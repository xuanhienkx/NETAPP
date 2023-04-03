Imports System.IO
Imports System.Net
Imports System.Text
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient

Namespace BenlyDAL
    Public Class DAL
        Dim conn As SqlConnection
        Public Sub New(ByVal conn As SqlConnection)
            Me.conn = conn
        End Sub
        Public Function Meeting_getlist(ByVal meetingcode As String) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Meetings_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function

        Public Function GetVoteSenate(ByVal senateName As String) As DataTable
            Dim result As New DataTable
            Dim query As String
            query = "select c.CandidateCode as Code,c.CandidateName as Name from Candidates c join Elections e on c.Electioncode= e.Electioncode and e.ElectionName like N'%" & senateName & "%'"
            Dim cmd As New SqlCommand(query, conn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Sub meeting_insert(ByVal meetingcode As String, ByVal MeetingName As String, ByVal CompanyName As String, ByVal companyAddress As String, ByVal MeetingAddress As String, ByVal Meetingtime As DateTime)
            Dim strquerry As String = "Meetings_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("MeetingName", SqlDbType.NVarChar).Value = MeetingName
            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = CompanyName
            cmd.Parameters.Add("companyAddress", SqlDbType.NVarChar).Value = companyAddress
            cmd.Parameters.Add("MeetingAddress", SqlDbType.NVarChar).Value = MeetingAddress
            cmd.Parameters.Add("Meetingtime", SqlDbType.SmallDateTime).Value = Meetingtime
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub meeting_update(ByVal meetingcode As String, ByVal MeetingName As String, ByVal CompanyName As String, ByVal companyAddress As String, ByVal MeetingAddress As String, ByVal Meetingtime As DateTime)
            Dim strquerry As String = "Meetings_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("MeetingName", SqlDbType.NVarChar).Value = MeetingName
            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = CompanyName
            cmd.Parameters.Add("companyAddress", SqlDbType.NVarChar).Value = companyAddress
            cmd.Parameters.Add("MeetingAddress", SqlDbType.NVarChar).Value = MeetingAddress
            cmd.Parameters.Add("Meetingtime", SqlDbType.SmallDateTime).Value = Meetingtime
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub meeting_delete(ByVal meetingcode As String)
            Dim strquerry As String = "Meetings_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Function Holder_getlist(ByVal meetingcode As String, ByVal holdercode As String, ByVal HolderIdentity As String) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Holders_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@holdercode", SqlDbType.VarChar).Value = holdercode
            cmd.Parameters.Add("@HolderIdentity", SqlDbType.VarChar).Value = HolderIdentity
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function

        Public Function Holder_getListLimited(ByVal meetingcode As String, ByVal intFrom As Decimal, ByVal intTo As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Holders_getListLimited"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@intFrom", SqlDbType.VarChar).Value = intFrom
            cmd.Parameters.Add("@intTo", SqlDbType.VarChar).Value = intTo
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function


        Public Sub Holder_delete(ByVal meetingcode As String, ByVal Holdercode As String)
            Dim strquerry As String = "Holders_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode
            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub holder_insert(ByVal meetingcode As String, ByVal Holdercode As String, ByVal HolderIdentity As String, ByVal HolderName As String, ByVal HolderAddress As String, ByVal Shares As Decimal, ByVal voterights As Decimal)
            Dim strquerry As String = "Holders_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Holdercode", SqlDbType.NVarChar).Value = Holdercode
            cmd.Parameters.Add("HolderIdentity", SqlDbType.NVarChar).Value = HolderIdentity
            cmd.Parameters.Add("HolderName", SqlDbType.NVarChar).Value = HolderName
            cmd.Parameters.Add("HolderAddress", SqlDbType.NVarChar).Value = HolderAddress
            cmd.Parameters.Add("Shares", SqlDbType.Int).Value = Shares
            cmd.Parameters.Add("voterights", SqlDbType.Int).Value = voterights
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub holder_update(ByVal meetingcode As String, ByVal Holdercode As String, ByVal HolderIdentity As String, ByVal HolderName As String, ByVal HolderAddress As String, ByVal Shares As Decimal, ByVal voterights As Decimal)
            Dim strquerry As String = "Holders_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Holdercode", SqlDbType.NVarChar).Value = Holdercode
            cmd.Parameters.Add("HolderIdentity", SqlDbType.NVarChar).Value = HolderIdentity
            cmd.Parameters.Add("HolderName", SqlDbType.NVarChar).Value = HolderName
            cmd.Parameters.Add("HolderAddress", SqlDbType.NVarChar).Value = HolderAddress
            cmd.Parameters.Add("Shares", SqlDbType.Int).Value = Shares
            cmd.Parameters.Add("voterights", SqlDbType.Int).Value = voterights
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Function Delegate_getlist(ByVal meetingcode As String, ByVal Delegatecode As Decimal, ByVal IdentityCard As String) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Delegates_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Delegatecode", SqlDbType.VarChar).Value = Delegatecode
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = IdentityCard
            cmd.Parameters.Add("@Delegatename", SqlDbType.VarChar).Value = ""
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function

        Public Sub Delegate_delete(ByVal meetingcode As String, ByVal Delegatecode As String)
            Dim strquerry As String = "Delegates_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Delegatecode", SqlDbType.VarChar).Value = Delegatecode
            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Function Delegate_insert(ByVal meetingcode As String, ByVal Delegatename As String, ByVal IdentityCard As String, ByVal DelegateAddress As String) As Decimal
            Dim strquerry As String = "Delegates_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("DelegateName", SqlDbType.NVarChar).Value = Delegatename
            cmd.Parameters.Add("IdentityCard", SqlDbType.NVarChar).Value = IdentityCard
            cmd.Parameters.Add("DelegateAddress", SqlDbType.NVarChar).Value = DelegateAddress
            Dim delegatecode As New SqlParameter
            delegatecode = cmd.Parameters.Add("delegatecode", SqlDbType.Int)
            delegatecode.Direction = ParameterDirection.Output
            ' cmd.Parameters.Add(delegatecode)
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
            Return delegatecode.Value
        End Function
        Public Sub Delegate_update(ByVal meetingcode As String, ByVal delegatecode As Decimal, ByVal Delegatename As String, ByVal IdentityCard As String, ByVal DelegateAddress As String)
            Dim strquerry As String = "Delegates_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode
            cmd.Parameters.Add("DelegateName", SqlDbType.NVarChar).Value = Delegatename
            cmd.Parameters.Add("IdentityCard", SqlDbType.NVarChar).Value = IdentityCard
            cmd.Parameters.Add("DelegateAddress", SqlDbType.NVarChar).Value = DelegateAddress
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Function getAuthorizationByDelegateCode(ByVal workingmeeting As String, ByVal DelegateCode As String) As String
            Dim strHolders As String
            strHolders = ""
            Dim dt As New DataTable
            Try
                dt = Authorizations_getlist(workingmeeting, DelegateCode, "", "", "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try

            For Each dr As DataRow In dt.Rows
                strHolders = strHolders + dr.Item("holdername") + ", "
            Next
            Return strHolders.Remove(strHolders.Length - 2, 2)

        End Function


        Public Function Authorizations_getlist(ByVal meetingcode As String, ByVal Delegatecode As Decimal, ByVal holdercode As String, ByVal IdentityCard As String, ByVal holderIdentity As String) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Authorizations_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Delegatecode", SqlDbType.Int).Value = Delegatecode
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = IdentityCard
            cmd.Parameters.Add("@holdercode", SqlDbType.VarChar).Value = holdercode
            cmd.Parameters.Add("@holderIdentity", SqlDbType.VarChar).Value = holderIdentity
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Sub Authorizations_insert(ByVal meetingcode As String, ByVal Holdercode As String, ByVal delegatecode As Decimal, ByVal delegateright As Decimal)
            Dim strquerry As String = "Authorizations_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode
            cmd.Parameters.Add("delegateright", SqlDbType.Int).Value = delegateright
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Authorizations_delete(ByVal meetingcode As String, ByVal Delegatecode As Decimal, ByVal holdercode As String)
            Dim strquerry As String = "Authorizations_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Delegatecode", SqlDbType.Int).Value = Delegatecode
            cmd.Parameters.Add("holdercode", SqlDbType.VarChar).Value = holdercode

            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Authorizations_update(ByVal meetingcode As String, ByVal Holdercode As String, ByVal delegatecode As Decimal, ByVal delegateright As Decimal)
            Dim strquerry As String = "Authorizations_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("Holdercode", SqlDbType.VarChar).Value = Holdercode
            cmd.Parameters.Add("delegatecode", SqlDbType.Int).Value = delegatecode
            cmd.Parameters.Add("delegateright", SqlDbType.Int).Value = delegateright
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Function Matter_getlist(ByVal meetingcode As String, ByVal mattercode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Matters_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Sub Matter_insert(ByVal meetingcode As String, ByVal Mattercode As String, ByVal Mattername As String, ByVal MatterDescription As String)
            Dim strquerry As String = "Matters_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode
            cmd.Parameters.Add("Mattername", SqlDbType.NVarChar).Value = Mattername
            cmd.Parameters.Add("MatterDescription", SqlDbType.NVarChar).Value = MatterDescription
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Matter_update(ByVal meetingcode As String, ByVal Mattercode As String, ByVal Mattername As String, ByVal MatterDescription As String)
            Dim strquerry As String = "Matters_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode
            cmd.Parameters.Add("Mattername", SqlDbType.NVarChar).Value = Mattername
            cmd.Parameters.Add("MatterDescription", SqlDbType.NVarChar).Value = MatterDescription
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Matter_delete(ByVal meetingcode As String, ByVal Mattercode As String)
            Dim strquerry As String = "Matters_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("mattercode", SqlDbType.Int).Value = Mattercode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Function Election_getlist(ByVal meetingcode As String, ByVal electioncode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Elections_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function

        Public Sub Election_insert(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal electionname As String, ByVal electionDescription As String, ByVal numofcandidates As Decimal)
            Dim strquerry As String = "elections_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("electionname", SqlDbType.NVarChar).Value = electionname
            cmd.Parameters.Add("electionDescription", SqlDbType.NVarChar).Value = electionDescription
            cmd.Parameters.Add("numofcandidates", SqlDbType.NVarChar).Value = numofcandidates
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Sub Election_update(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal electionname As String, ByVal electionDescription As String, ByVal numofcandidates As Decimal)
            Dim strquerry As String = "elections_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("electionname", SqlDbType.NVarChar).Value = electionname
            cmd.Parameters.Add("electionDescription", SqlDbType.NVarChar).Value = electionDescription
            cmd.Parameters.Add("numofcandidates", SqlDbType.NVarChar).Value = numofcandidates
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Election_delete(ByVal meetingcode As String, ByVal electioncode As Decimal)
            Dim strquerry As String = "elections_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Function Candidates_getlist(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal candidatecode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Candidates_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode
            cmd.Parameters.Add("@candidatecode", SqlDbType.VarChar).Value = candidatecode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Function Candidates_getlist_4voteupdate(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal candidatecode As Decimal, ByVal delegatecode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Candidates_getlist_4voteupdate"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode
            cmd.Parameters.Add("@candidatecode", SqlDbType.VarChar).Value = candidatecode
            cmd.Parameters.Add("@delegatecode", SqlDbType.VarChar).Value = delegatecode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Sub Candidate_insert(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal candidatecode As Decimal, ByVal candidatename As String, ByVal candidateaddress As String)
            Dim strquerry As String = "candidates_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode
            cmd.Parameters.Add("candidatename", SqlDbType.NVarChar).Value = candidatename
            cmd.Parameters.Add("candidateaddress", SqlDbType.NVarChar).Value = candidateaddress
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Sub Candidate_update(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal candidatecode As Decimal, ByVal candidatename As String, ByVal candidateaddress As String)
            Dim strquerry As String = "candidates_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode
            cmd.Parameters.Add("candidatename", SqlDbType.NVarChar).Value = candidatename
            cmd.Parameters.Add("candidateaddress", SqlDbType.NVarChar).Value = candidateaddress
            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub Candidate_delete(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal candidatecode As Decimal)
            Dim strquerry As String = "candidates_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("candidatecode", SqlDbType.Int).Value = candidatecode
            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Sub MatterVotes_insert(ByVal meetingcode As String, ByVal mattercode As Decimal, ByVal HolderCode As Decimal, ByVal DelegateCode As Decimal, ByVal Agree As Boolean, ByVal disAgree As Boolean, ByVal noidea As Boolean)
            Dim strquerry As String = "Mattervotes_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            'cmd.Parameters.Add("@HolderCode", SqlDbType.Int).Value = HolderCode
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree
            cmd.Parameters.Add("@Disagree", SqlDbType.Bit).Value = disAgree
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub MatterVotes_insert_remain(ByVal meetingcode As String, ByVal mattercode As Decimal, ByVal DelegateCode As Decimal, ByVal Agree As Boolean, ByVal disAgree As Boolean, ByVal noidea As Boolean)
            Dim strquerry As String = "Mattervotes_insert_remain"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree
            cmd.Parameters.Add("@Disagree", SqlDbType.Bit).Value = disAgree
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub MatterVotes_update(ByVal meetingcode As String, ByVal mattercode As Decimal, ByVal delegatecode As Decimal, ByVal Agree As Boolean, ByVal disAgree As Boolean, ByVal noidea As Boolean)
            Dim strquerry As String = "Mattervotes_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode
            cmd.Parameters.Add("@delegatecode", SqlDbType.Int).Value = delegatecode
            cmd.Parameters.Add("@Agree", SqlDbType.Bit).Value = Agree
            cmd.Parameters.Add("@DisAgree", SqlDbType.Bit).Value = disAgree
            cmd.Parameters.Add("@Noidea", SqlDbType.Bit).Value = noidea
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub MatterVotes_delete(ByVal meetingcode As String, ByVal mattercode As Decimal, ByVal delegatecode As Decimal, HolderCode As Decimal)
            Dim strquerry As String = "Mattervotes_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("@meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@Mattercode", SqlDbType.Int).Value = mattercode
            cmd.Parameters.Add("@delegatecode", SqlDbType.Int).Value = delegatecode
            'cmd.Parameters.Add("@HolderCode", SqlDbType.Int).Value = HolderCode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub

        Public Function MatterVotes_getlist(ByVal meetingcode As String, ByVal mattercode As Decimal, ByVal holderIdentify As String) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Mattervotes_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@holderIdentify", SqlDbType.VarChar).Value = holderIdentify
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Function MatterVotes_Infor_get(ByVal meetingcode As String, ByVal mattercode As Decimal) As MatterVoteInfo
            Dim result As New MatterVoteInfo
            Dim strquerry As String = "matters_VoteInfor_get"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@mattercode", SqlDbType.VarChar).Value = mattercode

            Dim reader3 As SqlDataReader
            Try
                reader3 = cmd.ExecuteReader()
            Catch ex As Exception
                Throw ex
            End Try
            While reader3.Read()
                result.sumofdelegates = reader3("sumofdelegates")
                result.enteredvotes = reader3("enteredvotes")
                result.remainvotes = reader3("remainvotes")
                result.AgreedDelegates = reader3("AgreedDelegates")
                result.DisAgreedDelegates = reader3("DisAgreedDelegates")
                result.Noideaddelegates = reader3("Noideaddelegates")
                result.mattername = reader3("mattername")
            End While
            reader3.Close()
            Return result
        End Function
        Public Function ElectionVotes_getlist(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal, ByVal candidatecode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Electionvotes_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.Parameters.Add("@candidateCode", SqlDbType.Int).Value = candidatecode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Sub ElectionVotes_insert(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal, ByVal CandidateCode As Decimal, ByVal Votes As Decimal)
            Dim strquerry As String = "Electionvotes_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode
            cmd.Parameters.Add("@votes", SqlDbType.Int).Value = Votes
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub ElectionVotes_update(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal, ByVal CandidateCode As Decimal, ByVal Votes As Decimal)
            Dim strquerry As String = "Electionvotes_update"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode
            cmd.Parameters.Add("@votes", SqlDbType.Int).Value = Votes
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub ElectionVotes_delete(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal, ByVal CandidateCode As Decimal)
            Dim strquerry As String = "Electionvotes_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub ElectionVotes_delete_all(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal, ByVal CandidateCode As Decimal)
            Dim strquerry As String = "Electionvotes_delete_all"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub IllegalElectionVotes_insert(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal)
            Dim strquerry As String = "IllegalElectionvotes_insert"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Sub IllegalElectionVotes_delete(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal)
            Dim strquerry As String = "IllegalElectionvotes_delete"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.Parameters.Add("meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            cmd.CommandType = CommandType.StoredProcedure

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw (ex)
            End Try
        End Sub
        Public Function IllegalElectionVotes_getlist(ByVal meetingcode As String, ByVal electioncode As Decimal, ByVal DelegateCode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "IllegalElectionvotes_getlist"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode
            cmd.Parameters.Add("@DelegateCode", SqlDbType.Int).Value = DelegateCode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try

            Return result
        End Function
        Public Structure MatterVoteInfo
            Dim mattername As String
            Dim sumofdelegates As Decimal
            Dim enteredvotes As Decimal
            Dim remainvotes As Decimal
            Dim AgreedDelegates As Decimal
            Dim DisAgreedDelegates As Decimal
            Dim Noideaddelegates As Decimal
        End Structure
        Public Structure ElectionVoteInfo
            Dim numberoflegalVote As Decimal
            Dim numberofIllegalVote As Decimal
            Dim LegalVoteRights As Decimal
            Dim IllegalVoteRights As Decimal
            Dim SummeetingVoteRight As Decimal
        End Structure
        Public Function ElectionVotes_Infor_get(ByVal meetingcode As String, ByVal electioncode As Decimal) As ElectionVoteInfo
            Dim result As New ElectionVoteInfo
            Dim strquerry As String = "Elections_VoteInfor_get"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.VarChar).Value = electioncode

            Dim reader3 As SqlDataReader
            Try
                reader3 = cmd.ExecuteReader()
            Catch ex As Exception
                Throw ex
            End Try
            While reader3.Read()
                result.numberoflegalVote = reader3("numberoflegalVote")
                result.numberofIllegalVote = reader3("numberofIllegalVote")
                result.LegalVoteRights = reader3("LegalVoteRights")
                result.IllegalVoteRights = reader3("IllegalVoteRights")
                result.SummeetingVoteRight = reader3("SummeetingVoteRight")
            End While
            reader3.Close()
            Return result
        End Function
        Public Function ElectionVotes_getresult(ByVal meetingcode As String, ByVal electioncode As Decimal) As DataTable
            Dim result As New DataTable
            Dim strquerry As String = "Electionvotes_Getresult"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode
            cmd.Parameters.Add("@electioncode", SqlDbType.Int).Value = electioncode
            Dim da As New SqlDataAdapter(cmd)
            Try
                da.Fill(result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        Public Structure MeetingInfo
            Dim companyname As String
            Dim meetingname As String
            Dim sumofholders As Decimal
            Dim sumofshares As Decimal
            Dim sumofvoterights As Decimal
            Dim numofdelegates As Decimal
            Dim numofholderparticipated As Decimal
            Dim numofholderAuthorised As Decimal
            Dim sumofholderAndAuthorizatedUser As Decimal
            Dim sumofparticipedVoterights As Decimal
        End Structure

        Public Function Meeting_Infor_get(ByVal meetingcode As String) As MeetingInfo
            Dim result As New MeetingInfo
            Dim strquerry As String = "Meetings_VoteInfor_get"
            Dim cmd As New SqlCommand(strquerry, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Meetingcode", SqlDbType.VarChar).Value = meetingcode

            Dim reader3 As SqlDataReader
            Try
                reader3 = cmd.ExecuteReader()
            Catch ex As Exception
                Throw ex
            End Try
            While reader3.Read()
                result.companyname = reader3("companyname")
                result.meetingname = reader3("meetingname")
                result.sumofholders = reader3("sumofholders")
                result.sumofshares = reader3("sumofshares")
                result.sumofvoterights = reader3("sumofvoterights")
                result.numofdelegates = reader3("numofdelegates")
                result.numofholderparticipated = reader3("numofholderparticipated")
                result.numofholderAuthorised = reader3("numofholderAuthorised")
                result.sumofholderAndAuthorizatedUser = reader3("sumofholderAndAuthorizatedUser")
                result.sumofparticipedVoterights = reader3("sumofparticipedVoterights")
            End While
            reader3.Close()
            Return result
        End Function

    End Class
End Namespace
