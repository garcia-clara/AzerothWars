namespace HeroicFantasyProject;

public class Skill
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Mana { get; set; }
    public string Description { get; set; }

    public Skill(string name, int damage, int mana, string description)
    {
        Name = name;
        Damage = damage;
        Mana = mana;
        Description = description;
    }
}
