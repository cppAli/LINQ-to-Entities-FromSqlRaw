using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace LINQ_to_Entities_191123_FromSqlRaw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // пересоздаем базу данных
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();
            //    Company microsoft = new Company { Name = "Microsoft" };
            //    Company google = new Company { Name = "Google" };
            //    db.companies.AddRange(microsoft, google);
            //    User tom = new User
            //    {
            //        Name = "Tom",
            //        Age = 36,
            //        Company =
            //    microsoft
            //    };
            //    User bob = new User
            //    {
            //        Name = "Bob",
            //        Age = 39,
            //        Company =
            //    google
            //    };
            //    User alice = new User
            //    {
            //        Name = "Alice",
            //        Age = 28,
            //        Company = microsoft
            //    };
            //    User kate = new User
            //    {
            //        Name = "Kate",
            //        Age = 25,
            //        Company
            //    = google
            //    };
            //    User tomas = new User
            //    {
            //        Name = "Tomas",
            //        Age = 22,
            //        Company = microsoft
            //    };
            //    User tomek = new User
            //    {
            //        Name = "Tomek",
            //        Age = 42,
            //        Company = google
            //    };
            //    db.Users.AddRange(tom, bob, alice, kate, tomas, tomek);
            //    db.SaveChanges();
            //}

            //получим все объекты из таблицы Companies
            //            Выражение SELECT извлекает данные из таблицы. Так как эта таблица
            //сопоставляется с моделью Company и хранит объекты этой модели, то в
            //результате мы получим набор объектов класса Company
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var comp = db.companies.FromSqlRaw("SELECT * FROM companies").ToList();
            //    foreach (var company in comp)
            //    {
            //        Console.WriteLine(company.Name);
            //    }

            //    //            При этом мы можем добавлять к методу другие методы LINQ, которые все
            //    //вместе будут конкатенироваться в одно общее SQL-выражение:

            //    var comps = db.companies.FromSqlRaw("SELECT * FROM companies").OrderBy(x => x.Name).ToList();
            //    foreach(var company in comps)
            //        Console.WriteLine(company.Name);

            //    //                В итоге будет выполняться следующее SQL-выражение:
            //    //SELECT "c"."Id", "c"."Name"
            //    //FROM(
            //    //SELECT * FROM Companies
            //    //) AS "c"
            //    //ORDER BY "c"."Name"


            //    //Также можно использовать метод Include для подгрузки связанных данных:
            //    var users = db.Users.FromSqlRaw("SELECT * FROM Users").
            //        Include(c=>c.Company).ToList();

            //    foreach (var user in users)
            //        Console.WriteLine($"{user.Name} - {user.Company?.Name}");
            //}

            ////////////////////////////////////////////////////////////////////////
            // метода FromSqlRaw() позволяет использовать параметры.
            //Например, выберем из бд все модели, в названии которых есть подстрока "Tom":

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    SqlParameter param = new SqlParameter("@name", "%Tom%");
            //    var users = db.Users.FromSqlRaw("SELECT * FROM Users WHERE Name LIKE @name", param).ToList();
            //    foreach (var user in users)
            //        Console.WriteLine(user.Name);
            //}

            ////////////////////////////////////////////////////////////////////////
            //Также мы можем определять параметры как простые переменные:

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var name = "%Tom%";
            //    var users = db.Users.FromSqlRaw("SELECT * FROM Users WHERE Name LIKE {0}", name).ToList();
            //    foreach (var user in users)
            //        Console.WriteLine(user.Name); //по первому индексу имени Т

            //    var age = 30;
            //    users = db.Users.FromSqlRaw("SELECT * FROM Users WHERE Age > {0}", age).ToList();
            //    foreach (var user in users)
            //        Console.WriteLine(user.Name); //сорт больше 30
            //}

            ////////////////////////////////////////////////////////////////////////
            //ExecuteSqlRaw  - удалять, обновлять уже существующие или вставлять новые записи
            //метод ExecuteSqlRaw() и его асинхронная версия -ExecuteSqlRawAsync(), которые возвращают количество
            //затронутых командой строк
            using (ApplicationContext db = new ApplicationContext())
            {
                // вставка
                //string newComp = "Apple";
                //int numberOfRowInserted = db.Database.ExecuteSqlRaw("INSERT INTO Companies (Name) VALUES ({0})", newComp);
                // асинхронная версия
                // int numberOfRowInserted2 = await db.Database.ExecuteSqlRawAsync("INSERT INTO Companies (Name) VALUES ({0})", newComp);


                // обновление
                //string appleInc = "Apple Inc.";
                //string apple = "Apple";
                //int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Companies SET Name={0} WHERE Name={1}", appleInc, apple);

                // удаление
                //string appleInc = "Apple Inc.";
                //int numberOfRowDeleted = db.Database.ExecuteSqlRaw("DELETE FROM Companies WHERE Name={0}", appleInc);

                ////////////////////////////////////////////////////////////////////////
                //Интерполяция строк
                //Для методов FromSqlRaw и ExecuteSqlRaw в EF Core определены их двойники - 
                //методы FromSqlInterpolated() и ExecuteSqlInterpolated() (асинхронная версия - ExecuteSqlInterpolatedAsync()), 
                //которые позволяют использовать интерполяцию строк для передачи параметров. Пример с FromSqlInterpolated:


                //var name = "%Tom%";
                //var age = 30;
                //var users = db.Users.FromSqlInterpolated($"SELECT * FROM Users WHERE Name LIKE {name} AND Age > {age}").ToList();
                //foreach (var user in users)
                //    Console.WriteLine(user.Name);

                //Использование ExecuteSqlInterpolated()/ExecuteSqlInterpolatedAsync():

                //string jetbrains = "JetBrains";
                //db.Database.ExecuteSqlInterpolated($"INSERT INTO companies (Name) VALUES ({jetbrains})");
                //асинхронная версия
                // await db.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO Companies (Name) VALUES ({jetbrains})");

                //foreach (var comp in db.companies.ToList())
                //    Console.WriteLine(comp.Name);

                ////////////////////////////////////////////////////////////////////////
                //обращение к хранимой функции в запросе SQL, который отправляется из кода C#:

                //SqlParameter param = new SqlParameter("@age", 30);
                //var users = db.Users.FromSqlRaw("SELECT * FROM GetUsersByAge (@age)", param).ToList();
                //foreach (var u in users)
                //    Console.WriteLine($"{u.Name} - {u.Age}");

                //Проецирование хранимой функции на метод класса
                //определение в классе контекста метода, который
                //проецируется на хранимую функцию и через который можно вызывать данную функцию.

                //GetUsersByAge  принимает некоторое число и возвращает набор пользователей
                //Создадим для этой функции метод - перейти в class ApplicationContext

                //Обращение к хранимой функции GetUsersByAge в коде
                //var users = db.GetUsersByAge(30); // обращение к хранимой функции
                //foreach (var u in users)
                //    Console.WriteLine($"{u.Name} - {u.Age}");

                ////////////////////////////////////////////////////////////////////////
                //Рассмотрим, как вызывать хранимые процедуры из кода на C# через Entity
                //Framework Core на примере БД MS SQL Server

                //через подключенную базу в вижуале

                //Данная процедура ищет все строки, где значение столбца название компании
                //равно строке, переданной через параметр @name.

                // в узле Stored Procedures появится новая хранимая процедура

                //SqlParameter param = new("@name", "Microsoft");
                //var users = db.Users.FromSqlRaw("GetUsersByCompany @name", param).ToList();
                //foreach (var p in users)
                //    Console.WriteLine($"{p.Name} - {p.Age}");
                //Параметр в методе FromSqlRaw принимает название процедуры, после
                //которого идет перечисление параметров: GetUsersByCompany @name

                ////////////////////////////////////////////////////////////////////////
                //Выходные параметры процедуры
                //возврат отдельных данных (не табличные наборы)

                //Например, нам надо получить имя пользователя с максимальным возрастом.
                //Для этого определим следующую хранимую процедуру GetUserWithMaxAge

                //CREATE PROCEDURE[dbo].[GetUserWithMaxAge]
                //@name varchar(50) OUTPUT
                //AS
                //SELECT @name = [Name] FROM Users WHERE Age = (SELECT MAX(Age) FROM Users)
                //RETURN 0

                //Параметр name здесь определен как выходной с ключевым словом OUTPUT.
                //Через него будет передаваться имя пользователя.
                SqlParameter param = new()
                {
                    ParameterName = "@userName", //выходной парам
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 50
                };
                db.Database.ExecuteSqlRaw("GetUserWithMaxAge @userName OUT", param); //
                Console.WriteLine(param.Value); //свойство param.Value получает значение переданное через параметр

            }
        }
    }
}
