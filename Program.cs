using HeroicFantasyProject;
using HeroicFantasyProject.Heroes;

// Fonction pour afficher les stats des personnages
static void DisplayStats(Character hero, Character enemy)
{
    Console.Clear();
    Console.WriteLine("╔═══════════════════════════════ BATTLE STATUS ═══════════════════════════════╗");
    Console.WriteLine($"│ {hero.Name} ({hero.Race})".PadRight(40) + $"│ {enemy.Name} ({enemy.Race})".PadRight(38) + "│");
    Console.WriteLine($"│ ❤️  PV: {hero.PV}".PadRight(40) + $"│ ❤️  PV: {enemy.PV}".PadRight(38) + "│");
    Console.WriteLine($"│ 🔮 Mana: {hero.Mana}".PadRight(40) + $"│ 🔮 Mana: {enemy.Mana}".PadRight(38) + "│");
    Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════╝");
    Console.WriteLine();
}

Console.WriteLine(@"
╔──────────────────────────────────────────────────────────────────────╗
│                                                                      │
│                               _   _      __          __              │
│      /\                      | | | |     \ \        / /              │
│     /  \    _______ _ __ ___ | |_| |__    \ \  /\  / /_ _ _ __ ___   │
│    / /\ \  |_  / _ \ '__/ _ \| __| '_ \    \ \/  \/ / _` | '__/ __|  │
│   / ____ \  / /  __/ | | (_) | |_| | | |    \  /\  / (_| | |  \__ \  │
│  /_/    \_\/___\___|_|  \___/ \__|_| |_|     \/  \/ \__,_|_|  |___/  │
│                                                                      │
╚──────────────────────────────────────────────────────────────────────╝                    
");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("1 - Paladin (Human)");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("2 - Blademaster (Orc)");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("3 - Lich (Undead)");
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("4 - Priestess of the Moon (Night Elf)");
Console.ResetColor();
Console.WriteLine("5 - More informations");

Console.Write("\nChoose your hero: ");
string heroChoice = Console.ReadLine() ?? "";
Character? hero = null;

Paladin paladin = new Paladin("Uther");
Blademaster blademaster = new Blademaster("Grom");
Lich lich = new Lich("Kel'Thuzad");
PriestessOfTheMoon priestess = new PriestessOfTheMoon("Tyrande");

switch (heroChoice)
{
    case "1":
        hero = paladin;
        break;
    case "2":
        hero = blademaster;
        break;
    case "3":
        hero = lich;
        break;
    case "4":
        hero = priestess;
        break;
    default:
        Console.WriteLine("Invalid choice.");
        break;
}

if (hero != null)
{
    Random rnd = new Random();
    var heroes = new List<Character> { paladin, blademaster, lich, priestess };
    int enemyIndex = rnd.Next(heroes.Count);
    while (heroes[enemyIndex] == hero)
    {
        enemyIndex = rnd.Next(heroes.Count);
    }
    Character enemy = heroes[enemyIndex];
    
    Console.WriteLine($"\nYou have chosen {hero.Name}");
    Console.WriteLine(hero.Quote());
    Console.WriteLine($"PV: {hero.PV}, Mana: {hero.Mana}");
    Console.WriteLine("\nSkills:");
    foreach (var skill in hero.Skills)
    {
        Console.WriteLine($"{skill.Name}");
        Console.WriteLine($"Damage: {skill.Damage}, Mana: {skill.Mana}");
        Console.WriteLine($"Description: {skill.Description}");
        Console.WriteLine("----------------------------");
    }
    
    Console.WriteLine("\nPress any key to start the battle...");
    Console.ReadKey();
    
    while (hero.IsAlive && enemy.IsAlive)
    {
        DisplayStats(hero, enemy);
        
        Console.WriteLine("Choose your action:");
        Console.WriteLine("1 - Attack");
        Console.WriteLine("2 - Use Skill");
        Console.WriteLine("3 - Pass");
        Console.WriteLine("4 - Use Item");

        Console.Write("\nWhat will you do next? ");
        string action = Console.ReadLine() ?? "";

        string actionResult = "";

        switch (action)
        {
            case "1":
                actionResult = hero.Attack(enemy);
                break;
            case "2":
                if (hero.Skills.Count > 0)
                {
                    Console.WriteLine("Available skills:");
                    for (int i = 0; i < hero.Skills.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {hero.Skills[i].Name} (Mana: {hero.Skills[i].Mana})");
                    }
                    Console.Write("\nSelect a skill: ");
                    string selectedSkill = Console.ReadLine() ?? "";
                    
                    if (int.TryParse(selectedSkill, out int skillIndex) && skillIndex >= 1 && skillIndex <= hero.Skills.Count)
                    {
                        actionResult = hero.Cast(hero.Skills[skillIndex - 1], enemy);
                    }
                    else
                    {
                        actionResult = "Invalid skill selection.";
                    }
                }
                else
                {
                    actionResult = $"{hero.Name} has no skills available.";
                }
                break;
            case "3":
                actionResult = $"{hero.Name} passes the turn.";
                break;
            case "4":
                actionResult = $"{hero.Name} uses an item!";
                break;
            default:
                actionResult = "Invalid action.";
                break;
        }

        Console.WriteLine($"\n{actionResult}");
        
        if (enemy.IsAlive)
        {
            string enemyAction = enemy.Attack(hero);
            Console.WriteLine($"{enemyAction}");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    

    DisplayStats(hero, enemy);
    if (hero.IsAlive)
    {
        Console.WriteLine("🎉 Victory! You have defeated your enemy!");
    }
    else
    {
        Console.WriteLine("💀 Defeat! You have been defeated...");
    }
}

