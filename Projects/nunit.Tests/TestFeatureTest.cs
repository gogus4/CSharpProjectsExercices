using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using nurl;

namespace nurl.Tests
{
	[TestFixture]
	public class TestFeatureTest
	{		
		public FeatureTest featureTest = new FeatureTest();
		
		#region DOWNLOAD TIME
		
		[Test]
		public void Show_download_time_is_double()
		{
			var type = featureTest.ShowDownloadTimeOfUrl("http://tutoznet.free.fr/test.xml");
			
			Assert.AreEqual(type.GetType(),typeof(double));
		}
		
		[Test]
		public void Show_download_time_success()
		{
			var time = featureTest.ShowDownloadTimeOfUrl("http://tutoznet.free.fr/test.xml");
			
			Assert.AreNotEqual(0,time);
		}
		
		[Test]
		public void Show_download_time_error()
		{
			var time = featureTest.ShowDownloadTimeOfUrl("http://tutoznet.free.fr/test123456.xml");
			
			Assert.AreEqual(0,time);
		}
		
		#endregion
		
		#region DOWNLOAD TIME WITH NUMBER OF TIMES
		
		[Test]
		public void Show_download_time_with_number_of_times_is_list()
		{
			var type = featureTest.ShowDownloadTimesOfUrlWithNumberOfTimes("http://tutoznet.free.fr/test.xml",5);
			
			Assert.AreEqual(type.GetType(),typeof(List<double>));
		}
		
		[Test]
		public void Show_download_time_with_number_of_times_success()
		{
			var listDouble = featureTest.ShowDownloadTimesOfUrlWithNumberOfTimes("http://tutoznet.free.fr/test.xml",5);

			Assert.AreNotEqual((ICollection)new [] {0,0,0,0,0},listDouble);
		}
		
		[Test]
		public void Show_download_time_with_number_of_times_error()
		{
			var listDouble = featureTest.ShowDownloadTimesOfUrlWithNumberOfTimes("http://tutoznet.free.fr/test123456.xml",5);

			Assert.AreEqual((ICollection)new [] {0,0,0,0,0},listDouble);
		}
		
		#endregion
		
		#region DOWNLOAD TIME AVERAGE
		
		[Test]
		public void Show_average_time_is_double()
		{
			var type = featureTest.ShowAverageTimes(new List<double>() { 1232,2121,21212,33232 });
			
			Assert.AreEqual(type.GetType(),typeof(double));
		}
		
		[Test]
		public void Show_average_time_success()
		{
			var average = featureTest.ShowAverageTimes(new List<double>() { 10,15,20,25 });

			Assert.AreEqual(17.5,average);
		}
		
		[Test]
		public void Show_average_time_error()
		{
			var average = featureTest.ShowAverageTimes(new List<double>() { 0,0,0,0});

			Assert.AreEqual(0,average);
		}
		
		#endregion
	}
}