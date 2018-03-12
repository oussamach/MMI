Public Class Menu

    Private Sub ServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceToolStripMenuItem.Click
        Service.MdiParent = Me
        Service.Show()
    End Sub

    Private Sub UtilisateurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilisateurToolStripMenuItem.Click
        Utilisateur.MdiParent = Me
        Utilisateur.Show()
    End Sub

    Private Sub MaterialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialToolStripMenuItem.Click
        Material.MdiParent = Me
        Material.Show()
    End Sub

    Private Sub CelluleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CelluleToolStripMenuItem.Click
        cellule.MdiParent = Me
        cellule.Show()
    End Sub

    Private Sub ReprateurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprateurToolStripMenuItem.Click
        Reparateur.MdiParent = Me
        Reparateur.Show()
    End Sub

    Private Sub LogicielToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogicielToolStripMenuItem.Click
        Logiceil.MdiParent = Me
        Logiceil.Show()
    End Sub

    Private Sub PiecesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiecesToolStripMenuItem.Click
        Pieces.MdiParent = Me
        Pieces.Show()
    End Sub

    Private Sub PanneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanneToolStripMenuItem.Click
        Panne.MdiParent = Me
        Panne.Show()
    End Sub

    Private Sub InterventionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterventionToolStripMenuItem.Click
        Intervention3.MdiParent = Me
        Intervention3.Show()
    End Sub

    Private Sub SocietéToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SocietéToolStripMenuItem.Click
        Societé.MdiParent = Me
        Societé.Show()
    End Sub

    Private Sub FermerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermerToolStripMenuItem.Click
        If MsgBox("Voulez-vous vraiment fermer l'application", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class