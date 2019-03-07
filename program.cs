using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Project3Stoness
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }



        static void Main(string[] args)
        {
            {
                ConsoleKeyInfo cki;
                do
                {
                    Console.WriteLine(); ///for draw map
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("           HH  HH    ||              ||                                              ");
                    Console.WriteLine("           HH  HH    ||              ||                     ");
                    Console.WriteLine("           HHHHHH    ||              ||                                  ");
                    Console.WriteLine("           HH  HH    ||              ||                                                  ");
                    Console.WriteLine("           HH  HH    ||              ||                                                      ");
                    Console.WriteLine("       ______________||______________||________________    ");
                    Console.WriteLine("       ______________||______________||________________  ");
                    Console.WriteLine("                     ||     CCCC     ||                                                 ");
                    Console.WriteLine("                     ||    CC        ||                                            MADE BY ");
                    Console.WriteLine("                     ||   CC         ||                                         BERKANT ALKAN           ");
                    Console.WriteLine("                     ||    CC        ||                                         YASIN CIRALI  ");
                    Console.WriteLine("                     ||     CCCC     ||                                         MUSTAFA CAGATAY ONAL      ");
                    Console.WriteLine("        _____________||______________||________________                                      ");
                    Console.WriteLine("        _____________||______________||________________               HEY HUMAN , YOU WANNA TRY TO BEAT ME??      ");
                    Console.WriteLine("                     ||              ||   HH  HH                        I DON'T THINK SO AHAAHAHAHAH ");
                    Console.WriteLine("                     ||              ||   HH  HH ");
                    Console.WriteLine("                     ||              ||   HHHHHH                            PRESS P FOR THE BEAT ME..     ");
                    Console.WriteLine("                     ||              ||   HH  HH");
                    Console.WriteLine("                     ||              ||   HH  HH");


                    while (Console.KeyAvailable == false)
                        Thread.Sleep(250);

                    cki = Console.ReadKey(true);
                    Console.WriteLine("Press p", cki.Key);
                } while (cki.Key != ConsoleKey.P);
                Console.Clear();
            }
            here4:
            Random rnd3 = new Random();// baslangıc sırası
            Random rnd1 = new Random();
            char[,] place = new char[12, 12];
            int x = 2;
            int y = 2;
            place[0, 0] = '+';
            place[0, 11] = '+';
            place[11, 0] = '+';
            place[11, 11] = '+';
            for (int i = 1; i < place.GetLength(0) - 1; i++)
            {
                place[0, i] = '-';
            }
            for (int i = 1; i < place.GetLength(0) - 1; i++)
            {
                place[11, i] = '-';
            }
            for (int i = 1; i < place.GetLength(0) - 1; i++)
            {
                place[i, 0] = '-';
            }
            for (int i = 1; i < place.GetLength(0) - 1; i++)
            {
                place[i, 11] = '-';
            }

            for (int i = 2; i < 10; i++)
                for (int k = 2; k < 10; k++)
                {
                    place[i, k] = '.';
                }
            for (int i = 0; i < 8; i++)
            {
                int num1 = rnd1.Next(2, 10);
                int num2 = rnd1.Next(2, 10);
                if (place[num1, num2] == '#')
                {
                    i--;
                }
                place[num1, num2] = '#';



            }
            int xx = 2;
            int yy = 1;
            for (int i = 0; i < place.GetLength(0); i++)
            {
                for (int j = 0; j < place.GetLength(1); j++)
                {
                    Console.SetCursorPosition(xx, yy);
                    Console.Write(place[i, j]);
                    xx = xx + 2;
                }
                yy = yy + 1;
                xx = 2;
            }


            int start = rnd3.Next(0, 2);
            int baslangic = start;

            xx = 6;
            yy = 3;

            bool wincondition = false;
            Console.SetCursorPosition(2, 1);//cursar ı en baş köşedeki yere getirmek için

            here3:
            while (wincondition == false)
            {

                while (start == 0)//insan
                {
                    ConsoleKeyInfo humancontrol;
                    here:
                    do
                    {
                        humancontrol = Console.ReadKey(true);
                        if (humancontrol.Key == ConsoleKey.RightArrow && xx >= 0 && xx <= 18)
                        {
                            Console.SetCursorPosition(xx + 2, yy);
                            xx += 2;
                            x += 1;
                        }
                        else if (humancontrol.Key == ConsoleKey.LeftArrow && xx >= 8 && xx <= 22)
                        {
                            Console.SetCursorPosition(xx - 2, yy);
                            xx -= 2;
                            x -= 1;
                        }
                        else if (humancontrol.Key == ConsoleKey.UpArrow && yy >= 4 && yy <= 12)
                        {
                            Console.SetCursorPosition(xx, yy - 1);
                            yy -= 1;
                            y -= 1;
                        }
                        else if (humancontrol.Key == ConsoleKey.DownArrow && yy >= 0 && yy <= 9)
                        {
                            Console.SetCursorPosition(xx, yy + 1);
                            yy += 1;
                            y += 1;
                        }

                    } while (humancontrol.Key != ConsoleKey.Spacebar);//human sapace e basana kadar cursor ın yerini değiştirme hakkı var

                    for (int i = 2; i < 10; i++)//eğer # üzerindeyken space e basarsa komut girmemiş sayılıyor,cursor ın yerini hala değiştirebilir
                    {
                        if (place[y, x] != '.')
                            goto here;
                        else
                            start = 1;
                    }
                    Console.SetCursorPosition(xx, yy);
                    WriteAt("H", xx, yy);
                    place[y, x] = 'H';
                    //wincondition
                    for (int i = 2; i < place.GetLength(0) - 2; i++)
                        for (int k = 2; k < place.GetLength(0) - 2; k++)
                        {


                            if (place[i, k] == 'H' && place[i + 1, k] == 'H' && place[i + 2, k] == 'H')//ÜST
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEST ME :((");

                                goto here3;
                            }

                            if (place[i, k] == 'H' && place[i - 1, k] == 'H' && place[i - 2, k] == 'H')//ALT
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }

                            if (place[i, k] == 'H' && place[i, k + 1] == 'H' && place[i, k + 2] == 'H')//yan
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }

                            if (place[i, k] == 'H' && place[i, k - 1] == 'H' && place[i, k - 2] == 'H')// SOL yan
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }

                            if (place[i, k] == 'H' && place[i + 1, k - 1] == 'H' && place[i + 2, k - 2] == 'H')// SOL ÜST  CAPRAZ
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }

                            if (place[i, k] == 'H' && place[i - 1, k + 1] == 'H' && place[i - 2, k + 2] == 'H')// hangi   CAPRAZ??
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }
                            if (place[i, k] == 'H' && place[i + 1, k + 1] == 'H' && place[i + 2, k + 2] == 'H')
                            {
                                wincondition = true;
                                Console.SetCursorPosition(0, 16);
                                Console.WriteLine("HUMAN, YOU BEAT ME :((");

                                goto here3;
                            }


                        }


                }//insan icin
                here2:
                while (start == 1)

                {

                    if (baslangic == 1)//comp ilk baslarsa
                    {

                        int xnumber = rnd1.Next(2, 11);
                        int ynumber = rnd1.Next(2, 11);

                        if (place[ynumber, xnumber] == '.')
                        {
                            WriteAt("C", (2 * xnumber) + 2, ynumber + 1);
                            place[ynumber, xnumber] = 'C';
                            start = 0;
                            baslangic = 2;

                        }
                        else
                            goto here2;

                    }//comp ilk baslarsa
                    if (baslangic == 2 && start == 1)//comp ilk baslayip kazandırcak hamle
                    {
                        for (int i = 2; i < place.GetLength(0) - 1; i++)
                            for (int k = 2; k < place.GetLength(1) - 1; k++)
                            {
                                if (place[i, k] == 'C')
                                {
                                    for (int j = i - 1; j < i + 2; j++)//comp atama
                                        for (int l = k - 1; l < k + 2; l++)
                                        {
                                            if (place[j, l] == '.')
                                            {
                                                place[j, l] = 'C';
                                                WriteAt("C", ((2 * l) + 2), j + 1); //formulu y+1,2(x)  +2
                                                start = 0;
                                                baslangic = 3;
                                                goto here2;
                                            }


                                        }
                                }
                            }
                    }
                    pcilkbasladıkazansındiye:
                    if (start == 1) //kazanma hamlesi 
                    {
                        for (int i = 2; i < place.GetLength(0) - 1; i++)
                            for (int k = 2; k < place.GetLength(1) - 1; k++)
                            {
                                if (place[i, k] == 'C')
                                {
                                    if (place[i - 1, k - 1] == 'C' && start == 1)   //sol üst
                                    {
                                        if (place[i - 2, k - 2] == '.')
                                        {
                                            place[i - 2, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i - 1);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i, k - 1] == 'C' && start == 1)   //solyan
                                    {
                                        if (place[i, k - 2] == '.')
                                        {
                                            place[i, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i + 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i, k + 1] == 'C' && start == 1)  //sag yan
                                    {
                                        if (place[i, k + 2] == '.')
                                        {
                                            place[i, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i + 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i + 1, k + 1] == 'C' && start == 1) //sag alt
                                    {
                                        if (place[i + 2, k + 2] == '.')
                                        {
                                            place[i + 2, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i + 1, k] == 'C' && start == 1)  //üst
                                    {
                                        if (place[i + 2, k] == '.')
                                        {
                                            place[i + 2, k] = 'C';
                                            WriteAt("C", 2 * (k) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 1, k] == 'C' && start == 1) //üst
                                    {
                                        if (place[i - 2, k] == '.')
                                        {
                                            place[i - 2, k] = 'C';
                                            WriteAt("C", 2 * (k) + 2, i - 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i - 1, k + 1] == 'C' && start == 1)
                                    {
                                        if (place[i - 2, k + 2] == '.')
                                        {
                                            place[i - 2, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i - 1);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i + 1, k - 1] == 'C' && start == 1)
                                    {
                                        if (place[i + 2, k - 2] == '.')
                                        {
                                            place[i + 2, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 2, k - 2] == 'C' && start == 1)   //sol üst
                                    {
                                        if (place[i - 1, k - 1] == '.')
                                        {
                                            place[i - 1, k - 1] = 'C';
                                            WriteAt("C", 2 * (k - 1) + 2, i);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 2, k + 2] == 'C' && start == 1)
                                    {
                                        if (place[i - 1, k + 1] == '.')
                                        {
                                            place[i - 1, k + 1] = 'C';
                                            WriteAt("C", 2 * (k + 1) + 2, i);
                                            start = 0;
                                        }
                                    }


                                }
                            }
                    }
                    if (start == 1) //insanın kazanmasını engellemek
                    {
                        for (int i = 2; i < place.GetLength(0) - 1; i++)
                            for (int k = 2; k < place.GetLength(1) - 1; k++)
                            {
                                if (place[i, k] == 'H')
                                {
                                    if (place[i - 1, k - 1] == 'H' && start == 1)   //sol üst
                                    {
                                        if (place[i - 2, k - 2] == '.')
                                        {
                                            place[i - 2, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i - 1);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i, k - 1] == 'H' && start == 1)   //solyan
                                    {
                                        if (place[i, k - 2] == '.')
                                        {
                                            place[i, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i + 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i, k + 1] == 'H' && start == 1)  //sag yan
                                    {
                                        if (place[i, k + 2] == '.')
                                        {
                                            place[i, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i + 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i + 1, k + 1] == 'H' && start == 1) //sag alt
                                    {
                                        if (place[i + 2, k + 2] == '.')
                                        {
                                            place[i + 2, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i + 1, k] == 'H' && start == 1)  //üst
                                    {
                                        if (place[i + 2, k] == '.')
                                        {
                                            place[i + 2, k] = 'C';
                                            WriteAt("C", 2 * (k) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 1, k] == 'H' && start == 1) //alt
                                    {
                                        if (place[i - 2, k] == '.')
                                        {
                                            place[i - 2, k] = 'C';
                                            WriteAt("C", 2 * (k) + 2, i - 1);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i - 1, k + 1] == 'H' && start == 1)
                                    {
                                        if (place[i - 2, k + 2] == '.')
                                        {
                                            place[i - 2, k + 2] = 'C';
                                            WriteAt("C", 2 * (k + 2) + 2, i - 1);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i + 1, k - 1] == 'H' && start == 1)
                                    {
                                        if (place[i + 2, k - 2] == '.')
                                        {
                                            place[i + 2, k - 2] = 'C';
                                            WriteAt("C", 2 * (k - 2) + 2, i + 3);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 2, k - 2] == 'H' && start == 1)   //sol üst
                                    {
                                        if (place[i - 1, k - 1] == '.')
                                        {
                                            place[i - 1, k - 1] = 'C';
                                            WriteAt("C", 2 * (k - 1) + 2, i);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 2, k] == 'H' && start == 1)//dikey olarak H lerin arasında bi boşluk var ise arasında C koyuyor
                                    {
                                        if (place[i - 1, k] == '.')
                                        {
                                            place[i - 1, k] = 'C';
                                            WriteAt("C", (2 * k) + 2, i);
                                            start = 0;
                                        }

                                    }
                                    else if (place[i, k - 2] == 'H' && start == 1)//yatay olarak H lerin arasında bi boşluk var ise arasına C koyuyor 
                                    {
                                        if (place[i, k - 1] == '.')
                                        {
                                            place[i, k - 1] = 'C';
                                            WriteAt("C", ((2 * (k - 1)) + 2), i + 1);
                                            start = 0;
                                        }
                                    }
                                    else if (place[i - 2, k + 2] == 'H' && start == 1)
                                    {
                                        if (place[i - 1, k + 1] == '.')
                                        {
                                            place[i - 1, k + 1] = 'C';
                                            WriteAt("C", 2 * (k + 1) + 2, i);
                                            start = 0;
                                        }
                                    }
                                    else if (start == 1 && baslangic == 3 && place[i, k] == 'C')
                                    {
                                        for (int j = i - 1; j < i + 2; j++)//comp atama
                                            for (int l = k - 1; l < k + 2; l++)
                                            {
                                                if (place[j, l] == '.')
                                                {
                                                    place[j, l] = 'C';
                                                    WriteAt("C", 2 * (l) + 2, j + 1);
                                                    start = 0;
                                                    goto pcilkbasladıkazansındiye;

                                                }
                                            }
                                    }

                                }
                            }
                    }

                    if (start == 1)//sıra computerda
                    {
                        for (int i = 0; i < place.GetLength(0); i++)
                            for (int k = 0; k < place.GetLength(1); k++)
                            {
                                if (place[i, k] == 'H')
                                {
                                    for (int j = i - 1; j < i + 2; j++)//comp atama
                                        for (int l = k - 1; l < k + 2; l++)
                                        {
                                            if (place[j, l] == '.')
                                            {
                                                place[j, l] = 'C';
                                                WriteAt("C", ((2 * l) + 2), j + 1); //formulu y+1,2(x)  +2
                                                start = 0;
                                                goto here2;

                                            }


                                        }
                                    /*
                            if (place[i-1,k-1]=='.')
                            {
                                place[i-1,k-1]='C';
                                WriteAt("C", ((2*(k-1))+2),i);
                                break;
                            }
                            if (place[i , k - 1] == '.')
                            {
                                place[i , k - 1] = 'C';
                                WriteAt("C", ((2 * (k - 1)) + 2), i+1);
                                break;
                            }*/

                                }
                            }

                    }
                }
                for (int i = 2; i < place.GetLength(0) - 2; i++)
                    for (int k = 2; k < place.GetLength(1) - 2; k++)
                    {
                        if (place[i, k] == 'C' && place[i + 1, k] == 'C' && place[i + 2, k] == 'C')//ÜST
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }


                        if (place[i, k] == 'C' && place[i - 1, k] == 'C' && place[i - 2, k] == 'C')//ALT
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }

                        if (place[i, k] == 'C' && place[i, k + 1] == 'C' && place[i, k + 2] == 'C')//YAN
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }

                        if (place[i, k] == 'C' && place[i, k - 1] == 'C' && place[i, k - 2] == 'C')//SOL YAN
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }

                        if (place[i, k] == 'C' && place[i + 1, k - 1] == 'C' && place[i + 2, k - 2] == 'C')//SOL ÜST CAPRAZ
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }

                        if (place[i, k] == 'C' && place[i - 1, k + 1] == 'C' && place[i - 2, k + 2] == 'C')//hangi  CAPRAZ bilmom
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHAHAH I WON AS I SAID");

                            goto here3;
                        }
                        if (place[i, k] == 'C' && place[i + 1, k + 1] == 'C' && place[i + 2, k + 2] == 'C')
                        {
                            wincondition = true;
                            Console.SetCursorPosition(0, 16);
                            Console.WriteLine("AHHAHAH I WON AS I SAID");

                            goto here3;
                        }
                    }










                start = 0;
            }//oyun için


            ConsoleKeyInfo yenidenbaslatma;
            Console.WriteLine("WANNA PLAY AGAIN ? PRESS P");
            yenidenbaslatma = Console.ReadKey();
            if (yenidenbaslatma.Key == ConsoleKey.F5) ;
            {
                Console.Clear();
                goto here4;
            }



        }

    }

}
