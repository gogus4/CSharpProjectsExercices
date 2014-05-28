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
		public void ShowWithErrorUrl()
		{
			var featureGet = new FeatureGet();
			
			var command = featureGet.Show("http://tutoznet.free.fr/test123456.xml");
			
			Assert.AreEqual("<h1>hello</h1>", command);
		}
		#endregion
	}
}