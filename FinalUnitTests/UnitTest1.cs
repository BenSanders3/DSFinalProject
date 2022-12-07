using System;
using System.Collections;
using Xunit;

namespace FinalUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetOrderTime()
        {
            ArrayList orders = new ArrayList();
            orders.Add("Burger");
            orders.Add(8.99);
            orders.Add("Fries");
            orders.Add(2.99);
            orders.Add("Large Drink");
            orders.Add(4.99);
            DSFinalProject.Ticket T = new DSFinalProject.Ticket("Ben", "B15", 12, orders);
            Assert.Equal(T.orderPlaced, T.GetOrderTime().ToString("HH:mm:ss tt"));
        }

        [Fact]
        public void TestToString()
        {
            ArrayList orders = new ArrayList();
            orders.Add("Burger");
            orders.Add(8.99);
            orders.Add("Fries");
            orders.Add(2.99);
            orders.Add("Large Drink");
            orders.Add(4.99);
            DSFinalProject.Ticket T = new DSFinalProject.Ticket("Ben", "B15", 12, orders);
            string x = "Server: Ben\nTable: B15\nOrder Time: " + T.orderPlaced + "\nBurger     $8.99\nFries     $2.99\nLarge Drink     $4.99\nTotal:     $12";
            Assert.Equal(x, T.ToString());
        }
        [Fact]
        public void TestAddTicket()
        {
            ArrayList orders = new ArrayList();
            orders.Add("Burger");
            orders.Add(8.99);
            orders.Add("Fries");
            orders.Add(2.99);
            orders.Add("Large Drink");
            orders.Add(4.99);
            DSFinalProject.Ticket T = new DSFinalProject.Ticket("Ben", "B15", 12, orders);
            DSFinalProject.TicketRack TR = new DSFinalProject.TicketRack();
            TR.AddTicket(T);
            Assert.True(TR.tickets.Contains(T));
        }
        [Fact]
        public void TestFinishTicket()
        {
            ArrayList orders = new ArrayList();
            orders.Add("Burger");
            orders.Add(8.99);
            orders.Add("Fries");
            orders.Add(2.99);
            orders.Add("Large Drink");
            orders.Add(4.99);
            DSFinalProject.Ticket T = new DSFinalProject.Ticket("Ben", "B15", 12, orders);
            DSFinalProject.TicketRack TR = new DSFinalProject.TicketRack();
            TR.AddTicket(T);
            TR.FinishTicket();
            Assert.False(TR.tickets.Contains(T));
        }
    }
}
