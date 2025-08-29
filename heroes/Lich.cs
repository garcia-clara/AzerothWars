namespace HeroicFantasyProject.Heroes;

public class Lich : Character
{
    public Skill FrostNova = new Skill(
        "💎 Frost Nova",
        damage: 150,
        mana: 125,
        description: "Blasts enemy units around a target enemy unit with a wave of damaging frost that slows movement by 50% and attack rate by 25%."
    );

    public Skill FrostArmor = new Skill(
        "🧊 Frost Armor",
        damage: 0,
        mana: 40,
        description: "Creates a shield of frost around a target friendly unit. The shield adds armor and slows melee units that attack it. The slow is 50% movement and 25% attack."
    );

    public Skill DarkRitual = new Skill(
        "💀 Dark Ritual",
        damage: 0,
        mana: 25,
        description: "Sacrifices a target friendly Undead unit to convert its hit points into mana for the Lich."
    );
    public Lich(string name) : base(name, race: "Undead", pv: 475, mana: 300)
    {
        Skills.Add(FrostNova);
        Skills.Add(FrostArmor);
        Skills.Add(DarkRitual);
    }

    public override string Quote()
    {
        return "☠️ The ancient evil survives!";
    }

    public override string Attack(Character target)
    {
        int damage = 15;
        target.TakeDamage(damage);
        return $"{Name} strikes {target.Name}, dealing {damage} damage!";
    }
    
}
