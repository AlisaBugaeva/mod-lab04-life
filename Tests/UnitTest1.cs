using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using cli_life;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadingFile()
        {
            String s ="    **    "
            Reset();
            OpenFile("standard_figures/block.txt");
            String res = "";
            for (int row = 0; row < board.Rows; row++)
            {
                var cell = board.Cells[0, row];
                if (cell.IsAlive)
                {
                    s+='*';
                }
                else
                {
                    s+=' ';
                }
            }
            Assert.IsTrue(res == s);
        }
        [TestMethod]
        public void CheckParams()
        {
            Reset();
            int width = board.width;
            Assert.IsTrue(width == 10); 
        }   
        [TestMethod]
        public void FindShip()
        {
            String s = " ship";
            Reset();
            OpenFile("standard_figures/ship.txt");
            String res= board.findShip()
            Assert.IsTrue( res == s);
        }  
        [TestMethod]
        public void CountAliveCells()
        {
            Reset();
            OpenFile("standard_figures/box.txt");
            int count = board.countAliveCells();
            Assert.IsTrue(count == 4);
        }  
        [TestMethod]
        public void FindFigures()
        {
            String s = " box hive boat"
            Reset();
            OpenFile("colonies/second.txt");
            String res = board.findBlock() + board.findBox() + board.findHive() + board.findBoat() + board.findShip();
            Assert.IsTrue(res == s);
        } 
        [TestMethod]
        public void ComeToStablePhase()
        {
            int stopParametr = 5;
            int i = 0;
            int stableTime = 0;
            Reset();
            OpenFile("colonies/first.txt");
            while (stopParametr > i)
            {
                int bTime = board.countAliveCells();
                board.Advance();
                i++;
                stableTime = board.becomeStablePhase(bTime, stableTime);
            }
            Assert.IsTrue(stableTime == 5);
        }  
        [TestMethod]
        public void hasHorizontalSymmetry()
        {
            Reset();
            OpenFile("colonies/block.txt");
            bool res = board.hasHorizontalSymmetry()
            Assert.IsTrue(res == true);
        }  
        //добавить метод с выстрелом ружья

        
    }
}
