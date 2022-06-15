Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Public Class frmUrinalysis
   
#Region "Variables"
    Public myFormStatus As Integer
    Public PatientNo As String
    Public soperation As Integer
    Public myResult As Integer
    Public requestdetailno As Long
    Public status As Integer
    Public IsSelected As Boolean
    Public Islock As Boolean
    Public LabID, dtResult, dtLabResultDetails As New DataTable()
    Dim dtHospitalInfo As New DataTable()
    '*******************Design Mode**********************
    Public Const WM_NCLBUTTONDOWN = &HA1
    Public Const HTCAPTION = 2
    Public enabl As Boolean = True

    Dim dragging As Boolean
    Dim startX As Integer
    Dim startY As Integer

    Dim x As Integer
    Dim _mouseDown As Boolean = False
    'db variables
    Dim LabdetailID As Long
    Dim normvalues As String
    Dim visiblecontrols As Byte
    Dim locationx As Long
    Dim locationy As Long
    Dim txtheight As Long
    Dim txtwidth As Long
    Dim isdrag As Byte
    Dim dtmedtech As New DataTable
    Public isSave As Boolean
    Public isCancel As Boolean

    Dim LocX As Double
    Dim LocY As Double
    'Dim Idriz as String
    'local variables
    Dim UcolorID, UAppearanceID, UReactionsID, UspecificGravID, UAlbuminID,
        UsugarID, UKetoneID, UB_othersID, UPusCellsID, URBCID, UepithelialCellsID,
        UMucusThreadsID, UAmorphousUratesID, UUricAcidID, UCalcOxalateID, U3PhosphateID,
        UCoareID, UFineID, UCrystalOthersID, UyeastCellsID, UCast_OthersID,
        UPhysicalExaminID, UChem_ExminID, UMicroExaminID, UCastsID, UCystalsID,
        UBacteriaID As Long

    Public dtUrinalysis As New DataTable
    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
    End Enum

    Dim Admission As New clsAdmission
#End Region
    
#Region "Methods"
    Public Sub LockFields()
        Dim cControl As Control
        For Each cControl In Me.Controls
            If (TypeOf cControl Is Panel) Then
                cControl.Enabled = False
            End If
        Next cControl
    End Sub
    Private Sub ChangeTextboxForeColor(ByVal txtName As TextBox, ByVal SelectedColor As System.Drawing.Color)
        With txtName
            .BackColor = .BackColor
            .ForeColor = SelectedColor
        End With
    End Sub
