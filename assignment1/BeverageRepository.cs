//Author: David Barnes
//CIS 237
//Assignment 1
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

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack, decimal price, bool active)
        {
            //Add a new WineItem to the collection. Increase the Length variable.
            Beverage beverage = new Beverage();
            beverage.id = id;
            beverage.name = description;
            beverage.pack = pack;
            beverage.price = price;
            beverage.active = active;

            beverageEntities.Beverages.Add(beverage);
            beverageEntities.SaveChanges();
        }
        
        //Get The Print String Array For All Items
        public string GetPrintString()
        {
            string output = string.Empty;

            foreach(Beverage beverage in beverageEntities.Beverages)
            {
                output += beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price + " " + beverage.active + Environment.NewLine;
            }

            return output;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //For each WineItem in wineItems
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                //If the wineItem is not null
                if (beverage != null)
                {
                    //if the wineItem Id is the same as the search id
                    if (beverage.id == id)
                    {
                        //Set the return string to the result of the wineItem's ToString method
                        returnString = beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price + " " + beverage.active + Environment.NewLine;
                    }
                }
            }
            //Return the returnString
            return returnString;
        }

    }
}
