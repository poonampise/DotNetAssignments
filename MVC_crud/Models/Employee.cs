﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Configuration.Provider;
using ModelBindingAndDbCode.Models;



namespace ModelBindingAndDbCode.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }

    }
}