
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeLogiciels

    Private Sub ListeCellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RempliRDGV()
    End Sub
    Public Sub RempliRDGV()
        Dim Logiciel = "SELECT  [Idlogiciel] as 'ID',[Nomlogiciel] as 'Logiciel' FROM [dbo].[logiciel]"
        da = New SqlDataAdapter(Logiciel, con)
        If ds.Tables.Contains("Logiciel1") Then
            ds.Tables("Logiciel1").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Logiciel1")
        con.Close()
        DataGridView1.DataSource = ds.Tables("Logiciel1")
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            If IsNumeric(TextBox1.Text) Then
                Dim Logiciel = "SELECT  [Idlogiciel] as 'ID',[Nomlogiciel] as 'Logiciel' FROM [dbo].[logiciel] where Idlogiciel='" & TextBox1.Text & "'"
                da = New SqlDataAdapter(Logiciel, con)
                If ds.Tables.Contains("Log") Then
                    ds.Tables("Log").Rows.Clear()
                End If
                con.Open()
                da.Fill(ds, "Log")
                con.Close()
                If ds.Tables("log").Rows.Count <> 0 Then
                    DataGridView1.DataSource = ds.Tables("Log")
                Else
                    MsgBox("Aucune Donner Trouver", MsgBoxStyle.Information, "Information")
                End If
            Else
                TextBox1.Clear()
            End If
        Else
            RempliRDGV()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Logiceil.Show()
        Me.Close()
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    'If ds.Tables("Logiciel1").Rows.Count <> 0 Then
    '    '    For c = 0 To ds.Tables("Logiciel1").Rows.Count - 1
    '    '        While DataGridView1.SelectedCells(0).RowIndex = True
    '    '            ds.Tables("Logiciel1").Rows(c).Delete()
    '    '            Dim cb As New SqlCommandBuilder(da)
    '    '            da.Update(ds, "Logiciel1")
    '    '            MsgBox("Logiciel à été supprimer avec succée", MsgBoxStyle.Information, "Information")
    '    '            RempliRDGV()
    '    '        End While
    '    '    Next
    '    'Else
    '    '    MsgBox("Aucune donner trouver pour supprimer", MsgBoxStyle.Exclamation, "Attention")
    '    'End If
    '    If ds.Tables("Logiciel1").Rows.Count <> 0 Then
    '        For c = 0 To ds.Tables("Logiciel1").Rows.Count - 1
    '            If DataGridView1.Rows(c).Cells(0).Value = True Then
    '                ds.Tables("Logiciel1").Rows(c).Delete()
    '                Dim cb As New SqlCommandBuilder(da)
    '                da.Update(ds, "Logiciel1")
    '                MsgBox("Logiciel à été supprimer avec succée", MsgBoxStyle.Information, "Information")
    '                RempliRDGV()
    '            End If
    '        Next
    '    Else
    '        MsgBox("Aucune donner trouver pour supprimer", MsgBoxStyle.Exclamation, "Attention")
    '    End If
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    If ds.Tables("Logiciel1").Rows.Count <> 0 Then
    '        For c = 0 To ds.Tables("Logiciel1").Rows.Count - 1
    '            If DataGridView1.Rows(c).Cells(0).Value = False Then
    '                DataGridView1.Rows(c).Cells(0).Value = True
    '            Else
    '                DataGridView1.Rows(c).Cells(0).Value = False
    '            End If
    '        Next
    '    Else
    '        MsgBox("Aucune donner trouver pour Selectionner", MsgBoxStyle.Exclamation, "Attention")
    '    End If
    'End Sub
End Class