using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        const int maxCars = 100;

        string[] vin = new string[maxCars];
        string[] brand = new string[maxCars];
        int[] modelCode = new int[maxCars];
        int[] year = new int[maxCars];
        int[] mileage = new int[maxCars];
        string[] color = new string[maxCars];
        double[] price = new double[maxCars];
        bool[] isSold = new bool[maxCars];

        int carCount = 0;
        vin[0] = "WVW123456789";
        brand[0] = "Volkswagen";
        modelCode[0] = 101;
        year[0] = 2020;
        mileage[0] = 85000;
        color[0] = "Чорний";
        price[0] = 18500;
        isSold[0] = false;

        carCount = 1;


        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("              АВТОСАЛОН");
            Console.WriteLine("======================================");
            Console.WriteLine("Користувач: студент");
            Console.WriteLine();

            Console.WriteLine("1 — показати всі автомобілі");
            Console.WriteLine("2 — додати автомобіль");
            Console.WriteLine("3 — знайти автомобіль");
            Console.WriteLine("4 — змінити автомобіль");
            Console.WriteLine("5 — видалити автомобіль");
            Console.WriteLine("6 — зведена таблиця");
            Console.WriteLine("7 — зберегти у файл");
            Console.WriteLine("8 — завантажити з файлу");
            Console.WriteLine("9 — експорт у CSV");
            Console.WriteLine("0 — вихід");
            Console.WriteLine();

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllCars(
                        vin,
                        brand,
                        modelCode,
                        year,
                        mileage,
                        color,
                        price,
                        isSold,
                        carCount);

                    Pause();
                    break;


                case "2":
                    AddCar(
                        vin,
                        brand,
                        modelCode,
                        year,
                        mileage,
                        color,
                        price,
                        isSold,
                        ref carCount,
                        maxCars);

                    Pause();
                    break;


                case "3":
                    Console.WriteLine("Пошук буде додано пізніше.");
                    Pause();
                    break;

                case "4":
                    Console.WriteLine("Редагування буде додано пізніше.");
                    Pause();
                    break;

                case "5":
                    Console.WriteLine("Видалення буде додано пізніше.");
                    Pause();
                    break;

                case "6":
                    ShowSummaryTable();
                    Pause();
                    break;


                case "7":
                    Console.WriteLine("Збереження у файл буде додано пізніше.");
                    Pause();
                    break;

                case "8":
                    Console.WriteLine("Завантаження з файлу буде додано пізніше.");
                    Pause();
                    break;

                case "9":
                    Console.WriteLine("Експорт у CSV буде додано пізніше.");
                    Pause();
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Програму завершено.");
                    break;

                default:
                    Console.WriteLine("Помилка: такого пункту меню немає.");
                    Pause();
                    break;
            }
            //case 1
            static void ShowAllCars(
                string[] vin,
                string[] brand,
                int[] modelCode,
                int[] year,
                int[] mileage,
                string[] color,
                double[] price,
                bool[] isSold,
                int carCount)
            {
                Console.Clear();

                Console.WriteLine("==========================================================================");
                Console.WriteLine("                         АВТОМОБІЛІ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine();

                if (carCount == 0)
                {
                    Console.WriteLine("Автомобілів поки немає.");
                    return;
                }

                Console.WriteLine(
                    $"{"№",-5}" +
                    $"{"VIN",-18}" +
                    $"{"Марка",-15}" +
                    $"{"Модель",-10}" +
                    $"{"Рік",-8}" +
                    $"{"Пробіг",-10}" +
                    $"{"Колір",-12}" +
                    $"{"Ціна",-12}" +
                    $"{"Статус",-12}");

                Console.WriteLine(new string('-', 102));

                for (int i = 0; i < carCount; i++)
                {
                    string status;

                    if (isSold[i])
                    {
                        status = "Продано";
                    }
                    else
                    {
                        status = "У продажу";
                    }

                    Console.WriteLine(
                        $"{i + 1,-5}" +
                        $"{vin[i],-18}" +
                        $"{brand[i],-15}" +
                        $"{modelCode[i],-10}" +
                        $"{year[i],-8}" +
                        $"{mileage[i],-10}" +
                        $"{color[i],-12}" +
                        $"{price[i],-12:F2}" +
                        $"{status,-12}");
                }

                Console.WriteLine();
                Console.WriteLine($"Кількість автомобілів: {carCount}");
            }
            //case 2
            static void AddCar(
    string[] vin,
    string[] brand,
    int[] modelCode,
    int[] year,
    int[] mileage,
    string[] color,
    double[] price,
    bool[] isSold,
    ref int carCount,
    int maxCars)
{
    Console.Clear();

    Console.WriteLine("======================================");
    Console.WriteLine("        ДОДАВАННЯ АВТОМОБІЛЯ");
    Console.WriteLine("======================================");
    Console.WriteLine();

    if (carCount >= maxCars)
    {
        Console.WriteLine("Сховище заповнене.");
        return;
    }

    Console.Write("Введіть VIN: ");
    string enteredVin = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(enteredVin))
    {
        Console.WriteLine("VIN не може бути порожнім.");
        return;
    }

    Console.Write("Введіть марку: ");
    string enteredBrand = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(enteredBrand))
    {
        Console.WriteLine("Марка не може бути порожньою.");
        return;
    }

    Console.Write("Введіть код моделі: ");
    bool modelIsCorrect =
        int.TryParse(Console.ReadLine(), out int enteredModelCode);

    if (!modelIsCorrect || enteredModelCode <= 0)
    {
        Console.WriteLine("Код моделі має бути додатним числом.");
        return;
    }

    Console.Write("Введіть рік випуску: ");
    bool yearIsCorrect =
        int.TryParse(Console.ReadLine(), out int enteredYear);

    if (!yearIsCorrect ||
        enteredYear < 1886 ||
        enteredYear > DateTime.Now.Year)
    {
        Console.WriteLine("Неправильний рік випуску.");
        return;
    }

    Console.Write("Введіть пробіг: ");
    bool mileageIsCorrect =
        int.TryParse(Console.ReadLine(), out int enteredMileage);

    if (!mileageIsCorrect || enteredMileage < 0)
    {
        Console.WriteLine("Пробіг не може бути від’ємним.");
        return;
    }

    Console.Write("Введіть колір: ");
    string enteredColor = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(enteredColor))
    {
        Console.WriteLine("Колір не може бути порожнім.");
        return;
    }

    Console.Write("Введіть ціну: ");
    bool priceIsCorrect =
        double.TryParse(Console.ReadLine(), out double enteredPrice);

    if (!priceIsCorrect || enteredPrice <= 0)
    {
        Console.WriteLine("Ціна має бути додатним числом.");
        return;
    }

    Console.Write("Автомобіль проданий? Введіть так або ні: ");
    string soldAnswer = Console.ReadLine().ToLower();

    bool enteredIsSold;

    if (soldAnswer == "так")
    {
        enteredIsSold = true;
    }
    else if (soldAnswer == "ні")
    {
        enteredIsSold = false;
    }
    else
    {
        Console.WriteLine("Введіть тільки «так» або «ні».");
        return;
    }

    vin[carCount] = enteredVin;
    brand[carCount] = enteredBrand;
    modelCode[carCount] = enteredModelCode;
    year[carCount] = enteredYear;
    mileage[carCount] = enteredMileage;
    color[carCount] = enteredColor;
    price[carCount] = enteredPrice;
    isSold[carCount] = enteredIsSold;

    carCount++;

    Console.WriteLine();
    Console.WriteLine("Автомобіль успішно додано.");
}


        }
        //case 6
        static void ShowSummaryTable()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("         ТАБУЛЮВАННЯ ФУНКЦІЇ");
            Console.WriteLine("======================================");
            Console.WriteLine();

            double from = 0.5;
            double to = 3.0;
            double step = 0.25;

            Console.WriteLine($"{"x",10}{"y",15}");
            Console.WriteLine(new string('-', 25));

            for (double x = from; x <= to + 1e-9; x += step)
            {
                double y = Math.Sqrt(x) + 1 / x;

                Console.WriteLine($"{x,10:F2}{y,15:F4}");
            }

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("     ТАБЛИЦЯ З ВКЛАДЕНИМИ ЦИКЛАМИ");
            Console.WriteLine("======================================");
            Console.WriteLine();

            Console.Write($"{string.Empty,8}");

            for (int column = 1; column <= 6; column++)
            {
                Console.Write($"{column,8}");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 56));

            for (int row = 1; row <= 5; row++)
            {
                Console.Write($"{row,8}");

                for (int column = 1; column <= 6; column++)
                {
                    Console.Write($"{row * column,8}");
                }

                Console.WriteLine();
            }
        }

    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Натисніть будь-яку клавішу...");
        Console.ReadKey(true);
    }
}
