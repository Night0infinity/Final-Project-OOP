using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
[Serializable]
class Horse : Animal
{
    public string CoatColor { get; set; }
    public string Breed { get; set; }

    public Horse(string name, int birthYear, string coatColor, string breed)
        : base(name, birthYear)
    {
        CoatColor = coatColor;
        Breed = breed;
    }

    public override void Print(StreamWriter writer)
    {
        writer.WriteLine($"Horse: {Name}, born in {BirthYear}, coat color: {CoatColor}, breed: {Breed}");
    }
}