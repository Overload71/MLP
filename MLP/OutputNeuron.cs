using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class OutputNeuron : Neuron
    {
        int d;
        double e;
        public void SetDesired(int newD)
        {
            d = newD;
        }
        public void CalculateNewSiGMA()
        {
            this.SiGMA = (d - this.f) * DerivativeActivation(this.f);
        }
        public int GetDesired()
        {
            return d;
        }
        public bool IsMatching()
        {
            if (this.f - d == 0)
                return true;
            else
                return false;
        }
        public void SetF(double newF)
        {
            this.f = newF;
        }
        public void CalculateError()
        {
            e=d-f;
        }
        public double GetError()
        {
            return e;
        }
       
    }
}
