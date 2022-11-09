using System;
using System.Collections;
namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            FamilyMember grandmother = new Parent("Anna");
            grandmother.Add(new Child("Vita"));

            FamilyMember mother1 = new Parent("Paul");
            mother1.Add(new Child("Philip"));
            mother1.Add(new Child("James"));
            grandmother.Add(mother1);
            grandmother.Add(new Child("Kate"));

            Child mother2 = new Child("Carl");
            grandmother.Add(mother2);
            grandmother.Remove(mother2);
            grandmother.Display(0);
            Console.Read();
        }
    }
    abstract class FamilyMember
    {
        public string name;
        public FamilyMember(string name)
        {
            this.name = name;
        }

        public abstract void Add(FamilyMember c);
        public abstract void Remove(FamilyMember c);
        public abstract void Display(int depth);
    }
    class Parent : FamilyMember
    {
        private ArrayList children = new ArrayList();
        public Parent(string name)
            : base(name)
        {
        }

        public override void Add(FamilyMember component)
        {
            children.Add(component);
        }

        public override void Remove(FamilyMember component)
        {
            if(children.Contains(component)) children.Remove(component);
            else Console.WriteLine($"{component.name} isn't {name}'s child");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (FamilyMember component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Child : FamilyMember
    {
        public Child(string name)
            : base(name)
        {
        }

        public override void Add(FamilyMember c)
        {
            Console.WriteLine("A child can't have children");
        }

        public override void Remove(FamilyMember c)
        {
            Console.WriteLine($"{c.name} isn't {name}'s child");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}
