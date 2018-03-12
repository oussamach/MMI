Imports System.Data.SqlClient
Imports System .Data.Sql
Public Class Mtr
    Dim pp As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim req66 As String = "update  Material set Marque= '" & TextBox1.Text & "',NumSerie='" & TextBox2.Text & "' where NumInventaire = '" & idd & "'  "
        Dim smdm As New SqlCommand(req66, cnx)
        cnx.Open()
        smdm.ExecuteNonQuery()
        cnx.Close()
        Dim req99 As String = "update  panne set Effectuer = 'Terminé' where  (IdPanne= '" & Intervention3.ComboBox3.SelectedItem & "' )  "
        Dim req90 As String = "update  Intervention set EtatIntervention = 'Changé' where  (idPanne = '" & Intervention3.ComboBox3.SelectedItem & "' )  "
        Dim smddd As New SqlCommand(req99, cnx)
        Dim etta As New SqlCommand(req90, cnx)
        cnx.Open()
        smddd.ExecuteNonQuery()
        etta.ExecuteNonQuery()
        cnx.Close()
        Intervention3.ComboBox3.Items.Clear()
        Intervention3.termin2()
        Intervention3.loadd()
        Intervention3.repart()
        Intervention3.affichage()
        Intervention3.repart()
        Intervention3.termin2()
        Intervention3.Button11.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class