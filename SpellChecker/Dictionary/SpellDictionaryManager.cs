using System;
using System.Collections.Generic;

namespace SpellChecker.Dictionary
{
	/// <summary>
	/// Singletone
	/// </summary>
	internal sealed class SpellDictionaryManager
	{
		private readonly Dictionary<string, SpellDictionary> dictionaries;


		/// <summary>
		/// .ctor
		/// </summary>
		public SpellDictionaryManager ()
		{
			dictionaries = new Dictionary<string, SpellDictionary> ();

			string dicsFolder = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			dicsFolder = System.IO.Path.GetDirectoryName(dicsFolder);
			dicsFolder = System.IO.Path.Combine(dicsFolder, "dics");
			DictionariesBaseFolder = dicsFolder;
		}



		/// <summary>
		/// Returns dictionary for the passed culture.
		/// </summary>
		/// <param name="cultName">e.g., "en-US", or "ru-RU"</param>
		/// <returns>null, if there's no such dictionary</returns>
		public SpellDictionary GetDictionary (string cultName)
		{
			SpellDictionary dict= null;
			cultName = cultName.ToLower ();
			if (dictionaries.ContainsKey (cultName))
			{
				dict = dictionaries[cultName];
			}
			else
			{
				try
				{
					dict = new SpellDictionary (cultName);
					
					string path = System.IO.Path.Combine (DictionariesBaseFolder, cultName);
					dict.Load (path);

					dictionaries.Add (cultName, dict);
				}
				catch (Exception)
				{
					dict= null;
				}
			}

			return dict;
		}




		/// <summary>
		/// 
		/// </summary>
		public string DictionariesBaseFolder
		{
			get; set;
		}



		/// <summary>
		/// 
		/// </summary>
		public void ReloadDictionaries()
		{
			dictionaries.Clear();
		}



	}
}
