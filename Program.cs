using System;
using System.Linq;

namespace OwnedEntityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        using (var context=new OrderContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
            InsertNewOrder();
            RetrieveOrder();
        }

    private static void InsertNewOrder()
    {
      var order=new SalesOrder(DateTime.Today, 100.00M);
      order.ShippingAddress=PostalAddress.Create("One Main","Burlington", "VT", "05000");
      //order.BillingAddress=new PostalAddress("Two Main","Burlington", "VT", "05000");
      using(var context=new OrderContext()){
          context.SalesOrders.Add(order);
          context.SaveChanges();
      }

    }
    private static void RetrieveOrder()
    {
       using(var context=new OrderContext()){
          var order=context.SalesOrders.FirstOrDefault();
        
      }  
    }
  }
}
