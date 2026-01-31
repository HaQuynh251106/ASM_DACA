using System;
using System.Collections.Generic;

namespace ASM_Bai2.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save(); // Hàm lưu thay đổi xuống DB
    }
}