#Region "Load Urinalysis"
    Public Sub loadUrinalysis()
        LabID = clsLaboratoryResult.getLaboratoryID(requestdetailno, "2", 6)
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address").ToString()
        Me.lablTelNo.Text = dtHospitalInfo.Rows(0).Item("Telephone").ToString()
        Try
            ' Image.FromFile(dtHospitalInfo.Rows(0).Item("hospitallogo").ToString())
            Dim tempphoto As Byte() = dtHospitalInfo.Rows(0).Item("hospitallogo")
            If IsDBNull(dtHospitalInfo.Rows(0).Item("hospitallogo")) Or tempphoto.Length = 0 Then
                pctrLogo.Image = Nothing
            Else
                pctrLogo.Image = Utility.convertImage(dtHospitalInfo.Rows(0).Item("hospitallogo")) 'image here
            End If
        Catch ex As Exception
        End Try
        If IsSelected = True Then
            txtBoxProperties(True)
            Me.txtPathologist.DataSource = clsLaboratoryResult.getPathologist("777")
            Me.txtPathologist.DisplayMember = "radiologist"
            Me.txtPathologist.ValueMember = "employeeid"
            Me.txtPathologist.SelectedIndex = 0
            Me.cmbMedtech.DataSource = clsLaboratoryResult.getPathologist("666")
            Me.cmbMedtech.DisplayMember = "radiologist"
            Me.cmbMedtech.ValueMember = "employeeid"
            Me.cmbMedtech.SelectedIndex = 0
            dtResult = clsLaboratoryResult.getRadiologyResultDetails(requestdetailno, myResult)

            Admission.AdmissionID = dtResult.Rows(0).Item("admissionid").ToString
            Admission.patientname = dtResult.Rows(0).Item("patient").ToString 
            Me.txtPatientName.Text = dtResult.Rows(0).Item("patient").ToString()
            If dtResult.Rows(0).Item("hospitalno").ToString = "" Then
                Me.txtHospitalNo.Text = Nothing
            Else
                Me.txtHospitalNo.Text = Utility.formatHospitalNumber(dtResult.Rows(0).Item("hospitalno").ToString)
            End If
            Me.txtAge.Text = dtResult.Rows(0).Item("age").ToString
            Me.txtGender.Text = dtResult.Rows(0).Item("gender").ToString
            Me.txtRoomno.Text = dtResult.Rows(0).Item("roomno").ToString
            Me.txtLabno.Text = dtResult.Rows(0).Item("labexaminationno").ToString
            If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
                'LockFields(Islock)
                If Islock = True Then
                    LockFields()
                Else
                    isEnabledTop(False)
                End If

                dtmedtech = clsLaboratoryResult.getMedtech(requestdetailno)

                Me.cmbMedtech.Text = dtmedtech.Rows(0).Item("medtechnologist").ToString
                Me.txtPathologist.Text = dtResult.Rows(0).Item("pathologist").ToString
                dtLabResultDetails = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, LabID.Rows(0)(0).ToString(), 2, 1)
                dtLabResultDetails.PrimaryKey = New DataColumn() {dtLabResultDetails.Columns("description")}
                Dim dr As DataRow

                dr = dtLabResultDetails.Rows.Find("COLOR")
                If dr IsNot Nothing Then
                    Me.txtColor.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("APPEARANCE")
                If dr IsNot Nothing Then
                    Me.txtAppearance.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("REACTIONS")
                If dr IsNot Nothing Then
                    Me.txtReactions.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("SPECIFIC GRAVITY")
                If dr IsNot Nothing Then
                    Me.txtSpecGrav.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("PUS CELLS")
                If dr IsNot Nothing Then
                    Me.txtPussCells.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("RBC")
                If dr IsNot Nothing Then
                    Me.txtRBC.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("EPITHELIAL CELLS")
                If dr IsNot Nothing Then
                    Me.txtEpithCells.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("MUCUS THREADS")
                If dr IsNot Nothing Then
                    Me.txtMucthread.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("COARE")
                If dr IsNot Nothing Then
                    Me.txtCoarse.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("FINE")
                If dr IsNot Nothing Then
                    Me.txtFine.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("CAST_OTHERS")
                If dr IsNot Nothing Then
                    Me.txtCastOthers.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("ALBUMIN")
                If dr IsNot Nothing Then
                    Me.txtAlbumin.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("SUGAR")
                If dr IsNot Nothing Then
                    Me.txtSugar.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("KETONE")
                If dr IsNot Nothing Then
                    Me.txtKetone.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("CRYSTAL_OTHERS")
                If dr IsNot Nothing Then
                    Me.txtChemothers.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("AMORPHOUS URATES")
                If dr IsNot Nothing Then
                    Me.txtAmorphousUrates.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("URIC ACID")
                If dr IsNot Nothing Then
                    Me.txtUricAcid.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("CALCIUM OXALATE")
                If dr IsNot Nothing Then
                    Me.txtCalcOxalte.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("TRIPLE PHOSPHATE")
                If dr IsNot Nothing Then
                    Me.txtTriplePhosphate.Text = dr.Item("result").ToString
                End If
                dr = dtLabResultDetails.Rows.Find("YEAST CELLS")
                If dr IsNot Nothing Then
                    Me.txtYeast.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("B_OTHERS")
                If dr IsNot Nothing Then
                    Me.txtBacteriaOthers.Text = dr.Item("result").ToString
                End If

            End If

            LoadDesign()
            If myFormStatus = enFormStatus.browsing Or isCancel Then
                isEnabled()
            End If
        Else
            LoadDesign()
            Me.Label1.Visible = True
            isEnabledTop(False)
        End If

    End Sub
    Private Sub LoadDesign()
        dtUrinalysis = clsExamination.getLabdetails("2")
        dtUrinalysis.PrimaryKey = New DataColumn() {dtUrinalysis.Columns("description")}
        Dim dr As DataRow
        dr = dtUrinalysis.Rows.Find("COLOR")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UcolorID = dr.Item("laboratorydetailsid").ToString
                pnlColor.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlColor.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                UcolorID = dr.Item("laboratorydetailsid").ToString
                pnlColor.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlColor.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("APPEARANCE")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UAppearanceID = dr.Item("laboratorydetailsid").ToString
                pnlAppearance.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlAppearance.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                UAppearanceID = dr.Item("laboratorydetailsid").ToString
                pnlAppearance.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlAppearance.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("REACTIONS")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Appearance Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UReactionsID = dr.Item("laboratorydetailsid").ToString
                pnlReactions.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlReactions.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                UReactionsID = dr.Item("laboratorydetailsid").ToString
                pnlReactions.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlReactions.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("SPECIFIC GRAVITY")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Specific Gravity Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UspecificGravID = dr.Item("laboratorydetailsid").ToString
                pnlSpecGravity.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlSpecGravity.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                UspecificGravID = dr.Item("laboratorydetailsid").ToString
                pnlSpecGravity.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlSpecGravity.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("ALBUMIN")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Albumin Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UAlbuminID = dr.Item("laboratorydetailsid").ToString
                pnlAlbumin.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlAlbumin.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlAlbumin.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UAlbuminID = dr.Item("laboratorydetailsid").ToString
                pnlAlbumin.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("SUGAR")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Sugar Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UsugarID = dr.Item("laboratorydetailsid").ToString
                pnlSugar.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlSugar.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlSugar.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UsugarID = dr.Item("laboratorydetailsid").ToString
                pnlSugar.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("KETONE")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Ketone Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UKetoneID = dr.Item("laboratorydetailsid").ToString
                pnlKetone.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlKetone.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlKetone.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UKetoneID = dr.Item("laboratorydetailsid").ToString
                pnlKetone.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("B_OTHERS")
        If dr IsNot Nothing Then
            'Me.txtColor.Text = dr.Item("result").ToString

            'Panel Chem Others Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UB_othersID = dr.Item("laboratorydetailsid").ToString
                pnlChemOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlChemOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlChemOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UB_othersID = dr.Item("laboratorydetailsid").ToString
                pnlChemOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If


        dr = dtUrinalysis.Rows.Find("PUS CELLS")
        If dr IsNot Nothing Then
            'Panel Puss Cells Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UPusCellsID = dr.Item("laboratorydetailsid").ToString
                pnlPusCells.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlPusCells.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlPusCells.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UPusCellsID = dr.Item("laboratorydetailsid").ToString
                pnlPusCells.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("RBC")
        If dr IsNot Nothing Then

            'Panel RBC Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                URBCID = dr.Item("laboratorydetailsid").ToString
                pnlRBC.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlRBC.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlRBC.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                URBCID = dr.Item("laboratorydetailsid").ToString
                pnlRBC.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("EPITHELIAL CELLS")
        If dr IsNot Nothing Then
            'Panel EPITHELIAL CELLS Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UepithelialCellsID = dr.Item("laboratorydetailsid").ToString
                pnlEpithCells.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlEpithCells.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlEpithCells.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UepithelialCellsID = dr.Item("laboratorydetailsid").ToString
                pnlEpithCells.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("MUCUS THREADS")
        If dr IsNot Nothing Then
            'Panel MUCUS THREADS Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UMucusThreadsID = dr.Item("laboratorydetailsid").ToString
                pnlMucThread.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlMucThread.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlMucThread.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UMucusThreadsID = dr.Item("laboratorydetailsid").ToString
                pnlMucThread.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("AMORPHOUS URATES")
        If dr IsNot Nothing Then
            'Panel AMORPHOUS URATES Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UAmorphousUratesID = dr.Item("laboratorydetailsid").ToString
                pnlAmorUrates.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlAmorUrates.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlAmorUrates.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UAmorphousUratesID = dr.Item("laboratorydetailsid").ToString
                pnlAmorUrates.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("URIC ACID")
        If dr IsNot Nothing Then
            'Panel AMORPHOUS URATES Property
            'Panel URIC ACID Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UUricAcidID = dr.Item("laboratorydetailsid").ToString
                pnlUricAcid.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlUricAcid.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlUricAcid.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UUricAcidID = dr.Item("laboratorydetailsid").ToString
                pnlUricAcid.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("CALCIUM OXALATE")
        If dr IsNot Nothing Then
            'Panel CALCIUM OXALATE Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCalcOxalateID = dr.Item("laboratorydetailsid").ToString
                pnlCalciumOxalate.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCalciumOxalate.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCalciumOxalate.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCalcOxalateID = dr.Item("laboratorydetailsid").ToString
                pnlCalciumOxalate.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If


        dr = dtUrinalysis.Rows.Find("TRIPLE PHOSPHATE")
        If dr IsNot Nothing Then
            'Panel TRIPLE PHOSPHATE Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                U3PhosphateID = dr.Item("laboratorydetailsid").ToString
                pnlTriplePhospate.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlTriplePhospate.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlTriplePhospate.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                U3PhosphateID = dr.Item("laboratorydetailsid").ToString
                pnlTriplePhospate.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("COARE")
        If dr IsNot Nothing Then
            'Panel COARSE Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCoareID = dr.Item("laboratorydetailsid").ToString
                pnlCoarse.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCoarse.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCoarse.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCoareID = dr.Item("laboratorydetailsid").ToString
                pnlCoarse.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("FINE")
        If dr IsNot Nothing Then
            'Panel FINE Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UFineID = dr.Item("laboratorydetailsid").ToString
                pnlFine.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlFine.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlFine.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UFineID = dr.Item("laboratorydetailsid").ToString
                pnlFine.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If


        dr = dtUrinalysis.Rows.Find("CRYSTAL_OTHERS")
        If dr IsNot Nothing Then
            'Panel Bacteria_Others Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCrystalOthersID = dr.Item("laboratorydetailsid").ToString
                pnlBacteriaOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlBacteriaOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlBacteriaOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCrystalOthersID = dr.Item("laboratorydetailsid").ToString
                pnlBacteriaOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If


        dr = dtUrinalysis.Rows.Find("YEAST CELLS")
        If dr IsNot Nothing Then
            'Panel YEAST CELLS Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UyeastCellsID = dr.Item("laboratorydetailsid").ToString
                pnlYeast.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlYeast.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlYeast.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UyeastCellsID = dr.Item("laboratorydetailsid").ToString
                pnlYeast.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("CAST_OTHERS")
        If dr IsNot Nothing Then
            'Panel CAST_OTHERS Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCast_OthersID = dr.Item("laboratorydetailsid").ToString
                pnlCastOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCastOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCastOthers.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCast_OthersID = dr.Item("laboratorydetailsid").ToString
                pnlCastOthers.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("PHYSICAL_EXAMIN")
        If dr IsNot Nothing Then
            '  Panel(PHYSICAL_EXAMIN) 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UPhysicalExaminID = dr.Item("laboratorydetailsid").ToString
                pnlPhysicalExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlPhysicalExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlPhysicalExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UPhysicalExaminID = dr.Item("laboratorydetailsid").ToString
                pnlPhysicalExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If


        dr = dtUrinalysis.Rows.Find("CHEM_EXAMIN")
        If dr IsNot Nothing Then
            'Panel CHEM_EXAMIN 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UChem_ExminID = dr.Item("laboratorydetailsid").ToString
                pnlChemExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlChemExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlChemExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UChem_ExminID = dr.Item("laboratorydetailsid").ToString
                pnlChemExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("MICROSCOPIC_EXAMIN")
        If dr IsNot Nothing Then
            'Panel MICROSCOPIC_EXAMIN 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UMicroExaminID = dr.Item("laboratorydetailsid").ToString
                pnlMicroExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlMicroExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlMicroExam.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UMicroExaminID = dr.Item("laboratorydetailsid").ToString
                pnlMicroExam.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtUrinalysis.Rows.Find("CASTS")
        If dr IsNot Nothing Then
            'Panel CASTS 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCastsID = dr.Item("laboratorydetailsid").ToString
                pnlCastsUrinalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCastsUrinalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCastsUrinalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCastsID = dr.Item("laboratorydetailsid").ToString
                pnlCastsUrinalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtUrinalysis.Rows.Find("CRYSTALS")
        If dr IsNot Nothing Then
            'Panel CRYSTALS 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UCystalsID = dr.Item("laboratorydetailsid").ToString
                pnlCrystals.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCrystals.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCrystals.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UCystalsID = dr.Item("laboratorydetailsid").ToString
                pnlCrystals.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If


        dr = dtUrinalysis.Rows.Find("BACTERIA")
        If dr IsNot Nothing Then
            'Panel BACTERIA 'label Property
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                UBacteriaID = dr.Item("laboratorydetailsid").ToString
                pnlBacteria.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlBacteria.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlBacteria.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                UBacteriaID = dr.Item("laboratorydetailsid").ToString
                pnlBacteria.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If
        '***********************End of Properties********************************* IDRIZ
    End Sub
