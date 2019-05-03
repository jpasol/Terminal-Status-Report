Imports Terminal_Status_Report

Public Class TerminalStatusReport
    Implements ITerminalStatusReport

    Public Property TotalGroundSlotTEU As Integer Implements ITerminalStatusReport.TotalGroundSlotTEU
    Public Property StaticCapacityTEU As Integer Implements ITerminalStatusReport.StaticCapacityTEU
    Public Property TotalYardCapacityTEU As Integer Implements ITerminalStatusReport.TotalYardCapacityTEU
    Public Property MTDAverageGrossCraneProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossCraneProductivity
    Public Property MTDAverageGrossBerthProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossBerthProductivity
    Public Property MTDAverageGrossVesselProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossVesselProductivity
    Public Property MTDAverageNetCraneProductivity As Double Implements ITerminalStatusReport.MTDAverageNetCraneProductivity
    Public Property MTDAverageNetBerthProductivity As Double Implements ITerminalStatusReport.MTDAverageNetBerthProductivity
    Public Property MTDAverageNetVesselProductivity As Double Implements ITerminalStatusReport.MTDAverageNetVesselProductivity
    Public Property CraneDensity As Double Implements ITerminalStatusReport.CraneDensity
    Public Property AverageImportDwellTime As Double Implements ITerminalStatusReport.AverageImportDwellTime
    Public Property MTDImportDwellTime As Double Implements ITerminalStatusReport.MTDImportDwellTime
    Public Property YTDImportDwellTime As Double Implements ITerminalStatusReport.YTDImportDwellTime
    Public Property MTDExportDwellTime As Double Implements ITerminalStatusReport.MTDExportDwellTime
    Public Property YTDExportDwellTime As Double Implements ITerminalStatusReport.YTDExportDwellTime
    Public Property DailyTEUInByTrucks As Double Implements ITerminalStatusReport.DailyTEUInByTrucks
    Public Property DailyTEUOutByTrucks As Double Implements ITerminalStatusReport.DailyTEUOutByTrucks
    Public Property MTDTEUInByTrucks As Double Implements ITerminalStatusReport.MTDTEUInByTrucks
    Public Property MTDTEUOutByTrucks As Double Implements ITerminalStatusReport.MTDTEUOutByTrucks
    Public Property YTDTEUInByTrucks As Double Implements ITerminalStatusReport.YTDTEUInByTrucks
    Public Property YTDTEUOutByTrucks As Double Implements ITerminalStatusReport.YTDTEUOutByTrucks
    Public Property OverstayingManilaCargo As Double Implements ITerminalStatusReport.OverstayingManilaCargo
    Public Property TotalOverstayingCargo As Double Implements ITerminalStatusReport.TotalOverstayingCargo
    Public Property ImportFullTEU As Double Implements ITerminalStatusReport.ImportFullTEU
    Public Property ImportEmptyTEU As Double Implements ITerminalStatusReport.ImportEmptyTEU
    Public Property ExportFullTEU As Double Implements ITerminalStatusReport.ExportFullTEU
    Public Property ExportEmptyTEU As Double Implements ITerminalStatusReport.ExportEmptyTEU
    Public Property StorageEmptyTEU As Double Implements ITerminalStatusReport.StorageEmptyTEU
    Public Property TotalInYardTEU As Double Implements ITerminalStatusReport.TotalInYardTEU
    Public Property YardUtilization As Double Implements ITerminalStatusReport.YardUtilization

End Class
