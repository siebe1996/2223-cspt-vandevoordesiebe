using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicLayer
{
    public class SwimmingPool
    {
        public string City { get; }
        public int Id { get; }
        public PoolLaneLength LaneLength { get; }
        public string Name { get; }
        public string Street { get; }
        public int ZipCode { get; }

        public SwimmingPool(SwimmingPoolModel swimmingPool)
        {
            City = swimmingPool.City;
            Id = swimmingPool.Id;
            LaneLength = (PoolLaneLength)swimmingPool.LaneLength;
            Name = swimmingPool.Name;
            Street = swimmingPool.Street;
            ZipCode = swimmingPool.ZipCode;
        }
        public SwimmingPool(string city, int id, PoolLaneLength laneLength, string name, string street, int zipCode)
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
