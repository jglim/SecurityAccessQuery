using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
Additional tests:

CRD3NFZ 2435h
WDB9067331S861252
Request Seed for Variantcoding: 52 F6 CB D8
Try B5 E2 62 81
passed: Access Key: 11 (0xB)

MED177
Request 42 21 90 48
C4 2D E1 7E
passed: 5
 */

namespace SecurityAccessQuery
{
    public partial class MainForm : Form
    {
        private DllContext currentDll;
        List<DllContext> cachedDllMetadata = new List<DllContext>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UnmanagedUtility.SendMessage(txtChallenge.Handle, UnmanagedUtility.EM_SETCUEBANNER, 0, "Enter seed data here");

            if (!Directory.Exists(Program.GetLibraryPath())) 
            {
                Directory.CreateDirectory(Program.GetLibraryPath());
                MessageBox.Show("A library folder to contain DLL files was not found, so an empty folder has been created for you.\r\nThis application requires DLL files that match your ECU to operate.", "Notice");
            }

            LoadLibraryMetadata();
            TryRefreshKey();
        }

        private void LoadLibraryMetadata()
        {
            cachedDllMetadata = new List<DllContext>();
            foreach (string file in Program.GetLibraryFiles())
            {
                if (Path.GetExtension(file).ToLower() != ".dll")
                {
                    continue;
                }

                DllContext libraryToLoad = new DllContext(file, false);
                libraryToLoad.UnloadLibrary();
                cachedDllMetadata.Add(libraryToLoad);
            }
        }

        private void DiagnosticsDumpReport()
        {
            List<DllContext> libraries = new List<DllContext>();
            foreach (string file in Program.GetLibraryFiles())
            {
                if (Path.GetExtension(file).ToLower() != ".dll")
                {
                    continue;
                }

                DllContext libraryToLoad = new DllContext(file);
                libraryToLoad.UnloadLibrary();
                libraries.Add(libraryToLoad);
            }

            string divider = "==========================================================";
            StringBuilder sb = new StringBuilder();
            foreach (DllContext library in libraries)
            {
                sb.AppendLine(divider);
                sb.AppendLine();
                sb.AppendLine(library.FileName);
                sb.AppendLine($"SHA1: {library.SHA1Hash}");
                sb.AppendLine($"ECUName: {library.ECUName}");
                sb.AppendLine($"Comment: {library.Comment}");
                sb.AppendLine($"Comment: {library.Comment}");
                sb.AppendLine($"Exports: [{string.Join(", ", library.DllExports)}]");
                string accessLevels = string.Join(", ", library.AccessLevels.Select(t => $"[Level: {t.Item1}, KeySize: {t.Item2}, SeedSize: {t.Item3}]"));
                sb.AppendLine($"Levels: [{accessLevels}]");
                sb.AppendLine();
            }

            string exportPath = Program.GetStartupPath() + "Report.txt";
            File.WriteAllText(exportPath, sb.ToString());
            MessageBox.Show($"Export OK : Report saved at \r\n{exportPath}", "Diagnostics");
        }

        private void ShowDllInfoNew(byte[] seed)
        {
            DataTable dt = new DataTable();
            if (currentDll is null) 
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("Value");
                dt.Rows.Add(new string[] { "Welcome", "Please load a compatible DLL file (File > Select DLL)" });
                dt.Rows.Add(new string[] { "License", "MIT: This application should be made available to you at no cost." });
                dt.Rows.Add(new string[] { "URL", "https://github.com/jglim/SecurityAccessQuery" });
                dgvResponse.DataSource = dt;
                dgvResponse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvResponse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                return;
            }

            dt.Columns.Add("Name");
            dt.Columns.Add("Value");

            dt.Rows.Add(new string[] { "DLL Name", currentDll.FileName });
            dt.Rows.Add(new string[] { "DLL SHA1", currentDll.SHA1Hash });
            dt.Rows.Add(new string[] { "DLL Description", currentDll.FileDescription });
            dt.Rows.Add(new string[] { "ECU Name", currentDll.ECUName });
            dt.Rows.Add(new string[] { "Comment", currentDll.Comment });
            dt.Rows.Add(new string[] { "Capability", $"Specify: {currentDll.ModeSpecified}, Generate: {currentDll.KeyGenerationCapability}" });
            dt.Rows.Add(new string[] { "Available Access Levels", $"{currentDll.AccessLevels.Count}" });

            foreach (Tuple<uint, int, int> accessLevel in currentDll.AccessLevels)
            {
                dt.Rows.Add(new string[] { $"Access Level {accessLevel.Item1} (0x{accessLevel.Item1:X})", $"Key size: {accessLevel.Item2}, Seed size: {accessLevel.Item3}" });
            }

            dt.Rows.Add(new string[] { "Interpreted Seed", $"{BitUtility.BytesToHex(seed, true)}" });
            dt.Rows.Add(new string[] { "Last Generation Time", $"{DateTime.Now.ToLongTimeString()}" });

            foreach (Tuple<uint, int, int> accessLevel in currentDll.AccessLevels)
            {
                if (accessLevel.Item3 == seed.Length)
                {
                    dt.Rows.Add(new string[] { $"Access Key: {accessLevel.Item1} (0x{accessLevel.Item1:X})", $"{currentDll.GenerateKeyAuto(accessLevel.Item1, seed)}" });
                }
                else
                {
                    dt.Rows.Add(new string[] { $"Access Key: {accessLevel.Item1} (0x{accessLevel.Item1:X})", $"Seed size mismatch: {seed.Length} bytes, expecting {accessLevel.Item3} bytes" });
                }
            }

            dgvResponse.DataSource = dt;
            dgvResponse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvResponse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void txtChallenge_TextChanged(object sender, EventArgs e)
        {
            TryRefreshKey();
        }

        public void TryRefreshKey() 
        {
            bool validHex = true;
            string cleanedText = txtChallenge.Text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("-", "").ToUpper();
            if (cleanedText.Length % 2 != 0)
            {
                validHex = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleanedText, @"\A\b[0-9a-fA-F]+\b\Z"))
            {
                validHex = false;
            }

            if (validHex)
            {
                byte[] seed = BitUtility.BytesFromHex(cleanedText);
                txtChallenge.BackColor = System.Drawing.SystemColors.Window;
                ShowDllInfoNew(seed);
            }
            else
            {
                if (cleanedText.Length == 0) 
                {
                    ShowDllInfoNew(new byte[] { });
                }
                txtChallenge.BackColor = System.Drawing.Color.LavenderBlush;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            TryRefreshKey();
        }

        private void selectDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a compatible DLL file";
            ofd.Multiselect = false;
            ofd.InitialDirectory = Program.GetStartupPath();
            ofd.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentDll = new DllContext(ofd.FileName);
                TryRefreshKey();
            }
        }

        private void selectDLLFilteredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibrarySelector selector = new LibrarySelector();
            selector.LoadedDlls = cachedDllMetadata;
            if (selector.ShowDialog() == DialogResult.OK)
            {
                currentDll = new DllContext(selector.SelectedFile);
                TryRefreshKey();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtChallenge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                e.Handled = true;
                TryRefreshKey();
            }
        }

        private void diagnosticsDumpDLLReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This might take a few minutes, depending on the number of files. Continue?", "Diagnostics", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DiagnosticsDumpReport();
            }
        }
    }
}
