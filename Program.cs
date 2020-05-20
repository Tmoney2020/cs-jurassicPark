using System;
using System.Collections.Generic;
using System.Linq;

namespace cs_jurassicPark
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            //  Your dinosaurs will be stored in a List<Dinosaur>
            var listOfDinosaurs = new List<Dinosaurs>();
            //Here are the 3 dinosaurs that we already had 
            var kento = new Dinosaurs
            {
                Name = "Kento",
                DietType = "herbivore",
                WhenAcquired = DateTime.Now,
                Weight = 4,
                EnclosureNumber = 1,

            };

            var abtahee = new Dinosaurs
            {
                Name = "Abtahee",
                DietType = "carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 20,
                EnclosureNumber = 2,
            };

            var cody = new Dinosaurs
            {
                Name = "Cody",
                DietType = "carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 50,
                EnclosureNumber = 3,
            };


            // Now we add our dinosaurs that we made to the list. 
            listOfDinosaurs.Add(kento);
            listOfDinosaurs.Add(cody);
            listOfDinosaurs.Add(abtahee);

            // step 3 -  Welcome the users to the application
            Console.WriteLine();
            Console.WriteLine($"Welcome to JURASSIC PARK! The park that spares NO Expense! We have {listOfDinosaurs.Count()} Dinosaurs in the park. Enjoy your visit! ");
            Console.WriteLine();

            // Step 4 - Make a menu so that the user can choose how to navigate 
            // What does the menu have to do? 
            //  -1 View - This will show all dinosaurs in a list. Ordered by WhenAquired
            //  -2 Add - This will allow the user to add a dinosaur to our list. 
            //        - the user will enter the information one property at a time to complete an object
            //  -3 Remove - User can search for a dinosaur by name, then the when prompted will delete the dinosaur
            //  -4 Transfer - this will prompt for the dinos name, search, then prompt for new enclosure number to change 
            //  -5 Summary - This will display the number of carivores and herbivores in the park 
            //  -6 Quit - This will exit the program.  

            //Quit 
            var userChooseQuit = false;

            while (userChooseQuit == false)
            {

                //View - done
                Console.WriteLine($"(V)iew all the dinosaurs we have in the Park");
                Console.WriteLine();

                //Add - done
                Console.WriteLine($"(A)dd a new Dinosaur to our Park");
                Console.WriteLine();

                //Remove - done
                Console.WriteLine($"(R)emove a dinosaur from our park");
                Console.WriteLine();

                //Transfer - done
                Console.WriteLine($"(T)ransfer a dinosaur to a new enclosure");
                Console.WriteLine();

                //Summary - done 
                Console.WriteLine($"(S)ummary of all the carnivores and herbivores in the park");
                Console.WriteLine();

                //Quit - done 
                Console.WriteLine($"(Q)uit the application and leave the park");
                Console.WriteLine();


                var toChoose = PromptForString("Choose One: ");


                //  -5 Summary - This will display the number of carivores and herbivores in the park 
                if (toChoose == "S")
                {
                    var numberOfCarnivores = listOfDinosaurs.Where(dinosaur => dinosaur.DietType == "carnivore").Count();
                    Console.WriteLine($"There are {numberOfCarnivores} carnivores");

                    var numberOfHerbivore = listOfDinosaurs.Where(dinosaur => dinosaur.DietType == "herbivore").Count();
                    Console.WriteLine($"There are {numberOfHerbivore} herbivores");

                }



                //-4 Transfer - this will prompt for the dinos name, search, then prompt for new enclosure number to change 

                if (toChoose == "T")
                {
                    var dinoToTransfer = PromptForString("Name of dinosaur to be transferred: ");

                    var transferDinosaur = listOfDinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == dinoToTransfer);

                    if (transferDinosaur == null)
                    {
                        Console.WriteLine($"Sorry we don't have that Dinosaur, our scientists are busy getting it's DNA from Amber.");
                    }
                    else
                    {
                        var transferDinosaurDiscription = transferDinosaur.Description();
                        Console.WriteLine(transferDinosaurDiscription);
                        Console.WriteLine();

                        var finalRemove = PromptForString($"Would you like to transfer {transferDinosaur.Name} (Y/N)");
                        if (finalRemove == "Y")
                        {
                            var newEnclosureNumber = PromptForInteger("New Enclosure Number: ");
                            transferDinosaur.EnclosureNumber = newEnclosureNumber;
                        }
                    }


                }
                //to remove 
                if (toChoose == "R")
                {
                    var dinoToRemove = PromptForString("Name of dinosaur to be removed: ");

                    var removeDinosaur = listOfDinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == dinoToRemove);

                    if (removeDinosaur == null)
                    {
                        Console.WriteLine($"Sorry we don't have that Dinosaur, our scientists are busy getting it's DNA from Amber.");
                    }
                    else
                    {
                        var removeDinosaurDiscription = removeDinosaur.Description();
                        Console.WriteLine(removeDinosaurDiscription);
                        Console.WriteLine();

                        var finalRemove = PromptForString($"Would you like to remove {removeDinosaur.Name} (Y/N)");
                        if (finalRemove == "Y")
                        {
                            listOfDinosaurs.Remove(removeDinosaur);
                        }
                    }
                }
                // Add
                if (toChoose == "A")
                {
                    var dinosaurName = PromptForString("Name: ");
                    var dinosaurDietType = PromptForString("Diet Type: ");
                    var dinosaurWeight = PromptForInteger("Weight: ");
                    var dinosaurEnclosureNumber = PromptForInteger("Enclosure Number: ");
                    var dinosaurWhenAcquired = DateTime.Now;

                    var newDino = new Dinosaurs
                    {
                        Name = dinosaurName,
                        DietType = dinosaurDietType,
                        Weight = dinosaurWeight,
                        EnclosureNumber = dinosaurEnclosureNumber,
                        WhenAcquired = dinosaurWhenAcquired,
                    };
                    listOfDinosaurs.Add(newDino);
                }

                //View all the dinosaurs in the park
                if (toChoose == "V")
                {
                    foreach (var dinosaurs in listOfDinosaurs)
                    {
                        var orderedDiscription = listOfDinosaurs.OrderBy(dinosaurs => dinosaurs.WhenAcquired);
                        var dinosaurDescription = dinosaurs.Description();
                        Console.WriteLine(dinosaurDescription);
                    }
                }

                //If we quit
                if (toChoose == "Q")
                {
                    userChooseQuit = true;
                    Console.WriteLine("Come back anytime! Remeber at Jurassic Park Nature Always Finds A Way!");
                    Console.WriteLine();
                }
            }
        }


        //  When the console application runs, it should let the user choose one of the following actions:

        //  View
        // This command will show the all the dinosaurs in the list, ordered by WhenAcquired
        //  Add
        // This command will let the user type in the information for a dinosaur and add it to the list
        //  Remove
        // This command will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
        //  Transfer
        // This command will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.
        //  Summary
        //  This command will display the number of carnivores and the number of herbivores.
        //  Quit
        //  This will stop the program

        // PEDAC
        //Problem - We need to be able to take in dinosaurs. Have people look at their descriptions. 
        // - Makes changes to the dinosaurs. Delete the dinsaurs from the system. Quit the system 
        // Example - 
        // | TRex | Carnivore | 01/01/2020 | 2,000 lbs | 4 |  
        // Data - Lists of dinosaurs, integers, class, 
        // Algorithm - 
        // Step 1 - Create a class of dinosaurs - done 
        // Step 2 - add dinosuars so that we can check the data as we go  - done 
        // ste 3 -  Welcome the users to the application
        // Step 4 - Promote the user with a menu of the various options of things to do
        // Create a  class of Dinosaurs 
        // Add atributes to the class 
        // add a method that describes your dinosaur to the user 

        // Step 5 - when each option is clicked, the user needs to be able to navigate the application to the appropriate area 
        // Step 6 - if the user chooses to quit. This will exit the program, otherwise the program will continue to the original 
    }
}

