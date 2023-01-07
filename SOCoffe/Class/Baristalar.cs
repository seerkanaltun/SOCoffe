using SOCoffe.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOCoffe.Class

{
    public class Baristalar : Personel
    {
        public Baristalar(string _name, bool _bostaMi) : base(_name, _bostaMi, CalisanPozisyon.Barista)
        {

        }
    }
}

