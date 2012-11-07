using SpellChecker.Dictionary.Affixes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SpellChecker.Tests.Dictionary.Affixes
{
    
    
    /// <summary>
    ///This is a test class for SuffixTest and is intended
    ///to contain all SuffixTest Unit Tests
    ///</summary>
	[TestClass ()]
	public class SuffixTest
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
			Suffix_Accessor sfx = Suffix_Accessor.Parse (new string[] { "SFX", "D", "a", "b", "cde" });
			Assert.AreEqual (sfx.addChars, "b");
			Assert.AreEqual (sfx.stripChars, "a");
			Assert.AreEqual (sfx.conditionChars, "cde");

			Assert.IsNull (Suffix.Parse (new string[] { "PFX", "D", "a", "b", "cde" }) );
			Assert.IsNull (Suffix.Parse (new string[] { "" }));
			
			Assert.IsNull (Suffix.Parse (new string[] { "SFX", "D", "a", "0", "cde" }));

			sfx = Suffix_Accessor.Parse (new string[] { "SFX", "D", "0", "b", "." });
			Assert.AreEqual (sfx.addChars, "b");
			Assert.IsNull (sfx.stripChars);
			Assert.IsNull (sfx.conditionChars);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod ()]
		public void ApplyReverseTest ()
		{
			Suffix suffix = Suffix.Parse (new string[] {"SFX", "G", "e", "ing", "e"});
			Assert.AreEqual ("mine", suffix.ApplyReverse ("mining"));

			suffix = Suffix.Parse (new string[] { "SFX", "G", "0", "ing", "[^e]" });
			Assert.IsNull (suffix.ApplyReverse ("mine"));
			Assert.IsNull (suffix.ApplyReverse ("driveing"));
			Assert.AreEqual ("build", suffix.ApplyReverse ("building"));
		}


		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void CheckConditionTest ()
		{
			Suffix_Accessor sfx = Suffix_Accessor.Parse (new string[] { "SFX", "G", "0", "ing", "ab" });
			Assert.IsTrue (sfx.CheckCondition ("eeeab", false));
			Assert.IsTrue (sfx.CheckCondition ("ab", false));
			Assert.IsTrue (sfx.CheckCondition ("ab", true));
			Assert.IsFalse (sfx.CheckCondition ("eeeabc", false));
			Assert.IsTrue (sfx.CheckCondition ("abeeedd", true));
			Assert.IsFalse (sfx.CheckCondition ("acbeeedd", true));
			Assert.IsFalse (sfx.CheckCondition ("eeeab", true));
			Assert.IsFalse (sfx.CheckCondition ("a", true));
			Assert.IsFalse (sfx.CheckCondition ("a", false));
			Assert.IsFalse (sfx.CheckCondition ("", false));

			sfx = Suffix_Accessor.Parse (new string[] { "SFX", "G", "0", "ing", "[abcd].efg" });
			Assert.IsTrue (sfx.CheckCondition ("xxawefg", false));
			Assert.IsTrue (sfx.CheckCondition ("xxbxefg", false));
			Assert.IsTrue (sfx.CheckCondition ("xxcyefg", false));
			Assert.IsTrue (sfx.CheckCondition ("xxdzefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxezefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxawefh", false));
			Assert.IsFalse (sfx.CheckCondition ("cefg", false));
			Assert.IsTrue (sfx.CheckCondition ("awefg", true));
			Assert.IsTrue (sfx.CheckCondition ("bxefg", true));
			Assert.IsTrue (sfx.CheckCondition ("cyefg", true));
			Assert.IsTrue (sfx.CheckCondition ("dzefg", true));
			Assert.IsTrue (sfx.CheckCondition ("dzefgxxx", true));
			Assert.IsFalse (sfx.CheckCondition ("adzefgxxx", true));

			sfx = Suffix_Accessor.Parse (new string[] { "SFX", "G", "0", "ing", "[^abcd].efg" });
			Assert.IsTrue (sfx.CheckCondition ("xxmwefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxawefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxbxefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxcyefg", false));
			Assert.IsFalse (sfx.CheckCondition ("xxdzefg", false));
			Assert.IsFalse (sfx.CheckCondition ("wefg", false));
			Assert.IsTrue (sfx.CheckCondition ("mwefg", true));
			Assert.IsTrue (sfx.CheckCondition ("mwefgxx", true));
			Assert.IsFalse (sfx.CheckCondition ("awefg" ,true));
			Assert.IsFalse (sfx.CheckCondition ("bxefg", true));
			Assert.IsFalse (sfx.CheckCondition ("cyefg", true));
			Assert.IsFalse (sfx.CheckCondition ("dzefg", true));
			Assert.IsFalse (sfx.CheckCondition ("mnzefgxxx", true));

			sfx = Suffix_Accessor.Parse (new string[] { "SFX", "G", "0", "ing", "." });
			Assert.IsTrue (sfx.CheckCondition ("jkhgsairug", true));		// condition is ignoring
		}

	}
}
