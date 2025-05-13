using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{

    public interface IFood
    {
        void Cook();
    }
    //public class Food 
    //{ 
    //    public  void Cook()
    //    {
    //        Console.WriteLine($"{GetType().Name} hazırlandı");
    //    }

    //    public virtual void PresentFood()
    //    {
    //        Console.WriteLine("Yanında ..... sunuldu");
    //    }
        
    //}

    public class Pasta : IFood
    {
        //public override void PresentFood()
        //{
        //    base.PresentFood();
        //}
        public void Cook()
        {
            Console.WriteLine("Makarna pişti");
        }
    }
       
    public class Cake : IFood
    {
        //public override void PresentFood()
        //{
        //   throw new NotImplementedException("Kek yanında bir ikram yok!");
        //}
        public void Cook()
        {
            Console.WriteLine("Kek pişti");
        }
    }

    public class Chef
    {
        public void Cook(IFood food)
        {
            food.Cook();
        }

        //public void Present( food ) {
        //    //if (!(food is Cake))
        //    //{
        //    //    food.PresentFood();
        //    //}
        //    food.PresentFood();
        //}
    }
}
