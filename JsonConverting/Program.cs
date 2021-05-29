using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace JsonConverting
{
    class Program
    {
       
        public static List<MyFileStructure> GetFileStructure()
        {
            Tree t = new Tree();
            List<MyFileStructure> list = new List<MyFileStructure>();

            list.Add(new MyFileStructure() { Id = "1", Title = "Equipments", Key = "0" });
            list.Add(new MyFileStructure() { Id = "2", Title = "630", Key = "1", Node = "first" });
            list.Add(new MyFileStructure() { Id = "3", Title = "630.01", Key = "2", Node = "second" });
            list.Add(new MyFileStructure() { Id = "4", Title = "630.01.01", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "5", Title = "630.01.02", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "5", Title = "630.01.03", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "6", Title = "630.01.01.01", Key = "4", Node = "fourth" });

            list.Add(new MyFileStructure() { Id = "11", Title = "Equipments", Key = "0" });
            list.Add(new MyFileStructure() { Id = "22", Title = "930", Key = "1", Node = "first" });
            list.Add(new MyFileStructure() { Id = "33", Title = "930.01", Key = "2", Node = "second" });
            list.Add(new MyFileStructure() { Id = "44", Title = "930.01.01", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "55", Title = "930.01.02", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "66", Title = "930.01.03", Key = "3", Node = "third" });
            list.Add(new MyFileStructure() { Id = "77", Title = "930.01.01.01", Key = "4", Node = "tedt" });

            var list2 = list.OrderBy(a => a.Title).ToList();
            List<MyFileStructure> treelist = new List<MyFileStructure>();
            if (list2.Count > 0)
            {
                treelist = t.BuildTree(list2);
            }

            return treelist;


            // return new JsonResult { Data = new { treeList = treelist }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        static void Main(string[] args)
        {
            // -- SERIALIZATION --

            // Initial object
           var originObj = new MyClass { Property1 = 1988, Property2 = "Some data :D" };

            // "First level" Of serialization.
            string jsonString = JsonConvert.SerializeObject(originObj);
            Console.WriteLine(jsonString);
            // Prints: 
            // {"Property1":1988,"Property2":"Some data :D"}


            // "Second level" of serialization.
            string escapedJsonString = JsonConvert.SerializeObject(jsonString);
            Console.WriteLine(escapedJsonString);
            // "{\"Property1\":1988,\"Property2\":\"Some data :D\"}"
            // Note the initial and final " character and de backslash characters

            // ...
            // at this point you could do more serializations ("More levels"), Obtaining as a result more and more backslash followed,
            // something like this:
            // "\"{\\\"Property1\\\":1988,\\\"Property2\\\":\\\"Some data :D\\\"}\""
            // Note that is... very very crazy :D
            // ...

            // -- DESERIALIZATION --

            // First deserialize to another string (unescaped string).
            string unescapedJsonString = JsonConvert.DeserializeObject<string>(escapedJsonString);
            Console.WriteLine(unescapedJsonString);
            // Prints:
            // {"Property1":1988,"Property2":"Some data :D"}

            // ...
            // at this point you could repeat more deserializations to string, if necessary. For example if you have many backslash \\\
            // ...

            // Finally, perform final deserialization to the target type, using the last unescaped string.
            MyClass targetObject = JsonConvert.DeserializeObject<MyClass>(unescapedJsonString);



        }

    }
}
