using CharacterConstructor.Models;

namespace CharacterConstructor.Patterns;

public class TemplateRegistry
{
    private static Lazy<TemplateRegistry> _instance = new(() => new TemplateRegistry());

    public static TemplateRegistry Instance => _instance.Value;

    private Dictionary<string, Character> _templates = new();

    private TemplateRegistry() { }

    public void Register(string key, Character template)
    {
        ArgumentNullException.ThrowIfNull(template);
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Ключ шаблона не может быть пустым", nameof(key));
        }
        _templates[key] = template.Clone();
        Console.WriteLine($"   реестр: шаблон «{key}» сохранён");
    }

    public Character GetClone(string key)
    {
        if (!_templates.TryGetValue(key, out var template))
        {
            throw new KeyNotFoundException($"Шаблон «{key}» не найден");
        }
        Console.WriteLine($"   реестр: выдан клон шаблона «{key}»");
        return template.Clone();
    }
}