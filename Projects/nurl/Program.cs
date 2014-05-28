/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 14/05/2014
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nurl
{
	class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				EngineFeature engine = new EngineFeature(args);
				engine.Start();
			}
			catch(Exception e)
			{
				Console.Write(e.Message);
			}
		}
	}
}