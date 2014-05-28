/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 14/05/2014
 * Time: 12:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Text;

namespace nurl
{
	/// <summary>
	/// Description of FeatureGet.
	/// </summary>
	public class FeatureGet
	{
		public FeatureGet()
		{
			
		}
		
		public string Show(string url)
		{
			try
			{
		        var request = WebRequest.Create(url);
		        var response = (HttpWebResponse)request.GetResponse ();
		        var dataStream = response.GetResponseStream ();
		        var reader = new StreamReader (dataStream);
		       
		        return reader.ReadToEnd();
			}
			catch(Exception E)
			{
				return "<h1>hello</h1>";
			}
		}
		
		public bool SaveUrlInFile(string url,string nameFile)
		{
			try
			{
				string data = Show(url);
				
				if(data.Equals("<h1>hello</h1>"))
					return false;
				
				var file = new System.IO.StreamWriter(nameFile);
				file.WriteLine(data);
				
				return true;
			}
			catch(Exception E)
			{
				return false;
			}
		}
	}
}
