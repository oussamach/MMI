Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeMaterial

    Private Sub ListeMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim Material = "select dbo.Material.NumInventaire as 'Numero Inventaire',dbo.Material.Marque as 'Marque', dbo.Material.NumSerie as 'Numero Serie', Utilisateur.NomUtilisateur as 'Nom Utilisateur' from dbo.Utilisateur inner join dbo.Material on dbo.Utilisateur.IdUtilisateur = dbo.Material.IdUtilisateur"
        da = New SqlDataAdapter(Material, con)
        If ds.Tables.Contains("Material1") Then
            ds.Tables("Material1").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Material1")
        con.Close()
        DataGridView1.DataSource = ds.Tables("Material1")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim Material = "select dbo.Material.NumInventaire as 'Numero Inventaire',dbo.Material.Marque as 'Marque', dbo.Material.NumSerie as 'Numero Serie', Utilisateur.NomUtilisateur as 'Nom Utilisateur' from dbo.Utilisateur inner join dbo.Material on dbo.Utilisateur.IdUtilisateur = dbo.Material.IdUtilisateur where NumInventaire='" & TextBox1.Text & "' "
                da = New SqlDataAdapter(Material, con)
                If ds.Tables.Contains("Mat") Then
                    ds.Tables("Mat").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Mat")
                con.Close()
                If ds.Tables("Mat").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("Mat")
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
        Material.Show()
        Me.Close()
    End Sub
End Class