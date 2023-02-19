using HW18.Modules;


namespace HW18.BL;

static class Display
{
    public static void Show(List<Cat> cats)
    {
        System.Console.WriteLine(" {0, -2} | {1, -15} | {2, -10} | {3, -10} | {4, -10} | {5, -10} | {6, -10} |", "ID", "Имя", "Возраст", "Здоровье", "Настроение", "Сытость", "Уровень");
        int id = 0;
        cats.Sort((x, y) => x.Level.CompareTo(y.Level));
        foreach (Cat cat in cats)
        {
            System.Console.WriteLine(" {0, -2} | {1, -18} | {2, -17} | {3, -18} | {4, -20} | {5, -17} | {6, -17} |", id, cat.Name, cat.Age, cat.Health, cat.Mood, cat.Satiety, cat.Level);
            id++;
        }
    }
}
