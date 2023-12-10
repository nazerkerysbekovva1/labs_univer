using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace func_lab9
{
    internal class Tovar
    {
        private readonly TovarTypeEnum _TovarType;
        private readonly IEnumerable<string> _TovarData;

        public Tovar(TovarTypeEnum TovarType)
        {
            _TovarType = TovarType;
            _TovarData = new List<string>(new string[] { });
        }

        public Tovar(TovarTypeEnum TovarType, IEnumerable<string> TovarData)
        {
            _TovarType = TovarType;
            _TovarData = new List<string>(TovarData);
        }


        public Tovar ChangeTovar(TovarTypeEnum TovarType)
        {
            return new Tovar(TovarType, _TovarData);
        }

        public Tovar ChangeTovar(TovarTypeEnum TovarType, IEnumerable<string> TovarData)
        {
            return new Tovar(TovarType, _TovarData.Concat(TovarData));
        }

        public Tovar ChangeTovar(IEnumerable<string> TovarData)
        {
            return new Tovar(_TovarType, _TovarData.Concat(TovarData));
        }

        public IReadOnlyList<string> TovarData
        {
            get
            {
                return new ReadOnlyCollection<string>(_TovarData.ToList());
            }
        }

        public TovarTypeEnum CurrentTovarType
        {
            get
            {
                return _TovarType;
            }
        }
    }
}