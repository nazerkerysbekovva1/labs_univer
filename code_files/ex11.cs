using System;
using System.Threading.Tasks;

class DemoParallelForWithLoopResult
{
    static int[] data;

    // Параллель орындалатын цикл тұлғасы ретінде қызмет ететін әдіс.
    static void DisplayData(int v, ParallelLoopState pls)
    {
        // Теріс мән табылған жағдайда цикл жұмысын тоқтату.
        if (v < 0) pls.Break();
        Console.WriteLine("Мән: " + v);
    }

    static void Main()
    {
        Console.WriteLine("Negizgi agyn iske kosyldy.");
        data = new int[100000000];
        // Мәліметтерді инициалдау.
        for (int i = 0; i < data.Length; i++) data[i] = i;
        // Теріс мәнді data жиымына енгізу
        data[1000] = -10;
        // ForEach() әдісінің көмегімен параллель орындалатын циклді пайдалану
        ParallelLoopResult loopResult = Parallel.ForEach(data, DisplayData);
        // Циклдің аяқталғанын тексеру.
        if (loopResult.IsCompleted)
            Console.WriteLine("\nЦикл мерзімінен бұрын аяқталды, себебі циклдің " + loopResult.LowestBreakIteration + " нөмірлі қадамында теріс мән табылды\n");
        Console.WriteLine("Негізгі ағын аяқталды.");
    }
}
