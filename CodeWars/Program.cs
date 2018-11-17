using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static void Main( string[] args )
        {
            //Console.WriteLine(
            //    Kata.QueueTime( new[] { 1, 2, 3, 4 }, 1 )
            //);

            Console.WriteLine(
                Kata.QueueTime( new int[] { 2, 2, 3, 3, 4, 4 }, 2 )
                );

            Console.ReadLine();
        }
    }

    public class Kata
    {
        public static long QueueTime( int[] customers, int n )
        {
            var registers = new List<int>( Enumerable.Repeat( 0, n ) );

            foreach ( int cust in customers )
            {
                registers[registers.IndexOf( registers.Min() )] += cust;
            }
            return registers.Max();
        }
    }
}
