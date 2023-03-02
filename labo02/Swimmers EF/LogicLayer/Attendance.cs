/*using DataAccessLayer;
using DataAccessLayer.Models;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Attendance
    {
        public Attendance() { }

        public static List<Member> GetMembers(string kind) 
        {
            Data data = new Data();
            List<MemberModel> membersModel = data.DataMembersKind(kind);
            List<Member> members = new List<Member>();
            if (kind.Equals("Coaches"))
            {
                members = new List<Member>(membersModel.Select(m => new Coach((CoachModel)m)));
            }
            else if (kind.Equals("Swimmers"))
            {
                members = new List<Member>(membersModel.Select(m => new Swimmer((SwimmerModel)m)));
            }
            return members;
        }
    }
}
*/