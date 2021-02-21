using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class TestClass : IEquatable<TestClass>
	{
		public TestClass() { }
		public TestClass(Random rand)
		{
			Int = rand.Next();
			Str = rand.Next().ToString();
		}

		public int Int { get; set; }
		protected string Str { get; set; }

		public TestClass Clone()
		{
			return new TestClass() { Int = Int, Str = Str  };
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as TestClass);
		}

		public bool Equals(TestClass other)
		{
			return other != null &&
				   Int == other.Int &&
				   Str == other.Str;
		}

		public override int GetHashCode()
		{
			int hashCode = 2115060958;
			hashCode = hashCode * -1521134295 + Int.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Str);
			return hashCode;
		}
	}
}
