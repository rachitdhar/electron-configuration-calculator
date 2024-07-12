Public Class Form1

    Dim rem_e As Integer

    Public Sub clean()
        Dim i As Integer = 1
        Do While i < 25
            For Each obj As Object In Me.Controls
                If obj.GetType Is GetType(Label) Then
                    Dim shell = DirectCast(obj, Label)
                    If shell.Name = "s" & i Then
                        shell.Text = "0"
                        i += 1
                    End If
                End If
            Next
        Loop
    End Sub

    Public Sub Compute()
        clean()
        Try
            rem_e = Val(no_e.Text)
            If Val(no_e.Text) <= 170 Then
                Dim i As Integer = 1
                Do Until rem_e = 0
                    For Each obj As Object In Me.Controls
                        If obj.GetType Is GetType(Label) Then
                            Dim shell = DirectCast(obj, Label)
                            If shell.Name = "s" & i Then
                                If shell.Tag < rem_e Then
                                    shell.Text = shell.Tag
                                    rem_e -= shell.Tag
                                Else
                                    shell.Text = rem_e
                                    rem_e = 0
                                End If
                                i += 1
                            End If
                        End If
                    Next
                Loop
            Else
                MsgBox("Please enter a number less than or equal to 170 only", MsgBoxStyle.OkOnly, "Electron Configuration")
            End If
        Catch ex As Exception
            MsgBox("Please enter some number in the Textbox", MsgBoxStyle.OkOnly, "Electron Configuration")
        End Try
    End Sub

    Public Sub WriteShell(ByVal b As String, ByVal n As Integer)
        ec.SelectedText = b
        ec.SelectionCharOffset = 10
        ec.SelectedText = n
        ec.SelectionCharOffset = 0
        ec.AppendText(" ")
    End Sub

    Private Sub ok_Click(sender As Object, e As EventArgs) Handles ok.Click
        Compute()
        ec.Clear()
        Dim i As Integer = 1
        Do Until i = 25
            For Each obj As Object In Me.Controls
                If obj.GetType Is GetType(Label) Then
                    Dim shell = DirectCast(obj, Label)
                    If shell.Name = "s" & i Then
                        If shell.Text = 0 Then
                            Exit Do
                        Else
                            WriteShell(shell.AccessibleName, shell.Text)
                        End If
                        i += 1
                    End If
                End If
            Next
        Loop
    End Sub
End Class