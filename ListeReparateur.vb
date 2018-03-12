Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeReparateur
    Private Sub ListeMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim rep = "select IdRep as 'ID',NomRep as 'Nom',PrenomRep as 'Prenom',TelephoneRep as 'Telephone', NomCellule as Cellule from Reparateur inner  join Cellule on dbo.Reparateur.IdCellule=Cellule.IdCellule"
        da = New SqlDataAdapter(rep, con)
        If ds.Tables.Contains("rep") Then
            ds.Tables("rep").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "rep")
        con.Close()
        DataGridView1.DataSource = ds.Tables("rep")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim rep = "select IdRep as 'ID',NomRep as 'Nom',PrenomRep as 'Prenom',TelephoneRep as 'Telephone', NomCellule as Cellule from Reparateur inner  join Cellule on dbo.Reparateur.IdCellule=Cellule.IdCellule where IdRep='" & TextBox1.Text & "'"
                da = New SqlDataAdapter(rep, con)
                If ds.Tables.Contains("rep") Then
                    ds.Tables("rep").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "rep")
                con.Close()
                If ds.Tables("rep").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("rep")
                Else
                    MsgBox("Aucune Donner Trouver", MsgBoxStyle.Information, "Information")
                End If
            Else
                TextBox1.Clear()
            End If
        Else
            RemplirDGV()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Reparateur.Show()
        Me.Close()
    End Sub
End Class