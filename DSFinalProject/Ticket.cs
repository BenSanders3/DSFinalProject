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
        private ArrayList orders;

        public Ticket()
        {
            Console.WriteLine("What is the server name?\n");
            this.server = Console.ReadLine();
            Console.WriteLine("What is the table number?");
            this.tableNum = Console.ReadLine();
            this.orderTime = DateTime.Now.ToString("HH:mm tt");
            this.orders = CreateTicket();
        }

        public Ticket(string server, string tableNum)
        {
            this.server = server;
            this.tableNum = tableNum;
            this.orderTime = DateTime.Now.ToString("HH:mm tt");
            this.orders = CreateTicket();
        }

        private ArrayList CreateTicket()
        {
            int cont = 1;
            ArrayList orderPriceList = new ArrayList();
            while (cont != 0)
            {
                Console.WriteLine("What is the first order? \n");
                orderPriceList.Add(Console.ReadLine());
                Console.WriteLine("How much does it cost? \n$");
                orderPriceList.Add(Console.ReadLine());
                Console.WriteLine("Is there another order? (No == 0, Yes == 1)\n");
                if(int.TryParse(Console.ReadLine(), out cont))
                {
                    while (cont != 0 | cont != 1)
                    {
                        Console.WriteLine("Please enter 1 for \"Yes\" or 0 for \"No\"\n");
                        if (int.TryParse(Console.ReadLine(), out cont))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid value, please restart.");
                            orderPriceList.Clear();
                            cont = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value, please restart.");
                    orderPriceList.Clear();
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
