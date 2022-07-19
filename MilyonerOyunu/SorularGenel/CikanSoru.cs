using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilyonerOyunu
{
    public class CikanSoru
    {
        public int SoruId { get; set; }
        public int SoruNumarasi { get; set; }
        public string Soru { get; set; }
        public string CevapA { get; set; }
        public string CevapB { get; set; }
        public string CevapC { get; set; }
        public string CevapD { get; set; }
        public int SoruPuani { get; set; }
        public string DogruCevap { get; set; }

    }
}
