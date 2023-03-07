using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    public class Coach : Member
    {
        public CoachLevel Level { get; set; }

        public Coach() { }

        public Coach(DateTime dateOfBirth, string firstName, string lastName, char gender, CoachLevel level) : base(dateOfBirth, firstName, lastName, gender)
        {
            this.Level = level;
        }

    }
}
