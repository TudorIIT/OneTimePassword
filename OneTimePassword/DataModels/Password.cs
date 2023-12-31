﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.DataModels
{
    public class Password
    {
        internal string userID { get; set; }
        private DateOnly userDate { get; set; }
        public DateTime GeneratedTime { get; set; }
        internal string otPassword { get; set; }
        public bool validity { get; private set; }

        public Password(string userID, DateOnly userDate, string password)
        {
            this.userID = userID;
            this.userDate = userDate;
            GeneratedTime = DateTime.Now;
            otPassword = password;
            validity = true;
        }

        public void SetValidityToFalse()
        {
            validity = false;
        }
     
    }
}
