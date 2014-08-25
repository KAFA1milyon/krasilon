using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace balaban.Models
{
    public abstract class Status
    {
        private bool _isLive;
        public bool? IsLive
        {
            get { return _isLive; }
            set { _isLive = value == null ? true : (Boolean)value; }
        }

        private bool _isDeleted;
        public virtual bool? IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value == null ? true : (Boolean)value; }
        }
    }
}