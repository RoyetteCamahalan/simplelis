Public Class frmProgressIndicator
#Region "Variables"
    Public myFormStatus As Integer
    Public myResult As Integer

    Dim disposeFormTimer As Integer
    Public labtype As Integer
    Public rowcount As Integer
    Public dtFecalysis As New DataTable
    Public LabID As New DataTable
    Public dtLabResultDetails As New DataTable
    Dim dr As DataRow
    Dim drLabResultDetails As DataRow

    '*************************Fecalysis
    Public txtcolor As String
    Public txtConsist As String
    Public txtPussCells As String
    Public txtRBC As String
    Public txtFatGlob As String
    Public txtALumb As String
    Public txtHookworm As String
    Public txtTtrichu As String
    Public txtEntahisCyst As String
    Public txtOthers As String
    Public txtTropozite As String
    Public isUsetoDashboard As Boolean
    '||>
    '||>
    '||>
    '************************ Urinalysis
    Public txtColor1 As String
    Public txtAppearance As String
    Public txtReactions As String
    Public txtSpecGrav As String

    Public txtPussCells1 As String
    Public txtRBC1 As String
    Public txtEpithCells As String
    Public txtMucthread As String

    Public txtCoarse As String
    Public txtFine As String
    Public txtCastOthers As String

    Public txtAlbumin As String
    Public txtSugar As String
    Public txtKetone As String
    Public txtChemothers As String

    Public txtAmorphousUrates As String
    Public txtUricAcid As String
    Public txtCalcOxalte As String

    Public txtTriplePhosphate As String
    Public txtYeast As String
    Public txtBacteriaOthers As String



    '******************************Hematology as 1 others
    Public txtHemoglobin As String
    Public txtHematocrit As String
    Public txtLeucocyteCount As String


    Public txtSegmentedNeutophilis As String
    Public txtStabs As String
    Public txtLymphocytes As String
    Public txtMonocytes As String
    Public txtEosinophilis As String
    Public txtBasophilis As String

    Public cmbBloodtype As String
    Public txtPlateletCount As String
    Public txtBleedingTime As String
    Public txtClottingTime As String
    Public txtESR As String
    Public txtMalarialPara As String

    Public txtRedCelllCount As String
    Public txtOthers1 As String

    '*******************************Blood Chemistry
    Public txtFBS As String
    Public txtRBS As String
    Public txtPPBS As String
    Public txtSUA As String

    Public txtCreatinine As String
    Public txtALTSGPT As String
    Public txtCholesterol As String
    Public txtTriglyceride As String

    Public txtHDL As String
    'laktaw 1
    Public txtLDL As String
    Public txtHBAlc As String

    Public txtAmylase As String
    Public txtTotallProtein As String
    Public txtAlbumin1 As String ' existing 1
    Public txtGlobulin As String

    Public txtLipase As String
    Public txtAST As String
    Public txtAP As String

    Public txtBUN As String
    Public txtSodium As String
    Public txtPotassium As String
    Public txtCalcium As String


    Public bilirubin As String
    Public Directbilirubin As String
    Public IndirectDirectbilirubin As String
    'Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    'Friend WithEvents Timer1 As System.Windows.Forms.Timer
    'Private components As System.ComponentModel.IContainer
    'Friend WithEvents Label1 As System.Windows.Forms.Label
    Dim subCtr As Integer


    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
    End Enum
