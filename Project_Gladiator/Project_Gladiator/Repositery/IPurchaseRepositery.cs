using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This interface declares all the methods which will be used by  its repositery and its controller


namespace Project_Gladiator.Repositery
{
    public interface IPurchaseRepositery
    {
        Task<List<Purchase>> GetAllPurchasesAsync();
        Task<Purchase> GetPurchaseAsync(int id);
        Task<Purchase> Register(UpdatePurchaseViewModel purchase);
        Task<Purchase> Update(int id,UpdatePurchaseViewModel purchase);
        Task<Purchase> Delete(int id);
        Task<bool> Exists(int id);
    }
}
