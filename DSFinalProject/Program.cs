using System;
using System.Collections.Generic;

namespace DSFinalProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Ticket a = new Ticket("1", "One");

            TicketRack tr = new TicketRack();
            tr.AddTicket(a);

            tr.ShowAllTickets();
    }
}
}
