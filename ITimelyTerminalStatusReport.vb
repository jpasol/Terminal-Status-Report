Public Interface IYearlyTerminalStatusReport
    ReadOnly Property Year As Integer
    Property OPConnection As ADODB.Connection
    Property N4Connection As ADODB.Connection
    Property TerminalStatusReports As List(Of MonthlyTerminalStatusReport)
    ReadOnly Property ClosingTerminalStatusReport As MonthlyTerminalStatusReport
    ReadOnly Property Report As TSR
    Sub RetrieveTerminalStatusReports()
    Sub FormatReport()
    Sub Calculate()

End Interface
