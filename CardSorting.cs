using System;
using System.Collections.Generic;
using System.IO;

namespace CardSorting
{
	class Program
	{
		static void Main(string[] args)
		{
			if(args.Length != 3)
			{
				Console.Out.WriteLine("Error: Failed to specify two inputs and one output.");
				Console.Out.WriteLine("Exiting");
				return;
			}
			
			//TODO: Proper try/catch
			StreamReader file0Reader = new StreamReader(args[0]);
			StreamReader file1Reader = new StreamReader(args[1]);
			
			List<string> file0Cards = new List<string>();
			List<string> file1Cards = new List<string>();
			
			while(!file0Reader.EndOfStream)
			{
				string line = file0Reader.ReadLine();
				file0Cards.Add(line);
				Console.Out.WriteLine(line);
			}
			
			Console.Out.WriteLine();
			
			while(!file1Reader.EndOfStream)
			{
				string line = file1Reader.ReadLine();
				file1Cards.Add(line);
				Console.Out.WriteLine(line);
			}
			
			Console.Out.WriteLine();
			
			StreamWriter output = new StreamWriter(args[2]);
			output.WriteLine("Remove:");
			foreach(string s in file0Cards)
			{
				if(!file1Cards.Contains(s))
				{
					output.WriteLine(s);
				}
			}
			
			output.WriteLine("Add:");
			foreach(string s in file1Cards)
			{
				if(!file0Cards.Contains(s))
				{
					output.WriteLine(s);
				}
			}
			
			output.Close();
		}
	}
}
