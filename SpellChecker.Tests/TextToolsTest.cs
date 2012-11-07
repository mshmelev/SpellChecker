using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpellChecker.Tests
{
	/// <summary>
	/// Summary description for TextToolsTest
	/// </summary>
	[TestClass]
	[DeploymentItem ("SpellChecker.dll")]
	public class TextToolsTest
	{
		public TextToolsTest ()
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

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion



		/// <summary>
		///A test for GetWords
		///</summary>
		[TestMethod ()]
		public void GetWordsTest ()
		{
			string s;

			s = "aa bb";
			Assert.IsTrue (TextTools.GetWords (s).ListEquals (new List<Word> {
				new Word(0, 1, s),
				new Word(3, 4, s)}));

			s = "aa bb ";
			Assert.IsTrue (TextTools.GetWords (s).ListEquals (new List<Word> {
				new Word(0, 1, s),
				new Word(3, 4, s)}));

			s = "a b c";
			Assert.IsTrue (TextTools.GetWords (s).ListEquals (new List<Word> {
				new Word(0, 0, s),
				new Word(2, 2, s),
				new Word(4, 4, s)}));

			s = "aa bb,,cc, dd! ee? ff!!! gg...";
			Assert.IsTrue (TextTools.GetWords (s).ListEquals (new List<Word> {
				new Word(0, 1, s),
				new Word(3, 4, s),
				new Word(7, 8, s),
				new Word(11, 12, s),
				new Word(15, 16, s),
				new Word(19, 20, s),
				new Word(25, 26, s)}));

			Assert.IsTrue (TextTools.GetWords ("").ListEquals (new List<Word> ()));
		}




		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void IsUppercaseWordTest()
		{
			Assert.IsTrue (TextTools.IsUppercaseText ("SJKGHADF"));
			Assert.IsTrue (TextTools.IsUppercaseText ("FH478)FHDS__+ASD"));
			Assert.IsTrue (TextTools.IsUppercaseText ("F"));
			Assert.IsFalse (TextTools.IsUppercaseText ("FGKJ40Ss"));
			Assert.IsTrue (TextTools.IsUppercaseText ("АРШГРВ98АФЫАРП"));
			Assert.IsFalse (TextTools.IsUppercaseText ("АРШГРВ98АФЫАРп"));
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EndsWithTest ()
		{
			Assert.IsTrue (TextTools.EndsWith ("dsagrtgv3245rsdf2", "5rsdf2"));
			Assert.IsTrue (TextTools.EndsWith ("abcdef", "abcdef"));
			Assert.IsTrue (TextTools.EndsWith ("abcdef", "f"));
			Assert.IsTrue (TextTools.EndsWith ("abcdef", ""));
			Assert.IsFalse (TextTools.EndsWith ("", "sadfdsfdsaf"));
			Assert.IsFalse (TextTools.EndsWith ("abcde", "abcdef"));
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void GetTextCultureTest ()
		{
			Assert.AreEqual (TextTools.GetTextCulture ("fdsa adf7drtf w87ergsdf 873r"), "en-US");
			Assert.AreEqual (TextTools.GetTextCulture ("fdsa adf7drtf пн45выа 873r"), "ru-RU");
		}

	
	}
}
