using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ConvertToArrayLocationTestLow()
        {
            TicTac t = new TicTac();
            t.e.IsTesting = true;
            t.Start();
            int[] expected = new int[] { 0, 1 };

            int[] actual = t.e.ConvertToArrayLocation("2");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestHigh()
        {
            TicTac t = new TicTac();
            t.e.IsTesting = true;
            t.Start();
            int[] expected = new int[] { 2, 2 };

            int[] actual = t.e.ConvertToArrayLocation("9");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestNonInt()
        {
            //This test is here to show you invalid input is not handled
            TicTac t = new TicTac();
            t.e.IsTesting = true;
            t.Start();
            int[] expected = new int[] { 0, 0 };

            int[] actual = t.e.ConvertToArrayLocation("a");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestOutOfBounds()
        {
            //What should happen when the user enters an invalid number (out of bounds of the map)?
            TicTac t = new TicTac();
            t.e.IsTesting = true;
            t.Start();
            int[] expected = new int[] { 2, 2 };

            int[] actual = t.e.ConvertToArrayLocation("15");

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}