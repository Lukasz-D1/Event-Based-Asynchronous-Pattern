using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Based_Asynchronous_Pattern
{
    class MatMulCompletedEventArgs : AsyncCompletedEventArgs
    {
        // Klasa ktora odpowiada za zakonczony event liczenia macierzy.
        // Przyjmuje jako parametry obliczona macierz, oraz jej rozmiar.
        double[] mat;
        int size;
        public MatMulCompletedEventArgs(double[] mat, int size, Exception e, object o, bool b) : base(e, b, o)
        {
            // Reszta tych parametrow pochodzi z AsyncCompletedEventArgs, ale nie musimy jej wypelniac, wiec mozemy po prostu wpisac null w wywolaniu.
            this.Mat = mat;
            this.Size = size;
        }

        public double[] Mat { get => mat; set => mat = value; }
        public int Size { get => size; set => size = value; }
    }
}
