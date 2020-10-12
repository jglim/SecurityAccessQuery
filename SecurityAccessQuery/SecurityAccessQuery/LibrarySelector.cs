using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAccessQuery
{
    public partial class LibrarySelector : Form
    {
        public string SelectedFile { get; set; }

        public List<DllContext> LoadedDlls = new List<DllContext>();
        private Keys[] directionalKeys = new Keys[] { Keys.Up, Keys.Down, Keys.Left, Keys.Right };

        public LibrarySelector()
        {
            InitializeComponent();
        }

        private void LibrarySelector_Load(object sender, EventArgs e)
        {
            UnmanagedUtility.SendMessage(txtFilter.Handle, UnmanagedUtility.EM_SETCUEBANNER, 0, "Filter library by file name or ECU name..");
            EnableDoubleBuffer(dgvResponse, true);
            DrawDatagrid();
        }
        
        public static void EnableDoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void DrawDatagrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Target ECU");
            dt.Columns.Add("Available Levels");

            foreach (DllContext dll in LoadedDlls)
            {
                if (cbHasGenerationFn.Checked)
                {
                    if (!dll.KeyGenerationCapability)
                    {
                        continue;
                    }
                }
                if (cbHasValidModes.Checked)
                {
                    if (dll.AccessLevels.Count == 0)
                    {
                        continue;
                    }
                }
                string filter = txtFilter.Text.ToLower();
                if (dll.FileName.ToLower().Contains(filter) || dll.FileName.ToLower().Contains(filter))
                {
                    string accessLevels = string.Join(", ", dll.AccessLevels.Select(t => $"{t.Item1}"));
                    dt.Rows.Add(new string[] { dll.FileName, dll.ECUName, $"[{accessLevels}]" });
                }
            }

            dgvResponse.DataSource = dt;
            dgvResponse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResponse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvResponse.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }


        private void cbHasGenerationFn_CheckedChanged(object sender, EventArgs e)
        {
            DrawDatagrid();
        }

        private void cbHasValidModes_CheckedChanged(object sender, EventArgs e)
        {
            DrawDatagrid();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            DrawDatagrid();
        }

        private bool TryReturnSelectedItem() 
        {
            if (dgvResponse.SelectedRows.Count > 0)
            {
                SelectedFile = Program.GetLibraryPath() + dgvResponse.SelectedRows[0].Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }
            return false;
        }

        private void dgvResponse_DoubleClick(object sender, EventArgs e)
        {
            TryReturnSelectedItem();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!TryReturnSelectedItem())
            {
                MessageBox.Show("Please select a DLL file first", "No file selected");
            }
        }

        private void dgvResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TryReturnSelectedItem();
                return;
            }

            if (directionalKeys.Contains(e.KeyCode))
            {
                return;
            }
            else 
            {
                // send unrecognized keystrokes into the textbox if the user decides to type into the datagridview
                txtFilter.Focus();
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TryReturnSelectedItem();
                return;
            }
            // navigation keys go back to the datagridview
            if (directionalKeys.Contains(e.KeyCode))
            {
                dgvResponse.Focus();
            }
        }
    }
}
