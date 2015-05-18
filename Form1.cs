using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tx_mailmerge_progressbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        frmProgress progress = new frmProgress();

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("sample_db.xml", XmlReadMode.ReadSchema);

            progress = new frmProgress();
            progress.Show();

            progress.progressBar1.Maximum = ds.Tables[0].Rows.Count - 1;
            progress.progressBar1.Value = 0;
            progress.progressBar1.Step = 1;

            mailMerge1.Merge(ds.Tables[0]);

            progress.Close();
        }

        private void mailMerge1_DataRowMerged(object sender, TXTextControl.DocumentServer.MailMerge.DataRowMergedEventArgs e)
        {
            progress.Update();
            progress.progressBar1.PerformStep();
        }
    }
}
