Public Class frmNotifSettings


    Private Sub frmNotifSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadTones()
        If modGlobal.alertaudio = "" Then
            Me.chkmute.Checked = True
        Else
            Me.cmbtones.SelectedItem = modGlobal.alertaudio
        End If
    End Sub
    Private Sub loadTones()
        Me.cmbtones.Items.Clear()
        Dim di As New IO.DirectoryInfo("templates\alerts")
        Dim arrFolders As IO.DirectoryInfo() = di.GetDirectories()
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.wav")
        For Each fi In aryFi
            Me.cmbtones.Items.Add(fi.Name)
        Next
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://mixkit.co/free-sound-effects/notification")
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        If Me.chkmute.Checked Then
            clsOffices.updateRingtone("", modGlobal.sourceOfficeCode)
            modGlobal.alertaudio = ""
        ElseIf Me.cmbtones.SelectedIndex >= 0 Then
            clsOffices.updateRingtone(cmbtones.Text, modGlobal.sourceOfficeCode)
            modGlobal.alertaudio = cmbtones.Text
        End If
        Me.Close()
    End Sub

    Private Sub cmbtones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtones.SelectedIndexChanged
        Me.btnplay.Enabled = Me.cmbtones.SelectedIndex >= 0
    End Sub

    Private Sub btnadd_Click(sender As System.Object, e As System.EventArgs) Handles btnadd.Click
        Dim fd As New OpenFileDialog()
        fd.RestoreDirectory = True
        fd.Filter = "Audio Files(*.wav)|*wav;"
        If fd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filename As String = fd.SafeFileName
            If filename.Contains(".wav") = False Then
                filename = filename & ".wav"
            End If
            If System.IO.File.Exists("templates\alerts\" & filename) Then
                MsgBox("Audio already exist.")
            Else
                System.IO.File.Copy(fd.FileName, "templates\alerts\" & filename)
                Me.chkmute.Checked = False
                loadTones()
                Me.cmbtones.SelectedItem = filename
            End If
        End If
    End Sub

    Private Sub btnplay_Click(sender As System.Object, e As System.EventArgs) Handles btnplay.Click
        Try
            If System.IO.File.Exists("templates\alerts\" & cmbtones.Text) Then
                My.Computer.Audio.Play("templates\alerts\" & cmbtones.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkmute_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkmute.CheckedChanged
        If Me.chkmute.Checked Then
            Me.cmbtones.SelectedIndex = -1
            Me.cmbtones.Enabled = False
        Else
            Me.cmbtones.Enabled = True
        End If
    End Sub
End Class