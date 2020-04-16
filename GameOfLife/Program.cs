using System;

namespace GameOfLife
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        private static void Main()
        {
            const int w = 30;
            const int h = 30;

            var u = Spaceship(w, h);

            DrawWorld(u, w, h);
            Console.ReadKey();
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                u = Rebuild(u, w, h);
                DrawWorld(u, w, h);
            }
        }

        private static int[,] CreateRandomWorld(int w, int h)
        {
            var world = new int[w, h];

            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    world[y, x] = Rnd.Next(int.MaxValue) < int.MaxValue * 0.1 ? 1 : 0;

            return world;
        }

        private static int[,] Rebuild(int[,] r, int d, int j)
        {
            for (var x = 0; x < d; x++)
            {
                for (var y = 0; y < d; y++)
                {
                    var lives = 0;
                    for (var dx = x - 1; dx <= x + 1; dx++)
                        for (var dy = y - 1; dy <= y + 1; dy++)
                            lives += r[(dx + d) % d, (dy + d) % d];

                    switch (r[x, y])
                    {
                        case 1 when lives != 2 || lives != 3:
                        {
                            if (lives < 2) r[x, y] = 0;
                            if (lives > 3) r[x, y] = 0;
                            break;
                        }
                        default:
                        {
                            if (lives == 3)
                                r[x, y] = 1;
                            break;
                        }
                    }
                }
            }
            return r;
        }

        private static void DrawWorld(int[,] world, int w, int h)
        {
            for (var x = 0; x < w; x++)
            {
                for (var y = 0; y < h; y++)
                    Console.Write(world[y, x] == 1 ? "@ " : ". ");
                Console.Write(Environment.NewLine);
            }
        }

        private static int[,] Spaceship(int w,int h)
        {
            var u = new int[w, h];

            u[10,10]=0;
            u[10,11]=1;
            u[10,13]=1;
            u[11,10]=1;
            u[12,10]=1;
            u[13,10]=1;
            u[14,10]=1;
            u[14,11]=1;
            u[14,12]=1;
            u[13,13]=1;

            return u;
        }

        private static int[,] GosperGuilderGun(int w, int h)
        {
            var u = new int[w, h];
            u[0, 2] = 1;
            u[0, 3] = 1;
            u[1, 2] = 1;
            u[1, 3] = 1;

            u[8, 3] = 1;
            u[8, 4] = 1;
            u[9, 2] = 1;
            u[9, 4] = 1;
            u[10, 2] = 1;
            u[10, 3] = 1;

            u[16, 4] = 1;
            u[17, 4] = 1;
            u[16, 5] = 1;
            u[18, 5] = 1;
            u[16, 6] = 1;

            u[22, 1] = 1;
            u[22, 2] = 1;
            u[23, 0] = 1;
            u[23, 2] = 1;

            u[24, 0] = 1;
            u[24, 1] = 1;
            u[24, 12] = 1;
            u[26, 12] = 1;
            u[25, 12] = 1;
            u[24, 13] = 1;
            u[25, 14] = 1;

            u[34, 0] = 1;
            u[35, 0] = 1;
            u[34, 1] = 1;
            u[35, 1] = 1;

            u[35, 7] = 1;
            u[36, 7] = 1;
            u[35, 8] = 1;
            u[37, 8] = 1;
            u[35, 9] = 1;

            return u;
        }

        private static int[,] Simpleline(int w, int h)
        {
            var u = new int[w, h];

            u[5,10] = 1;
            u[6,10] = 1;
            u[7,10] = 1;
            u[8,10] = 1;
            u[9,10] = 1;
            u[10,10] = 1;
            u[11,10] = 1;
            u[12,10] = 1;
            u[13,10] = 1;
            u[14,10] = 1;

            return u;
        }
    }
}