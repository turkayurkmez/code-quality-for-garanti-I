using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    

    public interface ISortStrategy
    {
        void Sort();
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort()
        {
            Console.WriteLine("Bubble Sort Algoritması");
        }
    }

    public class HeapSort : ISortStrategy
    {
        public void Sort()
        {
            Console.WriteLine("Bubble Sort Algoritması");
        }
    }

    public class  StudentService
    {
        
        public void Sort(ISortStrategy sortStrategy)
        {
            //Sıralama algoritması.....
            sortStrategy.Sort();
        }
    }


}
