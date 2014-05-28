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
		public void Arguments_contain_feature_is_boolean()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(typeof(Boolean), engineFeature.ArgumentsContainFeature().GetType());
		}
		
		[Test]
		public void Arguments_contain_geature_get()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainFeature());
		}
		
		[Test]
		public void Arguments_not_contain_feature_get()
		{
			string[] args = { "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainFeature());
		}
		
		#endregion
		
		#region FEATURE TEST	
		
		[Test]
		public void Arguments_contain_feature_test()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainFeature());
		}
		
		[Test]
		public void Arguments_not_contain_feature_test()
		{
			string[] args = { "-url", "\"http://abc\"", "-times", "5", "-avg"};

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainFeature());
		}
		
		#endregion
	
		#region ARGUMENTS PARSE		

		[Test]
		public void Arguments_parse_is_boolean()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(typeof(Boolean), engineFeature.ArgumentsParseError().GetType());
		}
	
		[Test]
		public void Arguments_parse_error()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg","-error" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsParseError());
		}
		
		[Test]
		public void Arguments_parse_not_error()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsParseError());
		}
		
		#endregion
		
		#region URL ARGUMENT
		
		[Test]
		public void Arguments_contain_url_is_boolean()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(typeof(Boolean), engineFeature.ArgumentsContainUrl().GetType());
		}
		
		[Test]
		public void Arguments_contain_url()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainUrl());
		}
		
		[Test]
		public void Arguments_not_contain_url()
		{
			string[] args = { "test","\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainUrl());
		}
		#endregion
		
		#region SAVE ARGUMENT
		[Test]
		public void Arguments_contain_save_is_boolean()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(typeof(Boolean), engineFeature.ArgumentsContainSave().GetType());
		}
		
		[Test]
		public void Arguments_contain_save()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainSave());
		}
		
		[Test]
		public void Arguments_not_contain_save()
		{
			string[] args = { "get","\"http://abc\""};

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainSave());
		}
		#endregion
		
		#region AVG ARGUMENT
		[Test]
		public void Arguments_contain_avg_is_boolean()
		{
			string[] args = { "get", "-url", "\"http://abc\"", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(typeof(Boolean), engineFeature.ArgumentsContainAvg().GetType());
		}
		
		[Test]
		public void Arguments_not_contain_avg()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(false, engineFeature.ArgumentsContainAvg());
		}
		
		[Test]
		public void Arguments_contain_avg()
		{
			string[] args = { "test", "-url", "\"http://abc\"", "-times", "5", "-avg" };

			var engineFeature = new EngineFeature(args);
			
			Assert.AreEqual(true, engineFeature.ArgumentsContainAvg());
		}
		#endregion
		
		#region TEST ARGUMENTS TIMES
		[Test]
		public void Arguments_times_is_not_correct()
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
		public void Start_method_fail_feature()
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
		public void Arguments_feature_get_missing()
		{
			string[] args = { "get", "-save", "file.txt" };

			var engineFeature = new EngineFeature(args);
			
			try
			{
				engineFeature.Start();
			}
			catch(Exception e)
			{
				Assert.AreEqual("Error argument it missing url argument", e.Message);
			}
		}
		
		[Test]
		public void Arguments_feature_test_missing()
		{
			string[] args = { "test","-url","\"http://abc\""};

			var engineFeature = new EngineFeature(args);
			
			try
			{
				engineFeature.Start();
			}
			catch(Exception e)
			{
				Assert.AreEqual("Error argument it missing url argument or time is not correct", e.Message);
			}
		}
	
		
		[Test]
		public void Start_method_too_many_arguments()
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
		
		[Test]
		public void Start_method_error_mixture_between_get_and_test_arguments()
		{
			string[] args = { "test","-url","\"http://abc\"", "-times", "5", "-avg","-save","file.txt"};

			var engineFeature = new EngineFeature(args);
			
			try
			{
				engineFeature.Start();
			}
			catch(Exception E)
			{
				Assert.AreEqual("Error arguments between GET and feature TEST",E.Message);
			}
		}
		
		#endregion
	}
}