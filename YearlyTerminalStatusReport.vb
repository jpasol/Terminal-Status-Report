Imports ADODB
Imports Terminal_Status_Report
Imports Reports

Public Class YearlyTerminalStatusReport
    Inherits TerminalStatusReport
    Implements IYearlyTerminalStatusReport

    Public Sub New(Year As String)
        Dim connections As New Connections

        Me.Year = Year
        Me.Report = New TSR
        Me.N4Connection = connections.N4Connection
        Me.OPConnection = connections.OPConnection
        RetrieveTerminalStatusReports()
        Calculate()

    End Sub

    Private Sub Calculate() Implements IYearlyTerminalStatusReport.Calculate
        With ClosingTerminalStatusReport
            Me.TotalGroundSlotTEU = .TotalGroundSlotTEU
            Me.StaticCapacityTEU = .StaticCapacityTEU
            Me.TotalYardCapacityTEU = .TotalYardCapacityTEU
            Me.OverstayingManilaCargo = .OverstayingManilaCargo
            Me.TotalOverstayingCargo = .TotalOverstayingCargo
            Me.ImportFullTEU = .ImportFullTEU
            Me.ImportEmptyTEU = .ImportEmptyTEU
            Me.ExportFullTEU = .ExportFullTEU
            Me.ExportEmptyTEU = .ExportEmptyTEU
            Me.StorageEmptyTEU = .StorageEmptyTEU
            Me.TotalInYardTEU = .TotalInYardTEU

        End With
        With TerminalStatusReports.AsEnumerable
            Me.MTDAverageGrossCraneProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossCraneProductivity)
            Me.MTDAverageGrossVesselProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossVesselProductivity)
            Me.MTDAverageGrossBerthProductivity = .Average(Function(mtsr) mtsr.MTDAverageGrossBerthProductivity)
            Me.MTDAverageNetCraneProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetCraneProductivity)
            Me.MTDAverageNetVesselProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetVesselProductivity)
            Me.MTDAverageNetBerthProductivity = .Average(Function(mtsr) mtsr.MTDAverageNetBerthProductivity)
            Me.CraneDensity = .Average(Function(mtsr) mtsr.CraneDensity)
            Me.AverageImportDwellTime = .Average(Function(mtsr) mtsr.AverageImportDwellTime)
            Me.MTDImportDwellTime = .Average(Function(mtsr) mtsr.MTDImportDwellTime)
            Me.YTDImportDwellTime = .Average(Function(mtsr) mtsr.YTDImportDwellTime)
            Me.MTDExportDwellTime = .Average(Function(mtsr) mtsr.MTDExportDwellTime)
            Me.YTDImportDwellTime = .Average(Function(mtsr) mtsr.YTDImportDwellTime)
            Me.YardUtilization = .Average(Function(dtsr) dtsr.YardUtilization)
        End With
    End Sub

    Public ReadOnly Property Year As Integer Implements IYearlyTerminalStatusReport.Year
    Private TerminalStatusReportData As New TerminalStatusReportData
    Public Property OPConnection As Connection Implements IYearlyTerminalStatusReport.OPConnection
    Public Property N4Connection As Connection Implements IYearlyTerminalStatusReport.N4Connection
    Public Property TerminalStatusReports As New List(Of MonthlyTerminalStatusReport) Implements IYearlyTerminalStatusReport.TerminalStatusReports
    Public ReadOnly Property ClosingTerminalStatusReport As MonthlyTerminalStatusReport Implements IYearlyTerminalStatusReport.ClosingTerminalStatusReport
        Get
            Return TerminalStatusReports.AsEnumerable.OrderByDescending(Function(mtsr) CDate(mtsr.TerminalStatusReportMonthDate)).First
        End Get
    End Property

    Public Property Report As TSR Implements IYearlyTerminalStatusReport.Report

    Public Sub RetrieveTerminalStatusReports() Implements IYearlyTerminalStatusReport.RetrieveTerminalStatusReports
        For Month As Integer = 1 To 12
            Try
                TerminalStatusReports.Add(New MonthlyTerminalStatusReport($"{Month}/{Year}"))
            Catch
            End Try
        Next
    End Sub

    Public Sub FormatReport() Implements IYearlyTerminalStatusReport.FormatReport
        For Each tsr As MonthlyTerminalStatusReport In TerminalStatusReports
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
                                                                                    created:= .TerminalStatusReportMonthDate)
            End With
        Next

        Report.SetDataSource(TerminalStatusReportData)
        Report.SetParameterValue(0, "Yearly")
    End Sub
End Class
