
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace EAAutoFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<DataCollection> _dataCollections = new List<DataCollection>();

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNum = row,
                        columnName = table.Columns[col].ColumnName,
                        columnValue = table.Rows[row][col].ToString()

                    };
                    _dataCollections.Add(dtTable);
                }

            }
        }
        // With Excel Library
        //private static DataTable ExcelToDataTable(string fileName)
        //{
        //    DataTable dt = null;
        //    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        //    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //    //set first row as column
        //    excelReader.IsFirstRowAsColumnNames = true;
        //    DataSet result = excelReader.AsDataSet();
        //    //Get All Table
        //    DataTableCollection table = null;
        //    table = result.Tables;
        //    dt = table["Sheet1"];
        //    return  dt;
        //}

        private static DataTable ExcelToDataTable(string fileName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                    //Get All Table
                    DataTableCollection table = null;
                    table = result.Tables;
                    DataTable dt = table["Sheet1"];
                    return dt;
                }

            }
        }

        public static string ReadData(int rowNum, string columnName)
        {
            try
            {
                string data = (from colData in _dataCollections
                               where colData.columnName == columnName && colData.rowNum == rowNum
                               select colData.columnValue).FirstOrDefault();
                // var data = _dataCollections.Where(x => x.columnName == columnName && x.rowNum == rowNum).SingleOrDefault().columnValue;

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }

    public class DataCollection
    {
        public int rowNum
        {
            get; set;
        }

        public string columnName
        {
            get; set;
        }

        public string columnValue
        {
            get; set;
        }

    }
}
