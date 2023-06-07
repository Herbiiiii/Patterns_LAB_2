using System;

// Поведенческий паттерн "Интерпретатор"
// Абстрактный интерпретатор
abstract class Expression
{
    public abstract bool Interpret(string context);
}

// Конкретный интерпретатор для проверки наличия товара
class ItemExistExpression : Expression
{
    private string _item;

    public ItemExistExpression(string item)
    {
        _item = item;
    }

    public override bool Interpret(string context)
    {
        return context.Contains(_item);
    }
}

// Фасад, предоставляющий простой интерфейс для клиента
class StoreFacade
{
    private ItemExistExpression _itemExistExpression;

    public StoreFacade()
    {
        _itemExistExpression = new ItemExistExpression("shirt");
    }

    public bool CheckItemAvailability(string item)
    {
        return _itemExistExpression.Interpret(item);
    }
}

// Пример использования

class Program
{
    static void Main(string[] args)
    {
        // Создание фасада
        StoreFacade facade = new StoreFacade();

        // Проверка наличия товара
        string item = "red shirt";
        bool isAvailable = facade.CheckItemAvailability(item);

        Console.WriteLine($"Товар '{item}' доступен в магазине: {isAvailable}");
    }
}
