using System;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SqlDataHelper("Data Source=.;Initial Catalog=MyDB;Integrated Security=SSPI;"))
            {
                db.Execute("INSERT INTO Customer(id, name, phone) VALUES(@id, @name, @phone)", new { id = 1, name = "이순신", phone = "010-433-3111" });
                db.Execute("INSERT INTO Customer(id, name, phone) VALUES(@id, @name, @phone)", new { id = 2, name = "강감찬", phone = "010-511-4342" });
                db.Execute("INSERT INTO Customer(id, name, phone) VALUES(@id, @name, @phone)", new { id = 3, name = "안중근", phone = "010-532-2232" });
                db.Execute("INSERT INTO Customer(id, name, phone) VALUES(@id, @name, @phone)", new { id = 4, name = "김유신", phone = "010-532-3232" });

                db.Execute("UPDATE Customer SET phone = @phone WHERE ID = @id", new { id = 2, phone = "010-222-2222" });

                db.Execute("DELETE Customer WHERE ID = @id", new { id = 2 });

                var dt = db.GetDataTable("select * from Customer");

                foreach(DataRow row in dt.Rows)
                {
                    foreach(var item in row.ItemArray)
                    {
                        Console.Write($"{item} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
