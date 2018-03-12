Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class ListeService

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click


    End Sub

    Private Sub ListeCellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim service = "select IdService as 'ID'  ,LibelleService as 'Libelle Service' from dbo.Service"
        da = New SqlDataAdapter(service, con)
        If ds.Tables.Contains("listeservice") Then
            ds.Tables("listeservice").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "listeservice")
        con.Close()
        DataGridView1.DataSource = ds.Tables("listeservice")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim service = "select IdService as 'ID'  ,LibelleService as 'Libelle Service' from dbo.Service where IdService='" & TextBox1.Text & "' "
                da = New SqlDataAdapter(service, con)
                If ds.Tables.Contains("listeservice") Then
                    ds.Tables("listeservice").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "listeservice")
                con.Close()
                If ds.Tables("listeservice").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("listeservice")
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
        Service.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class