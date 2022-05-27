
Imports System.Net.Mail
Imports System.Net
Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CRUD.strstrconnection()
        Me.Text = "Email Sending App"
        Try 'CALL THE METHOD THAT YOU HAVE CREATED. 
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS. 
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW reload("SELECT * FROM users", DTGLIST) 
            Dim query As String
            query = "SELECT e.primerApellido,e.segundoApellido,e.primerNombre,e.segundoNombre
                     FROM estudiante e"
            CRUD.reload(query, DataGridView1)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try 'CALL THE METHOD THAT YOU HAVE CREATED. 
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS. 
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW reload("SELECT * FROM users", DTGLIST) 
            Dim query As String
            query = "SELECT e.primerApellido,e.segundoApellido,e.primerNombre,e.segundoNombre
                     FROM estudiante e"
            CRUD.reload(query, DataGridView1)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim plantilla As String
        plantilla = "los siguientes"
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("pruebaproyectobasededatos@gmail.com", "proyectoAsistencia")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("pruebaproyectobasededatos@gmail.com")
            e_mail.To.Add("luissebastian.cepedaflechas@gmail.com")
            e_mail.Subject = "Prueba correo"
            e_mail.IsBodyHtml = False
            e_mail.Body = plantilla
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
