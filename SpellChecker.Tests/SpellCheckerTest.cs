using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpellChecker.Tests
{
    
    
    /// <summary>
    ///This is a test class for SpellCheckerTest and is intended
    ///to contain all SpellCheckerTest Unit Tests
    ///</summary>
	[TestClass ()]
	[DeploymentItem ("SpellChecker.dll")]
	[DeploymentItem (@"dics\test\test.aff", @"dics\test")]
	[DeploymentItem (@"dics\test\test.dic", @"dics\test")]
	public class SpellCheckerTest
	{
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
		[TestMethod]
		public void CheckWordSpellTest ()
		{
			SpellChecker_Accessor sc = new SpellChecker_Accessor();
			sc.DictionariesPath = System.IO.Path.Combine (TestContext.TestDeploymentDir, @"dics");
			
			sc.SpellOptions.IgnoreUppercaseWords = true;
			Assert.IsTrue (sc.CheckWordSpell ("attention", "test"));
			Assert.IsTrue (sc.CheckWordSpell ("Attention", "test"));
			Assert.IsTrue (sc.CheckWordSpell ("ATTENTION", "test"));
			Assert.IsFalse (sc.CheckWordSpell ("ATTEntion", "test"));
			Assert.IsFalse (sc.CheckWordSpell ("ottention", "test"));

			sc.SpellOptions.IgnoreUppercaseWords = false;
			Assert.IsFalse (sc.CheckWordSpell ("ATTENTION", "test"));
			Assert.IsFalse (sc.CheckWordSpell ("ATTEntion", "test"));
		}



	}
}
