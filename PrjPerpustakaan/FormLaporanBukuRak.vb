﻿Public Class FormLaporanBukuRak
    Sub isicombo()
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from table_rak1810005 order by rak_kode1810005"
        cek = perintah.ExecuteReader
        While cek.Read
            awalrak.Items.Add(cek.Item("rak_kode1810005") & " - Kapasitas = " & cek.Item("rak_kapasitas1810005"))
        End While
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim subs As Integer
        Dim x As String = awalrak.SelectedItem

        If x.Substring(2, 1) = "-" Then
            subs = 1
        ElseIf x.Substring(3, 1) = "-" Then
            subs = 2
        ElseIf x.Substring(4, 1) = "-" Then
            subs = 3
        ElseIf x.Substring(5, 1) = "-" Then
            subs = 4
        ElseIf x.Substring(6, 1) = "-" Then
            subs = 5
        ElseIf x.Substring(7, 1) = "-" Then
            subs = 6
        ElseIf x.Substring(8, 1) = "-" Then
            subs = 7
        ElseIf x.Substring(9, 1) = "-" Then
            subs = 8
        ElseIf x.Substring(10, 1) = "-" Then
            subs = 9
        ElseIf x.Substring(11, 1) = "-" Then
            subs = 10
        End If

        Dim value As String = awalrak.SelectedItem

        value = value.Substring(0, subs)

        kon.Close()
        Dim lapbukurak As New LapBukuRak
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "SELECT rak_kode1810005, rak_kapasitas1810005, rak_lokasi1810005, buku_id1810005, buku_judul1810005, penerbit_nama1810005, " & _
            "pengarang_nama1810005, buku_tahun1810005, buku_jumlah1810005 FROM table_buku1810005 JOIN table_rak1810005 ON rak_kode1810005=buku_idrak1810005 " & _
            "JOIN table_penerbit1810005 ON penerbit_id1810005=buku_idpenerbit1810005 JOIN table_pengarang1810005 ON pengarang_id1810005=buku_idpengarang1810005 " & _
            "WHERE rak_kode1810005='" & value & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "bukurak")
        lapbukurak.SetDataSource(ds.Tables("bukurak"))
        FormCetakLapBukuRak.crv.ReportSource = lapbukurak
        FormCetakLapBukuRak.WindowState = FormWindowState.Maximized
        FormCetakLapBukuRak.Show()
        kon.Close()
    End Sub

    Private Sub FormLaporanBukuPn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isicombo()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        FormMenu.Enabled = True
        Me.Visible = False
    End Sub
End Class