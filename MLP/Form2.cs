using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLP
{
    public partial class Form2 : Form
    {
        bool formClosed;
        int numOfLayers = 0;
        List<int> neuronsPerLayer = new List<int>();
        List<int> temp = new List<int>();
        public Form2()
        {
            InitializeComponent();
            formClosed = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            numOfLayers = Convert.ToInt32(textBox1.Text);
            dataGridView1.RowCount = numOfLayers;
            dataGridView1.ColumnCount = 1;

        }
        public int GetNumOfLayers()
        {
            return numOfLayers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formClosed = true;
            neuronsPerLayer.Clear();
            for (int i = 0; i < GetNumOfLayers(); i++)
            {
                neuronsPerLayer.Add(Convert.ToInt32(dataGridView1[0, i].Value));
            }
            temp = new List<int>(neuronsPerLayer);
                this.Hide();
        }
        public bool isClosed()
        {
            return formClosed;
        }
        public List<int> GetNeuronsPerLayer()
        {
            return temp;
        }
    }
}
