using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Manager");
            Employee o1 = new Manager("Manager", "Poonam", 4000, 12);
            o1.DisplayData();
            Console.ReadLine();

            Console.WriteLine("GenerelManager");
            Employee o2 = new GenerelManager("Food", "general manager", "Poonam", 4000, 14);
            o2.DisplayData();
            Console.ReadLine();


            Console.WriteLine("CEO");
            CEO o3 = new CEO("poonam", 59000, 101);
            o3.DisplayData();


            Console.ReadLine();

        }
    }
    public abstract class Employee
    {
        public Employee(string name = "poonam", decimal basic = 4000, short deptNo = 12)
        {
            this.EmpNo = ++empNo;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
        }
        private string name;
        public string Name
        {
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Enter a Correct Name");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }

        // private static int lastEmpNo = 0;
        private static int empNo = 0;
        public int EmpNo
        {
            get;

            private set;
        }

        private decimal basic;
        public abstract decimal Basic { get; set; }


        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Depart no should be greater then 0");
                }
                else
                {
                    deptNo = value;
                }

            }
            get
            {
                return deptNo;
            }
        }
        public virtual void DisplayData()
        {
            Console.WriteLine("Employee Id : " + EmpNo);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee department : " + DeptNo);
            //Console.WriteLine("Employee designation : " + designation);
            Console.WriteLine("==========");
        }

        public abstract decimal CalcNetSalary();
    }


    public class Manager : Employee
    {
        public int BASIS, DA, HRA;
        public decimal GROSS;

        public override decimal Basic { get; set; }


        public Manager(string designation = "manager", string name = "poonam", decimal basic = 4000, short deptNo = 12) : base(name, basic, deptNo)
        {
            this.Designation = designation;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
        }
        private string designation;
        public string Designation
        {
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Designation should not be empty");
                }
                else
                {
                    designation = value;
                }
            }
            get
            {
                return designation;
            }
        }

        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.4 * BASIS);
            HRA = (int)(0.3 * BASIS);
            GROSS = Basic + DA + HRA;
            return GROSS;
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Employee designation : " + designation);
            Console.WriteLine("Employee Salaary : " + CalcNetSalary());
            Console.WriteLine("============");
        }
    }

    public class GenerelManager : Manager
    {
        private string perks;
        public string Perks
        {
            get; set;
        }



        public GenerelManager(string perks = "KitKat", string designation = "manager", string name = "Poonam", decimal basic = 2500, short deptNo = 10) : base(designation, name, basic, deptNo)
        {
            this.Perks = perks;
            this.Designation = designation;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
        }


        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.4 * BASIS);
            HRA = (int)(0.3 * BASIS);
            GROSS = Basic + DA + HRA + 500;
            return GROSS;
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Employee  perks : " + Perks);
            Console.WriteLine("===========================================");
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic { get; set; }

        public CEO(string name = "poonam", decimal basic = 6000, short deptNo = 101) : base(name, basic, deptNo)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
        }

        public int BASIS, DA, HRA;
        public decimal GROSS;
        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.5 * BASIS);
            HRA = (int)(0.4 * BASIS);
            GROSS = Basic + DA + HRA;
            return GROSS;
        }

        public override sealed void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("CEO  Sal : " + CalcNetSalary());
            Console.WriteLine("=====");
        }
    }
}

