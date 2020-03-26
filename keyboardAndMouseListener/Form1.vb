Public Class Form1
    Dim kbHook As FullHook
    Dim AllData As DataSession
    Public Running As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Running Then
            kbHook = New FullHook()
            AllData = New DataSession(True, Me)
            AddHandler AllData.ActionAdded, AddressOf NewEvent
            kbHook.Start(Me, AllData)
            Button1.Text = "Unhook Computer"
        Else
            kbHook.StopAll()
            kbHook.Dispose()
            kbHook = Nothing
            AllData = Nothing
            Button1.Text = "Hook Computer"
        End If
        Running = Not Running
    End Sub


    Private Sub NewEvent(ByRef _action As OneAction)
        ListBox1.Items.Add(Now.ToString & " > " & _action.ToString)
        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub
  


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If kbHook IsNot Nothing Then
            kbHook.Dispose()
        End If
    End Sub
    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & _
            "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