#End Region
#Region "Printing"

    'Call in Printing
    Public Sub DisplayPrintPreview()
        DisplayPrintPDF()
        dlgPrintPreview.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 579) 'Updates
        dlgPrintPreview.PrintPreviewControl.Zoom = 1.0
        dlgPrintPreview.WindowState = FormWindowState.Maximized
        dlgPrintPreview.ShowDialog()

    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_Urinalysis_" & requestdetailno & ".jpg"
        Dim destfolder As String = "\documents\" & Admission.AdmissionID
        Dim destfile As String = destfolder & "\" & filename


        If Not Directory.Exists(gDocumentLocationEMR & destfolder) Then
            Directory.CreateDirectory(gDocumentLocationEMR & destfolder)
        End If
        If File.Exists(gDocumentLocationEMR & destfile) Then
            Exit Sub
        End If
        GetFormImage(True).Save(gDocumentLocationEMR & destfile, ImageFormat.Jpeg)

        Dim odocuments As New clsadmissiondocuments
        Dim dtadmissiondocuments As DataTable = createDataTable()

        dtadmissiondocuments.Rows.Add(Admission.AdmissionID,
                                                      requestdetailno,
                                                      destfile,
                                                      Path.GetFileName(destfile),
                                                      "",
                                                      "RadLab",
                                                      userid,
                                                      Utility.GetServerDate,
                                                      1,
                                                      False
                                                      )

        If dtadmissiondocuments.Rows.Count > 0 Then
            Call odocuments.saveAdmissionDocuments(dtadmissiondocuments)
            dtadmissiondocuments.Rows.Clear()
        End If
    End Sub
    Private Function GetFormImage(ByVal include_borders As Boolean) As Bitmap
        ' Make the bitmap.
        Dim wid As Integer = Me.Width
        Dim hgt As Integer = Me.Height
        Dim bm As New Bitmap(wid, hgt)
        ' Draw the form onto the bitmap.
        Me.DrawToBitmap(bm, New Rectangle(0, 0, wid, hgt))
        ' Make a smaller bitmap without borders.
        wid = Me.ClientSize.Width
        hgt = Me.ClientSize.Height
        Dim bm2 As New Bitmap(wid, hgt)
        ' Get the offset from the window's corner to its client
        ' area's corner.
        Dim pt As New Point(0, 0)
        pt = PointToScreen(pt)
        Dim dx As Integer = pt.X - Me.Left
        Dim dy As Integer = pt.Y - Me.Top
        ' Copy the part of the original bitmap that we want
        ' into the bitmap.
        Dim gr As Graphics = Graphics.FromImage(bm2)
        gr.DrawImage(bm, 0, 0, New Rectangle(dx, dy, wid, hgt), GraphicsUnit.Pixel)
        Return bm
    End Function
    Private Function createDataTable() As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add(New DataColumn("[admissionid]", GetType(Integer)))
            .Add(New DataColumn("[documentcode]", GetType(String)))
            .Add(New DataColumn("[documentlocation]", GetType(String)))
            .Add(New DataColumn("[documentname]", GetType(String)))
            .Add(New DataColumn("[documenturl]", GetType(String)))
            .Add(New DataColumn("[documenttype]", GetType(String)))
            .Add(New DataColumn("createdbyid", GetType(Integer)))
            .Add(New DataColumn("datecreated", GetType(Date)))
            .Add(New DataColumn("[uploadsequence]", GetType(Integer)))
            .Add(New DataColumn("[isuploaded]", GetType(Boolean)))
        End With
        Return dt
    End Function
    Private Sub UrinalysisPrintDocu_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles UrinalysisPrintDocu.PrintPage
        dtUrinalysis = clsExamination.getLabdetails("2")

        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Center
        Dim txtfnt As New Font("Times New Roman", 10)
        Dim txtfntheader As New Font("Times New Roman", 11, FontStyle.Bold)
        Dim txtfnt1 As New Font("Times New Roman", 6.75)
        Dim txtlabs As New Font("Times New Roman", 8)
        Dim flblLabNo As New Font("Times New Roman", 11, FontStyle.Underline) 'Updates begin here *********IDRIZ
        e.Graphics.DrawLine(Pens.Black, LineBorder.X1, LineBorder.Y1, _
                             LineBorder.X2, LineBorder.Y2)

        Dim sngCenterPage1 As Single
        sngCenterPage1 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblUrinalysis.Text, Me.lblUrinalysis.Font).Width / 2) 'Updates begin here *********IDRIZ
        e.Graphics.DrawString(Me.lblUrinalysis.Text, Me.lblUrinalysis.Font, Brushes.Black, sngCenterPage1, 80)

        Dim sngCenterPage2 As Single
        sngCenterPage2 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblHeader.Text, Me.lblHeader.Font).Width / 2) 'Updates begin here *********IDRIZ
        e.Graphics.DrawString(Me.lblHeader.Text, lblHeader.Font, Brushes.Black, sngCenterPage2, 6)


        Dim sngCenterPage3 As Single
        sngCenterPage3 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblAddress.Text, Me.lblAddress.Font).Width / 2)
        e.Graphics.DrawString(Me.lblAddress.Text, lblAddress.Font, Brushes.Black, sngCenterPage3, 20) 'Updates begin here *********IDRIZ

        Dim sngCenterPage4 As Single
        sngCenterPage4 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lablTelNo.Text, Me.lablTelNo.Font).Width / 2)
        e.Graphics.DrawString(Me.lablTelNo.Text, lablTelNo.Font, Brushes.Black, sngCenterPage4, 35) ' updates


        e.Graphics.DrawImage(Me.pctrLogo.Image, Me.pctrLogo.Location.X, Me.pctrLogo.Location.Y, 94, 88) 'Updates


        e.Graphics.DrawString(Me.lblpatientid.Text, Font, Brushes.Black, lblpatientid.Location.X, lblpatientid.Location.Y)
        e.Graphics.DrawString(Me.txtPatientName.Text, flblLabNo, Brushes.Black, txtPatientName.Location.X, txtPatientName.Location.Y)

        'e.Graphics.DrawString(Me.lblPatientname.Text, Font, Brushes.Black, lblPatientname.Location.X, lblPatientname.Location.Y)
        e.Graphics.DrawString(Me.txtHospitalNo.Text, flblLabNo, Brushes.Black, txtHospitalNo.Location.X, txtHospitalNo.Location.Y)

        e.Graphics.DrawString(Me.lblAge.Text, Font, Brushes.Black, lblAge.Location.X, lblAge.Location.Y)
        e.Graphics.DrawString(Me.txtAge.Text, flblLabNo, Brushes.Black, txtAge.Location.X, txtAge.Location.Y)

        e.Graphics.DrawString(Me.lblGender.Text, Font, Brushes.Black, lblGender.Location.X, lblGender.Location.Y)
        e.Graphics.DrawString(Me.txtGender.Text, flblLabNo, Brushes.Black, txtGender.Location.X, txtGender.Location.Y)

        e.Graphics.DrawString(Me.lblLabNo.Text, Font, Brushes.Black, lblLabNo.Location.X, lblLabNo.Location.Y)
        e.Graphics.DrawString(Me.txtLabno.Text, flblLabNo, Brushes.Black, txtLabno.Location.X, txtLabno.Location.Y)

        e.Graphics.DrawString(Me.lblRoomno.Text, Font, Brushes.Black, lblRoomno.Location.X, lblRoomno.Location.Y)
        e.Graphics.DrawString(Me.txtRoomno.Text, flblLabNo, Brushes.Black, txtRoomno.Location.X, txtRoomno.Location.Y)

        e.Graphics.DrawString(Me.lblPathologist.Text, Font, Brushes.Black, lblPathologist.Location.X, lblPathologist.Location.Y)
        e.Graphics.DrawString(Me.txtPathologist.Text, flblLabNo, Brushes.Black, txtPathologist.Location.X, txtPathologist.Location.Y)

        e.Graphics.DrawString(Me.lblDate.Text, Font, Brushes.Black, lblDate.Location.X, lblDate.Location.Y)
        e.Graphics.DrawString(Me.dtDate.Text, txtfnt, Brushes.Black, dtDate.Location.X, dtDate.Location.Y)

        e.Graphics.DrawString(Me.lblMedtech.Text, Font, Brushes.Black, lblMedtech.Location.X, lblMedtech.Location.Y)
        e.Graphics.DrawString(Me.cmbMedtech.Text, flblLabNo, Brushes.Black, cmbMedtech.Location.X, cmbMedtech.Location.Y)

        '********************************************Controls********************************************************

        If Convert.ToBoolean(dtUrinalysis.Rows(0)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblColor.Text, txtfnt1, Brushes.Black, pnlColor.Location.X _
                                  + lblColor.Location.X, pnlColor.Location.Y + lblColor.Location.Y)
            e.Graphics.DrawString(Me.txtColor.Text, txtColor.Font, Brushes.Black, pnlColor.Location.X _
                                  + txtColor.Location.X, pnlColor.Location.Y + txtColor.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineColor.X1 + Me.pnlColor.Location.X, lineColor.Y1 + Me.pnlColor.Location.Y, _
                                lineColor.X2 + Me.pnlColor.Location.X, lineColor.Y2 + Me.pnlColor.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(1)(7).ToString) = True Then
            '  tsclick(Me.frmurinalysiss.pnlAppearance, e.Node)
            e.Graphics.DrawString(Me.lblAppearance.Text, txtfnt1, Brushes.Black, pnlAppearance.Location.X _
                                 + lblAppearance.Location.X, pnlAppearance.Location.Y + lblAppearance.Location.Y)
            e.Graphics.DrawString(Me.txtAppearance.Text, txtAppearance.Font, Brushes.Black, pnlAppearance.Location.X _
                                  + txtAppearance.Location.X, pnlAppearance.Location.Y + txtAppearance.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineAppearance.X1 + Me.pnlAppearance.Location.X, LineAppearance.Y1 + Me.pnlAppearance.Location.Y, _
                                LineAppearance.X2 + Me.pnlAppearance.Location.X, LineAppearance.Y2 + Me.pnlAppearance.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(2)(7).ToString) = True Then
            ' tsclick(Me.frmurinalysiss.pnlReactions, e.Node)
            e.Graphics.DrawString(Me.lblReactions.Text, txtfnt1, Brushes.Black, pnlReactions.Location.X _
                                 + lblReactions.Location.X, pnlReactions.Location.Y + lblReactions.Location.Y)
            e.Graphics.DrawString(Me.txtReactions.Text, txtReactions.Font, Brushes.Black, pnlReactions.Location.X _
                                  + txtReactions.Location.X, pnlReactions.Location.Y + txtReactions.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineReactions.X1 + Me.pnlReactions.Location.X, lineReactions.Y1 + Me.pnlReactions.Location.Y, _
                                lineReactions.X2 + Me.pnlReactions.Location.X, lineReactions.Y2 + Me.pnlReactions.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(3)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(3)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlSpecGravity, e.Node)

            e.Graphics.DrawString(Me.lblSpecificGravity.Text, txtfnt1, Brushes.Black, pnlSpecGravity.Location.X _
                                 + lblSpecificGravity.Location.X, pnlSpecGravity.Location.Y + lblSpecificGravity.Location.Y)
            e.Graphics.DrawString(Me.txtSpecGrav.Text, txtSpecGrav.Font, Brushes.Black, pnlSpecGravity.Location.X _
                                  + txtSpecGrav.Location.X, pnlSpecGravity.Location.Y + txtSpecGrav.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineSpecGrav.X1 + Me.pnlSpecGravity.Location.X, lineSpecGrav.Y1 + Me.pnlSpecGravity.Location.Y, _
                                lineSpecGrav.X2 + Me.pnlSpecGravity.Location.X, lineSpecGrav.Y2 + Me.pnlSpecGravity.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(4)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(4)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlAlbumin, e.Node)

            e.Graphics.DrawString(Me.lblAlbumin.Text, txtfnt1, Brushes.Black, pnlAlbumin.Location.X _
                                 + lblAlbumin.Location.X, pnlAlbumin.Location.Y + lblAlbumin.Location.Y)
            e.Graphics.DrawString(Me.txtAlbumin.Text, txtAlbumin.Font, Brushes.Black, pnlAlbumin.Location.X _
                                  + txtAlbumin.Location.X, pnlAlbumin.Location.Y + txtAlbumin.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineAlmubin.X1 + Me.pnlAlbumin.Location.X, lineAlmubin.Y1 + Me.pnlAlbumin.Location.Y, _
                                lineAlmubin.X2 + Me.pnlAlbumin.Location.X, lineAlmubin.Y2 + Me.pnlAlbumin.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(5)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(5)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlSugar, e.Node)

            e.Graphics.DrawString(Me.lblSugar.Text, txtfnt1, Brushes.Black, pnlSugar.Location.X _
                                 + lblSugar.Location.X, pnlSugar.Location.Y + lblSugar.Location.Y)
            e.Graphics.DrawString(Me.txtSugar.Text, txtSugar.Font, Brushes.Black, pnlSugar.Location.X _
                                  + txtSugar.Location.X, pnlSugar.Location.Y + txtSugar.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineSugar.X1 + Me.pnlSugar.Location.X, lineSugar.Y1 + Me.pnlSugar.Location.Y, _
                                lineSugar.X2 + Me.pnlSugar.Location.X, lineSugar.Y2 + Me.pnlSugar.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(6)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(6)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlKetone, e.Node)

            e.Graphics.DrawString(Me.lblKetone.Text, txtfnt1, Brushes.Black, pnlKetone.Location.X _
                                 + lblKetone.Location.X, pnlKetone.Location.Y + lblKetone.Location.Y)
            e.Graphics.DrawString(Me.txtKetone.Text, txtKetone.Font, Brushes.Black, pnlKetone.Location.X _
                                  + txtKetone.Location.X, pnlKetone.Location.Y + txtKetone.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineKetone.X1 + Me.pnlKetone.Location.X, lineKetone.Y1 + Me.pnlKetone.Location.Y, _
                                lineKetone.X2 + Me.pnlKetone.Location.X, lineKetone.Y2 + Me.pnlKetone.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(7)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(7)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlChemOthers, e.Node)

            e.Graphics.DrawString(Me.lblOthersChemExam.Text, txtfnt1, Brushes.Black, pnlChemOthers.Location.X _
                                 + lblOthersChemExam.Location.X, pnlChemOthers.Location.Y + lblOthersChemExam.Location.Y)
            e.Graphics.DrawString(Me.txtChemothers.Text, txtChemothers.Font, Brushes.Black, pnlChemOthers.Location.X _
                                  + txtChemothers.Location.X, pnlChemOthers.Location.Y + txtChemothers.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineChemOthers.X1 + Me.pnlChemOthers.Location.X, lineChemOthers.Y1 + Me.pnlChemOthers.Location.Y, _
                                lineChemOthers.X2 + Me.pnlChemOthers.Location.X, lineChemOthers.Y2 + Me.pnlChemOthers.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(8)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(8)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlPusCells, e.Node)

            e.Graphics.DrawString(Me.lblPussCells.Text, txtfnt1, Brushes.Black, pnlPusCells.Location.X _
                                 + lblPussCells.Location.X, pnlPusCells.Location.Y + lblPussCells.Location.Y)
            e.Graphics.DrawString(Me.txtPussCells.Text, txtPussCells.Font, Brushes.Black, pnlPusCells.Location.X _
                                  + txtPussCells.Location.X, pnlPusCells.Location.Y + txtPussCells.Location.Y)
            e.Graphics.DrawLine(Pens.Black, linePussCells.X1 + Me.pnlPusCells.Location.X, linePussCells.Y1 + Me.pnlPusCells.Location.Y, _
                                linePussCells.X2 + Me.pnlPusCells.Location.X, linePussCells.Y2 + Me.pnlPusCells.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(9)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(9)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlRBC, e.Node)

            e.Graphics.DrawString(Me.lblRBC.Text, txtfnt1, Brushes.Black, pnlRBC.Location.X _
                                 + lblRBC.Location.X, pnlRBC.Location.Y + lblRBC.Location.Y)
            e.Graphics.DrawString(Me.txtRBC.Text, txtRBC.Font, Brushes.Black, pnlRBC.Location.X _
                                  + txtRBC.Location.X, pnlRBC.Location.Y + txtRBC.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineRBC.X1 + Me.pnlRBC.Location.X, lineRBC.Y1 + Me.pnlRBC.Location.Y, _
                                lineRBC.X2 + Me.pnlRBC.Location.X, lineRBC.Y2 + Me.pnlRBC.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(10)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(10)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlEpithCells, e.Node)

            e.Graphics.DrawString(Me.lblEpithelialCells.Text, txtfnt1, Brushes.Black, pnlEpithCells.Location.X _
                                 + lblEpithelialCells.Location.X, pnlEpithCells.Location.Y + lblEpithelialCells.Location.Y)
            e.Graphics.DrawString(Me.txtEpithCells.Text, txtEpithCells.Font, Brushes.Black, pnlEpithCells.Location.X _
                                  + txtEpithCells.Location.X, pnlEpithCells.Location.Y + txtEpithCells.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineEpithCells.X1 + Me.pnlEpithCells.Location.X, lineEpithCells.Y1 + Me.pnlEpithCells.Location.Y, _
                                lineEpithCells.X2 + Me.pnlEpithCells.Location.X, lineEpithCells.Y2 + Me.pnlEpithCells.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(11)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(11)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlMucThread, e.Node)

            e.Graphics.DrawString(Me.lblMucuThreads.Text, txtfnt1, Brushes.Black, pnlMucThread.Location.X _
                                 + lblMucuThreads.Location.X, pnlMucThread.Location.Y + lblMucuThreads.Location.Y)
            e.Graphics.DrawString(Me.txtMucthread.Text, txtMucthread.Font, Brushes.Black, pnlMucThread.Location.X _
                                  + txtMucthread.Location.X, pnlMucThread.Location.Y + txtMucthread.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineMucThread.X1 + Me.pnlMucThread.Location.X, lineMucThread.Y1 + Me.pnlMucThread.Location.Y, _
                                lineMucThread.X2 + Me.pnlMucThread.Location.X, lineMucThread.Y2 + Me.pnlMucThread.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(12)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(12)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlAmorUrates, e.Node)

            e.Graphics.DrawString(Me.lblAmorphousUrates.Text, txtfnt1, Brushes.Black, pnlAmorUrates.Location.X _
                                 + lblAmorphousUrates.Location.X, pnlAmorUrates.Location.Y + lblAmorphousUrates.Location.Y)
            e.Graphics.DrawString(Me.txtAmorphousUrates.Text, txtAmorphousUrates.Font, Brushes.Black, pnlAmorUrates.Location.X _
                                  + txtAmorphousUrates.Location.X, pnlAmorUrates.Location.Y + txtAmorphousUrates.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineAmorUrates.X1 + Me.pnlAmorUrates.Location.X, lineAmorUrates.Y1 + Me.pnlAmorUrates.Location.Y, _
                                lineAmorUrates.X2 + Me.pnlAmorUrates.Location.X, lineAmorUrates.Y2 + Me.pnlAmorUrates.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(13)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(13)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlUricAcid, e.Node)

            e.Graphics.DrawString(Me.lblUricAcid.Text, txtfnt1, Brushes.Black, pnlUricAcid.Location.X _
                                 + lblUricAcid.Location.X, pnlUricAcid.Location.Y + lblUricAcid.Location.Y)
            e.Graphics.DrawString(Me.txtUricAcid.Text, txtUricAcid.Font, Brushes.Black, pnlUricAcid.Location.X _
                                  + txtUricAcid.Location.X, pnlUricAcid.Location.Y + txtUricAcid.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineUricAcid.X1 + Me.pnlUricAcid.Location.X, lineUricAcid.Y1 + Me.pnlUricAcid.Location.Y, _
                                lineUricAcid.X2 + Me.pnlUricAcid.Location.X, lineUricAcid.Y2 + Me.pnlUricAcid.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(14)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(14)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlCalciumOxalate, e.Node)

            e.Graphics.DrawString(Me.lblCalciumOxalate.Text, txtfnt1, Brushes.Black, pnlCalciumOxalate.Location.X _
                                 + lblCalciumOxalate.Location.X, pnlCalciumOxalate.Location.Y + lblCalciumOxalate.Location.Y)
            e.Graphics.DrawString(Me.txtCalcOxalte.Text, txtCalcOxalte.Font, Brushes.Black, pnlCalciumOxalate.Location.X _
                                  + txtCalcOxalte.Location.X, pnlCalciumOxalate.Location.Y + txtCalcOxalte.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineCalcOxalte.X1 + Me.pnlCalciumOxalate.Location.X, lineCalcOxalte.Y1 + Me.pnlCalciumOxalate.Location.Y, _
                                lineCalcOxalte.X2 + Me.pnlCalciumOxalate.Location.X, lineCalcOxalte.Y2 + Me.pnlCalciumOxalate.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(15)(7).ToString) = True Then


            'ElseIf e.Node.Name = dtFecalysis.Rows(15)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlTriplePhospate, e.Node)

            e.Graphics.DrawString(Me.lblTriplePhosphate.Text, txtfnt1, Brushes.Black, pnlTriplePhospate.Location.X _
                                 + lblTriplePhosphate.Location.X, pnlTriplePhospate.Location.Y + lblTriplePhosphate.Location.Y)
            e.Graphics.DrawString(Me.txtTriplePhosphate.Text, txtTriplePhosphate.Font, Brushes.Black, pnlTriplePhospate.Location.X _
                                  + txtTriplePhosphate.Location.X, pnlTriplePhospate.Location.Y + txtTriplePhosphate.Location.Y)
            e.Graphics.DrawLine(Pens.Black, line3Phosphate.X1 + Me.pnlTriplePhospate.Location.X, line3Phosphate.Y1 + Me.pnlTriplePhospate.Location.Y, _
                                line3Phosphate.X2 + Me.pnlTriplePhospate.Location.X, line3Phosphate.Y2 + Me.pnlTriplePhospate.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(16)(7).ToString) = True Then


            'ElseIf e.Node.Name = dtFecalysis.Rows(16)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlCoarse, e.Node)

            e.Graphics.DrawString(Me.lblCoarse.Text, txtfnt1, Brushes.Black, pnlCoarse.Location.X _
                                 + lblCoarse.Location.X, pnlCoarse.Location.Y + lblCoarse.Location.Y)
            e.Graphics.DrawString(Me.txtCoarse.Text, txtCoarse.Font, Brushes.Black, pnlCoarse.Location.X _
                                  + txtCoarse.Location.X, pnlCoarse.Location.Y + txtCoarse.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineCoarse.X1 + Me.pnlCoarse.Location.X, lineCoarse.Y1 + Me.pnlCoarse.Location.Y, _
                                lineCoarse.X2 + Me.pnlCoarse.Location.X, lineCoarse.Y2 + Me.pnlCoarse.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(17)(7).ToString) = True Then


            'ElseIf e.Node.Name = dtFecalysis.Rows(17)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlFine, e.Node)

            e.Graphics.DrawString(Me.lblFine.Text, txtfnt1, Brushes.Black, pnlFine.Location.X _
                                 + lblFine.Location.X, pnlFine.Location.Y + lblFine.Location.Y)
            e.Graphics.DrawString(Me.txtFine.Text, txtFine.Font, Brushes.Black, pnlFine.Location.X _
                                  + txtFine.Location.X, pnlFine.Location.Y + txtFine.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineFine.X1 + Me.pnlFine.Location.X, lineFine.Y1 + Me.pnlFine.Location.Y, _
                                lineFine.X2 + Me.pnlFine.Location.X, lineFine.Y2 + Me.pnlFine.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(18)(7).ToString) = True Then


            '    'Bacteria_Others
            'ElseIf e.Node.Name = dtFecalysis.Rows(18)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlBacteriaOthers, e.Node)

            e.Graphics.DrawString(Me.lblBacOthers.Text, txtfnt1, Brushes.Black, pnlBacteriaOthers.Location.X _
                                 + lblBacOthers.Location.X, pnlBacteriaOthers.Location.Y + lblBacOthers.Location.Y)
            e.Graphics.DrawString(Me.txtBacteriaOthers.Text, txtBacteriaOthers.Font, Brushes.Black, pnlBacteriaOthers.Location.X _
                                  + txtBacteriaOthers.Location.X, pnlBacteriaOthers.Location.Y + txtBacteriaOthers.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineBacOthers.X1 + Me.pnlBacteriaOthers.Location.X, lineBacOthers.Y1 + Me.pnlBacteriaOthers.Location.Y, _
                                lineBacOthers.X2 + Me.pnlBacteriaOthers.Location.X, lineBacOthers.Y2 + Me.pnlBacteriaOthers.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(19)(7).ToString) = True Then


            'ElseIf e.Node.Name = dtFecalysis.Rows(19)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlYeast, e.Node)

            e.Graphics.DrawString(Me.lblYeastCells.Text, txtfnt1, Brushes.Black, pnlYeast.Location.X _
                                 + lblYeastCells.Location.X, pnlYeast.Location.Y + lblYeastCells.Location.Y)
            e.Graphics.DrawString(Me.txtYeast.Text, txtYeast.Font, Brushes.Black, pnlYeast.Location.X _
                                  + txtYeast.Location.X, pnlYeast.Location.Y + txtYeast.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineYeastCells.X1 + Me.pnlYeast.Location.X, lineYeastCells.Y1 + Me.pnlYeast.Location.Y, _
                                lineYeastCells.X2 + Me.pnlYeast.Location.X, lineYeastCells.Y2 + Me.pnlYeast.Location.Y)
        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(20)(7).ToString) = True Then


            'ElseIf e.Node.Name = dtFecalysis.Rows(20)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlCastOthers, e.Node)

            e.Graphics.DrawString(Me.lblCastOthers.Text, txtfnt1, Brushes.Black, pnlCastOthers.Location.X _
                                 + lblCastOthers.Location.X, pnlCastOthers.Location.Y + lblCastOthers.Location.Y)
            e.Graphics.DrawString(Me.txtCastOthers.Text, txtCastOthers.Font, Brushes.Black, pnlCastOthers.Location.X _
                                  + txtCastOthers.Location.X, pnlCastOthers.Location.Y + txtCastOthers.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineCastOthers.X1 + Me.pnlCastOthers.Location.X, lineCastOthers.Y1 + Me.pnlCastOthers.Location.Y, _
                                lineCastOthers.X2 + Me.pnlCastOthers.Location.X, lineCastOthers.Y2 + Me.pnlCastOthers.Location.Y)
        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(21)(7).ToString) = True Then


            e.Graphics.DrawString(Me.lblPhysicalExamin.Text, Font, Brushes.Black, pnlPhysicalExam.Location.X _
                                 + lblPhysicalExamin.Location.X, pnlPhysicalExam.Location.Y + lblPhysicalExamin.Location.Y)

        End If

        If Convert.ToBoolean(dtUrinalysis.Rows(22)(7).ToString) = True Then

            e.Graphics.DrawString(Me.lblChemicalExamination.Text, Font, Brushes.Black, pnlChemExam.Location.X _
                                 + lblChemicalExamination.Location.X, pnlChemExam.Location.Y + lblChemicalExamination.Location.Y)

        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(23)(7).ToString) = True Then

            'ElseIf e.Node.Name = dtFecalysis.Rows(23)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlMicroExam, e.Node)
            e.Graphics.DrawString(Me.lblMicroscopicExam.Text, Font, Brushes.Black, pnlMicroExam.Location.X _
                                 + lblMicroscopicExam.Location.X, pnlMicroExam.Location.Y + lblMicroscopicExam.Location.Y)

        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(24)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(24)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlCasts, e.Node)

            e.Graphics.DrawString(Me.lblCasts.Text, Font, Brushes.Black, pnlCastsUrinalysis.Location.X _
                                 + lblCasts.Location.X, pnlCastsUrinalysis.Location.Y + lblCasts.Location.Y)

        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(25)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(25)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlCrystals, e.Node)

            e.Graphics.DrawString(Me.lblCrystals.Text, Font, Brushes.Black, pnlCrystals.Location.X _
                                 + lblCrystals.Location.X, pnlCrystals.Location.Y + lblCrystals.Location.Y)

        End If


        If Convert.ToBoolean(dtUrinalysis.Rows(26)(7).ToString) = True Then
            'ElseIf e.Node.Name = dtFecalysis.Rows(26)(2).ToString() Then
            '    tsclick(Me.frmurinalysiss.pnlBacteria, e.Node)


            e.Graphics.DrawString(Me.lblBacteria.Text, Font, Brushes.Black, pnlBacteria.Location.X _
                                 + lblBacteria.Location.X, pnlBacteria.Location.Y + lblBacteria.Location.Y)

        End If

    End Sub

