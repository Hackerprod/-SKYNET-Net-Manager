using System;
using System.Collections.Generic;
using System.Text;
using IniParser.Model.Configuration;

namespace IniParser.Model.Formatting
{
	public class DefaultIniDataFormatter : IIniDataFormatter
	{
		public DefaultIniDataFormatter() : this(new IniParserConfiguration())
		{
		}

		public DefaultIniDataFormatter(IniParserConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			this.Configuration = configuration;
		}

		public virtual string IniDataToString(IniData iniData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.Configuration.AllowKeysWithoutSection)
			{
				this.WriteKeyValueData(iniData.Global, stringBuilder);
			}
			foreach (SectionData section in iniData.Sections)
			{
				this.WriteSection(section, stringBuilder);
			}
			return stringBuilder.ToString();
		}

		public IniParserConfiguration Configuration
		{
			get
			{
				return this._configuration;
			}
			set
			{
				this._configuration = value.Clone();
			}
		}

		private void WriteSection(SectionData section, StringBuilder sb)
		{
			if (sb.Length > 0)
			{
				sb.Append(this.Configuration.NewLineStr);
			}
			this.WriteComments(section.Comments, sb);
			sb.Append(string.Format("{0}{1}{2}{3}", new object[]
			{
				this.Configuration.SectionStartChar,
				section.SectionName,
				this.Configuration.SectionEndChar,
				this.Configuration.NewLineStr
			}));
			this.WriteKeyValueData(section.Keys, sb);
			this.WriteComments(section.Comments, sb);
		}

		private void WriteKeyValueData(KeyDataCollection keyDataCollection, StringBuilder sb)
		{
			foreach (KeyData keyData in keyDataCollection)
			{
				if (keyData.Comments.Count > 0)
				{
					sb.Append(this.Configuration.NewLineStr);
				}
				this.WriteComments(keyData.Comments, sb);
				sb.Append(string.Format("{0}{3}{1}{3}{2}{4}", new object[]
				{
					keyData.KeyName,
					this.Configuration.KeyValueAssigmentChar,
					keyData.Value,
					this.Configuration.AssigmentSpacer,
					this.Configuration.NewLineStr
				}));
			}
		}

		private void WriteComments(List<string> comments, StringBuilder sb)
		{
			foreach (string arg in comments)
			{
				sb.Append(string.Format("{0}{1}{2}", this.Configuration.CommentString, arg, this.Configuration.NewLineStr));
			}
		}

		private IniParserConfiguration _configuration;
	}
}
