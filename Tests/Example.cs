using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axion.Collections.Concurrent;

namespace Tests
{
	public class Example
	{
		public static void Main()
		{
			ConcurrentHashSet<string> set = new ConcurrentHashSet<string>()
			{
				"string",
				"testing",
				"word",
			};
			Console.WriteLine(set.IsEmpty ? "Empty" : "Not Empty");
			set.Clear();
			Console.WriteLine(set.IsEmpty ? "Empty" : "Not Empty");

			for (int i = 0; i < 10; i++) {
				set.Add(i.ToString());
			}

			Console.WriteLine("Contents: " + string.Join(", ", set.OrderBy(x => x)));

			foreach (string item in set.Take(5).ToList()) {
				if (set.TryRemove(item, out string removed)) {
					Console.WriteLine("Removed: " + removed);
				}
			}
			if (set.TryGetValue("7", out string str)) {
				Console.WriteLine(str + " was found");
			}

			if (set.TryGetValue("8", out str)) {
				Console.WriteLine(str + " was found");
			}
		}
	}
}
