using Ecommerce.Data;
using Ecommerce.Model;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product Get(string id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(string id);
    }

    public class ProductService:IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(string id)
        {
            var entity = productRepository.Get(id);
            if (entity != null)
            {
                productRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public Product Get(string id)
        {
            return productRepository.Get(id, "Category");
        }

        public IList<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void Insert(Product product)
        {
            productRepository.Insert(product);
            unitOfWork.SaveChanges();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
            unitOfWork.SaveChanges();
        }
    }
}
