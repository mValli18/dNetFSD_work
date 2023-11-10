namespace ShoppingModelLibrary
{
    public class Product
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public float Discount { get; set; }
        public Product()
        {
            Price = 0.0f;
            Discount = 0.5f;
            Quantity = 1;
            Rating = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="picture"></param>
        /// <param name="description"></param>
        /// <param name="rating"></param>
        /// <param name="discount"></param>

        public Product(int id, string name, int quantity, float price, string picture, string description, float rating, float discount)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Picture = picture;
            Description = description;
            Rating = rating;
            Discount = discount;
        }
        public override string ToString()
        {
            float netPrice = Price - (Price * Discount / 100);
            return $"Product Id : {Id}\nProduct Name : {Name}\nProduct Price : {Price}\nProduct Quantity In Hand : {Quantity}" +
                $"Discount offered : {Discount}\nRating : {Rating}";
        }
    }
}