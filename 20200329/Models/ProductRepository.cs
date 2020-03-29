using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20200329.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        // 생성자
        public ProductRepository()
        {
            products.Add(new Product() { Id = 1, Name = "모니터", Category = "부품", Price = 3000});
            products.Add(new Product() { Id = 2, Name = "스피커", Category = "부품", Price = 2000 });
            products.Add(new Product() { Id = 3, Name = "마우스", Category = "부품", Price = 1000 });
        }

        public Product Create(Product item)
        {
            if (item.Equals(null))
            {
                throw new ArgumentNullException("item is null");
            }

            products.Add(item);

            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public bool Update(Product item)
        {
            int index = products.FindIndex(p => p.Id == item.Id);

            if(index == -1)
            {
                return false;
            }

            products.RemoveAt(index);
            products.Add(item);

            return true;
        }
    }
}