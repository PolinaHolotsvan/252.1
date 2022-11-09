using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            string aditionalTopping;
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetAditionalTopping(string at) { aditionalTopping = at; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}\nAditional toping: {3}",
               dough, sauce, topping, aditionalTopping);
            }
        }
        //Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }
            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildAditionalTopping();
        }
        //Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("ham+pineapple");
            }
            public override void BuildAditionalTopping() { pizza.SetAditionalTopping("cheese"); }
        }

        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("panbaked"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("mozzarella cheese+tomatoes");
            }
            public override void BuildAditionalTopping() { pizza.SetAditionalTopping("fresh basil"); }
        }
        //Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.SetDough("panbaked"); }
        public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("pepparoni+salami");
            }
            public override void BuildAditionalTopping() { pizza.SetAditionalTopping("ham"); }
        }
        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb)
            {
                pizzaBuilder = pb;
            }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildAditionalTopping();
            }
        }
        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza = waiter.GetPizza();
                Console.WriteLine("Info about hawaiian pizza");
                pizza.Info();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza2 = waiter.GetPizza();
                Console.WriteLine("Info about margarita pizza");
                pizza2.Info();
                Console.ReadKey();
            }
        }
    }
}