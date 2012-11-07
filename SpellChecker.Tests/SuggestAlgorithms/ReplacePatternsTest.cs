using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Dictionary;
using SpellChecker.SuggestAlgorithms;

namespace SpellChecker.Tests.SuggestAlgorithms
{
	/// <summary>
	/// Summary description for ReplacePatternsTest
	/// </summary>
	[TestClass]
	[DeploymentItem (@"dics\test\test.aff", @"dics\test")]
	[DeploymentItem (@"dics\test\test.dic", @"dics\test")]
	public class ReplacePatternsTest
	{
		private static SpellDictionary dic;

		public ReplacePatternsTest ()
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
			ReplacePatterns sa = new ReplacePatterns (sc);
			Dictionary<string, SpellSuggestion> suggestedWords = new Dictionary<string, SpellSuggestion> ();

			sa.Apply ("thare", suggestedWords, dic);
			Assert.IsTrue (suggestedWords.Count == 1
				&& suggestedWords.ContainsKey ("their")
				&& suggestedWords["their"].EditDistance == 3);


			// check infinite cycles ("i" replaces to "igh")
			suggestedWords.Clear ();
			sa.Apply ("appliceition", suggestedWords, dic);
			Assert.IsTrue (suggestedWords.Count == 1
				&& suggestedWords.ContainsKey ("application")
				&& suggestedWords["application"].EditDistance == 2);
		}

	}
}
