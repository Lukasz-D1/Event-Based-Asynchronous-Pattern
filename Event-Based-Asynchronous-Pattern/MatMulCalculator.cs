using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Based_Asynchronous_Pattern
{
    class MatMulCalculator
    {
        public delegate void EventHandler(MatMulCompletedEventArgs args);
        public event EventHandler foo;

        public double getval(double[] mat, int row, int column, int size)
        {
            return mat[row * size + column];
        }

        public double[] matMul(double[] mat1, double[] mat2, int size)
        {
            // Funkcja od mnozenia macierzy.

            double[] result = new double[size * size];
            for (int i = 0; i < size * size; i++)
            {
                result[i] = 0;
            }
            for (int i = 0; i < size * size; i++)
            {
                int row = i / size;
                int column = i % size;
                for (int j = 0; j < size; j++)
                {
                    result[i] += getval(mat1, row, j, size) * getval(mat2, j, column, size);
                }
            }

            // Deklarujemy obiekt wskazujacy na to, ze dzialanie funkcji MatMul sie zakonczylo, czyli ze mamy juz wynik mnozenia dwoch macierzy.
            MatMulCompletedEventArgs args = new MatMulCompletedEventArgs(result, size, null, null, true);
            
            // Zglaszamy event CompletedEventArgs czyli no ze nasze glowne zdarzenie dot. liczenia macierzy dobieglo konca.
            foo.Invoke(args);
       
            // Zwracamy wynik.
            return result;

        }

    }
}
