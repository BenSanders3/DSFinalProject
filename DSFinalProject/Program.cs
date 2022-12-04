/**************************************************************
* Name        : Program.cs
* Author      : Ben Sanders
* Created     : 11/30/2022
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This is the driver code for the DSFinalProject
*               assignment. It creates multiple tickets, adds
*               them to a ticket rack, and prints the ticket
*               rack contents.
*
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/

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
