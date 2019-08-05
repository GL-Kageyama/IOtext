using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// Tihs Code is need a mono.

namespace IOTextStream
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var IOobj = new IOClass();

			IOobj.ReadLineText();

			IOobj.ReadAllText();

			IOobj.ReadLineFifteen();

			IOobj.CountHamlet();

			IOobj.NumberCount();

			IOobj.OutTxet();

			IOobj.WriteAllText();

			IOobj.GetFileSize();
		}
	}

	class IOClass
	{
		// テキストファイルのハムレットを出力
		public void ReadLineText()
		{
			// 実行ファイルと同一階層にhamlet.txtを配置する
			var filePath = @"hamlet.txt";
			if (File.Exists(filePath))
			{
				using (var reader = new StreamReader(filePath, Encoding.UTF8))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						Console.WriteLine(line);
					}
				}
			}
			Console.WriteLine();
		}

		// テキストファイルを一度に読み込む -> 出力
		public void ReadAllText()
		{
			var filePath = @"hamlet.txt";
			var lines = File.ReadAllLines(filePath, Encoding.UTF8);
			foreach (var line in lines)
				Console.WriteLine(line);
			Console.WriteLine();
		}

		// 先頭の15行を取り出す
		public void ReadLineFifteen()
		{
			var filePath = @"hamlet.txt";
			var lines = File.ReadLines(filePath, Encoding.UTF8).Take(15).ToArray();
			foreach (var line in lines)
				Console.WriteLine(line);
			Console.WriteLine();
		}

		// Hamletが含まれている行をカウント
		public void CountHamlet()
		{
			var filePath = @"hamlet.txt";
			var count = File.ReadLines(filePath, Encoding.UTF8).Count(s => s.Contains("Hamlet"));
			Console.WriteLine(count);
			Console.WriteLine();
		}

		// 行番号を付加
		public void NumberCount()
		{
			var filePath = @"hamlet.txt";
			var lines = File.ReadLines(filePath)
			                .Select((s, ix) => String.Format("{0,4}: {1}", ix + 1, s))
			                .ToArray();
			foreach (var line in lines)
				Console.WriteLine(line);
			Console.WriteLine();
		}

		// テキストをファイルに出力
		public void OutTxet()
		{
			var filePath = @"BlueBird.txt";
			using (var writer = new StreamWriter(filePath))
			{
				writer.WriteLine("Much to his surprise, the Fairy turned crimson with rage. ");
				writer.WriteLine("It was a hobby of hers to be like nobody, because she was a fairy and able to change her appearance, from one moment to the next, as she pleased. ");
				writer.WriteLine("That evening, she happened to be ugly and old and hump-backed; she had lost one of her eyes; and two lean wisps of grey hair hung over her shoulders.");
				writer.WriteLine("What do I look like? she asked Tyltyl. Am I pretty or ugly? Old or young?");
			}
		}

		// 文字の配列をテキストに出力
		public void WriteAllText()
		{
			var names = new List<string> {"Tokyo", "Chiba", "Oosaka"};
			var filePath = @"kenmei.txt";
			// Oosakaのみが出力される
			File.WriteAllLines(filePath, names.Where(s => s.Length > 5));
		}

		// ファイルサイズを取得する
		public void GetFileSize()
		{
			// hamlet.txtのサイズを取得
			var fi1 = new FileInfo(@"hamlet.txt");
			long size1 = fi1.Length;
			Console.WriteLine(size1); 

			// BlueBird.txtのサイズを取得
			var fi2 = new FileInfo(@"BlueBird.txt");
			long size2 = fi2.Length;
			Console.WriteLine(size2); 

			// kenmei.txtのサイズを取得
			var fi3 = new FileInfo(@"kenmei.txt");
			long size3 = fi3.Length;
			Console.WriteLine(size3); 
		}

	}
}


