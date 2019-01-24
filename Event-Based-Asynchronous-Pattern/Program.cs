using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Based_Asynchronous_Pattern
{
    class Program
    {

        delegate void EventHandler(EventArgs args);

        static event EventHandler foo;


        static void Main(string[] args)
        {
            //CzescI();
            /*
             * Zaprojektuj klase CompletedEventArgs dla zdarzenia
             * obslugujacego asynchroniczna operacje
             * MatMulAsync w ramach operacji asynchronicznego mnozenia
             * macierzy. Rozwaz implementacje klasy ProgressChangedEventArgs.
             * Przyjmij zalozenie ze mnozone macierze beda o rozmiarze n x n.
             */

            /*
             * Utwórz klasę MatMulCalculator i rozpocznij budowę klasy zgodnie z
             * wzorcem EAP (MSDN)
               Zadeklaruj delegat dla zdarzenia MatMulCompleted

               Zadeklaruj zdarzenie MatMulCompleted

               Zadeklaruj HybridDictionary, przechowujący informacje o wykonywanych
               operacjach

               Zadeklaruj callback onCompletedCallback (typu SendOrPostCallback)

               Zdefiniuj metodę CalculateCompleted, która, w razie, gdy zostało w jakiś
               sposób zdefiniowane zdarzenie MatMulCompleted, wywołuje to zdarzenie

               W konstruktorze przypisz operację CalculateCompleted do callbacku
               onCompletedCallback

            XD
             */

            MatMulCalculator calculator = new MatMulCalculator();
            // Do kolejki zdarzen dodajemy funkcje wypisujaca na konsole wynik mnozenia. Uruchomi sie ona w momencie, gdy do EventHandlera dojdzie informacja, ze zakonczono wykonywanie funkcji mnozacej macierze.
            calculator.foo += Calculator_foo;
            // Teoretycznie normalnie ta funkcja powinna cos zwrocic, ale nie zwraca dlatego ze foo jest typu event handler 
            // i kolejkuje bo czeka na glowny event (policzenie tej macierzy) az sie skonczy
            //, czyli zajmuje sie tym naszym zdarzeniem.

            // Deklarujemy ta macierz.
            double[] mat = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // I wykonujemy mnozenie. Jak ono sie skonczy to wyswietli sie nam wynik z zakolejkowanej funkcji.
            calculator.matMul(mat, mat, 3);
        }

        private static void Calculator_foo(MatMulCompletedEventArgs args)
        {
            // Ta metoda tylko wyswietla wynik przekazany do MatMulCompletedEventArgs
            for (int i = 0; i < args.Size; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < args.Size; j++)
                {
                    Console.Write("{0} ", args.Mat[i * args.Size + j]);
                }
                Console.WriteLine("]");
            }

        }

        private static void CzescI()
        {
            foo = new EventHandler(baseEvent);
            foo += myEvent;
            foo.Invoke(new EventArgs());
        }

        static void baseEvent(EventArgs args)
        {
            Console.WriteLine("Pozdrowienia z glownego ciala zdarzenia");
        }

        static void myEvent(EventArgs args)
        {
            Console.WriteLine("i z ciala zaimplementowanego w ramach klienta oprogramowania");
        }



    }
}
