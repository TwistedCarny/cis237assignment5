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
    class BeverageRepository
    {
        //Private Variables
        BeverageWCurtisEntities beverageEntities;

        //Constuctor. Must pass the size of the collection.
        public BeverageRepository()
        {
            beverageEntities = new BeverageWCurtisEntities();
        }

        //Add a new item to the database
        public void AddNewItem(string id, string description, string pack, decimal price, bool active)
        {
            //Add a new Beverage to the database.
            Beverage beverage = new Beverage();
            beverage.id = id;
            beverage.name = description;
            beverage.pack = pack;
            beverage.price = price;
            beverage.active = active;

            beverageEntities.Beverages.Add(beverage);
            beverageEntities.SaveChanges();
        }

        // Update beverage in the database
        public void UpdateItem(string id, string description, string pack, decimal price, bool active)
        {
            
            Beverage beverage = SearchForBeverage(id);
            if(beverage != null)
            {
                beverage.name = description;
                beverage.pack = pack;
                beverage.price = price;
                beverage.active = active;

                beverageEntities.SaveChanges();
            }
            
        }

        // Delete beverage from database
        public void DeleteItem(string id)
        {
            Beverage beverage = SearchForBeverage(id);

            beverageEntities.Beverages.Remove(beverage);

            beverageEntities.SaveChanges();
        }

        //Get The Print String Array For All Items
        public string GetPrintString()
        {
            string output = string.Empty;

            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                output += "---------------------------------------------------------" + Environment.NewLine;
                output += beverage.id + " " + beverage.name + " " +
                     Environment.NewLine + beverage.pack + " " + beverage.price.ToString("C") + " " +  "Active: " + beverage.active + Environment.NewLine;
                output += "---------------------------------------------------------" + Environment.NewLine;
            }

            return output;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //For each Beverage in Beverages
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                //If the Beverage is not null
                if (beverage != null)
                {
                    //if the Beverage Id is the same as the search id
                    if (beverage.id == id)
                    {
                        // Construct a string to return from the beverages properties
                        returnString = beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price + " " + beverage.active + Environment.NewLine;
                    }
                }
            }
            //Return the returnString
            return returnString;
        }

        private Beverage SearchForBeverage(string id)
        {

            //For each Beverage in Beverages
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                //If the Beverage is not null
                if (beverage != null)
                {
                    //if the Beverage Id is the same as the search id
                    if (beverage.id == id)
                    {
                        return beverage;
                    }
                }
            }

            return null;
        }

    }
}
