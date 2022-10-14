using NPOI.XSSF.UserModel;
using System.Data;
using NPOI.HSSF.UserModel;



namespace BAT.api.Utils.Helpers
{
    public class ExcelHelper
    {
        public static void MergeData(string path, DataTable dt)
        {
            XSSFWorkbook workbook = new XSSFWorkbook(path);
            XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0);
            XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            if (dt.Rows.Count == 0)
            {
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    dt.Columns.Add(column);
                }
            }
            else
            {
            }

            int rowCount = sheet.LastRowNum + 1;
            for (int i = (sheet.FirstRowNum + 1); i < rowCount; i++)
            {
                XSSFRow row = (XSSFRow)sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            workbook = null;
            sheet = null;

           
        }
        public static void ExportEasy(DataTable dtSource, string strFileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
            foreach (DataColumn column in dtSource.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dataRow = (HSSFRow)sheet.CreateRow(i + 1);
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                }
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
        }
    }
}
