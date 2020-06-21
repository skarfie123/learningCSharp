using System;
using System.Collections.Generic;

namespace learningCSharp
{
    class Program
    {
        static void WorkingWithIntegers()
        {
            int a = 18;
            int b = 6;

            // addition
            int c = a + b;
            Console.WriteLine(c);

            // subtraction
            c = a - b;
            Console.WriteLine(c);

            // multiplication
            c = a * b;
            Console.WriteLine(c);

            // division
            c = a / b;
            Console.WriteLine(c);
        }
        static void OrderPrecedence()
        {
            int a = 5;
            int b = 4;
            int c = 2;
            int d = a + b * c;
            Console.WriteLine(d);

            d = (a + b) * c;
            Console.WriteLine(d);

            d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine(d);

            int e = 7;
            int f = 4;
            int g = 3;
            int h = (e + f) / g;
            Console.WriteLine(h);
        }
        static void IntegerPrecision()
        {
            int a = 7;
            int b = 4;
            int c = 3;
            int d = (a + b) / c;
            int e = (a + b) % c;
            Console.WriteLine($"quotient: {d}");
            Console.WriteLine($"remainder: {e}");

            int max = int.MaxValue;
            int min = int.MinValue;
            Console.WriteLine($"The range of integers is {min} to {max}");

            int what = max + 3;
            Console.WriteLine($"An example of overflow: {what}");
        }
        static void Double()
        {
            double a = 5;
            double b = 4;
            double c = 2;
            double d = (a + b) / c;
            Console.WriteLine(d);

            double e = 19;
            double f = 23;
            double g = 8;
            double h = (e + f) / g;
            Console.WriteLine(h);

            double max = double.MaxValue;
            double min = double.MinValue;
            Console.WriteLine($"The range of double is {min} to {max}");

            double third = 1.0 / 3.0;
            Console.WriteLine(third);
        }
        static void Decimal()
        {
            decimal min = decimal.MinValue;
            decimal max = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal type is {min} to {max}");

            double a = 1.0;
            double b = 3.0;
            Console.WriteLine(a / b);

            decimal c = 1.0M;
            decimal d = 3.0M;
            Console.WriteLine(c / d);
        }
        static void Loops()
        {
            int counter = 0;
            while (counter < 10)
            {
                Console.Write(counter);
                counter++;
            }
            Console.WriteLine();
            //do minimum one time
            counter = 0;
            do
            {
                Console.Write(counter);
                counter++;
            } while (counter < 10);
            Console.WriteLine();
            for (int row = 1; row < 4; row++)
            {
                for (char column = 'a'; column < 'd'; column++)
                {
                    Console.Write($"({row}, {column}) ");
                }
                Console.WriteLine();
            }
        }
        static void WorkingWithStrings()
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" }; //using System.Collections.Generic for List
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.Write(name.ToUpper() + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");

            Console.WriteLine($"The list has {names.Count} people in it");

            var index = names.IndexOf("Felipe");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            index = names.IndexOf("Not Found");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");

            }

            names.Sort();
            foreach (var name in names)
            {
                Console.Write(name.ToUpper() + " ");
            }
            Console.WriteLine();
        }
        static void BankingClasses()
        {
            var account = new BankAccount("<name>", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(">>>Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(">>>Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());
        }
        static void ValueTypes()
        {
            ///Simple Types
            //   int, byte, char, double, bool, etc.

            ///Enum Types
            ErrorCode none = ErrorCode.None;
            ErrorCode uk = ErrorCode.Unknown;
            Console.WriteLine($"{none}:{(int)none}, {uk}:{(int)uk}");
            Console.WriteLine($"Get ErrorCode from int (if exists): 1:{(ErrorCode)1}, 10:{(ErrorCode)10}");

            ///Struct Types
            Coords coords = new Coords();
            Coords home = new Coords("Home", 5, 5);
            Console.WriteLine(coords);
            Console.WriteLine(home);

            ///Nullable Types
            //    T? can be null as well as any value that T can be
            bool? b1 = null; // can be null, false, true
            bool b2 = false; // can be false, true but not null
            System.Console.WriteLine($"b1 {b1}, b2{b2}");
            int? a = 42;
            if (a is int valueOfA) //use `is` to both examine and get value
            {
                Console.WriteLine($"a is {valueOfA}");
            }
            else
            {
                Console.WriteLine("a does not have a value");
            }
            if (a.HasValue) // or (a != null)
            {
                Console.WriteLine($"a is {a.Value}");
            }
            else
            {
                Console.WriteLine("a does not have a value"); // a.Value here would throw InvalidOperationException
            }
            int c = a ?? -1; // conversion, -1 is default if it was null
            c = a.GetValueOrDefault(-1); // if no argument, gives default value of the type
            c = (int)a; // throws InvalidOperationException if null
            Console.WriteLine($"int? is {typeof(int?)} {(IsNullable(typeof(int?)) ? "nullable" : "non nullable")} value type");
            Console.WriteLine($"int is {(IsNullable(typeof(int)) ? "nullable" : "non-nullable")} value type");
            bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;

            Console.WriteLine(IsOfNullableType(a));  // output: True
            Console.WriteLine(IsOfNullableType(c));  // output: False
            bool IsOfNullableType<T>(T o) // multiple type input
            {
                var type = typeof(T);
                return Nullable.GetUnderlyingType(type) != null; // false if null, null if not a nullable
            }

            ///Tuples
            var unnamed = ("one", "two");
            var named = (first: "one", second: "two");
            var first = 12.5;
            var second = 5;
            var accumulation = (first, second, 3); // tuple projection initializers - named by variable name
            System.Console.WriteLine($"{unnamed.Item1} {named.Item1} {named.first} {accumulation.first} {accumulation.Item3}");
            (string a, string b)? nullableTuple = named;
            (int, (int, int)) nestedTuple = (1, (2, 3));
            Console.WriteLine(nestedTuple == (1, (2, 3)));
            (double, long, long) conversion = accumulation;
            //Various ways to deconstruct
            // (int count, double sum, double sumOfSquares) = ComputeSumAndSumOfSquares(sequence);
            // (long count, var sum, var sumOfSquares) = ComputeSumAndSumOfSquares(sequence);
            // var (sum, sumOfSquares, count) = ComputeSumAndSumOfSquares(sequence);
            // (sum, sumOfSquares, count) = ComputeSumAndSumOfSquares(sequence); // if already existing variables


            ///Boxing and Unboxing
            //    a value type can be boxed into type `object` or any interface that the value type implements
            //    this is an expensive process
            int i = 123;
            object o = i; // boxing.
            int j = (int)o;  // unboxing (casting)
        }
        enum ErrorCode : ushort //default is int if not specified
        {
            None, // by default starts at 0 and counts up
            Unknown,
            ConnectionLost = 100,
            OutlierReading = 200
        }
        public struct Coords
        {
            public Coords(string name, double x, double y)
            {
                NAME = name;
                X = x;
                Y = y;
            }

            public string NAME { get; }
            public double X { get; }
            public double Y { get; }

            public override string ToString() => $"{NAME}: ({X}, {Y})";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WorkingWithIntegers();
            OrderPrecedence();
            IntegerPrecision();
            Double();
            Decimal();
            Loops();
            WorkingWithStrings();
            BankingClasses();

            //Types
            ValueTypes();
        }
    }
}
