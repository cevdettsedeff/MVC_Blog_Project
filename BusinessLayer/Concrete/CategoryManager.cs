using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {

        ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAllOnlyTrue()
        {
            return _categoryDal.List(x => x.CategoryStatus==true);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public void CategoryStatusFalseBL(int id)
        {
            Category category2 = _categoryDal.Find(x => x.CategoryID == id);
            category2.CategoryStatus = false;
            _categoryDal.Update(category2);
        }

        public void CategoryStatusTrueBL(int id)
        {
            Category category3 = _categoryDal.Find(x => x.CategoryID == id);
            category3.CategoryStatus = true;
            _categoryDal.Update(category3);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }


        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
