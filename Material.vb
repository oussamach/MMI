Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Material
    Shared i As Integer
    Dim daUti As SqlDataAdapter
    Dim daMat As SqlDataAdapter
    Private Sub Material_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        'TextBox1.Enabled = False
        Dim uti As String = " select * from utilisateur"
        daUti = New SqlDataAdapter(uti, con)
        If ds.Tables.Contains("utilisateur") Then
            ds.Tables("utilisateur").Rows.Clear()

        End If
        con.Open()
        daUti.Fill(ds, "utilisateur")
        con.Close()
        ComboBox1.DisplayMember = ds.Tables("utilisateur").Columns(1).ToString
        ComboBox1.ValueMember = ds.Tables("utilisateur").Columns(0).ToString
        ComboBox1.DataSource = ds.Tables("utilisateur")
        Material()
    End Sub
    Public Sub Material()
        Dim material = "select * from material"
        daMat = New SqlDataAdapter(material, con)
        If ds.Tables.Contains("material") Then
            ds.Tables("material").Rows.Clear()
        End If
        con.Open()
        daMat.Fill(ds, "material")
        con.Close()
        dt = ds.Tables("material")
        If dt.Rows.Count <> 0 Then
            navigation(0)
        End If
    End Sub
    Public Sub navigation(ByVal p As String)
        If dt.Rows.Count <> 0 Then
            TextBox1.Text = dt.Rows(p)(0).ToString
            TextBox2.Text = dt.Rows(p)(1).ToString
            TextBox3.Text = dt.Rows(p)(2).ToString
            ComboBox1.SelectedValue = dt.Rows(p)(3).ToString
            Label8.Text = (i + 1) & "/" & dt.Rows.Count
        End If
    End Sub
    Public Sub nouveau()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedIndex = 1
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir  le champs de nom material", MsgBoxStyle.Information, "Information")
            ElseIf TextBox3.Text = "" Then
                MsgBox("Remplir  le champs de numero série de material", MsgBoxStyle.Information, "Information")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Aucune  utilisateur trouver" + vbCrLf + "Il faut ajouter un  utilisateurs avant  l'ajout un material ", MsgBoxStyle.Information, "Information")
            Else
                dr1 = dt.NewRow
                'dar(0) = TextBox1.Text
                dr1(1) = TextBox2.Text
                dr1(2) = TextBox3.Text
                dr1(3) = ComboBox1.SelectedValue
                dt.Rows.Add(dr1)
                cb = New SqlCommandBuilder(daMat)
                daMat.Update(ds, "material")
                MsgBox("le Material à été ajouter", MsgBoxStyle.Information, "Information")
                TextBox1.Text = dt.Rows.Count
                Label8.Text = (i + 1) & "/" & dt.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
        Material()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text = "" Then
                MsgBox("Remplir  le champs de nom material", MsgBoxStyle.Information, "Information")
            ElseIf TextBox3.Text = "" Then
                MsgBox("Remplir  le champs de numero série de material", MsgBoxStyle.Information, "Information")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Aucune  utilisateur trouver" + vbCrLf + "Il faut ajouter un  utilisateurs avant  l'ajout un material ", MsgBoxStyle.Information, "Information")
            Else
                Dim pos As Boolean
                For c = 0 To dt.Rows.Count - 1
                    If TextBox1.Text = dt.Rows(c)(0) Then
                        dt.Rows(c)(1) = TextBox2.Text
                        dt.Rows(c)(2) = TextBox3.Text
                        dt.Rows(c)(3) = ComboBox1.SelectedValue
                        cb = New SqlCommandBuilder(daMat)
                        daMat.Update(ds, "material")
                        MsgBox("Le material à été Modifier", MsgBoxStyle.Information, "Information")
                        TextBox1.Text = dt.Rows(0)(0)
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
            If MsgBox("Voulez-vous vraiment supprimer ce material?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If dt.Rows.Count <> 0 Then
                    dt.Rows(i).Delete()
                    cb = New SqlCommandBuilder(daMat)
                    daMat.Update(ds, "material")
                    i = 0
                    nouveau()
                    navigation(0)
                    MsgBox("Le material  à été supprimer avec Sucée", MsgBoxStyle.Information, "Information")
                    Label8.Text = (i + 1) & "/" & dt.Rows.Count
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
        Me.Close()

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
            i += 1
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
        ListeMaterial.Show()
        Me.Hide()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        For j As Integer = 0 To dt.Rows.Count - 1
            If dt(j)(0).ToString = TextBox1.Text Then
                TextBox1.Text = dt.Rows(j)(0).ToString
                TextBox2.Text = dt.Rows(j)(1).ToString
                TextBox3.Text = dt.Rows(j)(2).ToString
                ComboBox1.SelectedValue = dt.Rows(j)(3).ToString
                i = j
            End If
        Next
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Text = ""
        End If
    End Sub
End Class