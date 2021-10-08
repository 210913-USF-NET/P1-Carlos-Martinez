using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IStoreFront
    {
         StoreFront AddStoreFront(StoreFront storeToAdd);

         StoreFront GetStoreFront(StoreFront store);

        List<StoreFront> GetAllStoreFronts();

        void DeleteStoreFront(StoreFront storeToDelete);

        StoreFront UpdateStoreFront(StoreFront storeToUpdate);

    }
}