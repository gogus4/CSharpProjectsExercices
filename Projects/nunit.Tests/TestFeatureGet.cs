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
		public void Show_with_success_url()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test.xml");
			
			Assert.AreEqual("<PROGRAMMATION><ROW><NAME>DIEGO</NAME><AGE>20</AGE></ROW></PROGRAMMATION>",command);
		}
		
		[Test]
		public void Show_type_is_string()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test.xml");
			
			Assert.AreEqual(command.GetType(),typeof(string));
		}
		
		[Test]
		public void Show_with_error_url()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test123456.xml");
			
			Assert.AreEqual("<h1>hello</h1>", command);
		}
		#endregion
		
		#region SAVE FILE
		
		[Test]
		public void Save_url_type_is_boolean()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","file.txt");
			
			Assert.AreEqual(command.GetType(),typeof(Boolean));
		}
		
		[Test]
		public void Save_url_in_file_success()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","file.txt");
			
			Assert.AreEqual(true,result);
		}
		
		[Test]
		public void Save_url_in_file_with_error_url()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test12345.xml","file.txt");
			
			Assert.AreEqual(true,result);
		}
		
		[Test]
		public void Save_url_file_with_error_name_file()
		{
			var featureGet = new FeatureGet();
			
			var result = featureGet.SaveUrlInFile("http://tutoznet.free.fr/test.xml","\\file.txt");
			
			Assert.AreEqual(false,result);
		}
		
		[Test]
		public void Check_if_file_is_correctly_filled()
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