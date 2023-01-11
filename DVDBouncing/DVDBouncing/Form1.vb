Imports System.Diagnostics.Eventing.Reader

Public Class Form1

    Dim MoveRight As Boolean

    Dim MoveUp As Boolean

    Dim txttop As Integer

    Dim txtbottom As Integer

    Dim txtright As Integer

    Dim txtleft As Integer

    Dim Colour As Pen

    Dim Rng As New Random()

    Private Sub Form_Resize()

        PictureBox2.Size = ClientSize

        TextBox1.BorderStyle = 0

        TextBox2.BorderStyle = 0

        TextBox3.BorderStyle = 0

        TextBox4.BorderStyle = 0

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim MyGraphics As Graphics = Graphics.FromImage(PictureBox2.Image)

        Colour = New Pen(Color.FromArgb(Rng.Next(256), Rng.Next(256), Rng.Next(256)))

        Form_Resize()

        If MoveRight = True Then

            PictureBox1.Left += 5

        Else

            PictureBox1.Left -= 5

        End If

        If MoveUp = True Then

            PictureBox1.Top -= 5

        Else

            PictureBox1.Top += 5

        End If

        If MoveRight = True And MoveUp = True Then 'North East

            MyGraphics.DrawLine(Colour, PictureBox1.Left, PictureBox1.Bottom, PictureBox1.Right, PictureBox1.Top)

        Else

            If MoveRight = False And MoveUp = False Then 'South West

                MyGraphics.DrawLine(Colour, PictureBox1.Right, PictureBox1.Top, PictureBox1.Left, PictureBox1.Bottom)

            Else

                If MoveRight = True And MoveUp = False Then 'South East

                    MyGraphics.DrawLine(Colour, PictureBox1.Left, PictureBox1.Top, PictureBox1.Right, PictureBox1.Bottom)

                Else

                    If MoveRight = False And MoveUp = True Then 'North West

                        MyGraphics.DrawLine(Colour, PictureBox1.Right, PictureBox1.Bottom, PictureBox1.Left, PictureBox1.Top)

                    End If

                End If

            End If

        End If

        If PictureBox1.Left <= PictureBox2.Left Then

            MoveRight = True

            txtleft += 1

        End If

        If PictureBox1.Left + PictureBox1.Width >= PictureBox2.Right Then

            MoveRight = False

            txtright += 1

        End If

        If PictureBox1.Top <= PictureBox2.Top Then

            MoveUp = False

            txttop += 1

        End If

        If PictureBox1.Top + PictureBox1.Height >= PictureBox2.Bottom Then

            MoveUp = True

            txtbottom += 1

        End If

        TextBox1.Text = "Left: " & txtleft

        TextBox2.Text = "Right: " & txtright

        TextBox3.Text = "Top: " & txttop

        TextBox4.Text = "Bottom: " & txtbottom

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.BackColor = Color.White

        TextBox2.BackColor = Color.White

        TextBox3.BackColor = Color.White

        TextBox4.BackColor = Color.White

        PictureBox1.Parent = PictureBox2

    End Sub

End Class
