namespace PetShopWebAPI.Entities
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AmountAll { get; set; }
        public int SubCathegoryID { get; set; }
        public int AmountAvailable { get; set; }
        public string ItemDescription { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
    }
}
