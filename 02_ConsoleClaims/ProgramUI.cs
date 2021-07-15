using _02_RepositoryClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ConsoleClaims
{
    public class ProgramUI
    {
        public ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaim();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Claims Department! We're here to help.\n" +
                    "\n" +
                    "Please choose one of the options below:\n" +
                    "\n" +
                    "1. Show all claims.\n" +
                    "2. Take care of the next claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry. Please enter a valid number.");
                        break;
                }
            }
        }

        public void ShowAllClaims()
        {
            Console.Clear();
            List<Claims> claimList = _claimRepo.GetList();

            Console.WriteLine("ClaimID ClaimType Descirption Amount IncidentDate ClaimDate IsValid");

            foreach (Claims content in claimList)
            {
                Console.WriteLine($"{content.ClaimID}\n" +
                    $"{content.ClaimType}\n" +
                    $"{content.Description}\n" +
                    $"{content.Amount}\n" +
                    $"{content.IncidentDate}\n" +
                    $"{content.ClaimDate}\n" +
                    $"{content.IsValid}\n");
            }
            Console.WriteLine("Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();
        }

        public void ShowNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:\n");

            List<Claims> newList = _claimRepo.GetList();

            foreach (Claims content in newList)
            {
                Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                    $"ClaimType: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount: {content.Amount}\n" +
                    $"IncidentDate: {content.IncidentDate}\n" +
                    $"ClaimDate: {content.ClaimDate}\n" +
                    $"IsValid: {content.IsValid}\n" +
                    $"Do you want to deal with this claim? (y/n)");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "y":
                        _claimRepo.Remove();
                        Console.WriteLine("You have successfully taken the claim!\n" +
                            "\n" +
                            "Press 'Enter' to continue.");
                        break;
                    case "n":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please enter 'y' or 'n'.");
                        break;
                }
                Console.ReadLine();
            }
        }

        public void AddClaim()
        {
            Claims content = new Claims();

            Console.Clear();
            Console.WriteLine($"(ClaimID) (ClaimType) (Description) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) (ClaimType) (Description) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    content.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    content.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    content.ClaimType = TypeOfClaim.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) (Description) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter a claim description: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (Amount) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the damage amount: ");
            content.Amount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) ({content.Amount}) (Incident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of the incident (YYYY, MM, DD): ");
            content.IncidentDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) ({content.Amount}) ({content.IncidentDate}) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of the claim (YYYY, MM, DD): ");
            content.ClaimDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) ({content.Amount}) ({content.IncidentDate}) ({content.ClaimDate}) (Valid)\n");

            _claimRepo.IsValid(content);

            Console.Clear();
            Console.WriteLine($"The following claim will be added to the list:\n" +
                $"\n" +
                $"ClaimID: {content.ClaimID}\n" +
                $"ClaimType: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: {content.Amount}\n" +
                $"IncidentDate: {content.IncidentDate}\n" +
                $"ClaimDate: {content.ClaimDate}\n" +
                $"IsValid {content.IsValid}\n" +
                $"\n" +
                $"Press 'Enter' to confirm the entry.");
            Console.ReadLine();

            _claimRepo.AddClaim(content);

            Console.Clear();
            Console.WriteLine("Claim was successfully added to the list!\n" +
                "\n" +
                "Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();
        }

        public void SeedClaim()
        {
            Claims firstClaim = new Claims(1, TypeOfClaim.Car, "Hail damage", 2500, DateTime.Parse("06/15/2021"), DateTime.Parse("06/17/2021"), true);
            Claims secondClaim = new Claims(2, TypeOfClaim.Home, "Water damage in upstairs bathroom", 5000, DateTime.Parse("02/4/2021"), DateTime.Parse("02/06/2021"), true);
            Claims thirdClaim = new Claims(3, TypeOfClaim.Theft, "Stolen phone charger", 5, DateTime.Parse("03/6/2021"), DateTime.Parse("05/6/2021"), false);

            _claimRepo.AddClaim(firstClaim);
            _claimRepo.AddClaim(secondClaim);
            _claimRepo.AddClaim(thirdClaim);
        }
    }
}
