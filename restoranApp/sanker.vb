﻿Imports System.Data.SqlClient
Public Class sanker

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
        prijava.Show()
    End Sub

    Private Sub sanker_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim sqlCommand As New SqlCommand("SELECT * FROM  narudzbaS", Baza.connection)
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim pica_tabel As New DataTable()


        Dim brojacOpreme As Integer = 0
        Try
            adapter.Fill(pica_tabel)
            brojacOpreme = pica_tabel.Rows.Count

            For i = 0 To brojacOpreme
                Dim L As Label = New Label
                With L
                    .Text = pica_tabel.Rows(i)(0)             'naziv artikla izvucen u label
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = True
                    .Font = New Font("Microsoft Sans Serif", 14)
                    .BackColor = Color.Transparent
                    .Dock = DockStyle.Fill

                    table.Controls.Add(L, 0, i)
                End With

                Dim L1 As Label = New Label
                With L1
                    .Text = pica_tabel.Rows(i)(1)
                    .Name = "L1" + i.ToString 'kolicina izvucena u label
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = True
                    .Font = New Font("Microsoft Sans Serif", 14)
                    .BackColor = Color.Transparent
                    .Dock = DockStyle.Fill
                    table.Controls.Add(L1, 1, i)
                End With

                Dim L2 As Label = New Label
                With L2
                    .Text = pica_tabel.Rows(i)(2)
                    .TextAlign = ContentAlignment.MiddleCenter 'cijena izvucena u label
                    .Visible = True
                    .BackColor = Color.Transparent
                    .Font = New Font("Microsoft Sans Serif", 14)
                    .Dock = DockStyle.Fill
                    table.Controls.Add(L2, 2, i)
                End With

                Dim b As Button = New Button
                With b

                    .Text = "OTVORI"
                    .Name = "b" + i.ToString
                    .Visible = True
                    .Size = New Size(100, 40)

                    AddHandler b.Click, AddressOf btnCreate_Click
                    table.Controls.Add(b, 3, i)
                End With

                table.HorizontalScroll.Enabled = False

            Next
        Catch ex As Exception
        End Try



    End Sub


    Public Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs)
        'cCreate_Click

        Dim sqlCommand1 As New SqlCommand("SELECT * FROM  narudzbaS", Baza.connection)
        Dim adapter1 As New SqlDataAdapter(sqlCommand1)
        Dim pica_tabel As New DataTable()

        adapter1.Fill(pica_tabel)



        Dim sqlCommand As New SqlCommand("SELECT * FROM NarudzbaK ", Baza.connection)
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim oprema_table As New DataTable()


        Dim brojacOpreme As Integer = 0
        Try
            adapter.Fill(oprema_table)
            brojacOpreme = oprema_table.Rows.Count
        Catch ex As Exception
        End Try

        Dim i As Integer
        Dim b As Button = DirectCast(sender, Button)
        For i = 0 To brojacOpreme
            If b.Name = "b" + i.ToString Then
                pregledNarudzbe.Show()
                pregledNarudzbe.ucitaj(pica_tabel.Rows(i)(0))
            End If
        Next
        Me.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Me.Controls.Clear() 'removes all the controls on the form
        'InitializeComponent() 'load all the controls again
        'sanker_Load(e, e)
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        sanker_Load(e, e)
    End Sub
End Class