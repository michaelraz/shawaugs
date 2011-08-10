using System;
using System.Data;
using System.Linq;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        public IDbConnection connection;
        public bool is_off { get; private set; }

        public Calculator(IDbConnection connection,int number,int number2)
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
            using(connection)
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void shut_off()
        {
            if(Thread.CurrentPrincipal.IsInRole("awesome"))
            {
                is_off = true;
            }
        }
    }
}