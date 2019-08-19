using System.Collections.Generic;
using System.Linq;
using api_netcore_and_ef.Data;
using api_netcore_and_ef.Models;
using api_netcore_and_ef.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_netcore_and_ef.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDataContext _context;

        public ProductRepository (StoreDataContext context) {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get(){
            return _context.Products
                .Include (x => x.Category)
                .Select (x => new ListProductViewModel {
                    Id = x.Id,
                        Title = x.Title,
                        Price = x.Price,
                        Category = x.Category.Title,
                        IdCategory = x.IdCategory
                })
                .AsNoTracking ()
                .ToList ();
        }

        public Product Get(int id){
            return _context.Products.Find(id);
            //_context.Products.AsNoTracking ().Where (x => x.Id == id).FirstOrDefault ();
        }

        public void Save(Product product){
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product){
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges(); 
        }
    }
}