#End Region
#Region "LOCK"
    Private Sub isEnabledTop(ByVal accesssible As Boolean)
        'Me.txtPatientid.Enabled = accesssible
        'Me.txtPatientname.Enabled = accesssible
        'Me.txtAge.Enabled = accesssible
        'Me.txtGender.Enabled = accesssible
        'Me.txtRoomno.Enabled = accesssible
        'Me.dtDate.Enabled = accesssible

        'Me.lblpatientid.Enabled = accesssible
        'Me.lblPatientname.Enabled = accesssible
        'Me.lblAge.Enabled = accesssible
        'Me.lblGender.Enabled = accesssible
        'Me.lblRoomno.Enabled = accesssible
        'Me.lblDate.Enabled = accesssible
    End Sub
    Private Sub isEnabled()
        'Me.txtPatientid.Enabled = False
        'Me.txtPatientname.Enabled = False
        'Me.txtAge.Enabled = False
        'Me.txtGender.Enabled = False
        'Me.txtRoomno.Enabled = False
        Me.txtLabno.Enabled = False
        Me.txtPathologist.Enabled = False
        Me.dtDate.Enabled = False
        Me.cmbMedtech.Enabled = False

        'Me.lblpatientid.Enabled = False
        'Me.lblPatientname.Enabled = False
        'Me.lblAge.Enabled = False
        'Me.lblGender.Enabled = False
        'Me.lblRoomno.Enabled = False
        Me.lblLabNo.Enabled = False
        Me.lblPathologist.Enabled = False
        'Me.lblDate.Enabled = False
        Me.lblMedtech.Enabled = False
    End Sub
