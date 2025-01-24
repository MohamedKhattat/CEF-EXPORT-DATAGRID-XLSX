using System.Windows;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.Win32;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = sfDataGrid.ExportToExcel(sfDataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            IWorksheet sheet = workBook.Worksheets[0];

            sheet.InsertColumn(1, 1, ExcelInsertOptions.FormatDefault);
            var rowcount = this.sfDataGrid.RowGenerator.Items.Count;

            for (int i = 1; i < rowcount; i++)
            {
                sheet.Range["A" + (i + 1).ToString()].Number = i;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {

                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }
    }
}