using SpellChecker.Dictionary;
using SpellChecker.Dictionary.Affixes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpellChecker.Tests.Dictionary
{
    
    
    /// <summary>
    ///This is a test class for SpellDictionaryTest and is intended
    ///to contain all SpellDictionaryTest Unit Tests
    ///</summary>
	[TestClass ()]
	[DeploymentItem (@"dics\test\test.aff", @"dics\test")]
	[DeploymentItem (@"dics\test\test.dic", @"dics\test")]
	public class SpellDictionaryTest
	{
		private TestContext testContextInstance;
		private static SpellDictionary dic;


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
		///A test for Load
		///</summary>
		[TestMethod ()]
		public void LoadTest ()
		{
			SpellDictionary_Accessor d = new SpellDictionary_Accessor (new PrivateObject (dic));
			Assert.AreEqual (((AffixRulesCollection)d.affixRules.Target).Count, 23);
			//Assert.AreEqual (d.words.Keys.Count, 62118);
			Assert.AreEqual (d.TryCharacters, "esianrtolcdugmphbyfvkwzESIANRTOLCDUGMPHBYFVKWZ'");
			//Assert.AreEqual (d.ReplacePatterns.Count, 88);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod ()]
		public void IsWordCorrect ()
		{
			Assert.IsTrue (dic.IsWordCorrect ("smell"));
			Assert.IsTrue (dic.IsWordCorrect ("smells"));
			Assert.IsTrue (dic.IsWordCorrect ("smellable"));
			Assert.IsTrue (dic.IsWordCorrect ("smeller"));
			Assert.IsTrue (dic.IsWordCorrect ("smelled"));
			Assert.IsTrue (dic.IsWordCorrect ("smelling"));
			Assert.IsFalse (dic.IsWordCorrect ("smellly"));
			Assert.IsTrue (dic.IsWordCorrect ("affray"));
			Assert.IsTrue (dic.IsWordCorrect ("affrayed"));

			// several suffixes
			Assert.IsFalse (dic.IsWordCorrect ("smellers"));
			
			// invalid suffix
			Assert.IsFalse (dic.IsWordCorrect ("goed"));

			// prefix + suffix
			Assert.IsTrue (dic.IsWordCorrect ("sort"));
			Assert.IsTrue (dic.IsWordCorrect ("sorting"));
			Assert.IsTrue (dic.IsWordCorrect ("resort"));
			Assert.IsTrue (dic.IsWordCorrect ("resorting"));

			// prefix + prefix + suffix
			Assert.IsFalse (dic.IsWordCorrect ("reconsorting"));

			// uncombinable affixes
			Assert.IsTrue (dic.IsWordCorrect ("construct"));
			Assert.IsTrue (dic.IsWordCorrect ("constructive"));
			Assert.IsTrue (dic.IsWordCorrect ("reconstruct"));
			Assert.IsFalse (dic.IsWordCorrect ("reconstructive"));

			// check capitalization
			Assert.IsTrue (dic.IsWordCorrect ("USSR"));
			Assert.IsFalse (dic.IsWordCorrect ("UsSr"));
			Assert.IsFalse (dic.IsWordCorrect ("Ussr"));
			Assert.IsFalse (dic.IsWordCorrect ("ussr"));
			Assert.IsTrue (dic.IsWordCorrect ("smell"));
			Assert.IsTrue (dic.IsWordCorrect ("Smell"));
			Assert.IsFalse (dic.IsWordCorrect ("SMell"));
			Assert.IsFalse (dic.IsWordCorrect ("SMELL"));
		}




		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void AddUserWordTest ()
		{
			Assert.IsFalse (dic.IsWordCorrect ("ggghhhjjj"));
			Assert.IsTrue (dic.AddUserWord ("ggghhhjjj", true));
			Assert.IsTrue (dic.IsWordCorrect ("ggghhhjjj"));

			// reload dictionary
			LoadDictionary (TestContext);
			Assert.IsTrue (dic.IsWordCorrect ("ggghhhjjj"));
			
			// User dictionary isn't needed to delete cause it's created
			// in a temporary test folder.
		}
	}
}
