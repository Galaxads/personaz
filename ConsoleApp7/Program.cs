using System.Runtime.InteropServices;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько создать персонажей для игры?");
            int pers=Convert.ToInt32(Console.ReadLine());
            Gameperson[] gameperson1 = new Gameperson[pers];
            for (int i = 0; i < gameperson1.Length; i++)// цикл для создания n кол-во персонажей
            {
                gameperson1[i] = new Gameperson();
                ((Gameperson)gameperson1[i]).namepers = gameperson1[i].fio();//Генерация ника
                ((Gameperson)gameperson1[i]).lagery = gameperson1[i].lager();//Генерация лагеря
                gameperson1[i].info("", 1, 1, true, 1);
            }
            for (int i = 0; i < gameperson1.Length; i++)
            {
                Console.WriteLine($"Введите номер персонажа?(Доступно {pers} персонажей)");
                int viborpers=Convert.ToInt32(Console.ReadLine());
                    gameperson1[viborpers].game();
              
                for (int j = 0; j < pers; j++) 
                {
                    for (int f = 0; f < viborpers; f++)
                    {
                        bool itog3 = gameperson1[f].lagery == gameperson1[viborpers].lagery;
                        if (itog3 == false)
                        {
                            gameperson1[f].svedprotivnik();
                        }
                    }
                    int provcoord = gameperson1[viborpers].x + gameperson1[viborpers].y;//формула для подсчета координат
                    int provcoord1= gameperson1[j].x + gameperson1[j].y;
                    bool itog2 = gameperson1[j].lagery == gameperson1[viborpers].lagery;
                    List<int> nomerpers = new List<int>() { };
                    if (provcoord==provcoord1 && itog2==true)
                    {
                        Console.WriteLine("Вы встретили друга");
                        Console.WriteLine($"Вы нашли персонажа под номером {j}");
                        nomerpers.Add(j);
                        gameperson1[viborpers].game();
                    }
                    if (provcoord == provcoord1 && itog2 == false) 
                    {
                        
                        Console.WriteLine("Вы встретили врага");
                        Console.WriteLine($"Вы нашли персонажа под номером {j}");
                        nomerpers.Add(j);
                        gameperson1[viborpers].uron();
                        gameperson1[viborpers].game();
                    }
                    if ( provcoord != provcoord1 )
                    { gameperson1[viborpers].game(); }
                    foreach (var person in nomerpers)
                    {
                        Console.WriteLine(person);
                    }
                }   
            }
        }
    }
}