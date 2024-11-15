using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Inizializzazione delle variabili
        int A = 10;
        int B = 20;
        int C = 30;

        // Task paralleli per il calcolo delle variabili D, E, F
        Task<int> taskD = Task.Run(() => A + 5);           // Calcola D
        Task<int> taskE = Task.Run(() => B * 2);           // Calcola E
        Task<int> taskF = Task.Run(() => C * C);           // Calcola F

        // Attendere che tutti i task di D, E e F siano completati
        Task.WhenAll(taskD, taskE, taskF).Wait();

        // Ottenere i risultati
        int D = taskD.Result;
        int E = taskE.Result;
        int F = taskF.Result;

        // Task per il calcolo di G
        Task<int> taskG = Task.Run(() => E - D);           // Calcola G

        // Calcolo di H dipendente da G e F
        Task<int> taskH = taskG.ContinueWith(prevTask => F + prevTask.Result);

        // Attendere che tutti i task siano completati
        taskH.Wait();

        // Stampa i risultati
        Console.WriteLine(D);  // Risultato di D
        Console.WriteLine(E);  // Risultato di E
        Console.WriteLine(F);  // Risultato di F
        Console.WriteLine(taskG.Result);  // Risultato di G
        Console.WriteLine(taskH.Result);  // Risultato di H
    }
}