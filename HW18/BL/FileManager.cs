using HW18.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW18.BL;

static class FileManager
{
    private static string fileName = "Cats.json";
    public static void CheckFile()
    {
        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, "{}");
        }
    }

    public static void SaveAll(List<Cat> allCats)
    {
        File.WriteAllText(fileName, "");
        foreach (Cat cat in allCats)
        {
            SaveOne(cat);
        }
    }
    public static void SaveOne(Cat cat)
    {
        string serCat = JsonSerializer.Serialize<Cat>(cat);
        File.AppendAllText(fileName, serCat + "\n");

    }
    public static List<Cat> ReadAll()
    {
        string[] allCatsString = File.ReadAllLines(fileName);
        List<Cat> allCats = new List<Cat>();
        foreach (string cat in allCatsString)
        {
            Cat? catDesir = JsonSerializer.Deserialize<Cat>(cat);
            if (catDesir != null)
            {
                allCats.Add(catDesir);
            }
        }
        return allCats;
    }
    public static void ReadOne()
    {
        // TODO: Прочитать из файла
    }
    public static void Sorting()
    {
        // TODO: Показать таблицу на экране
    }
}
