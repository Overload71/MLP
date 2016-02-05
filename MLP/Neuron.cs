using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class Neuron
    {
        //Member Variables
        protected List<double> inputs = new List<double>();
        protected List<double> weights = new List<double>();
        int maxWeight = 1, minWeight =-1;
        private static Random rand = new Random();
        protected double f;
        protected double SiGMA = 0;
        protected double slopeConst;

        //Member Functions
        public void setInputs(List<double> L)
        {
            inputs = new List<double>(L);
        }
        public void setWeights(List<double> W)
        {
            weights = new List<double>(W);
        }
        public void SetSlopeConstant(double s)
        {
            slopeConst = s;
        }
        private double IxW()
        {
            double v = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                v += inputs[i]*weights[i];
            }
            return v;
        }
        private double ActivationSigmoid(double v)
        {
            return  1 / (1 + Math.Exp(-v*slopeConst));
            
        }
        public void Start()
        {
            double v = IxW();
            f = ActivationSigmoid(v);

        }
        public void StartPCA()
        {
            f = IxW();
        }
       public double GetOutput()
        {
            return f;
        }
       public void InitNode(List<double> L)
       {
           inputs = new List<double>(L);
           inputs.Insert(0, 1.0);
           for (int i = 0; i < inputs.Count; i++)
           {

               weights.Add(rand.NextDouble() * (maxWeight - minWeight) + minWeight);
           }
       }
       public void InitNode_PCA(List<double> L)
       {
          // inputs = new List<double>(L);
           
           for (int i = 0; i < L.Count; i++)
           {

               weights.Add(rand.NextDouble() * (maxWeight - minWeight) + minWeight);
           }
       }
        public double DerivativeActivation(double u)
       {
           return (u * (1 - u));
       }
        public void CalculateNewSiGMA(List<double> S, List<double> W)
        {
            
        }
        public void SetSiGMA(double S)
        {
            SiGMA = S;
        }
        public double GetSiGMA()
        {
            return SiGMA;
        }
        public List<double> GetWeights()
        {
            return weights;
        }
        public void UpdateWeights(double learningRate)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                weights[i] += learningRate * SiGMA * inputs[i];
            }
        }
        public void UpdateWeights(double learningRate, List<double> f)
        {
            for (int i = 0; i < f.Count; i++)
            {
                weights[i] += learningRate * SiGMA * f[i];
            }
        }
    }
}
