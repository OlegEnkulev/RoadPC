using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadPC_Console
{
    class Program
    {
        static float lenght;
        static float averageSpeed = 60;
        static float timeOnRoad;
        static float fuelSize;
        static float averageFuelExpence;
        static float stopsCount = 0;
        static float stopsTime;
        static float fuelExpect;
        static float plannedStopsCount = 0;
        static float plannedStopsTime;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите длинну пути(км.): ");
                lenght = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите ёмкость бензобака(л.): ");
                fuelSize = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите расход топлива вашего автомобиля (л/100 км): ");
                averageFuelExpence = int.Parse(Console.ReadLine());

                Core();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[INFO] ");
                Console.ResetColor();
                Console.WriteLine("Не удаётся преобразовать введённые символы в число!");
            }
        }

        static void Core()
        {
            averageSpeed = 60;
            timeOnRoad = 0;
            stopsCount = 0;
            stopsTime = 0;
            fuelExpect = 0;
            plannedStopsCount = 0;
            plannedStopsTime = 0;
            Console.Clear();

            timeOnRoad = lenght / averageSpeed;

            float lenghtOnCalculations = lenght - 100;
            for (int i = 0; lenghtOnCalculations > 0; i++)
            {
                lenghtOnCalculations = lenghtOnCalculations - 100;

                plannedStopsCount++;
            }

            fuelExpect = lenght * averageFuelExpence / 100;

            float fuelExpectOnCalculations = fuelExpect - fuelSize;
            for (int i = 0; fuelExpectOnCalculations > 0; i++)
            {
                fuelExpectOnCalculations = fuelExpectOnCalculations - fuelSize;

                stopsCount++;
            }

            stopsTime = stopsCount * 20;
            plannedStopsTime = plannedStopsCount * 20;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Время в пути(ч.): " + timeOnRoad + " ч.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Потребуется топлива(л.): " + fuelExpect + " л.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Число остановок: " + stopsCount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Время на остановки(м.): " + stopsTime + " м.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Число плановых остановок: " + plannedStopsCount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine("Время на плановые остановки(м.): " + plannedStopsTime + " м.");

            Console.ReadKey(true);
        }
    }
}
