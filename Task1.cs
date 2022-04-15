using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCoreHandsOn1
{
    class student
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string smailid { get; set; }
        public string branch { get; set; }
        public double per { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            student[] slist = new student[]
            {
                new student(){ firstname ="Saurabh",lastname = "Jadhav",smailid = "SJ123@gmail.com",branch = "Science", per= 85},
                new student(){ firstname ="Abhay",lastname = "Shinde",smailid = "AS123@gmail.com",branch = "Science", per= 95},
                new student(){ firstname ="Sumit",lastname = "Nirmale",smailid = "SN123@gmail.com",branch = "Science", per= 75},
                new student(){ firstname ="Pramod",lastname = "Patil",smailid = "PP123@gmail.com",branch = "Commerce", per= 83},
                new student(){ firstname ="Akshay",lastname = "Deore",smailid = "AD123@gmail.com",branch = "Arts", per= 65},
                new student(){ firstname ="Vishal",lastname = "Vispute",smailid = "VV123@gmail.com",branch = "Commerce", per= 88},
                new student(){ firstname ="Rushi",lastname = "Mahajan",smailid = "RM123@gmail.com",branch = "Arts", per= 98},
                new student(){ firstname ="Tushar",lastname = "Tambe",smailid = "TT123@gmail.com",branch = "Commerce", per= 65}
            };
            Console.WriteLine("All OPERATIONS IN LINQ");
            Console.WriteLine("----------SELECT-----------");
            var query1 = (from i in slist select i);
            foreach (var i in query1)
            {
                Console.WriteLine(i.firstname + "," + i.lastname + "," + i.smailid + "," + i.smailid + "," + i.branch + "," + i.per);
            }
            Console.WriteLine("---------WHERE------------");
            var query2 = from i in slist where i.branch == "Science" select i;
            foreach (student i in query2)
            {
                Console.WriteLine(i.firstname + "," + i.lastname);
            }
            Console.WriteLine("---------TAKE------------");
            var query3 = (from i in slist select i.per).Take(5);
            foreach (var i in query3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------TAKEWHILE------------");
            var query4 = (from i in slist select i.per).TakeWhile(i => i > 65);
            foreach (var i in query4)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------SKIP-----------");
            var query5 = (from i in slist select i.lastname).Skip(3);
            foreach (var i in query5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------SKIPWHILE-----------");
            var query6 = (from i in slist select i.per).SkipWhile(i => i > 65);
            foreach (var i in query6)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------ORDERBY ASC-----------");
            var query7 = from i in slist orderby i.per ascending select i;
            foreach (var i in query7)
            {
                Console.WriteLine(i.per);
            }
            Console.WriteLine("----------ORDERBY DSC-----------");
            var query8 = from i in slist orderby i.per descending select i;
            foreach (var i in query8)
            {
                Console.WriteLine(i.per);
            }
            Console.WriteLine("----------GROUPBY-----------");
            var query9 = from i in slist group i.per by i.firstname;
            foreach (var group in query9)
            {
                Console.WriteLine(group.Key);
                foreach (var i in group)
                {
                    Console.WriteLine(i);
                }
            }
            List<List<int>> arr = new List<List<int>>();
            List<int> arr1 = new List<int> { 24, 27, 69 };
            arr.Add(arr1);
            Console.WriteLine("\n-------------SelectMany query-----------------");
            var query10 = arr.SelectMany(i => i);
            foreach (var i in query10)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("----------AGGREGATE FUNCTION(SUM)-----------");
            List<int> list1 = new List<int> { 10, 20, 35, 40, 55, 60, 70, 85, 90, 100 };
            int sum = (from i in list1 where i > 60 select i).Sum();
            Console.WriteLine("sum is " + sum);
            Console.WriteLine("----------AGGREGATE FUNCTION(Max)-----------");
            int max = (from i in list1 where i > 60 select i).Max();
            Console.WriteLine("max is " + max);
            Console.WriteLine("----------AGGREGATE FUNCTION(Min)-----------");
            int min = (from i in list1 where i > 60 select i).Min();
            Console.WriteLine("min is " + min);
            Console.WriteLine("----------AGGREGATE FUNCTION(Avg)-----------");
            double avg = (from i in list1 where i > 10 & i < 50 select i).Average();
            Console.WriteLine("avg is " + avg);
            Console.WriteLine("----------AGGREGATE FUNCTION(Count)-----------");
            int count = (from i in slist select i.per).Count();
            Console.WriteLine("count is " + count);
            Console.WriteLine("----------AGGREGATE FUNCTION(Distinct)-----------");
            var query11 = (from i in slist select i.branch).Distinct();
            foreach (string i in query11)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("------------LET---------");
            var query12 = from i in slist let res = i.per + 10 select res;
            foreach (var i in query12)
            {
                Console.WriteLine(i);
            }
            student[] slist1 = new student[]
            {
                new student(){ firstname ="Saurabh",lastname = "Jadhav",smailid = "SJ123@gmail.com",branch = "Science", per= 85},
                new student(){ firstname ="Abhay",lastname = "Shinde",smailid = "AS123@gmail.com",branch = "Science", per= 95},
                new student(){ firstname ="Sumit",lastname = "Nirmale",smailid = "SN123@gmail.com",branch = "Science", per= 75},
                new student(){ firstname ="Pramod",lastname = "Patil",smailid = "PP123@gmail.com",branch = "Commerce", per= 83},
                new student(){ firstname ="Akshay",lastname = "Deore",smailid = "AD123@gmail.com",branch = "Arts", per= 65},
                new student(){ firstname ="Vishal",lastname = "Vispute",smailid = "VV123@gmail.com",branch = "Commerce", per= 88},
                new student(){ firstname ="Rushi",lastname = "Mahajan",smailid = "RM123@gmail.com",branch = "Arts", per= 98},
                new student(){ firstname ="Tushar",lastname = "Tambe",smailid = "TT123@gmail.com",branch = "Commerce", per= 65}
            };
            Console.WriteLine("-----------Into Query-------------");
            var query13 = from i in slist
                          join j in slist1 on i.per equals j.per into res
                          select res;
            foreach (var j in query13)
            {
                foreach (var i in j)
                {
                    Console.WriteLine($"{i.firstname},{i.lastname},{i.smailid},{i.branch},{i.per}");
                }
            }
            Console.WriteLine("---------------Oftype Query-------------");
            object[] obj = new object[] { 1, "String", 2, "Double", 0 };
            Console.WriteLine("All the integer type values in the obj");
            var query14 = obj.OfType<int>();
            foreach (var i in query14)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("------------First Query--------------");
            var query15 = (from i in slist where i.branch == "Science" select i.per).First();
            Console.WriteLine(query15);
            Console.WriteLine("------------FirstOrDefault Query--------------");
            var query16 = (from i in slist where i.branch == "A" select i.per).FirstOrDefault();
            Console.WriteLine(query16);
            Console.WriteLine("------------Last Query--------------");
            var query17 = (from i in slist where i.branch == "Commerce" select i.per).Last();
            Console.WriteLine(query17);
            Console.WriteLine("------------LastOrDefault Query--------------");
            var query18 = (from i in slist where i.branch == "comp" select i.per).LastOrDefault();
            Console.WriteLine(query18);
            Console.WriteLine("------------SingleOrDefault Query--------------");
            var query20 = (from i in slist where i.per == 85 select i).SingleOrDefault();
            Console.WriteLine(query20.firstname);
            Console.WriteLine("-----------Elementat and ElementatOrDefault----------");
            var query21 = (from i in slist select i).ElementAt(2);
            var query22 = (from i in slist select i.firstname).ElementAtOrDefault(3);
            Console.WriteLine(query21.firstname);
            Console.WriteLine(query22);
            Console.WriteLine("-----------IMMEDIATE EXECUTION-----------");
            List<student> studet = new List<student>
            {
                 new student(){firstname="Vijay",lastname="Rathod",smailid="VR123@gmail.com",branch="Science",per =85},
                new student(){firstname="Rushi",lastname="Gore",smailid="RG123@gmail.com",branch="Arts",per =96},
            };
            var query23 = (from i in studet select i).Count();//immidiate execution takes place if aggregate func used
            studet.Add(new student() { firstname = "Amaira", lastname = "Aggarwal", smailid = "amaira@gmai.com" });
            studet.Add(new student() { firstname = "Anu", lastname = "Aggarwal", smailid = "anu@gmai.com" });
            Console.WriteLine(query23);

            Console.WriteLine("----------DEFFERED EXECUTION-----------");
            List<student> studet1 = new List<student>
            {
                 new student(){firstname="Anuradha",lastname="palakurthi",smailid="ap4589@gmail.com",branch="Science",per =85},
                new student(){firstname="Amrutha",lastname="Patel",smailid="ap4785@gmail.com",branch="Commerce",per =75},
            };
            var query24 = (from i in studet1 select i);//here deferred execution takes place
            studet1.Add(new student() { firstname = "Amaira", lastname = "Aggarwal", smailid = "amaira@gmai.com" });
            studet1.Add(new student() { firstname = "Anu", lastname = "Aggarwal", smailid = "anu@gmai.com" });
            foreach (student i in query24) //here query1 execution starts
            {
                Console.WriteLine(i.firstname + " " + i.lastname);
            }

            Console.WriteLine("---------STARTSWITH()------------");
            var Startwith = slist.Where(i => i.firstname.StartsWith("H"));
            foreach (student i in Startwith)
            {
                Console.WriteLine(i.firstname);
            }
            Console.WriteLine("----------ENDSWITH()------------");
            var Endwith = slist.Where(i => i.firstname.EndsWith("t"));
            foreach (student i in Endwith)
            {
                Console.WriteLine(i.firstname);
            }
            Console.WriteLine("----------CONTAINS()----------");
            var contain = slist.Where(i => i.firstname.Contains("A"));
            foreach (student i in contain)
            {
                Console.WriteLine(i.firstname);
            }
            Console.WriteLine("----------Ienumerable----------");
            IEnumerable<student> ienu = (from i in slist select i).AsEnumerable();
            foreach (var i in ienu)
            {
                Console.WriteLine(i.firstname);
            }
            Console.WriteLine("----------Iqueryable-----------");
            IQueryable<student> iquery = (from i in slist select i).AsQueryable();
            foreach (var i in iquery)
            {
                Console.WriteLine(i.firstname);
            }
        }

    }
}