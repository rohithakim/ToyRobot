using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Commandcentre commandObj = new Commandcentre();
                commandObj.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in command execution");
            }

        }
    }
}
