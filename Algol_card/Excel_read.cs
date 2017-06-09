using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Algol_card
{
    public partial class Form1 : Form
    {

        // 확장명 XLS (Excel 97~2003 용)
        private const string ConnectStrFrm_Excel97_2003 =
            "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 8.0; HDR={1}; IMEX={2}';" +
            "Persist Security Info=False";

        // 확장명 XLSX (Excel 2007 이상용)
        private const string ConnectStrFrm_Excel =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';" +
            "Persist Security Info=False";

        /*
         * Excel 파일의 형태를 반환
         * -2 : Error  
         * -1 : 엑셀파일아님
         * 0 : 97-2003 엑셀 파일 (xls)
         * 1 : 2007 이상 파일 (xlsx)
         * XlsFile = Excel File 명 전체 경로입니다.
        */
        public static int ExcelFileType(string XlsFile)
        {
            byte[,] ExcelHeader = {
                { 0xD0, 0xCF, 0x11, 0xE0, 0xA1 }, // XLS  File Header
                { 0x50, 0x4B, 0x03, 0x04, 0x14 }  // XLSX File Header
            };

            // result -2=error, -1=not excel , 0=xls , 1=xlsx
            int result = -1;

            FileInfo FI = new FileInfo(XlsFile);
            FileStream FS = FI.Open(FileMode.Open);

            try
            {
                byte[] FH = new byte[5];

                FS.Read(FH, 0, 5);

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (FH[j] != ExcelHeader[i, j]) break;
                        else if (j == 4) result = i;
                    }
                    if (result >= 0) break;
                }
            }
            catch
            {
                result = (-2);
                //throw e;
            }
            finally
            {
                FS.Close();
            }
            return result;
        }

        /*
         * Excel 파일의 특정 Sheet DataTable 으로 변환하여 반환
         * FileName = Excel File 명 PullPath
         * SheetName = Excel File의 Sheet Name
         * UseHeader= 첫번째 줄을 Field 명으로 사용할 것이지 여부
        */
        private static DataTable OpenExcelTargetSheet(string FileName, string SheetName, bool UseHeader)
        {
            if (FileName == null)
                return null;

            if (SheetName == null)
                return null;

            string[] HDROpt = { "NO", "YES" };
            string HDR = "";
            string ConnStr = "";

            if (UseHeader)
                HDR = HDROpt[1];
            else
                HDR = HDROpt[0];

            int ExcelType = ExcelFileType(FileName);

            switch (ExcelType)
            {
                case (-2): throw new Exception(FileName + "의 형식검사중 오류가 발생하였습니다.");
                case (-1): throw new Exception(FileName + "은 엑셀 파일형식이 아닙니다.");
                case (0):
                    ConnStr = string.Format(ConnectStrFrm_Excel97_2003, FileName, HDR, "1");
                    break;
                case (1):
                    ConnStr = string.Format(ConnectStrFrm_Excel, FileName, HDR, "1");
                    break;
            }

            OleDbConnection OleDBConn = null;
            DataTable Schema;

            try
            {
                OleDBConn = new OleDbConnection(ConnStr);
                OleDBConn.Open();

                Schema = new DataTable();

                OleDbCommand SelectCommand = OleDBConn.CreateCommand();
                SelectCommand.CommandText = "SELECT * FROM [" + SheetName + "$]";

                Schema.Load(SelectCommand.ExecuteReader());
                OleDBConn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (OleDBConn != null) OleDBConn.Close();
            }

            return Schema;
        }

        public void KB(int Excel_num)
        {
            int month_Count = 0, month_Save = 0;
            if (Excel_num == 1)
            {
                DataTable Excel1 = OpenExcelDBTargetSheet(Excel1_fileFullName,
                    Excel1_fileName.Substring(0, Excel1_fileName.LastIndexOf("_") + 5));

                int row_num = 0; string Temp_Use="";
                //값 추출
                foreach (DataRow row in Excel1.Rows)
                {
                    row_num++;
                    if (row_num > 4)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0) {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }              
                            }              
                            else if (i == 2)//내용
                                Temp_Use = objs[i].ToString();
                            else if (i == 4)// 출금(원)
                            {
                                if (objs[i].ToString() == "0")
                                     continue;
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                                Excel_Use.Add(Temp_Use);
                            }
                        }
                    }
                }
            }
            else if (Excel_num == 2)
            {
                DataTable Excel2 = OpenExcelDBTargetSheet(Excel2_fileFullName,
                    Excel2_fileName.Substring(0, Excel2_fileName.LastIndexOf("_") + 5));

                int row_num = 0; string Temp_Use = "";

                //값 추출
                foreach (DataRow row in Excel2.Rows)
                {
                    row_num++;
                    if (row_num > 4)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0)
                                {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }
                            }
                            else if (i == 2)//내용
                                Temp_Use = objs[i].ToString();
                            else if (i == 4)// 출금(원)
                            {
                                if (objs[i].ToString() == "0")
                                    continue;
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                                Excel_Use.Add(Temp_Use);
                            }
                        }
                    }
                }
            }
            else if (Excel_num == 3)
            {
                DataTable Excel3 = OpenExcelDBTargetSheet(Excel3_fileFullName, 
                    Excel3_fileName.Substring(0, Excel3_fileName.LastIndexOf("_") + 5));

                int row_num = 0; string Temp_Use = "";

                //값 추출
                foreach (DataRow row in Excel3.Rows)
                {
                    row_num++;
                    if (row_num > 4)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0)
                                {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }
                            }
                            if (i == 2)//내용
                                Temp_Use = objs[i].ToString();
                            else if (i == 4)// 출금(원)
                            {
                                if (objs[i].ToString() == "0")
                                    continue;
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                                Excel_Use.Add(Temp_Use);
                            }
                        }
                    }
                }
            }
        }

        public void SH(int Excel_num)
        {
            int month_Count = 0, month_Save = 0;
            if (Excel_num == 1)
            {
                DataTable Excel1 = OpenExcelDBTargetSheet(Excel1_fileFullName, Excel1_fileName.Substring(0, Excel1_fileName.IndexOf(".")));

                int row_num = 0;

                //값 추출
                foreach (DataRow row in Excel1.Rows)
                {
                    row_num++;
                    if (row_num > 6)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0)
                                {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }
                            }
                            if (i == 3) //출금(원)
                            {
                                if (objs[i].ToString() == "") { break; }
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                            }
                            else if (i == 5)// 내용
                                Excel_Use.Add(objs[i].ToString());
                        }
                    }
                }
            }
            else if (Excel_num == 2)
            {
                DataTable Excel2 = OpenExcelDBTargetSheet(Excel2_fileFullName, Excel2_fileName.Substring(0, Excel2_fileName.IndexOf(".")));

                int row_num = 0;

                //값 추출
                foreach (DataRow row in Excel2.Rows)
                {
                    row_num++;
                    if (row_num > 6)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0)
                                {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }
                            }
                            if (i == 3) //출금(원)
                            {
                                if (objs[i].ToString() == "")
                                    break;
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                            }
                            else if (i == 5)// 내용
                                Excel_Use.Add(objs[i].ToString());
                        }
                    }
                }
            }
            else if (Excel_num == 3)
            {
                DataTable Excel3 = OpenExcelDBTargetSheet(Excel3_fileFullName, Excel3_fileName.Substring(0, Excel3_fileName.IndexOf(".")));

                int row_num = 0;

                //값 추출
                foreach (DataRow row in Excel3.Rows)
                {
                    row_num++;
                    if (row_num > 6)
                    {
                        Object[] objs = row.ItemArray;
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (i == 0)//거래일시
                            {
                                if (month_Count == 0)
                                {
                                    month_Save = Convert.ToInt32(objs[i].ToString()[6]); month_Count++;
                                }
                                else if (month_Save != objs[i].ToString()[6])
                                {
                                    return;
                                }
                            }
                            if (i == 3) //출금(원)
                            {
                                if (objs[i].ToString() == "")
                                    break;
                                Excel_Won.Add(Convert.ToInt32(objs[i].ToString().Replace(",", "")));
                            }
                            else if (i == 5)// 내용
                                Excel_Use.Add(objs[i].ToString());
                        }
                    }
                }
            }
        }



        public void Save_Data_Excel(int Excel_Num1, int Excel_Num2, int Excel_Num3)
        {
            if (Excel_Num1 == 1)
            {
                if (button_excel1.Text == "신한")
                    SH(1);
                else if (button_excel1.Text == "국민")
                    KB(1);
            }
            if (Excel_Num2 == 1)
            {
                if (button_excel2.Text == "신한")
                    SH(2);
                else if (button_excel2.Text == "국민")
                    KB(2);
            }
            if (Excel_Num3 == 1)
            {
                if (button_excel3.Text == "신한")
                    SH(3);
                else if (button_excel3.Text == "국민")
                    KB(3);
            }
        }



        /*
         * Excel 파일의 특정 Sheet DataTable 으로 변환하여 반환
         * ExcelFile = Excel File 명(전체경로).
        */
        public static DataTable OpenExcelDBTargetSheet(string FileName, string SheetName)
        {
            return OpenExcelTargetSheet(FileName, SheetName, true);
        }

        public string check_filename(string file_name)
        {
            if (file_name[8] == 'K' && file_name[9] == 'B')
                return "국민";
            else if (file_name[8] == '신' && file_name[9] == '한')
                return "신한";
            /*
            else if ()
                return "우리";
            else if ()
                return "하나";
                */
            else
                return "ERROR";
        }
    }
}