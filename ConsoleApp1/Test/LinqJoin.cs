using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Test
{
    public class LinqJoin
    {
        public class ModelA
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class ModelB
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        public void Run()
        {
            var listA = new List<ModelA>();
            listA.Add(new ModelA { Name = "10살", Age = 10 });
            listA.Add(new ModelA { Name = "20살", Age = 20 });
            listA.Add(new ModelA { Name = "30살", Age = 30 });
            listA.Add(new ModelA { Name = "40살", Age = 40 });
            listA.Add(new ModelA { Name = "50살", Age = 50 });

            var listB = new List<ModelB>();
            listB.Add(new ModelB { Name = "20살", Age = 20 });
            listB.Add(new ModelB { Name = "50살", Age = 50 });

            var query = from a in listA
                        join b in listB
                        on a.Name equals b.Name
                        select new { a.Name, b.Age };

            foreach(var item in query.ToList())
            {
                Console.WriteLine($"{item.Name}: {item.Age}");
            }

            var query2 = listA.Join(listB,
                a => a.Name,
                b => b.Name, 
                (a, b) => new { a.Name, b.Age });

            foreach (var item in query2.ToList())
            {
                Console.WriteLine($"{item.Name}: {item.Age}");
            }

        }
    }
}
