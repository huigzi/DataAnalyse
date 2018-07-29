using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAnalyse.DataClass
{
    class VelocityDataBlock
    {

        public UInt16 nId;
        public UInt16 nVersion;
        public UInt32 nBlockLength;

        public byte[] chConfiguration;
    }
}
