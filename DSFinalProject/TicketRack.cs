/**************************************************************
* Name        : TicketRack.cs
* Author      : Ben Sanders
* Created     : 11/30/2022
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This program simulates a ticket rack at a restaurant.
*               The user creates the rack, then can add ticket objects
*               using the AddTicket() method. The method automatically
*               sorts the rack on the addition of a ticket, but the
*               user can also manually make the rack sort without adding
*               a new ticket. The tickets are sorted based on the time
*               they were created, so tickets that have existed for longer
*               will be at the front, meaning you need to work on them first.
*               This is because, at a restauraunt, you need to get tickets
*               out as fast as possible, so you don't want a ticket to be
*               sitting there for an hour while other tickets come and go
*
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSFinalProject
{
    public class TicketRack
    {
        private Queue<Ticket> tickets;  // creates priorityQueue to hold all tickets and is 1/2 of the required Data Structures for this assignment

        public TicketRack()  // allows creation of ticket rack
        {
            this.tickets = new Queue<Ticket>();
        }

        public void AddTicket(Ticket t) // allows tickets to be added to ticket rack.
        {
            this.tickets.Enqueue(t);  
            this.SortRack();  // automatically sorts uppon ticket addition. This simulates how a human would naturally sort the tickets when adding
        }

        public void SortRack() // sorts all elements in rack
        {
            Ticket[] tickArray = new Ticket[this.tickets.Count]; // creates array that can move items around inside of it
            int count = 0;
            while (this.tickets.Count != 0)
            {
                tickArray[count] = this.tickets.Dequeue(); // adds all tickets to array
                count++;
            }
            int len = tickArray.Length;
            for (int i = 1; i < len; i++)
            {
                DateTime curr = tickArray[i].GetOrderTime();
                int j = i - 1;


                while (j >= 0 && tickArray[j].GetOrderTime() > curr) // checks if the current element is smaller than its predecessor
                {
                    Ticket temp = tickArray[j + 1]; //stores current element in temp ticket
                    tickArray[j + 1] = tickArray[j]; // sets current element to value of predecessor
                    tickArray[j] = temp; // sets predecessor to temp tickets value, essentially swapping the two.
                    j = j - 1;
                }

                foreach(Ticket x in tickArray)
                {
                    if (x.GetOrderTime() == curr)  // this works because no two tickets can be created in the same second without throwing an error and ending the program
                    {
                        tickArray[j + 1] = x;
                        break;
                    }
                }
            }
            foreach (Ticket x in tickArray)
            {
                this.tickets.Enqueue(x); // re-adds all tickets to the queue in sorted order
            }
        }
        public string FinishTicket() // simulates the completion of a ticket and sending it out to the restauraunt. 
        {
            return this.tickets.Dequeue().ToString();
        }
        public void ShowAllTickets() // calls ToString for all tickets in queue.
        {
            while(this.tickets.Count != 0)
            {
                Ticket x = this.tickets.Dequeue();
                Console.WriteLine(x.ToString());
                Console.WriteLine();
                Console.WriteLine(); // two lines of whitespace to separate output and increase readability.
            }
        }
    }
}