#End Region
#Region "Anchor"
    Private Sub AnchorFields()
        'Me.lblheader1.Anchor = AnchorStyles.None
        Me.lblUrinalysis.Anchor = AnchorStyles.None
        Me.txtPatientName.Anchor = AnchorStyles.None
        Me.txtHospitalNo.Anchor = AnchorStyles.None
        Me.txtAge.Anchor = AnchorStyles.None
        Me.txtGender.Anchor = AnchorStyles.None
        Me.txtRoomno.Anchor = AnchorStyles.None
        Me.txtLabno.Anchor = AnchorStyles.None
        Me.txtPathologist.Anchor = AnchorStyles.None
        Me.dtDate.Anchor = AnchorStyles.None

        Me.lblpatientid.Anchor = AnchorStyles.None
        'Me.lblPatientname.Anchor = AnchorStyles.None
        Me.lblAge.Anchor = AnchorStyles.None
        Me.lblGender.Anchor = AnchorStyles.None
        Me.lblRoomno.Anchor = AnchorStyles.None
        Me.lblLabNo.Anchor = AnchorStyles.None
        Me.lblPathologist.Anchor = AnchorStyles.None
        Me.lblDate.Anchor = AnchorStyles.None
        Me.LineBorder.Anchor = AnchorStyles.None
    End Sub
