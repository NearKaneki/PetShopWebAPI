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


        //public Item(int ID, string Name, int AmountAll, int SubCathegoryID,
        //    int AmountAvailable, string ItemDescription, string Picture, decimal Price)
        //{
        //    this.ID = ID;
        //    this.Name = Name;
        //    this.AmountAll = AmountAll;
        //    this.SubCathegoryID = SubCathegoryID;
        //    this.AmountAvailable = AmountAvailable;
        //    this.ItemDescription = ItemDescription;
        //    this.Picture = Picture;
        //    this.Price = Price;
        //}
    }
}
