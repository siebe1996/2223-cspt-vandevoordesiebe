using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public abstract class MemberModel : IComparable<MemberModel>
    {
        public DateTime DateOfBirth { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public char Gender { get; }
        public int Id { get; }

        public MemberModel(int id, DateTime dateOfBirth, string firstName, string lastName, char gender)
        {
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Id = id;
        }

        public int CompareTo(MemberModel member)
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
            return obj is MemberModel member &&
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
