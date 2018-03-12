﻿
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Pieces
    Dim da1 As SqlDataAdapter
    Shared i As Integer
    Private Sub Service_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TextBox1.Enabled = False
        Pieces()
    End Sub
    Public Sub navigation(ByVal p As String)
        If dt.Rows.Count <> 0 Then
            TextBox1.Text = dt.Rows(p)(0).ToString
            TextBox2.Text = dt.Rows(p)(1).ToString
            Label4.Text = (i + 1) & "/" & dt.Rows.Count

        End If
    End Sub

    Public Sub nouveau()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()

    End Sub
    Public Sub Pieces()
        Dim pieces = "select * from pieces"
        da1 = New SqlDataAdapter(pieces, con)
        If ds.Tables.Contains("pc") Then
            ds.Tables("pc").Rows.Clear()
        End If
        con.Open()
        da1.Fill(ds, "pc")
        con.Close()
        dt = ds.Tables("pc")
        If dt.Rows.Count <> 0 Then
            navigation(0)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de  nom de pieces", MsgBoxStyle.Information, "Information")
            Else
                dr1 = dt.NewRow
                dr1(1) = TextBox2.Text
                cb = New SqlCommandBuilder(da1)
                dt.Rows.Add(dr1)
                da1.Update(ds, "pc")
                MsgBox("Pieces Ajouter", MsgBoxStyle.Information, "Information")
                TextBox1.Text = dt.Rows.Count
                Label4.Text = (i + 1) & "/" & dt.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
        Pieces()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim pos As Boolean
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de  nom de pieces", MsgBoxStyle.Information, "Information")
            Else
                For c = 0 To dt.Rows.Count - 1
                    If TextBox1.Text = dt.Rows(c)(0) Then
                        dt.Rows(c)(1) = TextBox2.Text
                        cb = New SqlCommandBuilder(da1)
                        da1.Update(ds, "pc")
                        MsgBox("Pieces Modifier", MsgBoxStyle.Information, "Information")
                        pos = True
                    End If
                Next
                If pos = False Then
                    MsgBox("Aucune Donner Trouver Pour Modifier", MsgBoxStyle.Information, "Information")
                End If
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If dt.Rows.Count <> 0 Then
                If MsgBox("Voulez-vous vraiment supprimer cette pièce?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    dt.Rows(i).Delete()
                    Dim cb As New SqlCommandBuilder(da1)
                    da1.Update(ds, "pieces")
                    i = 0
                    nouveau()
                    navigation(0)
                    MsgBox("Le pieces  à été supprimer avec Sucée", MsgBoxStyle.Information, "Information")
                    Label4.Text = (i + 1) & "/" & dt.Rows.Count
                Else
                    MsgBox("la suppression a ete annulé", MsgBoxStyle.Exclamation, "Information")

                End If
            Else
                MsgBox("Aucun pieces trouve pour  supprimer", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If MsgBox("Voullez Vous Vraiment Fermer ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Me.Close()
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        i = 0
        navigation(i)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If i > 0 Then
            i = i - 1
        Else
            i = dt.Rows.Count - 1
        End If
        navigation(i)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If i < dt.Rows.Count - 1 Then
            i = i + 1
        Else
            i = 0
        End If
        navigation(i)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        i = dt.Rows.Count - 1
        navigation(i)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ListePieces.Show()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        For j As Integer = 0 To dt.Rows.Count - 1
            If dt(j)(0).ToString = TextBox1.Text Then
                TextBox2.Text = dt.Rows(j)(1).ToString
                i = j
            End If
        Next
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Text = ""
        End If
    End Sub
End Class