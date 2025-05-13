using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IMath
    {
        int Add(int x, int y);
        int Subtract(int x, int y);
        int Multiply(int x, int y);
        int Divide(int x, int y);
       

    }

    public interface IComplexMath
    {
        int Modulo(int x, int y);
        int Power(int x, int y);
    }

    public class SimpleMath : IMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Divide(int x, int y)
        {
            return x / y;
        }
      
        public int Multiply(int x, int y)
        {
            return x * y;
        }

     

        public int Subtract(int x, int y)
        {
            return x - y;
        }
    }

    public class ComplexMath : IMath, IComplexMath
    {
        public int Add(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Divide(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Modulo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Multiply(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Power(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
