Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class ListePannes
    Private Sub ListePannes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panne.Show()
        Me.Close()
    End Sub
    Public Sub RemplirDGV()
        Dim lpanne = "SELECT dbo.panne.IdPanne AS ID, dbo.Material.Marque AS Material, dbo.panne.objet AS Objet, dbo.panne.DateDePanne AS [Date de Panne], dbo.panne.traitement AS Traitement, dbo.panne.EtatPanne AS [Panne Reparer dans], dbo.panne.Effectuer FROM dbo.Material INNER JOIN dbo.panne ON dbo.Material.NumInventaire = dbo.panne.NumInventaire"
        da = New SqlDataAdapter(lpanne, con)
        If ds.Tables.Contains("Lpanne") Then
            ds.Tables("Lpanne").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Lpanne")
        con.Close()
        DataGridView1.DataSource = ds.Tables("Lpanne")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim lpanne = "SELECT dbo.panne.IdPanne AS ID, dbo.Material.Marque AS Material, dbo.panne.objet AS Objet, dbo.panne.DateDePanne AS [Date de Panne], dbo.panne.traitement AS Traitement, dbo.panne.EtatPanne AS [Panne Reparer dans], dbo.panne.Effectuer FROM dbo.Material INNER JOIN dbo.panne ON dbo.Material.NumInventaire = dbo.panne.NumInventaire where IdPanne='" & TextBox1.Text & "'"
                da = New SqlDataAdapter(lpanne, con)
                If ds.Tables.Contains("Pa") Then
                    ds.Tables("Pa").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Pa")
                con.Close()
                If ds.Tables("Pa").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("Pa")
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



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class