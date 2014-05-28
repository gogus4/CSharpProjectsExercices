using System;
using NUnit.Framework;
using nurl;

namespace nurl.Tests
{
	[TestFixture]
	public class TestFeatureGet
	{		
		#region SHOW URL
		[Test]
		public void ShowWithSuccessUrl()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test.xml");
			
			Assert.AreEqual("<PROGRAMMATION><ROW><NAME>DIEGO</NAME><AGE>20</AGE></ROW></PROGRAMMATION>",command);
		}
		
		[Test]
		public void ShowTypeIsString()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test.xml");
			
			Assert.AreEqual(command.GetType(),typeof(string));
		}
		
		[Test]
		public void ShowWithErrorUrl()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test123456.xml");
			
			Assert.AreEqual("<h1>hello</h1>", command);
		}
		#endregion
		
		#region SAVE FILE
		
		[Test]
		public void SaveUrlTypeIsBoolean()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","file.txt");
			
			Assert.AreEqual(command.GetType(),typeof(Boolean));
		}
		
		[Test]
		public void SaveUrlInFileSuccess()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","file.txt");
			
			Assert.AreEqual(true,result);
		}
		
		[Test]
		public void SaveUrlInFileWithErrorUrl()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test12345.xml","file.txt");
			
			Assert.AreEqual(true,result);
		}
		
		[Test]
		public void SaveUrlInFileWithErrorNameFile()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","\\file.txt");
			
			Assert.AreEqual(false,result);
		}
		
		[Test]
		public void CheckIfFileIsCorrectlyFilled()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","file.txt");
			
			Assert.AreEqual(true,result);
			
			var readLine = System.IO.File.ReadAllText(@"file.txt");
			
			Assert.AreEqual("<PROGRAMMATION><ROW><NAME>DIEGO</NAME><AGE>20</AGE></ROW></PROGRAMMATION>\r\n",readLine);
		}
		
		#endregion
	}
}