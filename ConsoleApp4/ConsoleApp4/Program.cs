using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== СИСТЕМА ВХОДУ =====
        if (!LoginSystem())
        {
            Console.WriteLine("Доступ заборонено. Програма завершує роботу.");
            return;
        }

        int choice = -1;

        while (choice != 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Кафе-бар Vafelka ===\n");
            Console.ResetColor();

            Console.WriteLine("1. Переглянути меню");
            Console.WriteLine("2. Розрахунок покупки");
            Console.WriteLine("3. Інформація про заклад");
            Console.WriteLine("4. Налаштування");
            Console.WriteLine("0. Вихід");

            Console.Write("\nВаш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\nПомилка! Введіть число.");
                Pause();
                continue;
            }

            switch (choice)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    CalculateOrder();
                    break;
                case 3:
                    Info();
                    break;
                case 4:
                    Settings();
                    break;
                case 0:
                    Console.WriteLine("\nДо побачення!");
                    break;
                default:
                    Console.WriteLine("\nНевірний вибір!");
                    break;
            }

            Pause();
        }
    }

    // ================= СИСТЕМА ВХОДУ =================
    static bool LoginSystem()
    {
        string correctLogin = "admin";
        string correctPassword = "1234";

        int attempts = 3;

        do
        {
            Console.Clear();
            Console.WriteLine("=== ВХІД ДО СИСТЕМИ ===");

            Console.Write("Логін: ");
            string login = Console.ReadLine();

            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            if (login == correctLogin && password == correctPassword)
            {
                Console.WriteLine("✅ Вхід успішний!");
                Pause();
                return true;
            }
            else
            {
                attempts--;
                Console.WriteLine($"❌ Невірні дані! Залишилось спроб: {attempts}");
                Pause();
            }

        } while (attempts > 0);

        return false;
    }

    // ================= МЕНЮ =================
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Меню кафе ===\n");

        Console.WriteLine("Бургер         - 120 грн");
        Console.WriteLine("Картопля фрі   - 55 грн");
        Console.WriteLine("Піцца          - 180 грн");
        Console.WriteLine("Кока-кола      - 35 грн");
        Console.WriteLine("Кава           - 45 грн");
        Console.WriteLine("Коньяк 100мл   - 75 грн");
    }

    static void CalculateOrder()
    {
        Console.Clear();
        Console.WriteLine("=== Розрахунок покупки ===\n");

        double burgerPrice = 120;
        double friesPrice = 55;
        double pizzaPrice = 180;
        double colaPrice = 35;
        double coffeePrice = 45;
        double cognacPrice = 75;

        double burgers = ReadDouble("Введіть кількість бургерів: ");
        double fries = ReadDouble("Введіть кількість картоплі фрі: ");
        double pizzas = ReadDouble("Введіть кількість піц: ");
        double colas = ReadDouble("Введіть кількість склянок коли: ");
        double coffees = ReadDouble("Введіть кількість чашок кави: ");
        double cognac = ReadDouble("Введіть кількість порцій коньяку: ");

        double total = burgers * burgerPrice +
                       fries * friesPrice +
                       pizzas * pizzaPrice +
                       colas * colaPrice +
                       coffees * coffeePrice +
                       cognac * cognacPrice;

        Random rnd = new Random();
        double discount = rnd.Next(5, 16);
        double totalWithDiscount = total - total * discount / 100;

        Console.WriteLine($"\nЗагальна сума: {total:F2} грн");
        Console.WriteLine($"Знижка: {discount}%");
        Console.WriteLine($"До сплати: {totalWithDiscount:F2} грн");
    }

    static void Info()
    {
        Console.Clear();
        Console.WriteLine("=== Інформація про кафе ===\n");
        Console.WriteLine("Кафе-бар Vafelka працює з 10:00 до 23:00");
        Console.WriteLine("Адреса: вул. Смачна, 5");
    }

    static void Settings()
    {
        Console.Clear();
        Console.WriteLine("=== Налаштування ===\n");
        Console.WriteLine("Функція в розробці...");
    }

    static double ReadDouble(string message)
    {
        double number;
        Console.Write(message);
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Помилка! Введіть число: ");
        }
        return number;
    }

    static void Pause()
    {
        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }
}