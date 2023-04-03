Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Globalization
Imports BenlyDAL.BenlyDAL
Public Class Mainform
    Public conn As New SqlConnection
    Public BenlyDal As New DAL(conn)
    Public workingmeeting As String = ""
    Public dateMeeting As DateTime = DateTime.Now


    Private Sub Mainform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("vi-VN")
    End Sub

    Private Sub Mainform_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        connect2db()
        MeetingList.Show()
    End Sub
    Private Sub connect2db()
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = GetConnectionString("connDBstr")
            Try
                conn.Open()
            Catch ex As Exception
                Throw ex
                Exit Sub
            End Try
        End If
    End Sub
    Public Function GetConnectionString(ByVal key As String) As String
        Dim strApp As String = ""
        Try
            strApp = ConfigurationManager.ConnectionStrings(key).ConnectionString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return strApp
    End Function
    Public Function addthousandseperator(ByVal str As String) As String
        Dim result As String = str
        Dim len As Integer = str.Length
        If len > 3 Then
            result = result.Insert(len - 3, ".")
            len = len - 3

            While len > 3
                result = result.Insert(len - 3, ".")
                len = len - 3
            End While

        End If
        Return result
    End Function
    Private Sub DanhSáchCuộcHọpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchCuộcHọpToolStripMenuItem.Click
        MeetingList.Show()
    End Sub

    Private Sub DanhSáchCổĐôngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchCổĐôngToolStripMenuItem.Click
        HolderList.Show()
    End Sub

    Private Sub DanhSáchĐạiBiểuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchĐạiBiểuToolStripMenuItem.Click
        DelegateList.Show()
    End Sub

    Private Sub DanhSáchỦyQuyềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchỦyQuyềnToolStripMenuItem.Click
        AuthorizationList.Show()
    End Sub

    Private Sub DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Click
        MatterList.Show()
    End Sub

    Private Sub BiểuQuyếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiểuQuyếtToolStripMenuItem.Click

    End Sub

    Private Sub DanhSáchVấnĐềBầuCửToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchVấnĐềBầuCửToolStripMenuItem.Click
        ElectionList.Show()
    End Sub

    Private Sub DanhSáchỨngViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchỨngViênToolStripMenuItem.Click
        CandidateList.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        MatterVoteList.Show()
    End Sub

    Private Sub KếtQuảBầuCửToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KếtQuảBầuCửToolStripMenuItem.Click
        Elections_result.Show()
    End Sub

    Private Sub DanhSáchPhiếuBầuCửToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchPhiếuBầuCửToolStripMenuItem.Click
        ElectionVoteList.Show()
    End Sub

    Private Sub KếtQuảBiểuQuyếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KếtQuảBiểuQuyếtToolStripMenuItem.Click
        MatterVoteResult.Show()
    End Sub

    Private Sub ThôngTinCuộcHọpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThôngTinCuộcHọpToolStripMenuItem.Click
        MeetingInfoshow.ShowDialog()
    End Sub

    Private Sub DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Click
        IllegalElectionList.Show()
    End Sub

    Private Sub AbcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("abc")
    End Sub
End Class
