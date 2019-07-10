using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                if (!db.Database.EnsureCreated())
                {
                    Console.WriteLine("Table Not Exists");
                    return;
                }

                switch (args[0])
                {
                    case "get": Get(args[1], db);break;
                    case "add": Add(args[1], db);break;
                    default:break;
                }
            }
        }

        static void Add(string path, AppContext ctx)
        {
            ctx.Projects.Add(new Project
            {
                Type = "",
                Path = path
            });
        }

        static List<Project> Get(string str, AppContext ctx)
        {
            return ctx.Projects.Where(p => EF.Functions.Like(p.Path, $"%{str}%")).ToList();
        }
    }
}
