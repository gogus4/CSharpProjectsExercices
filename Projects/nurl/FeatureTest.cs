/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 14/05/2014
 * Time: 12:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;

namespace nurl
{
	/// <summary>
	/// Description of FeatureTest.
	/// </summary>
	public class FeatureTest
	{
		public FeatureTest()
		{
			
		}
				
		public double ShowDownloadTimeOfUrl(string url)
		{
			try
			{
				var featureGet = new FeatureGet();
				
				DateTime beforeDownload = DateTime.Now;
				
				if(featureGet.Show(url) == "<h1>hello</h1>")
					return 0;
					
				DateTime afterDownload = DateTime.Now;
				
				TimeSpan time_compare = afterDownload - beforeDownload;
					
				return time_compare.TotalMilliseconds;
			}
			catch(WebException e)
			{
				Debug.WriteLine(e.Message);
				return 0;
			}
		}
		
		public List<double> ShowDownloadTimesOfUrlWithNumberOfTimes(string url,int numberOfTimes)
		{
			List<double> list_times = new List<double>();
			
			for(int i = 0 ; i < numberOfTimes ; i++)
			{
				list_times.Add(ShowDownloadTimeOfUrl(url));
			}	
			
			return list_times;
		}
		
		public double ShowAverageTimes(List<double> list_times)
		{
			return list_times.Average();
		}
	}
}
