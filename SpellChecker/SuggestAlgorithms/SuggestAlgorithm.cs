using System.Collections.Generic;
using SpellChecker.Dictionary;

namespace SpellChecker.SuggestAlgorithms
{
	internal abstract class SuggestAlgorithm
	{
		protected global::SpellChecker.SpellChecker spellChecker;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="spellChecker"></param>
		public SuggestAlgorithm (global::SpellChecker.SpellChecker spellChecker)
		{
			this.spellChecker= spellChecker;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="word">source word</param>
		/// <param name="suggestedWords">generated suggested words will be placed here</param>
		/// <param name="dic"></param>
		public abstract void Apply (string word, Dictionary<string, SpellSuggestion> suggestedWords, SpellDictionary dic);
	}
}
