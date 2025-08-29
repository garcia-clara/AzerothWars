namespace HeroicFantasyProject.Heroes;

public class PriestessOfTheMoon : Character
{
     public Skill Scout = new Skill(
        "🦉 Scout",
        damage: 0,
        mana: 50,
        description: "Temporarily summons an Owl Scout, which can be used to scout the map. Can see invisible units."
    );

    public Skill SearingArrows = new Skill(
        "🔥 Searing Arrows (Autocast)",
        damage: 0,
        mana: 25,
        description: "Increases the damage of the Priestess' attack by adding fire."
    );

    public Skill TrueshotAura = new Skill(
        "🎯 Trueshot Aura (Passive)",
        damage: 0,
        mana: 0,
        description: "An aura that gives friendly units around the Priestess bonus damage to their ranged attacks."
    );
    public PriestessOfTheMoon(string name) : base(name, race: "Night Elf", pv: 550, mana: 225) 
    {
        Skills.Add(Scout);
        Skills.Add(SearingArrows);
        Skills.Add(TrueshotAura);
    }

    public override string Quote()
    {
        return "🏹 Warriors of the night, assemble!";
    }

    public override string Attack(Character target)
    {
        int damage = 15;
        target.TakeDamage(damage);
        return $"{Name} strikes {target.Name}, dealing {damage} damage!";
    }

    public string Fireball(Character target)
    {
        if (!ConsumeMana(30))
        {
            return $"{Name} does not have enough mana to cast Fireball.";
        }
        int damage = 40;
        target.TakeDamage(damage);
        return $"{Name} casts Fireball at {target.Name}, dealing {damage} damage!";

    }
}
