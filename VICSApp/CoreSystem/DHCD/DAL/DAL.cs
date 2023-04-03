using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BenlyDAL.BenlyDAL
{
    public class DAL
    {
        private SqlConnection conn;

        public DAL(SqlConnection conn)
        {
            this.conn = conn;
        }

        public DataTable Meeting_getlist(string meetingcode)
        {
            var result = new DataTable();
            string strquerry = "Meetings_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataTable GetVoteSenate(string senateName, string meettinCode)
        {
            var result = new DataTable();
            string query;
            query = "select distinct c.CandidateCode as Code,c.CandidateName as Name from Candidates c join Elections e on c.Electioncode= e.Electioncode and e.Meetingcode= e.Meetingcode and e.ElectionName like N'%" + senateName + "%' and c.Meetingcode = '"+ meettinCode + "'";
            var cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void meeting_insert(string meetingcode, string MeetingName, string CompanyName, string companyAddress, string MeetingAddress, DateTime Meetingtime, string Period, string MettingType , string year)
        {
            string strquerry = "Meetings_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("MeetingName", SqlDbType.NVarChar).Value = MeetingName;
            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = CompanyName;
            cmd.Parameters.Add("companyAddress", SqlDbType.NVarChar).Value = companyAddress;
            cmd.Parameters.Add("MeetingAddress", SqlDbType.NVarChar).Value = MeetingAddress;
            cmd.Parameters.Add("Meetingtime", SqlDbType.SmallDateTime).Value = Meetingtime;
            cmd.Parameters.Add("@Period", SqlDbType.NVarChar).Value = Period;
            cmd.Parameters.Add("@MettingType", SqlDbType.NVarChar).Value = MettingType;
            cmd.Parameters.Add("@YearMeeting", SqlDbType.VarChar).Value = year;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void meeting_update(string meetingcode, string MeetingName, string CompanyName, string companyAddress, string MeetingAddress, DateTime Meetingtime, string Period, string MettingType, string year)
        {
            string strquerry = "Meetings_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("MeetingName", SqlDbType.NVarChar).Value = MeetingName;
            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = CompanyName;
            cmd.Parameters.Add("companyAddress", SqlDbType.NVarChar).Value = companyAddress;
            cmd.Parameters.Add("MeetingAddress", SqlDbType.NVarChar).Value = MeetingAddress;
            cmd.Parameters.Add("Meetingtime", SqlDbType.SmallDateTime).Value = Meetingtime;
            cmd.Parameters.Add("@Period", SqlDbType.NVarChar).Value = Period;
            cmd.Parameters.Add("@MettingType", SqlDbType.NVarChar).Value = MettingType;
            cmd.Parameters.Add("@YearMeeting", SqlDbType.VarChar).Value = year;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void meeting_delete(string meetingcode)
        {
            string strquerry = "Meetings_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Holder_getlist(string meetingcode, string holdercode, string HolderIdentity)
        {
            var result = new DataTable();
            string strquerry = "Holders_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@holdercode", SqlDbType.VarChar).Value = holdercode;
            cmd.Parameters.Add("@HolderIdentity", SqlDbType.VarChar).Value = HolderIdentity;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataTable Holder_getListLimited(string meetingcode, decimal intFrom, decimal intTo)
        {
            var result = new DataTable();
            string strquerry = "Holders_getListLimited";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@intFrom", SqlDbType.VarChar).Value = intFrom;
            cmd.Parameters.Add("@intTo", SqlDbType.VarChar).Value = intTo;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Holder_delete(string meetingcode, string Holdercode)
        {
            string strquerry = "Holders_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void holder_insert(string meetingcode, string Holdercode, string HolderIdentity, string HolderName, string HolderAddress, decimal Shares, decimal voterights)
        {
            string strquerry = "Holders_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Holdercode", SqlDbType.NVarChar).Value = Holdercode;
            cmd.Parameters.Add("HolderIdentity", SqlDbType.NVarChar).Value = HolderIdentity;
            cmd.Parameters.Add("HolderName", SqlDbType.NVarChar).Value = HolderName;
            cmd.Parameters.Add("HolderAddress", SqlDbType.NVarChar).Value = HolderAddress;
            cmd.Parameters.Add("Shares", SqlDbType.Int).Value = Shares;
            cmd.Parameters.Add("voterights", SqlDbType.Int).Value = voterights;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void holder_update(string meetingcode, string Holdercode, string HolderIdentity, string HolderName, string HolderAddress, decimal Shares, decimal voterights)
        {
            string strquerry = "Holders_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Holdercode", SqlDbType.NVarChar).Value = Holdercode;
            cmd.Parameters.Add("HolderIdentity", SqlDbType.NVarChar).Value = HolderIdentity;
            cmd.Parameters.Add("HolderName", SqlDbType.NVarChar).Value = HolderName;
            cmd.Parameters.Add("HolderAddress", SqlDbType.NVarChar).Value = HolderAddress;
            cmd.Parameters.Add("Shares", SqlDbType.Int).Value = Shares;
            cmd.Parameters.Add("voterights", SqlDbType.Int).Value = voterights;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Delegate_getlist(string meetingcode, decimal Delegatecode, string IdentityCard)
        {
            var result = new DataTable();
            string strquerry = "Delegates_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Delegatecode", SqlDbType.VarChar).Value = Delegatecode;
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = IdentityCard;
            cmd.Parameters.Add("@Delegatename", SqlDbType.VarChar).Value = "";
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Delegate_delete(string meetingcode, string Delegatecode)
        {
            string strquerry = "Delegates_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Delegatecode", SqlDbType.VarChar).Value = Delegatecode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal Delegate_insert(string meetingcode, string Delegatename, string IdentityCard, string DelegateAddress)
        {
            string strquerry = "Delegates_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("DelegateName", SqlDbType.NVarChar).Value = Delegatename;
            cmd.Parameters.Add("IdentityCard", SqlDbType.NVarChar).Value = IdentityCard;
            cmd.Parameters.Add("DelegateAddress", SqlDbType.NVarChar).Value = DelegateAddress;
            var delegatecode = new SqlParameter();
            delegatecode = cmd.Parameters.Add("delegatecode", SqlDbType.Int);
            delegatecode.Direction = ParameterDirection.Output;
            // cmd.Parameters.Add(delegatecode)
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Conversions.ToDecimal(delegatecode.Value);
        }

        public void Delegate_update(string meetingcode, decimal delegatecode, string Delegatename, string IdentityCard, string DelegateAddress)
        {
            string strquerry = "Delegates_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode;
            cmd.Parameters.Add("DelegateName", SqlDbType.NVarChar).Value = Delegatename;
            cmd.Parameters.Add("IdentityCard", SqlDbType.NVarChar).Value = IdentityCard;
            cmd.Parameters.Add("DelegateAddress", SqlDbType.NVarChar).Value = DelegateAddress;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getAuthorizationByDelegateCode(string workingmeeting, string DelegateCode)
        {
            string strHolders;
            strHolders = "";
            var dt = new DataTable();
            try
            {
                dt = Authorizations_getlist(workingmeeting, Conversions.ToDecimal(DelegateCode), "", "", "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
            if (dt.Rows.Count <= 0) return "";
            foreach (DataRow dr in dt.Rows)
                strHolders = Conversions.ToString(Operators.AddObject(Operators.AddObject(strHolders, dr["holdername"]), ", "));
            return strHolders.Remove(strHolders.Length - 2, 2);
        }

        public DataTable Authorizations_getlist(string meetingcode, decimal Delegatecode, string holdercode, string IdentityCard, string holderIdentity)
        {
            var result = new DataTable();
            string strquerry = "Authorizations_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Delegatecode", SqlDbType.Int).Value = Delegatecode;
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = IdentityCard;
            cmd.Parameters.Add("@Holdercode", SqlDbType.VarChar).Value = holdercode;
            cmd.Parameters.Add("@HolderIdentity", SqlDbType.VarChar).Value = holderIdentity;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Authorizations_insert(string meetingcode, string Holdercode, decimal delegatecode, decimal delegateright)
        {
            string strquerry = "Authorizations_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode;
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode;
            cmd.Parameters.Add("delegateright", SqlDbType.Int).Value = delegateright;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Authorizations_delete(string meetingcode, decimal Delegatecode, string holdercode)
        {
            string strquerry = "Authorizations_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Delegatecode", SqlDbType.Int).Value = Delegatecode;
            cmd.Parameters.Add("holdercode", SqlDbType.VarChar).Value = holdercode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Authorizations_update(string meetingcode, string Holdercode, decimal delegatecode, decimal delegateright)
        {
            string strquerry = "Authorizations_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode;
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode;
            cmd.Parameters.Add("delegateright", SqlDbType.Int).Value = delegateright;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Matter_getlist(string meetingcode, decimal mattercode)
        {
            var result = new DataTable();
            string strquerry = "Matters_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Matter_insert(string meetingcode, string Mattercode, string Mattername, string MatterDescription)
        {
            string strquerry = "Matters_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode;
            cmd.Parameters.Add("Mattername", SqlDbType.NVarChar).Value = Mattername;
            cmd.Parameters.Add("MatterDescription", SqlDbType.NVarChar).Value = MatterDescription;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Matter_update(string meetingcode, string Mattercode, string Mattername, string MatterDescription)
        {
            string strquerry = "Matters_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode;
            cmd.Parameters.Add("Mattername", SqlDbType.NVarChar).Value = Mattername;
            cmd.Parameters.Add("MatterDescription", SqlDbType.NVarChar).Value = MatterDescription;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Matter_delete(string meetingcode, string Mattercode)
        {
            string strquerry = "Matters_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Election_getlist(string meetingcode, decimal electioncode)
        {
            var result = new DataTable();
            string strquerry = "Elections_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Election_insert(string meetingcode, decimal electioncode, string electionname, string electionDescription, decimal numofcandidates)
        {
            string strquerry = "elections_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("electionname", SqlDbType.NVarChar).Value = electionname;
            cmd.Parameters.Add("electionDescription", SqlDbType.NVarChar).Value = electionDescription;
            cmd.Parameters.Add("numofcandidates", SqlDbType.NVarChar).Value = numofcandidates;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Election_update(string meetingcode, decimal electioncode, string electionname, string electionDescription, decimal numofcandidates)
        {
            string strquerry = "elections_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("electionname", SqlDbType.NVarChar).Value = electionname;
            cmd.Parameters.Add("electionDescription", SqlDbType.NVarChar).Value = electionDescription;
            cmd.Parameters.Add("numofcandidates", SqlDbType.NVarChar).Value = numofcandidates;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Election_delete(string meetingcode, decimal electioncode)
        {
            string strquerry = "elections_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Candidates_getlist(string meetingcode, decimal electioncode, decimal candidatecode)
        {
            var result = new DataTable();
            string strquerry = "Candidates_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode;
            cmd.Parameters.Add("@candidatecode", SqlDbType.VarChar).Value = candidatecode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataTable Candidates_getlist_4voteupdate(string meetingcode, decimal electioncode, decimal candidatecode, decimal delegatecode)
        {
            var result = new DataTable();
            string strquerry = "Candidates_getlist_4voteupdate";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode;
            cmd.Parameters.Add("@candidatecode", SqlDbType.VarChar).Value = candidatecode;
            cmd.Parameters.Add("@delegatecode", SqlDbType.VarChar).Value = delegatecode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void Candidate_insert(string meetingcode, decimal electioncode, decimal candidatecode, string candidatename, string candidateaddress)
        {
            string strquerry = "candidates_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode;
            cmd.Parameters.Add("candidatename", SqlDbType.NVarChar).Value = candidatename;
            cmd.Parameters.Add("candidateaddress", SqlDbType.NVarChar).Value = candidateaddress;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Candidate_update(string meetingcode, decimal electioncode, decimal candidatecode, string candidatename, string candidateaddress)
        {
            string strquerry = "candidates_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode;
            cmd.Parameters.Add("candidatename", SqlDbType.NVarChar).Value = candidatename;
            cmd.Parameters.Add("candidateaddress", SqlDbType.NVarChar).Value = candidateaddress;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Candidate_delete(string meetingcode, decimal electioncode, decimal candidatecode)
        {
            string strquerry = "candidates_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MatterVotes_insert(string meetingcode, decimal mattercode, decimal HolderCode, decimal DelegateCode, bool Agree, bool disAgree, bool noidea)
        {
            string strquerry = "Mattervotes_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            // cmd.Parameters.Add("@HolderCode", SqlDbType.Int).Value = HolderCode
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree;
            cmd.Parameters.Add("@Disagree", SqlDbType.Bit).Value = disAgree;
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MatterVotes_insert_remain(string meetingcode, decimal mattercode, decimal DelegateCode, bool Agree, bool disAgree, bool noidea)
        {
            string strquerry = "Mattervotes_insert_remain";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode;
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree;
            cmd.Parameters.Add("@Disagree", SqlDbType.Bit).Value = disAgree;
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MatterVotes_update(string meetingcode, decimal mattercode, decimal delegatecode, bool Agree, bool disAgree, bool noidea)
        {
            string strquerry = "Mattervotes_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode;
            cmd.Parameters.Add("@delegatecode", SqlDbType.Int).Value = delegatecode;
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree;
            cmd.Parameters.Add("@DisAgree", SqlDbType.Bit).Value = disAgree;
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MatterVotes_delete(string meetingcode, decimal mattercode, decimal delegatecode, decimal HolderCode)
        {
            string strquerry = "Mattervotes_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode;
            cmd.Parameters.Add("@delegatecode", SqlDbType.Int).Value = delegatecode;
            // cmd.Parameters.Add("@HolderCode", SqlDbType.Int).Value = HolderCode
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable MatterVotes_getlist(string meetingcode, decimal mattercode, string holderIdentify)
        {
            var result = new DataTable();
            string strquerry = "Mattervotes_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("@holderIdentify", SqlDbType.VarChar).Value = holderIdentify;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public MatterVoteInfo MatterVotes_Infor_get(string meetingcode, decimal mattercode)
        {
            var result = new MatterVoteInfo();
            string strquerry = "matters_VoteInfor_get";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode;
            SqlDataReader reader3;
            try
            {
                reader3 = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            while (reader3.Read())
            {
                result.sumofdelegates = Conversions.ToDecimal(reader3["sumofdelegates"]);
                result.enteredvotes = Conversions.ToDecimal(reader3["enteredvotes"]);
                result.remainvotes = Conversions.ToDecimal(reader3["remainvotes"]);
                result.AgreedDelegates = Conversions.ToDecimal(reader3["AgreedDelegates"]);
                result.DisAgreedDelegates = Conversions.ToDecimal(reader3["DisAgreedDelegates"]);
                result.Noideaddelegates = Conversions.ToDecimal(reader3["Noideaddelegates"]);
                result.mattername = Conversions.ToString(reader3["mattername"]);
            }

            reader3.Close();
            return result;
        }

        public DataTable ElectionVotes_getlist(string meetingcode, decimal electioncode, decimal DelegateCode, decimal candidatecode)
        {
            var result = new DataTable();
            string strquerry = "Electionvotes_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.Parameters.Add("@candidateCode", SqlDbType.Int).Value = candidatecode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void ElectionVotes_insert(string meetingcode, decimal electioncode, decimal DelegateCode, decimal CandidateCode, decimal Votes)
        {
            string strquerry = "Electionvotes_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
            cmd.Parameters.Add("@votes", SqlDbType.Int).Value = Votes;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElectionVotes_update(string meetingcode, decimal electioncode, decimal DelegateCode, decimal CandidateCode, decimal Votes)
        {
            string strquerry = "Electionvotes_update";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
            cmd.Parameters.Add("@votes", SqlDbType.Int).Value = Votes;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElectionVotes_delete(string meetingcode, decimal electioncode, decimal DelegateCode, decimal CandidateCode)
        {
            string strquerry = "Electionvotes_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ElectionVotes_delete_all(string meetingcode, decimal electioncode, decimal DelegateCode, decimal CandidateCode)
        {
            string strquerry = "Electionvotes_delete_all";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IllegalElectionVotes_insert(string meetingcode, decimal electioncode, decimal DelegateCode)
        {
            string strquerry = "IllegalElectionvotes_insert";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IllegalElectionVotes_delete(string meetingcode, decimal electioncode, decimal DelegateCode)
        {
            string strquerry = "IllegalElectionvotes_delete";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IllegalElectionVotes_getlist(string meetingcode, decimal electioncode, decimal DelegateCode)
        {
            var result = new DataTable();
            string strquerry = "IllegalElectionvotes_getlist";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode;
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public struct MatterVoteInfo
        {
            public string mattername;
            public decimal sumofdelegates;
            public decimal enteredvotes;
            public decimal remainvotes;
            public decimal AgreedDelegates;
            public decimal DisAgreedDelegates;
            public decimal Noideaddelegates;
        }

        public struct ElectionVoteInfo
        {
            public decimal numberoflegalVote;
            public decimal numberofIllegalVote;
            public decimal LegalVoteRights;
            public decimal IllegalVoteRights;
            public decimal SummeetingVoteRight;
        }

        public ElectionVoteInfo ElectionVotes_Infor_get(string meetingcode, decimal electioncode)
        {
            var result = new ElectionVoteInfo();
            string strquerry = "Elections_VoteInfor_get";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode;
            SqlDataReader reader3;
            try
            {
                reader3 = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            while (reader3.Read())
            {
                result.numberoflegalVote = Conversions.ToDecimal(reader3["numberoflegalVote"]);
                result.numberofIllegalVote = Conversions.ToDecimal(reader3["numberofIllegalVote"]);
                result.LegalVoteRights = Conversions.ToDecimal(reader3["LegalVoteRights"]);
                result.IllegalVoteRights = Conversions.ToDecimal(reader3["IllegalVoteRights"]);
                result.SummeetingVoteRight = Conversions.ToDecimal(reader3["SummeetingVoteRight"]);
            }

            reader3.Close();
            return result;
        }

        public DataTable ElectionVotes_getresult(string meetingcode, decimal electioncode)
        {
            var result = new DataTable();
            string strquerry = "Electionvotes_Getresult";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode;
            var da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public struct MeetingInfo
        {
            public string companyname;
            public string meetingname;
            public decimal sumofholders;
            public decimal sumofshares;
            public decimal sumofvoterights;
            public decimal numofdelegates;
            public decimal numofholderparticipated;
            public decimal numofholderAuthorised;
            public decimal sumofholderAndAuthorizatedUser;
            public decimal sumofparticipedVoterights;
        }

        public MeetingInfo Meeting_Infor_get(string meetingcode)
        {
            var result = new MeetingInfo();
            string strquerry = "Meetings_VoteInfor_get";
            var cmd = new SqlCommand(strquerry, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode;
            SqlDataReader reader3;
            try
            {
                reader3 = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            while (reader3.Read())
            {
                result.companyname = Conversions.ToString(reader3["companyname"]);
                result.meetingname = Conversions.ToString(reader3["meetingname"]);
                result.sumofholders = Conversions.ToDecimal(reader3["sumofholders"]);
                result.sumofshares = Conversions.ToDecimal(reader3["sumofshares"]);
                result.sumofvoterights = Conversions.ToDecimal(reader3["sumofvoterights"]);
                result.numofdelegates = Conversions.ToDecimal(reader3["numofdelegates"]);
                result.numofholderparticipated = Conversions.ToDecimal(reader3["numofholderparticipated"]);
                result.numofholderAuthorised = Conversions.ToDecimal(reader3["numofholderAuthorised"]);
                result.sumofholderAndAuthorizatedUser = Conversions.ToDecimal(reader3["sumofholderAndAuthorizatedUser"]);
                result.sumofparticipedVoterights = Conversions.ToDecimal(reader3["sumofparticipedVoterights"]);
            }

            reader3.Close();
            return result;
        }
    }
}