using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class TestClass2 : IEquatable<TestClass2>
	{
		public TestClass2() { }
		public TestClass2(Random rand)
		{
			Int = rand.Next();
			Str = rand.Next().ToString();
		}

		public int Int { get; set; }
		protected string Str { get; set; }

		public TestClass2 Clone()
		{
			return new TestClass2() { Int = Int };
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as TestClass2);
		}

		public bool Equals(TestClass2 other)
		{
			return other != null &&
				   Int == other.Int;
		}

		public override int GetHashCode()
		{
			return 1497029550 + Int.GetHashCode();
		}
	}
}
