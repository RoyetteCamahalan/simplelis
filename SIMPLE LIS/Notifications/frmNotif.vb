Public Class frmNotif
    Private adapterHeight As Integer = 60
    Public Enum enMsgType
        _info
        _success
        _warning
        _error
    End Enum
    Private interval As Integer
    Private dtNotifs As DataTable
    Private Sub frmNotif_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Visible = True

        'Me.ShowInTaskbar = False

        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop
    End Sub
    Public Sub StartBroadCast()
        getNotifs()
        Timer1.Interval = IIf(modGlobal.alerttimeout = 0, 6000, modGlobal.alerttimeout * 100)
        Timer1.Start()
    End Sub
    Public Sub getNotifs()
        Dim dpk(1) As DataColumn
        dtNotifs = clsNotification.getNotifs
        dpk(0) = dtNotifs.Columns("notificationid")
        dtNotifs.PrimaryKey = dpk

        Dim haschanges As Boolean
        For Each ctrl As Control In Me.Panel1.Controls
            Dim _row As DataRow = dtNotifs.Rows.Find(ctrl.Name.Replace("ctrl_", ""))
            If _row Is Nothing Then
                Me.Panel1.Controls.Remove(ctrl)
                haschanges = True
            Else
                dtNotifs.Rows.Remove(_row)
            End If
        Next

        For Each row As DataRow In dtNotifs.Rows
            Dim panel As Control = Me.Panel1.Controls.Find("ctrl_" & row.Item("notificationid"), True).FirstOrDefault()
            If panel Is Nothing Then
                addItem(row.Item("notificationid"), row.Item("title"), row.Item("description"))
            End If
        Next
        If haschanges Then
            arrangeControls()
        End If
    End Sub
    Public Sub addItem(notifid As Long, title As String, msg As String, Optional msgtype As enMsgType = enMsgType._info)
        Dim adapter As New ucNotifAdapter()
        adapter.lbltitle.Text = title
        adapter.lblmessage.Text = msg
        If msgtype = enMsgType._info Then
            adapter.BackColor = Color.AliceBlue
            adapter.PictureBox1.Image = My.Resources.ic_info_24
        ElseIf msgtype = enMsgType._success Then
            adapter.BackColor = Color.Honeydew
            adapter.PictureBox1.Image = My.Resources.ic_check_24
        ElseIf msgtype = enMsgType._warning Or msgtype = enMsgType._error Then
            adapter.BackColor = Color.LightYellow
            adapter.PictureBox1.Image = My.Resources.ic_warning_24
        End If
        adapter.Location = New Point(0, adapterHeight * Me.Panel1.Controls.Count)
        adapter.Name = "ctrl_" & notifid
        adapter.btnremove.Tag = adapter.Name
        AddHandler adapter.btnremove.Click, AddressOf remove_Click
        Me.Panel1.Controls.Add(adapter)
        Me.Height = (adapterHeight * Me.Panel1.Controls.Count) + Me.panelheader.Height
        If Me.Panel1.Controls.Count > 0 And Me.Visible = False Then
            Me.Show()
            Me.TopMost = True
        Else
            If Me.Height >= Screen.PrimaryScreen.WorkingArea.Height Then
                Dim panel As Control = Me.Panel1.Controls(0)
                If Not panel Is Nothing Then
                    Panel1.Controls.Remove(panel)
                End If
                arrangeControls()
            End If
        End If
        setLocationY()

        Me.BringToFront()
        Try

            If modGlobal.alertaudio <> "" AndAlso System.IO.File.Exists("templates\alerts\" & modGlobal.alertaudio) Then
                My.Computer.Audio.Play("templates\alerts\" & modGlobal.alertaudio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub remove_Click(sender As System.Object, e As System.EventArgs)
        Dim panel As Control = Me.Panel1.Controls.Find(sender.Tag, True).First
        If Not panel Is Nothing Then
            Panel1.Controls.Remove(panel)
        End If
        arrangeControls()
        clsNotification.markAsRead(sender.Tag.ToString().Replace("ctrl_", ""))
    End Sub
    Private Sub arrangeControls()
        Dim idx As Integer = 0
        For Each ctrl As Control In Me.Panel1.Controls
            ctrl.Location = New Point(0, adapterHeight * idx)
            idx = idx + 1
        Next
        If Me.Panel1.Controls.Count = 0 Then
            Me.Hide()
        Else
            Me.Height = (adapterHeight * Me.Panel1.Controls.Count) + Me.panelheader.Height
            setLocationY()
        End If
    End Sub
    Private Sub setLocationY()
        Dim x As Integer = Me.Location.X
        Dim y As Integer = Me.Location.Y
        Dim targetY As Integer = IIf(y > Screen.PrimaryScreen.WorkingArea.Height - Me.Height, -1, 1)

        Do Until y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
            y = y + targetY
            Me.Location = New Point(x, y)
        Loop
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        getNotifs()
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        For Each ctrl As Control In Me.Panel1.Controls
            clsNotification.markAsRead(ctrl.Name.Replace("ctrl_", ""))
        Next
        Me.Panel1.Controls.Clear()
        Me.Height = (adapterHeight * Me.Panel1.Controls.Count) + Me.panelheader.Height
        Me.Hide()
    End Sub

    Private Sub btnsettings_Click(sender As System.Object, e As System.EventArgs) Handles btnsettings.Click
        Dim f As New frmNotifSettings
        f.Show()
    End Sub
End Class