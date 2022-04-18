using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotProject;

namespace ToyRobotUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChangeToyRobotDirection()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE,2,3,NORTH";
            objToy.PLACE(cmd.Split(','));
            objToy.MOVE();
            objToy.LEFT();

            Assert.AreEqual(true, (objToy.robotXposition == 2 && objToy.robotYposition == 4 && objToy.robotDirection == "WEST"));
        }


        [TestMethod]
        public void TestPlacingToyOutSideOfBoard()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE,6,6,NORTH";
            objToy.PLACE(cmd.Split(','));

            Assert.AreEqual(true, (objToy.robotXposition== null && objToy.robotYposition == null));
        }

        [TestMethod]
        public void TestCommandFormat()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "place,2,2";
            objToy.PLACE(cmd.Split(','));

            Assert.AreEqual(true, (objToy.robotXposition == null && objToy.robotYposition == null));
        }

        [TestMethod]
        public void TestMultipleCommands()
        {
            ToyRobot objToy = new ToyRobot();
            string cmd = "PLACE,2,2,NORTH";
            objToy.PLACE(cmd.Split(','));
            objToy.MOVE();
            objToy.MOVE();
            string cmd2 = "PLACE,1,3";
            objToy.PLACE(cmd2.Split(','));
            objToy.MOVE();
            objToy.RIGHT();

            Assert.AreEqual(true, (objToy.robotXposition == 1 && objToy.robotYposition == 4 && objToy.robotDirection == "EAST"));
        }
    }
}
