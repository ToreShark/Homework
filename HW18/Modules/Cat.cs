using HW18.Interface;

namespace HW18.Modules;

class Cat : ICat
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Health { get; set; }
    public int Mood { get; set; }
    public int Satiety { get; set; }
    public int Level { get; set; }
}
