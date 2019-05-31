Imports AutomatedTerminalStatusReport
Module Program
    Public Sub Main()
        Dim TerminalStatusReport As New TSRClass(Now)
        TerminalStatusReport.Save()
    End Sub
End Module
