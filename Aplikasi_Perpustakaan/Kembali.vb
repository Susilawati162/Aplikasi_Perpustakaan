Imports System.Data.SqlClient
Public Class Kembali

    Dim PILIHAN As String

    Sub Kosongkan()
        TextBox1.Clear()
        ComboBox1.Text = ""
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Text = ""
        TextBox7.Clear()
        DateTimePicker2.Text = ""
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
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
        TextBox5.Clear()
        DateTimePicker2.Text = ""
        TextBox7.Clear()
        TextBox6.Clear()
        DateTimePicker1.Text = ""
        DateTimePicker3.Text = ""
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox1.Focus()
    End Sub

    Sub tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from Kembali", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Sub pinjam()
        Call Koneksi()
        CMD = New SqlCommand(" select * from pinjam", CONN)
        DR = CMD.ExecuteReader
        Do While DR.Read()
            ComboBox1.Items.Add(DR.Item("Id_Pinjam"))
        Loop
    End Sub

    Sub kodeotomatis()
        Call koneksi()
        TextBox1.Enabled = False
        CMD = New SqlCommand("SELECT * from Kembali order by Id_Kembali desc", CONN)
        DR = CMD.ExecuteReader
        DR.Read()

        If Not DR.HasRows Then
            TextBox1.Text = "KEM-0001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(DR.Item("Id_Kembali").ToString, 5, 7)) + 1

            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "KEM-000" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "KEM-00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "KEM-0" & TextBox1.Text & ""
            End If
        End If
    End Sub

    Sub jk()
        If RadioButton1.Checked = True Then
            Pilihan = RadioButton1.Text 'L
        ElseIf RadioButton2.Checked = True Then
            Pilihan = RadioButton2.Text 'P
        End If
    End Sub

    Private Sub Kembali_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label18.Text = ""
        Timer1.Start()
        Call Kosongkan()
        Call pinjam()
        Call tampilgrid()
        Call Koneksi()
        Call kodeotomatis()
        TextBox2.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        DateTimePicker1.Enabled = False
        TextBox7.Enabled = False
        DateTimePicker2.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox11.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        TextBox8.Text = DateDiff("d", DateTimePicker2.Value, DateTimePicker3.Value)
        If TextBox8.Text < 0 Then
            TextBox8.Text = 0
            TextBox9.Text = "Rp.0"
        Else
            TextBox9.Text = TextBox8.Text * 5000
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Dim TX9 As Double = TextBox9.Text
        Dim TX10 As Double = TextBox10.Text
        If TX10 < TX9 Then
            MsgBox("Uang Tidak Cukup")
            TextBox10.Clear()
        Else
            TextBox11.Text = TX10 - TX9
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or DateTimePicker1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Try
                Call Koneksi()
                CMD = New SqlCommand("select * from Kembali where Id_Kembali='" & TextBox1.Text & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                Call jk()
                If Not DR.HasRows Then
                    Call Koneksi()
                    Dim simpan As String = " insert into Kembali values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & PILIHAN & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & DateTimePicker3.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')"
                    CMD = New SqlCommand(simpan, CONN)
                    CMD.ExecuteNonQuery()
                    Dim simpan1 As String = " insert into Detail1 values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & PILIHAN & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & DateTimePicker3.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')"
                    CMD = New SqlCommand(simpan1, CONN)
                    CMD.ExecuteNonQuery()
                    Call Kosongkan()
                Else
                    Call Koneksi()
                    Dim edit As String = " update Kembali set Nama='" & TextBox2.Text & "',JK='" & PILIHAN & "',Alamat='" & TextBox3.Text & "',Judul='" & TextBox4.Text & "',Pengarang='" & TextBox5.Text & "',Jumlah_Sewa='" & TextBox6.Text & "',Tahun_Terbit='" & TextBox7.Text & "',Tgl_Sewa='" & DateTimePicker1.Text & "',Tgl_Hrs_Kem='" & DateTimePicker2.Text & "', Tgl_Skrg='" & DateTimePicker3.Text & "',Terlambat='" & TextBox8.Text & "',Denda='" & TextBox9.Text & "',Bayar='" & TextBox10.Text & "' where Id_Kembali='" & TextBox1.Text & "'"
                    CMD = New SqlCommand(edit, CONN)
                    CMD.ExecuteNonQuery()
                    Dim edit1 As String = " update Detail1 set Nama='" & TextBox2.Text & "',JK='" & PILIHAN & "',Alamat='" & TextBox3.Text & "',Judul='" & TextBox4.Text & "',Pengarang='" & TextBox5.Text & "',Jumlah_Sewa='" & TextBox6.Text & "',Tahun_Terbit='" & TextBox7.Text & "',Tgl_Sewa='" & DateTimePicker1.Text & "',Tgl_Hrs_Kem='" & DateTimePicker2.Text & "', Tgl_Skrg='" & DateTimePicker3.Text & "',Terlambat='" & TextBox8.Text & "',Denda='" & TextBox9.Text & "',Bayar='" & TextBox10.Text & "' where Id_Kembali='" & TextBox1.Text & "'"
                    CMD = New SqlCommand(edit1, CONN)
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

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("anda harus mengisi data dulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Hapus Data Ini...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from Kembali where Id_Kembali='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Dim hapus1 As String = "delete from Detail1 where Id_Kembali='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus1, CONN)
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
        ComboBox1.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        TextBox4.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        TextBox5.Text = DGV.Rows(e.RowIndex).Cells(6).Value
        DateTimePicker1.Text = DGV.Rows(e.RowIndex).Cells(7).Value
        TextBox6.Text = DGV.Rows(e.RowIndex).Cells(8).Value
        DateTimePicker2.Text = DGV.Rows(e.RowIndex).Cells(9).Value
        DateTimePicker3.Text = DGV.Rows(e.RowIndex).Cells(10).Value
        TextBox7.Text = DGV.Rows(e.RowIndex).Cells(11).Value
        TextBox8.Text = DGV.Rows(e.RowIndex).Cells(12).Value
        TextBox9.Text = DGV.Rows(e.RowIndex).Cells(13).Value
        If DGV.Rows(e.RowIndex).Cells(3).Value = "L" Then
            RadioButton1.Checked = True
        ElseIf DGV.Rows(e.RowIndex).Cells(3).Value = "P" Then
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Call Kosongkan()
        Call kodeotomatis()
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs)
        Call Koneksi()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Koneksi()
        Me.Visible = False
        Menu_Utama.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Pinjam where Id_Pinjam='" & ComboBox1.Text & "'", CONN)
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
            TextBox4.Text = DR.Item("Judul")
            TextBox5.Text = DR.Item("Pengarang")
            TextBox6.Text = DR.Item("Jumlah_Sewa")
            TextBox7.Text = DR.Item("Tahun_Terbit")
            DateTimePicker1.Text = DR.Item("Tgl_Sewa")
            DateTimePicker2.Text = DR.Item("Tgl_Hrs_Kem")
        End If
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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Call Koneksi()
        Struk2.Show()
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from Kembali where Id_Kembali like '%" & TextBox11.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from Kembali where Id_Kembali like '%" & TextBox11.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("ID KEMBALI TIDAK DI TEMUKAN")
        End If
    End Sub
End Class