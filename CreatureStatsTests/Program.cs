using ArkSaveEditor;
using ArkSaveEditor.World;
using ArkSaveEditor.World.WorldTypes;
using System;
using System.Linq;

namespace CreatureStatsTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            ArkImports.ImportContent("imports\\");
            ArkWorld world = new ArkWorld("save\\", "Extinction", @"C:\Program Files (x86)\Steam\steamapps\common\ARK\ShooterGame\SavedV\Config\WindowsServer\", null, true);
            Console.WriteLine("World loaded.");

            RunTestNamed(world, "Blake", "Yutyrannus", 2300.8f, 3091.2f, 4200f, 644.8f);
            RunTestNamed(world, "Kato", "Rock Drake", 2268.8f, 1578.4f, 3120f, 642.8f);

            Console.WriteLine("Tests completed.");
            Console.ReadLine();
        }

        static void RunTestNamed(ArkWorld w, string name, string species, float expectedHealth, float expectedStamina, float expectedFood, float expectedWeight)
        {
            //Find
            ArkDinosaur dino = null;
            foreach(ArkDinosaur d in w.dinos)
            {
                if (d.dino_entry == null)
                    continue;
                if (d.dino_entry.screen_name == species && name == d.tamedName)
                    dino = d;
            }
            RunTest(dino, expectedHealth, expectedStamina, expectedFood, expectedWeight);
        }

        static void RunTest(ArkDinosaur dino, float expectedHealth, float expectedStamina, float expectedFood, float expectedWeight)
        {
            //Find dino and get stats
            ArkDinosaurStats stats = dino.GetMaxStats();
            string label = $"{dino.tamedName} ({dino.dino_entry.screen_name}, {dino.dinosaurId})";

            //Log
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"====[ {label} ]====");

            //Check
            RunSingleStatTest(label, "Health", stats.health, expectedHealth);
            RunSingleStatTest(label, "Stamina", stats.stamina, expectedStamina);
            RunSingleStatTest(label, "Food", stats.food, expectedFood);
            RunSingleStatTest(label, "Weight", stats.inventoryWeight, expectedWeight);
        }

        static void RunSingleStatTest(string label, string statLabel, float actual, float expected)
        {
            if(actual == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{label}] [{statLabel}] Stats match! {actual}/{expected}");
            } else if (MathF.Abs(actual - expected) < 1f)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{label}] [{statLabel}] Stats are close. {actual}/{expected}");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{label}] [{statLabel}] Stats are incorrect. {actual}/{expected}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
