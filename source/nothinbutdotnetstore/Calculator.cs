using System;
using System.Data;
using System.Linq;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);

            return first + second;
        }

        void ensure_all_are_positive(params int[] numbers)
        {
            if (numbers.All(x => x > 0)) return;
            throw new ArgumentException();
        }

        public void initialize()
        {
            connection.Open();
        }
    }
}