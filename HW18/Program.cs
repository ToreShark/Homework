using System.Text;
using HW18.Modules;
using HW18.BL;

namespace HW18;

class Program
{
    /* Pencil */
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Menu menu = new Menu();
        while (true)
        {
            switch (menu.Run())
            {
                case 0:
                    FileManager.SaveOne(InputData());
                    break;
                case 1:
                    ActionCat("Вы покормили кота", 1);
                    break;
                case 2:
                    ActionCat("Вы поиграли с котом", 2);
                    break;
                case 3:
                    ActionCat("Вы вылечили кота", 3);
                    break;
                case 4:
                    NextDay("Следующий день", 4);
                    break;
                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
        }
    }
    public static void ActionCat(string action, int actionIndex)
    {
        string nameCat = UserInput.InputString("Введите имя кота");
        List<Cat> allCats = FileManager.ReadAll();
        bool findCat = false;
        foreach (Cat cat in allCats)
        {
            if (cat.Name.Contains(nameCat))
            {
                System.Console.WriteLine($"{action}: {nameCat}");
                switch (actionIndex)
                {
                    case 1:
                        if (cat.Age <= 5)
                        {
                            cat.Satiety += 7;
                            cat.Mood += 7;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Satiety += 5;
                            cat.Mood += 5;
                        }
                        else
                        {
                            cat.Satiety += 4;
                            cat.Mood += 4;
                        }
                        break;
                    case 2:
                        if (cat.Age <= 5)
                        {
                            cat.Satiety -= 3;
                            cat.Mood += 7;
                            cat.Health += 7;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Satiety -= 5;
                            cat.Mood += 5;
                            cat.Health += 5;
                        }
                        else
                        {
                            cat.Satiety -= 6;
                            cat.Mood += 4;
                            cat.Health += 4;
                        }
                        break;
                    case 3:
                        if (cat.Age <= 5)
                        {
                            cat.Satiety -= 3;
                            cat.Mood -= 7;
                            cat.Health += 7;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Satiety -= 5;
                            cat.Mood -= 5;
                            cat.Health += 5;
                        }
                        else
                        {
                            cat.Satiety -= 6;
                            cat.Mood -= 6;
                            cat.Health += 4;
                        }
                        break;
                }
                findCat = true;
            }
            cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        }
        FileManager.SaveAll(allCats);
        if (!findCat)
        {
            System.Console.WriteLine($"Кота с именем: {nameCat} не существует");
        }
        Console.ReadKey(true);
    }

    public static void NextDay(string action, int actionIndex)
    {
        List<Cat> allCats = FileManager.ReadAll();
        foreach (Cat cat in allCats)
        {
            Random random = new Random();
            cat.Satiety -= random.Next(1, 6);
            cat.Mood += random.Next(-3, 4);
            cat.Health += random.Next(-3, 4);
            cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        }

        FileManager.SaveAll(allCats);
    }
    public static Cat InputData()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Cat cat = new Cat();
        cat.Name = UserInput.InputString("Enter name");
        cat.Age = UserInput.InputInteger("Введи возраст");
        Random random = new Random();
        cat.Health = random.Next(20, 81);
        cat.Mood = random.Next(20, 81);
        cat.Satiety = random.Next(20, 81);
        cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        return cat;
    }
}