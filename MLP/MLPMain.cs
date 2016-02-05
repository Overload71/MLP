using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class MLPMain
    {
      
        //Member Variables
        private Pre_Processing preprocessing = new Pre_Processing();
        private InputReader reader = new InputReader();
        private List<List<double>> list_of_features = new List<List<double>>();
        private List<List<Neuron>> hiddenlayers = new List<List<Neuron>>();
        private List<OutputNeuron> outputlayer = new List<OutputNeuron>();
        private List<OutputNeuron> outputlayer_PCA = new List<OutputNeuron>();
        private List<int> nodesPerLayer = new List<int>();
        private double learningRate;
        private double learningRatePCA;
        private double slopeConstant;
        private int numberOfEpochs;
        private int numberOfMismatch=0;
        private int numberOfMatching = 0;
        private double totalError = 0;
        private double theBigTotalError = 0;
        private double errorThreshold;
        private bool InitNode = true;
        private int principalComponents = 0;
        //Member Functions
        public void ReadIrisData(string filePath)
        {
           this.list_of_features = reader.ReadIrisData(filePath);
        }
        public void ReadImageData(string[] filepaths)
        {
            this.list_of_features = reader.ReadImageData(filepaths);
        }
        public void NormalizeFeatures()
        {
            List<double> L = new List<double>();
            for (int i = 0; i < list_of_features[0].Count; i++)
            {
                for (int j = 0; j < list_of_features.Count; j++)
                {
                    L.Add(list_of_features[j][i]);
                }
                L = preprocessing.Normalize(L);
                for (int j = 0; j < list_of_features.Count; j++)
                {
                    list_of_features[j][i] = L[j];
                }
                L.Clear();
            }
        }
        public void SetLearningRate(double l)
        {
            this.learningRate = l;
        }
        public void SetLearningRatePCA(double l)
        {
            learningRatePCA = l;
        }
        public void SetSlopeConstant(double s)
        {
            this.slopeConstant = s;
        }
        public void SetErrorThreshold(double e)
        {
            errorThreshold = e;
        }
        public void SetNodesPerLayer(List<int> N)
        {
            this.nodesPerLayer =new List<int>( N);
        }
        public void SetPrinicpalComponents(int n)
        {
            principalComponents = n;
        }
        public int GetPrinicpalComponents()
        {
            return principalComponents;
        }
        private void InitializeFirstLayer()
        {
            //Put first sample into the nodes of the first layer (X1,X2,X3,X4 into 1st Layer Nodes)
            for (int i = 0; i < nodesPerLayer[0]; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < list_of_features.Count; j++)
                {
                    temp.Add(list_of_features[j][0]);
                }
                Neuron t = new Neuron();
                t.setInputs(temp);
                hiddenlayers[0].Add(t);
                
            }

            //Initialize weights of the nodes of the first layer to 0
            List<double> tempWeights = new List<double>();
            for (int i = 0; i < list_of_features.Count; i++)
            {
                tempWeights.Add(0);
            }
            for (int i = 0; i < nodesPerLayer[0]; i++)
            {
                hiddenlayers[0][i].setWeights(tempWeights);
            }
           
        }
        public void InitializeLayers(double s)
        {

            for (int i = 0; i < nodesPerLayer.Count; i++)
            {
                hiddenlayers.Add(new List<Neuron>());
            }
            for (int i = 0; i < hiddenlayers.Count; i++)
            {
                for (int j = 0; j < nodesPerLayer[i]; j++)
                {
                    hiddenlayers[i].Add(new Neuron());
                }
            }
            // InitializeFirstLayer();

            //Output Neurons layer.
            if (list_of_features[0].Count == 900)
            {
                for (int i = 0; i < 5; i++)
                {
                    outputlayer.Add(new OutputNeuron());
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    outputlayer.Add(new OutputNeuron());
                }
            }
           

            for (int i = 0; i < hiddenlayers.Count; i++)
            {
                for (int j = 0; j < hiddenlayers[i].Count; j++)
                {
                    hiddenlayers[i][j].SetSlopeConstant(s);
                }
            }
            for (int i = 0; i < outputlayer.Count; i++)
            {
                outputlayer[i].SetSlopeConstant(s);
            }

        }
        public void StartTraining()
        {
            while(true)
            {
                //Feed Forward
                // List<double> temp = new List<double>();
                for (int k = 0; k < list_of_features.Count; k++)
                {

                    if (k >= 0 && k <= 49)
                    {
                        outputlayer[0].SetDesired(1);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(0);
                    }
                    else if (k >= 50 && k <= 99)
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(1);
                        outputlayer[2].SetDesired(0);
                    }
                    else
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(1);
                    }
                    if (k == 35 || k == 85 || k == 135)
                    {
                        k += 15;
                    }
                    else if (k == 0 && InitNode==true)
                    {
                        InitNode = false;
                        List<double> temp = new List<double>();

                        for (int i = 0; i < hiddenlayers[0].Count; i++)
                        {
                            hiddenlayers[0][i].InitNode(list_of_features[k]);
                            hiddenlayers[0][i].Start();
                        }
                        for (int j = 1; j < hiddenlayers.Count; j++)
                        {
                            for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                            {
                                temp.Add(hiddenlayers[j - 1][l].GetOutput());
                            }
                            for (int l = 0; l < hiddenlayers[j].Count; l++)
                            {
                                hiddenlayers[j][l].InitNode(temp);
                                hiddenlayers[j][l].Start();
                            }
                            temp.Clear();
                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                            }
                            outputlayer[i].InitNode(temp);
                            outputlayer[i].Start();
                            temp.Clear();
                        }
                        //Back Propagation--------------------------------------------------------------------------

                        //Output layer SiGMA
                        for (int a = 0; a < outputlayer.Count; a++)
                        {
                            outputlayer[a].CalculateNewSiGMA();
                        }
                        //Last hidden layer SiGMA
                        double newSiGMA, oldSiGMA;
                        List<double> L = new List<double>();
                        newSiGMA = 0;
                        for (int a = 0; a < hiddenlayers[hiddenlayers.Count - 1].Count; a++)
                        {
                            for (int b = 0; b < outputlayer.Count; b++)
                            {
                                oldSiGMA = outputlayer[b].GetSiGMA();
                                L = new List<double>(outputlayer[b].GetWeights());
                                newSiGMA += oldSiGMA * L[a];
                            }
                            hiddenlayers[hiddenlayers.Count - 1][a].SetSiGMA(newSiGMA * hiddenlayers[hiddenlayers.Count - 1][a].DerivativeActivation(hiddenlayers[hiddenlayers.Count - 1][a].GetOutput()));
                            newSiGMA = 0;

                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //Rest of the hidden layers
                        for (int i = hiddenlayers.Count - 1; i > 0; i--) //Looping over the layers.
                        {
                            for (int j = 0; j < hiddenlayers[i - 1].Count; j++) //Looping over each node in the previous layer
                            {
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    oldSiGMA = hiddenlayers[i][l].GetSiGMA();
                                    L = new List<double>(hiddenlayers[i][l].GetWeights());
                                    newSiGMA += oldSiGMA * L[j + 1];
                                }
                                hiddenlayers[i - 1][j].SetSiGMA((newSiGMA * hiddenlayers[i - 1][j].DerivativeActivation(hiddenlayers[i - 1][j].GetOutput())));
                                newSiGMA = 0;
                            }

                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //----------------------------------------------------------------------------------------------
                        //Updating the weights
                        for (int i = 0; i < hiddenlayers.Count; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < hiddenlayers[i].Count; j++)
                                {
                                    hiddenlayers[i][j].UpdateWeights(learningRate);
                                }
                            }
                            else
                            {
                                List<double> fs = new List<double>();
                                for (int j = 0; j < hiddenlayers[i-1].Count; j++)
                                {
                                    fs.Add(hiddenlayers[i-1][j].GetOutput());
                                }
                                fs.Insert(0, 1.0);
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    hiddenlayers[i][l].UpdateWeights(learningRate, fs);
                                }
                                fs.Clear();
                            }
                        }
                        List<double> outputlayer_f = new List<double>();
                        for (int i = 0; i < outputlayer.Count; i++) //Updating weights of the output layer
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                outputlayer_f.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());
                            }
                            outputlayer_f.Insert(0, 1.0);
                            outputlayer[i].UpdateWeights(learningRate, outputlayer_f);
                            outputlayer_f.Clear();
                         }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            outputlayer[i].CalculateError();
                            totalError += Math.Pow(outputlayer[i].GetError(), 2);
                        }
                        totalError /= 2;
                    }
                    else
                    {
                        List<double> temp = new List<double>();
                        for (int i = 0; i < hiddenlayers[0].Count; i++)
                        {
                            hiddenlayers[0][i].setInputs(list_of_features[k]);
                            hiddenlayers[0][i].Start();
                        }
                        for (int j = 1; j < hiddenlayers.Count; j++)
                        {
                            for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                            {
                                temp.Add(hiddenlayers[j - 1][l].GetOutput());
                            }
                            for (int l = 0; l < hiddenlayers[j].Count; l++)
                            {
                                hiddenlayers[j][l].setInputs(temp);
                                hiddenlayers[j][l].Start();
                            }
                            temp.Clear();

                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                            }
                            outputlayer[i].setInputs(temp);
                            outputlayer[i].Start();
                            temp.Clear();
                        }
                        //Back Propagation--------------------------------------------------------------------------

                        //Output layer SiGMA
                        for (int a = 0; a < outputlayer.Count; a++)
                        {
                            outputlayer[a].CalculateNewSiGMA();
                        }
                        //Last hidden layer SiGMA
                        double newSiGMA, oldSiGMA;
                        List<double> L = new List<double>();
                        newSiGMA = 0;
                        for (int a = 0; a < hiddenlayers[hiddenlayers.Count - 1].Count; a++)
                        {
                            for (int b = 0; b < outputlayer.Count; b++)
                            {
                                oldSiGMA = outputlayer[b].GetSiGMA();
                                L = new List<double>(outputlayer[b].GetWeights());
                                newSiGMA += oldSiGMA * L[a];
                            }
                            hiddenlayers[hiddenlayers.Count - 1][a].SetSiGMA(newSiGMA * hiddenlayers[hiddenlayers.Count - 1][a].DerivativeActivation(hiddenlayers[hiddenlayers.Count - 1][a].GetOutput()));
                            newSiGMA = 0;
                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //Rest of the hidden layers
                        for (int i = hiddenlayers.Count - 1; i > 0; i--) //Looping over the layers.
                        {
                            for (int j = 0; j < hiddenlayers[i - 1].Count; j++) //Looping over each node in the previous layer
                            {
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    oldSiGMA = hiddenlayers[i][l].GetSiGMA();
                                    L = new List<double>(hiddenlayers[i][l].GetWeights());
                                    newSiGMA += oldSiGMA * L[j + 1];
                                }
                                hiddenlayers[i - 1][j].SetSiGMA((newSiGMA * hiddenlayers[i - 1][j].DerivativeActivation(hiddenlayers[i - 1][j].GetOutput())));
                                newSiGMA = 0;
                            }
                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //----------------------------------------------------------------------------------------------
                        //Updating the weights
                        for (int i = 0; i < hiddenlayers.Count; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < hiddenlayers[i].Count; j++)
                                {
                                    hiddenlayers[i][j].UpdateWeights(learningRate);
                                }
                            }
                            else
                            {
                                List<double> fs = new List<double>();
                                for (int j = 0; j < hiddenlayers[i - 1].Count; j++)
                                {
                                    fs.Add(hiddenlayers[i - 1][j].GetOutput());
                                }
                                fs.Insert(0, 1.0);
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    hiddenlayers[i][l].UpdateWeights(learningRate, fs);
                                }
                                fs.Clear();
                            }
                        }
                        List<double> outputlayer_f = new List<double>();
                        for (int i = 0; i < outputlayer.Count; i++) //Updating weights of the output layer
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                outputlayer_f.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());
                            }
                            outputlayer_f.Insert(0, 1.0);

                            outputlayer[i].UpdateWeights(learningRate, outputlayer_f);
                            outputlayer_f.Clear();
                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            outputlayer[i].CalculateError();
                            totalError += Math.Pow(outputlayer[i].GetError(),2);
                        }
                        totalError /= 2;                        
                    }
                }
                theBigTotalError += totalError;
                theBigTotalError /=  105.0d;
                if (Convert.ToSingle(theBigTotalError) < errorThreshold)
                {
                    Console.WriteLine("After Training: " + Convert.ToSingle(theBigTotalError));
                    theBigTotalError = 0;
                    InitNode = true;
                    break;
                }
                else
                    totalError = 0;
                    Console.WriteLine(theBigTotalError);
                    //theBigTotalError = 0;
            }
            Console.WriteLine("TheBigTotalError = " + theBigTotalError.ToString());
        }
        public void Testing()
        {
            numberOfMatching = 0;
            numberOfMismatch = 0;
            for (int k = 35; k < list_of_features.Count; k++)
            {
                if (k >= 0 && k <= 49) //Class 1
                {
                    outputlayer[0].SetDesired(1);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(0);
                }
                else if (k >= 50 && k <= 99) //Class 2
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(1);
                    outputlayer[2].SetDesired(0);
                }
                else //Class 3
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(1);
                }
                if (k == 50 || k == 100) //Skip 35 Training Samples
                {
                    k += 35;
                }
                else
                {
                    List<double> temp = new List<double>();
                    for (int i = 0; i < hiddenlayers[0].Count; i++)
                    {
                        hiddenlayers[0][i].setInputs(list_of_features[k]);
                        hiddenlayers[0][i].Start();
                    }
                    for (int j = 1; j < hiddenlayers.Count; j++)
                    {
                        for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                        {
                            temp.Add(hiddenlayers[j - 1][l].GetOutput());
                        }
                        for (int l = 0; l < hiddenlayers[j].Count; l++)
                        {
                            hiddenlayers[j][l].setInputs(temp);
                            hiddenlayers[j][l].Start();
                        }
                        temp.Clear();

                    }
                    for (int i = 0; i < outputlayer.Count; i++)
                    {
                        for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                        {
                            temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                        }
                        outputlayer[i].setInputs(temp);
                        outputlayer[i].Start();
                        temp.Clear();
                    }
                }
                double max = 0;
                int index = 0;
                for (int i = 0; i < outputlayer.Count; i++)
                {
                    if (max < outputlayer[i].GetOutput())
                    {
                        max = outputlayer[i].GetOutput();
                        index = i;
                    }
                }
                max = 0;
                for (int i = 0; i < outputlayer.Count; i++)
                {
                    if (index == i)
                    {
                        outputlayer[i].SetF(1);
                    }
                    else
                        outputlayer[i].SetF(0);
                }
                bool isMismatching = false;
                 for (int i = 0; i < outputlayer.Count; i++)
                 {
                     if (!outputlayer[i].IsMatching())
                     {
                         isMismatching = true;
                     }

                     
                 }
                 if (isMismatching)
                 {
                     numberOfMismatch++;
                 }
                 else
                 {
                     numberOfMatching++;
                 }
            }
            hiddenlayers.Clear();
            outputlayer.Clear();
          
        }
        public void StartImageTraining()
        {
             while(true)
            {
                //Feed Forward
                // List<double> temp = new List<double>();
                for (int k = 0; k < list_of_features.Count; k++)
                {
                    if (k >= 0 && k <= 8)
                    {
                        outputlayer[0].SetDesired(1);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(0);
                        outputlayer[3].SetDesired(0);
                        outputlayer[4].SetDesired(0);

                    }
                    else if (k >= 9 && k <=17 )
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(1);
                        outputlayer[2].SetDesired(0);
                        outputlayer[3].SetDesired(0);
                        outputlayer[4].SetDesired(0);
                    }
                    else if(k >= 18 && k <= 26)
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(1);
                        outputlayer[3].SetDesired(0);
                        outputlayer[4].SetDesired(0);
                    }
                    else if (k >= 27 && k <= 35)
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(0);
                        outputlayer[3].SetDesired(1);
                        outputlayer[4].SetDesired(0);
                    }
                    else
                    {
                        outputlayer[0].SetDesired(0);
                        outputlayer[1].SetDesired(0);
                        outputlayer[2].SetDesired(0);
                        outputlayer[3].SetDesired(0);
                        outputlayer[4].SetDesired(1);
                    }
                    if (k == 6 || k == 15 || k == 24 || k==33 || k==42)
                    {
                        k += 3;
                    }
                    else if (k == 0 && InitNode==true)
                    {
                        InitNode = false;
                        List<double> temp = new List<double>();

                        for (int i = 0; i < hiddenlayers[0].Count; i++)
                        {
                            hiddenlayers[0][i].InitNode(list_of_features[k]);
                            hiddenlayers[0][i].Start();
                        }
                        for (int j = 1; j < hiddenlayers.Count; j++)
                        {
                            for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                            {
                                temp.Add(hiddenlayers[j - 1][l].GetOutput());
                            }
                            for (int l = 0; l < hiddenlayers[j].Count; l++)
                            {
                                hiddenlayers[j][l].InitNode(temp);
                                hiddenlayers[j][l].Start();
                            }
                            temp.Clear();
                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                            }
                            outputlayer[i].InitNode(temp);
                            outputlayer[i].Start();
                            temp.Clear();
                        }
                        //Back Propagation--------------------------------------------------------------------------

                        //Output layer SiGMA
                        for (int a = 0; a < outputlayer.Count; a++)
                        {
                            outputlayer[a].CalculateNewSiGMA();
                        }
                        //Last hidden layer SiGMA
                        double newSiGMA, oldSiGMA;
                        List<double> L = new List<double>();
                        newSiGMA = 0;
                        for (int a = 0; a < hiddenlayers[hiddenlayers.Count - 1].Count; a++)
                        {
                            for (int b = 0; b < outputlayer.Count; b++)
                            {
                                oldSiGMA = outputlayer[b].GetSiGMA();
                                L = new List<double>(outputlayer[b].GetWeights());
                                newSiGMA += oldSiGMA * L[a];
                            }
                            hiddenlayers[hiddenlayers.Count - 1][a].SetSiGMA(newSiGMA * hiddenlayers[hiddenlayers.Count - 1][a].DerivativeActivation(hiddenlayers[hiddenlayers.Count - 1][a].GetOutput()));
                            newSiGMA = 0;

                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //Rest of the hidden layers
                        for (int i = hiddenlayers.Count - 1; i > 0; i--) //Looping over the layers.
                        {
                            for (int j = 0; j < hiddenlayers[i - 1].Count; j++) //Looping over each node in the previous layer
                            {
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    oldSiGMA = hiddenlayers[i][l].GetSiGMA();
                                    L = new List<double>(hiddenlayers[i][l].GetWeights());
                                    newSiGMA += oldSiGMA * L[j + 1];
                                }
                                hiddenlayers[i - 1][j].SetSiGMA((newSiGMA * hiddenlayers[i - 1][j].DerivativeActivation(hiddenlayers[i - 1][j].GetOutput())));
                                newSiGMA = 0;
                            }

                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //----------------------------------------------------------------------------------------------
                        //Updating the weights
                        for (int i = 0; i < hiddenlayers.Count; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < hiddenlayers[i].Count; j++)
                                {
                                    hiddenlayers[i][j].UpdateWeights(learningRate);
                                }
                            }
                            else
                            {
                                List<double> fs = new List<double>();
                                for (int j = 0; j < hiddenlayers[i-1].Count; j++)
                                {
                                    fs.Add(hiddenlayers[i-1][j].GetOutput());
                                }
                                fs.Insert(0, 1.0);
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    hiddenlayers[i][l].UpdateWeights(learningRate, fs);
                                }
                                fs.Clear();
                            }
                        }
                        List<double> outputlayer_f = new List<double>();
                        for (int i = 0; i < outputlayer.Count; i++) //Updating weights of the output layer
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                outputlayer_f.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());
                            }
                            outputlayer_f.Insert(0, 1.0);
                            outputlayer[i].UpdateWeights(learningRate, outputlayer_f);
                            outputlayer_f.Clear();
                         }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            outputlayer[i].CalculateError();
                            totalError += Math.Pow(outputlayer[i].GetError(), 2);
                        }
                        totalError /= 2;

                    }
                    else
                    {
                        List<double> temp = new List<double>();
                        for (int i = 0; i < hiddenlayers[0].Count; i++)
                        {
                            hiddenlayers[0][i].setInputs(list_of_features[k]);
                            hiddenlayers[0][i].Start();
                        }
                        for (int j = 1; j < hiddenlayers.Count; j++)
                        {
                            for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                            {
                                temp.Add(hiddenlayers[j - 1][l].GetOutput());
                            }
                            for (int l = 0; l < hiddenlayers[j].Count; l++)
                            {
                                hiddenlayers[j][l].setInputs(temp);
                                hiddenlayers[j][l].Start();
                            }
                            temp.Clear();

                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                            }
                            outputlayer[i].setInputs(temp);
                            outputlayer[i].Start();
                            temp.Clear();
                        }
                        //Back Propagation--------------------------------------------------------------------------

                        //Output layer SiGMA
                        for (int a = 0; a < outputlayer.Count; a++)
                        {
                            outputlayer[a].CalculateNewSiGMA();
                        }
                        //Last hidden layer SiGMA
                        double newSiGMA, oldSiGMA;
                        List<double> L = new List<double>();
                        newSiGMA = 0;
                        for (int a = 0; a < hiddenlayers[hiddenlayers.Count - 1].Count; a++)
                        {
                            for (int b = 0; b < outputlayer.Count; b++)
                            {
                                oldSiGMA = outputlayer[b].GetSiGMA();
                                L = new List<double>(outputlayer[b].GetWeights());
                                newSiGMA += oldSiGMA * L[a];
                            }
                            hiddenlayers[hiddenlayers.Count - 1][a].SetSiGMA(newSiGMA * hiddenlayers[hiddenlayers.Count - 1][a].DerivativeActivation(hiddenlayers[hiddenlayers.Count - 1][a].GetOutput()));
                            newSiGMA = 0;
                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //Rest of the hidden layers
                        for (int i = hiddenlayers.Count - 1; i > 0; i--) //Looping over the layers.
                        {
                            for (int j = 0; j < hiddenlayers[i - 1].Count; j++) //Looping over each node in the previous layer
                            {
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    oldSiGMA = hiddenlayers[i][l].GetSiGMA();
                                    L = new List<double>(hiddenlayers[i][l].GetWeights());
                                    newSiGMA += oldSiGMA * L[j + 1];
                                }
                                hiddenlayers[i - 1][j].SetSiGMA((newSiGMA * hiddenlayers[i - 1][j].DerivativeActivation(hiddenlayers[i - 1][j].GetOutput())));
                                newSiGMA = 0;
                            }
                        }
                        L.Clear();
                        oldSiGMA = 0;
                        //----------------------------------------------------------------------------------------------
                        //Updating the weights
                        for (int i = 0; i < hiddenlayers.Count; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < hiddenlayers[i].Count; j++)
                                {
                                    hiddenlayers[i][j].UpdateWeights(learningRate);
                                }
                            }
                            else
                            {
                                List<double> fs = new List<double>();
                                for (int j = 0; j < hiddenlayers[i - 1].Count; j++)
                                {
                                    fs.Add(hiddenlayers[i - 1][j].GetOutput());
                                }
                                fs.Insert(0, 1.0);
                                for (int l = 0; l < hiddenlayers[i].Count; l++)
                                {
                                    hiddenlayers[i][l].UpdateWeights(learningRate, fs);
                                }
                                fs.Clear();
                            }
                        }
                        List<double> outputlayer_f = new List<double>();
                        for (int i = 0; i < outputlayer.Count; i++) //Updating weights of the output layer
                        {
                            for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                            {
                                outputlayer_f.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());
                            }
                            outputlayer_f.Insert(0, 1.0);

                            outputlayer[i].UpdateWeights(learningRate, outputlayer_f);
                            outputlayer_f.Clear();
                        }
                        for (int i = 0; i < outputlayer.Count; i++)
                        {
                            outputlayer[i].CalculateError();
                            totalError += Math.Pow(outputlayer[i].GetError(),2);

                        }
                        totalError /= 2;

                                               
                    }
                   // theBigTotalError += totalError;
                    theBigTotalError += totalError; 
                    totalError = 0;

                }
                theBigTotalError /= 30.0d;
                if (theBigTotalError < errorThreshold)
                {
                    Console.WriteLine("After Training: " + theBigTotalError);
                    theBigTotalError = 0;
                    InitNode = true;
                    break;
                }
                else
                    Console.WriteLine("During Training:" + theBigTotalError);
                    theBigTotalError = 0;
            }
        }
        public void TestingImage()
        {
            numberOfMatching = 0;
            numberOfMismatch = 0;
            for (int k = 6; k < list_of_features.Count; k++)
            {
                if (k >= 0 && k <= 8)
                {
                    outputlayer[0].SetDesired(1);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(0);
                    outputlayer[3].SetDesired(0);
                    outputlayer[4].SetDesired(0);

                }
                else if (k >= 9 && k <= 17)
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(1);
                    outputlayer[2].SetDesired(0);
                    outputlayer[3].SetDesired(0);
                    outputlayer[4].SetDesired(0);
                }
                else if (k >= 18 && k <= 26)
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(1);
                    outputlayer[3].SetDesired(0);
                    outputlayer[4].SetDesired(0);
                }
                else if (k >= 27 && k <= 35)
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(0);
                    outputlayer[3].SetDesired(1);
                    outputlayer[4].SetDesired(0);
                }
                else
                {
                    outputlayer[0].SetDesired(0);
                    outputlayer[1].SetDesired(0);
                    outputlayer[2].SetDesired(0);
                    outputlayer[3].SetDesired(0);
                    outputlayer[4].SetDesired(1);
                }
                if (k == 9 || k == 18 || k==27 || k==36 )
                {
                    k += 6;
                }
                else
                {
                    List<double> temp = new List<double>();
                    for (int i = 0; i < hiddenlayers[0].Count; i++)
                    {
                        hiddenlayers[0][i].setInputs(list_of_features[k]);
                        hiddenlayers[0][i].Start();
                    }
                    for (int j = 1; j < hiddenlayers.Count; j++)
                    {
                        for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                        {
                            temp.Add(hiddenlayers[j - 1][l].GetOutput());
                        }
                        for (int l = 0; l < hiddenlayers[j].Count; l++)
                        {
                            hiddenlayers[j][l].setInputs(temp);
                            hiddenlayers[j][l].Start();
                        }
                        temp.Clear();

                    }
                    for (int i = 0; i < outputlayer.Count; i++)
                    {
                        for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                        {
                            temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                        }
                        outputlayer[i].setInputs(temp);
                        outputlayer[i].Start();
                        temp.Clear();
                    }
                }
                double max = 0;
                int index = 0;
                for (int i = 0; i < outputlayer.Count; i++)
                {
                    if (max < outputlayer[i].GetOutput())
                    {
                        max = outputlayer[i].GetOutput();
                        index = i;
                    }
                }
                max = 0;
                for (int i = 0; i < outputlayer.Count; i++)
                {
                    if (index == i)
                    {
                        outputlayer[i].SetF(1);
                    }
                    else
                        outputlayer[i].SetF(0);
                }
                bool isMismatching = false;
                for (int i = 0; i < outputlayer.Count; i++)
                {
                    if (!outputlayer[i].IsMatching())
                    {
                        isMismatching = true;
                    }


                }
                if (isMismatching)
                {
                    numberOfMismatch++;
                }
                else
                {
                    numberOfMatching++;
                }
            }
            hiddenlayers.Clear();
            outputlayer.Clear();
        }
        public void SetNumberOfEpochs(int n)
        {
            numberOfEpochs = n;
        }
        public string SampleTest(List<double> sampleInput)
        {
                    
                    List<double> temp = new List<double>();
                    for (int i = 0; i < hiddenlayers[0].Count; i++)
                    {
                        hiddenlayers[0][i].setInputs(sampleInput);
                        hiddenlayers[0][i].Start();
                    }
                    for (int j = 1; j < hiddenlayers.Count; j++)
                    {
                        for (int l = 0; l < hiddenlayers[j - 1].Count; l++)
                        {
                            temp.Add(hiddenlayers[j - 1][l].GetOutput());
                        }
                        for (int l = 0; l < hiddenlayers[j].Count; l++)
                        {
                            hiddenlayers[j][l].setInputs(temp);
                            hiddenlayers[j][l].Start();
                        }
                        temp.Clear();

                    }
                    for (int i = 0; i < outputlayer.Count; i++)
                    {
                        for (int j = 0; j < hiddenlayers[hiddenlayers.Count - 1].Count; j++)
                        {
                            temp.Add(hiddenlayers[hiddenlayers.Count - 1][j].GetOutput());

                        }
                        outputlayer[i].setInputs(temp);
                        outputlayer[i].Start();
                        temp.Clear();
                    }
                    double max = 0;
                    int index = 0;
                    for (int i = 0; i < outputlayer.Count; i++)
                    {
                        if (max < outputlayer[i].GetOutput())
                        {
                            max = outputlayer[i].GetOutput();
                            index = i;
                        }
                    }
                    max = 0;
                    for (int i = 0; i < outputlayer.Count; i++)
                    {
                        if (index == i)
                        {
                            outputlayer[i].SetF(1);
                        }
                        else
                            outputlayer[i].SetF(0);
                    }
                    if (outputlayer[0].GetOutput() == 1.0)
                    {
                        return "Setosa";

                    }
                    else if (outputlayer[1].GetOutput() == 1.0)
                    {
                        return "Versicolor";
                    }
                    else
                    {
                        return "Virginica";
                    }
            

                }
        public void PCA()
        {

            //double[,] ay7aga = new double[900,900];
            List<List<double>> ay7aga = new List<List<double>>();
            for (int i = 0; i < principalComponents; i++)
            {
                ay7aga.Add(new List<double>());
                for (int j = 0; j < list_of_features[0].Count; j++)
                {
                    ay7aga[i].Add(0);
                }
            }
            List<List<double>> outputPCA_weight = new List<List<double>>();
            List<double> fs = new List<double>();
            List<double> Temp1;
            for (int i = 0; i < principalComponents; i++)
            {
                OutputNeuron temp = new OutputNeuron();
                outputlayer_PCA.Add(temp);
                outputlayer_PCA[i].InitNode_PCA(list_of_features[0]);
            }

            //Epochs Loop
            for (int l = 0; l < numberOfEpochs; l++)
            {
                for (int k = 0; k < list_of_features.Count; k++)
                {
                    for (int z = 0; z < principalComponents; z++)
                    {
                        outputlayer_PCA[z].setInputs(list_of_features[k]);
                        outputlayer_PCA[z].StartPCA();
                        fs.Add(outputlayer_PCA[z].GetOutput());
                        Temp1 = new List<double>(outputlayer_PCA[z].GetWeights());
                        outputPCA_weight.Add(new List<double>(Temp1));
                        Temp1.Clear();
                    }
                    for (int j = 0; j < principalComponents; j++)
                    {
                        for (int i = 0; i < list_of_features[k].Count; i++)
                        {
                            if (j == 0)
                                ay7aga[j][i] = outputPCA_weight[j][i] * fs[j];
                            else
                                ay7aga[j][i] = ay7aga[j - 1][i] + (outputPCA_weight[j][i] * fs[j]);
                            outputPCA_weight[j][i] += learningRatePCA * (fs[j] * list_of_features[k][i] - fs[j] * ay7aga[j][i]);
                        }
                        outputlayer_PCA[j].setWeights(outputPCA_weight[j]);
                    }
                    //Samples Loop
                    outputPCA_weight.Clear();
                    fs.Clear();
                }
               //Epoch Loop
                Console.WriteLine("Epoch #" + (l + 1) + " is done!");
            }
            
            List<List<double>> reducedFeatures = new List<List<double>>();
            for (int k = 0; k < list_of_features.Count; k++)
            {
                for (int z = 0; z < principalComponents; z++)
                {
                    outputlayer_PCA[z].setInputs(list_of_features[k]);
                    outputlayer_PCA[z].StartPCA();
                    fs.Add(outputlayer_PCA[z].GetOutput());
                 
                }
                reducedFeatures.Add(new List<double>(fs));
                fs.Clear();
              
                //Samples Loop
            }
            list_of_features.Clear();
            for (int i = 0; i < reducedFeatures.Count; i++)
            {
                list_of_features.Add(new List<double>(reducedFeatures[i]));
               
            }
            ay7aga.Clear();
            reducedFeatures.Clear();
           
        }
        public int GetNumberOfMismatch()
        {
            return numberOfMismatch;
        }
        public int GetNumberOfMatching()
        {
            return numberOfMatching;
        }
    }
}
