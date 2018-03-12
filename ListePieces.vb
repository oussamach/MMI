Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListePieces
    Private Sub ListeCellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGv()
    End Sub
    Public Sub RemplirDGv()
        Dim Pieces = "select IdPieces as 'ID'  , NomPieces as 'Nom Pieces' from dbo.pieces"
        da = New SqlDataAdapter(Pieces, con)
        If ds.Tables.Contains("Pieces") Then
            ds.Tables("Pieces").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Pieces")
        con.Close()
        DataGridView1.DataSource = ds.Tables("Pieces")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim Pieces = "select IdPieces as 'ID'  , NomPieces as 'Nom Pieces' from dbo.pieces where IdPieces='" & TextBox1.Text & "'"
                da = New SqlDataAdapter(Pieces, con)
                If ds.Tables.Contains("Pi") Then
                    ds.Tables("Pi").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Pi")
                con.Close()
                If ds.Tables("Pi").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("Pi")
                Else
                    MsgBox("Aucune Donner Trouver", MsgBoxStyle.Information, "Information")
                End If
            Else
                TextBox1.Clear()
            End If
        Else
            RemplirDGv()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Pieces.Show()
        Me.Close()
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class