using NUnit.Framework;
using Algorithms.ArrayProb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb.Tests
{
    [TestFixture()]
    public class ArrayUnitTest
    {
        [Test()]
        public void firstNotRepeatingCharacterTest()
        {
            var res = Arrays.firstNotRepeatingCharacter("abacabad");
            Assert.AreEqual('c', res);
        }

        [Test()]
        public void MergeIntervalsTest()
        {
            var res = Arrays.MergeIntervals(new Interval[] {
                new Interval(1, 3),
                new Interval(2, 4 ),
                new Interval( 5, 6),
                new Interval(7, 9),
                new Interval(8, 10),
                new Interval(12, 21)
            });
        }

        [Test()]
        public void InsertIntervalTest()
        {
            // Insert into first pos
            var res = Arrays.InsertInterval(new Interval[] {
                new Interval(2, 4),
                new Interval(5, 6)
            }, new Interval(1, 3));

            // Insert into last pos
            res = Arrays.InsertInterval(new Interval[] {
                new Interval(1, 2),
                new Interval(3, 4)
            }, new Interval(5, 6));

            // Insert into mid
            res = Arrays.InsertInterval(new Interval[] {
                new Interval(1, 2),
                 new Interval(5, 6)
            }, new Interval(3, 4));

            // Overlap with all intervals
            res = Arrays.InsertInterval(new Interval[] {
                new Interval(1, 2),
                 new Interval(5, 6)
            }, new Interval(1, 7));

            // Overlap with some intervals
            res = Arrays.InsertInterval(new Interval[] {
                new Interval(1, 2),
                 new Interval(5, 6)
            }, new Interval(3, 5));
        }

        [Test()]
        public void DailyTemperaturesTest()
        {
            var temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            var res = Arrays.DailyTemperatures(temperatures);
        }
    }
}