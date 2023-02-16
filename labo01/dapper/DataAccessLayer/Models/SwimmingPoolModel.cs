using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SwimmingPoolModel
    {
        public string City { get; }
        public int Id { get; }
        public PoolLaneLengthModel LaneLength { get; }
        public string Name { get; }
        public string Street { get; }
        public int ZipCode { get; }

        public SwimmingPoolModel(int id, string city, PoolLaneLengthModel laneLength, string name, string street, int zipCode)
        {
            City = city;
            Id = id;
            LaneLength = laneLength;
            Name = name;
            Street = street;
            ZipCode = zipCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