#End Region
#Region "Method/s"
    Private Sub Save()
        Dim myLaboratoryResultDetails As New clsLaboratoryResultDetails
        dtFecalysis.PrimaryKey = New DataColumn() {dtFecalysis.Columns("laboratorydetailsid")}
        dtLabResultDetails.PrimaryKey = New DataColumn() {dtLabResultDetails.Columns("laboratorydetailsid")}

        If labtype = 1 Then

            For ctr = 0 To dtFecalysis.Rows.Count - 1
                dr = dtFecalysis.Rows.Find(CDbl(dtFecalysis.Rows(ctr)(1).ToString()))
                If dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Color" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtcolor
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Consistency" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtConsist
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Pus Cells" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtPussCells
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "RBC" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtRBC
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Fat Globules" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtFatGlob
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Ascaris lumbricoides" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtALumb
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Hookworm" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtHookworm
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Trichuris trichiura" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtTtrichu
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Entamoeba histolyca Cyst" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtEntahisCyst
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "OTHERS" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtOthers
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Trophozoite" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtTropozite
                End If
                If myFormStatus = enFormStatus.add Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = Nothing
                    myLaboratoryResultDetails.Save(True)
                Else
                    drLabResultDetails = dtLabResultDetails.Rows.Find(CDbl(dtLabResultDetails.Rows(ctr)(2).ToString()))
                    If drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Color" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Consistency" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Pus Cells" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "RBC" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Fat Globules" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Ascaris lumbricoides" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Hookworm" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Trichuris trichiura" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Entamoeba histolyca Cyst" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "OTHERS" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Trophozoite" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    End If
                    myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                    myLaboratoryResultDetails.Save(False)
                End If
            Next
        ElseIf labtype = 2 Then
            For ctr = 0 To dtFecalysis.Rows.Count - 1
                If ctr <= 20 Then
                    dr = dtFecalysis.Rows.Find(CDbl(dtFecalysis.Rows(ctr)(1).ToString()))
                    If dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "COLOR" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString  'dtFecalysis.Rows(ctr)(1).ToString()
                        myLaboratoryResultDetails.result = txtColor1
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "APPEARANCE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtAppearance
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "REACTIONS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtReactions
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "SPECIFIC GRAVITY" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtSpecGrav
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "ALBUMIN" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtAlbumin 'txtPussCells1
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "SUGAR" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtSugar
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "KETONE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtKetone
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "B_OTHERS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtBacteriaOthers
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "PUS CELLS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtPussCells1
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "RBC" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtRBC1
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "EPITHELIAL CELLS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtEpithCells
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "MUCUS THREADS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtMucthread
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "AMORPHOUS URATES" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtAmorphousUrates
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "URIC ACID" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtUricAcid
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "CALCIUM OXALATE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtCalcOxalte
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "TRIPLE PHOSPHATE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtTriplePhosphate
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "COARE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtCoarse
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "FINE" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtFine
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "CRYSTAL_OTHERS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtChemothers
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "YEAST CELLS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtYeast
                    ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "CAST_OTHERS" Then
                        myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                        myLaboratoryResultDetails.result = txtCastOthers
                    End If
                    If myFormStatus = enFormStatus.add Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = Nothing
                        myLaboratoryResultDetails.Save(True)
                    Else
                        drLabResultDetails = dtLabResultDetails.Rows.Find(CDbl(dtLabResultDetails.Rows(ctr)(2).ToString()))
                        If drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "COLOR" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "APPEARANCE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "REACTIONS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "SPECIFIC GRAVITY" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "ALBUMIN" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "SUGAR" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "KETONE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "B_OTHERS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "PUS CELLS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "RBC" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "EPITHELIAL CELLS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "MUCUS THREADS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "AMORPHOUS URATES" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "URIC ACID" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "CALCIUM OXALATE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "TRIPLE PHOSPHATE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "COARE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "FINE" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "CRYSTAL_OTHERS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "YEAST CELLS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "CAST_OTHERS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                        End If
                        myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                        myLaboratoryResultDetails.Save(False)
                    End If
                Else
                    Exit For
                End If
            Next
        ElseIf labtype = 3 Then
            For ctr = 0 To dtFecalysis.Rows.Count - 2
                dr = dtFecalysis.Rows.Find(CDbl(dtFecalysis.Rows(ctr)(1).ToString()))
                If dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "HEMOGLOBIN" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtHemoglobin
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "HEMATOCRIT" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtHematocrit
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "LEUCOCYTE COUNT" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtLeucocyteCount
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Segmented Neutrophills" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtSegmentedNeutophilis
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Stabs" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtStabs
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Lymphocytes" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtLymphocytes
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Monocytes" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtMonocytes
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Eosinophills" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtEosinophilis
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Basophills" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtBasophilis
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "BLOOD TYPE/Rh TYPE" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = cmbBloodtype
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "PLATELET COUNT" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtPlateletCount
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "BLEEDING TIME" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtBleedingTime
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "CLOTTING TIME" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtClottingTime
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = " ESR(Erythrocyte Sedimentation Rate)" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtESR
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "MALARIAL PARASITE" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtMalarialPara
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Red Cell Count" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtRedCelllCount
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "OTHERS" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtOthers1
                End If
                If myFormStatus = enFormStatus.add Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = Nothing
                    myLaboratoryResultDetails.Save(True)
                Else
                    drLabResultDetails = dtLabResultDetails.Rows.Find(CDbl(dtLabResultDetails.Rows(ctr)(2).ToString()))
                    If drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "HEMOGLOBIN" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "HEMATOCRIT" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "LEUCOCYTE COUNT" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Segmented Neutrophills" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Stabs" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Lymphocytes" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Monocytes" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Eosinophills" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Basophills" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "BLOOD TYPE/Rh TYPE" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "PLATELET COUNT" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "BLEEDING TIME" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "CLOTTING TIME" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = " ESR(Erythrocyte Sedimentation Rate)" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "MALARIAL PARASITE" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "Red Cell Count" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(ctr)(3).ToString() = "OTHERS" Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                    End If
                    myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                    myLaboratoryResultDetails.Save(False)
                End If
            Next
        ElseIf labtype = 4 Then
            For ctr = 0 To dtFecalysis.Rows.Count - 1 ' laktaw sa index 9
                dr = dtFecalysis.Rows.Find(CDbl(dtFecalysis.Rows(ctr)(1).ToString()))
                If dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Fasting Blood Sugar" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtFBS
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Random Blood Sugar" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtRBS
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "2 Hrs PPBS" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtPPBS
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Serum Uric Acid" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtSUA
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Creatinine" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtCreatinine
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "ALT/SGPT" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtALTSGPT
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Cholesterol" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtCholesterol
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Triglyceride" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtTriglyceride
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "HDLM" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtHDL
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "LDL" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtLDL
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "HBA1c" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtHBAlc
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Amylase" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtAmylase
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Total Protein" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtTotallProtein
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Albumin" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtAlbumin1
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Globulin" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtGlobulin
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Lipase" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtLipase
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "AST/SGOT" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtAST
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Alkalaine Phos" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtAP
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "BUN(Urea)" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtBUN
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Sodium" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtSodium
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Potassium" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtPotassium
                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Calcium" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = txtCalcium

                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Total Bilirubin" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = bilirubin

                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Direct Bilirubin" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = Directbilirubin

                ElseIf dr IsNot Nothing And dtFecalysis.Rows(ctr)(2).ToString() = "Indirect Bilirubin" Then
                    myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                    myLaboratoryResultDetails.result = IndirectDirectbilirubin

                End If
                If myFormStatus = enFormStatus.add Then
                    If ctr <> 9 Then
                        myLaboratoryResultDetails.Oldlaboratoryresultid = Nothing
                        'myLaboratoryResultDetails.laboratoryresultid = myLaboratoryResult.laboratoryid
                        myLaboratoryResultDetails.Save(True)
                    End If
                Else
                    If ctr <> 9 Then
                        If ctr > 9 Then
                            drLabResultDetails = dtLabResultDetails.Rows.Find(CDbl(dtLabResultDetails.Rows(ctr - 1)(2).ToString()))
                            subCtr = ctr - 1
                        Else
                            drLabResultDetails = dtLabResultDetails.Rows.Find(CDbl(dtLabResultDetails.Rows(ctr)(2).ToString()))
                            subCtr = ctr
                        End If
                        If drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Fasting Blood Sugar" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Random Blood Sugar" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "2 Hrs PPBS" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Serum Uric Acid" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Creatinine" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "ALT/SGPT" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Cholesterol" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Triglyceride" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "HDLM" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "LDL" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "HBA1c" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Amylase" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Total Protein" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Albumin" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Globulin" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Lipase" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "AST/SGOT" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Alkalaine Phos" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "BUN(Urea)" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Sodium" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Potassium" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()
                            myLaboratoryResultDetails.Save(False)
                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Calcium" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()

                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Total Bilirubin" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()

                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Direct Bilirubin" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()

                        ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetails.Rows(subCtr)(3).ToString() = "Indirect Bilirubin" Then
                            myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                            myLaboratoryResultDetails.laboratoryresultid = LabID.Rows(0)(0).ToString()


                            myLaboratoryResultDetails.Save(False)
                        End If
                    End If
                End If
            Next
        Else
        End If
    End Sub
    Private Sub tmr()
        If isUsetoDashboard = False Then
            Me.ProgressBar1.Maximum = dtFecalysis.Rows.Count
        Else
            Me.ProgressBar1.Maximum = 10
        End If
        disposeFormTimer = 0
        Timer1.Start()
    End Sub
