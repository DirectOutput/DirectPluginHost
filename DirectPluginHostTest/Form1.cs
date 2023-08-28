using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectPluginHost;

namespace DirectPluginHostTest
{
    public partial class Form1 : Form
    {
        Host Host = new Host();

        public Form1()
        {
            InitializeComponent();

            RefreshOutput();

        }

        private void PluginInit_Click(object sender, EventArgs e)
        {
            if (DataHostingApplication.Text.Length > 0)
            {
                Host.PluginsInit(DataHostingApplication.Text, DataTableFilename.Text, DataGameName.Text);
            }
            else
            {
                MessageBox.Show("You must at least specify the hosting application name before calling init.");
            }
            RefreshOutput();
        }

        private void PluginFinish_Click(object sender, EventArgs e)
        {
            Host.PluginsFinish();
            RefreshOutput();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Number = 0;
            int Value = 0;


         
            if (int.TryParse(DataNumber.Text, out Number) && int.TryParse(DataValue.Text, out Value) && DataTableElementType.Text != null && DataTableElementType.Text.ToString().Length>0)
            {
                char TableElementType = DataTableElementType.Text[0];

                Host.PluginsDataReceive(TableElementType, Number, Value);
            }
            else
            {
                MessageBox.Show("IdNumber and Value must contain numeric values before data can be sent.");
            }
            RefreshOutput();
        }


        private void RefreshOutput()
        {
            PluginHostStatus.Text = Host.Status.ToString();

            PluginList.Rows.Clear();

            foreach (Plugin P in Host.Plugins)
            {
                int RowIndex = PluginList.Rows.Add();
                PluginList[PluginListName.Name, RowIndex].Value = P.Name;
                PluginList[PluginListStatus.Name, RowIndex].Value = P.Status;
                PluginList[PluginListLastException.Name, RowIndex].Value = (P.LastException!=null?P.LastException.Message:"");
            }


        }

    }
}
