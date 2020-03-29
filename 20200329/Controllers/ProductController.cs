using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _20200329.Models;
using Newtonsoft.Json;

namespace _20200329.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public string GetProductAll()
        {
            List<Product> list = repository.GetAll().ToList();
            return JsonConvert.SerializeObject(list);
        }

        public Product GetProduct(int id)
        {
            Debug.WriteLine(id);
            Product item = repository.Get(id);

            if (item.Equals(null))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(String category)
        {            
            return repository.GetAll().Where(p => String.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        //public HttpResponseMessage PostProduct(Product item)
        //{
        //    item = repository.Create(item);

        //    var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

        //    string uri = Url.Link("DefaultApi", new { id = item.Id });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        public Product PostProduct(Product item)
        {
            repository.Create(item);

            //return item;

            return repository.Get(4);
        }

        public Product PutProduct(int id, Product item)
        {
            item.Id = id;
            repository.Update(item);

            return item;
        }

    }
}