#End Region
#Region "Textbox properties"
    Public Sub txtBoxProperties(ByVal accessible As Boolean)
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is TextBox = True Or TypeOf Controls(i) Is DateTimePicker = True Or TypeOf Controls(i) Is Panel Or TypeOf Controls(i) Is ComboBox Then
                Controls(i).Enabled = accessible
            End If
        Next
        'Me.txtPatientname.ReadOnly = True
        'Me.txtLabno.ReadOnly = True
        'Me.txtPatientid.ReadOnly = True
        'Me.dtDate.Enabled = False
        'Me.txtGender.ReadOnly = True
        'Me.txtAge.ReadOnly = True
        'Me.txtRoomno.ReadOnly = True
    End Sub
#End Region
    Public Sub saveUrinalysis()
        Dim myLaboratoryResult As New clsLaboratoryResult
        '******************** save labresult
        With myLaboratoryResult

            .laboratoryid = 2
            .itemcatcode = Nothing
            If dtResult.Rows.Count = 0 Then
                .admissionid = 1
                .patientrequestno = 1
                .labno = "1"
            Else
                .admissionid = dtResult.Rows(0).Item("admissionid").ToString()
                .patientrequestno = requestdetailno 'dtResult.Rows(0).Item("patientrequestno").ToString
                .labno = Utility.EmptyToZero(dtResult.Rows(0).Item("labexaminationno").ToString)
            End If
            .specimen = Nothing
            .datesubmitted = Utility.GetServerDate()
            .dateencoded = Utility.GetServerDate()
            .encodedby = 1 ' modGlobal.userid
            .pathologist = Me.txtPathologist.SelectedValue
            .medtech = 1
            .medicaltechnologist = Me.cmbMedtech.SelectedValue
            .releasedby = 1
            .datereleased = "01/01/1990"
            '.pathologist = Me.cmbRadiologist.SelectedValue
            If myFormStatus = enFormStatus.add Then
                .soperation = soperation
                .Save(True)
                Call SaveLog("Laboratory", "New urinalysis result with request no.: " & .patientrequestno & "", modGlobal.userid)
            Else
                .Oldlaboratoryid = Convert.ToInt32(LabID.Rows(0)(0).ToString())
                .soperation = soperation
                .Save(False)
                Call SaveLog("Laboratory", "Update urinalysis result with request no.: " & .patientrequestno & "", modGlobal.userid)
            End If
        End With

        Dim frmProgress As New frmProgressIndicator()
        frmProgress.labtype = myLaboratoryResult.laboratoryid
        frmProgress.myFormStatus = myFormStatus
        frmProgress.myresult = myResult
        frmProgress.dtFecalysis = clsExamination.getLabdetails("2")

        frmProgress.txtColor1 = Me.txtColor.Text
        frmProgress.txtAppearance = Me.txtAppearance.Text
        frmProgress.txtReactions = Me.txtReactions.Text
        frmProgress.txtSpecGrav = Me.txtSpecGrav.Text

        frmProgress.txtPussCells1 = Me.txtPussCells.Text
        frmProgress.txtRBC1 = Me.txtRBC.Text
        frmProgress.txtEpithCells = Me.txtEpithCells.Text
        frmProgress.txtMucthread = Me.txtMucthread.Text

        frmProgress.txtCoarse = Me.txtCoarse.Text
        frmProgress.txtFine = Me.txtFine.Text
        frmProgress.txtCastOthers = Me.txtCastOthers.Text

        frmProgress.txtAlbumin = Me.txtAlbumin.Text
        frmProgress.txtSugar = Me.txtSugar.Text
        frmProgress.txtKetone = Me.txtKetone.Text
        frmProgress.txtChemothers = Me.txtChemothers.Text

        frmProgress.txtAmorphousUrates = Me.txtAmorphousUrates.Text
        frmProgress.txtUricAcid = Me.txtUricAcid.Text
        frmProgress.txtCalcOxalte = Me.txtCalcOxalte.Text

        frmProgress.txtTriplePhosphate = Me.txtTriplePhosphate.Text
        frmProgress.txtYeast = Me.txtYeast.Text
        frmProgress.txtBacteriaOthers = Me.txtBacteriaOthers.Text




        If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
            frmProgress.dtLabResultDetails = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, LabID.Rows(0)(0).ToString(), 2, 1)
            frmProgress.LabID = clsLaboratoryResult.getLaboratoryID(requestdetailno, "2", 6)
        End If
        frmProgress.ShowDialog()
        isSave = True
    End Sub
    Public Sub Urinalysis()

        'Save Panel Color Properties
        If Me.pnlColor.Visible = True Then
            LabdetailID = UcolorID
            visiblecontrols = 1
            LocX = Me.pnlColor.Location.X
            LocY = Me.pnlColor.Location.Y
            isdrag = 1

            SaveUrinalysiDesign()
        Else
            LabdetailID = UcolorID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlColor.Location.X
            LocY = Me.pnlColor.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Appearance Properties
        If Me.pnlAppearance.Visible = True Then
            LabdetailID = UAppearanceID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlAppearance.Location.X
            LocY = Me.pnlAppearance.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UAppearanceID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlAppearance.Location.X
            LocY = Me.pnlAppearance.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Reactions Properties
        If Me.pnlReactions.Visible = True Then
            LabdetailID = UReactionsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlReactions.Location.X
            LocY = Me.pnlReactions.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UReactionsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlReactions.Location.X
            LocY = Me.pnlReactions.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Specific Gravity Properties
        If Me.pnlSpecGravity.Visible = True Then
            LabdetailID = UspecificGravID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlSpecGravity.Location.X
            LocY = Me.pnlSpecGravity.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UspecificGravID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlSpecGravity.Location.X
            LocY = Me.pnlSpecGravity.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Albumin Properties
        If Me.pnlAlbumin.Visible = True Then
            LabdetailID = UAlbuminID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlAlbumin.Location.X
            LocY = Me.pnlAlbumin.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UAlbuminID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlAlbumin.Location.X
            LocY = Me.pnlAlbumin.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Sugar Properties
        If Me.pnlSugar.Visible = True Then
            LabdetailID = UsugarID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlSugar.Location.X
            LocY = Me.pnlSugar.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UsugarID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlSugar.Location.X
            LocY = Me.pnlSugar.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Ketone Properties
        If Me.pnlKetone.Visible = True Then
            LabdetailID = UKetoneID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlKetone.Location.X
            LocY = Me.pnlKetone.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UKetoneID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlKetone.Location.X
            LocY = Me.pnlKetone.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Chem Others Properties
        If Me.pnlChemOthers.Visible = True Then
            LabdetailID = UB_othersID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlChemOthers.Location.X
            LocY = Me.pnlChemOthers.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UB_othersID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlChemOthers.Location.X
            LocY = Me.pnlChemOthers.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Puss Cells Properties
        If Me.pnlPusCells.Visible = True Then
            LabdetailID = UPusCellsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlPusCells.Location.X
            LocY = Me.pnlPusCells.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UPusCellsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlPusCells.Location.X
            LocY = Me.pnlPusCells.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel RBC Properties
        If Me.pnlRBC.Visible = True Then
            LabdetailID = URBCID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlRBC.Location.X
            LocY = Me.pnlRBC.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = URBCID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlRBC.Location.X
            LocY = Me.pnlRBC.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Epith Cells Properties
        If Me.pnlEpithCells.Visible = True Then
            LabdetailID = UepithelialCellsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlEpithCells.Location.X
            LocY = Me.pnlEpithCells.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UepithelialCellsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlEpithCells.Location.X
            LocY = Me.pnlEpithCells.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Mucus Threads Properties
        If Me.pnlMucThread.Visible = True Then
            LabdetailID = UMucusThreadsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlMucThread.Location.X
            LocY = Me.pnlMucThread.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UMucusThreadsID 'UepithelialCellsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlMucThread.Location.X
            LocY = Me.pnlMucThread.Location.Y
            SaveUrinalysiDesign()

        End If


        'Save Panel Amor phous Urates Properties
        If Me.pnlAmorUrates.Visible = True Then
            LabdetailID = UAmorphousUratesID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlAmorUrates.Location.X
            LocY = Me.pnlAmorUrates.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UAmorphousUratesID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlAmorUrates.Location.X
            LocY = Me.pnlAmorUrates.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Uric Acid Properties
        If Me.pnlUricAcid.Visible = True Then
            LabdetailID = UUricAcidID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlUricAcid.Location.X
            LocY = Me.pnlUricAcid.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UUricAcidID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlUricAcid.Location.X
            LocY = Me.pnlUricAcid.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Calcium Oxalate Properties
        If Me.pnlCalciumOxalate.Visible = True Then
            LabdetailID = UCalcOxalateID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCalciumOxalate.Location.X
            LocY = Me.pnlCalciumOxalate.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCalcOxalateID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCalciumOxalate.Location.X
            LocY = Me.pnlCalciumOxalate.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel 3 Phosphate Properties
        If Me.pnlTriplePhospate.Visible = True Then
            LabdetailID = U3PhosphateID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlTriplePhospate.Location.X
            LocY = Me.pnlTriplePhospate.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = U3PhosphateID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlTriplePhospate.Location.X
            LocY = Me.pnlTriplePhospate.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Coarse Properties
        If Me.pnlCoarse.Visible = True Then
            LabdetailID = UCoareID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCoarse.Location.X
            LocY = Me.pnlCoarse.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCoareID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCoarse.Location.X
            LocY = Me.pnlCoarse.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Fine Properties
        If Me.pnlFine.Visible = True Then
            LabdetailID = UFineID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlFine.Location.X
            LocY = Me.pnlFine.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UFineID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlFine.Location.X
            LocY = Me.pnlFine.Location.Y
            SaveUrinalysiDesign()

        End If


        'Save Panel Bacteria Others Properties
        If Me.pnlBacteriaOthers.Visible = True Then
            LabdetailID = UCrystalOthersID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlBacteriaOthers.Location.X
            LocY = Me.pnlBacteriaOthers.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCrystalOthersID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlBacteriaOthers.Location.X
            LocY = Me.pnlBacteriaOthers.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Yeast Cells Properties
        If Me.pnlYeast.Visible = True Then
            LabdetailID = UyeastCellsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlYeast.Location.X
            LocY = Me.pnlYeast.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UyeastCellsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlYeast.Location.X
            LocY = Me.pnlYeast.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Cast Others Properties
        If Me.pnlCastOthers.Visible = True Then
            LabdetailID = UCast_OthersID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCastOthers.Location.X
            LocY = Me.pnlCastOthers.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCast_OthersID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCastOthers.Location.X
            LocY = Me.pnlCastOthers.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Physical Examination Properties
        If Me.pnlPhysicalExam.Visible = True Then
            LabdetailID = UPhysicalExaminID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlPhysicalExam.Location.X
            LocY = Me.pnlPhysicalExam.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UPhysicalExaminID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlPhysicalExam.Location.X
            LocY = Me.pnlPhysicalExam.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Chem Examination Properties
        If Me.pnlChemExam.Visible = True Then
            LabdetailID = UChem_ExminID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlChemExam.Location.X
            LocY = Me.pnlChemExam.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UChem_ExminID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlChemExam.Location.X
            LocY = Me.pnlChemExam.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Micro Examination Properties
        If Me.pnlMicroExam.Visible = True Then
            LabdetailID = UMicroExaminID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlMicroExam.Location.X
            LocY = Me.pnlMicroExam.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UMicroExaminID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlMicroExam.Location.X
            LocY = Me.pnlMicroExam.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Cast Label Properties
        If Me.pnlCastsUrinalysis.Visible = True Then
            LabdetailID = UCastsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCastsUrinalysis.Location.X
            LocY = Me.pnlCastsUrinalysis.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCastsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCastsUrinalysis.Location.X
            LocY = Me.pnlCastsUrinalysis.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Crystals Label Properties
        If Me.pnlCrystals.Visible = True Then
            LabdetailID = UCystalsID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCrystals.Location.X
            LocY = Me.pnlCrystals.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UCystalsID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCrystals.Location.X
            LocY = Me.pnlCrystals.Location.Y
            SaveUrinalysiDesign()

        End If

        'Save Panel Bacteria Label Properties
        If Me.pnlBacteria.Visible = True Then
            LabdetailID = UBacteriaID
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlBacteria.Location.X
            LocY = Me.pnlBacteria.Location.Y
            SaveUrinalysiDesign()
        Else
            LabdetailID = UBacteriaID
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlBacteria.Location.X
            LocY = Me.pnlBacteria.Location.Y
            SaveUrinalysiDesign()

        End If
        Call SaveLog("Laboratory", "Modify urinalysis design schema", modGlobal.userid)
        '******End of Saving*********8


    End Sub
    Public Sub SaveUrinalysiDesign()

        Dim MyUrinalysis As New clsExamination

        MyUrinalysis.laboratorydetailsid = LabdetailID
        MyUrinalysis.visible = visiblecontrols
        MyUrinalysis.isDrag = isdrag
        MyUrinalysis.x = LocX
        MyUrinalysis.y = LocY
        MyUrinalysis.save(True)

    End Sub
    Public Sub UpdateRequestStatus()
        Dim Myrequest As New clsExaminationUpshots

        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno

        If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Then
            Myrequest.save(False)
        Else
            '.Oldlaboratoryid = Convert.ToInt32(LabID.Rows(0)(0).ToString())
            '.Save(False)
        End If
    End Sub

