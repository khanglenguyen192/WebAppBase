using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Service
{
    public interface IPersonService : IBaseService<WebApp.Data.Entities.Person>
    {
        WebApp.Data.Entities.Person GetUser(string email, string passCode, bool isUsingPhoneNumber = false);
    }
}