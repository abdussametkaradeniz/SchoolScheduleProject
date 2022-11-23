using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomersAndSchoolDtos:IEntity
    {
        [Key]
        public string CustomerAndSchool_Id { get; set; }

        public int CustomerId { get; set; }
        public int School_Id { get; set; }
    }
}
