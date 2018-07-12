using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using dataAnalyse.DataClass;

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
