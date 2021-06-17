using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.Itefaces
{
    public interface IItemRepository 
    {
        /// <summary>
        /// Post Item to data bsae
        /// </summary>
        /// <returns></returns>
        Task<bool> PostItemAsync(Item item);
        /// <summary>
        /// Get Item from data base 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItemAsync(Guid id);
    }
}