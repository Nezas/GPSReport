using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSReport.Models;

namespace GPSReport
{
    public static class Menu
    {
        public static void Start(Histogram histogram, RoadSection roadSection, List<GpsData> data)
        {
            MenuText();

            while(true)
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        {
                            Console.Clear();
                            histogram.DrawSatellites(data);
                            ContinueToMenu();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            histogram.DrawSpeed(data);
                            ContinueToMenu();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            roadSection.FindRoadSection(data);
                            ContinueToMenu();
                            break;
                        }
                    case "4":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.Write("Invalid input!\n");
                            Console.Write("\nEnter your option: ");
                            break;
                        }
                }
            }
        }

        static void MenuText()
        {
            Console.Clear();
            Console.WriteLine("1 - Draw histogram of satellites data");
            Console.WriteLine("2 - Draw histogram of speed data");
            Console.WriteLine("3 - Find the road section");
            Console.WriteLine("4 - Exit");
            Console.Write("\nEnter your option: ");
        }

        static void ContinueToMenu()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            MenuText();
        }
    }
}
