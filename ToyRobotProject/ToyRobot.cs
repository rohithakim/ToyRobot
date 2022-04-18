using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotProject
{
    public class ToyRobot
    {
        int xMax = 5;
        int yMax = 5;

        int xMin = 0;
        int yMin = 0;

        public int? robotXposition = null;
        public int? robotYposition = null;
        public string robotDirection = ""; 

        public void PLACE(string[] inpcmds)
        {
            int x, y;
            string dir = "";
            if(inpcmds.Length-1==3)
            {
                x = Convert.ToInt16(inpcmds[1]);
                y = Convert.ToInt16(inpcmds[2]);
                dir = inpcmds[3];
            }
            else
            {
                x = Convert.ToInt16(inpcmds[1]);
                y = Convert.ToInt16(inpcmds[2]);

            }

            if (dir == "")
            {
                if (robotDirection == "")
                {
                    Console.WriteLine("First PLACE command should have both coordinates and direction.");
                    return;
                }
            }
            else
                robotDirection = dir;

            if ((x < xMin || x > xMax) || (y < yMin || y > yMax))
            {
                Console.WriteLine("Kindly place the robot inside 6X6 board.");
                return;
            }

            if (x >= xMin && x <= xMax)
                robotXposition = x;

            if (y >= yMin && y <= yMax)
                robotYposition = y;

        }

        public void MOVE()
        {
            if (robotXposition != null && robotYposition != null)
            {
                switch (robotDirection)
                {
                    case "NORTH":
                        if (robotYposition < yMax)
                            robotYposition = robotYposition + 1;
                        break;
                    case "SOUTH":
                        if (robotYposition > 0)
                            robotYposition = robotYposition - 1;
                        break;
                    case "EAST":
                        if (robotXposition < xMax)
                            robotXposition = robotXposition + 1;
                        break;
                    case "WEST":
                        if (robotXposition < xMax)
                            robotXposition = robotXposition + 1;
                        break;
                }
            }
            else
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
        }

        public void LEFT()
        {
            if (robotDirection == "")
            {
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
                return;
            }

            switch (robotDirection.ToUpper())
            {
                case "NORTH":
                    robotDirection = "WEST";
                    break;
                case "SOUTH":
                    robotDirection = "EAST";
                    break;
                case "EAST":
                    robotDirection = "NORTH";
                    break;
                case "WEST":
                    robotDirection = "SOUTH";
                    break;
            }
        }

        public void RIGHT() {

            if (robotDirection == "")
            {
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
                return;
            }

            switch (robotDirection.ToUpper())
                {
                    case "NORTH":
                        robotDirection = "EAST";
                        break;
                    case "SOUTH":
                        robotDirection = "WEST";
                        break;
                    case "EAST":
                        robotDirection = "SOUTH";
                        break;
                    case "WEST":
                        robotDirection = "NORTH";
                        break;
                }
            
        }

        public string REPORT
        {
            get
            {
                return robotXposition.ToString() + " " +robotYposition.ToString()+ " " +robotDirection;
            }
        }

        public override string ToString()
        {
            if (robotXposition == null || robotYposition == null)
            {
                Console.WriteLine("Kindly place the toy first using the PLACE command.");
                return "";
            }
            else
            {
                string comma = ",";
                return (
                                String.Concat(
                                    "Output: ",
                                    robotXposition.ToString(), comma,
                                    robotYposition.ToString(), comma,
                                    robotDirection)
                            );
            }
        }

    }
}
