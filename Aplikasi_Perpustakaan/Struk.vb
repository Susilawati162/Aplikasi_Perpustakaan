Imports System.Data.SqlClient
Public Class Struk
    Sub struk()
        Call Koneksi()
        CMD = New SqlCommand(" select * from Detail", CONN)
        DR = CMD.ExecuteReader
        Do While DR.Read()
            ComboBox1.Items.Add(DR.Item("Id_Pinjam"))
        Loop
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Pilih Id Peminjaman terlebih dahulu")
                ComboBox1.Focus()
            Else
                Cetak1.CrystalReportViewer1.SelectionFormula = "{Detail.Id_Pinjam}='" & ComboBox1.Text & "'"
                Cetak1.CrystalReportViewer1.RefreshReport()
                Cetak1.WindowState = FormWindowState.Maximized
                Cetak1.Show()
                ComboBox1.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Struk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call struk()
    End Sub
End Class