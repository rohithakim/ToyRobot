using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ToyRobotProject
{
    public class Utilities
    {
        enum direction { NORTH,EAST,SOUTH,WEST }

        public bool validateInput(string input)
        {
            bool result = false;
            string[] commandList = System.Configuration.ConfigurationManager.AppSettings["validCommmand"].Split(',');
            var section = ConfigurationManager.GetSection("Commands") as NameValueCollection;
            string commmandFormat = string.Empty;
            string[] inputCommand = input.Split(',');
            foreach (string command in commandList)
            {
                if (command == inputCommand[0].ToUpper())
                {
                    commmandFormat = section[inputCommand[0]];
                    result = true;
                    break;
                }

            }



            if(result && commmandFormat != "")
            {
                bool inpLengthisGood = true;

                string[] commands = commmandFormat.Split(',');
                int optionalParams = 0;
                if (commands.Length != inputCommand.Length-1)
                { 
                    foreach(string cmd in commands)
                    {
                        if(cmd.Contains("opt"))
                        {
                            optionalParams += 1;
                        }
                    }
                    if ((commands.Length - optionalParams) != inputCommand.Length - 1)
                    {
                        inpLengthisGood = false;
                        result = false;
                    }
                }

                for (int i =1,y=0; i<inputCommand.Length && inpLengthisGood; y++,i++)
                {
                     
                    if(commands[y].Contains("opt"))
                    {
                        commands[y] = commands[y].Remove(0, commands[y].IndexOf('-') + 1);
                    }
                    switch (commands[y])
                    {
                        case "int":
                            result = checkforIntCorr(inputCommand[i]);
                            break;
                        case "string":
                            result = checkforDirection(inputCommand[i].ToUpper());
                            break;
                        default:
                            result = false;
                            break;

                    }
                }
            }
            return result;
        }

        private bool checkforIntCorr(string input)
        {
            int value;
            bool result = int.TryParse(input, out value);
            if (value < 0 || value > 5)
                result = false;

            return result;
        }

        private bool checkforDirection(string input)
        {
            bool res = false;
            foreach (string dir in Enum.GetNames(typeof(direction)))
            {
                if (dir == input)
                    res = true;
            }

            return res;
         }


    }
}
