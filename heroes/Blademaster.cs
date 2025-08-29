namespace HeroicFantasyProject.Heroes;

public class Blademaster : Character
{
    public Skill WindWalk = new Skill(
        "🌪️ Wind Walk",
        damage: 0,
        mana: 75,
        description: "Allows the Blademaster to become invisible, and move faster for a set amount of time. When the Blademaster attacks a unit to break invisibility, he will deal bonus damage."
    );

    public Skill MirrorImage = new Skill(
        "🪞 Mirror Image",
        damage: 0,
        mana: 25,
        description: "Confuses the enemy by creating illusions of the Blademaster and dispelling all magic from the Blademaster."
    );

    public Skill CriticalStrike = new Skill(
        "🗡️ Critical Strike (Passive)",
        damage: 0,
        mana: 0,
        description: "Gives a 15% chance that the Blademaster will do more damage on his attacks."
    );
    public Blademaster(string name) : base(name, race: "Orc", pv: 550, mana: 240) 
    {
        Skills.Add(WindWalk);
        Skills.Add(MirrorImage);
        Skills.Add(CriticalStrike);
    }

        public override string Quote()
    {
        return "⚔️ My blade seeks vengeance.";
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
