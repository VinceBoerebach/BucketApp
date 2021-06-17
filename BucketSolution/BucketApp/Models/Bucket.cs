using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketApp.Models
{
    public delegate void OverflowedDelegate(int Overflow);

    public class Bucket : Container
    {
        public void Fill(Bucket bucket)
        {
            Console.WriteLine($"Filling {this.Name} with {bucket.Name}");

            if(Capacity - Content >= bucket.Content)
            {
                Content += bucket.Content;
            }
            else
            {
                int Overflow = bucket.Content - (Capacity - Content);
                Console.WriteLine("Bucket is full!");
                OverFlowedEvent?.Invoke(Overflow);
                Content = Capacity;
            }
            bucket.Content = 0;
        }

        public event OverflowedDelegate OverFlowedEvent;
    }
}
