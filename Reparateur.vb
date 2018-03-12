Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Reparateur
    Dim da1 As SqlDataAdapter
    Shared i As Integer
    Private Sub Utilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Dim ser As String = " select * from Cellule"
        da = New SqlDataAdapter(ser, con)
        If ds.Tables.Contains("Cellule") Then
            ds.Tables("Cellule").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "Cellule")
        con.Close()
        ComboBox1.DisplayMember = ds.Tables("Cellule").Columns(1).ToString
        ComboBox1.ValueMember = ds.Tables("Cellule").Columns(0).ToString
        ComboBox1.DataSource = ds.Tables("Cellule")
        Reparateur()
    End Sub
    Public Sub nouveau()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.SelectedIndex = 1
    End Sub
    Public Sub navigation(ByVal p As String)
        Try
            If dt.Rows.Count <> 0 Then
                TextBox1.Text = dt.Rows(p)(0).ToString
                TextBox2.Text = dt.Rows(p)(1).ToString
                TextBox3.Text = dt.Rows(p)(2).ToString
                TextBox4.Text = dt.Rows(p)(3).ToString
                ComboBox1.SelectedValue = dt.Rows(p)(4).ToString
                Label8.Text = (i + 1) & "/" & dt.Rows.Count

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim pos As Boolean
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de nom  de reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf TextBox3.Text = "" Then
                MsgBox("Remplir le champs de prenom de reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf TextBox4.Text = "" Then
                MsgBox("Remplir le champs de nom reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Aucune Cellule Trouver" + vbCrLf + "Il faut ajouter un cellule avant modifier un reparateur", MsgBoxStyle.Information, "Information")
            Else
                For c = 0 To dt.Rows.Count - 1
                    If TextBox1.Text = dt.Rows(c)(0) Then
                        dt.Rows(c)(1) = TextBox2.Text
                        dt.Rows(c)(2) = TextBox3.Text
                        dt.Rows(c)(3) = TextBox4.Text
                        dt.Rows(c)(4) = ComboBox1.SelectedValue
                        Dim cb As New SqlCommandBuilder(da1)
                        da1.Update(ds, "Reparateur")
                        MsgBox("Le Reparateur à été Modifier", MsgBoxStyle.Information, "Information")
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
            If MsgBox("Voulez-vous vraiment supprimer ce réparateur ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If dt.Rows.Count <> 0 Then
                    dt.Rows(i).Delete()
                    Dim cb As New SqlCommandBuilder(da1)
                    da1.Update(ds, "reparateur")
                    nouveau()
                    navigation(0)

                    MsgBox("Le reparateur  à été supprimer avec Sucée", MsgBoxStyle.Information, "Information")
                    Label8.Text = (i + 1) & "/" & dt.Rows.Count
                Else
                    MsgBox("Aucun Données Trouver pour Supprimer", MsgBoxStyle.Exclamation, "infromation")

                End If
            Else
                MsgBox("la suppression a ete annulé", MsgBoxStyle.Exclamation, "Information")
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        i = 0
        navigation(0)
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
        ListeReparateur.Show()
    End Sub
    Public Sub Reparateur()
        Dim reparateur = "select * from Reparateur"
        da1 = New SqlDataAdapter(reparateur, con)
        If ds.Tables.Contains("Reparateur") Then
            ds.Tables("Reparateur").Rows.Clear()
        End If
        con.Open()
        da1.Fill(ds, "Reparateur")
        con.Close()
        dt = ds.Tables("Reparateur")
        If dt.Rows.Count <> 0 Then
            navigation(0)
            Label8.Text = (i + 1) & "/" & dt.Rows.Count
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir le champs de nom  de reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf TextBox3.Text = "" Then
                MsgBox("Remplir le champs de prenom de reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf TextBox4.Text = "" Then
                MsgBox("Remplir le champs de nom reparateur ", MsgBoxStyle.Information, "Information")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Aucune Cellule Trouver" + vbCrLf + "Il faut ajouter un cellule avant ajouter un reparateur", MsgBoxStyle.Information, "Information")
            Else
                dr1 = dt.NewRow
                dr1(1) = TextBox2.Text
                dr1(2) = TextBox3.Text
                dr1(3) = TextBox4.Text
                dr1(4) = ComboBox1.SelectedValue
                dt.Rows.Add(dr1)
                Dim cb As New SqlCommandBuilder(da1)
                da1.Update(ds, "Reparateur")
                MsgBox("Le Reparateur à été Ajouter", MsgBoxStyle.Information, "Information")
                TextBox1.Text = dt.Rows.Count
                Label8.Text = (i + 1) & "/" & dt.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
        Reparateur()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        For j As Integer = 0 To dt.Rows.Count - 1
            If dt(j)(0).ToString = TextBox1.Text Then
                TextBox2.Text = dt.Rows(j)(1).ToString
                TextBox3.Text = dt.Rows(j)(2).ToString
                TextBox4.Text = dt.Rows(j)(3).ToString
                ComboBox1.SelectedValue = dt.Rows(j)(4).ToString
                i = j
            End If
        Next
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Text = ""
        End If
    End Sub
End Class
