using System;
using System.Collections.Generic;

class Product
{
    public int Id;
    public string Name;
    public double Price;

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

class Program
{
    static List<Product> menu = new List<Product>();

    static void Main()
    {
        if (!LoginSystem())
        {
            Console.WriteLine("Доступ заборонено");
            return;
        }

        InitMenu();

        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Кафе-бар Vafelka ===\n");

            Console.WriteLine("1. Меню та оформлення замовлення");
            Console.WriteLine("2. Вивести меню (таблиця)");
            Console.WriteLine("3. Додати елемент");
            Console.WriteLine("4. Пошук");
            Console.WriteLine("5. Видалення");
            Console.WriteLine("6. Сортування");
            Console.WriteLine("7. Статистика");
            Console.WriteLine("0. Вихід");

            Console.Write("\nВаш вибір: ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: MakeOrder(); break;
                case 2: ShowTable(); break;
                case 3: AddProduct(); break;
                case 4: Search(); break;
                case 5: Delete(); break;
                case 6: SortMenu(); break;
                case 7: Statistics(); break;
            }

            Pause();
        }
        while (choice != 0);
    }

    // ===== ВХІД =====
    static bool LoginSystem()
    {
        string loginOk = "admin";
        string passOk = "1234";
        int attempts = 3;

        while (attempts-- > 0)
        {
            Console.Clear();
            Console.Write("Логін: ");
            string l = Console.ReadLine();
            Console.Write("Пароль: ");
            string p = Console.ReadLine();

            if (l == loginOk && p == passOk)
                return true;

            Console.WriteLine("Помилка входу");
            Pause();
        }
        return false;
    }

    // ===== ДАНІ =====
    static void InitMenu()
    {
        menu.Add(new Product(1, "Бургер", 120));
        menu.Add(new Product(2, "Картопля фрі", 55));
        menu.Add(new Product(3, "Піцца", 180));
        menu.Add(new Product(4, "Кока-кола", 35));
        menu.Add(new Product(5, "Кава", 45));
        menu.Add(new Product(6, "Коньяк", 75));
    }

    // ===== ЗАМОВЛЕННЯ =====
    static void MakeOrder()
    {
        Console.Clear();
        Console.WriteLine("=== МЕНЮ ===");

        for (int i = 0; i < menu.Count; i++)
            Console.WriteLine($"{i}. {menu[i].Name} - {menu[i].Price} грн");

        double total = 0;
        for (int i = 0; i < menu.Count; i++)
        {
            Console.Write($"Кількість \"{menu[i].Name}\": ");
            int qty;
            int.TryParse(Console.ReadLine(), out qty);
            total += qty * menu[i].Price;
        }

        Random rnd = new Random();
        int discount = rnd.Next(5, 16);
        double finalSum = total - total * discount / 100;

        Console.WriteLine($"\nСума: {total} грн");
        Console.WriteLine($"Знижка: {discount}%");
        Console.WriteLine($"До сплати: {finalSum:F2} грн");
    }

    // ===== ТАБЛИЦЯ =====
    static void ShowTable()
    {
        Console.WriteLine("\nID  Назва            Ціна");
        Console.WriteLine("----------------------------");
        foreach (var p in menu)
            Console.WriteLine($"{p.Id,-3} {p.Name,-15} {p.Price,6} грн");
    }

    // ===== ДОДАВАННЯ =====
    static void AddProduct()
    {
        try
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Назва: ");
            string name = Console.ReadLine();
            Console.Write("Ціна: ");
            double price = double.Parse(Console.ReadLine());

            menu.Add(new Product(id, name, price));
        }
        catch { Console.WriteLine("Помилка"); }
    }

    // ===== ПОШУК =====
    static void Search()
    {
        Console.Write("Назва: ");
        string key = Console.ReadLine().ToLower();

        foreach (var p in menu)
            if (p.Name.ToLower() == key)
                Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
    }

    // ===== ВИДАЛЕННЯ =====
    static void Delete()
    {
        Console.Write("Індекс: ");
        if (int.TryParse(Console.ReadLine(), out int i) && i >= 0 && i < menu.Count)
            menu.RemoveAt(i);
    }

    // ===== СОРТУВАННЯ =====
    static void SortMenu()
    {
        Console.WriteLine("1 - Вбудоване");
        Console.WriteLine("2 - Бульбашкове");
        string c = Console.ReadLine();

        if (c == "1")
            menu.Sort((a, b) => a.Price.CompareTo(b.Price));
        else
            BubbleSort();
    }

    static void BubbleSort()
    {
        for (int i = 0; i < menu.Count - 1; i++)
            for (int j = 0; j < menu.Count - i - 1; j++)
                if (menu[j].Price > menu[j + 1].Price)
                {
                    var t = menu[j];
                    menu[j] = menu[j + 1];
                    menu[j + 1] = t;
                }
    }

    // ===== СТАТИСТИКА =====
    static void Statistics()
    {
        double min = menu[0].Price, max = menu[0].Price, sum = 0;

        foreach (var p in menu)
        {
            if (p.Price < min) min = p.Price;
            if (p.Price > max) max = p.Price;
            sum += p.Price;
        }

        Console.WriteLine($"Кількість: {menu.Count}");
        Console.WriteLine($"Мін: {min}");
        Console.WriteLine($"Макс: {max}");
        Console.WriteLine($"Сума: {sum}");
        Console.WriteLine($"Середня: {sum / menu.Count:F2}");
    }

    static void Pause()
    {
        Console.WriteLine("\nEnter...");
        Console.ReadLine();
    }
}