using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSFinalProject
{
    public class Ticket { 
        private string server;
        private string tableNum;  // String in case table is called B10 (for Bar, seat 10) or something similar
        private string orderTime;
        private double orderTotal = 0.00;
        private ArrayList orders;

        public Ticket()
        {
            Console.WriteLine("What is the server name?");
            this.server = Console.ReadLine();
            Console.WriteLine("What is the table number?");
            this.tableNum = Console.ReadLine();
            this.orderTime = DateTime.Now.ToString("HH:mm:ss tt");
            this.orders = GetOrders();
        }

        public Ticket(string server, string tableNum)
        {
            this.server = server;
            this.tableNum = tableNum;
            this.orderTime = DateTime.Now.ToString("HH:mm:ss tt");
            this.orders = GetOrders();
        }

        public int GetOrderTime()
        {
            var ticketTime = DateTime.Parse(this.orderTime);
            var timespan = DateTime.Now - ticketTime;
            int timeSince = Convert.ToInt32(timespan.TotalSeconds);
            return timeSince;
        }

        private ArrayList GetOrders()
        {
            double priceHolder;
            int cont = 1;
            ArrayList orderPriceList = new ArrayList();
            while (cont != 0)
            {
                Console.WriteLine("What is the order?");
                orderPriceList.Add(Console.ReadLine());
                Console.Write("How much does it cost? \n$");
                if(double.TryParse(Console.ReadLine(), out priceHolder))
                {
                    orderPriceList.Add(priceHolder.ToString("0.00"));
                    this.orderTotal += priceHolder;
                }
                else
                {
                    Console.WriteLine("Price value not valid, please restart");
                    orderPriceList.Clear();
                    this.server = null;
                    this.tableNum = null;
                    this.orderTime = null;
                    break;
                }
                Console.WriteLine("Is there another order? (No == 0, Yes == 1)");
                if(int.TryParse(Console.ReadLine(), out cont))
                {
                    while (cont != 0 & cont != 1)
                    {
                        Console.WriteLine("Please enter 1 for \"Yes\" or 0 for \"No\"");
                        if (int.TryParse(Console.ReadLine(), out cont))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid value, please restart.");
                            orderPriceList.Clear();
                            this.server = null;
                            this.tableNum = null;
                            this.orderTime = null;
                            cont = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value, please restart.");
                    orderPriceList.Clear();
                    this.server = null;
                    this.tableNum = null;
                    this.orderTime = null;
                    cont = 0;
                }
            }
            return orderPriceList;
        }

        public override string ToString()
        {
            string x = "Server: " + this.server + "\nTable: " + this.tableNum + "\n" + "Order Time: " + this.orderTime + "\n";
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

            return x;
        }
    }
}
