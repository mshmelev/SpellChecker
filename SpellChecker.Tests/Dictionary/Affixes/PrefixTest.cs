using SpellChecker.Dictionary.Affixes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SpellChecker.Tests.Dictionary.Affixes
{
    
    
    /// <summary>
    ///This is a test class for PrefixTest and is intended
    ///to contain all PrefixTest Unit Tests
    ///</summary>
	[TestClass ()]
	public class PrefixTest
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
			Prefix_Accessor sfx = Prefix_Accessor.Parse (new string[] { "PFX", "D", "a", "b", "cde" });
			Assert.AreEqual (sfx.addChars, "b");
			Assert.AreEqual (sfx.stripChars, "a");
			Assert.AreEqual (sfx.conditionChars, "cde");

			Assert.IsNull (Prefix.Parse (new string[] { "SFX", "D", "a", "b", "cde" }));
			Assert.IsNull (Prefix.Parse (new string[] { "" }));

			Assert.IsNull (Prefix.Parse (new string[] { "PFX", "D", "a", "0", "cde" }));

			sfx = Prefix_Accessor.Parse (new string[] { "PFX", "D", "0", "b", "." });
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
			Prefix pfx = Prefix.Parse (new string[] { "PFX", "A", "o", "un", "op" });
			Assert.AreEqual ("open", pfx.ApplyReverse ("unpen"));
			Assert.IsNull (pfx.ApplyReverse ("unreal"));

			pfx = Prefix.Parse (new string[] { "PFX", "A", "0", "pre", "." });
			Assert.AreEqual ("historic", pfx.ApplyReverse ("prehistoric"));
			Assert.IsNull (pfx.ApplyReverse ("prahistoric"));
		}
	}
}