#End Region
#Region "Event/s"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        disposeFormTimer += 1
        If disposeFormTimer <= Me.ProgressBar1.Maximum Then
            ProgressBar1.Value = disposeFormTimer
        Else
            If isUsetoDashboard = False Then
                Call Save()
            End If
            Timer1.Stop()
            Me.Close()
        End If
    End Sub
    Private Sub frmProgressIndicator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isUsetoDashboard Then
            Me.Text = "Loading Drugs"
        End If
        tmr()
    End Sub
#End Region

    'Private Sub InitializeComponent()
    '    Me.components = New System.ComponentModel.Container()
    '    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
    '    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    '    Me.Label1 = New System.Windows.Forms.Label()
    '    Me.SuspendLayout()
    '    '
    '    'ProgressBar1
    '    '
    '    Me.ProgressBar1.Location = New System.Drawing.Point(12, 23)
    '    Me.ProgressBar1.Name = "ProgressBar1"
    '    Me.ProgressBar1.Size = New System.Drawing.Size(301, 18)
    '    Me.ProgressBar1.Step = 40
    '    Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
    '    Me.ProgressBar1.TabIndex = 3
    '    Me.ProgressBar1.Value = 1
    '    '
    '    'Label1
    '    '
    '    Me.Label1.AutoSize = True
    '    Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonShadow
    '    Me.Label1.Location = New System.Drawing.Point(240, 50)
    '    Me.Label1.Name = "Label1"
    '    Me.Label1.Size = New System.Drawing.Size(70, 13)
    '    Me.Label1.TabIndex = 4
    '    Me.Label1.Text = "Please wait..."
    '    '
    '    'frmProgressIndicator
    '    '
    '    Me.ClientSize = New System.Drawing.Size(327, 74)
    '    Me.ControlBox = False
    '    Me.Controls.Add(Me.ProgressBar1)
    '    Me.Controls.Add(Me.Label1)
    '    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    '    Me.Name = "frmProgressIndicator"
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()

    'End Sub
End Class