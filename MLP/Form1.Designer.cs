namespace MLP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseTB = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.browseB = new System.Windows.Forms.Button();
            this.featuresGB = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.classesGB = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.learningRateTB = new System.Windows.Forms.TextBox();
            this.learningRateLabel = new System.Windows.Forms.Label();
            this.slopeConstantLabel = new System.Windows.Forms.Label();
            this.slopeConstantTB = new System.Windows.Forms.TextBox();
            this.hiddenLayersBT = new System.Windows.Forms.Button();
            this.startTrainingTB = new System.Windows.Forms.Button();
            this.epochsLB = new System.Windows.Forms.Label();
            this.epochsTB = new System.Windows.Forms.TextBox();
            this.missMatchLB = new System.Windows.Forms.Label();
            this.matchingLB = new System.Windows.Forms.Label();
            this.x1TB = new System.Windows.Forms.TextBox();
            this.x4TB = new System.Windows.Forms.TextBox();
            this.x3TB = new System.Windows.Forms.TextBox();
            this.x2TB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.classifyBT = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.errorThresholdTB = new System.Windows.Forms.TextBox();
            this.dataSetGB = new System.Windows.Forms.GroupBox();
            this.imageDataRB = new System.Windows.Forms.RadioButton();
            this.irisDataRB = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pcachoiceGP = new System.Windows.Forms.GroupBox();
            this.pcachoice2RB = new System.Windows.Forms.RadioButton();
            this.pcachoice1RB = new System.Windows.Forms.RadioButton();
            this.pcomponentsLB = new System.Windows.Forms.Label();
            this.pcomponentsTB = new System.Windows.Forms.TextBox();
            this.learningRatePCALB = new System.Windows.Forms.Label();
            this.learningRatePCATB = new System.Windows.Forms.TextBox();
            this.featuresGB.SuspendLayout();
            this.classesGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dataSetGB.SuspendLayout();
            this.pcachoiceGP.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseTB
            // 
            this.browseTB.Location = new System.Drawing.Point(87, 12);
            this.browseTB.Name = "browseTB";
            this.browseTB.Size = new System.Drawing.Size(340, 20);
            this.browseTB.TabIndex = 0;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(12, 12);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(67, 18);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "File path:";
            // 
            // browseB
            // 
            this.browseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseB.Location = new System.Drawing.Point(433, 6);
            this.browseB.Name = "browseB";
            this.browseB.Size = new System.Drawing.Size(85, 30);
            this.browseB.TabIndex = 2;
            this.browseB.Text = "Browse";
            this.browseB.UseVisualStyleBackColor = true;
            this.browseB.Click += new System.EventHandler(this.button1_Click);
            // 
            // featuresGB
            // 
            this.featuresGB.Controls.Add(this.label4);
            this.featuresGB.Controls.Add(this.label3);
            this.featuresGB.Controls.Add(this.label2);
            this.featuresGB.Controls.Add(this.label1);
            this.featuresGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featuresGB.Location = new System.Drawing.Point(730, 12);
            this.featuresGB.Name = "featuresGB";
            this.featuresGB.Size = new System.Drawing.Size(110, 100);
            this.featuresGB.TabIndex = 0;
            this.featuresGB.TabStop = false;
            this.featuresGB.Text = "Features:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "X4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "X3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "X2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "X1";
            // 
            // classesGB
            // 
            this.classesGB.AutoSize = true;
            this.classesGB.Controls.Add(this.label14);
            this.classesGB.Controls.Add(this.label13);
            this.classesGB.Controls.Add(this.label7);
            this.classesGB.Controls.Add(this.label6);
            this.classesGB.Controls.Add(this.label5);
            this.classesGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classesGB.Location = new System.Drawing.Point(730, 115);
            this.classesGB.Name = "classesGB";
            this.classesGB.Size = new System.Drawing.Size(110, 130);
            this.classesGB.TabIndex = 5;
            this.classesGB.TabStop = false;
            this.classesGB.Text = "Classes:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 18);
            this.label14.TabIndex = 15;
            this.label14.Text = "Virginica";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 18);
            this.label13.TabIndex = 14;
            this.label13.Text = "Virginica";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Virginica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Versicolor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Setosa";
            // 
            // learningRateTB
            // 
            this.learningRateTB.Location = new System.Drawing.Point(810, 261);
            this.learningRateTB.Name = "learningRateTB";
            this.learningRateTB.Size = new System.Drawing.Size(31, 20);
            this.learningRateTB.TabIndex = 6;
            // 
            // learningRateLabel
            // 
            this.learningRateLabel.AutoSize = true;
            this.learningRateLabel.Location = new System.Drawing.Point(727, 264);
            this.learningRateLabel.Name = "learningRateLabel";
            this.learningRateLabel.Size = new System.Drawing.Size(77, 13);
            this.learningRateLabel.TabIndex = 7;
            this.learningRateLabel.Text = "Learning Rate:";
            // 
            // slopeConstantLabel
            // 
            this.slopeConstantLabel.AutoSize = true;
            this.slopeConstantLabel.Location = new System.Drawing.Point(726, 290);
            this.slopeConstantLabel.Name = "slopeConstantLabel";
            this.slopeConstantLabel.Size = new System.Drawing.Size(82, 13);
            this.slopeConstantLabel.TabIndex = 9;
            this.slopeConstantLabel.Text = "Slope Constant:";
            // 
            // slopeConstantTB
            // 
            this.slopeConstantTB.Location = new System.Drawing.Point(809, 287);
            this.slopeConstantTB.Name = "slopeConstantTB";
            this.slopeConstantTB.Size = new System.Drawing.Size(31, 20);
            this.slopeConstantTB.TabIndex = 8;
            // 
            // hiddenLayersBT
            // 
            this.hiddenLayersBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenLayersBT.Location = new System.Drawing.Point(699, 346);
            this.hiddenLayersBT.Name = "hiddenLayersBT";
            this.hiddenLayersBT.Size = new System.Drawing.Size(133, 52);
            this.hiddenLayersBT.TabIndex = 10;
            this.hiddenLayersBT.Text = "Hidden Layers";
            this.hiddenLayersBT.UseVisualStyleBackColor = true;
            this.hiddenLayersBT.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // startTrainingTB
            // 
            this.startTrainingTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTrainingTB.Location = new System.Drawing.Point(604, 404);
            this.startTrainingTB.Name = "startTrainingTB";
            this.startTrainingTB.Size = new System.Drawing.Size(236, 52);
            this.startTrainingTB.TabIndex = 11;
            this.startTrainingTB.Text = "Start Training";
            this.startTrainingTB.UseVisualStyleBackColor = true;
            this.startTrainingTB.Click += new System.EventHandler(this.startTrainingTB_Click);
            // 
            // epochsLB
            // 
            this.epochsLB.AutoSize = true;
            this.epochsLB.Location = new System.Drawing.Point(4, 86);
            this.epochsLB.Name = "epochsLB";
            this.epochsLB.Size = new System.Drawing.Size(63, 18);
            this.epochsLB.TabIndex = 13;
            this.epochsLB.Text = "Epochs:";
            // 
            // epochsTB
            // 
            this.epochsTB.Location = new System.Drawing.Point(122, 83);
            this.epochsTB.Name = "epochsTB";
            this.epochsTB.Size = new System.Drawing.Size(47, 24);
            this.epochsTB.TabIndex = 12;
            // 
            // missMatchLB
            // 
            this.missMatchLB.AutoSize = true;
            this.missMatchLB.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missMatchLB.Location = new System.Drawing.Point(12, 76);
            this.missMatchLB.Name = "missMatchLB";
            this.missMatchLB.Size = new System.Drawing.Size(318, 31);
            this.missMatchLB.TabIndex = 14;
            this.missMatchLB.Text = "Number of mismatches: ";
            // 
            // matchingLB
            // 
            this.matchingLB.AutoSize = true;
            this.matchingLB.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchingLB.Location = new System.Drawing.Point(12, 115);
            this.matchingLB.Name = "matchingLB";
            this.matchingLB.Size = new System.Drawing.Size(291, 31);
            this.matchingLB.TabIndex = 15;
            this.matchingLB.Text = "Number of matching: ";
            // 
            // x1TB
            // 
            this.x1TB.Location = new System.Drawing.Point(81, 21);
            this.x1TB.Name = "x1TB";
            this.x1TB.Size = new System.Drawing.Size(100, 24);
            this.x1TB.TabIndex = 16;
            // 
            // x4TB
            // 
            this.x4TB.Location = new System.Drawing.Point(81, 106);
            this.x4TB.Name = "x4TB";
            this.x4TB.Size = new System.Drawing.Size(100, 24);
            this.x4TB.TabIndex = 17;
            // 
            // x3TB
            // 
            this.x3TB.Location = new System.Drawing.Point(81, 78);
            this.x3TB.Name = "x3TB";
            this.x3TB.Size = new System.Drawing.Size(100, 24);
            this.x3TB.TabIndex = 18;
            // 
            // x2TB
            // 
            this.x2TB.Location = new System.Drawing.Point(81, 51);
            this.x2TB.Name = "x2TB";
            this.x2TB.Size = new System.Drawing.Size(100, 24);
            this.x2TB.TabIndex = 19;
            this.x2TB.TextChanged += new System.EventHandler(this.x2TB_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.classifyBT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.x2TB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.x3TB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.x4TB);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.x1TB);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 213);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features:";
            // 
            // classifyBT
            // 
            this.classifyBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classifyBT.Location = new System.Drawing.Point(362, 142);
            this.classifyBT.Name = "classifyBT";
            this.classifyBT.Size = new System.Drawing.Size(116, 51);
            this.classifyBT.TabIndex = 20;
            this.classifyBT.Text = "Classify";
            this.classifyBT.UseVisualStyleBackColor = true;
            this.classifyBT.Click += new System.EventHandler(this.classifyBT_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "X4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "X3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "X2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "X1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(727, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Error Threshold:";
            // 
            // errorThresholdTB
            // 
            this.errorThresholdTB.Location = new System.Drawing.Point(810, 313);
            this.errorThresholdTB.Name = "errorThresholdTB";
            this.errorThresholdTB.Size = new System.Drawing.Size(31, 20);
            this.errorThresholdTB.TabIndex = 21;
            // 
            // dataSetGB
            // 
            this.dataSetGB.Controls.Add(this.imageDataRB);
            this.dataSetGB.Controls.Add(this.irisDataRB);
            this.dataSetGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSetGB.Location = new System.Drawing.Point(525, 12);
            this.dataSetGB.Name = "dataSetGB";
            this.dataSetGB.Size = new System.Drawing.Size(200, 77);
            this.dataSetGB.TabIndex = 23;
            this.dataSetGB.TabStop = false;
            this.dataSetGB.Text = "Choose Dataset:";
            // 
            // imageDataRB
            // 
            this.imageDataRB.AutoSize = true;
            this.imageDataRB.Location = new System.Drawing.Point(7, 49);
            this.imageDataRB.Name = "imageDataRB";
            this.imageDataRB.Size = new System.Drawing.Size(101, 22);
            this.imageDataRB.TabIndex = 1;
            this.imageDataRB.TabStop = true;
            this.imageDataRB.Text = "Image Data";
            this.imageDataRB.UseVisualStyleBackColor = true;
            this.imageDataRB.CheckedChanged += new System.EventHandler(this.imageDataRB_CheckedChanged);
            // 
            // irisDataRB
            // 
            this.irisDataRB.AutoSize = true;
            this.irisDataRB.Location = new System.Drawing.Point(7, 24);
            this.irisDataRB.Name = "irisDataRB";
            this.irisDataRB.Size = new System.Drawing.Size(80, 22);
            this.irisDataRB.TabIndex = 0;
            this.irisDataRB.TabStop = true;
            this.irisDataRB.Text = "Iris Data";
            this.irisDataRB.UseVisualStyleBackColor = true;
            this.irisDataRB.CheckedChanged += new System.EventHandler(this.irisDataRB_CheckedChanged);
            // 
            // pcachoiceGP
            // 
            this.pcachoiceGP.Controls.Add(this.learningRatePCALB);
            this.pcachoiceGP.Controls.Add(this.learningRatePCATB);
            this.pcachoiceGP.Controls.Add(this.pcomponentsLB);
            this.pcachoiceGP.Controls.Add(this.pcomponentsTB);
            this.pcachoiceGP.Controls.Add(this.pcachoice2RB);
            this.pcachoiceGP.Controls.Add(this.pcachoice1RB);
            this.pcachoiceGP.Controls.Add(this.epochsLB);
            this.pcachoiceGP.Controls.Add(this.epochsTB);
            this.pcachoiceGP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcachoiceGP.Location = new System.Drawing.Point(525, 89);
            this.pcachoiceGP.Name = "pcachoiceGP";
            this.pcachoiceGP.Size = new System.Drawing.Size(200, 192);
            this.pcachoiceGP.TabIndex = 24;
            this.pcachoiceGP.TabStop = false;
            this.pcachoiceGP.Text = "Training Method:";
            // 
            // pcachoice2RB
            // 
            this.pcachoice2RB.AutoSize = true;
            this.pcachoice2RB.Location = new System.Drawing.Point(7, 49);
            this.pcachoice2RB.Name = "pcachoice2RB";
            this.pcachoice2RB.Size = new System.Drawing.Size(111, 22);
            this.pcachoice2RB.TabIndex = 1;
            this.pcachoice2RB.TabStop = true;
            this.pcachoice2RB.Text = "Without PCA";
            this.pcachoice2RB.UseVisualStyleBackColor = true;
            this.pcachoice2RB.CheckedChanged += new System.EventHandler(this.pcachoice2RB_CheckedChanged);
            // 
            // pcachoice1RB
            // 
            this.pcachoice1RB.AutoSize = true;
            this.pcachoice1RB.Location = new System.Drawing.Point(7, 24);
            this.pcachoice1RB.Name = "pcachoice1RB";
            this.pcachoice1RB.Size = new System.Drawing.Size(90, 22);
            this.pcachoice1RB.TabIndex = 0;
            this.pcachoice1RB.TabStop = true;
            this.pcachoice1RB.Text = "With PCA";
            this.pcachoice1RB.UseVisualStyleBackColor = true;
            this.pcachoice1RB.CheckedChanged += new System.EventHandler(this.pcachoice1RB_CheckedChanged);
            // 
            // pcomponentsLB
            // 
            this.pcomponentsLB.AutoSize = true;
            this.pcomponentsLB.Location = new System.Drawing.Point(4, 118);
            this.pcomponentsLB.Name = "pcomponentsLB";
            this.pcomponentsLB.Size = new System.Drawing.Size(112, 18);
            this.pcomponentsLB.TabIndex = 15;
            this.pcomponentsLB.Text = "P.Components:";
            // 
            // pcomponentsTB
            // 
            this.pcomponentsTB.Location = new System.Drawing.Point(122, 115);
            this.pcomponentsTB.Name = "pcomponentsTB";
            this.pcomponentsTB.Size = new System.Drawing.Size(47, 24);
            this.pcomponentsTB.TabIndex = 14;
            // 
            // learningRatePCALB
            // 
            this.learningRatePCALB.AutoSize = true;
            this.learningRatePCALB.Location = new System.Drawing.Point(4, 151);
            this.learningRatePCALB.Name = "learningRatePCALB";
            this.learningRatePCALB.Size = new System.Drawing.Size(103, 18);
            this.learningRatePCALB.TabIndex = 26;
            this.learningRatePCALB.Text = "Learning Rate:";
            // 
            // learningRatePCATB
            // 
            this.learningRatePCATB.Location = new System.Drawing.Point(138, 148);
            this.learningRatePCATB.Name = "learningRatePCATB";
            this.learningRatePCATB.Size = new System.Drawing.Size(31, 24);
            this.learningRatePCATB.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 460);
            this.Controls.Add(this.pcachoiceGP);
            this.Controls.Add(this.dataSetGB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.errorThresholdTB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.matchingLB);
            this.Controls.Add(this.missMatchLB);
            this.Controls.Add(this.startTrainingTB);
            this.Controls.Add(this.hiddenLayersBT);
            this.Controls.Add(this.slopeConstantLabel);
            this.Controls.Add(this.slopeConstantTB);
            this.Controls.Add(this.learningRateLabel);
            this.Controls.Add(this.learningRateTB);
            this.Controls.Add(this.classesGB);
            this.Controls.Add(this.featuresGB);
            this.Controls.Add(this.browseB);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.browseTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.Form1_TextChanged);
            this.featuresGB.ResumeLayout(false);
            this.featuresGB.PerformLayout();
            this.classesGB.ResumeLayout(false);
            this.classesGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dataSetGB.ResumeLayout(false);
            this.dataSetGB.PerformLayout();
            this.pcachoiceGP.ResumeLayout(false);
            this.pcachoiceGP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox browseTB;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Button browseB;
        private System.Windows.Forms.GroupBox featuresGB;
        private System.Windows.Forms.GroupBox classesGB;
        private System.Windows.Forms.TextBox learningRateTB;
        private System.Windows.Forms.Label learningRateLabel;
        private System.Windows.Forms.Label slopeConstantLabel;
        private System.Windows.Forms.TextBox slopeConstantTB;
        private System.Windows.Forms.Button hiddenLayersBT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button startTrainingTB;
        private System.Windows.Forms.Label epochsLB;
        private System.Windows.Forms.TextBox epochsTB;
        private System.Windows.Forms.Label missMatchLB;
        private System.Windows.Forms.Label matchingLB;
        private System.Windows.Forms.TextBox x1TB;
        private System.Windows.Forms.TextBox x4TB;
        private System.Windows.Forms.TextBox x3TB;
        private System.Windows.Forms.TextBox x2TB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button classifyBT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox errorThresholdTB;
        private System.Windows.Forms.GroupBox dataSetGB;
        private System.Windows.Forms.RadioButton imageDataRB;
        private System.Windows.Forms.RadioButton irisDataRB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox pcachoiceGP;
        private System.Windows.Forms.RadioButton pcachoice2RB;
        private System.Windows.Forms.RadioButton pcachoice1RB;
        private System.Windows.Forms.Label pcomponentsLB;
        private System.Windows.Forms.TextBox pcomponentsTB;
        private System.Windows.Forms.Label learningRatePCALB;
        private System.Windows.Forms.TextBox learningRatePCATB;
    }
}

