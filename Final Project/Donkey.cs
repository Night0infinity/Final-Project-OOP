using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
[Serializable]
class Donkey : Animal
{
    public string Species { get; set; }
    public double Height { get; set; }

    public Donkey(string name, int birthYear, string species, double height)
        : base(name, birthYear)
    {
        Species = species;
        Height = height;
    }

    public override void Print(StreamWriter writer)
    {
        writer.WriteLine($"Donkey: {Name}, born in {BirthYear}, species: {Species}, height: {Height}m");
    }
}