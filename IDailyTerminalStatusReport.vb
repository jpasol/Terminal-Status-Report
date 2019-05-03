Public Interface IDailyTerminalStatusReport
    ReadOnly Property DailyTerminalStatusReportDate As String

    ReadOnly Property TotalGroundSlotTEU As Integer
    ReadOnly Property StaticCapacityTEU As Integer
    ReadOnly Property TotalYardCapacityTEU As Integer
    ReadOnly Property MTDAverageGrossCraneProductivity As Double
    ReadOnly Property MTDAverageGrossBerthProductivity As Double
    ReadOnly Property MTDAverageGrossVesselProductivity As Double
    ReadOnly Property MTDAverageNetCraneProductivity As Double
    ReadOnly Property MTDAverageNetBerthProductivity As Double
    ReadOnly Property MTDAverageNetVesselProductivity As Double
    ReadOnly Property CraneDensity As Double
    ReadOnly Property AverageImportDwellTime As Double
    ReadOnly Property MTDImportDwellTime As Double
    ReadOnly Property YTDImportDwellTime As Double
    ReadOnly Property MTDExportDwellTime As Double
    ReadOnly Property YTDExportDwellTime As Double
    ReadOnly Property DailyTEUInByTrucks As Double
    ReadOnly Property DailyTEUOutByTrucks As Double
    ReadOnly Property MTDTEUInByTrucks As Double
    ReadOnly Property MTDTEUOutByTrucks As Double
    ReadOnly Property YTDTEUInByTrucks As Double
    ReadOnly Property YTDTEUOutByTrucks As Double
    ReadOnly Property OverstayingManilaCargo As Double
    ReadOnly Property TotalOverstayingCargo As Double
    ReadOnly Property ImportFullTEU As Double
    ReadOnly Property ImportEmptyTEU As Double
    ReadOnly Property ExportFullTEU As Double
    ReadOnly Property ExportEmptyTEU As Double
    ReadOnly Property StorageEmptyTEU As Double
    ReadOnly Property TotalInYardTEU As Double
    ReadOnly Property YardUtilization As Double
    ReadOnly Property Report As TSR

    ReadOnly Property ClosingTerminalStatusReport As AutomatedTerminalStatusReport.TSRClass
    ReadOnly Property TerminalStatusReportsoftheDay As List(Of AutomatedTerminalStatusReport.TSRClass)

    Sub FormatReport()
    Sub RetrieveTerminalStatusReportsoftheDay()

End Interface
