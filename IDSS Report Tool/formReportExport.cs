using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;

namespace IDSS_Report_Tool
{
    public partial class formReportExport : Form
    {
        public formReportExport ()
        {
            InitializeComponent ();
        }

        private void formMain_Load (object sender, EventArgs e)
        {
            if (VersionCheck("IDSSReportTool","2.00.20150313") == "Y")
            {
                radioNonParameter.Checked = true;
                this.AcceptButton = buttonExport;
            }
            else
            {
                MessageBox.Show ("该程序未获得运行许可，请与管理员联系！");
                Application.Exit ();
            }
        }

        private void radioNonParameter_CheckedChanged (object sender, EventArgs e)
        {
            GetReportList ();
        }

        private void radioHasParameter_CheckedChanged (object sender, EventArgs e)
        {
            GetReportList ();
        }

        private void GetReportList ()
        {
            string sqlReportList = "";
            DataTable dtReportList = new DataTable ();

            string consqlserver = ConfigurationManager.ConnectionStrings["CSD_MGTConnectionString"].ToString () + ";Password=CSD;";
            SqlConnection con = new SqlConnection (consqlserver);

            if (radioNonParameter.Checked == true)
            {
                sqlReportList = "SELECT EMQS_ActionName FROM EMQS_GetReport ORDER BY EMQS_ActionName";
            }
            else
            {
                sqlReportList = "SELECT EMQS_ActionName FROM EMQS_GetReportEX ORDER BY EMQS_ActionName";
            }

            SqlDataAdapter daReportList = new SqlDataAdapter (sqlReportList, con);

            try
            {
                daReportList.Fill(dtReportList);
                if (dtReportList.Rows.Count >= 1)
                {
                    comboReportList.Items.Clear ();

                    for (int i = 0; i < dtReportList.Rows.Count; i++)
                    {
                        comboReportList.Items.Add (dtReportList.Rows[i]["EMQS_ActionName"].ToString ());
                    }
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            finally
            {
                con.Close ();
                con.Dispose ();
                dtReportList.Dispose ();
                daReportList.Dispose ();
            }
        }

        private string VersionCheck (string strProgramName,string strProgramVer)
        {
            string sqlRunAllow = "";
            DataTable dtRunAllow = new DataTable ();

            string consqlserver = ConfigurationManager.ConnectionStrings["CSD_MGTConnectionString"].ToString () + ";Password=CSD;";
            SqlConnection con = new SqlConnection (consqlserver);

            sqlRunAllow = "SELECT ActiveStatus FROM 程序版本控制 WHERE ProgramName = '" + strProgramName + "' AND ProgramV = '" + strProgramVer + "'";

            SqlDataAdapter daRunAllow = new SqlDataAdapter (sqlRunAllow, con);

            try
            {
                daRunAllow.Fill (dtRunAllow);
                if (dtRunAllow.Rows.Count >= 1)
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show (msg.Message);
                return "N";
            }
            finally
            {
                con.Close ();
                con.Dispose ();
                dtRunAllow.Dispose ();
                daRunAllow.Dispose ();
            }
        }

        private void comboReportList_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (comboReportList.Text != "")
            {
                string sqlReportMemo = "";
                DataTable dtReportMemo = new DataTable ();

                string consqlserver = ConfigurationManager.ConnectionStrings["CSD_MGTConnectionString"].ToString () + ";Password=CSD;";
                SqlConnection con = new SqlConnection (consqlserver);

                if (radioNonParameter.Checked == true)
                {
                    sqlReportMemo = "SELECT EMQS_ActionMemo FROM EMQS_GetReport WHERE EMQS_ActionName = '" + comboReportList.Text + "' AND	(NOT ([EMQS_ActionMemo] IS NULL))";
                }
                else
                {
                    sqlReportMemo = "SELECT EMQS_ActionMemo FROM EMQS_GetReportEX WHERE EMQS_ActionName = '" + comboReportList.Text + "' AND	(NOT ([EMQS_ActionMemo] IS NULL))";
                }

                SqlDataAdapter daReportMemo = new SqlDataAdapter (sqlReportMemo, con);

                try
                {
                    daReportMemo.Fill (dtReportMemo);
                    if (dtReportMemo.Rows.Count >= 1)
                    {
                        richDescription.Text = dtReportMemo.Rows[0]["EMQS_ActionMemo"].ToString ();
                    }
                    else
                    {
                        richDescription.Text = "没有说明！";
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
                finally
                {
                    con.Close ();
                    con.Dispose ();
                    dtReportMemo.Dispose ();
                    daReportMemo.Dispose ();
                }
            }
        }

        private void buttonExport_Click (object sender, EventArgs e)
        {
            if (radioHasParameter.Checked == true & textParameter.Text == "")
            {
                MessageBox.Show ("缺少参数！");
            }
            else
            {
                string sqlReportParameter = "";
                DataTable dtReportParameter = new DataTable ();

                string consqlserver = ConfigurationManager.ConnectionStrings["CSD_MGTConnectionString"].ToString () + ";Password=CSD;";
                SqlConnection con = new SqlConnection (consqlserver);

                if (radioNonParameter.Checked == true)
                {
                    sqlReportParameter = "SELECT * FROM EMQS_GetReport WHERE EMQS_ActionName = '" + comboReportList.Text + "'";
                }
                else
                {
                    sqlReportParameter = "SELECT * FROM EMQS_GetReportEX WHERE EMQS_ActionName = '" + comboReportList.Text + "'";
                }

                SqlDataAdapter daReportParameter = new SqlDataAdapter (sqlReportParameter, con);

                try
                {
                    daReportParameter.Fill (dtReportParameter);
                    if (dtReportParameter.Rows.Count >= 1)
                    {
                        CreateReport (dtReportParameter.Rows[0]["EMQS_ServerName"].ToString (),
                                      dtReportParameter.Rows[0]["EMQS_UID"].ToString (),
                                      dtReportParameter.Rows[0]["EMQS_DBName"].ToString (),
                                      dtReportParameter.Rows[0]["EMQS_PWD"].ToString (),
                                      dtReportParameter.Rows[0]["EMQS_PName"].ToString ());
                    }
                    else
                    {
                        MessageBox.Show ("没有符合条件的数据！");
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show (msg.Message);
                }
                finally
                {
                    con.Close ();
                    con.Dispose ();
                    dtReportParameter.Dispose ();
                    daReportParameter.Dispose ();
                }
            }
        }

        private void CreateReport (string strDataSource, string strUserID, string strInitialCatalog, string strPassword, string PName)
        {
            string sqlReportData = "";
            DataTable dtReportData = new DataTable ();

            string consqlserver = "Data Source=" + strDataSource +
                                  ";User ID=" + strUserID +
                                  ";Initial Catalog=" + strInitialCatalog +
                                  ";Password=" + strPassword;
            SqlConnection con = new SqlConnection (consqlserver);

            if (radioNonParameter.Checked == true)
            {
                sqlReportData = "EXEC " + PName;
            }
            else
            {
                sqlReportData = "EXEC " + PName + " '" + textParameter.Text.ToString () + "'";
            }

            SqlDataAdapter daReportData = new SqlDataAdapter (sqlReportData, con);

            try
            {
                daReportData.Fill (dtReportData);
                if (dtReportData.Rows.Count >= 1)
                {
                    var xlsReport = new Excel.Application ();
                    xlsReport.Visible = true;
                    Excel.Workbook workbookReport = xlsReport.Workbooks.Add ();
                    Excel.Worksheet worksheetReport = workbookReport.Worksheets.Add();
                    worksheetReport.Cells.Font.Size = 9;
                    worksheetReport.Name = comboReportList.Text;

                    object[,] valueReport = new object[dtReportData.Rows.Count, dtReportData.Columns.Count];

                    for (int row = 0; row < dtReportData.Rows.Count; row++)
                    {
                        for (int col = 0; col < dtReportData.Columns.Count; col++)
                        {
                            valueReport[row, col] = dtReportData.Rows[row][col].ToString();
                        }
                    }

                    Excel.Range rangeReport = worksheetReport.Range[worksheetReport.Cells[2, 1], worksheetReport.Cells[dtReportData.Rows.Count+1, dtReportData.Columns.Count]];
                    rangeReport.Value2 = valueReport;

                    for (int col = 0; col < dtReportData.Columns.Count; col++)
                    {
                        worksheetReport.Cells[1, col+1] = dtReportData.Columns[col].ColumnName.ToString();
                    }

                    worksheetReport.Cells.EntireColumn.AutoFit();

                    workbookReport.SaveAs ("d:\\IDSS Report\\" +
                                            comboReportList.Text + " " +
                                            DateTime.Now.Year.ToString () + "-" +
                                            DateTime.Now.Month.ToString () + "-" +
                                            DateTime.Now.Day.ToString () + " " +
                                            DateTime.Now.Hour.ToString () + "." +
                                            DateTime.Now.Minute.ToString () + "." +
                                            DateTime.Now.Second.ToString () + ".xlsx");
                    //MessageBox.Show ("得到符合条件的数据" + dtReportData.Rows.Count.ToString());
                }
                else
                {
                    MessageBox.Show ("没有符合条件的数据！");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show (msg.Message);
            }
            finally
            {
                con.Close ();
                con.Dispose ();
                dtReportData.Dispose ();
                daReportData.Dispose ();
            }
        }
    }
}
