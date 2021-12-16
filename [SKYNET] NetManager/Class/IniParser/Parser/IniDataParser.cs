using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Model.Configuration;

namespace IniParser.Parser
{
	public class IniDataParser
	{
		public IniDataParser() : this(new IniParserConfiguration())
		{
		}

		public IniDataParser(IniParserConfiguration parserConfiguration)
		{
			if (parserConfiguration == null)
			{
				throw new ArgumentNullException("parserConfiguration");
			}
			this.Configuration = parserConfiguration;
			this._errorExceptions = new List<Exception>();
		}

		public virtual IniParserConfiguration Configuration { get; protected set; }

		public bool HasError
		{
			get
			{
				return this._errorExceptions.Count > 0;
			}
		}

		public ReadOnlyCollection<Exception> Errors
		{
			get
			{
				return this._errorExceptions.AsReadOnly();
			}
		}

		public IniData Parse(string iniDataString)
		{
			IniData iniData = this.Configuration.CaseInsensitive ? new IniDataCaseInsensitive() : new IniData();
			iniData.Configuration = this.Configuration.Clone();
			if (string.IsNullOrEmpty(iniDataString))
			{
				return iniData;
			}
			this._errorExceptions.Clear();
			this._currentCommentListTemp.Clear();
			this._currentSectionNameTemp = null;
			try
			{
				string[] array = iniDataString.Split(new string[]
				{
					"\n",
					"\r\n"
				}, StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (!(text.Trim() == string.Empty))
					{
						try
						{
							this.ProcessLine(text, iniData);
						}
						catch (Exception ex)
						{
							ParsingException ex2 = new ParsingException(ex.Message, i + 1, text, ex);
							if (this.Configuration.ThrowExceptionsOnError)
							{
								throw ex2;
							}
							this._errorExceptions.Add(ex2);
						}
					}
				}
				if (this._currentCommentListTemp.Count > 0)
				{
					if (iniData.Sections.Count > 0)
					{
						iniData.Sections.GetSectionData(this._currentSectionNameTemp).Comments.AddRange(this._currentCommentListTemp);
					}
					else if (iniData.Global.Count > 0)
					{
						iniData.Global.GetLast().Comments.AddRange(this._currentCommentListTemp);
					}
					this._currentCommentListTemp.Clear();
				}
			}
			catch (Exception item)
			{
				this._errorExceptions.Add(item);
				if (this.Configuration.ThrowExceptionsOnError)
				{
					throw;
				}
			}
			if (this.HasError)
			{
				return null;
			}
			return (IniData)iniData.Clone();
		}

		protected virtual bool LineContainsAComment(string line)
		{
			return !string.IsNullOrEmpty(line) && this.Configuration.CommentRegex.Match(line).Success;
		}

		protected virtual bool LineMatchesASection(string line)
		{
			return !string.IsNullOrEmpty(line) && this.Configuration.SectionRegex.Match(line).Success;
		}

		protected virtual bool LineMatchesAKeyValuePair(string line)
		{
			return !string.IsNullOrEmpty(line) && line.Contains(this.Configuration.KeyValueAssigmentChar.ToString());
		}

		protected virtual string ExtractComment(string line)
		{
			string text = this.Configuration.CommentRegex.Match(line).Value.Trim();
			this._currentCommentListTemp.Add(text.Substring(1, text.Length - 1));
			return line.Replace(text, "").Trim();
		}

		protected virtual void ProcessLine(string currentLine, IniData currentIniData)
		{
			currentLine = currentLine.Trim();
			if (this.LineContainsAComment(currentLine))
			{
				currentLine = this.ExtractComment(currentLine);
			}
			if (currentLine == string.Empty)
			{
				return;
			}
			if (this.LineMatchesASection(currentLine))
			{
				this.ProcessSection(currentLine, currentIniData);
				return;
			}
			if (this.LineMatchesAKeyValuePair(currentLine))
			{
				this.ProcessKeyValuePair(currentLine, currentIniData);
				return;
			}
			if (this.Configuration.SkipInvalidLines)
			{
				return;
			}
			throw new ParsingException("Unknown file format. Couldn't parse the line: '" + currentLine + "'.");
		}

		protected virtual void ProcessSection(string line, IniData currentIniData)
		{
			string text = this.Configuration.SectionRegex.Match(line).Value.Trim();
			text = text.Substring(1, text.Length - 2).Trim();
			if (text == string.Empty)
			{
				throw new ParsingException("Section name is empty");
			}
			this._currentSectionNameTemp = text;
			if (!currentIniData.Sections.ContainsSection(text))
			{
				currentIniData.Sections.AddSection(text);
				currentIniData.Sections.GetSectionData(text).Comments.AddRange(this._currentCommentListTemp);
				this._currentCommentListTemp.Clear();
				return;
			}
			if (this.Configuration.AllowDuplicateSections)
			{
				return;
			}
			throw new ParsingException(string.Format("Duplicate section with name '{0}' on line '{1}'", text, line));
		}

		protected virtual void ProcessKeyValuePair(string line, IniData currentIniData)
		{
			string text = this.ExtractKey(line);
			if (string.IsNullOrEmpty(text) && this.Configuration.SkipInvalidLines)
			{
				return;
			}
			string value = this.ExtractValue(line);
			if (!string.IsNullOrEmpty(this._currentSectionNameTemp))
			{
				SectionData sectionData = currentIniData.Sections.GetSectionData(this._currentSectionNameTemp);
				this.AddKeyToKeyValueCollection(text, value, sectionData.Keys, this._currentSectionNameTemp);
				return;
			}
			if (!this.Configuration.AllowKeysWithoutSection)
			{
				throw new ParsingException("key value pairs must be enclosed in a section");
			}
			this.AddKeyToKeyValueCollection(text, value, currentIniData.Global, "global");
		}

		protected virtual string ExtractKey(string s)
		{
			int length = s.IndexOf(this.Configuration.KeyValueAssigmentChar, 0);
			return s.Substring(0, length).Trim();
		}

		protected virtual string ExtractValue(string s)
		{
			int num = s.IndexOf(this.Configuration.KeyValueAssigmentChar, 0);
			return s.Substring(num + 1, s.Length - num - 1).Trim();
		}

		protected virtual void HandleDuplicatedKeyInCollection(string key, string value, KeyDataCollection keyDataCollection, string sectionName)
		{
			if (!this.Configuration.AllowDuplicateKeys)
			{
				throw new ParsingException(string.Format("Duplicated key '{0}' found in section '{1}", key, sectionName));
			}
			if (this.Configuration.OverrideDuplicateKeys)
			{
				keyDataCollection[key] = value;
			}
		}

		private void AddKeyToKeyValueCollection(string key, string value, KeyDataCollection keyDataCollection, string sectionName)
		{
			if (keyDataCollection.ContainsKey(key))
			{
				this.HandleDuplicatedKeyInCollection(key, value, keyDataCollection, sectionName);
			}
			else
			{
				keyDataCollection.AddKey(key, value);
			}
			keyDataCollection.GetKeyData(key).Comments = this._currentCommentListTemp;
			this._currentCommentListTemp.Clear();
		}

		private List<Exception> _errorExceptions;

		private readonly List<string> _currentCommentListTemp = new List<string>();

		private string _currentSectionNameTemp;
	}
}
