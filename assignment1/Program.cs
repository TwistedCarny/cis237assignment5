﻿//Author: Westin Curtis
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the BeverageRepository class
            BeverageRepository beverageRepository = new BeverageRepository();


            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {

                    case 1:
                        //Print Entire List Of Items
                        userInterface.DisplayAllItems(beverageRepository.GetPrintString());
                        break;
                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageRepository.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        bool activeItem;
                        if(newItemInformation[4].ToLower() == "y")
                        {
                            activeItem = true;
                        }
                        else if(newItemInformation[4].ToLower() == "n")
                        {
                            activeItem = false;
                        }
                        else
                        {
                            userInterface.DisplayErrorMessage();
                            break;
                        }
                        

                        if (beverageRepository.FindById(newItemInformation[0]) == null)
                        {

                            try
                            {
                                beverageRepository.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], decimal.Parse(newItemInformation[3]), activeItem);
                                userInterface.DisplayAddBeverageSuccess();
                            }
                            catch(FormatException ex)
                            {
                                userInterface.DisplayInvalidPriceInput();
                            }    
                            
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                    case 4:
                        string[] updatedItemInformation = userInterface.GetUpdatedItemInformation();
                        bool updatedActiveItem = false;
                        if (updatedItemInformation[4].ToLower() == "y")
                        {
                            activeItem = true;
                        }
                        else if (updatedItemInformation[4].ToLower() == "n")
                        {
                            activeItem = false;
                        }
                        else
                        {
                            userInterface.DisplayErrorMessage();
                            break;
                        }

                        if(beverageRepository.FindById(updatedItemInformation[0]) != null)
                        {
                            try
                            {
                                beverageRepository.UpdateItem(updatedItemInformation[0], updatedItemInformation[1], updatedItemInformation[2], decimal.Parse(updatedItemInformation[3]), updatedActiveItem);
                                userInterface.DisplayAddBeverageSuccess();
                            }
                            catch (FormatException ex)
                            {
                                userInterface.DisplayInvalidPriceInput();
                            }
                        }
                        else
                        {
                            userInterface.DisplayItemNotExist();
                        }
                        break;
                    case 5:
                        string id = userInterface.GetItemIDForDeletion();
                        if (beverageRepository.FindById(id) != null)
                        {
                            beverageRepository.DeleteItem(id);
                            userInterface.DisplaySuccessfullyDeletedItem();
                        }
                        else
                        {
                            userInterface.DisplayItemNotExist();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
