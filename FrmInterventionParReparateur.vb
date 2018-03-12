Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class FrmInterventionParReparateur

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Intervention3.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListeIntervention.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim req1 As String = "SELECT dbo.Intervention.IdIntervention, dbo.Intervention.TypeIntervention, dbo.Intervention.IdPanne, dbo.Reparateur.NomRep, dbo.Intervention.DateDebutIntervention, dbo.Intervention.DateFinIntervention, dbo.logiciel.Nomlogiciel, dbo.pieces.NomPieces, dbo.Intervention.commentaire, dbo.Intervention.EtatIntervention FROM dbo.Intervention left outer JOIN dbo.logiciel ON dbo.Intervention.Idlogiciel = dbo.logiciel.Idlogiciel INNER JOIN dbo.panne ON dbo.Intervention.IdPanne = dbo.panne.IdPanne LEFT outer JOIN dbo.pieces ON dbo.Intervention.IdPieces = dbo.pieces.IdPieces INNER JOIN dbo.Reparateur ON dbo.Intervention.IdRep = dbo.Reparateur.IdRep where dbo.Intervention.IdIntervention ='" & TextBox1.Text & "'"
        da = New SqlDataAdapter(req1, con)
        If ds.Tables.Contains("ImprimerInterventionParReparateur") Then
            ds.Tables("ImprimerInterventionParReparateur").Rows.Clear()
        End If
        con.Open()
        da.Fill(ds, "ImprimerInterventionParReparateur")
        con.Close()
        dt = ds.Tables("ImprimerInterventionParReparateur")
        Dim cr As New ImprimerInterventionParReparateur
        Dim i As Integer
        If dt.Rows.Count <> 0 Then
            For i = 0 To ds.Tables("ImprimerInterventionParReparateur").Rows.Count - 1
                cr.SetParameterValue("IdIntervention", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(0))
                cr.SetParameterValue("TypeIntervention", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(1))
                cr.SetParameterValue("IdPanne", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(2))
                cr.SetParameterValue("IdRep", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(3))
                cr.SetParameterValue("DateDebutIntervention", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(4))
                cr.SetParameterValue("DateFinIntervention", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(5))
                cr.SetParameterValue("IdPieces", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(7).ToString)
                cr.SetParameterValue("Idlogiciel", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(6).ToString)
                cr.SetParameterValue("commentaire", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(8).ToString)
                cr.SetParameterValue("EtatIntervention", ds.Tables("ImprimerInterventionParReparateur").Rows(i)(9).ToString)
            Next
            CrystalReportViewer1.ReportSource = cr
            CrystalReportViewer1.Refresh()
        Else
            MsgBox("Aucune donner trouver", MsgBoxStyle.Information, "Information")
        End If
    End Sub
End Class