/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 14/05/2014
 * Time: 12:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NDesk.Options;

namespace nurl
{
	/// <summary>
	/// Description of EngineFeature.
	/// </summary>
	public class EngineFeature
	{
		public String FeatureValue { get; set; } // get or test
		public String UrlValue { get; set; } 
		public String SaveValue { get; set; } 
		public String TimesValue { get; set; } 
		public String AvgValue { get; set; } 
		
		public List<String> ArgumentsNotValid { get; set; }
		
		public EngineFeature()
		{
			
		}
		
		public EngineFeature(string[] args)
		{
			FeatureValue = args[0];
			
			OptionSet options = new OptionSet()
				.Add("url=|URL=", u => UrlValue = u)
				.Add("save=|SAVE=", s => SaveValue = s)
				.Add("times=|TIMES=", t => TimesValue = t)
				.Add("avg|AVG", a => AvgValue = a);
				
			ArgumentsNotValid = options.Parse(args);
		}
		
		public bool ArgumentsParseError()
		{
			if(ArgumentsNotValid.Count > 1)
				return true;
			
			return false;
		}
		
		public bool ArgumentsContainUrl()
		{
			if(UrlValue == null)
				return false;
			
			return true;
		}
		
		public bool ArgumentsContainSave()
		{
			if(SaveValue == null)
				return false;
			
			return true;
		}
		
		public bool ArgumentsTimesIsCorrect()
		{
			if(TimesValue == null)
				return false;
			
			int valueTimes;
			return int.TryParse(TimesValue,out valueTimes);
		}
		
		public bool ArgumentsContainAvg()
		{
			if(AvgValue == null)
				return false;
			
			return true;
		}
		
		public bool ArgumentsContainFeature()
		{
			if(FeatureValue == null || (FeatureValue != "get" && FeatureValue != "test"))
				return false;
			
			return true;
		}
		
		public void Start()
		{
			if(ArgumentsParseError() == true)
				throw new Exception("Too many arguments");
			
			if(FeatureValue.ToLower().Equals("get"))
			{
				if(ArgumentsTimesIsCorrect() || ArgumentsContainAvg())
					throw new Exception("Error arguments between GET and feature TEST");
				
				if(ArgumentsContainUrl())
				{
					FeatureGet get = new FeatureGet();
					
					if(ArgumentsContainSave())
					{
						if(get.SaveUrlInFile(UrlValue,SaveValue))
							Console.Write("{0} file saved",SaveValue);
						
						else
							Console.Write("Error file saved");
					}
					
					else
					{
						Console.Write(get.Show(UrlValue));
					}
				}
				
				else
					throw new Exception("Error argument it missing url argument");
			}
			
			else if(FeatureValue.ToLower().Equals("test"))
			{
				if(ArgumentsContainSave())
					throw new Exception("Error arguments between GET and feature TEST");
				
				if(ArgumentsContainUrl() && ArgumentsTimesIsCorrect())
				{
					FeatureTest test = new FeatureTest();
					List<double> list_times = test.ShowDownloadTimesOfUrlWithNumberOfTimes(UrlValue,int.Parse(TimesValue));
					
					if(ArgumentsContainAvg())
					{
						Console.Write("{0}",test.ShowAverageTimes(list_times));	
					}
					
					else
					{
						for(int i = 0 ; i < list_times.Count ; i++)
						{
							Console.Write("{0} ",list_times[i]);
						}
					}
				}
				
				else
					throw new Exception("Error argument it missing url argument or time is not correct");
			}
			
			else
			{
				throw new Exception("Feature incorrect");
			}
		}
	}
}
