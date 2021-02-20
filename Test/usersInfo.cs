using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public partial class usersInfo
    {
        #region Field Members
        public const string uid_Field = "uid";
        public const string name_Field = "name";
        public const string pwd_Field = "pwd";
        public const string jib_Field = "jib";
        public const string email_Field = "email";
        public const string qq_Field = "qq";
        public const string rdage_Field = "rdage";
        public const string ndate_Field = "ndate";
        #endregion

        #region Property Members
        /// <summary>
        ///  int
        /// <summary>
        public int? uid
        {
            set;
            get;
        }
        /// <summary>
        ///  nvarchar(50)
        /// <summary>
        public string name
        {
            set;
            get;
        }
        /// <summary>
        ///  nvarchar(50)
        /// <summary>
        public string pwd
        {
            set;
            get;
        }
        /// <summary>
        ///  int
        /// <summary>
        public int? jib
        {
            set;
            get;
        }
        /// <summary>
        ///  nvarchar(50)
        /// <summary>
        public string email
        {
            set;
            get;
        }
        /// <summary>
        ///  nvarchar(12)
        /// <summary>
        public string qq
        {
            set;
            get;
        }
        /// <summary>
        ///  datetime
        /// <summary>
        public DateTime? rdage
        {
            set;
            get;
        }
        /// <summary>
        ///  datetime
        /// <summary>
        public DateTime? ndate
        {
            set;
            get;
        }
        #endregion

    }
}
