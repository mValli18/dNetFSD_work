using System.Net.NetworkInformation;

namespace IniAPP
{
    internal class Program
    {
        static void checkNumber()
        {
            //Console.WriteLine("please enter a number between 25 and 99");
           // int num = Convert.ToInt32(Console.ReadLine());
            //if (num < 25 & num > 99)
               // Console.WriteLine("invalid");
            //else
                //Console.WriteLine($"number {num} is valid");
            
            
        }
        static int prime(int num)
        {
            int i;
            if (num <= 1)
                return 0;
            if (num == 2)
                return 1;
            for(i=3;i*i<=num;i++)
            {
                if (num % i == 0)
                    return 0;
            }
            return 1;

        }
        static void even(int num)
        {
            if (num % 2 == 0 & num >= 1)
                Console.WriteLine($"{num} is a even number");
            else
                Console.WriteLine($"{num} is a odd number");
        }
        static void Square(int num)
        {
            Console.WriteLine($"The square of the given number {num} is {num * num}");

        }
        static void Average(int num1,int num2)
        {
            Console.WriteLine("please enter 8 numbers one by one");
            int num3 = Convert.ToInt32(Console.ReadLine());
            int num4 = Convert.ToInt32(Console.ReadLine());
            int num5 = Convert.ToInt32(Console.ReadLine());
            int num6 = Convert.ToInt32(Console.ReadLine());
            int num7 = Convert.ToInt32(Console.ReadLine());
            int num8 = Convert.ToInt32(Console.ReadLine());
            int num9 = Convert.ToInt32(Console.ReadLine());
            int num10 = Convert.ToInt32(Console.ReadLine());
            double result =Convert.ToDouble((num1 + num2 +num3+ num4 + num5 + num6 + num7 + num8 + num9 + num10)) / 10;
            Console.WriteLine($"The Average of Ten numbers is {result}");
        }

        /*static int getARandomNum()
        {
            int num1=new Random().Next(1,500);
  

        }*/
        static void Main(string[] args)
        {
            //Console.WriteLine("enter name");
            //string n;
            //n=Console.ReadLine();
            //Console.WriteLine("hello "+n);
            //Console.WriteLine($"hello {n}!!!");
           // int num = getARandomNum();
           // Console.WriteLine("The number is " + num);
            //checkNumber();
            //sum();
            //assignment
            //1.sum of two numbers
            Console.WriteLine("enter two numbers");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The sum of two numbers is {num1 + num2}");
            //2.printing the biggest of two numbers
            if (num1 > num2)
                Console.WriteLine($"{num1} is the biggest of {num1} and {num2}");
            else
                Console.WriteLine($"{num2} is the biggest of {num1} and {num2}");
            
            //4.invoking prime method
            int result = prime(num1);
            if (result == 1)
                Console.WriteLine($"{num1} is a prime number");
            else
                Console.WriteLine($"{num1} is not a prime number");

            //3.invoking even or odd method
            even(num2);
            //5.invoking square of a number method
            Square(num1);
            //6.invoking average of two numbers method
            Average(num1, num2);

        }
    }
}