using System.Diagnostics;

namespace LD;

class LevestainDistance
{
    public static int Calculate(string s, string t)
    {
        int m = s.Length;
        int n = t.Length;

        int[] v0 = new int[t.Length + 1];
        int[] v1 = new int[t.Length + 1];
        
        for (int i = 0; i < n + 1; i++)
        {
            v0[i] = i;
        }

        for (int i = 0; i < m; i++)
        {

            v1[0] = i + 1;

            for(int j = 0; j < n; j ++)
            {
                int deletionCost = v0[j + 1] + 1;
                int insertionCost = v1[j] + 1;
                int subtractionCost;

                if (s[i] == t[j])
                {
                    subtractionCost = v0[j];
                }   
                else
                {
                    subtractionCost = v0[j] + 1;
                }

                v1[j + 1] = Math.Min(Math.Min(deletionCost, insertionCost), subtractionCost);

            }

            var temp = v1;
            v1 = v0;
            v0 = temp;
        }

        return v0[n];
    }
}

class Program
{
    static void Main(string[] args)
    {
        string str1 = "kitten";
        string str2 = "sitting";
        
        var sw = Stopwatch.StartNew();

        int distance = LevestainDistance.Calculate(str1, str2);

        sw.Stop();

        Console.WriteLine($"{str1} -> {str2} = {distance} | runtime: {sw.ElapsedMilliseconds}:{sw.ElapsedTicks}");

    }



}