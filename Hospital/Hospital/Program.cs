using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext context = new DataClasses1DataContext(
                @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alesak\Source\Repos\NewRepo\Hospital\Hospital\data.mdf;Integrated Security=True");

            /*var query = from cert in context.Trained_Ins
                        group cert.Treatment by cert.Physician;
            var physDict = query.ToDictionary(p=>p.Key);

            var query2 = context.Undergoes.AsEnumerable()
                .Where(n => !physDict[n.Physician].Contains(n.Procedures))
                .Select(n => n.Physician1);

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }*/


            var q = from treatment in context.Undergoes
                    join cert in context.Trained_Ins on treatment.Physician equals cert.Physician
                    select new { treatment, cert } into pair
                    //where pair.cert.CertificationExpires < pair.treatment.DateUndergoes
                    select pair;

            foreach (var item in q)
            {
                Console.WriteLine("Name: {0}, {1} < {2}", item.treatment.Physician1.Name, item.cert.CertificationExpires, item.treatment.DateUndergoes);
            }



            Console.ReadKey();

        }
    }
}
