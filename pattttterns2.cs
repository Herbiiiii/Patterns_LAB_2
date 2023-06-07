using System;

// Абстрактная фабрика
abstract class ProductFactory
{
    public abstract IProduct CreateProduct();
    public abstract IPackaging CreatePackaging();
}

// Конкретная фабрика для создания продукта "Книга"
class BookFactory : ProductFactory
{
    public override IProduct CreateProduct()
    {
        return new Book();
    }

    public override IPackaging CreatePackaging()
    {
        return new Box();
    }
}

// Конкретная фабрика для создания продукта "Игрушка"
class ToyFactory : ProductFactory
{
    public override IProduct CreateProduct()
    {
        return new Toy();
    }

    public override IPackaging CreatePackaging()
    {
        return new Wrapper();
    }
}

// Абстрактный продукт
interface IProduct
{
    void Display();
}

// Конкретный продукт "Книга"
class Book : IProduct
{
    public void Display()
    {
        Console.WriteLine("Это книга");
    }
}

// Конкретный продукт "Игрушка"
class Toy : IProduct
{
    public void Display()
    {
        Console.WriteLine("Это игрушка");
    }
}

// Абстрактная упаковка
interface IPackaging
{
    void Display();
}

// Конкретная упаковка "Коробка"
class Box : IPackaging
{
    public void Display()
    {
        Console.WriteLine("Упаковка в коробке");
    }
}

// Конкретная упаковка "Обертка"
class Wrapper : IPackaging
{
    public void Display()
    {
        Console.WriteLine("Упаковка в обертке");
    }
}

// Шаблонный метод
abstract class ProductStore
{
    protected ProductFactory factory;

    public void OrderProduct()
    {
        IProduct product = factory.CreateProduct();
        IPackaging packaging = factory.CreatePackaging();

        packaging.Display();
        product.Display();
    }
}

// Конкретный магазин продуктов
class BookStore : ProductStore
{
    public BookStore(ProductFactory factory)
    {
        this.factory = factory;
    }
}

class ToyStore : ProductStore
{
    public ToyStore(ProductFactory factory)
    {
        this.factory = factory;
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        // Создание магазина книг
        ProductFactory bookFactory = new BookFactory();
        ProductStore bookStore = new BookStore(bookFactory);
        bookStore.OrderProduct();

        Console.WriteLine();

        // Создание магазина игрушек
        ProductFactory toyFactory = new ToyFactory();
        ProductStore toyStore = new ToyStore(toyFactory);
        toyStore.OrderProduct();

        Console.ReadLine();
    }
}