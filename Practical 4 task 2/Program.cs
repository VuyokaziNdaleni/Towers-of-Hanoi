using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_4_task_2
{
    internal class Program
    {
        static Stack<int> pegA = new Stack<int>();
        static Stack<int> pegB = new Stack<int>();
        static Stack<int> pegC = new Stack<int>();
        static void Main(string[] args)
        {
            new Program();
        }

        public Program() 
        {

            solve();
        }

        public void solve() 
        {
            StreamReader reader = new StreamReader("TestInputs.txt"); ;
            string input = reader.ReadLine();


            while(input != null) 
            {
                int m = int.Parse(input);
                InitializePegs(m);
                
                SolveTowersOfHanoi(m, pegA, pegC, pegB);
                writedata("\n");
                input = reader.ReadLine();
            }
        
        }

        public void SolveTowersOfHanoi(int n, Stack<int> source, Stack<int> target, Stack<int> auxiliary)
        {
            if (n == 1)
            {
                MoveDisk(source, target);
            }
            else
            {
                SolveTowersOfHanoi(n - 1, source, auxiliary, target);
                MoveDisk(source, target);
                SolveTowersOfHanoi(n - 1, auxiliary, target, source);
            }
        }
        public void MoveDisk(Stack<int> source, Stack<int> target)
        {
            int disk = source.Pop();
            target.Push(disk);
          writedata(GetPegName(source),GetPegName(target));
        }
        public void InitializePegs(int m)
        {
            pegA.Clear();
            pegB.Clear();
            pegC.Clear();
            for (int i = m; i >= 1; i--)
            {
                pegA.Push(i);
            }
        }

        public string GetPegName(Stack<int> peg)
        {
            if (peg == pegA) return "A";
            if (peg == pegB) return "B";
            if (peg == pegC) return "C";
            return "";
        }

        public void writedata(string a, string b)
        {
            using (StreamWriter writer = new StreamWriter("Output01.txt", true))
                writer.Write(a + b+",");
        }

        public void writedata(string data)
        {
            using (StreamWriter writer = new StreamWriter("Output01.txt", true))
            {
                writer.Write(data);
            }
        }
    }
}
