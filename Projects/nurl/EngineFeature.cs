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
using System.IO;
using System.Net;
using System.Text;
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
				Console.WriteLine("GET");
				
				if(ArgumentsTimesIsCorrect() || ArgumentsContainAvg())
					throw new Exception("Error arguments between GET and feature TEST");
				
				if(ArgumentsContainUrl())
				{
					FeatureGet get = new FeatureGet();
					if(ArgumentsContainSave())
					{
						if(get.SaveUrlInFile(UrlValue,SaveValue))
							Console.WriteLine("{0} file saved",SaveValue);
						
						else
							Console.WriteLine("Error file saved");
					}
					
					else
					{
						Console.WriteLine(get.Show(UrlValue));
					}
					
					Console.WriteLine("Save : " + SaveValue);
					Console.WriteLine("url : " + UrlValue);
				}
			}
			
			else if(FeatureValue.ToLower().Equals("test"))
			{
				Console.WriteLine("TEST");
				
				if(ArgumentsContainSave())
					throw new Exception("Error arguments between GET and feature TEST");
				
				if(ArgumentsContainUrl() && ArgumentsTimesIsCorrect())
				{
					// Create object FeatureTest and launch method				
					Console.WriteLine("Times : " + TimesValue);
					Console.WriteLine("url : " + UrlValue);
					Console.WriteLine("avg : " + AvgValue);
				}
			}
			
			else
			{
				throw new Exception("Feature incorrect");
			}
		}
	}
}
