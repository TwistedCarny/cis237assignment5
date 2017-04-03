//Author: Westin Curtis
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 6;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the beverage program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.DisplayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the item you're looking for");
            Console.Write("> ");
            return Console.ReadLine();
        }

        public string GetItemIDForDeletion()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the item you would like to delete.");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the new items Price?");
            Console.Write("> ");
            string price = Console.ReadLine();
            Console.WriteLine("is the new item active? Y/N");
            Console.Write("> ");
            string active = Console.ReadLine();

            return new string[] { id, description, pack, price, active};
        }

        public string[] GetUpdatedItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the ID of the item you would like to update?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the updated items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the updated items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the updated items Price?");
            Console.Write("> ");
            string price = Console.ReadLine();
            Console.WriteLine("is the new updated active? Y/N");
            Console.Write("> ");
            string active = Console.ReadLine();

            return new string[] { id, description, pack, price, active };
        }

        //Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine(allItemsOutput);
            
        }

        public void DisplaySuccessfullyDeletedItem()
        {
            Console.WriteLine();
            Console.WriteLine("Successfully deleted item from database.");
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        public void DisplayInvalidPriceInput()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid price was input. Cannot add or update item in database.");
        }

        public void DisplayItemNotExist()
        {
            Console.WriteLine();
            Console.Write("The ID of the item entered doesn't exist in the database.");
        }

        //Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Beverage Success
        public void DisplayAddBeverageSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Update Item");
            Console.WriteLine("5. Delete Item");
            Console.WriteLine("6. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        public void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
