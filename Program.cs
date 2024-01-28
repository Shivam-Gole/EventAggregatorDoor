using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select door type: 1 - Simple Door, 2 - Smart Door");
            int doorType = int.Parse(Console.ReadLine());

            IDoor selectedDoor;

            if (doorType == 1)
            {
                selectedDoor = new SimpleDoor();
            }
            else if (doorType == 2)
            {
                Console.WriteLine("Configure Smart Door features: ");
                Console.Write("Enable Buzzer (true/false): ");
                bool enableBuzzer = bool.Parse(Console.ReadLine());

                Console.Write("Enable Pager (true/false): ");
                bool enablePager = bool.Parse(Console.ReadLine());

                Console.Write("Enable AutoClose (true/false): ");
                bool enableAutoClose = bool.Parse(Console.ReadLine());

                selectedDoor = new SmartDoor(enableBuzzer, enablePager, enableAutoClose);
            }
            else
            {
                Console.WriteLine("Invalid door type selection.");
                return;
            }

            Console.WriteLine("Door actions: 1 - Open, 2 - Close");
            int action = int.Parse(Console.ReadLine());

            if (action == 1)
            {
                selectedDoor.Open();
            }
            else if (action == 2)
            {
                selectedDoor.Close();
            }
            else
            {
                Console.WriteLine("Invalid action selection.");
            }

            Console.ReadLine();
        }
    }

}
