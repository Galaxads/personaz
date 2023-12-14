using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

internal class Gameperson
{
    public string namepers = "";
    public int x;
    public int y;
    public bool lagery;
    public int life;
    

    public void info(string namepers, int x, int y, bool lagery, int life)
    {
       
    
        namepers = fio() ;
        x = 1;
        y = 1;
        Random rnd = new Random();//Рандомайзер для кол-во здоровья
        life = rnd.Next(70, 150);
        Random coordx = new Random();//Рандомайзер для координаты x
        x = coordx.Next(-5, 5);
        Random coordy = new Random();//Рандомайзер для координаты y
        y = coordx.Next(-5, 5);
        lagery = lager();
        this.x = x;
        this.y = y;
        this.lagery = lagery;
        this.life = life;
        this.namepers = namepers;
        
    }
    public void print()
    {
       
        
        string nazvanielager = "";
        switch (this.lagery)
        {
            case (true):
                nazvanielager = "Друг"; break;
            case (false):
                nazvanielager = "Враг"; break;
        }
        Console.WriteLine($"Характеристики персонажа:\nИмя:{namepers}\nКоординаты по х:{x}\nКоординаты по у:{y}\nЛагерь:{nazvanielager}\nКоличество жизней:{life}");
    }
    public void movex(int x)
    {
        Console.WriteLine("Пойти налево или направо?");
        string otvet = Console.ReadLine();
        int coordx = this.x;
        switch (otvet)
        {
            case "Направо":
                if ( coordx < 5)
                {
                    coordx++;
                }
                else
                {
                    Console.WriteLine("Вы достигли границы карты");
                }
                this.x = coordx;
                break;
            case "Налево":
                if ( -5<coordx)
                {
                    coordx--;
                }
                else
                {
                    Console.WriteLine("Вы достигли границы карты");
                }
                this.x = coordx;
                break;
        }
    }
    public void movey(int y)
    {
        Console.WriteLine("Пойти вперед или вернуться назад?");
        string? otvet = Console.ReadLine();
        int coordx1 = this.y;
        switch (otvet)
        {
            case "Вперед":
                if ( coordx1 < 5 )
                {
                    coordx1++;
                }
                else
                {
                    Console.WriteLine("Вы достигли границы карты");
                }
                this.y = coordx1;
                break;
            case "Назад":
                if (-5<coordx1)
                {
                    coordx1--;
                }
                else
                {
                    Console.WriteLine("Вы достигли границы карты");
                }
                this.y = coordx1;break;
                
        }
    }
    public void del()
    {
        if (this.life < 0)
        {
            Console.WriteLine("Персонаж больше не доступен");
            Console.WriteLine("Выберите другого персонажа");
        }
    }
    public string fio()
    {
        Random nmd = new Random();
        string[] ime = { "Rufus", "Klayd", "Barret", "Soyp", "Solid", "Djonatan", "Victor", "Vesker", "Rin", "Ask" };
        string[] familia = { "Heygs", "Prays", "Mars", "Tallin", "Maggil", "Haynz", "Mons", "Lens", "Zenti", "Vans" };
        int mIndex = nmd.Next(ime.Length);
        int fIndex = nmd.Next(familia.Length);
        return this.namepers = ime[mIndex] + " " + familia[fIndex];
            
    }
    public bool lager()
    {
       
        var random = new Random();
        for (int i = 0; i < 1; i++)
        {
            lagery = random.Next(2) == 1;//Если 1,то True,иначе False
        }            
        return lagery;
    }                
    public void uron()//урон
    {                            
        Random rnd = new Random();//Рандомайзер для кол-во урона
        int damag = rnd.Next(10, this.life);
        int hp=this.life;
        Console.WriteLine($"Урон который вы можете нанести {damag}");
        Console.WriteLine("Вы встретили врага");
        svedprotivnik();
       /* for (int i = 0;hp<0||hp2<0;i++)
        {
          hp-=damag2;
           Console.WriteLine(hp);
            hp2 -= damag;
        }*/
        
    }
    public void svedprotivnik()
    {
        Console.WriteLine($"координаты по x({this.x})\nкоординаты по y({this.y})");
    }
    public void doc() //лечение 
    {
        int colvohilling=0;
        if (this.life > 0)
        {
            Console.WriteLine("Вы нашли лекарство");
            colvohilling++;
        }
        if (colvohilling> 0)
        {
            Console.WriteLine("Восстановить жизни?");
            string? otvet=Console.ReadLine();
            switch (otvet) 
            {
                case "Да":
                    this.life = this.life + 25;colvohilling-- ;break;
                case "Нет":
                    Console.WriteLine("Ничего не произошло"); break;
                case " ":
                    Console.WriteLine("Ничего не произошло");  break;
                
            }
        }
    }

    public void vost()//полное восстановление
    {
        this.life++;
    }
    public void game()
    {
        if (this.life > 0)
        {           
            int pobeda = 0;
            Console.WriteLine($"Вы {namepers} и ваша цель уничожить всех врагов.");
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Вы можете выполнить несколько действий:\n1)Сменить имя персонажа\n2)Сменить лагерь персонажа\n3)Начать движение по карте\n4)Восстановить хп\n5)Сменить персонажа\n6)Вывести информацию о персонаже\nДля выполнения действия введите новую цифру"); 
                int vibor=Convert.ToInt32( Console.ReadLine() );
                viborpers(vibor);
                if (vibor == 5)
                { return; }//возвращение к индексам массива
                if (vibor == 3)
                { return; }//возвращение к индексам массива
                               
            }
        }
        else
        {
          Console.WriteLine("Вы не можете играть за этого персонажа");  
        }    
    }
    private void viborpers(int vibor)
    {
      switch (vibor) 
      {
            case 1:
                Console.WriteLine("Введите новое имя персонажа");
                this.namepers = Console.ReadLine();break;
            case 2:
                if (this.lagery==true) 
                { this.lagery = false; }
                else { this.lagery = true;}
                break;
            case 3:
                Console.WriteLine($"Куда идти?(по оси х/y).Ваши текущие координты х:{x} y:{y}");
                string otvet = Console.ReadLine();
                switch (otvet)
                {
                    case "X":
                        movex(this.x); break;
                    case "Y":
                        movey(this.y); break;     
                        
                }
                break;
            case 4:
             doc();break;   
            case 5:
                return;
            case 6:
              print();break;
            case 7:
                svedprotivnik(); break;
        }
    }
}


 

 

