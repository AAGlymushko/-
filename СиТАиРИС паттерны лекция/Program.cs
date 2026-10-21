using CharacterConstructor.Patterns;

var registry = TemplateRegistry.Instance;
Console.WriteLine($"Singleton: один экземпляр? {ReferenceEquals(registry, TemplateRegistry.Instance)}\n");

var infernus = new CharacterBuilder()
    .SetName("Infernus").SetClass("Стрелок")
    .SetStats(8, 9, 10, 100, 60)
    .AddAbility("Flame Dash").AddAbility("Catalyst")
    .AddEquipment("Пистолет-огнемёт")
    .Build();

var abrams = new CharacterBuilder()
    .SetName("Abrams").SetClass("Танк")
    .SetStats(15, 6, 4, 180, 20)
    .AddAbility("Shoulder Charge").AddAbility("Siphon Life")
    .AddEquipment("Кулаки")
    .Build();

var vindicta = new CharacterBuilder()
    .SetName("Vindicta").SetClass("Снайпер")
    .SetStats(6, 12, 8, 90, 50)
    .AddAbility("Flight").AddAbility("Assassinate")
    .AddEquipment("Снайперская винтовка")
    .Build();

Console.WriteLine("--- Builder: собраны 3 шаблона ---");
Console.WriteLine(infernus);
Console.WriteLine(abrams);
Console.WriteLine(vindicta);
Console.WriteLine();

registry.Register("Infernus", infernus);
registry.Register("Abrams", abrams);
registry.Register("Vindicta", vindicta);
Console.WriteLine();

Console.WriteLine("--- Prototype: клонируем Abrams и дорабатываем ---");
var player = registry.GetClone("Abrams");
player.Name = "Мой Abrams";
player.Level = 3;
player.Equipment.Add("Духовая пушка");
player.Abilities.Add("Ultimate: Seismic Impact");
Console.WriteLine(player);
Console.WriteLine();

Console.WriteLine("--- Шаблон Abrams не изменился ---");
Console.WriteLine(registry.GetClone("Abrams"));
Console.WriteLine();

Console.WriteLine("--- Builder: без класса персонажа ---");
try
{
    new CharacterBuilder().SetName("Кто-то").Build();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"ошибка: {ex.Message}");
}