#Region "PAINT"
    Private Sub paintForm(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim mGraphics As Graphics = e.Graphics
        Dim pen1 As Pen = New Pen(Color.FromArgb(252, 254, 255), 1)
        Dim Area1 As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1) '253, 254, 255
        Dim LGB As LinearGradientBrush = New LinearGradientBrush(Area1, Color.FromArgb(252, 254, 255), Color.FromArgb(227, 237, 253), LinearGradientMode.Vertical)
        mGraphics.FillRectangle(LGB, Area1)
        mGraphics.DrawRectangle(pen1, Area1)
    End Sub
#End Region

    Private Sub panel_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPhysicalExam.MouseDown, _
        pnlColor.MouseDown, _
        pnlAppearance.MouseDown, _
        pnlReactions.MouseDown, _
        pnlSpecGravity.MouseDown, _
        pnlMicroExam.MouseDown, _
        pnlPusCells.MouseDown, _
        pnlRBC.MouseDown, _
        pnlEpithCells.MouseDown, _
        pnlMucThread.MouseDown, _
        pnlCastsUrinalysis.MouseDown, _
        pnlCoarse.MouseDown, _
        pnlFine.MouseDown, _
        pnlCastOthers.MouseDown, _
        pnlChemExam.MouseDown, _
        pnlAlbumin.MouseDown, _
        pnlSugar.MouseDown, _
        pnlKetone.MouseDown, _
        pnlChemOthers.MouseDown, _
        pnlCrystals.MouseDown, _
        pnlAmorUrates.MouseDown, _
        pnlUricAcid.MouseDown, _
        pnlCalciumOxalate.MouseDown, _
        pnlTriplePhospate.MouseDown, _
        pnlBacteria.MouseDown, _
        pnlYeast.MouseDown, _
        pnlBacteriaOthers.MouseDown
        If IsSelected = False Then
            dragging = True
        Else
            sender.Cursor = DefaultCursor
        End If
        startX = e.X
        startY = e.Y
    End Sub
    Private Sub panel_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPhysicalExam.MouseMove, _
        pnlColor.MouseMove, _
        pnlAppearance.MouseMove, _
        pnlReactions.MouseMove, _
        pnlSpecGravity.MouseMove, _
        pnlMicroExam.MouseMove, _
        pnlPusCells.MouseMove, _
        pnlRBC.MouseMove, _
        pnlEpithCells.MouseMove, _
        pnlMucThread.MouseMove, _
        pnlCastsUrinalysis.MouseMove, _
        pnlCoarse.MouseMove, _
        pnlFine.MouseMove, _
        pnlCastOthers.MouseMove, _
        pnlChemExam.MouseMove, _
        pnlAlbumin.MouseMove, _
        pnlSugar.MouseMove, _
        pnlKetone.MouseMove, _
        pnlChemOthers.MouseMove, _
        pnlCrystals.MouseMove, _
        pnlAmorUrates.MouseMove, _
        pnlUricAcid.MouseMove, _
        pnlCalciumOxalate.MouseMove, _
        pnlTriplePhospate.MouseMove, _
        pnlBacteria.MouseMove, _
        pnlYeast.MouseMove, _
        pnlBacteriaOthers.MouseMove
        If dragging = True Then
            Dim newX As Integer = sender.Location.X + e.X - startX
            Dim newY As Integer = sender.Location.Y + e.Y - startY
            If newX < -1 And newY < 173 Then
                sender.Location = New Point(0, 172)
            ElseIf newX < -1 And newY > 493 Then
                sender.Location = New Point(0, 492)
            ElseIf newX > 583 And newY < 173 Then
                sender.Location = New Point(582, 172)
            ElseIf newX > 583 And newY > 493 Then
                sender.Location = New Point(582, 492)
            ElseIf newX < -1 Then
                sender.Location = New Point(0, sender.Location.Y + e.Y - startY)
            ElseIf newX > 583 Then
                sender.Location = New Point(582, sender.Location.Y + e.Y - startY)
            ElseIf newY < 173 Then
                sender.Location = New Point(sender.Location.X + e.X - startX, 172)
            ElseIf newY > 493 Then
                sender.Location = New Point(sender.Location.X + e.X - startX, 492)
            Else
                sender.Location = New Point(sender.Location.X + e.X - startX, sender.Location.Y + e.Y - startY)
            End If
            Label1.Text = sender.Location.X & " , " & sender.Location.Y & " px"
            Me.Refresh()
        End If
    End Sub
    Private Sub panel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPhysicalExam.MouseUp, _
        pnlColor.MouseUp, _
        pnlAppearance.MouseUp, _
        pnlReactions.MouseUp, _
        pnlSpecGravity.MouseUp, _
        pnlMicroExam.MouseUp, _
        pnlPusCells.MouseUp, _
        pnlRBC.MouseUp, _
        pnlEpithCells.MouseUp, _
        pnlMucThread.MouseUp, _
        pnlCastsUrinalysis.MouseUp, _
        pnlCoarse.MouseUp, _
        pnlFine.MouseUp, _
        pnlCastOthers.MouseUp, _
        pnlChemExam.MouseUp, _
        pnlAlbumin.MouseUp, _
        pnlSugar.MouseUp, _
        pnlKetone.MouseUp, _
        pnlChemOthers.MouseUp, _
        pnlCrystals.MouseUp, _
        pnlAmorUrates.MouseUp, _
        pnlUricAcid.MouseUp, _
        pnlCalciumOxalate.MouseUp, _
        pnlTriplePhospate.MouseUp, _
        pnlBacteria.MouseUp, _
        pnlYeast.MouseUp, _
        pnlBacteriaOthers.MouseUp
        dragging = False
    End Sub
#End Region

#Region "Events"
    Private Sub frmUrinalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadUrinalysis()
    End Sub
    '*******************Design Mode******************
#End Region
End Class