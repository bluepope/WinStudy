using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1.Test
{
    class JsonConvertPrivateSetterTest
    {
        public void Run()
        {
            var x = JsonConvert.DeserializeObject<TestModel>("{ \"Str1\": \"a\", \"Str2\": \"b\"  }");
            Console.WriteLine($"{x.Str1} {x.Str2}");
        }
    }

    class TestModel
    {
        [JsonProperty]
        public string Str1 { get; private set; }

        [JsonProperty]
        public string Str2 { get; private set; }
    }
}
