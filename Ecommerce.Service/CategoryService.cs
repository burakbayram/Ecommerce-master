using Ecommerce.Data;
using Ecommerce.Model;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service
{
    public interface ICategoryService
    {
        IList<Category> GetAll();
        Category Get(string id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(string id);
    }

    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(string id)
        {
            var entity = categoryRepository.Get(id);
            if (entity != null)
            {
                categoryRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public Category Get(string id)
        {
            return categoryRepository.Get(id);
        }

        public IList<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public void Insert(Category category)
        {
            categoryRepository.Insert(category);
            unitOfWork.SaveChanges();
        }

        public void Update(Category category)
        {
            categoryRepository.Update(category);
            unitOfWork.SaveChanges();
        }
    }
}
