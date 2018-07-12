using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAnalyse.DataClass
{
    class RecordHeader
    {
        public UInt16 nID;
        public UInt16 nVersion;
        public UInt32 nBlockLength;
        public UInt32 nRecordLength;
        public UInt16 nYear;
        public Byte nMonth;
        public Byte nDayOfMonth;
        public UInt16 nHour;
        public Byte nMinute;
        public Byte nSecond;
        public UInt32 nNanoSecond;
    }
}
