using System;
using System.IO;
using System.Text;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Parser;

namespace IniParser
{
	public class FileIniDataParser : StreamIniDataParser
	{
		public FileIniDataParser()
		{
		}

		public FileIniDataParser(IniDataParser parser) : base(parser)
		{
			base.Parser = parser;
		}

		[Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
		public IniData LoadFile(string filePath)
		{
			return this.ReadFile(filePath);
		}

		[Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
		public IniData LoadFile(string filePath, Encoding fileEncoding)
		{
			return this.ReadFile(filePath, fileEncoding);
		}

		public IniData ReadFile(string filePath)
		{
			return this.ReadFile(filePath, Encoding.ASCII);
		}

		public IniData ReadFile(string filePath, Encoding fileEncoding)
		{
			if (filePath == string.Empty)
			{
				throw new ArgumentException("Bad filename.");
			}
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }
			IniData result;
			try
			{
				using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, fileEncoding))
					{
						result = base.ReadData(streamReader);
					}
				}
			}
			catch (IOException innerException)
			{
				throw new ParsingException(string.Format("Could not parse file {0}", filePath), innerException);
			}
			return result;
		}

		[Obsolete("Please use WriteFile method instead of this one as is more semantically accurate")]
		public void SaveFile(string filePath, IniData parsedData)
		{
			this.WriteFile(filePath, parsedData, Encoding.UTF8);
		}

		public void WriteFile(string filePath, IniData parsedData, Encoding fileEncoding = null)
		{
			if (fileEncoding == null)
			{
				fileEncoding = Encoding.UTF8;
			}
			if (string.IsNullOrEmpty(filePath))
			{
                return;
            }
            if (parsedData == null)
			{
                return;
			}
			using (FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(fileStream, fileEncoding))
				{
					base.WriteData(streamWriter, parsedData);
				}
			}
		}
	}
}
