using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Service.Person.Impls
{
    public class PersonService : BaseService<Data.Entities.Person>, IPersonService
    {
        public PersonService()
        {
        }

        public Data.Entities.Person GetUser(string userName, string passCode, bool isUsingPhoneNumber = false)
        {
            if (isUsingPhoneNumber)
                return GetQueryable(p => p.UserPhone.Equals(userName) && p.UserPassword.Equals(passCode)).FirstOrDefault();
            return GetQueryable(p => p.UserEmail.Equals(userName) && p.UserPassword.Equals(passCode)).FirstOrDefault();
        }
    }
}