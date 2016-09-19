Imports System.Data.SqlClient
Public Class Pinjam

    Dim PILIHAN As String

    Sub Kosongkan()
        TextBox1.Clear()
        ComboBox1.Text = ""
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox2.Text = ""
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox1.Focus()
    End Sub

    Sub DataBaru()
        TextBox1.Clear()
        ComboBox1.Text = ""
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox2.Text = ""
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox1.Focus()
    End Sub

    Sub tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from Pinjam", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Sub Mahasiswa()
        Call Koneksi()
        CMD = New SqlCommand(" select * from Mahasiswa", CONN)
        DR = CMD.ExecuteReader
        Do While DR.Read()
            ComboBox1.Items.Add(DR.Item("Id_Mahasiswa"))
        Loop
    End Sub

    Sub Buku()
        Call Koneksi()
        CMD = New SqlCommand(" select * from Buku", CONN)
        DR = CMD.ExecuteReader
        Do While DR.Read()
            ComboBox2.Items.Add(DR.Item("Id_Buku"))
        Loop
    End Sub

    Sub jk()
        If RadioButton1.Checked = True Then
            Pilihan = RadioButton1.Text 'L
        ElseIf RadioButton2.Checked = True Then
            Pilihan = RadioButton2.Text 'P
        End If
    End Sub

    Sub kodeotomatis()
        Call koneksi()
        TextBox1.Enabled = False
        CMD = New SqlCommand("SELECT * from Pinjam order by Id_Pinjam desc", CONN)
        DR = CMD.ExecuteReader
        DR.Read()

        If Not DR.HasRows Then
            TextBox1.Text = "PI-0001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(DR.Item("Id_Pinjam").ToString, 5, 7)) + 1

            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "PI-000" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "PI-00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "PI-0" & TextBox1.Text & ""
            End If
        End If
    End Sub

    Private Sub Pinjam_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        Label18.Text = ""
        Timer1.Start()
        Call Kosongkan()
        Call Buku()
        Call kodeotomatis()
        DateTimePicker1.Enabled = False
        TextBox8.Enabled = False
        TextBox10.Enabled = False
        TextBox12.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox2.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Call Mahasiswa()
        Call tampilgrid()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Select Case Label18.Text
            Case ""
                Label18.Text = "A"
            Case "A"
                Label18.Text = "AP"
            Case "AP"
                Label18.Text = "APL"
            Case "APL"
                Label18.Text = "APLI"
            Case "APLI"
                Label18.Text = "APLIK"
            Case "APLIK"
                Label18.Text = "APLIKA"
            Case "APLIKA"
                Label18.Text = "APLIKAS"
            Case "APLIKAS"
                Label18.Text = "APLIKASI"
            Case "APLIKASI"
                Label18.Text = "APLIKASI "
            Case "APLIKASI "
                Label18.Text = "APLIKASI P"
            Case "APLIKASI P"
                Label18.Text = "APLIKASI PE"
            Case "APLIKASI PE"
                Label18.Text = "APLIKASI PER"
            Case "APLIKASI PER"
                Label18.Text = "APLIKASI PERP"
            Case "APLIKASI PERP"
                Label18.Text = "APLIKASI PERPU"
            Case "APLIKASI PERPU"
                Label18.Text = "APLIKASI PERPUS"
            Case "APLIKASI PERPUS"
                Label18.Text = ""
        End Select
    End Sub


    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox6.KeyPress
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Dim TX7 As Double = TextBox7.Text
        Dim TX8 As Double = TextBox8.Text
        Dim TX9 As Double = TextBox9.Text
        If TX9 > TX7 Then
            MsgBox("Jumlah Sewa Melebihi Stok")
            TextBox9.Clear()
        ElseIf TX9 = 0 Then
            MsgBox("Jumlah Sewa Tidak Boleh Nol")
            TextBox9.Clear()
        ElseIf TX9 < 0 Then
            MsgBox("Jumlah Sewa Tidak Boleh Kurang Dari Nol")
            TextBox9.Clear()
        Else
            TextBox10.Text = TX9 * TX8
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Dim TX10 As Double = TextBox10.Text
        Dim TX11 As Double = TextBox11.Text
        If TX11 < TX10 Then
            MsgBox("Uang Tidak Cukup")
            TextBox11.Clear()
        Else
            TextBox12.Text = TX11 - TX10
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or DateTimePicker1.Text = "" Or DateTimePicker2.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or RadioButton1.Text = "" Or RadioButton2.Text = "" Or TextBox3.Text = "" Or ComboBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Try
                Call Koneksi()
                CMD = New SqlCommand("select * from Pinjam where Id_Pinjam='" & TextBox1.Text & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                Call jk()
                If Not DR.HasRows Then
                    Call Koneksi()
                    Dim simpan As String = " insert into Pinjam values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & PILIHAN & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')"
                    CMD = New SqlCommand(simpan, CONN)
                    CMD.ExecuteNonQuery()
                    Dim simpan2 As String = " insert into Detail values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & PILIHAN & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')"
                    CMD = New SqlCommand(simpan2, CONN)
                    CMD.ExecuteNonQuery()
                    CMD = New SqlCommand("select * from Buku where Id_Buku='" & ComboBox2.Text & "'", CONN)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    If DR.HasRows Then
                        Call Koneksi()
                        Dim KURANGI As String = " update Buku set STOK='" & DR.Item("STOK") - TextBox9.Text & "' where Id_Buku='" & ComboBox2.Text & "'"
                        CMD = New SqlCommand(KURANGI, CONN)
                        CMD.ExecuteNonQuery()
                        Call Kosongkan()
                    End If
                Else
                    Call Koneksi()
                    Dim edit As String = " update Pinjam set Nama='" & TextBox2.Text & "',JK='" & PILIHAN & "',Alamat='" & TextBox3.Text & "',Judul='" & TextBox4.Text & "', Pengarang='" & TextBox5.Text & "', Tahun_Terbit='" & TextBox6.Text & "', Harga_Sewa='" & TextBox8.Text & "', Jumlah_Sewa='" & TextBox9.Text & "', Tgl_Sewa='" & DateTimePicker1.Text & "',Tgl_Hrs_Kem='" & DateTimePicker2.Text & "',Total='" & TextBox10.Text & "', Bayar='" & TextBox11.Text & "' where Id_Pinjam='" & TextBox1.Text & "'"
                    CMD = New SqlCommand(edit, CONN)
                    CMD.ExecuteNonQuery()
                    Dim edit1 As String = " update Detail set Nama='" & TextBox2.Text & "',JK='" & PILIHAN & "',Alamat='" & TextBox3.Text & "',Judul='" & TextBox4.Text & "', Pengarang='" & TextBox5.Text & "', Tahun_Terbit='" & TextBox6.Text & "', Harga_Sewa='" & TextBox8.Text & "', Jumlah_Sewa='" & TextBox9.Text & "', Tgl_Sewa='" & DateTimePicker1.Text & "',Tgl_Hrs_Kem='" & DateTimePicker2.Text & "',Total='" & TextBox10.Text & "', Bayar='" & TextBox11.Text & "' where Id_Pinjam='" & TextBox1.Text & "'"
                    CMD = New SqlCommand(edit1, CONN)
                    CMD.ExecuteNonQuery()
                    CMD = New SqlCommand("select * from Buku where Id_Buku='" & ComboBox2.Text & "'", CONN)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    If DR.HasRows Then
                        Call Koneksi()
                        Dim KURANGI As String = " update Buku set STOK='" & (DR.Item("STOK") - TextBox9.Text) & "' where Id_Buku='" & ComboBox2.Text & "'"
                        CMD = New SqlCommand(KURANGI, CONN)
                        CMD.ExecuteNonQuery()
                        Call Kosongkan()
                    End If
                    Call Kosongkan()
                End If
                Call Kosongkan()
                Call tampilgrid()
                Call kodeotomatis()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("anda harus mengisi data dulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Hapus Data Ini...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from Pinjam where Id_Pinjam='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Dim hapus2 As String = "delete from Detail where Id_Pinjam='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus2, CONN)
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

    Private Sub DGV_CellContentClick_1(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV.CellContentClick
        On Error Resume Next
        TextBox1.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DGV.Rows(e.RowIndex).Cells(6).Value
        TextBox8.Text = DGV.Rows(e.RowIndex).Cells(7).Value
        TextBox9.Text = DGV.Rows(e.RowIndex).Cells(8).Value
        DateTimePicker1.Text = DGV.Rows(e.RowIndex).Cells(9).Value
        DateTimePicker2.Text = DGV.Rows(e.RowIndex).Cells(10).Value
        TextBox10.Text = DGV.Rows(e.RowIndex).Cells(11).Value
        TextBox11.Text = DGV.Rows(e.RowIndex).Cells(13).Value
        If DGV.Rows(e.RowIndex).Cells(2).Value = "L" Then
            RadioButton1.Checked = True
        ElseIf DGV.Rows(e.RowIndex).Cells(2).Value = "P" Then
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Call Kosongkan()
        Call kodeotomatis()
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Visible = False
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Koneksi()
        Me.Visible = False
        Menu_Utama.Show()
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Koneksi()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Value = DateTimePicker1.Value
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Mahasiswa where Id_Mahasiswa='" & ComboBox1.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            TextBox2.Text = DR.Item("Nama")
            If DR.Item("JK") = "L" Then
                RadioButton1.Checked = True
            ElseIf DR.Item("JK") = "P" Then
                RadioButton2.Checked = True
            End If
            TextBox3.Text = DR.Item("Alamat")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Buku where Id_Buku='" & ComboBox2.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            TextBox4.Text = DR.Item("Judul")
            TextBox5.Text = DR.Item("Pengarang")
            TextBox6.Text = DR.Item("Tahun_Terbit")
            TextBox7.Text = DR.Item("Stok")
            TextBox8.Text = DR.Item("Harga_Sewa")
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Call Koneksi()
        Struk.Show()
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Pinjam where Id_Pinjam like '%" & TextBox13.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from Pinjam where Id_Pinjam like '%" & TextBox13.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("ID Pinjam TIDAK DI TEMUKAN")
        End If
    End Sub
End Class