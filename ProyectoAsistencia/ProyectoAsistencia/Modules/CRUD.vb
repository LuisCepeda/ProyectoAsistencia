Imports MySql.Data.MySqlClient
Module CRUD
    'SETTING UP THE CONNECTION

    Public Function strstrconnection() As MySqlConnection
        Dim vConnString As New MySqlConnectionStringBuilder
        'vConnString.Server = "localhost"
        'vConnString.Port = "3308"
        'vConnString.Database = "proyectoasistencia"
        'vConnString.UserID = "root"
        'vConnString.Password = "pass123SQL"

        vConnString.Server = "bwv4kwv0evdypdwgjby1-mysql.services.clever-cloud.com"
        vConnString.Port = "3306"
        vConnString.Database = "bwv4kwv0evdypdwgjby1"
        vConnString.UserID = "u75eetfmdauejadh"
        vConnString.Password = "Ijyi2awemy70KNv33P1M"

        vConnString.IntegratedSecurity = False
        Return New MySqlConnection(vConnString.ToString)

    End Function

    Public strcon As MySqlConnection = strstrconnection()
    'DECLARING CLASSES AND VARIABLE
    Public result As String
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable

    'THIS METHOD IS FOR INSERTING DATA IN THE DATABASE
    Public Sub create(ByVal sql As String)
        Try
            strcon.Open()
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = strcon
                .CommandText = sql
                'EXECUTE THE DATA
                result = cmd.ExecuteNonQuery
                'CHECKING IF THE DATA HAS EXECUTED OR NOT AND THEN THE POP UP MESSAGE WILL APPEAR
                If result = 0 Then
                    MsgBox("FAILED TO SAVE THE DATA", MsgBoxStyle.Information)
                Else
                    MsgBox("DATA HAS BEEN SAVE IN THE DATABASE")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub


    'THIS METHOD IS FOR RETRIEVING DATA IN THE DATABASE
    Public Sub reload(ByVal sql As String, ByVal DTG As Object)
        Try
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            DTG.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub

    'THIS METHOD IS FOR UPDATING THE DATA IN THE DATABASE.
    Public Sub updates(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("DATA IS FAILED TO UPDATE.", MsgBoxStyle.Information)
                Else
                    MsgBox("THE DATA HAS BEEN UPDATED IN THE DATABASE.")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub

    'THIS METHOD IS FOR DELETING THE DATA IN THE DATABASE
    Public Sub delete(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("FAILED TO DELETE THE DATA IN THE DATABASE.", MsgBoxStyle.Critical)
                Else
                    MsgBox("DATA HAS BEEN DELETED IN THE DATABASE.")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub


End Module