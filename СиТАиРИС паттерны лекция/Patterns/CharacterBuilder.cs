namespace CharacterConstructor.Patterns;

using CharacterConstructor.Models;
public class CharacterBuilder
{
    private string _name = string.Empty;
    private string _className = string.Empty;
    private int _level = 1;
    private int _strength;
    private int _agility;
    private int _intellect;
    private int _health;
    private int _mana;
    private string _appearance = "стандартная";
    private List<string> _abilities = new();
    private List<string> _equipment = new();

    public CharacterBuilder SetName(string name) { _name = name; return this; }
    public CharacterBuilder SetClass(string className) { _className = className; return this; }

    public CharacterBuilder SetLevel(int level)
    {
        if (level <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(level), "Уровень должен быть > 0");
        }
        _level = level;
        return this;
    }

    public CharacterBuilder SetStats(int str, int agi, int intellect, int hp, int mp)
    {
        if (hp <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hp), "HP должно быть > 0");
        }
        if (mp < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mp), "MP не может быть отрицательным");
        }
        _strength = str; _agility = agi; _intellect = intellect;
        _health = hp; _mana = mp;
        return this;
    }

    public CharacterBuilder SetAppearance(string appearance) { _appearance = appearance; return this; }
    public CharacterBuilder AddAbility(string ability) { _abilities.Add(ability); return this; }
    public CharacterBuilder AddEquipment(string item) { _equipment.Add(item); return this; }

    public Character Build()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            throw new InvalidOperationException("Не задано имя персонажа");
        }
        if (string.IsNullOrWhiteSpace(_className))
        {
            throw new InvalidOperationException("Не задан класс персонажа");
        }
        if (_health <= 0)
        {
            throw new InvalidOperationException("Не задано здоровье персонажа");
        }

        return new Character
        {
            Name = _name,
            ClassName = _className,
            Level = _level,
            Strength = _strength,
            Agility = _agility,
            Intellect = _intellect,
            Health = _health,
            Mana = _mana,
            Appearance = _appearance,
            Abilities = new List<string>(_abilities),
            Equipment = new List<string>(_equipment)
        };
    }
}