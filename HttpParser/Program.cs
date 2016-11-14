using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace HttpParser
{
	class MainClass
	{
		static void Main(string[] args)
		{
			var parser = new HttpParser();
			parser.ParseUrl("https://code.google.com/archive/p/fizzler/", @"d:\images\", 2, ImageFormat.Png);
			Console.ReadKey();
		}
	}
}
