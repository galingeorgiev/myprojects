/* Code for example.
 * This code is from: http://en.wikipedia.org/wiki/Builder_pattern 
 * I only correct some warnings.
 * Classes not separeted in different files for better readability. */

namespace BuilderPattern
{
    // Builder - abstract interface for creating objects (the product, in this case)
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza()
        {
            return this.pizza;
        }

        public void CreateNewPizzaProduct()
        {
            this.pizza = new Pizza();
        }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }

    // Concrete Builder - provides implementation for Builder; an object able to construct other objects.
    // Constructs and assembles parts to build the objects
    public class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "cross";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "mild";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "ham+pineapple";
        }
    }
    // Concrete Builder - provides implementation for Builder; an object able to construct other objects.
    // Constructs and assembles parts to build the objects
    public class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "pan baked";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "hot";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "pepperoni + salami";
        }
    }

    // Director - responsible for managing the correct sequence of object creation.
    // Receives a Concrete Builder as a parameter and executes the necessary operations on it.
    public class Cook
    {
        private PizzaBuilder pizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder pb)
        {
            this.pizzaBuilder = pb;
        }

        public Pizza GetPizza()
        {
            return this.pizzaBuilder.GetPizza();
        }

        public void ConstructPizza()
        {
            this.pizzaBuilder.CreateNewPizzaProduct();
            this.pizzaBuilder.BuildDough();
            this.pizzaBuilder.BuildSauce();
            this.pizzaBuilder.BuildTopping();
        }
    }

    // Product - The final object that will be created by the Director using Builder
    public class Pizza
    {
        public string Dough = string.Empty;
        public string Sauce = string.Empty;
        public string Topping = string.Empty;
    }

    public class Builder
    {
        public static void Main(string[] args)
        {
            PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
            Cook cook = new Cook();
            cook.SetPizzaBuilder(hawaiianPizzaBuilder);
            cook.ConstructPizza();
            // create the product
            Pizza hawaiian = cook.GetPizza();

            PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
            cook.SetPizzaBuilder(spicyPizzaBuilder);
            cook.ConstructPizza();
            // create another product
            Pizza spicy = cook.GetPizza();
        }
    }

}