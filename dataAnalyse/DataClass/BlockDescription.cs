using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAnalyse.DataClass
{
    class BlockDescription
    {
        public UInt16 nID { get; set; }
        public UInt16 nVersion { get; set; }
        public UInt32 Length { get; set; }
    }
}
