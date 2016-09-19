Public Class Menu_Utama

    Private Sub AdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem.Click
        Call Koneksi()
        Admin.Show()
    End Sub

    Private Sub MahasiswaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MahasiswaToolStripMenuItem.Click
        Call Koneksi()
        Mahasiswa.Show()
    End Sub

    Private Sub BukuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BukuToolStripMenuItem.Click
        Call Koneksi()
        Buku.Show()
    End Sub

    Private Sub PeminjamanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeminjamanToolStripMenuItem.Click
        Call Koneksi()
        Pinjam.Show()
    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengembalianToolStripMenuItem.Click
        Call Koneksi()
        Kembali.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub Menu_Utama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class