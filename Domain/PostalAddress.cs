namespace OwnedEntityDemo
{
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