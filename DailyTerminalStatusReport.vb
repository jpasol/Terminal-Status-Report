Imports AutomatedTerminalStatusReport
Imports CrystalDecisions.CrystalReports.Engine
Imports Terminal_Status_Report

Public Class DailyTerminalStatusReport
    Implements IDailyTerminalStatusReport

    Public Sub New(DailyTerminalStatusDate As String, ByRef OPConnection As ADODB.Connection)

        Me.dailyTSRDate = DailyTerminalStatusDate
        Me.OPConnection = OPConnection
        Me.TerminalStatusReportsoftheDay = New List(Of TSRClass)
        Me.Report = New TSR
        RetrieveTerminalStatusReports()

        With ClosingTerminalStatusReport
            TotalGroundSlotTEU = .TotalGroundSlotTEU
            StaticCapacityTEU = .StaticCapacityTEU
            TotalYardCapacityTEU = .TotalYardCapacityTEU
            MTDAverageGrossCraneProductivity = .MTDAverageGrossCraneProductivity
            MTDAverageGrossBerthProductivity = .MTDAverageGrossBerthProductivity
            MTDAverageGrossVesselProductivity = .MTDAverageGrossVesselProductivity
            MTDAverageNetCraneProductivity = .MTDAverageNetCraneProductivity
            MTDAverageNetBerthProductivity = .MTDAverageNetBerthProductivity
            MTDAverageNetVesselProductivity = .MTDAverageNetVesselProductivity
            AverageImportDwellTime = .AverageImportDwellTime
            MTDImportDwellTime = .MTDImportDwellTime
            YTDImportDwellTime = .YTDImportDwellTime
            MTDExportDwellTime = .MTDExportDwellTime
            YTDExportDwellTime = .YTDExportDwellTime
            DailyTEUInByTrucks = .DailyTEUInByTrucks
            DailyTEUOutByTrucks = .DailyTEUOutByTrucks
            MTDTEUInByTrucks = .MTDTEUInByTrucks
            MTDTEUOutByTrucks = .MTDTEUOutByTrucks
            YTDTEUInByTrucks = .YTDTEUInByTrucks
            YTDTEUOutByTrucks = .YTDTEUOutByTrucks
            OverstayingManilaCargo = .OverstayingManilaCargo
            TotalOverstayingCargo = .TotalOverstayingCargo
            ImportFullTEU = .ImportFullTEU
            ImportEmptyTEU = .ImportEmptyTEU
            ExportFullTEU = .ExportFullTEU
            ExportEmptyTEU = .ExportEmptyTEU
            StorageEmptyTEU = .StorageEmptyTEU
            TotalInYardTEU = .TotalInYardTEU
            YardUtilization = .YardUtilization

        End With

    End Sub

    Public Sub FormatReport() Implements IDailyTerminalStatusReport.FormatReport
        For Each tsr As TSRClass In TerminalStatusReportsoftheDay
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
                                                                                    created:= .TerminalStatusDate)
            End With
        Next
        Report.SetDataSource(TerminalStatusReportData)
        Report.SetParameterValue(0, "Daily")
    End Sub

    Private dailyTSRDate As String
    Private OPConnection As ADODB.Connection
    Private N4Connection As ADODB.Connection
    Private TerminalStatusReportData As New TerminalStatusReportData

    Public ReadOnly Property DailyTerminalStatusReportDate As String Implements IDailyTerminalStatusReport.DailyTerminalStatusReportDate
        Get
            With CDate(dailyTSRDate)
                Return .ToString("yyyy-MM-dd")
            End With
        End Get
    End Property

    Public ReadOnly Property TotalGroundSlotTEU As Integer Implements IDailyTerminalStatusReport.TotalGroundSlotTEU
    Public ReadOnly Property StaticCapacityTEU As Integer Implements IDailyTerminalStatusReport.StaticCapacityTEU
    Public ReadOnly Property TotalYardCapacityTEU As Integer Implements IDailyTerminalStatusReport.TotalYardCapacityTEU
    Public ReadOnly Property MTDAverageGrossCraneProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageGrossCraneProductivity
    Public ReadOnly Property MTDAverageGrossBerthProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageGrossBerthProductivity
    Public ReadOnly Property MTDAverageGrossVesselProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageGrossVesselProductivity
    Public ReadOnly Property MTDAverageNetCraneProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageNetCraneProductivity
    Public ReadOnly Property MTDAverageNetBerthProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageNetBerthProductivity
    Public ReadOnly Property MTDAverageNetVesselProductivity As Double Implements IDailyTerminalStatusReport.MTDAverageNetVesselProductivity
    Public ReadOnly Property AverageImportDwellTime As Double Implements IDailyTerminalStatusReport.AverageImportDwellTime
    Public ReadOnly Property MTDImportDwellTime As Double Implements IDailyTerminalStatusReport.MTDImportDwellTime
    Public ReadOnly Property YTDImportDwellTime As Double Implements IDailyTerminalStatusReport.YTDImportDwellTime
    Public ReadOnly Property MTDExportDwellTime As Double Implements IDailyTerminalStatusReport.MTDExportDwellTime
    Public ReadOnly Property YTDExportDwellTime As Double Implements IDailyTerminalStatusReport.YTDExportDwellTime
    Public ReadOnly Property DailyTEUInByTrucks As Double Implements IDailyTerminalStatusReport.DailyTEUInByTrucks
    Public ReadOnly Property DailyTEUOutByTrucks As Double Implements IDailyTerminalStatusReport.DailyTEUOutByTrucks
    Public ReadOnly Property MTDTEUInByTrucks As Double Implements IDailyTerminalStatusReport.MTDTEUInByTrucks
    Public ReadOnly Property MTDTEUOutByTrucks As Double Implements IDailyTerminalStatusReport.MTDTEUOutByTrucks
    Public ReadOnly Property YTDTEUInByTrucks As Double Implements IDailyTerminalStatusReport.YTDTEUInByTrucks
    Public ReadOnly Property YTDTEUOutByTrucks As Double Implements IDailyTerminalStatusReport.YTDTEUOutByTrucks
    Public ReadOnly Property OverstayingManilaCargo As Double Implements IDailyTerminalStatusReport.OverstayingManilaCargo
    Public ReadOnly Property TotalOverstayingCargo As Double Implements IDailyTerminalStatusReport.TotalOverstayingCargo
    Public ReadOnly Property ImportFullTEU As Double Implements IDailyTerminalStatusReport.ImportFullTEU
    Public ReadOnly Property ImportEmptyTEU As Double Implements IDailyTerminalStatusReport.ImportEmptyTEU
    Public ReadOnly Property ExportFullTEU As Double Implements IDailyTerminalStatusReport.ExportFullTEU
    Public ReadOnly Property ExportEmptyTEU As Double Implements IDailyTerminalStatusReport.ExportEmptyTEU
    Public ReadOnly Property StorageEmptyTEU As Double Implements IDailyTerminalStatusReport.StorageEmptyTEU
    Public ReadOnly Property TotalInYardTEU As Double Implements IDailyTerminalStatusReport.TotalInYardTEU
    Public ReadOnly Property YardUtilization As Double Implements IDailyTerminalStatusReport.YardUtilization
    Public ReadOnly Property TerminalStatusReportsoftheDay As List(Of TSRClass) Implements IDailyTerminalStatusReport.TerminalStatusReportsoftheDay
    Public ReadOnly Property ClosingTerminalStatusReport As TSRClass Implements IDailyTerminalStatusReport.ClosingTerminalStatusReport
        Get
            Return TerminalStatusReportsoftheDay.OrderByDescending(Function(tsr) tsr.TerminalStatusDate).First
        End Get
    End Property

    Public ReadOnly Property Report As TSR Implements IDailyTerminalStatusReport.Report

    Public Sub RetrieveTerminalStatusReports() Implements IDailyTerminalStatusReport.RetrieveTerminalStatusReportsoftheDay
        OPConnection.Open()
        With getDailyTerminalStatusDate()
            While Not .EOF
                TerminalStatusReportsoftheDay.Add(New TSRClass(.Fields("created").Value, N4Connection, OPConnection))
                .MoveNext()
            End While
        End With
        OPConnection.Close()
    End Sub

    Private Function getDailyTerminalStatusDate() As ADODB.Recordset
        Dim getDailyTerminalRecordset As New ADODB.Command
        getDailyTerminalRecordset.ActiveConnection = OPConnection
        getDailyTerminalRecordset.CommandText = $"
SELECT [created]
FROM [opreports].[dbo].[reports_tsr] WHERE (datepart(yy,created) = {CDate(DailyTerminalStatusReportDate).Year} and
datepart(mm,created) = {CDate(DailyTerminalStatusReportDate).Month} and
datepart(dd,created) = {CDate(DailyTerminalStatusReportDate).Day})

"
        Return getDailyTerminalRecordset.Execute
    End Function

End Class
