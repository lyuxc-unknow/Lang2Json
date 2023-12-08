using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace Lang2Json
{
    public partial class Form1 : Form
    {
        public string[] lang;
        string[] temp;
        string temp_text;
        OpenFileDialog dialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dialog.Filter = "Lang File(*.lang)|*.lang";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader input = new StreamReader(dialog.OpenFile());
                    textBox1.Text = input.ReadToEnd();
                }
                catch { }
            }
            progressBar1.Value = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lang = textBox1.Text.Split("\r\n");
            temp_text = "{";
            for (int i = 0; i < lang.Length; i++)
            {
                if ((!lang[i].StartsWith("#") || lang[i].Contains("=")) && lang[i].Length != 0)
                {
                    temp = lang[i].Split("=");
                    temp_text += "\r\n    \"" + temp[0] + "\"" + ": " + "\"" + temp[1] + "\"";
                    if (i != lang.Length - 1) temp_text += ",";
                }
            }
            temp_text += "\r\n}";
            textBox2.Text = temp_text;
            progressBar1.Value = 100;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "*.json|*.json";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                writer.Write(temp_text);
                writer.Close();
            }
        }
    }
}
