using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotProject
{
    class Commandcentre
    {
        ToyRobot objToyRobot = new ToyRobot();
        public void Run()
        {
            string command = "";
            Utilities util = new Utilities();
            Console.WriteLine("Enter your command to move the Toy Robot");
            do
            {
                command = Console.ReadLine();
                if (util.validateInput(command))
                {
                    executeCommand(command);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }

            } while (command.ToUpper() != "REPORT");


            Console.ReadKey();
        }
            
        private void executeCommand(string input)
        {
            string[] inputCmds = input.Split(',');

            switch (inputCmds[0].ToUpper())
            {
                case "PLACE":
                    objToyRobot.PLACE(inputCmds);
                    break;
                case "MOVE":
                    objToyRobot.MOVE();
                    break;
                case "LEFT":
                    objToyRobot.LEFT();
                    break;
                case "RIGHT":
                    objToyRobot.RIGHT();
                    break;
                case "REPORT":
                    Console.WriteLine(objToyRobot.ToString());
                    break;
            }
        }
    }
}
