using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     abstract class BaseService
    {

            public ExchangingApartmentContext db;
            public BaseService()
            {

                db = new ExchangingApartmentContext();
            }


        //CARD

        public abstract int add(BaseService val);

      
     //   getByid()

        public Address convertAddressToEntity(address address)
            {
                
            }
            public address convertAddressToDAL(Address Address)
            {
                
            }
            public Apartment convertApartmentToEntity(apartment apartment)
            {
                
            }

            public apartment convertApartmentToDAL(Apartment Apartment)
            {
               
            }            
        }
    }
}
