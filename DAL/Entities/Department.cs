﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
  public class Department
  {
    [Key] public int DepartmentId { get; set; }
    [Required] public string Name { get; set; }
  }
}
