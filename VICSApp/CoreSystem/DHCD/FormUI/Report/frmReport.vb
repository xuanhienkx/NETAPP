Public Class frmReport

    Dim cr As New phieubieuquyet1
    Public Property Phieubieuquyet()
        Get
            Return cr
        End Get
        Set(ByVal value)
            cr = value
        End Set
    End Property

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CrystalReportViewer1.ReportSource = cr
        CrystalReportViewer1.Show()

    End Sub
End Class