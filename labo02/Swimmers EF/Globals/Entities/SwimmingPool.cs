//using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Globals.Entities
{
    public class SwimmingPool
    {
        public string City { get; set; }
        public int Id { get; set; }
        public PoolLaneLength LaneLength { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }

        /*public SwimmingPool(SwimmingPoolModel swimmingPool)
        {
            City = swimmingPool.City;
            Id = swimmingPool.Id;
            LaneLength = (PoolLaneLength)swimmingPool.LaneLength;
            Name = swimmingPool.Name;
            Street = swimmingPool.Street;
            ZipCode = swimmingPool.ZipCode;
        }*/

        public SwimmingPool(string city, PoolLaneLength laneLength, string name, string street, int zipCode)
        {
            City = city;
            LaneLength = laneLength;
            Name = name;
            Street = street;
            ZipCode = zipCode;
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
            return string.Format("{0} {1}", Name, LaneLength);
        }
    }
}
