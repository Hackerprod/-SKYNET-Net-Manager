using System;
using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
	public class SectionDataCollection : ICloneable, IEnumerable<SectionData>, IEnumerable
	{
		public SectionDataCollection() : this(EqualityComparer<string>.Default)
		{
		}

		public SectionDataCollection(IEqualityComparer<string> searchComparer)
		{
			this._searchComparer = searchComparer;
			this._sectionData = new Dictionary<string, SectionData>(this._searchComparer);
		}

		public SectionDataCollection(SectionDataCollection ori, IEqualityComparer<string> searchComparer)
		{
			this._searchComparer = (searchComparer ?? EqualityComparer<string>.Default);
			this._sectionData = new Dictionary<string, SectionData>(this._searchComparer);
			foreach (SectionData sectionData in ori)
			{
				this._sectionData.Add(sectionData.SectionName, (SectionData)sectionData.Clone());
			}
		}

		public int Count
		{
			get
			{
				return this._sectionData.Count;
			}
		}

		public KeyDataCollection this[string sectionName]
		{
			get
			{
				if (this._sectionData.ContainsKey(sectionName))
				{
					return this._sectionData[sectionName].Keys;
				}
				return null;
			}
		}

		public bool AddSection(string keyName)
		{
			if (!this.ContainsSection(keyName))
			{
				this._sectionData.Add(keyName, new SectionData(keyName, this._searchComparer));
				return true;
			}
			return false;
		}

		public void Add(SectionData data)
		{
			if (this.ContainsSection(data.SectionName))
			{
				this.SetSectionData(data.SectionName, new SectionData(data, this._searchComparer));
				return;
			}
			this._sectionData.Add(data.SectionName, new SectionData(data, this._searchComparer));
		}

		public void Clear()
		{
			this._sectionData.Clear();
		}

		public bool ContainsSection(string keyName)
		{
			return this._sectionData.ContainsKey(keyName);
		}

		public SectionData GetSectionData(string sectionName)
		{
			if (this._sectionData.ContainsKey(sectionName))
			{
				return this._sectionData[sectionName];
			}
			return null;
		}

		public void Merge(SectionDataCollection sectionsToMerge)
		{
			foreach (SectionData sectionData in sectionsToMerge)
			{
				if (this.GetSectionData(sectionData.SectionName) == null)
				{
					this.AddSection(sectionData.SectionName);
				}
				this[sectionData.SectionName].Merge(sectionData.Keys);
			}
		}

		public void SetSectionData(string sectionName, SectionData data)
		{
			if (data != null)
			{
				this._sectionData[sectionName] = data;
			}
		}

		public bool RemoveSection(string keyName)
		{
			return this._sectionData.Remove(keyName);
		}

		public IEnumerator<SectionData> GetEnumerator()
		{
			foreach (string key in this._sectionData.Keys)
			{
				yield return this._sectionData[key];
			}
			//Dictionary<string, SectionData>.KeyCollection.Enumerator enumerator = default(Dictionary<string, SectionData>.KeyCollection.Enumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public object Clone()
		{
			return new SectionDataCollection(this, this._searchComparer);
		}

		private IEqualityComparer<string> _searchComparer;

		private readonly Dictionary<string, SectionData> _sectionData;
	}
}
