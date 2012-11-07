using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Dictionary;
using SpellChecker.SuggestAlgorithms;

namespace SpellChecker.Tests.SuggestAlgorithms
{
	/// <summary>
	/// Summary description for SplitWordsTest
	/// </summary>
	[TestClass]
	[DeploymentItem (@"dics\test\test.aff", @"dics\test")]
	[DeploymentItem (@"dics\test\test.dic", @"dics\test")]
	public class SplitWordsTest
	{
		private static SpellDictionary dic;

		public SplitWordsTest ()
		{
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}



		/// <summary>
		/// 
		/// </summary>
		[ClassInitialize]
		public static void LoadDictionary (TestContext testContext)
		{
			dic = new SpellDictionary ("test");
			string path = System.IO.Path.Combine (testContext.TestDeploymentDir, @"dics\test");
			dic.Load (path);
		}


		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void ApplyTest ()
		{
			SpellChecker sc = new SpellChecker ();
			SplitWords sa = new SplitWords (sc);
			Dictionary<string, SpellSuggestion> suggestedWords = new Dictionary<string, SpellSuggestion> ();

			sa.Apply ("gohome", suggestedWords, dic);
			Assert.IsTrue (suggestedWords.Count == 1
				&& suggestedWords.ContainsKey ("go home")
				&& suggestedWords["go home"].EditDistance == 1);

			suggestedWords.Clear ();
			sa.Apply ("aq", suggestedWords, dic);
			Assert.IsTrue (suggestedWords.Count == 1
				&& suggestedWords.ContainsKey ("a q")
				&& suggestedWords["a q"].EditDistance == 1);
		}


	}
}
