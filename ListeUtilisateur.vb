Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeUtilisateur

    Private Sub ListeUtilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim Lutilisateur = "SELECT dbo.Utilisateur.idUtilisateur as 'ID',dbo.Utilisateur.NomUtilisateur AS Nom, dbo.Utilisateur.PrenomUtilisateur AS Prenom, dbo.Utilisateur.TelephoneUtilisateur AS Telephone, dbo.Service.LibelleService AS [Libelle Service] FROM dbo.Service INNER JOIN dbo.Utilisateur ON dbo.Service.IdService = dbo.Utilisateur.IdService"
        da = New SqlDataAdapter(Lutilisateur, con)
        If ds.Tables.Contains("ListeUtilisateur") Then
            ds.Tables("ListeUtilisateur").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "ListeUtilisateur")
        con.Close()
        DataGridView1.DataSource = ds.Tables("ListeUtilisateur")

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Utilisateur.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim Lutilisateur = "SELECT dbo.Utilisateur.idUtilisateur as 'ID',dbo.Utilisateur.NomUtilisateur AS Nom, dbo.Utilisateur.PrenomUtilisateur AS Prenom, dbo.Utilisateur.TelephoneUtilisateur AS Telephone, dbo.Service.LibelleService AS [Libelle Service] FROM dbo.Service INNER JOIN dbo.Utilisateur ON dbo.Service.IdService = dbo.Utilisateur.IdService where dbo.Utilisateur.IdUtilisateur ='" & TextBox1.Text & "'  "
                da = New SqlDataAdapter(Lutilisateur, con)
                If ds.Tables.Contains("ListeUtilisateur") Then
                    ds.Tables("ListeUtilisateur").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "ListeUtilisateur")
                con.Close()
                If ds.Tables("ListeUtilisateur").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("ListeUtilisateur")
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
End Class