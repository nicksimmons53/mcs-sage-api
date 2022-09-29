using System.Xml.Serialization;

namespace SageAPI.Models
{
  [XmlRoot("ClientQryRs")]
  public class Client
  {
    public int ObjectID { get; set; }

    public string ShortName { get; set; }

    public string Name { get; set; }

    public string Greeting { get; set; }

    public string Addr1 { get; set; }

    public string Addr2 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public string BillingAddr1 { get; set; }

    public string BillingAddr2 { get; set; }

    public string BillingCity { get; set; }

    public string BillingState { get; set; }

    public string BillingPostalCode { get; set; }

    public string ShippingAddr1 { get; set; }

    public string ShippingAddr2 { get; set; }

    public string ShippingCity { get; set; }

    public string ShippingState { get; set; }

    public string ShippingPostalCode { get; set; }

    public string UserDefined1 { get; set; }

    public string UserDefined2 { get; set; }

    public string UserDefined3 { get; set; }

    public string UserDefined4 { get; set; }

    public string UserDefined5 { get; set; }

    public int UserDefined6Logical { get; set; }

    public int UserDefined7Logical { get; set; }

    public int UserDefined8Logical { get; set; }

    public int UserDefined9Logical { get; set; }

    public string Contact1 { get; set; }

    public string Contact2 { get; set; }

    public string Contact3 { get; set; }

    public string Contact1Desc { get; set; }

    public string Contact2Desc { get; set; }

    public string Contact3Desc { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Phone3 { get; set; }

    public string PhoneExtension1 { get; set; }

    public string PhoneExtension2 { get; set; }

    public string PhoneExtension3 { get; set; }

    public string Fax1 { get; set; }

    public string Fax2 { get; set; }

    public string Fax3 { get; set; }

    public string Mobile1 { get; set; }

    public string Mobile2 { get; set; }

    public string Mobile3 { get; set; }

    public string Pager1 { get; set; }

    public string Pager2 { get; set; }

    public string Pager3 { get; set; }

    public string Email1 { get; set; }

    public string Email2 { get; set; }

    public string Email3 { get; set; }

    public string ReceivedDate { get; set; }

    public int SalespersonRef { get; set; }

    public int ManagerRef { get; set; }

    public int SalesTaxDistrictRef { get; set; }

    public string ContactedDate { get; set; }

    public string CallbackDate { get; set; }

    public string MailpieceDate { get; set; }

    public string MailedDate { get; set; }

    public string PurchasedDate { get; set; }

    public string ReferenceDate { get; set; }

    public int ProductRef { get; set; }

    public string DiscountTerm { get; set; }

    public double EarlyPaymentDiscountRate { get; set; }

    public string DueTerm { get; set; }

    public double FinanceRate { get; set; }

    public int SourceRef { get; set; }

    public int ClientTypeRef { get; set; }

    public int ClientStatusRef { get; set; }

    public int MailListRef { get; set; }

    public int AreaRef { get; set; }

    public int SizeRef { get; set; }

    public int ContractRef { get; set; }

    public string ExpirationDate { get; set; }

    public int DiscountRate { get; set; }

    public int BeginningBalance { get; set; }

    public int EndingBalance { get; set; }

    public string MapLocation { get; set; }

    public string CrossStreet { get; set; }

    public int PartBillingBasis { get; set; }

    public string PurchaseOrderNumber { get; set; }

    public string TaxExemptionNumber { get; set; }

    public string CreditCardNumber { get; set; }

    public string CreditCardExpirationDate { get; set; }

    public string CreditCardCardholder { get; set; }

    public string CreditCardType { get; set; }

    public string Memo { get; set; }

    public int IsInactive { get; set; }

    public string StatementEmail { get; set; }
  }
}