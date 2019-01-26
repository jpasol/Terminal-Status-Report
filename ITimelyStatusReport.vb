Public Interface ITerminalStatusReport
    Inherits AutomatedTerminalStatusReport.ITerminalStatusReport
    ReadOnly Property TimelyTerminalStatusReportDate As String
    ReadOnly Property ClosingTerminalStatusReport As AutomatedTerminalStatusReport.TSRClass
    ReadOnly Property TerminalStatusReports As List(Of AutomatedTerminalStatusReport.TSRClass)
    Sub RetrieveTerminalStatusReports()
End Interface
