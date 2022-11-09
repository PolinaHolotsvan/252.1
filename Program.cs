using System;
namespace FactoryMethodExample
{
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type, int id);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type, int id)
        {
            switch (type)
            {
                case 1: return new Phone(id);
                case 2: return new Laptop(id); 
                case 3: return new Tablet(id);
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product {
        public int id;
        abstract public void Info();
    }
    public class Phone : Product
    {
        public Phone(int id)
        {
            this.id = id;
        }
        public override void Info()
        {
            Console.WriteLine($"Phone with id {id}");
        }
    }
    public class Laptop : Product {
        public Laptop(int id)
        {
            this.id = id;
        }
        public override void Info()
        {
        Console.WriteLine($"Laptop with id {id}");
        }
    }
    public class Tablet : Product
    {
        public Tablet(int id)
        {
            this.id = id;
        }
        public override void Info()
        {
            Console.WriteLine($"Tablet with id {id}");
        }
    }

        class MainApp
    {
        static void Main()
        {  
            Random rnd = new Random();
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                var product = creator.FactoryMethod(i, rnd.Next(1000, 10000));
                product.Info();
            }
            Console.ReadKey();
        }
    }
}