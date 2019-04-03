using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IronMountainEx2Archiver.DTO
{
    public class ArchivatorDTO
    {
        public string StartIndex { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Delimiter { get; set; }
    }
}
