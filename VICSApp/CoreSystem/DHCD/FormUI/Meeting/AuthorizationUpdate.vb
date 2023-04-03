Public Class AuthorizationUpdate
    Dim updatedelegate As Integer
    Dim updateholdercode As String
    Dim initdelegateright As Integer
    Public Sub New(ByVal delegatecode As Integer, ByVal holdercode As String, ByVal delegateright As Integer)
        InitializeComponent()
        Me.updatedelegate = delegatecode
        Me.updateholdercode = holdercode
        Me.initdelegateright = delegateright
    End Sub
    Private Sub AuthorizationUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim daibieu As DataTable
        Dim codong As DataTable
        Try
            daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, updatedelegate, "")
            codong = Mainform.BenlyDal.Holder_getlist(Mainform.workingmeeting, updateholdercode, "")
        Catch ex As Exception
            MsgBox("Lỗi : " + ex.Message)
            Exit Sub
        End Try
        MaskedTextBox2.Text = daibieu.Rows(0).Item("Delegatecode")
        MaskedTextBox3.Text = daibieu.Rows(0).Item("IdentityCard")
        MaskedTextBox4.Text = daibieu.Rows(0).Item("DelegateName")
        MaskedTextBox8.Text = codong.Rows(0).Item("Holdercode")
        MaskedTextBox7.Text = codong.Rows(0).Item("HolderIdentity")
        MaskedTextBox6.Text = codong.Rows(0).Item("Holdername")
        StockTextBox1.Text = codong.Rows(0).Item("Voterights")
        StockTextBox2.Text = initdelegateright

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Mainform.BenlyDal.Authorizations_update(Mainform.workingmeeting, MaskedTextBox8.Text, MaskedTextBox2.Text, StockTextBox2.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox("Lỗi" + ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class