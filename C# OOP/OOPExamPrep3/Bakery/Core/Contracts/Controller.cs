using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }

            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }

            this.bakedFoods.Add(bakedFood);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            
            this.tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            string result = "";
            List<ITable> tables = this.tables.Where(t => !t.IsReserved).ToList();

            for (int i = 0; i < tables.Count; i++)
            {
                if (i != tables.Count - 1)
                {
                    result += tables[i].GetFreeTableInfo() + Environment.NewLine;
                }
                else
                {
                    result += tables[i].GetFreeTableInfo();
                }
            }

            return result;
            //foreach (var table in tables)
            //{
            //    sb.AppendLine(table.GetFreeTableInfo());
            //}
            //if (tables.Count == 0)
            //{
            //    
            //}
            //return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            //TODO: ChekHere for StringBulder
            return $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";

            }
            else
            {
                table.OrderDrink(drink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood bakedFood = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (bakedFood == null)
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                table.OrderFood(bakedFood);
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
