using BucketApp.Models;
using System;
using System.Collections.Generic;

namespace BucketApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Bucket> buckets = new List<Bucket>();
            List<RainBarrel> rainBarrels = new List<RainBarrel>();
            List<OilBarrel> oilBarrels = new List<OilBarrel>();
            CreateBucketScenario(buckets);
            CreateRainBarrelScenario(rainBarrels);
            CreateOilBarrelScenario(oilBarrels);
        }

        private static void CreateBucketScenario(List<Bucket> buckets)
        {
            buckets.Add(CreateBucket(8, buckets, 10));
            buckets.Add(CreateBucket(6, buckets, 16));
            buckets.Add(CreateBucket(6, buckets, 12));
            SubscribeBucketsToEvent(buckets);
            ShowBucketsData(buckets);

            buckets[0].Fill(buckets[1]);
            buckets[2].Fill(8);
            ShowBucketsData(buckets);

            buckets[0].Empty(2);
            buckets[2].Empty();
            ShowBucketsData(buckets);
        }

        private static void CreateRainBarrelScenario(List<RainBarrel> rainBarrels)
        {
            rainBarrels.Add(CreateRainBarrel(30, rainBarrels, 120));
            rainBarrels.Add(CreateRainBarrel(60, rainBarrels, 200));
            SubscribeRainBarrelsToEvent(rainBarrels);
            ShowRainBarrelsData(rainBarrels);

            rainBarrels[0].Empty();
            rainBarrels[1].Fill(100);
            ShowRainBarrelsData(rainBarrels);
        }

        private static void CreateOilBarrelScenario(List<OilBarrel> oilBarrels)
        {
            oilBarrels.Add(CreateOilBarrel(20, oilBarrels));
            oilBarrels.Add(CreateOilBarrel(220, oilBarrels));
            SubscribeOilBarrelsToEvent(oilBarrels);
            ShowOilBarrrelsData(oilBarrels);

            oilBarrels[0].Empty();
            oilBarrels[1].Fill(20);
            ShowOilBarrrelsData(oilBarrels);
        }
       

        public static Bucket CreateBucket(int content, List<Bucket> buckets, int capacity)
        {
            Bucket bucket = new Bucket();
            bucket.Name = "Bucket " + (buckets.Count + 1);

            if (capacity > 12 || capacity < 10)
            {
                Console.WriteLine($"{capacity} is not a valid amount for a bucket, changing to the default of 12");
                bucket.Capacity = 12;
            }
            else
            {
                bucket.Capacity = capacity;
            }

            if (content > bucket.Capacity)
            {
                Console.WriteLine("Not enough capacity, changing  content amount to max");
                bucket.Content = bucket.Capacity;
            }
            else if(content < 0)
            {
                Console.WriteLine("Content can't be negative, changing to 0");
                bucket.Content = 0;
            }
            else
            {
                bucket.Content = content;
            }

            return bucket;
        }

        public static RainBarrel CreateRainBarrel(int content, List<RainBarrel> rainBarrels, int capacity)
        {
            RainBarrel rainBarrel = new RainBarrel();
            rainBarrel.Name = "Rain Barrel " + (rainBarrels.Count + 1);

            if (capacity != 80 && capacity != 100 && capacity != 120)
            {
                Console.WriteLine($"{capacity} is not a valid capacity for a rain barrel, changing capacity to 100");
                rainBarrel.Capacity = 100;
            }
            else
            {
                rainBarrel.Capacity = capacity;
            }
            if(content > capacity)
            {
                Console.WriteLine("Not enough capacity, changing content amount to max");
                rainBarrel.Content = capacity;
            }
            else if(content < 0)
            {
                Console.WriteLine("Content can't be negative, changing to 0");
                rainBarrel.Content = 0;
            }
            else
            {
                rainBarrel.Content = content;
            }

            return rainBarrel;
        }
        
        public static OilBarrel CreateOilBarrel(int content, List<OilBarrel> oilBarrels)
        {
            OilBarrel oilBarrel = new OilBarrel();
            oilBarrel.Name = "Oil Barrel " + (oilBarrels.Count + 1);
            oilBarrel.Capacity = 159;

            if(content < 0)
            {
                Console.WriteLine("Content can't be negative, changing to 0");
                oilBarrel.Content = 0;
            }
            else if(content > 159)
            {
                Console.WriteLine("Not enough capacity, changing content amount to max");
                oilBarrel.Content = 159;
            }
            else
            {
                oilBarrel.Content = content;
            }

            return oilBarrel;
        }

        static void OverflowedEventHandler(int Overflow)
        {
            Console.WriteLine("Overflow = " + Overflow);
        }

        static void SubscribeBucketsToEvent(List<Bucket> buckets)
        {
            foreach (var Bucket in buckets)
            {
                Bucket.OverFlowedEvent += OverflowedEventHandler;
            }
        }

        static void SubscribeRainBarrelsToEvent(List<RainBarrel> rainBarrels)
        {
            foreach (var RainBarrel in rainBarrels)
            {
                RainBarrel.OverFlowedEvent += OverflowedEventHandler;
            }
        }

        static void SubscribeOilBarrelsToEvent(List<OilBarrel> oilBarrels)
        {
            foreach (var OilBarrel in oilBarrels)
            {
                OilBarrel.OverFlowedEvent += OverflowedEventHandler;
            }
        }

        static void ShowBucketsData(List<Bucket> buckets)
        {
            foreach (var Bucket in buckets)
            {
                Console.WriteLine(Bucket.ToString());
            }
        }

        static void ShowRainBarrelsData(List<RainBarrel> rainBarrels)
        {
            foreach (var RainBarrel in rainBarrels)
            {
                Console.WriteLine(RainBarrel.ToString());
            }
        }

        static void ShowOilBarrrelsData(List<OilBarrel> oilBarrels)
        {
            foreach (var OilBarrel in oilBarrels)
            {
                Console.WriteLine(OilBarrel.ToString());
            }
        }
    }
}

