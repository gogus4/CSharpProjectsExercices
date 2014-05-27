using System;
using NUnit.Framework;
using nurl;

namespace nurl.Tests
{
	[TestFixture]
	public class TestEngineFeature
	{	
		#region FEATURE GET		
		[Test]
		public void ArgumentsContainFeatureGet()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainFeature());
		}
		
		[Test]
		public void ArgumentsNotContainFeatureGet()
		{
			string[] args = { "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainFeature());
		}
		
		#endregion
		
		#region FEATURE TEST	
		[Test]
		public void ArgumentsContainFeatureTest()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainFeature());
		}
		
		[Test]
		public void ArgumentsNotContainFeatureTest()
		{
			string[] args = { "-url", "\"http://abc\"", "-times", "5", "-avg"};

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainFeature());
		}
		
		#endregion
	
		#region ARGUMENTS PARSE			
		[Test]
		public void ArgumentsParseError()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg","-error" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsParseError());
		}
		
		[Test]
		public void ArgumentsParseNotError()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsParseError());
		}
		
		#endregion
		
		#region URL ARGUMENT
		[Test]
		public void ArgumentsContainUrl()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainUrl());
		}
		
		[Test]
		public void ArgumentsNotContainUrl()
		{
			string[] args = { "test","\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainUrl());
		}
		#endregion
		
		#region SAVE ARGUMENT
		[Test]
		public void ArgumentsContainSave()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainSave());
		}
		
		[Test]
		public void ArgumentsNotContainSave()
		{
			string[] args = { "get","\"http://abc\""};

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainSave());
		}
		#endregion
		
		#region AVG ARGUMENT
		[Test]
		public void ArgumentsNotContainAvg()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainAvg());
		}
		
		[Test]
		public void ArgumentsContainAvg()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainAvg());
		}
		#endregion
		
		#region TEST ARGUMENTS TIMES
		[Test]
		public void ArgumentsTimesIsNotCorrect()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5azbdsds", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsTimesIsCorrect());
		}
		
		[Test]
		public void ArgumentsTimesIsCorrect()
		{
			string[] args = { "test","-url","\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsTimesIsCorrect());
		}
		#endregion
		
		#region START METHOD
		
		[Test]
		public void StartMethodFailFeature()
		{
			string[] args = { "testml","-url","\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			try
			{
				engineFeature.Start();
			}
			catch(Exception E)
			{
				Assert.AreEqual("Feature incorrect",E.Message);
			}
		}
		
		[Test]
		public void StartMethodSuccessFeature()
		{
			string[] args = { "test","-url","\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			engineFeature.Start();
		}
		
		[Test]
		public void StartMethodTooManyArguments()
		{
			string[] args = { "test","-url","\"http://abc\"", "-times", "5", "-avg","-error","-ok" };

			var engineFeature = new EngineFeature(args);
			
			try
			{
				engineFeature.Start();
			}
			catch(Exception E)
			{
				Assert.AreEqual("Too many arguments",E.Message);
			}
		}
		
		// Error arguments between GET and feature TEST
		
		#endregion
		
		
	}
}