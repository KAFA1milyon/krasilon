using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace balaban.Models
{
    public abstract class Status
    {
        public Status()
        {
            _KayitTarihi = DateTime.Now;
            _GuncellemeTarihi = DateTime.Now;
        }
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
            set { _isDeleted = value == null ? false : (Boolean)value; }
        }

        private DateTime? _KayitTarihi;
        public DateTime? KayitTarihi { get { return _KayitTarihi; }
            private set { _KayitTarihi = value == null ? DateTime.Now : _KayitTarihi; }
        }

        private DateTime _GuncellemeTarihi;
        public virtual DateTime GuncellemeTarihi
        {
            get { return _GuncellemeTarihi; }
            set { _GuncellemeTarihi = DateTime.Now; }
        }
    }
}