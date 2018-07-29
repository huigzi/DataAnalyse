using dataAnalyse.DataClass;
using System;
using System.IO;
using System.Windows;

namespace dataAnalyse
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataAnalyse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = ""
            };

            var result = openFileDialog.ShowDialog();

            if (result == false)
            {
                return;
            }

            FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

            var filecount = file.Length;
            byte[] readBuf = new byte[filecount];
            int count = 0;

            BinaryReader binaryReader = new BinaryReader(file);

            binaryReader.Read(readBuf, 0, (int)filecount);

            BlockDescription blockDescription = new BlockDescription();

            RecordHeader recordHeader1 = new RecordHeader();
            RecordHeader recordHeader2 = new RecordHeader();
            ScanInfo scanInfo = new ScanInfo();
            VelocityDataBlock velocityDataBlock1 = new VelocityDataBlock();
            VelocityDataBlock velocityDataBlock2 = new VelocityDataBlock();

            recordHeader1.nID = BitConverter.ToUInt16(readBuf, count);
            count += 2;
            recordHeader1.nVersion = BitConverter.ToUInt16(readBuf, count);
            count += 2;
            recordHeader1.nBlockLength = BitConverter.ToUInt32(readBuf, count);
            count += 4;
            recordHeader1.nRecordLength = BitConverter.ToUInt32(readBuf, count);
            count += 4;
            recordHeader1.nYear = BitConverter.ToUInt16(readBuf, count);
            count += 2;
            recordHeader1.nMonth = readBuf[14];
            recordHeader1.nDayOfMonth = readBuf[15];
            recordHeader1.nHour = BitConverter.ToUInt16(readBuf, 16);
            recordHeader1.nMinute = readBuf[18];
            recordHeader1.nSecond = readBuf[19];
            recordHeader1.nNanoSecond = BitConverter.ToUInt32(readBuf, 20);

            velocityDataBlock1.nId = BitConverter.ToUInt16(readBuf, 24);
            velocityDataBlock1.nVersion = BitConverter.ToUInt16(readBuf, 26);
            velocityDataBlock1.nBlockLength = BitConverter.ToUInt32(readBuf, 28);

            velocityDataBlock1.chConfiguration = new byte[velocityDataBlock1.nBlockLength];

            Array.Copy(readBuf, 32, velocityDataBlock1.chConfiguration, 0, velocityDataBlock1.nBlockLength);

            velocityDataBlock2.nId = BitConverter.ToUInt16(readBuf, (int) recordHeader1.nBlockLength);
            velocityDataBlock2.nVersion = BitConverter.ToUInt16(readBuf, (int) (recordHeader1.nBlockLength + 2));
            velocityDataBlock2.nBlockLength = BitConverter.ToUInt32(readBuf, (int) (recordHeader1.nBlockLength + 4));

            velocityDataBlock2.chConfiguration = new byte[velocityDataBlock2.nBlockLength];

            Array.Copy(readBuf, (int)(recordHeader1.nBlockLength + 8), velocityDataBlock2.chConfiguration, 0, velocityDataBlock2.nBlockLength);

            recordHeader2.nID = BitConverter.ToUInt16(readBuf,
                (int) (recordHeader1.nBlockLength + velocityDataBlock2.nBlockLength));
            recordHeader2.nVersion = BitConverter.ToUInt16(readBuf,
                (int) (recordHeader1.nBlockLength + velocityDataBlock2.nBlockLength + 2));
            recordHeader2.nBlockLength = BitConverter.ToUInt32(readBuf,
                (int) (recordHeader1.nBlockLength + velocityDataBlock2.nBlockLength + 4));
            recordHeader2.nRecordLength = BitConverter.ToUInt32(readBuf,
                (int) (recordHeader1.nBlockLength + velocityDataBlock2.nBlockLength + 8));
            recordHeader2.nYear = BitConverter.ToUInt16(readBuf,
                (int) (recordHeader1.nBlockLength + velocityDataBlock2.nBlockLength + 12));

            Console.ReadKey();
        }
    }
}
