using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zola.DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class PrductFilter
    {
        public IEnumerable<product> FilterBySize(IEnumerable<product> products,Size size)
        {
            foreach(var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }
        public IEnumerable<product> FilterByColor(IEnumerable<product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }
    }

    public class OpenClose
    {
        public static void OCMain()
        {
            var apple = new product("Apple", Color.Green, Size.Small);
            var tree = new product("Tree", Color.Green, Size.Large);
            var house = new product("House", Color.Blue, Size.Large);

            product[] products = { apple, tree, house };
            var pfilter = new PrductFilter();
            Console.WriteLine("Green Products (old):");
            foreach (var p in pfilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"-{p.Name} is green");
            }
        }
    }
}
