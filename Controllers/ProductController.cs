using System;
using System.Collections.Generic;
using System.Linq;
using api_netcore_and_ef.Models;
using api_netcore_and_ef.Repositories;
using api_netcore_and_ef.ViewModels;
using api_netcore_and_ef.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_netcore_and_ef.Controllers {
    public class ProductController : Controller {
        private readonly ProductRepository _repository;

        public ProductController (ProductRepository repository) {
            _repository = repository;
        }

        [Route ("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get () {
            return _repository.Get ();
        }

        [Route ("v1/products/{id}")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public Product Get (int id) {
            return _repository.Get (id);
        }

        [Route ("v1/products")]
        [HttpPost]
        public ResultViewModel Post ([FromBody] EditorProductViewModel model) {
            model.Validate ();
            if (model.Invalid)
                return new ResultViewModel {
                    Success = false,
                        Message = "Não foi possível cadastrar o produto",
                        Data = model.Notifications
                };

            var product = new Product ();
            product.Title = model.Title;
            product.IdCategory = model.IdCategory;
            product.CreateDate = DateTime.Now; // Nunca recebe esta informação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdate = DateTime.Now; // Nunca recebe esta informação
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Save (product);

            return new ResultViewModel {
                Success = true,
                    Message = "Produto cadastrado com sucesso!",
                    Data = product
            };
        }

        [Route ("v2/products")]
        [HttpPost]
        public ResultViewModel Post ([FromBody] Product product) {
            _repository.Save (product);

            return new ResultViewModel {
                Success = true,
                    Message = "Produto cadastrado com sucesso!",
                    Data = product
            };
        }

        [Route ("v1/products")]
        [HttpPut]
        public ResultViewModel Put ([FromBody] EditorProductViewModel model) {
            model.Validate ();
            if (model.Invalid)
                return new ResultViewModel {
                    Success = false,
                        Message = "Não foi possível alterar o produto",
                        Data = model.Notifications
                };

            var product = _repository.Get (model.Id);
            product.Title = model.Title;
            product.IdCategory = model.IdCategory;
            // product.CreateDate = DateTime.Now; // Nunca altera a data de criação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdate = DateTime.Now; // Nunca recebe esta informação
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Update (product);

            return new ResultViewModel {
                Success = true,
                    Message = "Produto alterado com sucesso!",
                    Data = product
            };
        }

    }
}