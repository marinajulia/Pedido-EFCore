using Microsoft.EntityFrameworkCore;
using System;

namespace CursoEntityFramework1 {
    class Program {
        static void Main(string[] args) {

            using var db = new Data.ApplicationContext();
            db.Database.Migrate();
            Console.WriteLine("Hello World!");
        }
    }
}
