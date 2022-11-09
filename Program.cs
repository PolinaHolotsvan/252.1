using System;
using System.Text;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Create ConcreteComponent and two Decorators
            ConcreteChristmasTree tree = new ConcreteChristmasTree();
            ConcreteDecoratorToys toysDec = new ConcreteDecoratorToys();
            ConcreteDecoratorLights lightsDec = new ConcreteDecoratorLights();

            // Link decorators
            toysDec.SetComponent(tree);         
            lightsDec.SetComponent(toysDec);

            lightsDec.Operation();
            

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ConcreteChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка стоїть");
        }
    }
    // "Decorator"
    abstract class Decorator : ChristmasTree
    {
        protected ChristmasTree component;

        public void SetComponent(ChristmasTree component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorToys : Decorator
    {
        public string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "фігурка зайчика";
            Console.WriteLine($"На ялинці висить {addedState}");
        }
    }

    // "ConcreteDecoratorB" 
    class ConcreteDecoratorLights : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
        }
        void AddedBehavior()
        {
            Console.WriteLine("Ялинка горить жовтими вогниками");
        }
    }
}
