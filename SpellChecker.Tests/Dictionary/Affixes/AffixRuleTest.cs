using SpellChecker.Dictionary.Affixes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SpellChecker.Tests.Dictionary.Affixes
{
    
    
    /// <summary>
    ///This is a test class for AffixRuleTest and is intended
    ///to contain all AffixRuleTest Unit Tests
    ///</summary>
	[TestClass ()]
	public class AffixRuleTest
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
		///A test for Parse
		///</summary>
		[TestMethod ()]
		public void ParseTest ()
		{
			AffixRule r= AffixRule.Parse (new string[] { "SFX", "D", "Y", "12" });
			Assert.IsInstanceOfType (r, typeof (SuffixRule));
			SuffixRule_Accessor sr = new SuffixRule_Accessor (new PrivateObject (r));
			Assert.IsTrue (sr.canCombine);
			Assert.AreEqual (sr.name, 'D');

			r = AffixRule.Parse (new string[] { "PFX", "E", "N", "13" });
			Assert.IsInstanceOfType (r, typeof (PrefixRule));
			PrefixRule_Accessor pr = new PrefixRule_Accessor (new PrivateObject (r));
			Assert.IsFalse (pr.canCombine);
			Assert.AreEqual (pr.name, 'E');

			Assert.IsNull (AffixRule.Parse (new string[] { "AFX", "E", "N", "13" }));
			Assert.IsNull (AffixRule.Parse (new string[] { "SFX", "E", "N", "13", "22" }));
		}
	}
}
