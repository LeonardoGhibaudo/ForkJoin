using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
       
        int A = 10;
        int B = 20;
        int C = 30;

        
        Task<int> taskD = Task.Run(() => A + 5);          
        Task<int> taskE = Task.Run(() => B * 2);           
        Task<int> taskF = Task.Run(() => C * C);           

     
        Task.WhenAll(taskD, taskE, taskF).Wait();

      
        int D = taskD.Result;
        Console.WriteLine(D); 
        int E = taskE.Result;
        Console.WriteLine(E);
        int F = taskF.Result;
        Console.WriteLine(F);

    
        Task<int> taskG = Task.Run(() => E - D);   
        Console.WriteLine(taskG.Result);

       
        Task<int> taskH = taskG.ContinueWith(prevTask => F + prevTask.Result);
        Console.WriteLine(taskH.Result); 

      
        taskH.Wait();

    }
}