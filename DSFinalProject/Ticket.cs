/**************************************************************
* Name        : Ticket.cs
* Author      : Ben Sanders
* Created     : 11/30/2022
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This program simulates an order ticket at a restaurant.
*               the user can create a ticket, then will be prompted
*               for an order and a price, then asked if there is more
*               orders on that ticket. If yes, the code repeats until
*               the answer is no. If no, the code sets the classes
*               ArrayList Data Structure to the list of orders and
*               prices.
*
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSFinalProject
{
    public class Ticket { 
        private string server;  // Server name, often added in ticket creation call but can be added as user input as well to simulate real life
        private string tableNum;  // String in case table is called B10 (for Bar, seat 10) or something similar
        private string orderPlaced; // Value for time ticket was created, used to sort tickets later. Stored as string for printing reasons.
        private double orderTotal = 0.00;  // Total cost of all items, Printed at end of ticket ToString()
        private ArrayList orders;  // ArrayList of all orders/prices and 1/2 required Data Structures for this assignment

        public Ticket()
        {
            Console.WriteLine("What is the server name?");
            this.server = Console.ReadLine();
            Console.WriteLine("What is the table number?");  // If Server name and table name are not specified in the constructor call, this gets them
            this.tableNum = Console.ReadLine();
            this.orderPlaced = DateTime.Now.ToString("HH:mm:ss tt");
            this.orders = GetOrders();
        }
        public Ticket(string server)
        {
            this.server = server;
            Console.WriteLine("What is the table number?");  
            this.tableNum = Console.ReadLine();
            this.orderPlaced = DateTime.Now.ToString("HH:mm:ss tt");  // if only server name is specified, this is called
            this.orders = GetOrders();
        }

        public Ticket(string server, string tableNum)
        {
            this.server = server;
            this.tableNum = tableNum;
            this.orderPlaced = DateTime.Now.ToString("HH:mm:ss tt");  // Same as other constructor but server name and table number are provided
            this.orders = GetOrders();
        }

        private ArrayList GetOrders()  // Function is called on ticket creationm, gets all orders for that ticket
        {
            double priceHolder;
            int cont = 1;  // Exit variable
            ArrayList orderPriceList = new ArrayList(); // initializes ArrayList so items can be added
            while (cont != 0) // while loop repeatedly asks user for the order and price of said order, then asks to continue.
            {
                Console.WriteLine("What is the order?");  
                orderPriceList.Add(Console.ReadLine());  // Orders can be anything so this code can be versitile and allow things like substitutions.
                Console.Write("How much does it cost? \n$");
                bool validPrice = false;
                while (validPrice != true) // allows looping of TryParse
                {
                    if (double.TryParse(Console.ReadLine(), out priceHolder))  // validates price entry can be set to double
                    {
                        orderPriceList.Add(priceHolder.ToString("0.00")); // rounds input to ameircan currency format
                        this.orderTotal += priceHolder; // adds price to total
                        validPrice = true; // changes sentinel variable to break free from loop
                    }
                    else
                    {
                        Console.Write("Price value not valid, please re-enter\n$"); // gives useful message, set to .Write so $ is in correct spot
                    }
                }
                Console.WriteLine("Is there another order? (No == 0, Yes == 1)");
                bool otherOrder = false;
                while (otherOrder != true) // allows looping of TryParse
                {
                    if (int.TryParse(Console.ReadLine(), out cont))  // validates input is an integer value
                    {
                        otherOrder = true;
                        while (cont != 0 & cont != 1)  // validates input as 0 or 1
                        {
                            Console.WriteLine("Please enter 1 for \"Yes\" or 0 for \"No\"");
                            if (int.TryParse(Console.ReadLine(), out cont))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid value");  // Since it already states the "please enter...", only "invlalid value" is printed
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, Please enter 1 for \"Yes\" or 0 for \"No\"");
                    }
                }
            }
            return orderPriceList;  // returns arrayList, setting class member to set of inputted items
        }
        public DateTime GetOrderTime()  // method used to get the time on the order for sorting purposes
        {
            DateTime returnDate;  // creates DateTime object for later use
            if(DateTime.TryParse(this.orderPlaced, out returnDate))  // This should never fail as time is automatically set, but is included just in case
            {
                return returnDate;
            }
            else
            {
                throw new Exception("DateTime not valid");
            }
        }
        public override string ToString()  // Prints ticket to screen, formatted to look as close to an actual ticket as possible without using html
        {
            string x = "Server: " + this.server + "\nTable: " + this.tableNum + "\n" + "Order Time: " + this.orderPlaced + "\n";
            int count = 1;
            foreach (var y in this.orders)
            {
                if (count == 1)
                {
                    x = x + y + "     $";
                    count = 2;
                }
                else if(count == 2)
                {
                    x = x + y + "\n";
                    count = 1;

                }
            }
            x = x + "Total:     $" + this.orderTotal;
            return x;
        }
    }
}
