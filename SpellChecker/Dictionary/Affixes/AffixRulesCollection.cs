using System.Collections.Generic;

namespace SpellChecker.Dictionary.Affixes
{
	internal class AffixRulesCollection : List<AffixRule>
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public AffixRulesCollection ()
		{
		}


		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="collection"></param>
		public AffixRulesCollection (IEnumerable<AffixRule> collection)
			: base (collection)
		{
		}

	}
}
