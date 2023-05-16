using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
[Serializable]
abstract class Animal
{
    public string Name { get; set; }
    public int BirthYear { get; set; }

    public Animal(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }

    public abstract void Print(StreamWriter writer);
}