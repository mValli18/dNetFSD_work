using ShoppingModelLibrary;

namespace ShoppingDAMLibrary
{
    public class ProductRepository : IRepository<int, Product>
    {
        Dictionary<int, Product> products = new Dictionary<int, Product>();

        /// <summary>
        /// c
        /// </summary>
        /// <param name="product">Product object that has to be added</param>
        /// <returns>The product that has been added</returns>                                                                   

        public Product Add(Product product)
        {
            int id = GenerateId();
            try
            {
                product.Id= id;
                products.Add(product.Id, product);
                return product;
                //throw new NotImplementedException();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Product already exists");
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Deletes the product from teh dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the product to be deleted</param>
        /// <returns>The deleted product</returns>
        public Product Delete(int id)
        {
            var product = products[id];
            products.Remove(id);
            return product;
        }

        public List<Product> GetAll()
        {
            var productList = products.Values.ToList();
            return productList;
        }

        public Product GetById(int id)
        {
            if (products.ContainsKey(id))
                return products[id];
            return null;
        }

        public Product Update(Product product)
        {
            products[product.Id] = product;
            return product;
        }
            
        private int GenerateId()
        {
            if (products.Count == 0)
                return 1;
            int id=products.Keys.Max();
            return ++id;
        }
    }
}