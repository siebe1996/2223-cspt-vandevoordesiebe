using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    [BsonKnownTypes(typeof(Swimmer), typeof(Coach))]
    public abstract class Member : IComparable<Member>
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        
        public string Discriminator { get; set; }

        public Member() { }

        public Member(DateTime dateOfBirth, string firstName, string lastName, char gender)
        {
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }

        public int CompareTo(Member member)
        {
            if (member == null) return 1;
            else
                return this.LastName.CompareTo(member.LastName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public override bool Equals(object? obj)
        {
            return obj is Member member &&
                   DateOfBirth == member.DateOfBirth &&
                   FirstName == member.FirstName &&
                   LastName == member.LastName &&
                   Gender == member.Gender &&
                   Id == member.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DateOfBirth, FirstName, LastName, Gender, Id);
        }
    }
}
