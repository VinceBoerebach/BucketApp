using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketApp.Models
{
    public abstract class Container
    {
        public delegate void OverflowedDelegate(int Overflow);

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Content { get; set; }

        public virtual void Fill(int amount)
        {
            Console.WriteLine($"Filling {this.Name} with {amount}");

            if (Capacity - Content >= amount)
            {
                Content += amount;
            }
            else
            {
                int Overflow = amount - (Capacity - Content);
                Content = Capacity;
                Console.WriteLine(this.Name + " is full!");
                OverFlowedEvent?.Invoke(Overflow);
            }
        }
        public virtual void Empty()
        {
            Console.WriteLine($"Emptying {this.Name}");
            this.Content = 0;
        }
        public virtual void Empty(int amount)
        {
            Console.WriteLine($"Emptying {this.Name} with {amount}");

            if (Content > amount)
            {
                Content = Content - amount;
            }
            else
            {
                Content = 0;
            }
        }
        public override string ToString()
        {
            return $"{Name} Capacity: {Capacity}, Content: {Content}";
        }

        public event OverflowedDelegate OverFlowedEvent;
    }
}
