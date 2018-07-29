using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace dataAnalyse.DataClass
{
    class ScanInfo
    {
        public UInt16 nId;
        public UInt16 nVersion;
        public UInt32 nBlockLength;
        public float fScanAzimuth_deg;
        public float fScanElevation_deg;
        public float fAzimuthRate_dps;
        public float fElevationRate_dps;
        public float fTargetAzimuth_deg;
        public float fTargetElevation_deg;
        public Int32 nScanEnabled;
        public Int32 nCurrentIndex;
        public Int32 nAcqScanState;
        public Int32 nDriveScanState;
        public Int32 nAcqDwellState;
        public Int32 nScanPatternType;
        public Int32 nValidPos;
        public Int32 nSSDoneState;
        public Int32 nErrorFlags;


    }
}
