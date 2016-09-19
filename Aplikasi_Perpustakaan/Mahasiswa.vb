Imports System.Data.SqlClient

Public Class Mahasiswa

    Dim Pilihan As String

    Sub Kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub

    Sub databaru()
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub

    Sub tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from Mahasiswa", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Sub kodeotomatis()
        Call koneksi()
        TextBox1.Enabled = False
        CMD = New SqlCommand("SELECT * from Mahasiswa order by Id_Mahasiswa desc", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            TextBox1.Text = "MH-0001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(DR.Item("Id_Mahasiswa").ToString, 5, 7)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "MH-000" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "MH-00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "MH-0" & TextBox1.Text & ""
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        lblWaktu.Text = DateTime.Now.ToString("H:mm:ss")
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or RadioButton1.Text = "" Or RadioButton2.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Try
                If RadioButton1.Checked = True Then
                    Pilihan = RadioButton1.Text 'L
                ElseIf RadioButton2.Checked = True Then
                    Pilihan = RadioButton2.Text 'P
                End If
                Call Koneksi()
                CMD = New SqlCommand("select * from Mahasiswa where Id_Mahasiswa='" & TextBox1.Text & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                If Not DR.HasRows Then
                    Call Koneksi()
                    Dim simpan As String = " insert into Mahasiswa values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & Pilihan & "','" & TextBox3.Text & "')"
                    CMD = New SqlCommand(simpan, CONN)
                    CMD.ExecuteNonQuery()
                Else
                    Call Koneksi()
                    Dim edit As String = " update Mahasiswa set Nama='" & TextBox2.Text & "',Jenis_Kelamin='" & Pilihan & "',Alamat='" & TextBox3.Text & "' where Id_Mahasiswa='" & TextBox1.Text & "'"
                    CMD = New SqlCommand(edit, CONN)
                    CMD.ExecuteNonQuery()
                End If
                Call Kosongkan()
                Call tampilgrid()
                Call kodeotomatis()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Call Koneksi()
        Me.Visible = False
        Menu_Utama.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("anda harus mengisi data dulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Hapus Data Ini...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from Mahasiswa where Id_Mahasiswa='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Call Kosongkan()
                Call tampilgrid()
                Call kodeotomatis()
            Else
                Call Kosongkan()
                Call kodeotomatis()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Call Kosongkan()
        Call kodeotomatis()
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox5.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Mahasiswa where Nama like '%" & TextBox5.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from Mahasiswa where Nama like '%" & TextBox5.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("NAMA Mahasiswa TIDAK DI TEMUKAN")
        End If
    End Sub

    Private Sub DGV_CellContentClick_1(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV.CellContentClick
        On Error Resume Next
        TextBox1.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        If DGV.Rows(e.RowIndex).Cells(2).Value = "L" Then
            RadioButton1.Checked = True
        ElseIf DGV.Rows(e.RowIndex).Cells(2).Value = "P" Then
            RadioButton2.Checked = True

        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Select Case Label6.Text
            Case ""
                Label6.Text = "A"
            Case "A"
                Label6.Text = "AP"
            Case "AP"
                Label6.Text = "APL"
            Case "APL"
                Label6.Text = "APLI"
            Case "APLI"
                Label6.Text = "APLIK"
            Case "APLIK"
                Label6.Text = "APLIKA"
            Case "APLIKA"
                Label6.Text = "APLIKAS"
            Case "APLIKAS"
                Label6.Text = "APLIKASI"
            Case "APLIKASI"
                Label6.Text = "APLIKASI "
            Case "APLIKASI "
                Label6.Text = "APLIKASI P"
            Case "APLIKASI P"
                Label6.Text = "APLIKASI PE"
            Case "APLIKASI PE"
                Label6.Text = "APLIKASI PER"
            Case "APLIKASI PER"
                Label6.Text = "APLIKASI PERP"
            Case "APLIKASI PERP"
                Label6.Text = "APLIKASI PERPU"
            Case "APLIKASI PERPU"
                Label6.Text = "APLIKASI PERPUS"
            Case "APLIKASI PERPUS"
                Label6.Text = ""
        End Select
    End Sub

    Private Sub Mahasiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label6.Text = ""
        Timer2.Start()
        Call Koneksi()
        Call tampilgrid()
        Call Kosongkan()
        Call kodeotomatis()
        lblTanggal.Text = DateTime.Now.ToString("ddd-MMMM-yyyy")
        Timer1.Enabled = True
    End Sub
End Class