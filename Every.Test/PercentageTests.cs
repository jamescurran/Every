using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelTheory;

namespace NovelTheory.Test
{
	[TestClass]
	public class PercentageTests
	{
		[TestMethod]
		public void MoreThan100_Test()
		{
			double countIt = 0;
			double expected = 50.0;
			int total = 600;
			var counter = new Percentage(total, (reps, percent) => countIt = percent);

			for (int i = 0; i < 300; ++i)
				counter.Next();

			Assert.AreEqual(expected, countIt);
		}
		
		[TestMethod]
		public void LessThan100_Test()
		{
			double countIt = 0;
			double expected = 40.0;
			int total = 25;
			var counter = new Percentage(total, (reps, percent) => countIt = percent);

			for (int i = 0; i < 10; ++i)
				++counter;

			Assert.AreEqual(expected, countIt);
		}

		[TestMethod]
		public void PrefixIncrementer_Test()
		{
			double countIt = 0;
			double expected = 50.0;
			int total = 600;
			var counter = new Percentage(total, (reps, percent) => countIt = percent);

			for (int i = 0; i < 300; ++i)
				++counter;

			Assert.AreEqual(expected, countIt);
		}

		[TestMethod]
		public void PostfixIncrementer_Test()
		{
			double countIt = 0;
			double expected = 50.0;
			int total = 600;
			var counter = new Percentage(total, (reps, percent) => countIt = percent);

			for (int i = 0; i < 300; ++i)
				counter++;

			Assert.AreEqual(expected, countIt);
		}

		[TestMethod]
		public void Never_Test()
		{
			double countIt = 0.0;
			double expected = 0.0;
			int total = 600;
			var counter = Percentage.Never;

			for (int i = 0; i < 300; ++i)
				counter++;

			Assert.AreEqual(expected, countIt);
		}

	}
}
