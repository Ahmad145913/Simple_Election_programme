using System;
using System.IO;
namespace HomeWork1
{
    class Program
    {
        static string[] names =new string[4];
        static int[] id = new int[4];
        static float total = 0;
        static void AddResultCenter(string pathname)
        {
            Console.WriteLine("Count from Center: " + pathname);
            Console.WriteLine("Votes\t\tName");
            Console.WriteLine("------------------------------------");
            string[] arr;
            total = 0;
            string r ;
            StreamReader strReader = new StreamReader(pathname);
            do
            {
                r = strReader.ReadLine();
                if (r != null)
                {
                    arr = r.Split(',');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        switch (arr[i]) {
                            case "1":
                            id[0]++;break;
                            case "2":
                            id[1]++; break;
                            case "3":
                            id[2]++; break;
                            case "4":
                            id[3]++; break;
                        }
                    }
                }
            } while (r != null);
            int j = 0;
            Console.WriteLine(id[0] + "\t\t" + names[0]);
            Console.WriteLine(id[1] + "\t\t" + names[1]);
            Console.WriteLine(id[2] + "\t\t" + names[2]);
            Console.WriteLine(id[3] + "\t\t" + names[3]);
            total = id[0]+ id[1]+ id[2]+ id[3];
            strReader.Close();
        }
        static void Main(string[] args)
        {
            Candidate[] arrC = new Candidate[4];
            int z = 0, m = 0;
            int[] num = new int[4];
            string name;
            string rows ;
            StreamReader str = new StreamReader("Candiates.txt");
            Console.WriteLine("Number\t\tName");
            Console.WriteLine("------------------------------");
            string[] a = new string[2];
            do
            {
                rows = str.ReadLine();
                if (rows != null)
                {
                    a = rows.Split(',');
                    num[m] = int.Parse(a[0]);
                    names[m] = a[1];
                }
                Console.WriteLine(a[0] + "\t\t" + a[1]);
                m += 1;
            } while (rows != null);
            str.Close();
            AddResultCenter("ElectionC1.txt");
            AddResultCenter("ElectionC2.txt");
            AddResultCenter("ElectionC3.txt");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("N\tName\tTotal\tPercentage");
            Console.WriteLine("----------------------------------------------------");
            for (int x = 0; x < 4; x++)
            {
                for (int y = x + 1; y < 4; y++)
                {
                    if (id[y] > id[x])
                    {
                        z = id[y];
                        id[y] = id[x];
                        id[x] = z;
                        name = names[y];
                        names[y] = names[x];
                        names[x] = name;
                        z = num[y];
                        num[y] = num[x];
                        num[x] = z;
                    }
                }
            }
            for (int j = 0; j < 4; j++)
            {
                arrC[j] = new Candidate(num[j], names[j], id[j]);
                arrC[j].computePercent(total);
                Console.WriteLine(arrC[j].ToString());
            }
        }
    }
}
