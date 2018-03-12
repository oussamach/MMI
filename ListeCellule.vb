
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeCellule
    Private Sub ListeCellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RemplirDGV()
    End Sub
    Public Sub RemplirDGV()
        Dim cellule = "SELECT [IdCellule] as 'ID',[NomCellule] as 'Cellule'FROM [dbo].[Cellule]"
        da = New SqlDataAdapter(cellule, con)
        If ds.Tables.Contains("cellule1") Then
            ds.Tables("cellule1").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "cellule1")
        con.Close()
        DataGridView1.DataSource = ds.Tables("cellule1")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim req As String = "SELECT [IdCellule] as 'ID',[NomCellule] as 'Cellule'FROM [dbo].[Cellule] where IdCellule='" & TextBox1.Text & "' "
                da = New SqlDataAdapter(req, con)
                If ds.Tables.Contains("Cell") Then
                    ds.Tables("Cell").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Cell")
                con.Close()

                If ds.Tables("Cell").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("Cell")
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
        cellule.Show()
        Me.Close()
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    If ds.Tables("cellule1").Rows.Count <> 0 Then
    '        For c = 0 To ds.Tables("cellule1").Rows.Count - 1
    '            If DataGridView1.Rows(c).Cells(0).Value = True Then
    '                ds.Tables("cellule1").Rows(c).Delete()
    '                Dim cb As New SqlCommandBuilder(da)
    '                da.Update(ds, "cellule1")
    '                MsgBox("Logiciel à été supprimer avec succée", MsgBoxStyle.Information, "Information")
    '                RemplirDGV()
    '            End If
    '        Next
    '    Else
    '        MsgBox("Aucune donner trouver pour supprimer", MsgBoxStyle.Exclamation, "Attention")
    '    End If
    'End Sub
End Class