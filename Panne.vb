Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Panne
    Shared i As Integer
    Dim da1 As SqlDataAdapter
    Dim da2 As SqlDataAdapter
    Public Sub panne()
        Dim pann = "select * from panne"
        da1 = New SqlDataAdapter(pann, con)
        If ds.Tables.Contains("Panne1") Then
            ds.Tables("Panne1").Rows.Clear()
        End If
        con.Open()
        da1.Fill(ds, "Panne1")
        con.Close()
        navigation(i)
    End Sub
    Private Sub Panne_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panne()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Enabled = False
        Dim mat As String = "select * from material "
        da = New SqlDataAdapter(mat, con)
        If ds.Tables.Contains("pmat") Then
            ds.Tables("pmat").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "pmat")
        con.Close()
        dt = ds.Tables("pmat")
        ComboBox1.DisplayMember = ds.Tables("pmat").Columns(1).ToString
        ComboBox1.ValueMember = ds.Tables("pmat").Columns(0).ToString
        ComboBox1.DataSource = ds.Tables("pmat")
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Societe")
        ComboBox2.Items.Add("Cellule")
        ComboBox2.SelectedItem = "Societe"
        'ComboBox3.Items.Add("En Cours")
        'ComboBox3.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim reqmat As String = ("SELECT dbo.Material.NumInventaire, dbo.Material.Marque, dbo.Material.NumSerie, dbo.Utilisateur.NomUtilisateur FROM dbo.Material INNER JOIN dbo.Utilisateur ON dbo.Material.IdUtilisateur = dbo.Utilisateur.IdUtilisateur where NumInventaire = '" & ComboBox1.SelectedValue & "'")
        da2 = New SqlDataAdapter(reqmat, con)
        If ds.Tables.Contains("infomat") Then
            ds.Tables("infomat").Rows.Clear()
        End If
        con.Open()
        da2.Fill(ds, "infomat")
        con.Close()
        dt = ds.Tables("infomat")
        If dt.Rows.Count <> 0 Then
            For c = 0 To dt.Rows.Count - 1
                Label15.Text = dt.Rows(c)(0).ToString
                Label16.Text = dt.Rows(c)(1).ToString
                Label17.Text = dt.Rows(c)(2).ToString
                Label18.Text = dt.Rows(c)(3).ToString
            Next
        End If
    End Sub

    Public Sub navigation(ByVal p As String)
        If ds.Tables("Panne1").Rows.Count <> 0 Then
            TextBox1.Text = ds.Tables("Panne1").Rows(p)(0).ToString
            ComboBox1.SelectedValue = ds.Tables("Panne1").Rows(p)(1)
            TextBox2.Text = ds.Tables("Panne1").Rows(p)(2).ToString
            DateTimePicker1.Value = ds.Tables("Panne1").Rows(p)(3)
            TextBox3.Text = ds.Tables("Panne1").Rows(p)(4).ToString
            ComboBox2.SelectedItem = ds.Tables("Panne1").Rows(p)(5).ToString
            ComboBox3.Text = ds.Tables("Panne1").Rows(p)(6).ToString
            Label9.Text = (i + 1) & "/" & ds.Tables("Panne1").Rows.Count
        End If
    End Sub
    Public Sub nouveau()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Value = Date.Now
        ComboBox1.SelectedValue = 1
        ComboBox2.SelectedValue = 1
        ComboBox3.SelectedValue = 1
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nouveau()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Aucune material trouver" + vbCrLf + "Il faut ajouter un material  avant ajouter un panne", MsgBoxStyle.Information, "Information")
            Else
                dr1 = ds.Tables("Panne1").NewRow
                dr1(1) = ComboBox1.SelectedValue
                dr1(2) = TextBox2.Text
                dr1(3) = CType(DateTimePicker1.Value, Date)
                dr1(4) = TextBox2.Text
                dr1(5) = ComboBox2.SelectedItem
                dr1(6) = "En cours"
                ds.Tables("Panne1").Rows.Add(dr1)
                cb = New SqlCommandBuilder(da1)
                da1.Update(ds, "Panne1")
                MsgBox("Panne Ajouter", MsgBoxStyle.Information, "Information")
                TextBox1.Text = dt.Rows.Count
                Label9.Text = (i + 1) & "/" & dt.Rows.Count
                Label10.Text = "En cours"
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
        panne()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim pos As Boolean
            If ComboBox1.Text = "" Then
                MsgBox("Aucune material trouver" + vbCrLf + "Impossible de modifier ce panne", MsgBoxStyle.Information, "Information")
            Else
                For c = 0 To ds.Tables("Panne1").Rows.Count - 1
                    If TextBox1.Text = dt.Rows(c)(0) Then
                        ds.Tables("Panne1").Rows(c)(1) = ComboBox1.SelectedValue
                        ds.Tables("Panne1").Rows(c)(2) = TextBox2.Text
                        ds.Tables("Panne1").Rows(c)(3) = DateTimePicker1.Value.Date
                        ds.Tables("Panne1").Rows(c)(4) = TextBox3.Text
                        ds.Tables("Panne1").Rows(c)(5) = ComboBox2.SelectedItem
                        ds.Tables("Panne1").Rows(c)(6) = "En Cours"
                        cb = New SqlCommandBuilder(da1)
                        da1.Update(ds, "Panne1")
                        MsgBox("Panne Modifier", MsgBoxStyle.Information, "Information")
                        pos = True
                    End If
                Next
                If pos = False Then
                    MsgBox("Aucune Panne Trouve Pour Modifier ", MsgBoxStyle.Information, "Information")
                End If
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If ds.Tables("Panne1").Rows.Count <> 0 Then
                If MsgBox("Voulez-vous vraiment supprimer cette panne?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ds.Tables("Panne1").Rows(i).Delete()
                    cb = New SqlCommandBuilder(da1)
                    da1.Update(ds, "panne1")
                    i = 0
                    nouveau()
                    navigation(0)
                    MsgBox("panne  à été supprimer avec Sucée", MsgBoxStyle.Information, "Information")
                    Label4.Text = (i + 1) & "/" & dt.Rows.Count
                Else
                    MsgBox("la suppression a ete annulé", MsgBoxStyle.Exclamation, "Information")
                End If
            Else
                MsgBox("Aucun panne trouve pour  supprimer", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + vbCrLf + ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ListePannes.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If i < ds.Tables("Panne1").Rows.Count - 1 Then
            i = i + 1
        Else
            i = 0
        End If
        navigation(i)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        i = 0
        navigation(i)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If i > 0 Then
            i -= 1
        Else
            i = ds.Tables("Panne1").Rows.Count - 1
        End If
        navigation(i)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        i = ds.Tables("Panne1").Rows.Count - 1
        navigation(i)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        For j As Integer = 0 To ds.Tables("Panne1").Rows.Count - 1
            If ds.Tables("Panne1").Rows(j)(0).ToString = TextBox1.Text Then
                ComboBox1.SelectedValue = ds.Tables("Panne1").Rows(j)(1)
                TextBox2.Text = ds.Tables("Panne1").Rows(j)(2).ToString
                DateTimePicker1.Value = ds.Tables("Panne1").Rows(j)(3)
                TextBox3.Text = ds.Tables("Panne1").Rows(j)(4).ToString
                ComboBox2.SelectedItem = ds.Tables("Panne1").Rows(j)(5).ToString
                ComboBox3.Text = ds.Tables("Panne1").Rows(j)(6).ToString
                i = j
            End If
        Next
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Text = ""
        End If
    End Sub
End Class