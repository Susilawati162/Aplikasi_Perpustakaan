Imports System.Data.SqlClient
Public Class Struk2

    Sub struk()
        Call Koneksi()
        CMD = New SqlCommand(" select * from Detail1", CONN)
        DR = CMD.ExecuteReader
        Do While DR.Read()
            ComboBox1.Items.Add(DR.Item("Id_Kembali"))
        Loop
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Pilih Id Pengembalian terlebih dahulu")
                ComboBox1.Focus()
            Else
                Cetak2.CrystalReportViewer1.SelectionFormula = "{Detail1.Id_Kembali}='" & ComboBox1.Text & "'"
                Cetak2.CrystalReportViewer1.RefreshReport()
                Cetak2.WindowState = FormWindowState.Maximized
                Cetak2.Show()
                ComboBox1.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Struk2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call struk()
    End Sub
End Class