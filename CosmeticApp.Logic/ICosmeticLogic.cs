using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmeticApp.Model;



namespace CosmeticApp.Logic
{
    /// <summary>
    /// Определяет бизнес-логику для работы с сущностью Cosmetic
    /// </summary>
    public interface ICosmeticLogic
    {
        void Create(Cosmetic cosmetic);
        void Delete(int id);
        Cosmetic ReadById(int id);
        void Update(Cosmetic cosmetic);
        IEnumerable<Cosmetic> GetAllCosmetics();
        IEnumerable<Cosmetic> GetCosmeticsByBrand(Brand brand);
        IEnumerable<Cosmetic> GetExpensiveCosmetics(decimal threshold);
    }
}