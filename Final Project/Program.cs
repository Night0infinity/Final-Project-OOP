using System.Runtime.Serialization.Json;
using System;

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();

        // Reading data from a file
        using (StreamReader reader = new StreamReader("C:\\Users\\lkuru\\OneDrive\\Робочий стіл\\ООП\\Final project\\GenerelInfo.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('/');
                string name = parts[0];
                int birthYear = int.Parse(parts[1]);
                string type = parts[2];
                if (type == "horse")
                {
                    string coatColor = parts[3];
                    string breed = parts[4];
                    animals.Add(new Horse(name, birthYear, coatColor, breed));
                }
                else if (type == "donkey")
                {
                    string species = parts[3];
                    double height = double.Parse(parts[4]);
                    animals.Add(new Donkey(name, birthYear, species, height));
                }
            }
        }

        List <Horse> serial = new List<Horse>();
        serial.Add(new("Jof", 1998, "white", "afro"));
        

        // Sorting animals by birth year
        List<Animal> sortedAnimals = animals.OrderBy(a => a.BirthYear).ToList();

        // Writing sorted animals to file 1
        using (StreamWriter writer = new StreamWriter("C:\\Users\\lkuru\\OneDrive\\Робочий стіл\\ООП\\Final project\\File1.txt"))
        {
            foreach (Animal animal in sortedAnimals)
            {
                animal.Print(writer);
            }
        }

        // Filtering and counting horses and donkeys
        List<Horse> whiteHorses = new List<Horse>();
        List<Donkey> tallDonkeys = new List<Donkey>();
        foreach (Animal animal in animals)
        {
            if (animal is Horse horse && horse.CoatColor == "white")
            {
                whiteHorses.Add(horse);
            }
            else if (animal is Donkey donkey && donkey.Height < 1.5)
            {
                tallDonkeys.Add(donkey);
            }
        }
        // Counter of white horses, and tall donkeys
        int whiteHorseCount = 0;
        int shortDonkeyCount = 0;
        foreach (Animal animal in animals)
        {
            if (animal is Horse horse && horse.CoatColor == "white")
            {
                whiteHorseCount++;
            }
            else if (animal is Donkey donkey && donkey.Height < 1.5)
            {
                shortDonkeyCount++;
            }
        }

        // Writing filtered animals and counts to file 2
        using (StreamWriter writer = new StreamWriter("C:\\Users\\lkuru\\OneDrive\\Робочий стіл\\ООП\\Final project\\File2.txt"))
        {
            writer.WriteLine("White horses:");
            foreach (Horse horse in whiteHorses)
            {
                horse.Print(writer);
            }
            writer.WriteLine("Tall donkeys:");
            foreach (Donkey donkey in tallDonkeys)
            {
                donkey.Print(writer);
            }
            writer.WriteLine("\n");
            writer.WriteLine($"Number of white horses: {whiteHorseCount}");
            writer.WriteLine($"Number of donkeys shorter than 1.5m: {shortDonkeyCount}");
        }
        // Serialization
        Stream file = new FileStream("Animal.json", FileMode.Create);
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Horse>));
        ser.WriteObject(file, serial);

        // DeSerealization
        file.Position = 0;
        List<Horse> person4 = (List<Horse>)ser.ReadObject(file);
        Console.Write("Json : " + person4);
        Console.WriteLine("\n________________________________________________________________");
    }
}
