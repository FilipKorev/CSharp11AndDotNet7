using Newtonsoft.Json;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.CheckFileExists)
            {
                string jsonText = File.ReadAllText(this.openFileDialog1.FileName);
                List<Person>? people = JsonConvert.DeserializeObject<List<Person>>(jsonText);

            }
        }
    }
}