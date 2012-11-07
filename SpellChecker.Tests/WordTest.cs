using SpellChecker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SpellChecker.Tests
{
    
    
    /// <summary>
    ///This is a test class for WordTest and is intended
    ///to contain all WordTest Unit Tests
    ///</summary>
	[TestClass ()]
	[DeploymentItem ("SpellChecker.dll")]
	public class WordTest
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
		///A test for Text
		///</summary>
		[TestMethod ()]
		public void TextTest ()
		{
			Word w= new Word (2, 3, "012345");
			Assert.AreEqual (w.Text, "23");
			w = new Word (5, 5, "012345");
			Assert.AreEqual (w.Text, "5");
		}

		/// <summary>
		///A test for Equals
		///</summary>
		[TestMethod ()]
		public void EqualsTest ()
		{
			Word w1 = new Word (2, 3, "012345");
			Word w2 = new Word (2, 3, "012345");

			Assert.AreEqual (w1, w2);
			Assert.AreEqual (w1, w1);
			Assert.AreNotEqual (w1, new Word (2, 3, "asdfadsfds"));
			Assert.AreNotEqual (w1, null);
		}
	}
}
