using Common;
using Common.ExtensionMethod;
using DataAccess.ExtendedTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.PrimaryTypes
{
    public class PartyMember : BaseClass
    {
        
   

        private static string JsonFilePath = AppConfiguration.PartyMemberFile;

        public int MemberId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //public string MemberCardNo { get; set; }

        


        public static bool AddPartyMember(PartyMember partyMember)
        {
            bool isExist = false;
            partyMember.MemberId = GetNextId(out isExist, partyMember);

            if(isExist)
            {
                return false;
            }
            InsertSingleObjectToListJson(JsonFilePath, partyMember);
            return true;
        }

        public static List<PartyMember> GetAll()
        {
            return ReadFileAsObjects<PartyMember>(JsonFilePath);
        }


        public static void Update(PartyMember updatedmember)
        {

            try
            {

                //List<PartyMember> list = ReadFileAsObjects<Zonal>(JsonFilePath);

                //var division = list.Where(c => c.ZonalId == updatedCustomer.ZonalId).First();

                //division.Name = updatedCustomer.Name;

                //WriteObjectsToFile(list, JsonFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Zonal GetDivisionDetails(Zonal division)
        {
            try
            {
                List<Zonal> list = ReadFileAsObjects<Zonal>(JsonFilePath);
                return list.Where(c => c.ZonalId == division.ZonalId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void DeleteDivision(int customerId, int sequenceNo)
        {
            try
            {
                List<Zonal> list = ReadFileAsObjects<Zonal>(JsonFilePath);

                var itemToDelete = list.Where(c => c.ZonalId == customerId).FirstOrDefault();
                list.Remove(itemToDelete);

                WriteObjectsToFile(list, JsonFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetNextId(out bool isExist, PartyMember pm)
        {
            List<PartyMember> list = ReadFileAsObjects<PartyMember>(JsonFilePath);

            isExist = list.Any(a => a.PhoneNumber.Trim() == pm.PhoneNumber);

            if (list == null || list.Count == 0) return 1;


            return (list.Max(m => m.MemberId) + 1);


        }

    }



}
