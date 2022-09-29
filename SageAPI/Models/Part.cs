namespace SageAPI.Models
{
    public class Part
    {
        public int ObjectID { get; set; }

        public string Desc { get; set; }

        public string Unit { get; set; }

        public string BinNumber { get; set; }

        public string AlphaPart { get; set; }

        public string MSDSNumber { get; set; }

        public string Manufacturer { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string UserDefined1 { get; set; }

        public string UserDefined2 { get; set; }

        public double CostCodeRef { get; set; }

        public int CostTypeRef { get; set; }

        public double TaskRef { get; set; }

        public int PartClassRef { get; set; }

        public int InventoryLocationRef { get; set; }

        public string PriceLastUpdatedDate { get; set; }

        public double ReorderQuantity { get; set; }

        public double MinimumOrderQuantity { get; set; }

        public double PackagedQuantity { get; set; }

        public double ShippingWeight { get; set; }

        public double AverageCost { get; set; }

        public double DefaultCost { get; set; }

        public double LaborUnitQuantity { get; set; }

        public double BillingAmount { get; set; }

        public double OnHandQuantity { get; set; }

        public double UserDefined6Logical { get; set; }

        public int IsStockPart { get; set; }

        public int IsSerialized { get; set; }

        public double BillingMarkupRate { get; set; }

        public int PartRef { get; set; }

        public string Memo { get; set; }

        public int IsServiceEquipment { get; set; }

        public int OEMWarrantyDuration { get; set; }

        public int InventoryRequired { get; set; }

        public int IsInactive { get; set; }
    }
}