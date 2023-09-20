using FluentValidationAndAutoMapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationAndAutoMapper.Entity
{
    internal class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
        public int SeatsNumber { get; set; }

    }
}
