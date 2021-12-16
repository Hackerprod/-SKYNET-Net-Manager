using System;
using IniParser.Model.Configuration;
using IniParser.Model.Formatting;

namespace IniParser.Model
{
	public class IniData : ICloneable
	{
		public IniData() : this(new SectionDataCollection())
		{
		}

		public IniData(SectionDataCollection sdc)
		{
			this._sections = (SectionDataCollection)sdc.Clone();
			this.Global = new KeyDataCollection();
			this.SectionKeySeparator = '.';
		}

		public IniData(IniData ori) : this(ori.Sections)
		{
			this.Global = (KeyDataCollection)ori.Global.Clone();
			this.Configuration = ori.Configuration.Clone();
		}

		public IniParserConfiguration Configuration
		{
			get
			{
				if (this._configuration == null)
				{
					this._configuration = new IniParserConfiguration();
				}
				return this._configuration;
			}
			set
			{
				this._configuration = value.Clone();
			}
		}

		public KeyDataCollection Global { get; protected set; }

		public KeyDataCollection this[string sectionName]
		{
			get
			{
				if (!this._sections.ContainsSection(sectionName))
				{
					if (!this.Configuration.AllowCreateSectionsOnFly)
					{
						return null;
					}
					this._sections.AddSection(sectionName);
				}
				return this._sections[sectionName];
			}
		}

		public SectionDataCollection Sections
		{
			get
			{
				return this._sections;
			}
			set
			{
				this._sections = value;
			}
		}

		public char SectionKeySeparator { get; set; }

		public override string ToString()
		{
			return this.ToString(new DefaultIniDataFormatter(this.Configuration));
		}

		public virtual string ToString(IIniDataFormatter formatter)
		{
			return formatter.IniDataToString(this);
		}

		public object Clone()
		{
			return new IniData(this);
		}

		public void ClearAllComments()
		{
			this.Global.ClearComments();
			foreach (SectionData sectionData in this.Sections)
			{
				sectionData.ClearComments();
			}
		}

		public void Merge(IniData toMergeIniData)
		{
			if (toMergeIniData == null)
			{
				return;
			}
			this.Global.Merge(toMergeIniData.Global);
			this.Sections.Merge(toMergeIniData.Sections);
		}

		public bool TryGetKey(string key, out string value)
		{
			value = string.Empty;
			if (string.IsNullOrEmpty(key))
			{
				return false;
			}
			string[] array = key.Split(new char[]
			{
				this.SectionKeySeparator
			});
			int num = array.Length - 1;
			if (num > 1)
			{
				throw new ArgumentException("key contains multiple separators", "key");
			}
			if (num == 0)
			{
				if (!this.Global.ContainsKey(key))
				{
					return false;
				}
				value = this.Global[key];
				return true;
			}
			else
			{
				string text = array[0];
				key = array[1];
				if (!this._sections.ContainsSection(text))
				{
					return false;
				}
				KeyDataCollection keyDataCollection = this._sections[text];
				if (!keyDataCollection.ContainsKey(key))
				{
					return false;
				}
				value = keyDataCollection[key];
				return true;
			}
		}

		public string GetKey(string key)
		{
			string result;
			if (!this.TryGetKey(key, out result))
			{
				return null;
			}
			return result;
		}

		private void MergeSection(SectionData otherSection)
		{
			if (!this.Sections.ContainsSection(otherSection.SectionName))
			{
				this.Sections.AddSection(otherSection.SectionName);
			}
			this.Sections.GetSectionData(otherSection.SectionName).Merge(otherSection);
		}

		private void MergeGlobal(KeyDataCollection globals)
		{
			foreach (KeyData keyData in globals)
			{
				this.Global[keyData.KeyName] = keyData.Value;
			}
		}

		private SectionDataCollection _sections;

		private IniParserConfiguration _configuration;
	}
}
