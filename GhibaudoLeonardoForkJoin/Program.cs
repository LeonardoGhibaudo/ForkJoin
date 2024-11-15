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

        // Fork: Creazione di task paralleli per il calcolo di D, E, F
        Task<int> taskD = Task.Run(() => CalcolaD(A));    // Calcola D
        Task<int> taskE = Task.Run(() => CalcolaE(B));    // Calcola E
        Task<int> taskF = Task.Run(() => CalcolaF(C));    // Calcola F

        // Join: Aspettiamo che tutti i task siano completati
        Task.WhenAll(taskD, taskE, taskF).Wait();

        // Ottenere i risultati dai task
        int D = taskD.Result;
        int E = taskE.Result;
        int F = taskF.Result;

        // Fork: Creazione di task paralleli per calcolare G (dipende da D e E)
        Task<int> taskG = Task.Run(() => CalcolaG(E, D));  // Calcola G

        // Join: Aspettiamo che il task G sia completato
        taskG.Wait();
        int G = taskG.Result;

        // Fork: Creazione di un task per calcolare H (dipende da F e G)
        Task<int> taskH = Task.Run(() => CalcolaH(F, G));  // Calcola H

        // Join: Aspettiamo che il task H sia completato
        taskH.Wait();
        int H = taskH.Result;

        // Stampa dei risultati
        Console.WriteLine($"D = {D}");
        Console.WriteLine($"E = {E}");
        Console.WriteLine($"F = {F}");
        Console.WriteLine($"G = {G}");
        Console.WriteLine($"H = {H}");
    }

    // Metodi di calcolo per ogni operazione
    static int CalcolaD(int A) => A + 5;
    static int CalcolaE(int B) => B * 2;
    static int CalcolaF(int C) => C * C;
    static int CalcolaG(int E, int D) => E - D;
    static int CalcolaH(int F, int G) => F + G;
}