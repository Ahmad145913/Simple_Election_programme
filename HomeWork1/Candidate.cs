using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    class Candidate
    {
      public int N;
      public string name;
      public int total;
      public float percentage;
      public  Candidate(int vN, string vname, int vtotal) 
        {
            N = vN;
            name = vname;
            total = vtotal;
        }
       public void computePercent(float all) 
        {
            percentage = (total /all);
        }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", N,name, total,Math.Round( percentage,2));
        }
    }
}
