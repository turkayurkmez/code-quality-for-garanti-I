namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            StudentService studentService = new StudentService();
            BubbleSort bubbleSort = new BubbleSort();
            HeapSort heapSort = new HeapSort(); 
            studentService.Sort(bubbleSort);
            studentService.Sort(heapSort);



        }
    }
    /*
     * Bir operasyonun algoritmasının değişme ihtimali vardır. Bu değişimi en ideal nasıl yönetirsiniz?
     */
  
}
