using System;

namespace DatabasesSnelheidTesten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DataBase test initiated");
            Console.WriteLine("Press enter to start the tests");
            Console.ReadLine();
            TestADONET();
            TestEntityFramework();
            TestNoSql();
            Console.WriteLine("Press enter to stop the tests");
            Console.ReadLine();
        }

        static void TestADONET()
        {
            ADONET.ADONET adonetTest = new ADONET.ADONET();
            Console.WriteLine("Now testing; ADO.NET Inserts");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + adonetTest.testCreate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + adonetTest.testCreate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + adonetTest.testCreate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + adonetTest.testCreate(10000) + "ms");
            Console.WriteLine("End of test; ADO.NET Inserts");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; ADO.NET Get");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + adonetTest.testRead(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + adonetTest.testRead(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + adonetTest.testRead(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + adonetTest.testRead(10000) + "ms");
            Console.WriteLine("End of test; ADO.NET Get");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; ADO.NET Update");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + adonetTest.testUpdate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + adonetTest.testUpdate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + adonetTest.testUpdate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + adonetTest.testUpdate(10000) + "ms");
            Console.WriteLine("End of test; ADO.NET Update");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; ADO.NET Delete");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + adonetTest.testDelete(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + adonetTest.testDelete(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + adonetTest.testDelete(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + adonetTest.testDelete(10000) + "ms");
            adonetTest.reSeedDB();
            Console.WriteLine("End of test; ADO.NET Delete");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        static void TestEntityFramework()
        {
            EntityFramework.EntityFramework entityFramework = new EntityFramework.EntityFramework();
            entityFramework.createGenres();

            Console.WriteLine("Now testing; EntityFramework Inserts");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + entityFramework.testCreate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + entityFramework.testCreate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + entityFramework.testCreate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + entityFramework.testCreate(10000) + "ms");
            Console.WriteLine("End of test; EntityFramework Inserts");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; EntityFramework Get");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + entityFramework.testRead(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + entityFramework.testRead(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + entityFramework.testRead(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + entityFramework.testRead(10000) + "ms");
            Console.WriteLine("End of test; EntityFramework Get");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; EntityFramework Update");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + entityFramework.testUpdate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + entityFramework.testUpdate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + entityFramework.testUpdate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + entityFramework.testUpdate(10000) + "ms");
            Console.WriteLine("End of test; EntityFramework Update");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; EntityFramework Delete");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + entityFramework.testDelete(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + entityFramework.testDelete(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + entityFramework.testDelete(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + entityFramework.testDelete(10000) + "ms");
            Console.WriteLine("End of test; EntityFramework Delete");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        static void TestNoSql()
        {
            NoSQL.NoSql noSQL = new NoSQL.NoSql();

            Console.WriteLine("Now testing; NoSql Inserts");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + noSQL.testCreate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + noSQL.testCreate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + noSQL.testCreate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + noSQL.testCreate(10000) + "ms");
            Console.WriteLine("End of test; NoSql Inserts");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; NoSql Get");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + noSQL.testRead(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + noSQL.testRead(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + noSQL.testRead(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + noSQL.testRead(10000) + "ms");
            Console.WriteLine("End of test; NoSql Get");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; NoSql Update");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + noSQL.testUpdate(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + noSQL.testUpdate(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + noSQL.testUpdate(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + noSQL.testUpdate(10000) + "ms");
            Console.WriteLine("End of test; NoSql Update");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Now testing; NoSql Delete");
            Console.WriteLine("1 row");
            Console.WriteLine("Time: " + noSQL.testDelete(1) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("100 rows");
            Console.WriteLine("Time: " + noSQL.testDelete(100) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1,000 rows");
            Console.WriteLine("Time: " + noSQL.testDelete(1000) + "ms");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("10,000 rows");
            Console.WriteLine("Time: " + noSQL.testDelete(10000) + "ms");
            Console.WriteLine("End of test; NoSql Delete");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}
