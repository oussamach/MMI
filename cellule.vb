Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class cellule
    Dim da1 As New SqlDataAdapter
    Shared i As Integer

    Private Sub cellule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cellule()
        'TextBox1.Enabled = False
    End Sub

    Public Sub Cellule()
        Dim cellule = "select * from Cellule"
        da1 = New SqlDataAdapter(cellule, con)
        If ds.Tables.Contains("Cellule") Then
            ds.Tables("Cellule").Rows.Clear()
        End If
        con.Open()
        da1.Fill(ds, "Cellule")
        con.Close()
        dt = ds.Tables("Cellule")
        If dt.Rows.Count <> 0 Then
            navigation(i)
        End If
    End Sub

    Public Sub nouveau()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Public Sub navigation(ByVal p As String)
        If dt.Rows.Count <> 0 Then
            TextBox1.Text = dt.Rows(p)(0).ToString
            TextBox2.Text = dt.Rows(p)(1).ToString
            Label4.Text = (i + 1) & "/" & dt.Rows.Count
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de nom de cellule", MsgBoxStyle.Information, "Attention")
            Else
                dr1 = dt.NewRow
                dr1(1) = TextBox2.Text
                dt.Rows.Add(dr1)
                cb = New SqlCommandBuilder(da1)
                da1.Update(ds, "Cellule")
                MsgBox("La Cellule a été ajouter", MsgBoxStyle.Information, "Information")
                Label4.Text = (i + 1) & "/" & dt.Rows.Count
                TextBox1.Text = dt.Rows.Count
                Cellule()
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de nom de cellule", MsgBoxStyle.Information, "Attention")
            Else
                Dim pos As Boolean
                For c = 0 To dt.Rows.Count - 1
                    If TextBox1.Text = dt.Rows(c)(0) Then
                        'dt.Rows(i)(0) = TextBox1.Text
                        dt.Rows(c)(1) = TextBox2.Text
                        Dim cb As New SqlCommandBuilder(da1)
                        da1.Update(ds, "Cellule")
                        MsgBox("Le Cellule à été Modifier", MsgBoxStyle.Information, "Information")
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
            If MsgBox("Voulez-vous vraiment supprimer cette cellule?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If dt.Rows.Count <> 0 Then
                    dt.Rows(i).Delete()
                    Dim cb As New SqlCommandBuilder(da1)
                    da1.Update(ds, "Cellule")
                    i = 0
                    nouveau()
                    navigation(0)
                    MsgBox("Le Service  à été supprimer avec Sucée", MsgBoxStyle.Information, "Information")
                    Label4.Text = (i + 1) & "/" & dt.Rows.Count
                Else
                    MsgBox("Aucun Données Trouver pour Supprimer", MsgBoxStyle.Exclamation, "infromation")
                End If
            Else
                MsgBox("La suppression a été annule", MsgBoxStyle.Exclamation, "Information")
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
        ListeCellule.Show()
        Me.Hide()
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