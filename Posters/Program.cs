using System;

namespace Posters
{
    class Program
    {
        public static int buildingsCount;
        public static string line;
        public static int[,] bxy;
        public static int posterCount;

        static void Main(string[] args)
        {
            buildingsCount = Convert.ToInt32(Console.ReadLine());
            if (buildingsCount > 0)
            {
                posterCount = 1;
                bxy = new int[buildingsCount, 2];
            }
            else posterCount = 0;

            for (int i = 0; i < buildingsCount; i++)
            {
                try
                {
                    readBuidlingDesc(i);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input - type correct building description(Two digits separated by space)");
                    readBuidlingDesc(i);
                }
            }

            int poster = calculatePosters(posterCount, buildingsCount, bxy);
            Console.WriteLine(poster);

            Console.ReadKey(true);
        }

        public static void readBuidlingDesc(int i)
        {
            line = Console.ReadLine();
            string[] xy = line.Split(new char[] { ' ' });
            bxy[i, 0] = Convert.ToInt32(xy[0]);
            bxy[i, 1] = Convert.ToInt32(xy[1]);
        }

        public static int calculatePosters(int posterCount, int buildingsCount, int[,] cxy)
        {
            int poster = posterCount;
            int minTemp = cxy[0, 1];

            for ( int x = 0; x < buildingsCount - 1; x++)
            {
                if (cxy[x + 1, 1] < minTemp)
                {
                    minTemp = cxy[x + 1, 1];
                    poster++;
                }
                if (cxy[x + 1, 1] > cxy[x, 1]) poster++;
                else if (cxy[x + 1, 1] < cxy[x, 1] && (cxy[x + 1, 1] > minTemp))
                {
                    poster++;
                    for (int i = 0; i < x; i++)
                    {
                        if (cxy[x + 1, 1] == cxy[i, 1] & cxy[x + 1, 1] > minTemp)
                        {
                            poster--;
                            i = buildingsCount;
                        }
                    }
                }
            }

            return poster;
        }
    }

}
