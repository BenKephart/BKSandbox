using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace LineGameTests
{
    [TestClass]
    public class LineGameTest
    {
        private LineGame _lineGame;

        [TestMethod]
        public void ExecuteLineTests()
        {
            Initialize(">....");
            TestMovingRight();
            TestGameOver();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidStartingState()
        {
            LineGame lineGame = new LineGame(">.....");
        }

        public void Initialize(string str)
        {
            _lineGame = new LineGame(str);
        }

        private void TestMovingRight()
        {
            _lineGame.MoveRight();
            Assert.AreEqual(_lineGame.CurrentState(), ".>...");
            _lineGame.MoveRight();
            Assert.AreEqual(_lineGame.CurrentState(), "..>..");
            _lineGame.MoveRight();
            Assert.AreEqual(_lineGame.CurrentState(), "...>.");
            _lineGame.MoveRight();
            Assert.AreEqual(_lineGame.CurrentState(), "....>");
        }

        private void TestGameOver()
        {
            Assert.AreEqual(_lineGame.CheckGameOver(), true);
        }
    }
}
