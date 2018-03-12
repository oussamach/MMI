Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Intervention3
    Dim daa As New SqlDataAdapter("select * from Intervention", cnx)
    Dim cc As String
    Public combo As Integer
    Dim tt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Enabled = False
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        ComboBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Enabled = True
        Dim l As DataRow
        l = dt.NewRow
        l(1) = Label16.Text
        If ComboBox3.Text <> "" Then

            l(2) = ComboBox3.SelectedItem.ToString
            If (ComboBox5.Text <> "" And ComboBox5.Visible = True) Then
                l(4) = ComboBox5.SelectedValue
            End If
            If (ComboBox5.Text = "" And ComboBox5.Visible = True) Then
                MsgBox("Remplir le champs de : Id Reparateur  ", MsgBoxStyle.Information, "Information")
            Else

                'If (ComboBox6.Text <> "" And ComboBox6.Visible = True) Then
                '    l(3) = ComboBox6.SelectedValue
                'End If
                If (ComboBox6.Text <> "" And ComboBox6.Visible = True) Then
                    l(3) = ComboBox6.SelectedValue
                End If
                If (ComboBox6.Text = "" And ComboBox6.Visible = True) Then
                    MsgBox("Remplir le champs de : Id Societe  ", MsgBoxStyle.Information, "Information")

                Else

                    If (ComboBox1.Text <> "" And ComboBox1.Visible = True) Then
                        l(7) = ComboBox1.SelectedValue
                    End If

                    If (ComboBox2.Text <> "" And ComboBox2.Visible = True) Then
                        l(8) = ComboBox2.SelectedValue
                    End If

                    If (DateTimePicker1.Value < DateTimePicker2.Value) Then

                        l(5) = DateTimePicker1.Value
                        l(6) = DateTimePicker2.Value
                        l(9) = TextBox2.Text
                        l(10) = "En cours"
                        dt.Rows.Add(l)
                        Dim cb As New SqlCommandBuilder(daa)
                        daa.Update(dt)
                        dt.AcceptChanges()
                        MsgBox("L'intervention à été Ajouter", MsgBoxStyle.Information, "Information")
                        ComboBox3.Items.Clear()
                        loadd()
                        charg()
                        affichage()
                    Else
                        MsgBox("la date de debut doit être inférieure à la date de fin", MsgBoxStyle.Information, "Information")

                    End If
                End If
            End If
        Else
            MsgBox("Remplir le champs de : Id panne  ", MsgBoxStyle.Information, "Information")
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("voullez vous vraiment supprimer ce reparateur ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            If dt.Rows.Count > 0 Then
                dt.Rows(i).Delete()
                Dim cb As New SqlCommandBuilder(daa)
                daa.Update(dt)
                dt.AcceptChanges()
                i = i - 1
                affichage()
            End If
            If i < 0 Then
                i = 0
            End If
            charg()
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("voullez vous vraiment modifier ce reparateur ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If dt.Rows.Count > 0 Then
                dt.Rows(i)(1) = Label16.Text
                dt.Rows(i)(2) = ComboBox3.SelectedItem
                If (ComboBox5.Text <> "") Then
                    dt.Rows(i)(4) = ComboBox5.SelectedValue
                End If
                If (ComboBox6.Text <> "") Then
                    dt.Rows(i)(3) = ComboBox6.SelectedValue
                End If
                If ComboBox5.Visible = False Then
                    dt.Rows(i)(4) = System.DBNull.Value
                End If
                If ComboBox6.Visible = False Then
                    dt.Rows(i)(3) = System.DBNull.Value
                End If
                If CheckBox1.Checked = False And CheckBox2.Checked = False Then
                    dt.Rows(i).Item(7) = System.DBNull.Value
                    dt.Rows(i)(8) = System.DBNull.Value
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False Then
                    dt.Rows(i)(8) = System.DBNull.Value
                    dt.Rows(i)(7) = ComboBox1.SelectedValue
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
                    dt.Rows(i).Item(7) = System.DBNull.Value
                    dt.Rows(i)(8) = ComboBox2.SelectedValue
                Else
                    If (ComboBox1.Text <> "") Then
                        dt.Rows(i)(7) = ComboBox1.SelectedValue
                    End If
                    If (ComboBox2.Text <> "") Then
                        dt.Rows(i)(8) = ComboBox2.SelectedValue
                    End If
                End If
                If (DateTimePicker1.Value < DateTimePicker2.Value) Then


                    dt.Rows(i)(5) = DateTimePicker1.Value
                    dt.Rows(i)(6) = DateTimePicker2.Value
                    dt.Rows(i)(9) = TextBox2.Text
                    Dim cb As New SqlCommandBuilder(daa)
                    dt.EndInit()
                    daa.Update(dt)
                    dt.AcceptChanges()
                    charg()
                Else
                    MsgBox("la date de debut doit être inférieure à la date de fin", MsgBoxStyle.Information, "Information")
                End If

            End If
        End If
    End Sub
    Private Sub Intervention3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button10.Hide()
        ss.Clear()
        loadd()
        If ss.Tables.Contains("sc") Then
            dt3.Rows.Clear()
        End If
        If ss.Tables.Contains("piec") Then
            dt5.Rows.Clear()
        End If
        If ss.Tables.Contains("logic") Then
            dt6.Rows.Clear()
        End If
        If ss.Tables.Contains("rp") Then
            dt4.Rows.Clear()
        End If
        da = New SqlDataAdapter("select * from Societe", cnx)
        cnx.Open()
        da.Fill(ss, "sc")
        cnx.Close()
        dt3 = ss.Tables("sc")
        da = New SqlDataAdapter("select * from pieces", cnx)
        cnx.Open()
        da.Fill(ss, "piec")
        cnx.Close()
        dt5 = ss.Tables("piec")
        da = New SqlDataAdapter("select * from logiciel", cnx)
        cnx.Open()
        da.Fill(ss, "logic")
        cnx.Close()
        dt6 = ss.Tables("logic")
        da = New SqlDataAdapter("select * from Reparateur", cnx)
        cnx.Open()
        da.Fill(ss, "rp")
        cnx.Close()
        dt4 = ss.Tables("rp")
        'ComboBox1.Items.Add("")
        ComboBox6.DisplayMember = dt3.Columns(1).ToString
        ComboBox6.ValueMember = dt3.Columns(0).ToString
        ComboBox6.DataSource = dt3
        ComboBox5.DisplayMember = dt4.Columns(1).ToString
        ComboBox5.ValueMember = dt4.Columns(0).ToString
        ComboBox5.DataSource = dt4
        ComboBox1.DisplayMember = dt5.Columns(1).ToString
        ComboBox1.ValueMember = dt5.Columns(0).ToString
        ComboBox1.DataSource = dt5
        ComboBox2.DisplayMember = dt6.Columns(1).ToString
        ComboBox2.ValueMember = dt6.Columns(0).ToString
        ComboBox2.DataSource = dt6
        affichage()
        ComboBox1.Hide()
        ComboBox2.Hide()
        If TextBox1.Text = "" Then
            bind.AddNew()
        End If
        hidee()
        repart()

    End Sub
    Public Sub loadd()
        If ss.Tables.Contains("inter") Then
            dt.Rows.Clear()
        End If
        If ss.Tables.Contains("pn") Then
            dt2.Rows.Clear()
        End If
        ComboBox3.Items.Clear()
        If ss.Tables.Contains("mm") Then
            dt9.Rows.Clear()
        End If
        cnx.Open()
        daa.Fill(ss, "inter")
        cnx.Close()
        dt = ss.Tables("inter")
        Dim req4 As String = "select * from panne "
        da = New SqlDataAdapter(req4, cnx)
        cnx.Open()
        da.Fill(ss, "pn")
        cnx.Close()
        dt2 = ss.Tables("pn")
        For i As Integer = 0 To dt2.Rows.Count - 1
            ComboBox3.Items.Add(dt2(i)(0).ToString)
        Next
        Dim reqm As String = "select * from Material "
        da = New SqlDataAdapter(reqm, cnx)
        cnx.Open()
        da.Fill(ss, "mm")
        cnx.Close()
        dt9 = ss.Tables("mm")
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        ListeIntervention.Show()
        Me.Hide()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Mtr.Show()
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim req55 As String = "update  panne set Effectuer = 'Terminé' where  (idPanne = '" & ComboBox3.SelectedItem & "' )  "
        Dim req555 As String = "update  Intervention set EtatIntervention = 'Terminé' where  (idPanne = '" & ComboBox3.SelectedItem & "' )  "
        Dim smddd As New SqlCommand(req55, cnx)
        Dim ettt As New SqlCommand(req555, cnx)
        cnx.Open()
        smddd.ExecuteNonQuery()
        ettt.ExecuteNonQuery()
        cnx.Close()
        dt.AcceptChanges()
        dt2.AcceptChanges()
        ss.AcceptChanges()
        loadd()
        charg()
        affichage()
        termin1()
        Button10.Hide()
    End Sub
    Public Sub affichage()
        TextBox1.Enabled = True
        If i < 0 Then
            i = 0
        End If
        If dt.Rows.Count > 0 And i < dt.Rows.Count Then
            TextBox1.Text = dt.Rows(i)(0).ToString
            TextBox2.Text = dt.Rows(i)(9).ToString
            Label21.Text = dt.Rows(i)(10).ToString
            If dt.Rows(i)(5).ToString <> "" Then
                DateTimePicker1.Value = dt.Rows(i)(5)
            End If
            If dt.Rows(i)(6).ToString <> "" Then
                DateTimePicker2.Value = dt.Rows(i)(6)
            End If
            Label16.Text = dt.Rows(i)(1).ToString
            ComboBox3.Text = dt.Rows(i)(2).ToString
            ComboBox6.SelectedValue = dt.Rows(i)(3)
            ComboBox5.SelectedValue = dt.Rows(i)(4)
            ComboBox1.SelectedValue = dt.Rows(i)(7)
            ComboBox2.SelectedValue = dt.Rows(i)(8)
        End If
        repart()
        charg()

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Public Sub hidee()
        If CheckBox1.Checked = True And CheckBox2.Checked = False Then
            ComboBox2.Hide()
            ComboBox1.Show()
            Label16.Text = "Hardware"
        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
            ComboBox1.Hide()
            ComboBox2.Show()
            Label16.Text = "Software"
        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
            ComboBox1.Show()
            ComboBox2.Show()
            Label16.Text = "Hardware/Software"
        Else
            ComboBox1.Hide()
            ComboBox2.Hide()
            Label16.Text = " "
        End If
    End Sub
    Private Sub charg()
        Dim hh As Integer = 1
        Dim m As Integer
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        If ss.Tables.Contains("rpp") Then
            dt7.Rows.Clear()
        End If
        If ss.Tables.Contains("rp2") Then
            dt8.Rows.Clear()
        End If
        Dim req5 As String = "select * from Intervention inner join pieces on(pieces.IdPieces = Intervention.IdPieces) where (idPanne = '" & ComboBox3.SelectedItem & "') "
        Dim req6 As String = "select * from Intervention inner join logiciel on(logiciel.Idlogiciel = Intervention.Idlogiciel) where (idPanne='" & ComboBox3.SelectedItem & "') "
        Dim dd As New SqlDataAdapter(req5, cnx)
        Dim dd2 As New SqlDataAdapter(req6, cnx)
        cnx.Open()
        dd.Fill(ss, "rpp")
        dd2.Fill(ss, "rp2")
        cnx.Close()
        dt7 = ss.Tables("rpp")
        dt8 = ss.Tables("rp2")
        For j As Integer = 0 To dt8.Rows.Count - 1
            ListBox2.Items.Add(dt8(j)(12).ToString)
        Next
        For j As Integer = 0 To dt7.Rows.Count - 1
            m = ListBox1.Items.Count - 1
            ListBox1.Items.Add(dt7.Rows(j)(12).ToString)
        Next
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        repart()
        charg()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        hidee()
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        hidee()
    End Sub
    Public Sub termin1()
        Label14.Hide()
        GroupBox2.Hide()
        GroupBox1.Show()
        ComboBox6.Hide()
        Button10.Hide()
        Button11.Hide()
        Label13.Text = "l'operation de reparation est terminé avec succès "
    End Sub
    Public Sub termin2()
        Label14.Hide()
        GroupBox2.Hide()
        GroupBox1.Hide()
        ComboBox6.Hide()
        Button10.Hide()
        Button11.Hide()
        Label13.Text = "l'operation de reparation est terminé avec changement de material "
    End Sub
    Public Sub repart()
        Label13.Text = ""
        For i As Integer = 0 To dt2.Rows.Count - 1
            If (ComboBox3.SelectedItem = dt2(i)(0).ToString) And dt2(i)(5).ToString = "Societe" Then
                GroupBox2.Hide()
                GroupBox1.Hide()
                ComboBox6.Show()
                Label14.Show()
                Button10.Show()
                Label13.Text = ""
            ElseIf (ComboBox3.SelectedItem = dt2(i)(0).ToString) And dt2(i)(5).ToString <> "Societe" Then
                GroupBox2.Show()
                GroupBox1.Show()
                ComboBox6.Hide()
                Label14.Hide()
                Button10.Hide()
                Button11.Show()
                Label13.Text = ""
            End If
        Next
        For i As Integer = 0 To dt2.Rows.Count - 1
            If (ComboBox3.SelectedItem = dt2(i)(0).ToString) Then
                For k As Integer = 0 To dt9.Rows.Count - 1
                    If dt2(i)(1).ToString = dt9(k)(0).ToString Then
                        Label12.Text = dt9(k)(1).ToString
                        idd = dt9(k)(0).ToString
                        maa = dt9(k)(2).ToString
                        typee = dt9(k)(3).ToString
                    End If
                Next
            End If
            If (ComboBox3.SelectedItem = dt2(i)(0).ToString) And dt2(i)(6).ToString = "Terminé" And dt2(i)(5).ToString = "Societe" And Label21.Text = "Changé" Then
                termin2()
            ElseIf (ComboBox3.SelectedItem = dt2(i)(0).ToString) And dt2(i)(6).ToString = "Terminé" And dt2(i)(5).ToString = "Societe" And Label21.Text <> "Changé" Then
                termin1()
            ElseIf (ComboBox3.SelectedItem = dt2(i)(0).ToString) And dt2(i)(6).ToString = "Terminé" And dt2(i)(5).ToString <> "Societe" Then
                termin1()
            End If
        Next
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        FrmImprimerInterventionParSociete.Show()
        Me.Hide()
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        FrmInterventionParReparateur.Show()
        Me.Hide()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        i = 0
        affichage()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If (i > 0) Then
            i = i - 1
            affichage()

        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If (i < dt.Rows.Count - 1) Then
            i = i + 1
            affichage()

        End If
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        i = dt.Rows.Count - 1
        affichage()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        hidee()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox6.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        For j As Integer = 0 To dt.Rows.Count - 1
            If dt(j)(0).ToString = TextBox1.Text Then
                i = j
                affichage()
            End If
        Next
    End Sub
End Class