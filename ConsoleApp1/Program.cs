using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var plate = new Plate(5, 5);
            Console.WriteLine("Please type file/input to start this application.");
            var option = Console.ReadLine();
            switch (option)
            {
                case "input":
                    Console.WriteLine("Please place your robot arm first.");
                    while (true)
                    {
                        var cmd = Console.ReadLine();
                        ExecuteCmd(cmd, ref plate);
                    }

                case "file":
                    const Int32 BufferSize = 128;
                    Console.WriteLine("Please type your file name. [cmd.txt]");
                    var filename = Console.ReadLine();
                    if (filename.Length == 0) filename = "cmd.txt";

                    using (var fileStream = File.OpenRead(filename))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            ExecuteCmd(line, ref plate);
                        }

                        // Process line
                    }

                    break;
            }
        }

        static Dictionary<string, int> CmdLengthMapping = new Dictionary<string, int>
        {
            {"report", 1},
            {"drop", 1},
            {"detect", 1},
            {"move", 2},
            {"place", 2}
        };

        // ValidateCmd function check if the input command is in correct format/valid format
        static bool ValidateCmd(string[] arr)
        {
            try
            {
                if (CmdLengthMapping[arr[0]] != arr.Length) throw new ArgumentException("Invalid Command");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        // ParseCoordinates function translate the coordinates into grid dimension 
        static Vec ParseCoordinates(string str)
        {
            var nums = str.Split(",");
            Vec vec = new Vec();
            if (nums.Length != 2) throw new ArgumentException("Invalid Coordinates");
            try
            {
                vec.x = int.Parse(nums[0]) - Plate.OFFSET;
                vec.y = int.Parse(nums[1]) - Plate.OFFSET;
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Invalid Coordinates");
            }

            return vec;
        }

        static void ExecuteCmd(string cmd, ref Plate target)
        {
            var tokens = cmd.ToLower().Split(" ");
            if (!ValidateCmd(tokens)) return;
            try
            {
                switch (tokens[0])
                {
                    case "report":
                        target.Report();

                        break;
                    case "drop":
                        target.Drop();

                        break;
                    case "detect":
                        Console.WriteLine("detect");
                        break;
                    case "move":
                        Direction dir = (Direction) Enum.Parse(typeof(Direction), tokens[1]);
                        target.Move(dir);
                        break;
                    case "place":
                        var vec = ParseCoordinates(tokens[1]);
                        target.Place(vec.x, vec.y);
                        break;
                    default:
                        Console.WriteLine("No such command");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}