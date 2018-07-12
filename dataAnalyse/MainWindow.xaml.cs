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

            byte[] readBuf = new byte[1024];

            FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

            BinaryReader binaryReader = new BinaryReader(file);

            var count = binaryReader.Read(readBuf, 0, 1024);

            BlockDescription blockDescription = new BlockDescription();
            RecordHeader recordHeader = new RecordHeader();

            recordHeader.nID = BitConverter.ToUInt16(readBuf, 0);
            recordHeader.nVersion = BitConverter.ToUInt16(readBuf, 2);
            recordHeader.nBlockLength = BitConverter.ToUInt32(readBuf, 4);
            recordHeader.nRecordLength = BitConverter.ToUInt32(readBuf, 8);
            recordHeader.nYear = BitConverter.ToUInt16(readBuf, 12);
            recordHeader.nMonth = readBuf[14];
            recordHeader.nDayOfMonth = readBuf[15];
            recordHeader.nHour = BitConverter.ToUInt16(readBuf, 16);
            recordHeader.nMinute = readBuf[18];
            recordHeader.nSecond = readBuf[19];
            recordHeader.nNanoSecond = BitConverter.ToUInt32(readBuf, 20);
        }
    }
}
