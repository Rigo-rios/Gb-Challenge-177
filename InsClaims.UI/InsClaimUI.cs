using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using InsClaims.data;
using InsClaims.Repository;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
namespace InsClaims.UI


{
    public class InsClaimUI
    {
        private readonly ClaimsRepository _ClaimRepo;

        public InsClaimUI()
        {
            _ClaimRepo = new ClaimsRepository();
        }

        public void Run()
        {
            RunApplication();
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Clear();
                System.Console.WriteLine("Welcome to our Komodo Insurance Claims Application: \n " +
                                        "1. Add A New Claim \n" +
                                        "2. View The Next Claim \n" +
                                        "3. See List Of All Claims \n" +
                                        "4. Process The Next Claim \n" +
                                        "0. Exit The Application \n" +
                        "O=============================================================O\n");

                var UserInput = int.Parse(ReadLine()!);

                switch (UserInput)
                {
                    case 1:
                        AddClaim();
                        break;
                    case 2:
                        ClaimFiledToBeProcessed();
                        break;
                    case 3:
                        GetClaimsFiled();
                        break;
                    case 4:
                        ProcessClaimFiled();
                        break;
                    case 0:
                        isRunning = CloseApplication();
                        break;
                    default:
                        WriteLine("That was not a valid operation, Please try again!");
                        break;
                }
            }
        }

        private void AddClaim()
        {
            Clear();
                ClaimFiled newClaim = new ClaimFiled();
                Write("Please Input The Claim: \n" +
                        "1. Car \n" +
                        "2. Home \n" +
                        "3. Theft \n"
                        );
                string UserInput_ClaimType = ReadLine()!;
                int UserInput_Int = int.Parse(UserInput_ClaimType);
                newClaim.ClaimType = (ClaimType)UserInput_Int;

                Write("Please Input a description  ");
                newClaim.ClaimDescription = ReadLine()!;

                Write("Please enter Claim Amount  ");
                string UserInput_ClaimAmount = ReadLine()!;
                decimal UserInput_Decimal = decimal.Parse(UserInput_ClaimAmount);
                newClaim.ClaimAmount = UserInput_Decimal;

                Write("Please enter the Date of Incidident. Ex:MM/dd/YYYY  ");
                newClaim.DateOfIncident = DateTime.Parse(ReadLine()!);

                Write("Please enter the Date of Claim. Ex: MM/dd/YYYY  ");
                newClaim.DateOfClaim = DateTime.Parse(ReadLine()!);
            
                
            PressAnyKey();
            }

            private void ClaimFiledToBeProcessed()
            {
                Clear();
                WriteLine("Pulling Up The Current Claim:  ");
                ClaimFiled currentClaimFiled = _ClaimRepo.ClaimFileToBeProcessed();
                if (currentClaimFiled != null)
                {
                    System.Console.WriteLine(currentClaimFiled);
                }
                else
                {
                    System.Console.WriteLine("Sorry, there were no Claims available.");
                }

                PressAnyKey();

            }

            private void GetClaimsFiled()
            {
                Clear();
                System.Console.WriteLine("-- Claim Listing -- ");
                if (_ClaimRepo.GetClaimsFiled().Count() > 0)
                {
                    foreach (ClaimFiled claimFiled in _ClaimRepo.GetClaimsFiled())
                    {
                        System.Console.WriteLine(claimFiled);
                    }
                }
                else
                {
                    System.Console.WriteLine("Sorry, but there are no claims present.");
                }
                PressAnyKey();
            }

            private void ProcessClaimFiled()
            {
                Clear();
                WriteLine(" -- Process The Current Claim");
                if (_ClaimRepo.GetClaimsFiled().Count() > 0)
                {
                    WriteLine("Would You Like To Remove The Current Claim. Y/N? \n");
                    WriteLine(_ClaimRepo.GetClaimsFiled());

                    string userInput = ReadLine()!;
                    if (userInput == "Y".ToLower())
                    {
                        ClaimFiled currentClaimFiled = _ClaimRepo.ProcessClaimFiled();
                        if (currentClaimFiled != null)
                        {
                            WriteLine($"You successfully removed {currentClaimFiled}");
                        }
                        else
                        {
                            WriteLine($"Sorry unable to Remove: Null Value! ");
                        }
                    }
                    else
                    {
                        WriteLine("Deletion Cancelled.");
                    }
                    PressAnyKey();

                }
            }

            private bool CloseApplication()
            {
                Clear();
                WriteLine("We appreciate you for using our application. GoodBye!");
                PressAnyKey();
                return false;
            }

            private void PressAnyKey()
            {
                System.Console.WriteLine("Press Any Key To Continue.");
                Console.ReadKey();
            }



        }
    }