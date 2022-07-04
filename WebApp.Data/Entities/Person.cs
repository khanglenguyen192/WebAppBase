using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApp.Common.Util.Enum;

namespace WebApp.Data.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {

        }

        public Person(int id, DateTime createdDateTime, string userFullName, string userEmail, string userPhone, DateTime? userBirthday, Gender userGender, string userPassword)
        {
            Id = id;
            CreatedDateTime = createdDateTime;
            UserFullName = userFullName;
            UserEmail = userEmail;
            UserPhone = userPhone;
            UserBirthday = userBirthday;
            UserGender = userGender;
            UserPassword = userPassword;
        }

        public string UserFullName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        public DateTime? UserBirthday { get; set; }

        public Gender UserGender { get; set; }

        public string UserPassword { get; set; }

    }
}