using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCrud db = new MongoCrud("AddressBook");

            PersonModel person = new PersonModel
            {
                FirstName = "Samarth",
                LastName = "Goel",
                Address = new AddressModel
                {
                    Street = "Naveen Nagar",
                    City = "Moradabad",
                    State = "Uttar Pradesh",
                    ZipCode = "244001"

                }
            };
            db.InsertRecord("Users", person);

            List<PersonModel> records = db.LoadRecords<PersonModel>("Users");

            foreach (var item in records)
            {
                Console.WriteLine($"{ item.Id}:{item.FirstName}{item.LastName}");

                if (item.Address != null)
                {
                    Console.WriteLine(item.Address.City);
                }
            }

            //db.LoadRecordById("Users", "");
            Console.ReadLine();
        }
    }
}
