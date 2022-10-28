using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public interface IDao<T>
    {
        void Add(T item);
        void Remove(int id);

        T Get(int id);
<<<<<<< HEAD
=======

        T GetByName(string name);

>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
        IEnumerable<T> GetAll();
    }
}
