Imports System.Data.SqlClient
Public Class Login

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Call Koneksi()
        CMD = New SqlCommand("select * from Admin where Username='" & TextBox1.Text & "'and Password='" & TextBox2.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            MsgBox("Login Gagal")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        Else
            Me.Visible = False
            Menu_Utama.Show()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class