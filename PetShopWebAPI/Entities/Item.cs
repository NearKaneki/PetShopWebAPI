namespace PetShopWebAPI.Entities
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SubCathegoryID { get; set; }
        public int AmountAll { get; set; }
        public int AmountCurrent { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public string PictureHref { get; set; }
        public decimal Price { get; set; }
    }
}
