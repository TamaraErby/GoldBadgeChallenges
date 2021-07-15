using _03_RepositoryOutings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ConsoleOutings
{
    class ProgramUI
    {
        private OutingRepository _outingRepo = new OutingRepository();
        public void Run()
        {
            SeedOuting();
            RunMenu();
        }

        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo's Outing Log! Let's Explore.\n" +
                    "\n" +
                    "Please choose one of the option below: \n" +
                    "\n" +
                    "1. Display a list of all outings.\n" +
                    "2. Add individual outings to a list.\n" +
                    "3. Display combined cost for all outings.\n" +
                    "4. Display costs by type.\n" +
                    "5. Exit\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        TotalCost();
                        break;
                    case "4":
                        CostByType();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry. Please enter a valid number.");
                        break;
                }
            }
        }

        public void DisplayAllOutings()
        {
            Console.Clear();
            List<Outing> outingList = _outingRepo.GetList();

            foreach (Outing content in outingList)
            {
                Console.WriteLine($"{content.OutingType}\n" +
                    $"{content.Attendance}\n" +
                    $"{content.OutingDate}\n" +
                    $"{content.CostPerPerson}\n" +
                    $"{content.TotalCost}\n");
            }

            Console.WriteLine("Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();

            Console.Clear();
        }

        public void AddOuting()
        {
            Outing content = new Outing();

            Console.Clear();
            Console.WriteLine("(OutingType) (Attendance) (OutingDate) (CostPerPerson) (TotalCost)\n");

            Console.WriteLine("Enter the event type number: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    content.OutingType = TypeOfOuting.Golf;
                    break;
                case "2":
                    content.OutingType = TypeOfOuting.Bowling;
                    break;
                case "3":
                    content.OutingType = TypeOfOuting.AmusementPark;
                    break;
                case "4":
                    content.OutingType = TypeOfOuting.Concert;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.OutingType} (Attendance) (OutingDate) (CostPerPerson) (TotalCost)");

            Console.WriteLine("Enter the number of people that attended the event:");
            content.Attendance = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.OutingType}) ({content.Attendance}) (OutingDate) (CostPerPerson) (TotalCost)");

            Console.WriteLine("Enter the date of the event (YYYY, MM, DD):");
            content.OutingDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.OutingType}) ({content.Attendance}) ({content.OutingDate}) (CostPerPerson) (TotalCost)");

            Console.WriteLine("Enter the total cost per person for the event: ");
            content.CostPerPerson = double.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.OutingType}) ({content.Attendance}) ({content.OutingDate}) ({content.CostPerPerson}) (TotalCost)");

            Console.WriteLine("Enter the total cost for the event: ");
            content.TotalCost = double.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.OutingType}) ({content.Attendance}) ({content.OutingDate}) ({content.CostPerPerson}) ({content.TotalCost})");

            Console.Clear();
            Console.WriteLine($"The following outing will be added to the list: \n" +
                $"\n" +
                $"OutingType: {content.OutingType}\n" +
                $"Attendance: {content.Attendance}\n" +
                $"OutingDate: {content.OutingDate}\n" +
                $"CostPerPerson: {content.CostPerPerson}\n" +
                $"TotalCost: {content.TotalCost}\n");

            Console.WriteLine("Press 'Enter' to confirm the entry.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Outing was successfully added!\n" +
                "\n" +
                "Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();

            Console.Clear();

            _outingRepo.AddOuting(content);
        }

        public void TotalCost()
        {
            Console.Clear();
            Console.WriteLine($"Total cost for all outings: ${_outingRepo.TotalCost()}");

            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to return to the Main Menu.");

            Console.ReadLine();

            Console.Clear();
        }

        public void CostByType()
        {
            Console.Clear();
            Console.WriteLine($"Total cost for Golf outings: ${_outingRepo.CostByType(TypeOfOuting.Golf)}\n" +
            $"Total cost for Bowling outings: ${_outingRepo.CostByType(TypeOfOuting.Bowling)}\n" +
            $"Total cost for Amusement Park outings: ${_outingRepo.CostByType(TypeOfOuting.AmusementPark)}\n" +
            $"Total cost for Concert outings: ${_outingRepo.CostByType(TypeOfOuting.Concert)}\n");

            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to return to the Main Menu.");

            Console.ReadLine();

            Console.Clear();
        }

        public void SeedOuting()
        {
            Outing Golf = new Outing(TypeOfOuting.Golf, 15, new DateTime(2019, 04, 25), 20d, 300d);
            Outing Bowling = new Outing(TypeOfOuting.Bowling, 15, new DateTime(2019, 04, 02), 8d, 120d);
            Outing AmusementPark = new Outing(TypeOfOuting.AmusementPark, 25, new DateTime(2019, 07, 04), 30d, 750d);
            Outing Concert = new Outing(TypeOfOuting.Concert, 50, new DateTime(1985, 04, 02), 25d, 1250d);

            _outingRepo.AddOuting(Golf);
            _outingRepo.AddOuting(Bowling);
            _outingRepo.AddOuting(AmusementPark);
            _outingRepo.AddOuting(Concert);
        }
    }
}
