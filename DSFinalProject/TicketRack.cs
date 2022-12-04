using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSFinalProject
{
    public class TicketRack
    {
        private Queue<Ticket> tickets;

        public TicketRack()
        {
            this.tickets = new Queue<Ticket>();
        }

        public void AddTicket(Ticket t)
        {
            this.tickets.Enqueue(t);
            this.SortRack();
        }

        private void SortRack()
        {
            Ticket[] tickArray = new Ticket[this.tickets.Count];
            int count = 0;
            while (this.tickets.Count != 0)
            {
                tickArray[count] = this.tickets.Dequeue();
                count++;
            }
            int len = tickArray.Length;
            for (int i = 1; i < len; i++)
            {
                DateTime curr = tickArray[i].GetOrderTime();
                int j = i - 1;


                while (j >= 0 && tickArray[j].GetOrderTime() > curr)
                {
                    Ticket temp = tickArray[j + 1];
                    tickArray[j + 1] = tickArray[j];
                    tickArray[j] = temp;
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
                this.tickets.Enqueue(x);
            }
        }

        public void ShowAllTickets()
        {
            while(this.tickets.Count != 0)
            {
                Ticket x = this.tickets.Dequeue();
                Console.WriteLine(x.ToString());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
