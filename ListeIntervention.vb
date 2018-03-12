Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ListeIntervention

    Private Sub ListeIntervention_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Tous")
        ComboBox1.Items.Add("Societe")
        ComboBox1.Items.Add("Reparateur")
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Tous" Then
            Dim req1 As String = "SELECT dbo.Intervention.IdIntervention, dbo.Intervention.TypeIntervention, dbo.Intervention.IdPanne, dbo.Societe.NomSociete, dbo.Reparateur.NomRep, dbo.Intervention.DateFinIntervention, dbo.Intervention.DateDebutIntervention, dbo.pieces.NomPieces, dbo.logiciel.Nomlogiciel, dbo.Intervention.commentaire, dbo.Intervention.EtatIntervention FROM dbo.Intervention LEFT OUTER JOIN dbo.logiciel ON dbo.Intervention.Idlogiciel = dbo.logiciel.Idlogiciel INNER JOIN dbo.panne ON dbo.Intervention.IdPanne = dbo.panne.IdPanne LEFT OUTER JOIN dbo.pieces ON dbo.Intervention.IdPieces = dbo.pieces.IdPieces LEFT OUTER JOIN dbo.Reparateur ON dbo.Intervention.IdRep = dbo.Reparateur.IdRep LEFT OUTER JOIN dbo.Societe ON dbo.Intervention.IdSociete = dbo.Societe.IdSociete"
            da = New SqlDataAdapter(req1, con)
            If ds.Tables.Contains("IntervAll") Then
                ds.Tables("IntervAll").Rows.Clear()
            End If
            con.Open()
            da.Fill(ds, "IntervAll")
            con.Close()
            DataGridView1.DataSource = ds.Tables("IntervAll")
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ElseIf ComboBox1.Text = "Societe" Then
            Dim req As String = "SELECT dbo.Intervention.IdIntervention, dbo.Intervention.IdPanne, dbo.Societe.NomSociete, dbo.Intervention.DateDebutIntervention, dbo.Intervention.DateFinIntervention, dbo.Intervention.commentaire, dbo.Intervention.EtatIntervention FROM dbo.Intervention INNER JOIN dbo.panne ON dbo.Intervention.IdPanne = dbo.panne.IdPanne INNER JOIN dbo.Societe ON dbo.Intervention.IdSociete = dbo.Societe.IdSociete "
            da = New SqlDataAdapter(req, con)
            If ds.Tables.Contains("Interv") Then
                ds.Tables("Interv").Rows.Clear()
            End If
            con.Open()
            da.Fill(ds, "Interv")
            con.Close()
            DataGridView1.DataSource = ds.Tables("Interv")
        Else
            Dim req1 As String = "SELECT dbo.Intervention.IdIntervention, dbo.Intervention.TypeIntervention, dbo.Intervention.IdPanne, dbo.Reparateur.NomRep, dbo.Intervention.DateDebutIntervention, dbo.Intervention.DateFinIntervention, dbo.logiciel.Nomlogiciel, dbo.pieces.NomPieces, dbo.Intervention.commentaire, dbo.Intervention.EtatIntervention FROM dbo.Intervention left outer JOIN dbo.logiciel ON dbo.Intervention.Idlogiciel = dbo.logiciel.Idlogiciel INNER JOIN dbo.panne ON dbo.Intervention.IdPanne = dbo.panne.IdPanne LEFT outer JOIN dbo.pieces ON dbo.Intervention.IdPieces = dbo.pieces.IdPieces INNER JOIN dbo.Reparateur ON dbo.Intervention.IdRep = dbo.Reparateur.IdRep"
            da = New SqlDataAdapter(req1, con)
            If ds.Tables.Contains("Interv1") Then
                ds.Tables("Interv1").Rows.Clear()
            End If
            con.Open()
            da.Fill(ds, "Interv1")
            con.Close()
            DataGridView1.DataSource = ds.Tables("Interv1")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Intervention3.Show()
        Me.Close()
    End Sub
End Class