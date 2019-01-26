Imports Terminal_Status_Report
Imports ADODB
Imports AutomatedTerminalStatusReport

Public Class MonthlyTerminalStatusReport
    Implements IMonthlyTerminalStatusReport

    Public Sub New(TSRMonthDate As String, ByRef OPConnection As ADODB.Connection)
        Me.TerminalStatusReportMonthDate = TSRMonthDate
        TerminalStatusReportData = New TerminalStatusReportData
        Report = New TSR
        Me.N4Connection = N4Connection
        Me.OPConnection = OPConnection
        RetrieveDailyTerminalStatusReportsoftheMonth()

        With ClosingTerminalStatusReport
            Me.TotalGroundSlotTEU = .TotalGroundSlotTEU
            Me.StaticCapacityTEU = .StaticCapacityTEU
            Me.TotalYardCapacityTEU = .TotalYardCapacityTEU
            Me.ImportFullTEU = .ImportFullTEU
            Me.ImportEmptyTEU = .ImportEmptyTEU
            Me.ExportFullTEU = .ExportFullTEU
            Me.ExportEmptyTEU = .ExportEmptyTEU
            Me.StorageEmptyTEU = .StorageEmptyTEU
            Me.TotalInYardTEU = .TotalInYardTEU
            Me.YardUtilization = .YardUtilization
        End With
        With DailyTerminalStatusReports.AsEnumerable
            Me.MTDAverageGrossCraneProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossCraneProductivity)
            Me.MTDAverageGrossVesselProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossVesselProductivity)
            Me.MTDAverageGrossBerthProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossBerthProductivity)
            Me.MTDAverageNetCraneProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetCraneProductivity)
            Me.MTDAverageNetVesselProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetVesselProductivity)
            Me.MTDAverageNetBerthProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetBerthProductivity)
            Me.AverageImportDwellTime = .Average(Function(mtsr) mtsr.AverageImportDwellTime)
            Me.MTDImportDwellTime = .Average(Function(mtsr) mtsr.MTDImportDwellTime)
            Me.YTDImportDwellTime = .Average(Function(mtsr) mtsr.YTDImportDwellTime)
            Me.MTDExportDwellTime = .Average(Function(mtsr) mtsr.MTDExportDwellTime)
            Me.YTDImportDwellTime = .Average(Function(mtsr) mtsr.YTDImportDwellTime)
            Me.OverstayingManilaCargo = .Max(Function(mtsr) mtsr.OverstayingManilaCargo)
            Me.TotalOverstayingCargo = .Max(Function(mtsr) mtsr.TotalOverstayingCargo)
        End With

    End Sub

    Public Sub RetrieveDailyTerminalStatusReportsoftheMonth() Implements IMonthlyTerminalStatusReport.RetrieveDailyTerminalStatusReportsoftheMonth

        With CDate(TerminalStatusReportMonthDate)
            For day As Integer = 1 To Date.DaysInMonth(.Year, .Month)
                Try
                    Dim reportDate As New Date(.Year, .Month, day)
                    Dim formattedDate As String = Format(reportDate, "MM/dd/yyyy")
                    DailyTerminalStatusReports.Add(New DailyTerminalStatusReport(formattedDate, OPConnection))
                Catch
                End Try
            Next
        End With
    End Sub

    Public Sub FormatReport() Implements IMonthlyTerminalStatusReport.FormatReport
        For Each tsr As DailyTerminalStatusReport In DailyTerminalStatusReports
            With tsr
                TerminalStatusReportData.terminalStatusReports.AddterminalStatusReportsRow(groundslot:= .TotalGroundSlotTEU,
                                                                                    staticcapacity:= .StaticCapacityTEU,
                                                                                    totalcapacity:= .TotalYardCapacityTEU,
                                                                                    grosscrane:= .MTDAverageGrossCraneProductivity,
                                                                                    grossvessel:= .MTDAverageGrossVesselProductivity,
                                                                                    grossberth:= .MTDAverageGrossBerthProductivity,
                                                                                    netcrane:= .MTDAverageNetCraneProductivity,
                                                                                    netvessel:= .MTDAverageNetVesselProductivity,
                                                                                    netberth:= .MTDAverageNetBerthProductivity,
                                                                                    ave_importdwell:= .AverageImportDwellTime,
                                                                                    mtd_importdwell:= .MTDImportDwellTime,
                                                                                    mtd_exportdwell:= .MTDExportDwellTime,
                                                                                    ytd_importdwell:= .YTDImportDwellTime,
                                                                                    ytd_exportdwell:= .YTDExportDwellTime,
                                                                                    daily_trucksin:= .DailyTEUInByTrucks,
                                                                                    daily_trucksout:= .DailyTEUOutByTrucks,
                                                                                    mtd_trucksin:= .MTDTEUInByTrucks,
                                                                                    mtd_trucksout:= .MTDTEUOutByTrucks,
                                                                                    ytd_trucksin:= .YTDTEUInByTrucks,
                                                                                    ytd_trucksout:= .YTDTEUOutByTrucks,
                                                                                    mnl_overstaying:= .OverstayingManilaCargo,
                                                                                    total_overstaying:= .TotalOverstayingCargo,
                                                                                    importfull:= .ImportFullTEU,
                                                                                    importempty:= .ImportEmptyTEU,
                                                                                    exportfull:= .ExportFullTEU,
                                                                                    exportempty:= .ExportEmptyTEU,
                                                                                    storageempty:= .StorageEmptyTEU,
                                                                                    yard_total:= .TotalInYardTEU,
                                                                                    yard_utilization:= .YardUtilization,
                                                                                    created:= .DailyTerminalStatusReportDate)
            End With
        Next

        Report.SetDataSource(TerminalStatusReportData)
        Report.SetParameterValue(0, "Monthly")
    End Sub

    Private N4Connection As ADODB.Connection
    Private OPConnection As ADODB.Connection
    Private TerminalStatusReportData As New TerminalStatusReportData

    Public ReadOnly Property TerminalStatusReportMonthDate As String Implements IMonthlyTerminalStatusReport.TerminalStatusReportMonthDate

    Public ReadOnly Property TotalGroundSlotTEU As Integer Implements IMonthlyTerminalStatusReport.TotalGroundSlotTEU
    Public ReadOnly Property StaticCapacityTEU As Integer Implements IMonthlyTerminalStatusReport.StaticCapacityTEU
    Public ReadOnly Property TotalYardCapacityTEU As Integer Implements IMonthlyTerminalStatusReport.TotalYardCapacityTEU
    Public ReadOnly Property MTDAverageGrossCraneProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageGrossCraneProductivity
    Public ReadOnly Property MTDAverageGrossBerthProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageGrossBerthProductivity
    Public ReadOnly Property MTDAverageGrossVesselProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageGrossVesselProductivity
    Public ReadOnly Property MTDAverageNetCraneProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageNetCraneProductivity
    Public ReadOnly Property MTDAverageNetBerthProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageNetBerthProductivity
    Public ReadOnly Property MTDAverageNetVesselProductivity As Double Implements IMonthlyTerminalStatusReport.MTDAverageNetVesselProductivity
    Public ReadOnly Property AverageImportDwellTime As Double Implements IMonthlyTerminalStatusReport.AverageImportDwellTime
    Public ReadOnly Property MTDImportDwellTime As Double Implements IMonthlyTerminalStatusReport.MTDImportDwellTime
    Public ReadOnly Property YTDImportDwellTime As Double Implements IMonthlyTerminalStatusReport.YTDImportDwellTime
    Public ReadOnly Property MTDExportDwellTime As Double Implements IMonthlyTerminalStatusReport.MTDExportDwellTime
    Public ReadOnly Property YTDExportDwellTime As Double Implements IMonthlyTerminalStatusReport.YTDExportDwellTime
    Public ReadOnly Property DailyTEUInByTrucks As Double Implements IMonthlyTerminalStatusReport.DailyTEUInByTrucks
    Public ReadOnly Property DailyTEUOutByTrucks As Double Implements IMonthlyTerminalStatusReport.DailyTEUOutByTrucks
    Public ReadOnly Property MTDTEUInByTrucks As Double Implements IMonthlyTerminalStatusReport.MTDTEUInByTrucks
    Public ReadOnly Property MTDTEUOutByTrucks As Double Implements IMonthlyTerminalStatusReport.MTDTEUOutByTrucks
    Public ReadOnly Property YTDTEUInByTrucks As Double Implements IMonthlyTerminalStatusReport.YTDTEUInByTrucks
    Public ReadOnly Property YTDTEUOutByTrucks As Double Implements IMonthlyTerminalStatusReport.YTDTEUOutByTrucks
    Public ReadOnly Property OverstayingManilaCargo As Double Implements IMonthlyTerminalStatusReport.OverstayingManilaCargo
    Public ReadOnly Property TotalOverstayingCargo As Double Implements IMonthlyTerminalStatusReport.TotalOverstayingCargo
    Public ReadOnly Property ImportFullTEU As Double Implements IMonthlyTerminalStatusReport.ImportFullTEU
    Public ReadOnly Property ImportEmptyTEU As Double Implements IMonthlyTerminalStatusReport.ImportEmptyTEU
    Public ReadOnly Property ExportFullTEU As Double Implements IMonthlyTerminalStatusReport.ExportFullTEU
    Public ReadOnly Property ExportEmptyTEU As Double Implements IMonthlyTerminalStatusReport.ExportEmptyTEU
    Public ReadOnly Property StorageEmptyTEU As Double Implements IMonthlyTerminalStatusReport.StorageEmptyTEU
    Public ReadOnly Property TotalInYardTEU As Double Implements IMonthlyTerminalStatusReport.TotalInYardTEU
    Public ReadOnly Property YardUtilization As Double Implements IMonthlyTerminalStatusReport.YardUtilization

    Public ReadOnly Property DailyTerminalStatusReports As New List(Of DailyTerminalStatusReport) Implements IMonthlyTerminalStatusReport.DailyTerminalStatusReports

    Public ReadOnly Property ClosingTerminalStatusReport As DailyTerminalStatusReport Implements IMonthlyTerminalStatusReport.ClosingTerminalStatusReport
        Get
            Return DailyTerminalStatusReports.OrderByDescending(Function(tsr) CDate(tsr.DailyTerminalStatusReportDate)).First
        End Get
    End Property

    Public Property Report As TSR Implements IMonthlyTerminalStatusReport.Report
End Class
