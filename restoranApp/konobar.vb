﻿Imports System.Data.SqlClient
Public Class konobar
    Public Shared counter As Integer = 0
    Public Sub Sumiranje(i As String, b As Integer)
        'Dim nazivPica As Label = New Label
        'With nazivPica
        '    .Text = i
        '    .TextAlign = ContentAlignment.MiddleCenter
        '    .Visible = True
        '    .BackColor = Color.Transparent
        '    .Font = New Font("Microsoft Sans Serif", 14)
        '    .Dock = DockStyle.Fill
        '    TABLA.Controls.Add(nazivPica, 0, 0)
        'End With
        'Dim kolicina As Label = New Label
        'With kolicina
        '    .Text = b
        '    .TextAlign = ContentAlignment.MiddleCenter
        '    .Visible = True
        '    .BackColor = Color.Transparent
        '    .Font = New Font("Microsoft Sans Serif", 14)
        '    .Dock = DockStyle.Fill
        '    TABLA.Controls.Add(kolicina, 1, 0)
        'End With
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CocaColaL.Text = CDbl(CocaColaL.Text) + 1
        'Button1.Tag = CDbl(Button1.Tag) + 1
        ' Sumiranje(Button1.Text, Label3.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PepsiL.Text = CDbl(PepsiL.Text) + 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FantaL.Text = CDbl(FantaL.Text) + 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        prijava.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Dim Command As New SqlCommand("SELECT * FROM NarudzbaK", Baza.connection)


        Dim commandS As New SqlCommand("SELECT Max(brojNarudzbe) FROM NarudzbaS", Baza.connection)

        Dim adapterS As New SqlDataAdapter(commandS)
        Dim tableS As New DataTable
        adapterS.Fill(tableS)

        Dim vrijednostID As Integer
        vrijednostID = tableS.Rows(0)(0)
        vrijednostID += 1





        Label2.Text = prijava.imePrijavljenog
        Try
            Baza.connection.Open()

            Dim Command As New SqlCommand("INSERT INTO NarudzbaK (redniBroj, konobar, CocaCola, Pepsi, Fanta, RedBUll, Schweppes, Sprite, Mineralna, Juice, Jabuka, Visnja, Borovnica, Multivitamin, Cijedjenisok, Ledenicaj, Vodasokusom, Izvorskavoda, Esspresso, Espressosmlijekom, Macchiato, Cappuccino, Nesscafe, Toplacokolada, Caj, Heineken, Nektar, Jelen, Staropramen, Banjalucko, Tuborg, Becks, JackDaniels, Belvedere, GreyGooz, VigorVodka, Jagermeister, Absinth, Viljamovka, Gin, BadelKonjak, RubinovVinjak ) VALUES  (" + vrijednostID.ToString + ", '" + prijava.KoJeOvajPokemon.Text + "' , " + CocaColaL.Text + ", " + PepsiL.Text + ", " + FantaL.Text + "," + RedBullL.Text + ", " + SchweppesL.Text + ", " + SpriteL.Text + ",  " + MineralnaL.Text + ", " + JuiceL.Text + ", " + JabukaL.Text + "," + VisnjaL.Text + ", " + BorovnicaL.Text + ", " + MultivitaminL.Text + ", " + CijedjenisokL.Text + ", " + LedeniCajL.Text + ", " + VodasokusomL.Text + "," + IzvorskavodaL.Text + ", " + EsspressoL.Text + ", " + EspressosmlijekomL.Text + ",  " + MacchiatoL.Text + ", " + CappuccinoL.Text + ", " + NesscafeL.Text + "," + ToplacokoladaL.Text + ", " + CajL.Text + ", " + HeinekenL.Text + " , " + NektarL.Text + "," + JelenL.Text + ", " + StaropramenL.Text + ", " + BanjaluckoL.Text + ", " + TuborgL.Text + ", " + BecksL.Text + " , " + JackDanielsL.Text + "," + BelvedereL.Text + ", " + GreygooseL.Text + ", " + VigorVodkaL.Text + ", " + JagermeisterL.Text + ", " + AbsinthL.Text + ", " + ViljamovkaL.Text + " , " + GinL.Text + "," + BadelKonjakL.Text + ", " + RubinovVinjakL.Text + ") ", Baza.connection)
            Dim brojac As Integer
            brojac = 0
            brojac += 1
            Dim Command1 As New SqlCommand("INSERT INTO NarudzbaS (brojNarudzbe, konobar, vrijemeNarudzbe) VALUES (" + vrijednostID.ToString + ", '" + prijava.KoJeOvajPokemon.Text + "', '" + Label1.Text + "') ", Baza.connection)
            brojac += 1


            If brojac = 2 And counter < 40 Then
                Command1.ExecuteNonQuery()
                Command.ExecuteNonQuery()

                Baza.connection.Close()

                MsgBox("Narudzba poslata sankeru!")

                Me.Controls.Clear() 'removes all the controls on the form
                InitializeComponent() 'load all the controls again
                konobar_Load(e, e)
            ElseIf counter = 40 Then
                MsgBox("Ne mozete poslati praznu narudzbu!")
                Baza.connection.Close()
            End If
        Catch ex As Exception
            Baza.connection.Close()
            MessageBox.Show(ex.ToString)
        End Try



    End Sub

    Private Sub konobar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = prijava.imePrijavljenog
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        konobar_Load(e, e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        counter = 0

        For Each Label In Me.Controls
            If Label.text = "0" Then
                Label.visible = False
                counter += 1
            Else
                Label.visible = True
            End If



        Next

        Label1.Text = TimeOfDay.ToString("hh:mm tt")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RedBullL.Text = CDbl(RedBullL.Text) + 1
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        SchweppesL.Text = CDbl(SchweppesL.Text) + 1
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        SpriteL.Text = CDbl(SpriteL.Text) + 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MineralnaL.Text = CDbl(MineralnaL.Text) + 1
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        JuiceL.Text = CDbl(JuiceL.Text) + 1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        JabukaL.Text = CDbl(JabukaL.Text) + 1
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        VisnjaL.Text = CDbl(VisnjaL.Text) + 1
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        BorovnicaL.Text = CDbl(BorovnicaL.Text) + 1
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        MultivitaminL.Text = CDbl(MultivitaminL.Text) + 1
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CijedjenisokL.Text = CDbl(CijedjenisokL.Text) + 1
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        LedeniCajL.Text = CDbl(LedeniCajL.Text) + 1
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        VodasokusomL.Text = CDbl(VodasokusomL.Text) + 1
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        IzvorskavodaL.Text = CDbl(IzvorskavodaL.Text) + 1
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        EsspressoL.Text = CDbl(EsspressoL.Text) + 1
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        EspressosmlijekomL.Text = CDbl(EspressosmlijekomL.Text) + 1
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        MacchiatoL.Text = CDbl(MacchiatoL.Text) + 1
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CappuccinoL.Text = CDbl(CappuccinoL.Text) + 1
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        NesscafeL.Text = CDbl(NesscafeL.Text) + 1
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        ToplacokoladaL.Text = CDbl(ToplacokoladaL.Text) + 1
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CajL.Text = CDbl(CajL.Text) + 1
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        HeinekenL.Text = CDbl(HeinekenL.Text) + 1
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        NektarL.Text = CDbl(NektarL.Text) + 1
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        JelenL.Text = CDbl(JelenL.Text) + 1
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        StaropramenL.Text = CDbl(StaropramenL.Text) + 1
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        BanjaluckoL.Text = CDbl(BanjaluckoL.Text) + 1
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        TuborgL.Text = CDbl(TuborgL.Text) + 1
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        BecksL.Text = CDbl(BecksL.Text) + 1
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        JackDanielsL.Text = CDbl(JackDanielsL.Text) + 1
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        BelvedereL.Text = CDbl(BelvedereL.Text) + 1
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        GreygooseL.Text = CDbl(GreygooseL.Text) + 1
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        VigorVodkaL.Text = CDbl(VigorVodkaL.Text) + 1
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        JagermeisterL.Text = CDbl(JagermeisterL.Text) + 1
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        AbsinthL.Text = CDbl(AbsinthL.Text) + 1
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        ViljamovkaL.Text = CDbl(ViljamovkaL.Text) + 1
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        GinL.Text = CDbl(GinL.Text) + 1
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        BadelKonjakL.Text = CDbl(BadelKonjakL.Text) + 1
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        RubinovVinjakL.Text = CDbl(RubinovVinjakL.Text) + 1
    End Sub
End Class