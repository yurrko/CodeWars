using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine(
                Kata.QueueTime( new[] { 1, 2, 3, 4 }, 1 )
            );

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
            var timeLong = 0;

            var all = customers.ToList();
            var q = new List<int>();
            var minNum = int.MaxValue;

            int CalculateMin( List<int> numbers )
            {
                return numbers.Min();
            }

            List<int> Refresh( List<int> allLongs, int minQ )
            {
                for ( int i = 0; i < n; i++ )
                {
                    if ( i < allLongs.Count )
                        allLongs[i] -= minQ;
                }

                for ( int j = 0; j < n; j++ )
                {
                    if ( j < allLongs.Count )
                        if ( allLongs[j] == 0 ) allLongs.RemoveAt( j );
                }

                return allLongs;
            }

            while ( all.Count > 0 )
            {
                for ( int i = 0; i < n; i++ )
                {
                    if ( i < all.Count )
                        q.Add( all[i] );
                }

                minNum = CalculateMin( q );
                timeLong += minNum;
                q.Clear();
                all = Refresh( all, minNum );
            }

            return timeLong;
        }
    }
}
