using System;
using System.Collections.Generic;

public class Appliance
{
    private string model;
    private int price;
    private int guarantee;

    public Appliance()
    {
        model = null;
        price = 0;
        guarantee = 0;
    }

    public Appliance(string model, int price, int guarantee)
    {
        this.model = model;
        this.price = price;
        this.guarantee = guarantee;
    }

    public virtual void Print()
    {
        if (model != null)
            Console.WriteLine("Модель: " + model);
        Console.WriteLine("Цена: " + price);
        Console.WriteLine("Гарантийный срок: " + guarantee);
    }

    public string GetModel()
    {
        return model;
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetGuarantee()
    {
        return guarantee;
    }

    public void SetModel(string name)
    {

        model = name;
    }

    public void SetPrice(int val)
    {
        if (0 < val && val < 999999)
            price = val;
    }

    public void SetGuarantee(int val)
    {
        if (0 <= val && val <= 10)
            guarantee = val;
    }
}


public class Printer : Appliance
{
    private int volumeOfPaint;
    private int printSpeed;
    private string printTechnology;

    public Printer() : base()
    {
        volumeOfPaint = 0;
        printSpeed = 0;
        printTechnology = null;
    }

    public Printer(string model, int price, int guarantee, int volume, int speed, string tech) : base(model, price, guarantee)
    {
        if (volume > 0 && volume < 100)
            volumeOfPaint = volume;
        if (speed > 0 && speed < 100)
            printSpeed = speed;

        printTechnology = tech;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Объем краски: " + volumeOfPaint);
        Console.WriteLine("Скорость печати: " + printSpeed);
        if (printTechnology != null)
            Console.WriteLine("Технология печати: " + printTechnology + "\n");
    }

    public int GetVolume()
    {
        return volumeOfPaint;
    }

    public int GetSpeed()
    {
        return printSpeed;
    }


    public string GetTech()
    {
        return printTechnology;
    }

    public void SetVolume(int val)
    {
        if (val > 0 && val < 100)
            volumeOfPaint = val;
    }

    public void SetSpeed(int val)
    {
        if (val > 0 && val < 100)
            printSpeed = val;
    }
}

public class Fax : Appliance
{
    private string phoneNumber;
    private int transmissionSpeed;
    private int memoryCapacity;

    public Fax() : base()
    {
        transmissionSpeed = 0;
        memoryCapacity = 0;
        phoneNumber = null;
    }

    public Fax(string model, int price, int guarantee, int memory, int speed, string number) : base(model, price, guarantee)
    {
        if (memory > 0 && memory < 100)
            memoryCapacity = memory;
        if (speed > 0 && speed < 100)
            transmissionSpeed = speed;

        phoneNumber = number;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Объем памяти: " + memoryCapacity);
        Console.WriteLine("Скорость передачи: " + transmissionSpeed);
        if (phoneNumber != null)
            Console.WriteLine("Номер: " + phoneNumber + "\n");
    }

    public int GetMemory()
    {
        return memoryCapacity;
    }

    public int GetSpeed()
    {
        return transmissionSpeed;
    }


    public string GetNumber()
    {
        return phoneNumber;
    }

    public void SetMemory(int val)
    {
        if (val > 0 && val < 100)
            memoryCapacity = val;
    }

    public void SetSpeed(int val)
    {
        if (val > 0 && val < 100)
            transmissionSpeed = val;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Для корректного отображения кириллицы в консоли

        List<Appliance> appliances = new List<Appliance>();
        int choice;

        while (true)
        {
            Console.WriteLine("Выберите действие:\n");
            Console.WriteLine("1 - Добавить объект\n");
            Console.WriteLine("2 - Вывести содержимое списка\n");
            Console.WriteLine("3 - Завершить программу\n");
            Console.Write("Ваш выбор: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Какой тип объекта добавить?\n1 - Прибор\n2 - Принтер\n3 - Факс");
                        Console.Write("Ваш выбор: ");
                        if (int.TryParse(Console.ReadLine(), out int typeChoice))
                        {
                            switch (typeChoice)
                            {
                                case 1:
                                    Console.Write("Введите модель прибора: ");
                                    string model = Console.ReadLine();
                                    Console.Write("Введите цену: ");
                                    if (int.TryParse(Console.ReadLine(), out int price))
                                    {
                                        Console.Write("Введите гарантийный срок: ");
                                        if (int.TryParse(Console.ReadLine(), out int guarantee))
                                        {
                                            appliances.Add(new Appliance(model, price, guarantee));
                                            Console.WriteLine("Объект добавлен!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверный формат ввода\n");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат ввода\n");
                                    }


                                    break;
                                case 2:
                                    Console.Write("Введите модель принтера: ");
                                    string printerModel = Console.ReadLine();
                                    Console.Write("Введите цену: ");
                                    if (int.TryParse(Console.ReadLine(), out int printerPrice))
                                    {
                                        Console.Write("Введите гарантийный срок: ");
                                        if (int.TryParse(Console.ReadLine(), out int printerGuarantee))
                                        {
                                            Console.Write("Введите объем краски: ");
                                            if (int.TryParse(Console.ReadLine(), out int volume))
                                            {
                                                Console.Write("Введите скорость печати: ");
                                                if (int.TryParse(Console.ReadLine(), out int speed))
                                                {
                                                    Console.Write("Введите технологию печати: ");
                                                    string tech = Console.ReadLine();
                                                    appliances.Add(new Printer(printerModel, printerPrice, printerGuarantee, volume, speed, tech));
                                                    Console.WriteLine("Объект добавлен!\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Неверный формат ввода\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный формат ввода\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверный формат ввода\n");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат ввода\n");
                                    }

                                    break;
                                case 3:
                                    Console.Write("Введите модель факса: ");
                                    string faxModel = Console.ReadLine();
                                    Console.Write("Введите цену: ");
                                    if (int.TryParse(Console.ReadLine(), out int faxPrice))
                                    {
                                        Console.Write("Введите гарантийный срок: ");
                                        if (int.TryParse(Console.ReadLine(), out int faxGuarantee))
                                        {
                                            Console.Write("Введите объем памяти: ");
                                            if (int.TryParse(Console.ReadLine(), out int memory))
                                            {
                                                Console.Write("Введите скорость передачи: ");
                                                if (int.TryParse(Console.ReadLine(), out int faxSpeed))
                                                {
                                                    Console.Write("Введите номер телефона: ");
                                                    string number = Console.ReadLine();
                                                    appliances.Add(new Fax(faxModel, faxPrice, faxGuarantee, memory, faxSpeed, number));
                                                    Console.WriteLine("Объект добавлен!\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Неверный формат ввода\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный формат ввода\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверный формат ввода\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат ввода\n");
                                    }

                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор типа объекта.\n");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ввода\n");
                        }
                        break;
                    case 2:
                        if (appliances.Count == 0)
                        {
                            Console.WriteLine("Список пуст.\n");
                        }
                        else
                        {
                            Console.WriteLine("Содержимое списка:\n");
                            foreach (var appliance in appliances)
                            {
                                appliance.Print();
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Программа завершена.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор действия.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода\n");
            }
        }
    }
}
