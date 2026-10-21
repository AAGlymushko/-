namespace CharacterConstructor.Models;
public class Character
{
    public string Name { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intellect { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public string Appearance { get; set; } = string.Empty;
    public List<string> Abilities { get; set; } = new();
    public List<string> Equipment { get; set; } = new();

    public Character Clone() => new()
    {
        Name = Name,
        ClassName = ClassName,
        Level = Level,
        Strength = Strength,
        Agility = Agility,
        Intellect = Intellect,
        Health = Health,
        Mana = Mana,
        Appearance = Appearance,
        Abilities = new List<string>(Abilities),
        Equipment = new List<string>(Equipment)
    };

    public override string ToString()
    {
        var abilities = Abilities.Count == 0 ? "—" : string.Join(", ", Abilities);
        var equipment = Equipment.Count == 0 ? "—" : string.Join(", ", Equipment);
        return $"{Name} [{ClassName}], ур. {Level}, " +
               $"СИЛ {Strength}/ЛОВ {Agility}/ИНТ {Intellect}/HP {Health}/MP {Mana}\n" +
               $"   способности: {abilities}\n" +
               $"   снаряжение: {equipment}\n" +
               $"   внешность: {Appearance}";
    }
}