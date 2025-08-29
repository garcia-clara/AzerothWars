namespace HeroicFantasyProject.Heroes;

public class Paladin : Character
{
    public Skill HolyLight = new Skill(
        "⛅ Holy Light",
        damage: 0,
        mana: 65,
        description: "A holy light that can heal a friendly living unit or damage an enemy undead unit."
    );

    public Skill DivineShield = new Skill(
        "🛡️ Divine Shield",
        damage: 0,
        mana: 25,
        description: "An impenetrable shield surrounds the Paladin, protecting him from all damage and spells for a set amount of time."
    );

    public Skill DevotionAura = new Skill(
        "✨ Devotion Aura",
        damage: 0,
        mana: 0,
        description: "A passive aura that increases the armor of nearby friendly units."
    );

    public Paladin(string name) : base(name, race: "Human", pv: 650, mana: 255) 
    {
        Skills.Add(HolyLight);
        Skills.Add(DivineShield);
        Skills.Add(DevotionAura);
    }
    public override string Quote()
    {
        return "🛡️ I live to serve all believers.";
    }

    public override string Attack(Character target)
    {
        Random rnd = new Random();
        int damage = rnd.Next(24, 34);
        target.TakeDamage(damage);
        return $"{Name} strikes {target.Name}, dealing {damage} damage!";
    }
}