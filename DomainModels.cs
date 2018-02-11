using System;
using System.Collections.Generic;

namespace OwnedEntityDemo {
 
  public class SalesOrder {
    public SalesOrder (DateTime orderDate, decimal orderTotal) {
      OrderDate = orderDate;
      OrderTotal = orderTotal;
      Id = Guid.NewGuid ();
    }
    private SalesOrder () {}
    public Guid Id { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal OrderTotal { get; private set; }
    private PostalAddress _shippingAddress;
    public PostalAddress ShippingAddress =>_shippingAddress;
    
    public void SetShippingAddress (PostalAddress shipping) {
      _shippingAddress = shipping;
    }
    private PostalAddress _billingAddress;
    public PostalAddress BillingAddress=>_billingAddress;
    public void CopyShippingAddressToBillingAddress () {
      _billingAddress = _shippingAddress?.CopyOf ();

    }
    public void SetBillingAddress (PostalAddress billing) {
      _billingAddress = billing;
    }
  }
   
    public class PostalAddress : ValueObject<PostalAddress> {
      public static PostalAddress Create (string street, string city, string region, string postalCode) {
        return new PostalAddress (street, city, region, postalCode);
      }
      public static PostalAddress Empty () {
        return new PostalAddress (null, null, null, null);
      }
      private PostalAddress () { }
      private PostalAddress (string street, string city, string region, string postalCode) {
        Street = street;
        City = city;
        Region = region;
        PostalCode = postalCode;
      }
      public string Street { get; private set; }
      public string City { get; private set; }
      public string Region { get; private set; }
      public string PostalCode { get; private set; }
      public PostalAddress CopyOf () {
        return new PostalAddress (Street, City, Region, PostalCode);
      }
    }
  
}