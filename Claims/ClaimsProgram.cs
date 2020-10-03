using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum Claims
    { Car = 1, Home, Theft, Unknown }
    public class ClaimsProgram
    {
        static void Main(string[] args)
        {
            /*1. Create a Claim class with properties, constructors, and any necessary fields.
            2. Create a ClaimRepository class that has proper methods.
            3. Create a Test Class for your repository methods.
            4. Create a Program file that allows a claims manager to manage items in a list of claims.*/

            ClaimsProgram claims = new ClaimsProgram();
            claims.Run();

        }
        private readonly claimsRepository _claimsRepo = new claimsRepository();
        public void SeedContent()
        {
            /*ClaimID: 1
            Type: Car
            Description: Car Accident on 464.
            Amount: $400.00
            DateOfAccident: 4/25/18
            DateOfClaim: 4/27/18
            IsValid: True*/

            ClaimsType GeorgeParker = new ClaimsType(
                1,
                Claims.Car,
                "Car Accident on 464",
                400.00,
                "4/25/18",
                "4/27/18",
                "True");

            _claimsRepo.AddClaimToDirecotry(GeorgeParker);
        }

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            /*Choose a menu item:
            1. See all claims
            2. Take care of next claim
            3. Enter a new claim*/
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the options you'd like to select:\n" +
                        "1. See all claims\n" +
                        "2. Take care of next claim\n" +
                        "3. Enter a new claim\n" +
                        "4. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        ShowClaims();
                        break;
                    case "2":
                        DoClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    case "4":
                        Console.WriteLine("GoodBye.");
                        Console.ReadKey();
                        programIsRunning = false;
                        break;
                    default:
                        break;



                }
            }
        }

        public void ShowClaims()
        {
            Console.Clear();

            List<ClaimsType> claim = _claimsRepo.ClaimsContent();
            foreach (ClaimsType claims in claim)
            {
                Console.WriteLine($"{claims.ClaimID}.     {claims.Type}    {claims.Description}   " +
                    $"- ${claims.Amount}" +
                    $"{claims.DateOfAccident}.       " +
                    $"{claims.DateOfClaim}.      " +
                    $"{claims.IsValid}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }
        public void DoClaim()
        {
            /*For #2, when a claims agent needs to deal with an 
             item they see the next item in the queue.

            Here are the details for the next claim to be handled:
            ClaimID: 1
            Type: Car
            Description: Car Accident on 464.
            Amount: $400.00
            DateOfAccident: 4/25/18
            DateOfAccident: 4/27/18
            IsValid: True
            Do you want to deal with this claim now(y/n)? y
            When the agent presses 'y', the claim will be pulled off the top of the queue. 
            If the agent presses 'n', it will go back to the main menu.*/
            Console.Clear();
            List<ClaimsType> claim = _claimsRepo.ClaimsContent();
             claim.ElementAt(0);
            foreach (var claims in claim)
            {

                Console.WriteLine("Here are the details for the next claim to be handled:\n" +
                $"ClaimID: {claims.ClaimID}\n" +
                $"Type: {claims.Type}\n" +
                $"Description: {claims.Description}\n" +
                $"Amount: ${claims.Amount}\n" +
                $"DateOfAccident: {claims.DateOfAccident}\n" +
                $"DateOfClaim: {claims.DateOfClaim}\n" +
                $"IsValid: {claims.IsValid}\n" +
                $"\n");
            }
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine();
            /*When the agent presses 'y', the claim will be pulled off the top of the queue. 
            If the agent presses 'n', it will go back to the main menu.*/
            switch (input)
            {
                case "y":
                    claim.Clear();
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("please try again....");
                    break;
            }

        }

        public void AddClaim()
        {
            Console.Clear();
            /*For #3, when a claims agent enters new data about a claim they 
             will be prompted for questions about it:

            Enter the claim id: 4
            Enter the claim type: Car
            Enter a claim description: Wreck on I-70.
            Amount of Damage: $2000.00
            Date Of Accident: 4/27/18
            Date of Claim: 4/28/18
            This claim is valid.*/


            Claims type;
            Console.WriteLine("Enter the claim ID:");
            int claimID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the claim type:");
            string typeString = Console.ReadLine();
            switch (typeString)
            {
                
                case "car":
                case "Car":
                case "car ":
                case "Car ":
                case "CAR":
                case "CAR ":
                     type = Claims.Car;
                    break;
                case "Home":
                case "home":
                case "HOME":
                case "home ":
                case "Home ":
                case "HOME ":
                    type = Claims.Home;
                    break;
                case "Theft":
                case "theft":
                case "THEFT":
                case "Theft ":
                case "theft ":
                case "THEFT ":
                    type = Claims.Theft;
                    break;
                default:
                    Console.WriteLine("please repeat...");
                    type = Claims.Unknown;
                    break;
            }
            Console.WriteLine("Enter a claim description:");
            string description = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            int amount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Date Of Accident:");
            string dateOfAccident = Console.ReadLine();
            Console.WriteLine("Date of Claim:");
            string dateOfClaim = Console.ReadLine();
            Console.WriteLine("Is this claim valid:");
            string valid = Console.ReadLine();
            /*Menu newitem = new Menu(itemNumber, name, description, ingredents, price);
                bool itemWasAdded = _menuRepo.AddItemToDirecotry(newitem);
                if (itemWasAdded)
                {
                    Console.WriteLine($"{name} was added to the menu.");
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();*/
            ClaimsType newtype = new ClaimsType(
                claimID,
                type,
                description,
                amount,
                dateOfAccident,
                dateOfClaim,
                valid);
            bool itemWasAdded = _claimsRepo.AddClaimToDirecotry(newtype);
            if (itemWasAdded)
            {
                Console.WriteLine($"ClaimID:{claimID} was added to the menu.");
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


    }

    public class ClaimsType
    {
        /*ClaimID: 1
        Type: Car
        Description: Car Accident on 464.
        Amount: $400.00
        DateOfAccident: 4/25/18
        DateOfClaim: 4/27/18
        IsValid: True*/


        public int ClaimID { get; set; }
        public Claims Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string DateOfAccident { get; set; }
        public string DateOfClaim { get; set; }
        public string IsValid { get; set; }
        public ClaimsType() { }
        public ClaimsType(
            int claimID,
            Claims type,
            string description,
            double amount,
            string dateOfAccident,
            string dateOfClaim,
            string isValid)
        {
            ClaimID = claimID;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
    public class claimsRepository
    {
        protected List<ClaimsType> _claimsDirectory = new List<ClaimsType>();

        public bool AddClaimToDirecotry(ClaimsType item)
        {
            int startingCount = _claimsDirectory.Count;

            _claimsDirectory.Add(item);

            bool wasAdded = (_claimsDirectory.Count > startingCount);
            return wasAdded;
        }

        public List<ClaimsType> ClaimsContent()
        {
            return _claimsDirectory;
        }

    }

}
