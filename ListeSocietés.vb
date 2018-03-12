Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class ListeSocietés

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click


    End Sub

    Private Sub ListeCellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim Societe = "select IdSociete as 'ID'  ,NomSociete as 'Nom Societe' from dbo.Societe"
        da = New SqlDataAdapter(Societe, con)
        If ds.Tables.Contains("Societe1") Then
            ds.Tables("Societe1").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Societe1")
        con.Close()
        DataGridView1.DataSource = ds.Tables("Societe1")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim Societe = "select IdSociete as 'ID'  ,NomSociete as 'Nom Societe' from dbo.Societe where IdSociete='" & TextBox1.Text & "'"
                da = New SqlDataAdapter(Societe, con)
                If ds.Tables.Contains("Societe1") Then
                    ds.Tables("Societe1").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Societe1")
                con.Close()
                If ds.Tables("Societe1").Rows.Count Then
                    DataGridView1.DataSource = ds.Tables("Societe1")
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Societé.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class