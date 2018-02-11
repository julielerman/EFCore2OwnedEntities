using System;
using System.Collections.Generic;

namespace OwnedEntityDemo
{
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
  
}