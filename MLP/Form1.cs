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
    public partial class Form1 : Form
    {
        Form2 layers;
        private MLPMain myMLP;
        bool irisMode;
        bool imageMode;
        bool pcamode;
        public Form1()
        {
            InitializeComponent();
            myMLP = new MLPMain();
            layers = new Form2();
            irisDataRB.Checked = false;
            irisMode = true;
            imageDataRB.Checked = true;
            imageMode = false;
            pcamode = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f1 = new OpenFileDialog();
            f1.Multiselect = true;
            if (irisMode == true)
                f1.Title = "Select Iris data file";
            else
                f1.Title = "Select Image dataset folder";
            f1.RestoreDirectory = true;
            if (f1.ShowDialog() == DialogResult.OK)
            {
                browseTB.Text = f1.FileName;
                if (irisMode)
                    myMLP.ReadIrisData(f1.FileName);
                else
                    myMLP.ReadImageData(f1.FileNames);

            }
            myMLP.NormalizeFeatures();

           // int numLayers = layers.GetNumOfLayers();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach (RadioButton r in dataSetGB.Controls)
            //{
            //    if (r.Checked)
            //    {
            //        if (r.Name == "irisDataRB")
            //        {
            //            irisMode = true;
            //            imageMode = false;
            //            label13.Hide();
            //            label14.Hide();
            //        }
            //        else if (r.Name == "imageDataRB")
            //        {
            //            irisMode = false;
            //            imageMode = true;
            //            foreach (Control c in featuresGB.Controls)
            //            {
            //                if (c.Name == "label1")
            //                {
            //                    c.Text = "Pixel 1";
            //                }
            //                else if (c.Name == "label2")
            //                {
            //                    c.Text = ".";
            //                }
            //                else if (c.Name == "label3")
            //                {
            //                    c.Text = ".";
            //                }
            //                else
            //                    c.Text = "Pixel 900";
                            
            //            }
            //            foreach (Control c in classesGB.Controls)
            //            {
            //                if (c.Name == "label5")
            //                {
            //                    c.Text = "Smiling";
            //                }
            //                else if (c.Name == "label6")
            //                {
            //                    c.Text = "Sad"; 
            //                }
            //                else if (c.Name == "label7")
            //                {
            //                    c.Text = "Disgusted";
            //                }
            //                else if (c.Name == "label13")
            //                {
            //                    c.Text = "Surprised";
            //                }
            //                else
            //                {
            //                    c.Text = "Scared";
            //                }
                            
            //            }
            //            //featuresGB.Controls[0].Text = "Pixel 1";
            //            //featuresGB.Controls[1].Text = ".";
            //            //featuresGB.Controls[2].Text = ".";
            //            //featuresGB.Controls[3].Text = "Pixel 4";
            //            //classesGB.Controls[0].Text = "Smiling";
            //            //classesGB.Controls[1].Text = "Sad";
            //            //classesGB.Controls[2].Text = "Disgusted";
                        

            //        }
            //    }
            //}

        }

        private void button1_Click_1(object sender, EventArgs e)  
        {
           
            layers.Show();
           
               
        }

        private void startTrainingTB_Click(object sender, EventArgs e)
        {
            if (layers.isClosed())
            {
               
                    myMLP.SetLearningRate(Convert.ToDouble(learningRateTB.Text));
                    myMLP.SetSlopeConstant(Convert.ToDouble(slopeConstantTB.Text));
                    myMLP.SetErrorThreshold(Convert.ToDouble(errorThresholdTB.Text));
                    int numOfLayers = layers.GetNumOfLayers();
                    myMLP.SetNodesPerLayer(layers.GetNeuronsPerLayer());
                    myMLP.InitializeLayers(Convert.ToDouble(slopeConstantTB.Text));
                    if (pcamode)
                    {
                        myMLP.SetNumberOfEpochs(Convert.ToInt32(epochsTB.Text));
                        myMLP.SetPrinicpalComponents(Convert.ToInt32(pcomponentsTB.Text));
                        myMLP.SetLearningRatePCA(Convert.ToDouble(learningRatePCATB.Text));
                        myMLP.PCA();
                    }
                    if (irisMode)
                    {
                        myMLP.StartTraining();
                        myMLP.Testing();

                    }
                    else
                    {
                        myMLP.StartImageTraining();
                        myMLP.TestingImage();
                    }
                    missMatchLB.Text = "Number of mismatches: " + myMLP.GetNumberOfMismatch().ToString();
                    matchingLB.Text = "Number of matching: " + myMLP.GetNumberOfMatching().ToString();
                

            }
            else
            {
                
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void classifyBT_Click(object sender, EventArgs e)
        {
            List<double> newI = new List<double>();
            newI.Add(Convert.ToDouble(x1TB.Text));
            newI.Add(Convert.ToDouble(x2TB.Text));
            newI.Add(Convert.ToDouble(x3TB.Text));
            newI.Add(Convert.ToDouble(x4TB.Text));
            string result = myMLP.SampleTest(newI);
            MessageBox.Show(result);

        }

        private void x2TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void irisDataRB_CheckedChanged(object sender, EventArgs e)
        {
            if (irisDataRB.Checked)
            {
                irisMode = true;
                imageMode = false;
                label1.Text = "X1";
                label2.Text = "X2";
                label3.Text = "X3";
                label4.Text = "X4";
                label5.Text = "Setosa";
                label6.Text = "Versicolor";
                label7.Text = "Virginica";
                label13.Hide();
                label14.Hide();
                groupBox1.Show();
            }

        }

        private void imageDataRB_CheckedChanged(object sender, EventArgs e)
        {
            if (imageDataRB.Checked)
            {
                irisMode = false;
                imageMode = true;
                foreach (Control c in featuresGB.Controls)
                {
                    if (c.Name == "label1")
                    {
                        c.Text = "Pixel 1";
                    }
                    else if (c.Name == "label2")
                    {
                        c.Text = ".";
                    }
                    else if (c.Name == "label3")
                    {
                        c.Text = ".";
                    }
                    else
                        c.Text = "Pixel 900";

                }
                foreach (Control c in classesGB.Controls)
                {
                    if (c.Name == "label5")
                    {
                        c.Text = "Smiling";
                    }
                    else if (c.Name == "label6")
                    {
                        c.Text = "Sad";
                    }
                    else if (c.Name == "label7")
                    {
                        c.Text = "Disgusted";
                    }
                    else if (c.Name == "label13")
                    {
                        c.Text = "Surprised";
                    }
                    else
                    {
                        c.Text = "Scared";
                    }

                }
                label13.Show();
                label14.Show();
                groupBox1.Hide();
            }
        }

        private void pcachoice1RB_CheckedChanged(object sender, EventArgs e)
        {
            if (pcachoice1RB.Checked)
            {
                pcamode = true;
                epochsLB.Show();
                epochsTB.Show();
                learningRatePCALB.Show();
                learningRatePCATB.Show();
                pcomponentsLB.Show();
                pcomponentsTB.Show();
            }
        }

        private void pcachoice2RB_CheckedChanged(object sender, EventArgs e)
        {
            if (pcachoice2RB.Checked)
            {
                pcamode = false;
                epochsLB.Hide();
                epochsTB.Hide();
                learningRatePCALB.Hide();
                learningRatePCATB.Hide();
                pcomponentsLB.Hide();
                pcomponentsTB.Hide();
            }
        }
    }
}
