Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class FrmImprimerInterventionParSociete

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim req As String = "SELECT dbo.Intervention.IdIntervention, dbo.Intervention.IdPanne, dbo.Societe.NomSociete, dbo.Intervention.DateDebutIntervention, dbo.Intervention.DateFinIntervention, dbo.Intervention.commentaire, dbo.Intervention.EtatIntervention FROM dbo.Intervention INNER JOIN dbo.panne ON dbo.Intervention.IdPanne = dbo.panne.IdPanne INNER JOIN dbo.Societe ON dbo.Intervention.IdSociete = dbo.Societe.IdSociete where dbo.Intervention.IdIntervention='" & TextBox1.Text & "' "
        da = New SqlDataAdapter(req, con)
        If ds.Tables.Contains("ImprimerInterventionParSociete") Then
            ds.Tables("ImprimerInterventionParSociete").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "ImprimerInterventionParSociete")
        con.Close()
        dt = ds.Tables("ImprimerInterventionParSociete")
        Dim cr As New ImprimerInterventionParSociete
        If dt.Rows.Count <> 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables("ImprimerInterventionParSociete").Rows.Count - 1
                cr.SetParameterValue("IdIntervention", ds.Tables("ImprimerInterventionParSociete").Rows(i)(0))
                'cr.SetParameterValue("TypeIntervention", ds.Tables("InterventionImprimer").Rows(i)(1).ToString)
                cr.SetParameterValue("IdPanne", ds.Tables("ImprimerInterventionParSociete").Rows(i)(1))
                cr.SetParameterValue("IdSociete", ds.Tables("ImprimerInterventionParSociete").Rows(i)(2))
                'cr.SetParameterValue("NomRep", ds.Tables("InterventionImprimer").Rows(i)(4))
                cr.SetParameterValue("DateDebutIntervention", ds.Tables("ImprimerInterventionParSociete").Rows(i)(3))
                cr.SetParameterValue("DateFinIntervention", ds.Tables("ImprimerInterventionParSociete").Rows(i)(4))
                'cr.SetParameterValue("NomPieces", ds.Tables("InterventionImprimer").Rows(i)(7).ToString)
                'cr.SetParameterValue("Nomlogiciel", ds.Tables("InterventionImprimer").Rows(i)(8).ToString)
                cr.SetParameterValue("commentaire", ds.Tables("ImprimerInterventionParSociete").Rows(i)(5).ToString)
                cr.SetParameterValue("EtatIntervention", ds.Tables("ImprimerInterventionParSociete").Rows(i)(6).ToString)
            Next
        Else
            MsgBox("Aucune donner trouver", MsgBoxStyle.Information, "Information")
        End If
        '   End If

        CrystalReportViewer1.ReportSource = cr
        'cr.SetDataSource(ds.Tables("InterventionImprimer"))
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Intervention3.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListeIntervention.Show()
        Me.Close()
    End Sub
End Class