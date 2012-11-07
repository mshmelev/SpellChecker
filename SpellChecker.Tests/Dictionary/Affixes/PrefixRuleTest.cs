using SpellChecker.Dictionary.Affixes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SpellChecker.Tests.Dictionary.Affixes
{
    
    
    /// <summary>
    ///This is a test class for PrefixRuleTest and is intended
    ///to contain all PrefixRuleTest Unit Tests
    ///</summary>
	[TestClass ()]
	public class PrefixRuleTest
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

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for ParseAndAddAffix
		///</summary>
		[TestMethod ()]
		public void ParseAndAddAffixTest ()
		{
			PrefixRule r = (PrefixRule)AffixRule.Parse (new string[] { "PFX", "E", "N", "13" });
			PrefixRule_Accessor ra = new PrefixRule_Accessor (new PrivateObject (r));
			Assert.IsTrue (ra.ParseAndAddAffix (new string[] {"PFX", "E", "0", "un", "."}));
			//Assert.AreEqual (ra.affixes.Count, 1);
			//Assert.AreEqual (new Prefix_Accessor (new PrivateObject (ra.affixes[0])).addChars, "un");

			Assert.IsFalse (ra.ParseAndAddAffix (new string[] { "SFX", "E", "0", "un", "." }));
			//Assert.AreEqual (ra.affixes.Count, 1);
		}
	}
}
