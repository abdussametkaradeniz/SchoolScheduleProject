using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class ClassDto:IEntity
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
    }
}
