using System;
namespace Kursovaya
{
    public class Task1
    {
        public int F(int n)
        {
            if (n <= 1) return 1;
            return F(n - 1) + F(n - 2);
        }
    }
}

