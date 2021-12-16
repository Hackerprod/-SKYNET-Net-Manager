﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
	public class KeyDataCollection : ICloneable, IEnumerable<KeyData>, IEnumerable
	{
		public KeyDataCollection() : this(EqualityComparer<string>.Default)
		{
		}

		public KeyDataCollection(IEqualityComparer<string> searchComparer)
		{
			this._searchComparer = searchComparer;
			this._keyData = new Dictionary<string, KeyData>(this._searchComparer);
		}

		public KeyDataCollection(KeyDataCollection ori, IEqualityComparer<string> searchComparer) : this(searchComparer)
		{
			foreach (KeyData keyData in ori)
			{
				if (this._keyData.ContainsKey(keyData.KeyName))
				{
					this._keyData[keyData.KeyName] = (KeyData)keyData.Clone();
				}
				else
				{
					this._keyData.Add(keyData.KeyName, (KeyData)keyData.Clone());
				}
			}
		}

		public string this[string keyName]
		{
			get
			{
				if (this._keyData.ContainsKey(keyName))
				{
					return this._keyData[keyName].Value;
				}
				return null;
			}
			set
			{
				if (!this._keyData.ContainsKey(keyName))
				{
					this.AddKey(keyName);
				}
				this._keyData[keyName].Value = value;
			}
		}

		public int Count
		{
			get
			{
				return this._keyData.Count;
			}
		}

		public bool AddKey(string keyName)
		{
			if (!this._keyData.ContainsKey(keyName))
			{
				this._keyData.Add(keyName, new KeyData(keyName));
				return true;
			}
			return false;
		}

		[Obsolete("Pottentially buggy method! Use AddKey(KeyData keyData) instead (See comments in code for an explanation of the bug)")]
		public bool AddKey(string keyName, KeyData keyData)
		{
			if (this.AddKey(keyName))
			{
				this._keyData[keyName] = keyData;
				return true;
			}
			return false;
		}

		public bool AddKey(KeyData keyData)
		{
			if (this.AddKey(keyData.KeyName))
			{
				this._keyData[keyData.KeyName] = keyData;
				return true;
			}
			return false;
		}

		public bool AddKey(string keyName, string keyValue)
		{
			if (this.AddKey(keyName))
			{
				this._keyData[keyName].Value = keyValue;
				return true;
			}
			return false;
		}

		public void ClearComments()
		{
			foreach (KeyData keyData in this)
			{
				keyData.Comments.Clear();
			}
		}

		public bool ContainsKey(string keyName)
		{
			return this._keyData.ContainsKey(keyName);
		}

		public KeyData GetKeyData(string keyName)
		{
			if (this._keyData.ContainsKey(keyName))
			{
				return this._keyData[keyName];
			}
			return null;
		}

		public void Merge(KeyDataCollection keyDataToMerge)
		{
			foreach (KeyData keyData in keyDataToMerge)
			{
				this.AddKey(keyData.KeyName);
				this.GetKeyData(keyData.KeyName).Comments.AddRange(keyData.Comments);
				this[keyData.KeyName] = keyData.Value;
			}
		}

		public void RemoveAllKeys()
		{
			this._keyData.Clear();
		}

		public bool RemoveKey(string keyName)
		{
			return this._keyData.Remove(keyName);
		}

		public void SetKeyData(KeyData data)
		{
			if (data == null)
			{
				return;
			}
			if (this._keyData.ContainsKey(data.KeyName))
			{
				this.RemoveKey(data.KeyName);
			}
			this.AddKey(data);
		}

		public IEnumerator<KeyData> GetEnumerator()
		{
			foreach (string key in this._keyData.Keys)
			{
				yield return this._keyData[key];
			}
			//Dictionary<string, KeyData>.KeyCollection.Enumerator enumerator = default(Dictionary<string, KeyData>.KeyCollection.Enumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._keyData.GetEnumerator();
		}

		public object Clone()
		{
			return new KeyDataCollection(this, this._searchComparer);
		}

		internal KeyData GetLast()
		{
			KeyData result = null;
			if (this._keyData.Keys.Count <= 0)
			{
				return result;
			}
			foreach (string key in this._keyData.Keys)
			{
				result = this._keyData[key];
			}
			return result;
		}

		private IEqualityComparer<string> _searchComparer;

		private readonly Dictionary<string, KeyData> _keyData;
	}
}
