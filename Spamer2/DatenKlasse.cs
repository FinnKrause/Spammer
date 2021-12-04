using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spamer
{
    public class DatenKlasse
    {
        public bool EnterNachAusgabe { get; set; }
        public bool Random { get; set; }
        public string Type { get; set; }
        public bool Advanced { get; set; }
        public string CurrentText { get; set; }
        public int Durchläufe { get; set; }
        public int Speed { get; set; }
        public string Background { get; set; }

    }
}
