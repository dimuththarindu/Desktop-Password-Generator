using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            tbLength.Text = "30";

            // Application Version
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVer.Text = "Password Generator v" + versionInfo.FileVersion;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            WaitTextboxes();            
            FillTextboxesParallelAsync();
        }        

        private async Task FillTextboxesParallelAsync(int length = 30)
        {
            try
            {
                List<Task<string>> tasks = new List<Task<string>>();

                for (int x = 1; x <= 10; x++)
                {
                    await Task.Delay(10);
                    StrongPasswordGenerator passwordGenerator = new StrongPasswordGenerator(length);
                    tasks.Add(Task.Run(() => passwordGenerator.Password));
                }

                tbPw1.Text = await tasks[0];
                tbPw2.Text = await tasks[1];
                tbPw3.Text = await tasks[2];
                tbPw4.Text = await tasks[3];
                tbPw5.Text = await tasks[4];
                tbPw6.Text = await tasks[5];
                tbPw7.Text = await tasks[6];
                tbPw8.Text = await tasks[7];
                tbPw9.Text = await tasks[8];
                tbPw10.Text = await tasks[9];
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong...", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void WaitTextboxes()
        {
            string pw = "Please wait...";

            tbPw1.Text = pw;
            tbPw2.Text = pw;
            tbPw3.Text = pw;
            tbPw4.Text = pw;
            tbPw5.Text = pw;
            tbPw6.Text = pw;
            tbPw7.Text = pw;
            tbPw8.Text = pw;
            tbPw9.Text = pw;
            tbPw10.Text = pw;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            WaitTextboxes();

            int x;
            if (!int.TryParse(tbLength.Text, out x))
            {
                x = 30;
                tbLength.Text = x.ToString();
            }

            FillTextboxesParallelAsync(x);
        }

        private async void ClipboardCopy(TextBox tb, Button tbn)
        {
            tbn.Text = "Copied";
            Clipboard.SetText(tb.Text);
            await Task.Delay(500);
            tbn.Text = "Copy";
        }

        //private void ClipboardCopy(string str)
        //{
        //    Clipboard.SetText(str);
        //}

        private void btnCopy1_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw1, btnCopy1);
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw2, btnCopy2);
        }

        private void btnCopy3_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw3, btnCopy3);
        }

        private void btnCopy4_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw4, btnCopy4);
        }

        private void btnCopy5_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw5, btnCopy5);
        }

        private void btnCopy6_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw6, btnCopy6);
        }

        private void btnCopy7_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw7, btnCopy7);
        }

        private void btnCopy8_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw8, btnCopy8);
        }

        private void btnCopy9_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw9, btnCopy9);
        }

        private void btnCopy10_Click(object sender, EventArgs e)
        {
            ClipboardCopy(tbPw10, btnCopy10);
        }
    }
}
