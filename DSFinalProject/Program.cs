using System;
using System.Collections.Generic;

namespace DSFinalProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Ticket a = new Ticket("1", "One");
            Ticket b = new Ticket("2", "Two");
            Ticket c = new Ticket("3", "Three");
            Ticket d = new Ticket("4", "Four");

            TicketRack tr = new TicketRack();       //Driver Code for in-development Testing
            tr.AddTicket(d);
            tr.AddTicket(c);
            tr.AddTicket(b);
            tr.AddTicket(a);

            tr.ShowAllTickets();
            
        }
    }
}
