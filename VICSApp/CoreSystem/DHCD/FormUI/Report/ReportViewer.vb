Imports CrystalDecisions.CrystalReports.Engine

Partial Public Class ReportViewer
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(reportDocument As ReportClass)
        Me.New()
        CrystalReportViewer1.ReportSource = reportDocument
    End Sub


    Private Sub ReportViewer_Load(sender As Object, e As EventArgs)
        CrystalReportViewer1.Show()
    End Sub

    Friend Shared Function LoadReport(reportDocument As ReportClass, owner As Form) As ReportViewer
        Dim v As New ReportViewer(reportDocument)
        v.Show()
        v.WindowState = FormWindowState.Maximized
        Return v
    End Function
End Class