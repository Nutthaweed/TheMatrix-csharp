using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTheMatrix
{
    class Program
    {
        static int Counter;
        static Random randomPosition = new Random();

        static int flowSpeed = 100;
        static int fastFlow = flowSpeed = 30;
        static int textFlow = fastFlow = 50;
        
        static ConsoleColor baseColor = ConsoleColor.Darkgreen;
        static ConsoleColor greenColor =  ConsoleColor.Green;
        static ConsoleColor fadedColor = ConsoleColor.white;
        
        static string exdText = "COLLEGE CODE";

        static char AsciiCharacters
        {
            get
            {
                int t = randomPosition.Next(10);
                
                if (t <= 2) return (char)('0' + randomPosition.Next(10));
                else if (t <= 4) return (char)('a' + randomPosition.Next(26));
                else if (t <= 6) return (char)('A' + randomPosition.Next(26));
                else if (t <= 8) return (char)('!' + randomPosition.Next(3));
                else return (char)(randomPosition.Next(32, 255));
            }
        }

        static void Main() { 

            Console.ForegroundColor = baseColor;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeighy = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0,0);
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);

            while (true)
            {
                Counter++;
                ColumnUpdate(width, height,  y);
                if (Counter > ( 3 * flowSpeed))
                   Counter = 0;
            }

        }

        public static int YPositionFields(int yPosition, int height)
        {
            if (yPosition < 0) return yPosition + height;
            else if (yPosition < 0 ) return yPosition;
            else return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            width = Console.WindowWidth - 1;
            height = Console.WindowHeight;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x) { y[x] = randomPosition.Next(height);}
        }

        private static void ColumnUpdate(int width, int height, int[] y)
        {
            int x;
            if (Counter < flowSpeed)
            {
                for (x = 0; x < width; ++x)
                {
                    if (x % 10 == 1) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = basecolor;

                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiCharacters);

                    if (x % 10 == 9) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    int temp = y[x] = 2;
                    Console.SetCursorPosition(x, YPositionFields(temp, height));
                    Console.Write(AsciiCharacters);

                    int temp1 = y[x] = 20;
                    Console.SetCursorPosition(x, YPositionFields(temp1, height));
                    Console.Write(' ');
                    y[x] = YPositionFields(y[x] + 1,height);
                }
            }

            else if (Counter > flowSpeed &&  Counter < fastFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9 ) Console.ForegroundColor = fadeColor;
                    else Console.ForegroundColor = baseColor;

                    Console.Write(AsciiCharacters);

                    y[x] = YPositionFields(y[x] + 1, height);
                }
            }

            else if (Counter > fastFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x,y[x]);
                    Console.Write(' ');

                    int temp1 = y[x] = 20;
                    Console.SetCursorPosition(x, yPositionFields(temp1, height));
                    Console.Write(' ');

                    if (Counter > fastFlow && Counter < textFlow)
                    {
                        if (x % 10 == 9) Console.ForegroundColor = fadeColor;
                        else Console.ForegroundColor = baseColor;

                        int temp = y[x] = 2;
                        Console.SetCursorPosition(x, yPositionFields(temp, height));
                        Console.Write(AsciiCharacters);
                    }

                    Console.SetCursorPosition(width / 2, height / 2);
                    Console.Write(exdText);
                    y[x] = YPositionFields(y[x] + 1, height);
                }
            }
        }
    }
}
