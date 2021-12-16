using System;
using System.IO;
using IniParser.Model;
using IniParser.Model.Formatting;
using IniParser.Parser;

namespace IniParser
{
	public class StreamIniDataParser
	{
		public IniDataParser Parser { get; protected set; }

		public StreamIniDataParser() : this(new IniDataParser())
		{
		}

		public StreamIniDataParser(IniDataParser parser)
		{
			this.Parser = parser;
		}

		public IniData ReadData(StreamReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			return this.Parser.Parse(reader.ReadToEnd());
		}

		public void WriteData(StreamWriter writer, IniData iniData)
		{
			if (iniData == null)
			{
                return;
			}
			if (writer == null)
			{
                return;
            }
            writer.Write(iniData.ToString());
		}

		public void WriteData(StreamWriter writer, IniData iniData, IIniDataFormatter formatter)
		{
			if (formatter == null)
			{
				throw new ArgumentNullException("formatter");
			}
			if (iniData == null)
			{
				throw new ArgumentNullException("iniData");
			}
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.Write(iniData.ToString(formatter));
		}
	}
}
