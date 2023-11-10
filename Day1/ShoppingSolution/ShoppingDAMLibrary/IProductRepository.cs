﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingDAMLibrary
{
    public interface IProductRepository
    {
        public Product Add(Product product);
        public Product Update(Product product);
        public Product Delete(int id);
        public Product GetById(int id);
        public List<Product> GetAll();
    }
}
