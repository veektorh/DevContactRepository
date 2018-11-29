using DevContactDirectory.Helper;
using DevContactDirectory.Models;
using Infrastructure.Concrete;
using Infrastructure.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevContactDirectory.Data.Repositories
{
    public class DeveloperRepository
    {
        private readonly IRepository<Developer> repository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork uoWork;
        Logger logger = LogManager.GetLogger("ErrorLogger");

        public DeveloperRepository()
        {
            uoWork = new UnitOfWork();
            repository = new Repository<Developer>(uoWork);
            _categoryRepository = new Repository<Category>(uoWork);
        }

        public Response Add(Developer entity)
        {
            var response = new Response();
            try
            {
                var category = _categoryRepository.GetById(entity.CategoryId);

                if (category == null)
                {
                    response.Message = "Invalid Category";
                    return response;
                }

                var dev = repository.Add(entity);

                var devViewModel = new DeveloperViewModel();
                devViewModel.Id = dev.Id;
                devViewModel.Firstname = dev.Firstname;
                devViewModel.Lastname = dev.Lastname;
                devViewModel.Email = dev.Email;
                devViewModel.Category = dev.Category.Name;

                response.Status = true;
                response.Developer = devViewModel;
                return response;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: Add ||\t Ex.Msg : " + ex.Message);
                return response;

            }
        }

        public IEnumerable<Developer> AddRange(List<Developer> entities)
        {
            try
            {
                return repository.AddRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: AddRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public bool Remove(Developer entity)
        {
            try
            {
                repository.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: Remove ||\t Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public bool Remove(object key)
        {
            try
            {
                repository.Remove(key);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: Remove ||\t  Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public DeveloperViewModel Update(Developer entity)
        {
            try
            {
                var dev =  repository.Update(entity);

                var devViewModel = new DeveloperViewModel();
                devViewModel.Id = dev.Id;
                devViewModel.Firstname = dev.Firstname;
                devViewModel.Lastname = dev.Lastname;
                devViewModel.Email = dev.Email;
                devViewModel.Category = dev.Category.Name;

                return devViewModel;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: Update ||\t Ex.Msg : " + ex.Message);
                return new DeveloperViewModel();
            }
        }

        public IEnumerable<Developer> UpdateRange(List<Developer> entities)
        {
            try
            {
                return repository.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: UpdateRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public List<Developer> GetAll()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: GetAll ||\t Ex.Msg : " + ex.Message);
                return new List<Developer>();
            }
        }

        public List<Developer> GetAll(Expression<Func<Developer, bool>> predicate)
        {
            try
            {
                return repository.GetAll(predicate).ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: GetAll(predicate) ||\t Ex.Msg : " + ex.Message);
                return new List<Developer>();
            }
        }

        public DeveloperViewModel GetById(object key)
        {
            try
            {
                var dev = repository.GetById(key);
                var devViewModel = new DeveloperViewModel();
                devViewModel.Id = dev.Id;
                devViewModel.Firstname = dev.Firstname;
                devViewModel.Lastname = dev.Lastname;
                devViewModel.Email = dev.Email;
                devViewModel.Category = dev.Category.Name;
                
                return devViewModel;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:DeveloperRepository || \t Method: GetById() ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }
    }
}
