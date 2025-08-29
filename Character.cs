namespace HeroicFantasyProject;

public abstract class Character
{
    public string Name { get; set; }
    public string Race { get; set; }
    public int PV { get; private set; }
    public int Mana { get; protected set; }
    public bool IsAlive => PV > 0;
    public List<Skill> Skills { get; } = new();

    protected Character(string name, string race, int pv, int mana)
    {
        Name = name;
        Race = race;
        PV = pv;
        Mana = mana;
    }

    public void TakeDamage(int damage)
    {
        PV = Math.Max(0, PV - damage);
    }
    
    public void Heal(int amount)
    {
        PV += amount;
    }

    public bool ConsumeMana(int amount)
    {
        if (Mana < amount) return false;
        Mana -= amount;
        return true;
    }

    public string Cast(Skill skill, Character target)
    {
        if (!Skills.Contains(skill))
            return $"{Name} does not know the skill {skill.Name}.";
        if (Mana < skill.Mana)
            return $"{Name} does not have enough mana to cast {skill.Name}.";
        
        ConsumeMana(skill.Mana);
        target.TakeDamage(skill.Damage);
        return $"{Name} casts {skill.Name} on {target.Name}, dealing {skill.Damage} damage!";
    }

    public abstract string Attack(Character target);
    public abstract string Quote();
}
