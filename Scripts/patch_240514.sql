/*
Deployment script for ecomed_240516
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ecomed_240516"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
USE [master]
GO
USE [$(DatabaseName)]
GO
PRINT N'Dropping [dbo].[spEMRWebService]...';


GO
DROP PROCEDURE [dbo].[spEMRWebService];


GO
PRINT N'Dropping [dbo].[emr_testrequestdetail]...';


GO
DROP TYPE [dbo].[emr_testrequestdetail];


GO
PRINT N'Altering [dbo].[laboratoryresult]...';


GO
ALTER TABLE [dbo].[laboratoryresult]
    ADD [esigvalidatedby] BIT    NULL,
        [verifiedby]      BIGINT NULL;


GO
PRINT N'Creating [dbo].[emr_testrequestdetail]...';


GO
CREATE TYPE [dbo].[emr_testrequestdetail] AS  TABLE (
    [testrequestdetailid] BIGINT        NOT NULL,
    [testrequestid]       BIGINT        NULL,
    [testid]              BIGINT        NULL,
    [isdaterequired]      BIT           NOT NULL,
    [daterequired]        DATETIME      NULL,
    [itemcode]            BIGINT        NULL,
    [remarks]             VARCHAR (255) NULL,
    [isdeleted]           BIT           NULL,
    [server_id]           BIGINT        NOT NULL);


GO
PRINT N'Creating [dbo].[emr_testrequestdetail_]...';


GO
CREATE TYPE [dbo].[emr_testrequestdetail_] AS  TABLE (
    [testrequestdetailid] BIGINT        NOT NULL,
    [testrequestid]       BIGINT        NULL,
    [testid]              BIGINT        NULL,
    [isdaterequired]      BIT           NOT NULL,
    [daterequired]        DATETIME      NULL,
    [itemcode]            VARCHAR (50)  NULL,
    [remarks]             VARCHAR (255) NULL,
    [isdeleted]           BIT           NULL,
    [server_id]           BIGINT        NOT NULL);


GO
PRINT N'Creating [dbo].[spEMRWebService]...';


GO

-- =============================================
-- Author:		Royette Camahalan
-- Create date: 2019-11-26
-- Description:	Manage Data Received From Server
-- Updated By: Royette 20220730 Fix issues with EMRWebservice
-- =============================================
--drop procedure [spEMRWebService];
CREATE PROCEDURE [dbo].[spEMRWebService]
	 @operation int=0
	,@soperation int=0
	,@search varchar(250)=''
	,@employeeid bigint=1405
	,@admissionid bigint=106158
	,@clinicID int=0
	,@isactive int=1
	,@requesttype int=0
	
	,@terminalcode varchar(250)=null
	,@terminaldesc varchar(250)=null
	,@terminaltype int=null
	,@devicetoken varchar(250)=null
	,@username varchar(20)='administrator'
	,@userpass varchar(200)='wBH4m6yDn3ZkG2qGa7BTOQ=='
	
	,@syncbatchcode varchar(100)=''
	,@emr_admissions emr_admissions READONLY
	,@emr_admissiondetails emr_admissiondetails READONLY
	,@emr_admissiondiagnosis emr_admissiondiagnosis READONLY
	,@emr_patientvitalsign emr_patientvitalsign READONLY
	,@emr_progressnotes emr_progressnotes READONLY
	,@emr_prescription emr_prescription READONLY
	,@emr_prescriptiondetails emr_prescriptiondetails READONLY
	,@emr_testrequest emr_testrequest READONLY
	,@emr_testrequestdetail emr_testrequestdetail READONLY
	,@keypair keypair READONLY
	,@conditions keypair READONLY
	
	,@tablename varchar(50)=''
	,@colname varchar(50)=''
	,@value varchar(2000)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF @operation=0
	BEGIN
		if @soperation=0
		begin
			select [terminalcode],[terminaldesc],[terminaltype],[isactive] from [terminals] s 
			where s.[terminalcode]=@search and isactive=1
		end
		else if @soperation=1
		begin
			SELECT e.[employeeid],e.[employeeno],e.[lastname],[firstname],[middlename],[address],[contactno]
				  ,e.[officecode],[email],[gender],[birthdate],[hiredate],[notes],[specialization],[designation]
				  ,e.[isactive],[proftype],[pan],[employeetypeid],[licenceno],[ptr],[proffee],[phic_accreditationno]
				  ,null [photo],[employeemasterid],[residential_address],[zipcode],[telephone_no]
				  ,e.[permanent_address_zipcode],[e_createdbyid],[e_datecreated],[e_updatedbyid],[e_dateupdated]
				  ,e.[mobileno],[religion],4 clinicid
			from users cu 
			inner join employees e on e.employeeid=cu.employeeid 
			where cu.username=@username and cu.userpass=@userpass and cu.isactive=1
		end
		else if @soperation=2
		begin
			select [routename],[description],[requesttype],[operation],[soperation],[tablename],[isactive] from [webserviceroute] s 
			where s.[routename]=@search and isactive=1 and requesttype=@requesttype
		end
		else if @soperation=3 --getpatients
		begin
			SELECT top 200 p.patientid, p.hospitalno, patientbarcode, lastname, firstname
			, middlename,suffixname, birthdate, gender, birthplace, homeaddress, bloodtype
			, obstetricalhistory, rl.religion, n.Nationality nationality, o.[description] occupation, civilstatus, philhealthno
			, sssno, gsisno, motherid, telephoneno, mobileno, emailaddress
			, mothername, fathername, allergies, familymedicalhistory, socialhistory, registrydate
			, registeredby, p.isactive, isnewborn, dependents, educationalprofile, socioeconomicprofile
			, income, company, businessaddress, oscaid,null photo, housenostreet
			, barangayid, glsalesaccount, patienttype, isphilhealthmember,1 issync, 0 clinicid
			, homeaddress completeaddress FROM patients p
			left join religion rl on rl.religionid=p.religion
			left join nationality n on n.NationalityCode=p.nationality
			left join occupation o on o.occupationid=p.occupation
			where ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%'
					and patienttype  = 1
					and p.isactive = @isactive
			order by p.LastName, p.firstname
		end
		else if @soperation=4 --getclinicpatientinformation
		begin
			SELECT p.patientid, p.hospitalno, patientbarcode, lastname, firstname
			, middlename,suffixname, birthdate, gender, birthplace, homeaddress, bloodtype
			, obstetricalhistory, rl.religion, n.Nationality nationality, o.[description] occupation, civilstatus, philhealthno
			, sssno, gsisno, motherid, telephoneno, mobileno, emailaddress
			, mothername, fathername, allergies, familymedicalhistory, socialhistory, registrydate
			, registeredby, p.isactive, isnewborn, dependents, educationalprofile, socioeconomicprofile
			, income, company, businessaddress, oscaid,null photo, housenostreet
			, barangayid, glsalesaccount, patienttype, isphilhealthmember,1 issync, 0 clinicid
			, homeaddress completeaddress FROM patients p
			left join religion rl on rl.religionid=p.religion
			left join nationality n on n.NationalityCode=p.nationality
			left join occupation o on o.occupationid=p.occupation
			where p.patientid=@search
		end
		else if @soperation=5 --getdiagnosis
		begin
			SELECT top 1000
			--diagnosisid,
			icd10code, diagnosisdesc, diagnosisclasscode, diagnosisspeccode, casetype, isactive, 
			isdefault, memo, createdbyid, datecreated, updatedbyid, dateupdated, 1 issync FROM 
			diagnosis
			where (icd10code like  '%'+@search+'%' or diagnosisdesc like  '%'+@search+'%')
			and isactive=@isactive
			order by icd10code
		end
		else if @soperation=6 --getdocumenttypes
		begin
			SELECT 
				--documenttypeid, 
				documetypeshortname, documetypename
				, coalesce(isactive,0) isactive
				, coalesce(isfavorite,0) isfavorite
				, coalesce(isphilhealth,0) isphilhealth, 1 issync FROM documenttype
				where isactive=@isactive
		end
		else if @soperation=7 --getlaboratory
		begin
			SELECT laboratoryid,[description], --laboratorycode, initialcopayment, ffcopaymentgov, ffcopaymentgprivate, 
			1 isactive, 1 issync,0 clinicid FROM laboratory
			--where isactive=@isactive
		end
		else if @soperation=8 --getPhysicianAdmissions
		begin
			SELECT top 100 p.lastname,p.firstname,p.middlename,p.suffixname,p.birthdate,p.gender
				 , a.admissionid, p.patientid, ptno, a.hospitalno, admissiontype, admissioncode, dateadmitted
				 , datedischarged, r.roomid, r.roomno, admittingphysicianid, attendingphysicianid, admissionstatus, mghdate
				 , informant, informantrelationship, familysize, notify, notifyrelationship, notifyaddress
				 , notifytelno, kindofoperation, memberphid, accreditationno, casetype, finaldiagnosis
				 , admittingdiagnosis, historyofpresentillness, physicalexamination, courseinthewards
				 , conditionondischarge, sodatetime, soanesthesiologist, soanethesiatype, sosurgeonname, reference
				 , isdischarge, hospitalplan, philhealthcasetype, encodedby, dateencoded, isadmitpatient, a.startdate
				 , dateended, reasonforadmission, admittingimpression, familyhistory, pasthistory, pastillness
				 , chiefcomplaints, packagecaseno, packagecaseno2, dischargestatus, referral, dateofdeath
				 , reasonrefferalno, istransmitted, isphicmember, referringhciid, referralhcid, memo, cf2purchasemeds
				 , cf2expenselabs, reltophicmember,1 issync, 0 clinicid,referringreason,cataractapplicationno
				 , assessment, [plan]
				  FROM patients p
				   inner join admissions a on a.patientid=p.patientid
				   left join rooms r on r.roomid=a.roomid
				   left join admissiondoctor ad on ad.admissionid=a.admissionid and ad.doctorid=@employeeid
			WHERE (ad.doctorid=@employeeid or a.admittingphysicianid=@employeeid or a.attendingphysicianid=@employeeid) AND --commented by royette 20200609
				  (ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%') AND
				  (@isactive=0 or (admissionstatus=0 and @isactive=1) or (admissionstatus=1 and @isactive=2) or (admissionstatus=2 and @isactive=3))
			order by a.admissionid desc
		end
		else if @soperation=9 --getAdmissionDetails
		begin
			SELECT top 1 p.patientid, p.hospitalno, p.lastname, p.firstname
			, p.middlename,p.suffixname, p.birthdate, p.gender, p.birthplace, p.homeaddress, p.bloodtype
			, p.obstetricalhistory, coalesce(n.Nationality, '') Nationality 
			, coalesce(oc.description, '') occupation
			, coalesce(r.religion, '') religion , p.civilstatus, p.philhealthno
			, p.sssno, p.gsisno, p.motherid, p.telephoneno, p.mobileno, p.emailaddress
			, p.mothername, p.fathername, p.allergies, p.familymedicalhistory, p.socialhistory, p.registrydate
			, p.registeredby, p.isactive, p.isnewborn, p.dependents, p.educationalprofile, p.socioeconomicprofile
			, p.income, p.company, p.businessaddress, p.oscaid,null photo, p.housenostreet
			, p.barangayid, p.glsalesaccount, p.patienttype, p.isphilhealthmember,1 issync, 0 clinicid
			, p.homeaddress completeaddress
			, a.*,ad.*
			, 'Dr. '+e.firstname+' '+e.middlename+' '+e.lastname+' '+coalesce(e.extensioname,'') admittingphysicianname
			, 'Dr. '+e1.firstname+' '+e1.middlename+' '+e1.lastname+' '+coalesce(e1.extensioname,'') attendingphysicianname
			, coalesce(o.officedescription, '') officedescription
			, r2.roomno
			FROM patients p 
			inner join admissions a on p.patientid = a.patientid 
			inner join admissiondetails ad on ad.admissionid = a.admissionid
			inner join employees e on e.employeeid=a.admittingphysicianid
			inner join employees e1 on e1.employeeid=a.attendingphysicianid
			left join offices o on o.officecode = ad.officecode
			left join nationality n on n.NationalityCode = p.nationality
			left join religion r on r.religionid = p.religion
			left join occupation oc on oc.occupationid = p.occupation
			left join rooms r2 on r2.roomid=a.roomid
			where a.admissionid = @search
		end
		else if @soperation=10 --getadmissionvitalsigns
		begin
			SELECT a.chiefcomplaints
			,a.physicalexamination
			,a.admittingdiagnosis
			,a.assessment
			,a.[plan]
			--,0 patientvitalsignid
			,coalesce(p.admissionid,0) admissionid,
			bloodpressure,breathing,pulse,temperature,height,weight,heent,chest,cvs,Abdomen,skinextremities,
			neuroexamination,gu,0 issync,coalesce(alteredmentalsensorium,0) alteredmentalsensorium,
			coalesce(abdominalcramp_pain,0) abdominalcramp_pain,coalesce(abdominaldistention,0) abdominaldistention,
			coalesce(anemia,0) anemia,coalesce(anorexia,0) anorexia,coalesce(breathlessness,0) breathlessness,
			coalesce(bleedinggums,0) bleedinggums,coalesce(bodyweakness,0) bodyweakness,coalesce(blurringofvision,0) blurringofvision,
			coalesce(constipation,0) constipation,coalesce(chestpain_discomfort,0) chestpain_discomfort,coalesce(chills,0) chills,
			coalesce(cough_dry,0) cough_dry,coalesce(cough_productive,0) cough_productive,coalesce(diarrhea,0) diarrhea,
			coalesce(dizziness,0) dizziness,coalesce(drowsiness,0) drowsiness,coalesce(dysphagia,0) dysphagia,
			coalesce(dyspnea,0) dyspnea,coalesce(dysuria,0) dysuria,coalesce(epigastricpain,0) epigastricpain,
			coalesce(epistaxis,0) epistaxis,coalesce(fatigue,0) fatigue,coalesce(fever,0) fever,
			coalesce(flankpain,0) flankpain,coalesce(frequencyofurination,0) frequencyofurination,coalesce(headache,0) headache,
			coalesce(hematemesis,0) hematemesis,coalesce(hematuria,0) hematuria,coalesce(hemoptysis,0) hemoptysis,
			coalesce(hypogastricsuprapubicpain,0) hypogastricsuprapubicpain,coalesce(increaseirritability,0) increaseirritability,
			coalesce(jaundice,0) jaundice,coalesce(lethargic,0) lethargic,coalesce(legcrampsorpain,0) legcrampsorpain,
			coalesce(lowerextremityedema,0) lowerextremityedema,coalesce(lowerbackpain,0) lowerbackpain,coalesce(myalgia,0) myalgia,
			coalesce(napepain,0) napepain,coalesce(nausea,0) nausea,coalesce(orthopnea,0) orthopnea,
			coalesce(palpitations,0) palpitations,coalesce(photophobia,0) photophobia,coalesce(shortnessofbreath,0) shortnessofbreath,
			coalesce(skinrashes,0) skinrashes,coalesce(stool_bloody_blacktarry_mucoid,0) stool_bloody_blacktarry_mucoid,
			coalesce(stool_soft_watery,0) stool_soft_watery,coalesce(sweating,0) sweating,coalesce(syncope,0) syncope,
			coalesce(seizures,0) seizures,coalesce(urgency,0) urgency,coalesce(vomiting,0) vomiting,coalesce(weightloss,0) weightloss,
			coalesce(wheezes,0) wheezes,others,coalesce(survey_awakeandalert,0) survey_awakeandalert,survey_alteredsensorium,
			coalesce(heent_essentiallynormal,0) heent_essentiallynormal,
			coalesce(heent_abnormalpupillaryreaction,0) heent_abnormalpupillaryreaction,
			coalesce(heent_cervicallympadenopathy,0) heent_cervicallympadenopathy,coalesce(heent_drymucousmembrane,0) heent_drymucousmembrane,
			coalesce(heent_ictericsclerae,0) heent_ictericsclerae,coalesce(heent_paleconjunctivae,0) heent_paleconjunctivae,
			coalesce(heent_sunkeneyeballs,0) heent_sunkeneyeballs,coalesce(heent_sunkenfontanelle,0) heent_sunkenfontanelle,
			coalesce(chest_essentiallynormal,0) chest_essentiallynormal,coalesce(chest_asymmetricalexpansion,0) chest_asymmetricalexpansion,
			coalesce(chest_decreasedbreathsounds,0) chest_decreasedbreathsounds,coalesce(chest_wheezes,0) chest_wheezes,
			coalesce(chest_lumpsoverbreast,0) chest_lumpsoverbreast,coalesce(chest_ralescracklesrhonchi,0) chest_ralescracklesrhonchi,
			coalesce(chest_intercostalribretraction,0) chest_intercostalribretraction,coalesce(cvs_essentiallynormal,0) cvs_essentiallynormal,
			coalesce(cvs_bradycardia,0) cvs_bradycardia,coalesce(cvs_displacedapexbeat,0) cvs_displacedapexbeat,
			coalesce(cvs_heaves,0) cvs_heaves,coalesce(cvs_irregularrhythm,0) cvs_irregularrhythm,
			coalesce(cvs_muffledheartsounds,0) cvs_muffledheartsounds,coalesce(cvs_murmur,0) cvs_murmur,
			coalesce(cvs_pericardialbulge,0) cvs_pericardialbulge,coalesce(cvs_tachycardia,0) cvs_tachycardia,
			coalesce(cvs_thrills,0) cvs_thrills,coalesce(abdomen_essentiallynormal,0) abdomen_essentiallynormal,
			coalesce(abdomen_abdominalrigidity,0) abdomen_abdominalrigidity,
			coalesce(abdomen_abdominaltenderness,0) abdomen_abdominaltenderness,
			coalesce(abdomen_hyperactivebowelsounds,0) abdomen_hyperactivebowelsounds,
			coalesce(abdomen_palpablemass,0) abdomen_palpablemass,
			coalesce(abdomen_tympaniticdullabdomen,0) abdomen_tympaniticdullabdomen,
			coalesce(abdomen_uterinecontraction,0) abdomen_uterinecontraction,
			coalesce(gu_essentiallynormal,0) gu_essentiallynormal,
			coalesce(gu_bloodstainedfinger,0) gu_bloodstainedfinger,
			coalesce(gu_cervicaldilatation,0) gu_cervicaldilatation,
			coalesce(gu_presenceofabnormaldischarge,0) gu_presenceofabnormaldischarge,
			coalesce(skin_essentiallynormal,0) skin_essentiallynormal,
			coalesce(skin_clubbing,0) skin_clubbing,
			coalesce(skin_coldclammy,0) skin_coldclammy,
			coalesce(skin_cyanosis,0) skin_cyanosis,
			coalesce(skin_edema,0) skin_edema,
			coalesce(skin_muscles,0) skin_muscles,
			coalesce(skin_palenailbeds,0) skin_palenailbeds,
			coalesce(skin_poorskinturgor,0) skin_poorskinturgor,
			coalesce(skin_rashespetechiae,0) skin_rashespetechiae,
			coalesce(skin_swelling,0) skin_swelling,
			coalesce(skin_weakpulses,0) skin_weakpulses,
			coalesce(neuro_essentiallynormal,0) neuro_essentiallynormal,
			coalesce(neuro_abnormalgait,0) neuro_abnormalgait,
			coalesce(neuro_abnormalposition,0) neuro_abnormalposition,
			coalesce(neuro_abnormalsensation,0) neuro_abnormalsensation,
			coalesce(neuro_presenceofabnormalreflex,0) neuro_presenceofabnormalreflex,
			coalesce(neuro_pooralteredmemory,0) neuro_pooralteredmemory,
			coalesce(neuro_poormuscletone,0) neuro_poormuscletone,
			coalesce(neuro_poorcoordination,0) neuro_poorcoordination,bpdiastolic,pain,
			null created_at,null updated_at
			--,p.batchcode  
			from admissions a left join patientvitalsign p
  			on a.admissionid = p.admissionid where a.admissionid = @search
		end
		else if @soperation=11 --getadmissiondiagnosis
		begin
			SELECT admissiondiagnosisid, admissionid, icd10code, isprimarydiagnosis, diagnosis, isprocedure, 
			dateofprocedure, laterality, csindication, createdbyid, createddate, updatedbyid, updateddate
			,isdeleted  
			from admissiondiagnosis 
			where coalesce(isdeleted,0) = 0 and 
			admissionid = @search
		end
		else if @soperation=12 --getadmissionprogressnotes
		begin
			--SELECT progressnoteid, admissionid, progressdate, notes, medicalorder, carried, administered
			--, requested, endorsed, discontinued, isdeleted,null created_at,null updated_at 
			--, coalesce(iscourseward,0) iscourseward, coalesce(prescriptionid,0) prescriptionid
			--, coalesce(testrequestid,0) testrequestid
			--from progressnotes where coalesce(isdeleted,0) = 0 and admissionid = @search and 
			--((coalesce(iscourseward,0)=@isactive) or (@isactive=2))
			SELECT pn.progressnoteid, pn.admissionid, pn.progressdate, pn.notes
				,case when coalesce(pd.prescriptionid,0)>0 then
						coalesce(i.itemdescription,pd.drugcode) + ' ' +
						case when coalesce(f.frequencyid,0)=0 then '' else f.frequencyname + ' ' end +
						case when coalesce(pd.dosage,'')='' then '' else pd.dosage + ' ' end +
						case when pd.period=0 then ''
							else
								'x ' + convert(varchar(10),pd.period) + ' ' + 
								case pd.per when 3 then 'mons' when 2 then 'weeks' else 'days' end end
								+ 
								case when pd.quantity>0 then ' #' + convert(varchar(10),pd.quantity) else '' end
					when coalesce(td.testrequestid,0)>0 then
						coalesce(i2.itemdescription,cast(td.itemcode AS varchar))
					else pn.medicalorder end medicalorder, pn.carried, pn.administered
			, pn.requested, pn.endorsed, pn.discontinued, pn.isdeleted,null created_at,null updated_at 
			, coalesce(pn.iscourseward,0) iscourseward, coalesce(pn.prescriptionid,0) prescriptionid
			, coalesce(pn.testrequestid,0) testrequestid
			from progressnotes pn
			left join prescriptiondetails pd on pd.drugcode=pn.medicalorder and pd.prescriptionid=pn.prescriptionid
			left join testrequestdetail td on cast(td.itemcode AS varchar)=pn.medicalorder and td.testrequestid=pn.testrequestid
			left join items i on cast(i.itemcode AS varchar)=pd.drugcode
			left join items i2 on i2.itemcode=td.itemcode
			left join frequency f on f.frequencyid=pd.frequency
			where coalesce(pn.isdeleted,0) = 0 and pn.admissionid = @search and 
			((coalesce(iscourseward,0)=@isactive) or (@isactive=2))
		end
		else if @soperation=13 --getprogressnotedetails
		begin
			SELECT progressnoteid, admissionid, progressdate, notes, medicalorder, carried, administered
			, requested, endorsed, discontinued, isdeleted,null created_at,null updated_at 
			from progressnotes where progressnoteid = @search
		end
		else if @soperation=16 --getadmissiondocuments
		begin
			SELECT ad.admissiondocumentid documentid, ad.admissionid, ad.documentcode, ad.documentlocation
			, ad.documentname, ad.documenturl, '' remarks
			, ad.datecreated created_at,null updated_at
			, ad.isdeleted, coalesce(i.itemdescription,dt.documetypename) documetypename,ad.laboratoryid,l.[description] laboratorydescription
			, ad.testresulttype,ad.testresultdate,ad.documentdescription,pr.daterequested
			FROM admissiondocuments ad 
			inner join documenttype dt on dt.documetypeshortname =  ad.documenttype 
			left join laboratory l on l.laboratoryid=ad.laboratoryid
			left join patientrequestdetails prd on prd.patientrequestdetailno=ad.documentcode
			left join patientrequest pr on pr.patientrequestno=prd.patientrequestno
			left join items i on i.itemcode=prd.itemcode
			where coalesce(isdeleted,0) = 0 and 
			ad.admissionid = @search
		end
		else if @soperation=17 --check documenttype
		begin
			SELECT * FROM documenttype 
			where documetypeshortname = @search
		end
		else if @soperation=18 --check admissiondocuments result
		begin
			SELECT admissiondocumentid,admissionid FROM admissiondocuments where admissiondocumentid=@search
		end
		else if @soperation=19 --getprescriptions
		begin
			SELECT p.prescriptionid, p.admissionid, p.[description], p.[date], p.physician, p.name, p.istemplate
				 , p.refpatientrequestno, p.isdeleted pisdeleted, p.datecreated pcreated_at, p.dateupdated pupdated_at
				 , pd.presecriptiondetailsid,  pd.drugcode, pd.quantity, pd.dosage, pd.period, pd.per, pd.isdeleted
				 , pd.datecreated, pd.dateupdated , coalesce(i.itemdescription,pd.drugcode) itemdescription
				 , pd.frequency, f.[description] frequencydescription
			FROM prescription p 
			inner join prescriptiondetails pd  on p.prescriptionid = pd.prescriptionid 
			left join items i on i.itemcode = pd.drugcode
			left join frequency f on f.frequencyid=pd.frequency
			where coalesce(pd.isdeleted,0) = 0 and 
			p.admissionid = @search
		end
		else if @soperation=20 --getappointments
		begin
			if @clinicid=0
			begin
				select @clinicid=id from clinics where is_default=1
			end
			SELECT A.[id]
				  ,a.sequenceno
				  ,p.patientid
				  ,P.hospitalno
				  ,P.lastname + ', ' +P.firstname +' '+COALESCE(P.suffixname,'')+' '+ COALESCE(P.middlename,'') AS [patient]
				  ,a.consultdate
				  ,COALESCE(A.consulttime,'') consulttime
				  ,commentdoctor
				  ,commentpatient
				  ,is_approved_doctor
				  ,is_approved_patient
				  ,is_done
					,case when DATEDIFF(yy, p.birthdate, GETDATE()) - CASE WHEN (MONTH(p.birthdate) > MONTH(GETDATE())) OR (MONTH(p.birthdate) = MONTH(GETDATE()) AND DAY(p.birthdate) > DAY(GETDATE())) THEN 1 ELSE 0 END> 0
					then  convert(varchar(10),DATEDIFF(yy, p.birthdate, GETDATE()) - CASE WHEN (MONTH(p.birthdate) > MONTH(GETDATE())) OR (MONTH(p.birthdate) = MONTH(GETDATE()) AND DAY(p.birthdate) > DAY(GETDATE())) THEN 1 ELSE 0 END)+'Y '+
						  convert(varchar(10),DATEDIFF(m, DATEADD(yy, DATEDIFF(yy, p.birthdate, GETDATE()) - CASE WHEN (MONTH(p.birthdate) > MONTH(GETDATE())) OR (MONTH(p.birthdate) = MONTH(GETDATE()) AND DAY(p.birthdate) > DAY(GETDATE())) THEN 1 ELSE 0 END, p.birthdate), GETDATE()) - CASE WHEN DAY(p.birthdate) > DAY(GETDATE()) THEN 1 ELSE 0 END)+'M'													
					when floor(datediff(DAY,p.birthdate,getdate()))> 31
					then convert(varchar(10),DATEDIFF(m, p.birthdate, GETDATE()) - CASE WHEN DAY(p.birthdate) > DAY(GETDATE()) THEN 1 ELSE 0 END)+'M '+
					   convert(varchar(10),datediff(DAY,DATEADD(m, DATEDIFF(m, p.birthdate, GETDATE()) - CASE WHEN DAY(p.birthdate) > DAY(GETDATE()) THEN 1 ELSE 0 END, p.birthdate),getdate()))+' Days'  
					else
						convert(varchar(10),datediff(DAY,p.birthdate,getdate()))+' Days'   
					end Age
				  ,c.name clinicname
			  FROM [appointments] A
			  INNER JOIN patients P ON P.patientid=A.patientid
			  INNER JOIN clinics c on c.id=a.clinicid
			  WHERE A.is_done=0 and A.doctorid=@employeeid and a.clinicid=@clinicID and
				(
					(A.is_approved_doctor=1 and A.is_approved_patient=1 and a.consultdate=convert(date,GETDATE()) and @isactive=0)
					or
					(A.is_approved_doctor=1 and A.is_approved_patient=1 and a.consultdate>convert(date,GETDATE()) and @isactive=1)
					or
					(A.is_approved_doctor=1 and A.is_approved_patient=0 and a.consultdate>=convert(date,GETDATE()) and @isactive=3)
				)
			  AND (ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%' OR
				   A.consultdate Like '%'+@search+'%' OR A.consulttime Like '%'+@search+'%' OR
				   A.id Like '%'+@search+'%')
		end
		
		else if @soperation=21 --getemployeeinfo
		begin
			SELECT e.employeeid,e.employeeno,e.lastname,e.firstname,e.middlename,e.extensioname,e.gender
				  ,e.permanentaddress,e.religion,e.permanent_address_zipcode
				  ,e.telephone_no,e.residential_address,e.zipcode
				  ,e.telephone_no residential_tel_no,e.birthdate,e.placeofbirth,e.mobileno,e.email,e.designation
				  ,e.citizenship,e.notes,e.officecode,e.employeetypeid,0 monthly_salary,e.phic_accreditationno
				  ,e.dailyvisitrate,e.proffee,e.ptr,e.licenceno,e.proftype,0 sub_specialtyid
				  ,e.specialization,e.isactive,null photo,null sig_photo,e.e_createdbyid createdbyid
				  ,e.e_datecreated datecreated,e.e_updatedbyid updatedbyid,e.e_dateupdated dateupdated, 1 issync 
				  from employees e
				where e.employeeid=@search
		end
		else if @soperation=22 --getitems
		begin
			SELECT itemcode, itembarcode, retailitemcode, itemcatcode, itemdescription
				, supplierno, unitcode, drugcode, drugdescription
				, isactive, createdbyid, createddate
				, updatedbyid, createddate, price1, price2, price3, costmethod, glsalesacct
				, glinventoryacct, glcostofsalesacct, ispurchaseitem
				, issalesitem, 1 issync
				, itemspecs 
				FROM items where itemcatcode='1' and isactive=1 and
				(itemdescription like '%' + @search + '%')
		end
		else if @soperation=23 --gethospitalinformation
		begin
			SELECT [infono],[HospName],TradeName,[NoStreet],[Barangay],[MunCity],[Province]
						  ,[region],[ZipCode],[philhealthaccredno]
						  ,null [hospitallogo],[Telephone],faxno,emailaddress
				   FROM [dbo].[hospitalinformation]
		end
		else if @soperation=24 --getPhysicianOPDAdmissions
		begin
			SELECT top 100 p.lastname,p.firstname,p.middlename,p.suffixname,p.birthdate,p.gender
				 , a.admissionid, p.patientid, ptno, a.hospitalno, admissiontype, admissioncode, dateadmitted
				 , datedischarged, r.roomid, r.roomno, admittingphysicianid, attendingphysicianid, admissionstatus, mghdate
				 , informant, informantrelationship, familysize, notify, notifyrelationship, notifyaddress
				 , notifytelno, kindofoperation, memberphid, accreditationno, casetype, finaldiagnosis
				 , admittingdiagnosis, historyofpresentillness, physicalexamination, courseinthewards
				 , conditionondischarge, sodatetime, soanesthesiologist, soanethesiatype, sosurgeonname, reference
				 , isdischarge, hospitalplan, philhealthcasetype, encodedby, dateencoded, isadmitpatient, a.startdate
				 , dateended, reasonforadmission, admittingimpression, familyhistory, pasthistory, pastillness
				 , chiefcomplaints, packagecaseno, packagecaseno2, dischargestatus, referral, dateofdeath
				 , reasonrefferalno, istransmitted, isphicmember, referringhciid, referralhcid, memo, cf2purchasemeds
				 , cf2expenselabs, reltophicmember,1 issync, 0 clinicid,referringreason,cataractapplicationno
				 , assessment, [plan]
				  FROM patients p
				   inner join admissions a on a.patientid=p.patientid
				   left join rooms r on r.roomid=a.roomid
				   left join admissiondoctor ad on ad.admissionid=a.admissionid and ad.doctorid=@employeeid
			WHERE (ad.doctorid=@employeeid or a.admittingphysicianid=@employeeid or a.attendingphysicianid=@employeeid) AND  --commented by royette 20200609
				 (ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%')
				 AND ((convert(varchar,dateadmitted,23)=convert(varchar,getdate(),23) and @isactive=1) or (convert(varchar,dateadmitted,23)<convert(varchar,getdate(),23) and @isactive=3))
			AND a.admissiontype='OPD'
			order by a.admissionid desc
		end
		else if @soperation=25 --getPhysicianIPDAdmissions
		begin
			SELECT top 100 p.lastname,p.firstname,p.middlename,p.suffixname,p.birthdate,p.gender
				 , a.admissionid, p.patientid, ptno, a.hospitalno, admissiontype, admissioncode, dateadmitted
				 , datedischarged, r.roomid, r.roomno, admittingphysicianid, attendingphysicianid, admissionstatus, mghdate
				 , informant, informantrelationship, familysize, notify, notifyrelationship, notifyaddress
				 , notifytelno, kindofoperation, memberphid, accreditationno, casetype, finaldiagnosis
				 , admittingdiagnosis, historyofpresentillness, physicalexamination, courseinthewards
				 , conditionondischarge, sodatetime, soanesthesiologist, soanethesiatype, sosurgeonname, reference
				 , isdischarge, hospitalplan, philhealthcasetype, encodedby, dateencoded, isadmitpatient, a.startdate
				 , dateended, reasonforadmission, admittingimpression, familyhistory, pasthistory, pastillness
				 , chiefcomplaints, packagecaseno, packagecaseno2, dischargestatus, referral, dateofdeath
				 , reasonrefferalno, istransmitted, isphicmember, referringhciid, referralhcid, memo, cf2purchasemeds
				 , cf2expenselabs, reltophicmember,1 issync, 0 clinicid,referringreason,cataractapplicationno
				 , assessment, [plan]
				  FROM patients p
				   inner join admissions a on a.patientid=p.patientid
				   left join rooms r on r.roomid=a.roomid
				   left join admissiondoctor ad on ad.admissionid=a.admissionid and ad.doctorid=@employeeid
			WHERE (ad.doctorid=@employeeid or a.admittingphysicianid=@employeeid or a.attendingphysicianid=@employeeid) AND  --commented by royette 20200609
				 (ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%') AND
				 (@isactive=0 or (admissionstatus=0 and @isactive=1) or (admissionstatus=1 and @isactive=2) or (admissionstatus=2 and @isactive=3)) AND 
				 a.admissiontype='IPD'
			order by a.admissionid desc
		end
		else if @soperation=26 --getPhysicianERAdmissions
		begin
			SELECT top 100 p.lastname,p.firstname,p.middlename,p.suffixname,p.birthdate,p.gender
				 , a.admissionid, p.patientid, ptno, a.hospitalno, admissiontype, admissioncode, dateadmitted
				 , datedischarged, r.roomid, r.roomno, admittingphysicianid, attendingphysicianid, admissionstatus, mghdate
				 , informant, informantrelationship, familysize, notify, notifyrelationship, notifyaddress
				 , notifytelno, kindofoperation, memberphid, accreditationno, casetype, finaldiagnosis
				 , admittingdiagnosis, historyofpresentillness, physicalexamination, courseinthewards
				 , conditionondischarge, sodatetime, soanesthesiologist, soanethesiatype, sosurgeonname, reference
				 , isdischarge, hospitalplan, philhealthcasetype, encodedby, dateencoded, isadmitpatient, a.startdate
				 , dateended, reasonforadmission, admittingimpression, familyhistory, pasthistory, pastillness
				 , chiefcomplaints, packagecaseno, packagecaseno2, dischargestatus, referral, dateofdeath
				 , reasonrefferalno, istransmitted, isphicmember, referringhciid, referralhcid, memo, cf2purchasemeds
				 , cf2expenselabs, reltophicmember,1 issync, 0 clinicid,referringreason,cataractapplicationno
				 , assessment, [plan]
				  FROM patients p
				   inner join admissions a on a.patientid=p.patientid
				   left join rooms r on r.roomid=a.roomid
				   left join admissiondoctor ad on ad.admissionid=a.admissionid and ad.doctorid=@employeeid
			WHERE (ad.doctorid=@employeeid or a.admittingphysicianid=@employeeid or a.attendingphysicianid=@employeeid) AND --commented by royette 20200609
				 (ltrim(p.LastName) +','+ p.firstname like   replace(@search,', ',',')+'%') AND
				 (@isactive=0 or (admissionstatus=0 and @isactive=1) or (admissionstatus=1 and @isactive=2) or (admissionstatus=2 and @isactive=3))
				  AND a.admissiontype='ER'
			order by a.admissionid desc
		end
		else if @soperation=27 --getpatientadmissions
		begin
			SELECT p.lastname,p.firstname,p.middlename,p.suffixname,p.birthdate,p.gender
				 , a.admissionid, p.patientid, ptno, a.hospitalno, admissiontype, admissioncode, dateadmitted
				 , datedischarged, r.roomid, r.roomno, admittingphysicianid, attendingphysicianid, admissionstatus, mghdate
				 , informant, informantrelationship, familysize, notify, notifyrelationship, notifyaddress
				 , notifytelno, kindofoperation, memberphid, accreditationno, casetype, finaldiagnosis
				 , admittingdiagnosis, historyofpresentillness, physicalexamination, courseinthewards
				 , conditionondischarge, sodatetime, soanesthesiologist, soanethesiatype, sosurgeonname, reference
				 , isdischarge, hospitalplan, philhealthcasetype, encodedby, dateencoded, isadmitpatient, startdate
				 , dateended, reasonforadmission, admittingimpression, familyhistory, pasthistory, pastillness
				 , chiefcomplaints, packagecaseno, packagecaseno2, dischargestatus, referral, dateofdeath
				 , reasonrefferalno, istransmitted, isphicmember, referringhciid, referralhcid, memo, cf2purchasemeds
				 , cf2expenselabs, reltophicmember,1 issync, 0 clinicid,referringreason,cataractapplicationno
				 , assessment, [plan]
				 , 'Dr. '+e.firstname+' '+e.middlename+' '+e.lastname+' '+coalesce(e.extensioname,'') admittingphysicianname
				 , 'Dr. '+e1.firstname+' '+e1.middlename+' '+e1.lastname+' '+coalesce(e1.extensioname,'') attendingphysicianname
				  FROM patients p
					inner join admissions a on a.patientid=p.patientid
					left join employees e on e.employeeid=a.admittingphysicianid
					left join employees e1 on e1.employeeid=a.attendingphysicianid
					left join rooms r on r.roomid=a.roomid
			WHERE p.patientid=@search
			order by a.admissionid desc
		end
		else if @soperation=28 --getspecificprescriptiondetail
		begin
			SELECT p.prescriptionid, p.admissionid, p.[description], p.[date], p.physician, p.name, p.istemplate
				 , p.refpatientrequestno, p.isdeleted pisdeleted, p.datecreated pcreated_at, p.dateupdated pupdated_at
				 , pd.presecriptiondetailsid,  pd.drugcode, pd.quantity, pd.dosage, pd.period, pd.per, pd.isdeleted
				 , pd.datecreated, pd.dateupdated , coalesce(i.itemdescription,pd.drugcode)itemdescription
				 , pd.frequency, f.[description] frequencydescription
			FROM prescription p 
			inner join prescriptiondetails pd  on p.prescriptionid = pd.prescriptionid 
			left join items i on cast(i.itemcode AS varchar) = pd.drugcode
			left join frequency f on f.frequencyid=pd.frequency
			where pd.presecriptiondetailsid = @search
		end
		else if @soperation=29 --getfrequency
		begin
			SELECT [frequencyid],[frequencyname],[description],[per],[days],[isactive]
				  ,[issync],[createdbyid],[datecreated],[updatedbyid],[dateupdated]
				  ,[server_id]
			  FROM [frequency] 
			  where [isactive]=1
			  order by [frequencyname]
		end
		
		
		else if @soperation=30 --get table type schema
		begin
			SELECT c.name,c.column_id FROM sys.columns c
			JOIN sys.table_types tt ON c.[object_id] = tt.type_table_object_id 
			WHERE tt.name = @search
		end
		------Start Of getting batchcodes
		else if @soperation=31 --get admissions batch
		begin
			SELECT local_id,admissionid as server_id FROM admissions where syncbatchcode=@search
		end
		else if @soperation=32 --get admissiondetails batch
		begin
			SELECT admissionid as local_id,admissionid as server_id FROM admissiondetails where syncbatchcode=@search
		end
		else if @soperation=33 --get admissionddiagnosis batch
		begin
			SELECT local_id,admissiondiagnosisid as server_id FROM admissiondiagnosis where syncbatchcode=@search
		end
		else if @soperation=34 --get patient vital signs batch
		begin
			SELECT admissionid as local_id,admissionid as server_id FROM patientvitalsign where syncbatchcode=@search
		end
		else if @soperation=35 --get progressnotes batch
		begin
			SELECT local_id,progressnoteid as server_id FROM progressnotes where syncbatchcode=@search
		end
		else if @soperation=36 --get prescription batch
		begin
			SELECT local_id,prescriptionid as server_id FROM prescription where syncbatchcode=@search
		end
		else if @soperation=37 --get prescription details batch
		begin
			SELECT local_id,presecriptiondetailsid as server_id FROM prescriptiondetails where syncbatchcode=@search
		end
		else if @soperation=38 --get admissiondiagnosis batch
		begin
			SELECT admissiondocumentid,admissionid FROM admissiondocuments where syncbatchcode=@search
		end
		else if @soperation=39 --get generatemedicalorder rx
		begin
			exec [spProgressNotes] @operation=0,@soperation=2, @search=@search
		end
		else if @soperation=40 --generate patient request
		begin
			exec [spPatientRequisition] @operation=1,@soperation=2,@search=@search
		end
		else if @soperation=41 --get generatemedicalorderdiagnostic test request
		begin
			exec [spProgressNotes] @operation=0,@soperation=3, @search=@search
		end
		else if @soperation=42 --generate patient request for test request
		begin
			exec [spPatientRequisition] @operation=1,@soperation=3,@search=@search
		end
		else if @soperation=43 --getitemlisting for test request
		begin
			declare @trackinventory bit
			select @trackinventory=coalesce(trackinventory,0) from hospitalinformation
			--exec spInventory @operation=3,@officecode=@search, @isphic=0, @trackinventory=@trackinventory ----deprecated moved to sphischarges 0/6 220708 by sir toni
			exec spHISCharges @operation=0,@soperation=6,@officecode=@search
		end
		else if @soperation=44 --gettestrequestoffices for test request
		begin
			exec [spPatientRequisition] @operation=0,@soperation=9
		end
		else if @soperation=45 --getofficedetails
		begin
			select officecode, officedescription from offices where officecode=@search or officedescription=@search
		end
		else if @soperation=46 --getitemdetails
		begin
			SELECT itemcode, itembarcode, retailitemcode, itemcatcode, itemdescription
				, supplierno, unitcode, drugcode, drugdescription
				, isactive, createdbyid, createddate
				, updatedbyid, createddate, price1, price2, price3, costmethod, glsalesacct
				, glinventoryacct, glcostofsalesacct, ispurchaseitem
				, issalesitem, 1 issync
				, itemspecs 
				FROM items where cast(itemcode as varchar)=@search or itemdescription=@search
		end
		else if @soperation=47 --get testrequest batch
		begin
			SELECT local_id,testrequestid as server_id FROM testrequest where syncbatchcode=@search
		end
		else if @soperation=48 --get testrequest details batch
		begin
			SELECT local_id,testrequestdetailid as server_id FROM testrequestdetail where syncbatchcode=@search
		end
		
		
		else if @soperation=60 --getclinics
		begin
			SELECT [id],[cliniccode],[name],[contact_no]
			FROM [dbo].[clinics]
			order by [name]
		end
		else if @soperation=61 --check terminal
		begin
			SELECT * from terminals where terminalcode=@search
		end
		else if @soperation=62 --getprescriptionmasters
		begin
			SELECT p.prescriptionid, p.admissionid, p.[description], p.[date], p.physician, p.name, p.istemplate
				 , p.refpatientrequestno, p.isdeleted pisdeleted, p.datecreated pcreated_at, p.dateupdated pupdated_at
				 , (select 
						' ' + coalesce(i.itemdescription,pd.drugcode) + ' ' +
						case when coalesce(f.frequencyid,0)=0 then '' else f.frequencyname + ' ' end +
						case when coalesce(pd.dosage,'')='' then '' else pd.dosage + ' ' end +
						case when pd.period=0 then ''
						else
						'x ' + convert(varchar(10),pd.per) + ' ' + 
						case pd.per when 3 then 'mons' when 2 then 'weeks' else 'days' end end
						+ 
						case when pd.quantity>0 then ' #' + convert(varchar(10),pd.quantity) else '' end + char(10)
						
						from [prescriptiondetails] pd 
						left join items i on pd.drugcode=cast(i.itemcode AS varchar)
						left join frequency f on f.frequencyid=pd.frequency
						where  pd.[prescriptionid] = p.[prescriptionid]
						and  coalesce(pd.isdeleted,0)=0
						order by p.[prescriptionid]
						FOR XML PATH(''), TYPE
						) drugs
			FROM prescription p 
			where coalesce(p.isdeleted,0) = 0 and 
			p.admissionid = @search
		end
		else if @soperation=63 --getprescriptiondetails
		begin
			SELECT p.prescriptionid, p.admissionid, p.[description], p.[date], p.physician, p.name, p.istemplate
				 , p.refpatientrequestno, p.isdeleted pisdeleted, p.datecreated pcreated_at, p.dateupdated pupdated_at
				 , pd.presecriptiondetailsid,  pd.drugcode, pd.quantity, pd.dosage, pd.period, pd.per, pd.isdeleted
				 , pd.datecreated, pd.dateupdated , coalesce(i.itemdescription,pd.drugcode) itemdescription
				 , pd.frequency, f.[description] frequencydescription
			FROM prescription p 
			inner join prescriptiondetails pd  on p.prescriptionid = pd.prescriptionid 
			left join items i on cast(i.itemcode AS varchar) = pd.drugcode
			left join frequency f on f.frequencyid=pd.frequency
			where coalesce(pd.isdeleted,0) = 0 and 
			p.prescriptionid = @search
		end
		else if @soperation=64 --gettestrequestdetails
		begin
			SELECT t.testrequestid, t.admissionid, t.requestdate, t.urgency, t.isfasting, t.medication, t.remarks remarksmaster
				 , t.refpatientrequestno, t.destinationoffice,o.officedescription
				 , td.testrequestdetailid,  td.testid, td.isdaterequired, td.daterequired, td.itemcode,'' remarks
				 , td.isdeleted, coalesce(i.itemdescription,td.itemcode)itemdescription
			FROM testrequest t 
			inner join testrequestdetail td  on t.testrequestid = td.testrequestid 
			left join items i on i.itemcode = td.itemcode
			left join offices o on o.officecode=t.destinationoffice
			where coalesce(td.isdeleted,0) = 0 and 
			t.testrequestid = @search
		end
		else if @soperation=65 --gettestrequestmaster
		begin
			SELECT t.testrequestid, t.admissionid, t.requestdate, t.urgency, t.isfasting, t.medication, t.remarks remarksmaster
				 , t.refpatientrequestno, t.destinationoffice,o.officedescription
				 ,(select 
						' ' + coalesce(i.itemdescription,td.itemcode) + ' ' +
						--case when coalesce(td.remarks,'')='' then '' else '(' + td.remarks + ')' end + 
						char(10)						
						from testrequestdetail td 
						left join items i on td.itemcode=i.itemcode
						where  td.testrequestid = t.testrequestid
						and  coalesce(td.isdeleted,0)=0
						order by t.testrequestid
						FOR XML PATH(''), TYPE
						) tests
			FROM testrequest t 
			left join offices o on o.officecode=t.destinationoffice
			where coalesce(t.isdeleted,0) = 0 and  t.admissionid = @search
		end
		else if @soperation=66 --getspecifictestrequestdetail
		begin
			SELECT t.testrequestid, t.admissionid, t.requestdate, t.urgency, t.isfasting, t.medication, t.remarks remarksmaster
				 , t.refpatientrequestno, t.destinationoffice,o.officedescription
				 , td.testrequestdetailid,  td.testid, td.isdaterequired, td.daterequired, td.itemcode,'' remarks
				 , td.isdeleted, coalesce(i.itemdescription,td.itemcode)itemdescription
			FROM testrequest t 
			inner join testrequestdetail td  on t.testrequestid = td.testrequestid 
			left join items i on i.itemcode = td.itemcode
			left join offices o on o.officecode=t.destinationoffice
			where coalesce(td.isdeleted,0) = 0 and 
			td.testrequestdetailid = @search
		end
	END
	
	
	ELSE IF @operation=1
	BEGIN
		if @soperation=0
		begin
			insert into terminals (terminalcode,terminaldesc,terminaltype,token,isactive)
			values
			(@terminalcode,@terminaldesc,@terminaltype,'',0)
		end
		else if @soperation=1
		begin
			select @admissionid=max(admissionid) from admissions
			BEGIN TRY
			BEGIN TRAN 
				UPDATE admissions
				set admissionid=b.admissionid
					,patientid=b.patientid
					,ptno=b.ptno
					,hospitalno=b.hospitalno
					,admissiontype=b.admissiontype
					,admissioncode=b.admissioncode
					,dateadmitted=b.dateadmitted
					,datedischarged=b.datedischarged
					,roomid=b.roomid
					,admittingphysicianid=b.admittingphysicianid
					,attendingphysicianid=b.attendingphysicianid
					,admissionstatus=b.admissionstatus
					,mghdate=b.mghdate
					,informant=b.informant
					,informantrelationship=b.informantrelationship
					,familysize=b.familysize
					,notify=b.notify
					,notifyrelationship=b.notifyrelationship
					,notifyaddress=b.notifyaddress
					,notifytelno=b.notifytelno
					,kindofoperation=b.kindofoperation
					,memberphid=b.memberphid
					,accreditationno=b.accreditationno
					,casetype=b.casetype
					,finaldiagnosis=b.finaldiagnosis
					,admittingdiagnosis=b.admittingdiagnosis
					,historyofpresentillness=b.historyofpresentillness
					,physicalexamination=b.physicalexamination
					,courseinthewards=b.courseinthewards
					,conditionondischarge=b.conditionondischarge
					,sodatetime=b.sodatetime
					,soanesthesiologist=b.soanesthesiologist
					,soanethesiatype=b.soanethesiatype
					,sosurgeonname=b.sosurgeonname
					,reference=b.reference
					,isdischarge=b.isdischarge
					,hospitalplan=b.hospitalplan
					,philhealthcasetype=b.philhealthcasetype
					,encodedby=b.encodedby
					,dateencoded=b.dateencoded
					,isadmitpatient=b.isadmitpatient
					,startdate=b.startdate
					,dateended=b.dateended
					,reasonforadmission=b.reasonforadmission
					,admittingimpression=b.admittingimpression
					,familyhistory=b.familyhistory
					,pasthistory=b.pasthistory
					,pastillness=b.pastillness
					,chiefcomplaints=b.chiefcomplaints
					,packagecaseno=b.packagecaseno
					,packagecaseno2=b.packagecaseno2
					,dischargestatus=b.dischargestatus
					,referral=b.referral
					,dateofdeath=b.dateofdeath
					,reasonrefferalno=b.reasonrefferalno
					,istransmitted=b.istransmitted
					,isphicmember=b.isphicmember
					,referringhciid=b.referringhciid
					,referralhcid=b.referralhcid
					,memo=b.memo
					,cf2purchasemeds=b.cf2purchasemeds
					,cf2expenselabs=b.cf2expenselabs
					,reltophicmember=b.reltophicmember
					,isemergency=b.isemergency
					,zbenefitcode=b.zbenefitcode
					,zpreauthdate=b.zpreauthdate
					,prenataldate1=b.prenataldate1
					,prenataldate2=b.prenataldate2
					,prenataldate3=b.prenataldate3
					,prenataldate4=b.prenataldate4
					,tbtype=b.tbtype
					,ntpcardno=b.ntpcardno
					,day0arv=b.day0arv
					,day3arv=b.day3arv
					,day7arv=b.day7arv
					,rig=b.rig
					,abpothers=b.abpothers
					,abpotherspecify=b.abpotherspecify
					,hivaidslaboratoryno=b.hivaidslaboratoryno
					,cataractpreauthdate=b.cataractpreauthdate
					,lefteyestickerno=b.lefteyestickerno
					,lefteyestickerexpiry=b.lefteyestickerexpiry
					,righteyestickerno=b.righteyestickerno
					,righteyestickerexpiry=b.righteyestickerexpiry
					,encodedineclaims=b.encodedineclaims
					,referringreason=b.referringreason
					,dateupdated=b.dateupdated
					,cataractapplicationno=b.cataractapplicationno
					,[plan]=b.[plan]
					,[assessment]=b.[assessment]
					,local_id=b.admissionid
					,syncbatchcode=@syncbatchcode
				FROM admissions a  INNER JOIN @emr_admissions b
				ON a.admissionid =  b.server_id
				WHERE b.server_id IN (SELECT admissionid FROM admissions)
				
				
				INSERT INTO [dbo].[admissions]
				   (admissionid
					,patientid
					,ptno
					,hospitalno
					,admissiontype
					,admissioncode
					,dateadmitted
					,datedischarged
					,roomid
					,admittingphysicianid
					,attendingphysicianid
					,admissionstatus
					,mghdate
					,informant
					,informantrelationship
					,familysize
					,notify
					,notifyrelationship
					,notifyaddress
					,notifytelno
					,kindofoperation
					,memberphid
					,accreditationno
					,casetype
					,finaldiagnosis
					,admittingdiagnosis
					,historyofpresentillness
					,physicalexamination
					,courseinthewards
					,conditionondischarge
					,sodatetime
					,soanesthesiologist
					,soanethesiatype
					,sosurgeonname
					,reference
					,isdischarge
					,hospitalplan
					,philhealthcasetype
					,encodedby
					,dateencoded
					,isadmitpatient
					,startdate
					,dateended
					,reasonforadmission
					,admittingimpression
					,familyhistory
					,pasthistory
					,pastillness
					,chiefcomplaints
					,packagecaseno
					,packagecaseno2
					,dischargestatus
					,referral
					,dateofdeath
					,reasonrefferalno
					,istransmitted
					,isphicmember
					,referringhciid
					,referralhcid
					,memo
					,cf2purchasemeds
					,cf2expenselabs
					,reltophicmember
					,isemergency
					,zbenefitcode
					,zpreauthdate
					,prenataldate1
					,prenataldate2
					,prenataldate3
					,prenataldate4
					,tbtype
					,ntpcardno
					,day0arv
					,day3arv
					,day7arv
					,rig
					,abpothers
					,abpotherspecify
					,hivaidslaboratoryno
					,cataractpreauthdate
					,lefteyestickerno
					,lefteyestickerexpiry
					,righteyestickerno
					,righteyestickerexpiry
					,encodedineclaims
					,referringreason
					,dateupdated
					,cataractapplicationno
					,[plan]
					,[assessment]
					,local_id
					,syncbatchcode)
					SELECT 
					    @admissionid+row_number() OVER (ORDER BY b.admissionid) admissionid
						,b.patientid
						,b.ptno
						,b.hospitalno
						,b.admissiontype
						,b.admissioncode
						,b.dateadmitted
						,b.datedischarged
						,b.roomid
						,b.admittingphysicianid
						,b.attendingphysicianid
						,b.admissionstatus
						,b.mghdate
						,b.informant
						,b.informantrelationship
						,b.familysize
						,b.notify
						,b.notifyrelationship
						,b.notifyaddress
						,b.notifytelno
						,b.kindofoperation
						,b.memberphid
						,b.accreditationno
						,b.casetype
						,b.finaldiagnosis
						,b.admittingdiagnosis
						,b.historyofpresentillness
						,b.physicalexamination
						,b.courseinthewards
						,b.conditionondischarge
						,b.sodatetime
						,b.soanesthesiologist
						,b.soanethesiatype
						,b.sosurgeonname
						,b.reference
						,b.isdischarge
						,b.hospitalplan
						,b.philhealthcasetype
						,b.encodedby
						,b.dateencoded
						,b.isadmitpatient
						,b.startdate
						,b.dateended
						,b.reasonforadmission
						,b.admittingimpression
						,b.familyhistory
						,b.pasthistory
						,b.pastillness
						,b.chiefcomplaints
						,b.packagecaseno
						,b.packagecaseno2
						,b.dischargestatus
						,b.referral
						,b.dateofdeath
						,b.reasonrefferalno
						,b.istransmitted
						,b.isphicmember
						,b.referringhciid
						,b.referralhcid
						,b.memo
						,b.cf2purchasemeds
						,b.cf2expenselabs
						,b.reltophicmember
						,b.isemergency
						,b.zbenefitcode
						,b.zpreauthdate
						,b.prenataldate1
						,b.prenataldate2
						,b.prenataldate3
						,b.prenataldate4
						,b.tbtype
						,b.ntpcardno
						,b.day0arv
						,b.day3arv
						,b.day7arv
						,b.rig
						,b.abpothers
						,b.abpotherspecify
						,b.hivaidslaboratoryno
						,b.cataractpreauthdate
						,b.lefteyestickerno
						,b.lefteyestickerexpiry
						,b.righteyestickerno
						,b.righteyestickerexpiry
						,b.encodedineclaims
						,b.referringreason
						,b.dateupdated
						,b.cataractapplicationno
						,b.[plan]
						,b.[assessment]
						,b.admissionid
						,@syncbatchcode
					FROM @emr_admissions b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT admissionid from [admissions])
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=2
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE admissiondetails
				set documentno=b.documentno
					,gravida=b.gravida
					,para=b.para
					,abortion=b.abortion
					,term=b.term
					,premature=b.premature
					,line=b.line
					,previousmenstrualperiod=b.previousmenstrualperiod
					,pmpdurationcharacter=b.pmpdurationcharacter
					,lastmenstrualperiod=b.lastmenstrualperiod
					,lmpdurationcharacter=b.lmpdurationcharacter
					,estimateddateofconfinement=b.estimateddateofconfinement
					,ageofgestation=b.ageofgestation
					,menarche=b.menarche
					,interval=b.interval
					,duration=b.duration
					,amount=b.amount
					,contraception=b.contraception
					,dysmenorrhea=b.dysmenorrhea
					,prenatalcoursepvtmd=b.prenatalcoursepvtmd
					,prenatalcoursedhiopd=b.prenatalcoursedhiopd
					,prenatalcoursehealthctr=b.prenatalcoursehealthctr
					,midwife=b.midwife
					,hilot=b.hilot
					,[none]=b.[none]
					,freqofcheckupdoneby=b.freqofcheckupdoneby
					,bp=b.bp
					,complications=b.complications
					,prenatalmedstaken=b.prenatalmedstaken
					,childhooddiseases=b.childhooddiseases
					,previoushospitalizations=b.previoushospitalizations
					,previousoperations=b.previousoperations
					,medicalillness=b.medicalillness
					,allergies=b.allergies
					,medications=b.medications
					,familyhistorydm=b.familyhistorydm
					,familyhistoryhpn=b.familyhistoryhpn
					,familyhistoryheartdse=b.familyhistoryheartdse
					,familyhistoryptb=b.familyhistoryptb
					,familyhistoryca=b.familyhistoryca
					,familyhistoryothers=b.familyhistoryothers
					,rr=b.rr
					,ht=b.ht
					,cr=b.cr
					,t=b.t
					,wt=b.wt
					,headneck=b.headneck
					,heart=b.heart
					,breasts=b.breasts
					,lungs=b.lungs
					,abdomenfh=b.abdomenfh
					,abdomenefw=b.abdomenefw
					,abdomenfht=b.abdomenfht
					,abdomenfhtcharacter=b.abdomenfhtcharacter
					,abdomenfhtlocation=b.abdomenfhtlocation
					,extremeties=b.extremeties
					,ieby=b.ieby
					,dilatation=b.dilatation
					,effacement=b.effacement
					,station=b.station
					,bow=b.bow
					,bowleakingsince=b.bowleakingsince
					,prespart=b.prespart
					,characterofdischargemucoid=b.characterofdischargemucoid
					,characterofdischargebloody=b.characterofdischargebloody
					,characterofdischargewatery=b.characterofdischargewatery
					,characterofdischargecolor=b.characterofdischargecolor
					,characterofdischargeodor=b.characterofdischargeodor
					,speculumexam=b.speculumexam
					,abnormalities=b.abnormalities
					,clinicalpelvimetryischialspines=b.clinicalpelvimetryischialspines
					,clinicalpelvimetrysidewalls=b.clinicalpelvimetrysidewalls
					,clinicalpelvimetrypubicarch=b.clinicalpelvimetrypubicarch
					,clinicalpelvimetrysacrumcontour=b.clinicalpelvimetrysacrumcontour
					,clinicalpelvimetrysacrosciaticnotch=b.clinicalpelvimetrysacrosciaticnotch
					,clinicalpelvimetryischialtuberosities=b.clinicalpelvimetryischialtuberosities
					,epcadequate=b.epcadequate
					,epcborderline=b.epcborderline
					,epcnarrow=b.epcnarrow
					,impression=b.impression
					,UltrasoundAOG=b.UltrasoundAOG
					,AdjustedEDC=b.AdjustedEDC
					,dateofquickening=b.dateofquickening
					,ultrasounddate=b.ultrasounddate
					,prenatalvisits=b.prenatalvisits
					,contraceptiveshistory=b.contraceptiveshistory
					,healthcareprovider=b.healthcareprovider
					,immunizationstetanus=b.immunizationstetanus
					,immunizationstetanusdoses=b.immunizationstetanusdoses
					,immunizationstetanusdate=b.immunizationstetanusdate
					,immunizationshepatitisb=b.immunizationshepatitisb
					,immunizationsothers=b.immunizationsothers
					,totalgainweight=b.totalgainweight
					,hb=b.hb
					,urinealb=b.urinealb
					,sugar=b.sugar
					,antenatalproblemsmb98ms=b.antenatalproblemsmb98ms
					,antenatalproblemsprevcssurgery=b.antenatalproblemsprevcssurgery
					,antenatalproblemsuti=b.antenatalproblemsuti
					,antenatalproblemsinfectiontracts=b.antenatalproblemsinfectiontracts
					,antenatalproblemsnutritional=b.antenatalproblemsnutritional
					,antenatalproblemshpnpidchvd=b.antenatalproblemshpnpidchvd
					,antenatalproblemscardiac=b.antenatalproblemscardiac
					,antenatalproblemsrenal=b.antenatalproblemsrenal
					,antenatalproblemsdmmetabolic=b.antenatalproblemsdmmetabolic
					,antenatalproblemsrespiratory=b.antenatalproblemsrespiratory
					,antenatalproblemsfetalwastage=b.antenatalproblemsfetalwastage
					,antenatalproblemsprematurelabor=b.antenatalproblemsprematurelabor
					,antenatalproblemsiugr=b.antenatalproblemsiugr
					,antenatalproblemsinfertility=b.antenatalproblemsinfertility
					,antenatalproblemsothers=b.antenatalproblemsothers
					,riskstatus=b.riskstatus
					,physicalexamdate=b.physicalexamdate
					,physicalexaminer=b.physicalexaminer
					,physicalexamgeneralstatus=b.physicalexamgeneralstatus
					,levelofsensorium=b.levelofsensorium
					,eent=b.eent
					,chestheart=b.chestheart
					,chestlungs=b.chestlungs
					,chestbreast=b.chestbreast
					,abdomenlsk=b.abdomenlsk
					,abdomenfundicheight=b.abdomenfundicheight
					,abdomenpresentation=b.abdomenpresentation
					,abdomenfloatingengaged=b.abdomenfloatingengaged
					,abdomenother=b.abdomenother
					,pelvicexamexternalgenitalia=b.pelvicexamexternalgenitalia
					,pelvicexamuterus=b.pelvicexamuterus
					,pelvicexamvaginacervixlength=b.pelvicexamvaginacervixlength
					,pelvicexampositionant=b.pelvicexampositionant
					,pelvicexampositionmidline=b.pelvicexampositionmidline
					,pelvicexampositionpost=b.pelvicexampositionpost
					,presentationposition=b.presentationposition
					,presentationstation=b.presentationstation
					,presentationmembranes=b.presentationmembranes
					,presentationamnioticfld=b.presentationamnioticfld
					,presentationsutures=b.presentationsutures
					,pelvimetrycontracted=b.pelvimetrycontracted
					,pelvimetrycontractedinlet=b.pelvimetrycontractedinlet
					,pelvimetrycontractedinlettxt=b.pelvimetrycontractedinlettxt
					,pelvimetrycontractedmidline=b.pelvimetrycontractedmidline
					,pelvimetrycontractedmidlinetxt=b.pelvimetrycontractedmidlinetxt
					,pelvimetrycontractedoutlet=b.pelvimetrycontractedoutlet
					,pelvimetrycontractedoutlettxt=b.pelvimetrycontractedoutlettxt
					,pelvimetryborderline=b.pelvimetryborderline
					,pelvimetryborderlinetriallabor=b.pelvimetryborderlinetriallabor
					,generalstatus=b.generalstatus
					,pelvimetryadequate=b.pelvimetryadequate
					,remarks=b.remarks
					,presentillness=b.presentillness
					,prenatalinfection=b.prenatalinfection
					,prenatalexposuretodrugs=b.prenatalexposuretodrugs
					,prenatalsmokingalcohol=b.prenatalsmokingalcohol
					,nataltypeofdelivery=b.nataltypeofdelivery
					,natalnsd=b.natalnsd
					,natalcs=b.natalcs
					,natalyo=b.natalyo
					,natalgestationalage=b.natalgestationalage
					,natalbodyweight=b.natalbodyweight
					,natalapgarscore=b.natalapgarscore
					,natalanomalies=b.natalanomalies
					,natalresuscitation=b.natalresuscitation
					,natalcomplication=b.natalcomplication
					,feedinghistorybreastfeeding=b.feedinghistorybreastfeeding
					,feedinghistorymilkformula=b.feedinghistorymilkformula
					,feedinghistorysupplemental=b.feedinghistorysupplemental
					,feedinghistoryallergies=b.feedinghistoryallergies
					,growthdevelopmentmotor=b.growthdevelopmentmotor
					,growthdevelopmentlanguage=b.growthdevelopmentlanguage
					,growthdevelopmenttoilettraining=b.growthdevelopmenttoilettraining
					,growthdevelopmentschool=b.growthdevelopmentschool
					,immunizationbcg=b.immunizationbcg
					,immunizationdpt=b.immunizationdpt
					,immunizationopv=b.immunizationopv
					,immunizationboosterdoses=b.immunizationboosterdoses
					,immunizationmeascles=b.immunizationmeascles
					,immunizationhib=b.immunizationhib
					,immunizationhepatitis=b.immunizationhepatitis
					,generalappearance=b.generalappearance
					,sheent=b.sheent
					,cl=b.cl
					,cvs=b.cvs
					,abdomin=b.abdomin
					,neurologicexam=b.neurologicexam
					,MenstrualCycle1=b.MenstrualCycle1
					,MenstrualCycle2=b.MenstrualCycle2
					,MenstrualCycle3=b.MenstrualCycle3
					,pogsgravida=b.pogsgravida
					,pogspara=b.pogspara
					,pogsabortion=b.pogsabortion
					,pogsterm=b.pogsterm
					,pogspremature=b.pogspremature
					,pogsline=b.pogsline
					,pediagravida=b.pediagravida
					,pediapara=b.pediapara
					,pediaabortion=b.pediaabortion
					,pogsdilatation=b.pogsdilatation
					,pogseffacement=b.pogseffacement
					,pogsfht=b.pogsfht
					,pogsefw=b.pogsefw
					,pogsextremities=b.pogsextremities
					,pogslastmenstrualperiod=b.pogslastmenstrualperiod
					,pogspreviousmenstrualperiod=b.pogspreviousmenstrualperiod
					,philhealthno=b.philhealthno
					,philrelationshiptomember=b.philrelationshiptomember
					,philReferredFrom=b.philReferredFrom
					,philrepresentative=b.philrepresentative
					,philcontactnorep=b.philcontactnorep
					,philtypeofdelivery=b.philtypeofdelivery
					,philnurseonduty=b.philnurseonduty
					,philwithmedpack=b.philwithmedpack
					,philremarks=b.philremarks
					,philisphilhealthapprove=b.philisphilhealthapprove
					,philhealthapprovalremarks=b.philhealthapprovalremarks
					,philrelationshiptorep=b.philrelationshiptorep
					,officecode=b.officecode	
					,syncbatchcode=@syncbatchcode
				FROM admissiondetails a  INNER JOIN @emr_admissiondetails b
				ON a.admissionid =  b.admissionid
				WHERE b.admissionid IN (SELECT admissionid FROM admissiondetails)
				
				
				INSERT INTO [dbo].[admissiondetails]
				   (admissionid
					,documentno
					,gravida
					,para
					,abortion
					,term
					,premature
					,line
					,previousmenstrualperiod
					,pmpdurationcharacter
					,lastmenstrualperiod
					,lmpdurationcharacter
					,estimateddateofconfinement
					,ageofgestation
					,menarche
					,interval
					,duration
					,amount
					,contraception
					,dysmenorrhea
					,prenatalcoursepvtmd
					,prenatalcoursedhiopd
					,prenatalcoursehealthctr
					,midwife
					,hilot
					,[none]
					,freqofcheckupdoneby
					,bp
					,complications
					,prenatalmedstaken
					,childhooddiseases
					,previoushospitalizations
					,previousoperations
					,medicalillness
					,allergies
					,medications
					,familyhistorydm
					,familyhistoryhpn
					,familyhistoryheartdse
					,familyhistoryptb
					,familyhistoryca
					,familyhistoryothers
					,rr
					,ht
					,cr
					,t
					,wt
					,headneck
					,heart
					,breasts
					,lungs
					,abdomenfh
					,abdomenefw
					,abdomenfht
					,abdomenfhtcharacter
					,abdomenfhtlocation
					,extremeties
					,ieby
					,dilatation
					,effacement
					,station
					,bow
					,bowleakingsince
					,prespart
					,characterofdischargemucoid
					,characterofdischargebloody
					,characterofdischargewatery
					,characterofdischargecolor
					,characterofdischargeodor
					,speculumexam
					,abnormalities
					,clinicalpelvimetryischialspines
					,clinicalpelvimetrysidewalls
					,clinicalpelvimetrypubicarch
					,clinicalpelvimetrysacrumcontour
					,clinicalpelvimetrysacrosciaticnotch
					,clinicalpelvimetryischialtuberosities
					,epcadequate
					,epcborderline
					,epcnarrow
					,impression
					,UltrasoundAOG
					,AdjustedEDC
					,dateofquickening
					,ultrasounddate
					,prenatalvisits
					,contraceptiveshistory
					,healthcareprovider
					,immunizationstetanus
					,immunizationstetanusdoses
					,immunizationstetanusdate
					,immunizationshepatitisb
					,immunizationsothers
					,totalgainweight
					,hb
					,urinealb
					,sugar
					,antenatalproblemsmb98ms
					,antenatalproblemsprevcssurgery
					,antenatalproblemsuti
					,antenatalproblemsinfectiontracts
					,antenatalproblemsnutritional
					,antenatalproblemshpnpidchvd
					,antenatalproblemscardiac
					,antenatalproblemsrenal
					,antenatalproblemsdmmetabolic
					,antenatalproblemsrespiratory
					,antenatalproblemsfetalwastage
					,antenatalproblemsprematurelabor
					,antenatalproblemsiugr
					,antenatalproblemsinfertility
					,antenatalproblemsothers
					,riskstatus
					,physicalexamdate
					,physicalexaminer
					,physicalexamgeneralstatus
					,levelofsensorium
					,eent
					,chestheart
					,chestlungs
					,chestbreast
					,abdomenlsk
					,abdomenfundicheight
					,abdomenpresentation
					,abdomenfloatingengaged
					,abdomenother
					,pelvicexamexternalgenitalia
					,pelvicexamuterus
					,pelvicexamvaginacervixlength
					,pelvicexampositionant
					,pelvicexampositionmidline
					,pelvicexampositionpost
					,presentationposition
					,presentationstation
					,presentationmembranes
					,presentationamnioticfld
					,presentationsutures
					,pelvimetrycontracted
					,pelvimetrycontractedinlet
					,pelvimetrycontractedinlettxt
					,pelvimetrycontractedmidline
					,pelvimetrycontractedmidlinetxt
					,pelvimetrycontractedoutlet
					,pelvimetrycontractedoutlettxt
					,pelvimetryborderline
					,pelvimetryborderlinetriallabor
					,generalstatus
					,pelvimetryadequate
					,remarks
					,presentillness
					,prenatalinfection
					,prenatalexposuretodrugs
					,prenatalsmokingalcohol
					,nataltypeofdelivery
					,natalnsd
					,natalcs
					,natalyo
					,natalgestationalage
					,natalbodyweight
					,natalapgarscore
					,natalanomalies
					,natalresuscitation
					,natalcomplication
					,feedinghistorybreastfeeding
					,feedinghistorymilkformula
					,feedinghistorysupplemental
					,feedinghistoryallergies
					,growthdevelopmentmotor
					,growthdevelopmentlanguage
					,growthdevelopmenttoilettraining
					,growthdevelopmentschool
					,immunizationbcg
					,immunizationdpt
					,immunizationopv
					,immunizationboosterdoses
					,immunizationmeascles
					,immunizationhib
					,immunizationhepatitis
					,generalappearance
					,sheent
					,cl
					,cvs
					,abdomin
					,neurologicexam
					,MenstrualCycle1
					,MenstrualCycle2
					,MenstrualCycle3
					,pogsgravida
					,pogspara
					,pogsabortion
					,pogsterm
					,pogspremature
					,pogsline
					,pediagravida
					,pediapara
					,pediaabortion
					,pogsdilatation
					,pogseffacement
					,pogsfht
					,pogsefw
					,pogsextremities
					,pogslastmenstrualperiod
					,pogspreviousmenstrualperiod
					,philhealthno
					,philrelationshiptomember
					,philReferredFrom
					,philrepresentative
					,philcontactnorep
					,philtypeofdelivery
					,philnurseonduty
					,philwithmedpack
					,philremarks
					,philisphilhealthapprove
					,philhealthapprovalremarks
					,philrelationshiptorep
					,officecode
					,syncbatchcode)
					SELECT 
					    b.admissionid
						,b.documentno
						,b.gravida
						,b.para
						,b.abortion
						,b.term
						,b.premature
						,b.line
						,b.previousmenstrualperiod
						,b.pmpdurationcharacter
						,b.lastmenstrualperiod
						,b.lmpdurationcharacter
						,b.estimateddateofconfinement
						,b.ageofgestation
						,b.menarche
						,b.interval
						,b.duration
						,b.amount
						,b.contraception
						,b.dysmenorrhea
						,b.prenatalcoursepvtmd
						,b.prenatalcoursedhiopd
						,b.prenatalcoursehealthctr
						,b.midwife
						,b.hilot
						,b.[none]
						,b.freqofcheckupdoneby
						,b.bp
						,b.complications
						,b.prenatalmedstaken
						,b.childhooddiseases
						,b.previoushospitalizations
						,b.previousoperations
						,b.medicalillness
						,b.allergies
						,b.medications
						,b.familyhistorydm
						,b.familyhistoryhpn
						,b.familyhistoryheartdse
						,b.familyhistoryptb
						,b.familyhistoryca
						,b.familyhistoryothers
						,b.rr
						,b.ht
						,b.cr
						,b.t
						,b.wt
						,b.headneck
						,b.heart
						,b.breasts
						,b.lungs
						,b.abdomenfh
						,b.abdomenefw
						,b.abdomenfht
						,b.abdomenfhtcharacter
						,b.abdomenfhtlocation
						,b.extremeties
						,b.ieby
						,b.dilatation
						,b.effacement
						,b.station
						,b.bow
						,b.bowleakingsince
						,b.prespart
						,b.characterofdischargemucoid
						,b.characterofdischargebloody
						,b.characterofdischargewatery
						,b.characterofdischargecolor
						,b.characterofdischargeodor
						,b.speculumexam
						,b.abnormalities
						,b.clinicalpelvimetryischialspines
						,b.clinicalpelvimetrysidewalls
						,b.clinicalpelvimetrypubicarch
						,b.clinicalpelvimetrysacrumcontour
						,b.clinicalpelvimetrysacrosciaticnotch
						,b.clinicalpelvimetryischialtuberosities
						,b.epcadequate
						,b.epcborderline
						,b.epcnarrow
						,b.impression
						,b.UltrasoundAOG
						,b.AdjustedEDC
						,b.dateofquickening
						,b.ultrasounddate
						,b.prenatalvisits
						,b.contraceptiveshistory
						,b.healthcareprovider
						,b.immunizationstetanus
						,b.immunizationstetanusdoses
						,b.immunizationstetanusdate
						,b.immunizationshepatitisb
						,b.immunizationsothers
						,b.totalgainweight
						,b.hb
						,b.urinealb
						,b.sugar
						,b.antenatalproblemsmb98ms
						,b.antenatalproblemsprevcssurgery
						,b.antenatalproblemsuti
						,b.antenatalproblemsinfectiontracts
						,b.antenatalproblemsnutritional
						,b.antenatalproblemshpnpidchvd
						,b.antenatalproblemscardiac
						,b.antenatalproblemsrenal
						,b.antenatalproblemsdmmetabolic
						,b.antenatalproblemsrespiratory
						,b.antenatalproblemsfetalwastage
						,b.antenatalproblemsprematurelabor
						,b.antenatalproblemsiugr
						,b.antenatalproblemsinfertility
						,b.antenatalproblemsothers
						,b.riskstatus
						,b.physicalexamdate
						,b.physicalexaminer
						,b.physicalexamgeneralstatus
						,b.levelofsensorium
						,b.eent
						,b.chestheart
						,b.chestlungs
						,b.chestbreast
						,b.abdomenlsk
						,b.abdomenfundicheight
						,b.abdomenpresentation
						,b.abdomenfloatingengaged
						,b.abdomenother
						,b.pelvicexamexternalgenitalia
						,b.pelvicexamuterus
						,b.pelvicexamvaginacervixlength
						,b.pelvicexampositionant
						,b.pelvicexampositionmidline
						,b.pelvicexampositionpost
						,b.presentationposition
						,b.presentationstation
						,b.presentationmembranes
						,b.presentationamnioticfld
						,b.presentationsutures
						,b.pelvimetrycontracted
						,b.pelvimetrycontractedinlet
						,b.pelvimetrycontractedinlettxt
						,b.pelvimetrycontractedmidline
						,b.pelvimetrycontractedmidlinetxt
						,b.pelvimetrycontractedoutlet
						,b.pelvimetrycontractedoutlettxt
						,b.pelvimetryborderline
						,b.pelvimetryborderlinetriallabor
						,b.generalstatus
						,b.pelvimetryadequate
						,b.remarks
						,b.presentillness
						,b.prenatalinfection
						,b.prenatalexposuretodrugs
						,b.prenatalsmokingalcohol
						,b.nataltypeofdelivery
						,b.natalnsd
						,b.natalcs
						,b.natalyo
						,b.natalgestationalage
						,b.natalbodyweight
						,b.natalapgarscore
						,b.natalanomalies
						,b.natalresuscitation
						,b.natalcomplication
						,b.feedinghistorybreastfeeding
						,b.feedinghistorymilkformula
						,b.feedinghistorysupplemental
						,b.feedinghistoryallergies
						,b.growthdevelopmentmotor
						,b.growthdevelopmentlanguage
						,b.growthdevelopmenttoilettraining
						,b.growthdevelopmentschool
						,b.immunizationbcg
						,b.immunizationdpt
						,b.immunizationopv
						,b.immunizationboosterdoses
						,b.immunizationmeascles
						,b.immunizationhib
						,b.immunizationhepatitis
						,b.generalappearance
						,b.sheent
						,b.cl
						,b.cvs
						,b.abdomin
						,b.neurologicexam
						,b.MenstrualCycle1
						,b.MenstrualCycle2
						,b.MenstrualCycle3
						,b.pogsgravida
						,b.pogspara
						,b.pogsabortion
						,b.pogsterm
						,b.pogspremature
						,b.pogsline
						,b.pediagravida
						,b.pediapara
						,b.pediaabortion
						,b.pogsdilatation
						,b.pogseffacement
						,b.pogsfht
						,b.pogsefw
						,b.pogsextremities
						,b.pogslastmenstrualperiod
						,b.pogspreviousmenstrualperiod
						,b.philhealthno
						,b.philrelationshiptomember
						,b.philReferredFrom
						,b.philrepresentative
						,b.philcontactnorep
						,b.philtypeofdelivery
						,b.philnurseonduty
						,b.philwithmedpack
						,b.philremarks
						,b.philisphilhealthapprove
						,b.philhealthapprovalremarks
						,b.philrelationshiptorep
						,b.officecode
						,@syncbatchcode
					FROM @emr_admissiondetails b 
					WHERE b.admissionid NOT IN (SELECT admissionid from admissiondetails)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=3
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE admissiondiagnosis
				set admissionid=b.admissionid
					,icd10code=b.icd10code
					,isprimarydiagnosis=b.isprimarydiagnosis
					,diagnosis=b.diagnosis	
					,isprocedure=b.isprocedure
					,dateofprocedure=b.dateofprocedure
					,laterality=b.laterality
					,csindication=b.csindication
					,createdbyid=b.createdbyid
					,createddate=b.createddate
					,updatedbyid=b.updatedbyid
					,updateddate=b.updateddate
					,local_id=b.admissiondiagnosisid
					,syncbatchcode=@syncbatchcode
				FROM admissiondiagnosis a  INNER JOIN @emr_admissiondiagnosis b
				ON a.admissiondiagnosisid =  b.server_id
				WHERE b.server_id IN (SELECT admissiondiagnosisid FROM admissiondiagnosis)
				
				
				INSERT INTO [dbo].[admissiondiagnosis]
				   (admissionid
					,icd10code
					,isprimarydiagnosis
					,diagnosis	
					,isprocedure
					,dateofprocedure
					,laterality
					,csindication
					,createdbyid
					,createddate
					,updatedbyid
					,updateddate
					,local_id
					,syncbatchcode)
					SELECT 
					    admissionid
						,icd10code
						,isprimarydiagnosis
						,diagnosis	
						,isprocedure
						,dateofprocedure
						,laterality
						,csindication
						,createdbyid
						,createddate
						,updatedbyid
						,updateddate
						,admissiondiagnosisid
						,@syncbatchcode
					FROM @emr_admissiondiagnosis b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT admissiondiagnosisid from [admissiondiagnosis])
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=4
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE patientvitalsign
				set bloodpressure=b.bloodpressure
					,breathing=b.breathing
					,pulse=b.pulse
					,temperature=b.temperature
					,height=b.height
					,weight=b.weight
					,heent=b.heent
					,chest=b.chest
					,cvs=b.cvs
					,Abdomen=b.Abdomen
					,skinextremities=b.skinextremities
					,neuroexamination=b.neuroexamination
					,gu=b.gu
					,alteredmentalsensorium=b.alteredmentalsensorium
					,abdominalcramp_pain=b.abdominalcramp_pain
					,abdominaldistention=b.abdominaldistention
					,anemia=b.anemia
					,anorexia=b.anorexia
					,breathlessness=b.breathlessness
					,bleedinggums=b.bleedinggums
					,bodyweakness=b.bodyweakness
					,blurringofvision=b.blurringofvision
					,constipation=b.constipation
					,chestpain_discomfort=b.chestpain_discomfort
					,chills=b.chills
					,cough_dry=b.cough_dry
					,cough_productive=b.cough_productive
					,diarrhea=b.diarrhea
					,dizziness=b.dizziness
					,drowsiness=b.drowsiness
					,dysphagia=b.dysphagia
					,dyspnea=b.dyspnea
					,dysuria=b.dysuria
					,epigastricpain=b.epigastricpain
					,epistaxis=b.epistaxis
					,fatigue=b.fatigue
					,fever=b.fever
					,flankpain=b.flankpain
					,frequencyofurination=b.frequencyofurination
					,headache=b.headache
					,hematemesis=b.hematemesis
					,hematuria=b.hematuria
					,hemoptysis=b.hemoptysis
					,hypogastricsuprapubicpain=b.hypogastricsuprapubicpain
					,increaseirritability=b.increaseirritability
					,jaundice=b.jaundice
					,lethargic=b.lethargic
					,legcrampsorpain=b.legcrampsorpain
					,lowerextremityedema=b.lowerextremityedema
					,lowerbackpain=b.lowerbackpain
					,myalgia=b.myalgia
					,napepain=b.napepain
					,nausea=b.nausea
					,orthopnea=b.orthopnea
					,palpitations=b.palpitations
					,photophobia=b.photophobia
					,shortnessofbreath=b.shortnessofbreath
					,skinrashes=b.skinrashes
					,stool_bloody_blacktarry_mucoid=b.stool_bloody_blacktarry_mucoid
					,stool_soft_watery=b.stool_soft_watery
					,sweating=b.sweating
					,syncope=b.syncope
					,seizures=b.seizures
					,urgency=b.urgency
					,vomiting=b.vomiting
					,weightloss=b.weightloss
					,wheezes=b.wheezes
					,others=b.others
					,survey_awakeandalert=b.survey_awakeandalert
					,survey_alteredsensorium=b.survey_alteredsensorium
					,heent_essentiallynormal=b.heent_essentiallynormal
					,heent_abnormalpupillaryreaction=b.heent_abnormalpupillaryreaction
					,heent_cervicallympadenopathy=b.heent_cervicallympadenopathy
					,heent_drymucousmembrane=b.heent_drymucousmembrane
					,heent_ictericsclerae=b.heent_ictericsclerae
					,heent_paleconjunctivae=b.heent_paleconjunctivae
					,heent_sunkeneyeballs=b.heent_sunkeneyeballs
					,heent_sunkenfontanelle=b.heent_sunkenfontanelle
					,chest_essentiallynormal=b.chest_essentiallynormal
					,chest_asymmetricalexpansion=b.chest_asymmetricalexpansion
					,chest_decreasedbreathsounds=b.chest_decreasedbreathsounds
					,chest_wheezes=b.chest_wheezes
					,chest_lumpsoverbreast=b.chest_lumpsoverbreast
					,chest_ralescracklesrhonchi=b.chest_ralescracklesrhonchi
					,chest_intercostalribretraction=b.chest_intercostalribretraction
					,cvs_essentiallynormal=b.cvs_essentiallynormal
					,cvs_bradycardia=b.cvs_bradycardia
					,cvs_displacedapexbeat=b.cvs_displacedapexbeat
					,cvs_heaves=b.cvs_heaves
					,cvs_irregularrhythm=b.cvs_irregularrhythm
					,cvs_muffledheartsounds=b.cvs_muffledheartsounds
					,cvs_murmur=b.cvs_murmur
					,cvs_pericardialbulge=b.cvs_pericardialbulge
					,cvs_tachycardia=b.cvs_tachycardia
					,cvs_thrills=b.cvs_thrills
					,abdomen_essentiallynormal=b.abdomen_essentiallynormal
					,abdomen_abdominalrigidity=b.abdomen_abdominalrigidity
					,abdomen_abdominaltenderness=b.abdomen_abdominaltenderness
					,abdomen_hyperactivebowelsounds=b.abdomen_hyperactivebowelsounds
					,abdomen_palpablemass=b.abdomen_palpablemass
					,abdomen_tympaniticdullabdomen=b.abdomen_tympaniticdullabdomen
					,abdomen_uterinecontraction=b.abdomen_uterinecontraction
					,gu_essentiallynormal=b.gu_essentiallynormal
					,gu_bloodstainedfinger=b.gu_bloodstainedfinger
					,gu_cervicaldilatation=b.gu_cervicaldilatation
					,gu_presenceofabnormaldischarge=b.gu_presenceofabnormaldischarge
					,skin_essentiallynormal=b.skin_essentiallynormal
					,skin_clubbing=b.skin_clubbing
					,skin_coldclammy=b.skin_coldclammy
					,skin_cyanosis=b.skin_cyanosis
					,skin_edema=b.skin_edema
					,skin_muscles=b.skin_muscles
					,skin_palenailbeds=b.skin_palenailbeds
					,skin_poorskinturgor=b.skin_poorskinturgor
					,skin_rashespetechiae=b.skin_rashespetechiae
					,skin_swelling=b.skin_swelling
					,skin_weakpulses=b.skin_weakpulses
					,neuro_essentiallynormal=b.neuro_essentiallynormal
					,neuro_abnormalgait=b.neuro_abnormalgait
					,neuro_abnormalposition=b.neuro_abnormalposition
					,neuro_abnormalsensation=b.neuro_abnormalsensation
					,neuro_presenceofabnormalreflex=b.neuro_presenceofabnormalreflex
					,neuro_pooralteredmemory=b.neuro_pooralteredmemory
					,neuro_poormuscletone=b.neuro_poormuscletone
					,neuro_poorcoordination=b.neuro_poorcoordination
					,bpdiastolic=b.bpdiastolic
					,pain=b.pain	
					,syncbatchcode=@syncbatchcode
				FROM patientvitalsign a  INNER JOIN @emr_patientvitalsign b
				ON a.admissionid =  b.admissionid
				WHERE b.admissionid IN (SELECT admissionid FROM patientvitalsign)
				
				
				INSERT INTO [dbo].[patientvitalsign]
				   (admissionid
					,bloodpressure
					,breathing
					,pulse
					,temperature
					,height
					,[weight]
					,heent
					,chest
					,cvs
					,Abdomen
					,skinextremities
					,neuroexamination
					,gu
					,alteredmentalsensorium
					,abdominalcramp_pain
					,abdominaldistention
					,anemia
					,anorexia
					,breathlessness
					,bleedinggums
					,bodyweakness
					,blurringofvision
					,constipation
					,chestpain_discomfort
					,chills
					,cough_dry
					,cough_productive
					,diarrhea
					,dizziness
					,drowsiness
					,dysphagia
					,dyspnea
					,dysuria
					,epigastricpain
					,epistaxis
					,fatigue
					,fever
					,flankpain
					,frequencyofurination
					,headache
					,hematemesis
					,hematuria
					,hemoptysis
					,hypogastricsuprapubicpain
					,increaseirritability
					,jaundice
					,lethargic
					,legcrampsorpain
					,lowerextremityedema
					,lowerbackpain
					,myalgia
					,napepain
					,nausea
					,orthopnea
					,palpitations
					,photophobia
					,shortnessofbreath
					,skinrashes
					,stool_bloody_blacktarry_mucoid
					,stool_soft_watery
					,sweating
					,syncope
					,seizures
					,urgency
					,vomiting
					,weightloss
					,wheezes
					,others
					,survey_awakeandalert
					,survey_alteredsensorium
					,heent_essentiallynormal
					,heent_abnormalpupillaryreaction
					,heent_cervicallympadenopathy
					,heent_drymucousmembrane
					,heent_ictericsclerae
					,heent_paleconjunctivae
					,heent_sunkeneyeballs
					,heent_sunkenfontanelle
					,chest_essentiallynormal
					,chest_asymmetricalexpansion
					,chest_decreasedbreathsounds
					,chest_wheezes
					,chest_lumpsoverbreast
					,chest_ralescracklesrhonchi
					,chest_intercostalribretraction
					,cvs_essentiallynormal
					,cvs_bradycardia
					,cvs_displacedapexbeat
					,cvs_heaves
					,cvs_irregularrhythm
					,cvs_muffledheartsounds
					,cvs_murmur
					,cvs_pericardialbulge
					,cvs_tachycardia
					,cvs_thrills
					,abdomen_essentiallynormal
					,abdomen_abdominalrigidity
					,abdomen_abdominaltenderness
					,abdomen_hyperactivebowelsounds
					,abdomen_palpablemass
					,abdomen_tympaniticdullabdomen
					,abdomen_uterinecontraction
					,gu_essentiallynormal
					,gu_bloodstainedfinger
					,gu_cervicaldilatation
					,gu_presenceofabnormaldischarge
					,skin_essentiallynormal
					,skin_clubbing
					,skin_coldclammy
					,skin_cyanosis
					,skin_edema
					,skin_muscles
					,skin_palenailbeds
					,skin_poorskinturgor
					,skin_rashespetechiae
					,skin_swelling
					,skin_weakpulses
					,neuro_essentiallynormal
					,neuro_abnormalgait
					,neuro_abnormalposition
					,neuro_abnormalsensation
					,neuro_presenceofabnormalreflex
					,neuro_pooralteredmemory
					,neuro_poormuscletone
					,neuro_poorcoordination
					,bpdiastolic
					,pain
					,syncbatchcode)
					SELECT 
					    b.admissionid
						,b.bloodpressure
						,b.breathing
						,b.pulse
						,b.temperature
						,b.height
						,b.[weight]
						,b.heent
						,b.chest
						,b.cvs
						,b.Abdomen
						,b.skinextremities
						,b.neuroexamination
						,b.gu
						,b.alteredmentalsensorium
						,b.abdominalcramp_pain
						,b.abdominaldistention
						,b.anemia
						,b.anorexia
						,b.breathlessness
						,b.bleedinggums
						,b.bodyweakness
						,b.blurringofvision
						,b.constipation
						,b.chestpain_discomfort
						,b.chills
						,b.cough_dry
						,b.cough_productive
						,b.diarrhea
						,b.dizziness
						,b.drowsiness
						,b.dysphagia
						,b.dyspnea
						,b.dysuria
						,b.epigastricpain
						,b.epistaxis
						,b.fatigue
						,b.fever
						,b.flankpain
						,b.frequencyofurination
						,b.headache
						,b.hematemesis
						,b.hematuria
						,b.hemoptysis
						,b.hypogastricsuprapubicpain
						,b.increaseirritability
						,b.jaundice
						,b.lethargic
						,b.legcrampsorpain
						,b.lowerextremityedema
						,b.lowerbackpain
						,b.myalgia
						,b.napepain
						,b.nausea
						,b.orthopnea
						,b.palpitations
						,b.photophobia
						,b.shortnessofbreath
						,b.skinrashes
						,b.stool_bloody_blacktarry_mucoid
						,b.stool_soft_watery
						,b.sweating
						,b.syncope
						,b.seizures
						,b.urgency
						,b.vomiting
						,b.weightloss
						,b.wheezes
						,b.others
						,b.survey_awakeandalert
						,b.survey_alteredsensorium
						,b.heent_essentiallynormal
						,b.heent_abnormalpupillaryreaction
						,b.heent_cervicallympadenopathy
						,b.heent_drymucousmembrane
						,b.heent_ictericsclerae
						,b.heent_paleconjunctivae
						,b.heent_sunkeneyeballs
						,b.heent_sunkenfontanelle
						,b.chest_essentiallynormal
						,b.chest_asymmetricalexpansion
						,b.chest_decreasedbreathsounds
						,b.chest_wheezes
						,b.chest_lumpsoverbreast
						,b.chest_ralescracklesrhonchi
						,b.chest_intercostalribretraction
						,b.cvs_essentiallynormal
						,b.cvs_bradycardia
						,b.cvs_displacedapexbeat
						,b.cvs_heaves
						,b.cvs_irregularrhythm
						,b.cvs_muffledheartsounds
						,b.cvs_murmur
						,b.cvs_pericardialbulge
						,b.cvs_tachycardia
						,b.cvs_thrills
						,b.abdomen_essentiallynormal
						,b.abdomen_abdominalrigidity
						,b.abdomen_abdominaltenderness
						,b.abdomen_hyperactivebowelsounds
						,b.abdomen_palpablemass
						,b.abdomen_tympaniticdullabdomen
						,b.abdomen_uterinecontraction
						,b.gu_essentiallynormal
						,b.gu_bloodstainedfinger
						,b.gu_cervicaldilatation
						,b.gu_presenceofabnormaldischarge
						,b.skin_essentiallynormal
						,b.skin_clubbing
						,b.skin_coldclammy
						,b.skin_cyanosis
						,b.skin_edema
						,b.skin_muscles
						,b.skin_palenailbeds
						,b.skin_poorskinturgor
						,b.skin_rashespetechiae
						,b.skin_swelling
						,b.skin_weakpulses
						,b.neuro_essentiallynormal
						,b.neuro_abnormalgait
						,b.neuro_abnormalposition
						,b.neuro_abnormalsensation
						,b.neuro_presenceofabnormalreflex
						,b.neuro_pooralteredmemory
						,b.neuro_poormuscletone
						,b.neuro_poorcoordination
						,b.bpdiastolic
						,b.pain
						,@syncbatchcode
					FROM @emr_patientvitalsign b 
					WHERE b.admissionid NOT IN (SELECT admissionid from patientvitalsign)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=5
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE progressnotes
				set progressdate=b.progressdate
					,notes=b.notes
					,medicalorder=b.medicalorder
					,carried=b.carried
					,administered=b.administered
					,requested=b.requested
					,endorsed=b.endorsed
					,discontinued=b.discontinued
					,server_id=b.server_id
					,isdeleted=b.isdeleted
					,iscourseward=b.iscourseward
					,prescriptionid=b.prescriptionid
					,local_id=b.progressnoteid
					,syncbatchcode=@syncbatchcode
				FROM progressnotes a  INNER JOIN @emr_progressnotes b
				ON a.progressnoteid =  b.server_id
				WHERE b.server_id IN (SELECT progressnoteid FROM progressnotes)
				
				
				INSERT INTO [dbo].[progressnotes]
				   (admissionid
					,progressdate
					,notes
					,medicalorder
					,carried
					,administered
					,requested
					,endorsed
					,discontinued
					,server_id
					,isdeleted
					,iscourseward
					,prescriptionid
					,local_id
					,syncbatchcode)
					SELECT 
					     b.admissionid
						,b.progressdate
						,b.notes
						,b.medicalorder
						,b.carried
						,b.administered
						,b.requested
						,b.endorsed
						,b.discontinued
						,b.server_id
						,b.isdeleted
						,b.iscourseward
						,b.prescriptionid
						,progressnoteid
						,@syncbatchcode
					FROM @emr_progressnotes b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT progressnoteid from [progressnotes])
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=6
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE prescription
				set admissionid=b.admissionid
					,[description]=b.[description]
					,[date]=b.[date]
					,physician=b.physician
					,name=b.name
					,istemplate=b.istemplate
					,refpatientrequestno=b.refpatientrequestno
					,createdbyid=b.createdbyid
					,dateupdated=GETDATE()
					,updatedbyid=b.updatedbyid
					,isdeleted=b.isdeleted
					,local_id=b.prescriptionid
					,syncbatchcode=@syncbatchcode
				FROM prescription a  INNER JOIN @emr_prescription b
				ON a.prescriptionid =  b.server_id
				WHERE b.server_id IN (SELECT prescriptionid FROM prescription)
				
				
				INSERT INTO [dbo].prescription
					(admissionid
					,[description]
					,[date]
					,physician
					,name
					,istemplate
					,refpatientrequestno
					,datecreated
					,createdbyid
					,dateupdated
					,updatedbyid
					,isdeleted
					,local_id
					,syncbatchcode)
					SELECT 
					     b.admissionid
						,b.[description]
						,b.[date]
						,b.physician
						,b.name
						,b.istemplate
						,b.refpatientrequestno
						,GETDATE()
						,b.createdbyid
						,GETDATE()
						,b.updatedbyid
						,b.isdeleted
						,prescriptionid
						,@syncbatchcode
					FROM @emr_prescription b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT prescriptionid from prescription)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=7
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE prescriptiondetails
				set drugcode=b.drugcode
					,quantity=b.quantity
					,dosage=b.dosage
					,period=b.period
					,per=b.per
					,dateupdated=GETDATE()
					,updatedbyid=b.updatedbyid
					,isdeleted=b.isdeleted
					,frequency=b.frequency
					,local_id=b.presecriptiondetailsid
					,syncbatchcode=@syncbatchcode
				FROM prescriptiondetails a  INNER JOIN @emr_prescriptiondetails b
				ON a.presecriptiondetailsid =  b.server_id
				WHERE b.server_id IN (SELECT presecriptiondetailsid FROM prescriptiondetails)
				
				
				INSERT INTO [dbo].prescriptiondetails
					(prescriptionid
					,drugcode
					,quantity
					,dosage
					,period
					,per
					,datecreated
					,createdbyid
					,dateupdated
					,updatedbyid
					,isdeleted
					,frequency
					,local_id
					,syncbatchcode)
					SELECT 
					    b.prescriptionid
						,b.drugcode
						,b.quantity
						,b.dosage
						,b.period
						,b.per
						,GETDATE()
						,b.createdbyid
						,GETDATE()
						,b.updatedbyid
						,b.isdeleted
						,b.frequency
						,b.presecriptiondetailsid
						,@syncbatchcode
					FROM @emr_prescriptiondetails b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT presecriptiondetailsid from prescriptiondetails)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=17
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE testrequest
				set [requestdate]=b.[requestdate]
					,urgency=b.urgency
					,isfasting=b.isfasting
					,medication=b.medication
					,remarks=b.remarks
					,physician=b.physician
					,syncbatchcode=@syncbatchcode
				FROM testrequest a  INNER JOIN @emr_testrequest b
				ON a.testrequestid =  b.server_id
				WHERE b.server_id IN (SELECT testrequestid FROM testrequest)
				
				
				INSERT INTO [dbo].testrequest
					(admissionid
					,requestdate
					,urgency
					,isfasting
					,medication
					,remarks
					,refpatientrequestno
					,physician
					,destinationoffice
					,clinicid
					,local_id
					,syncbatchcode)
					SELECT 
					     b.admissionid
						,b.requestdate
						,b.urgency
						,b.isfasting
						,b.medication
						,b.remarks
						,b.refpatientrequestno
						,b.physician
						,b.destinationoffice
						,b.clinicid
						,b.testrequestid
						,@syncbatchcode
					FROM @emr_testrequest b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT testrequestid from testrequest)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
		else if @soperation=18
		begin
			BEGIN TRY
			BEGIN TRAN 
				UPDATE testrequestdetail
				set isdaterequired=b.isdaterequired
					,daterequired=case when b.isdaterequired=1 then b.daterequired else null end
					,itemcode=b.itemcode
					,isdeleted=b.isdeleted
					,local_id=b.testrequestdetailid
					,syncbatchcode=@syncbatchcode
				FROM testrequestdetail a  INNER JOIN @emr_testrequestdetail b
				ON a.testrequestdetailid =  b.server_id
				WHERE b.server_id IN (SELECT testrequestdetailid FROM testrequestdetail)
				
				
				INSERT INTO [dbo].testrequestdetail
					(testrequestid
					,testid
					,isdaterequired
					,daterequired
					,itemcode
					,isdeleted
					,local_id
					,syncbatchcode)
					SELECT 
					    b.testrequestid
						,0
						,b.isdaterequired
						,case when b.isdaterequired=1 then b.daterequired else null end
						,b.itemcode as bigint
						,b.isdeleted
						,b.testrequestdetailid
						,@syncbatchcode
					FROM @emr_testrequestdetail b 
					WHERE coalesce(b.server_id,0) NOT IN (SELECT testrequestdetailid from testrequestdetail)
			COMMIT TRAN
			END TRY
			BEGIN CATCH
			ROLLBACK TRAN
			END CATCH
		end
	END
	
	ELSE IF @operation=2
	BEGIN
		if @soperation=0
		begin
			update terminals set token=@devicetoken where terminalcode=@terminalcode
		end
		else if @soperation=1
		begin
			declare @sql nvarchar (1000);
			declare @sqlcondition nvarchar (1000);
			declare @rowcount int=0;
			set @sql = N'update ' + @tablename+' set syncbatchcode='''+@syncbatchcode+'''';
			declare curFields cursor for select mkey, mvalue from @keypair
			open curFields
			
			fetch next from curFields into @colname,@value
			while @@fetch_status=0
			begin
				set @sql=@sql + ', [' + @colname+']=''' +@value + '''';
				fetch next from curFields into @colname,@value
			end
			close curFields
			deallocate curFields
			
			declare curConditions cursor for select mkey, mvalue from @conditions
			open curConditions
			
			set @sqlcondition=' where';
			fetch next from curConditions into @colname,@value
			while @@fetch_status=0
			begin
				set @rowcount=@rowcount+1
				if @rowcount>1
				begin
					set @sqlcondition=@sqlcondition + ' and'
				end
				set @sqlcondition=@sqlcondition + ' ' + @colname+'=''' +@value + '''';
				fetch next from curConditions into @colname,@value
			end
			close curConditions
			deallocate curConditions
			
			set @sql=@sql + @sqlcondition;
			exec sp_executesql @sql;
		end
		
	END

END
GO
PRINT N'Altering [dbo].[spExaminationUpshots]...';


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spExaminationUpshots]
	 @operation int=0,
	 @soperation int=0,
	 @search varchar(30)='',
	 @requestStatus int=0,
	 @destinationoffice char(3)='107',
	 @status smallint=0,
	 @userid int=1011
	 
AS
BEGIN
	 if @operation=0
	 BEGIN
		  if @soperation = 0 --- display Examination UpShots
			BEGIN 
				--DECLARE @viewall int  
				--SET @viewall=0 
				--set @requestStatus=1
				if @requestStatus=0 --view all
					BEGIN 
						SET @requestStatus=3
					END
				else if @requestStatus=1 --view all
					BEGIN 
						SET @requestStatus=4
					END
				else if @requestStatus=2 --view all
					BEGIN 
						SET @requestStatus=5
					END
				else if @requestStatus=3 --view all
					BEGIN 
						SET @requestStatus=6
					END
				
				  DECLARE @employeetypeid int
				  select @employeetypeid=employeetypeid FROM employees WHERE employeeid=@userid
					
					if @destinationoffice = '107'--- xray/utz or @destinationoffice = '005' or @destinationoffice = '006'
					Begin
					
					SELECT distinct Top 100 pd.patientrequestdetailno [prdno] --0
							, pr.[patientrequestno]--1
							 ,a.ptno --2
							 ,p.hospitalno as hospitalno--3 
							 --,p.[lastname]+', '+p.[firstname]+' '+p.[middlename] +' '+ coalesce(p.suffixname,'') as [patientname] --5
							,dbo.fnGetPatientName (p.patientid) [patientname]
							 ,p.birthdate DOB
							 ,dbo.fnGetAge(p.birthdate,a.dateadmitted) Age
							 ,p.gender Gender
							 ,pr.daterequested, --6
							 o.officedescription [office]--7
							 ,i.[itemdescription]  Request--8
							 ,a.[admissionid]--9
							 ,c.ispaid Paid
							 ,pd.[status]
					FROM  [dbo].[patientrequest] pr  
							  inner join [dbo].[patientrequestdetails] pd  on pr.[patientrequestno] = pd.[patientrequestno]
							  inner join admissions a on   a.admissionid= pr.[admissionid] 
							  inner join [dbo].[patients] p   on  p.[patientid] = a.[patientid] 
							  inner join [dbo].[items] i  on pd.[itemcode] = i.[itemcode]
							  inner join offices o on pr.sourceoffice=o.officecode 
							    inner join charges c on c.chargeid=pr.chargeid
					WHERE pd.destinationoffice = @destinationoffice 
						 --(SELECT officecode FROM offices where divisioncode in ('002')) --
						  and pd.status=@requestStatus  and  pr.iscancelled=0
						  and (  pr.[patientrequestno] LIKE @search + '%'
							 or  a.ptno  LIKE @search + '%'
							 or  p.[hospitalno] LIKE @search + '%' 
							 or  p.[lastname]+' ,'+p.[firstname]+' '+p.[middlename]  LIKE @search + '%' 
							 )
						   and	(
									( i.itemcatcode in ('333','444') AND   @employeetypeid in (900) ) --XRAY(333) UTZ(444) RADIOTECH (900)
									OR	( i.itemcatcode ='444' AND i.itemspecs not in('2D Echo','ECG','Arterial Duplex Scan','Venous Duplex Scan','Carotid Duplex Scan') AND @employeetypeid=903 ) --UTZ(444)RADIOTECH (903)
								    OR	( i.itemcatcode ='444' AND i.itemspecs in('2D Echo','ECG','Arterial Duplex Scan','Venous Duplex Scan','Carotid Duplex Scan') AND @employeetypeid=904 ) --Echo/ECG(444) RADIOTECH(904)
								 --   OR	( i.itemcatcode ='444' AND   @employeetypeid in (903,904) ) --UTZ(444)RADIOTECH (903-904)
									OR (i.itemcatcode ='333'  AND   @employeetypeid in (901) ) --XRAY(333)RADIOTECH (901)
									--OR (i.itemcatcode ='555'  AND   @employeetypeid in (904) )
								) --333xray 444utz
						   --and  ((daterequested>  convert(varchar(10),getdate(),101) and pd.status=3) or not pd.status=3)
						 order by pd.patientrequestdetailno desc 
					End
					else if @destinationoffice = '106' --laboratory office
					Begin
							SELECT distinct Top 100   pd.patientrequestdetailno [prdno] --0
									, pr.[patientrequestno]--1
									 ,a.ptno --2
									 ,p.hospitalno as hospitalno--3 
									 --,p.[lastname]+', '+p.[firstname]+' '+p.[middlename] +' '+ coalesce(p.suffixname,'') as [patientname] --5
									 ,dbo.fnGetPatientName (p.patientid) [patientname]
									 ,p.birthdate DOB
									 ,dbo.fnGetAge(p.birthdate,a.dateadmitted) Age
									 ,p.gender Gender
									 ,pr.daterequested, --6
									 o.officedescription [office]--7
									 ,i.[itemdescription]  Request--8
									 ,a.[admissionid]--9
									 ,c.ispaid Paid
									 ,pd.[status]
							FROM  [dbo].[patientrequest] pr  
									  inner join [dbo].[patientrequestdetails] pd  on pr.[patientrequestno] = pd.[patientrequestno]
									  inner join admissions a on   a.admissionid= pr.[admissionid] 
									  inner join [dbo].[patients] p   on  p.[patientid] = a.[patientid] 
									  inner join [dbo].[items] i  on pd.[itemcode] = i.[itemcode]
									  inner join offices o on pr.sourceoffice=o.officecode 
									  inner join charges c on c.chargeid=pr.chargeid
							WHERE pd.destinationoffice = @destinationoffice  
								  and pd.status=@requestStatus    and  pr.iscancelled=0
								  and (  pr.[patientrequestno] LIKE @search + '%'
									 or  a.ptno  LIKE @search + '%'
									 or  p.[hospitalno] LIKE @search + '%' 
									 or  p.[lastname]+','+p.[firstname]+' '+p.[middlename]  LIKE @search + '%' 
									 )
								  and i.itemcatcode = '222' --222lab 
								  --and  daterequested>  DATEADD( dd,-10,getdate())
								 order by pd.patientrequestdetailno desc
					End
					else if @destinationoffice in ('004' , '005' , '006') --??WARDS /OBSOLETE
					Begin
					 SELECT distinct Top 100 pd.patientrequestdetailno [Request Detail No.] --0
									, pr.[patientrequestno]--1
									 ,a.ptno --2
									 ,p.hospitalno as hospitalno--3
									 ,a.admissioncode--4
									 --,p.[lastname]+', '+p.[firstname]+' '+p.[middlename] +' '+ coalesce(p.suffixname,'') as [Name of Patient] --5
									,dbo.fnGetPatientName (p.patientid) [Name of Patient]
									 ,pr.daterequested, --6
									 o.officedescription [Department]--7
									 ,i.[itemdescription]  Request--8
									 ,a.[admissionid]--9
									 ,c.ispaid Paid
							FROM  [dbo].[patientrequest] pr  
									  inner join [dbo].[patientrequestdetails] pd  on pr.[patientrequestno] = pd.[patientrequestno]
									  inner join admissions a on   a.admissionid= pr.[admissionid] 
									  inner join [dbo].[patients] p   on  p.[patientid] = a.[patientid] 
									  inner join [dbo].[items] i  on pd.[itemcode] = i.[itemcode]
									  inner join offices o on pr.sourceoffice=o.officecode 
									  inner join charges c on c.chargeid=pr.chargeid
							WHERE pd.destinationoffice = @destinationoffice  
								  and pd.status=@requestStatus    and  pr.iscancelled=0
								  and (  pr.[patientrequestno] LIKE @search + '%'
									 or  a.ptno  LIKE @search + '%'
									 or  p.[hospitalno] LIKE @search + '%' 
									 or  p.[lastname]+','+p.[firstname]+' '+p.[middlename]  LIKE @search + '%' 
									 )
						 and i.itemcatcode in ('222','102','444','333')
						 --and daterequested>  DATEADD( dd,-10,getdate()) --commented 220713
						 order by pd.patientrequestdetailno desc
					End
					else
					Begin
					SELECT distinct Top 100 pd.patientrequestdetailno [prdno] --0
									, pr.[patientrequestno]--1
									 ,a.ptno --2
									 ,p.hospitalno as hospitalno--3 
									 --,p.[lastname]+', '+p.[firstname]+' '+p.[middlename] +' '+ coalesce(p.suffixname,'') as [patientname] --5
									,dbo.fnGetPatientName (p.patientid) [patientname]
									 ,p.birthdate DOB
									 ,dbo.fnGetAge(p.birthdate,a.dateadmitted) Age
									 ,p.gender Gender
									 ,pr.daterequested, --6
									 o.officedescription [office]--7
									 ,i.[itemdescription]  Request--8
									 ,a.[admissionid]--9
									 ,c.ispaid Paid
							FROM  [dbo].[patientrequest] pr  
									  inner join [dbo].[patientrequestdetails] pd  on pr.[patientrequestno] = pd.[patientrequestno]
									  inner join admissions a on   a.admissionid= pr.[admissionid] 
									  inner join [dbo].[patients] p   on  p.[patientid] = a.[patientid] 
									  inner join [dbo].[items] i  on pd.[itemcode] = i.[itemcode]
									  inner join offices o on pr.sourceoffice=o.officecode 
									  inner join charges c on c.chargeid=pr.chargeid
							WHERE pd.destinationoffice = @destinationoffice  
								  and pd.status=@requestStatus   and  pr.iscancelled=0
								  and (  pr.[patientrequestno] LIKE @search + '%'
									 or  a.ptno  LIKE @search + '%'
									 or  p.[hospitalno] LIKE @search + '%' 
									 or  p.[lastname]+','+p.[firstname]+' '+p.[middlename]  LIKE @search + '%' 
									 ) 
									 --and daterequested>  DATEADD( dd,-10,getdate()) --commented 220713
						 order by pd.patientrequestdetailno desc
					End
					
			END
				
			Else if @soperation=1
					Begin
						  SELECT [status],[destinationoffice]
						  FROM [patientrequestdetails]
						  where [patientrequestdetailno] = @search
					end
				
	 END

				Else if @operation = 2 --Update Patient Request Detail
					Begin
					UPDATE [patientrequestdetails]
							SET [status] = @status
							WHERE [patientrequestdetailno] = @search
							
							if @status=5 --Released
							begin
								update laboratoryresult set datereleased=GETDATE() where patientrequestdetailno=@search
								
								declare @admissionid bigint
								declare @admissiontype varchar(10)
								declare @officecode varchar(3)
								select @admissionid=a.admissionid,@admissiontype=a.admissiontype,@officecode=ad.officecode from admissions a
								inner join admissiondetails ad on a.admissionid=ad.admissionid
								inner join laboratoryresult lr on a.admissionid=lr.admissionid where lr.patientrequestdetailno=@search
								
								if @admissiontype='OPD' and @officecode='302' --Diagnostic
									AND (select count(*) from admissions a
									inner join admissiondetails ad on a.admissionid=ad.admissionid
									inner join patientrequest pr on a.admissionid=pr.admissionid
									inner join patientrequestdetails prd on prd.patientrequestno=pr.patientrequestno
									where a.admissionid=@admissionid
									and prd.[status] not in (5,6) -- 5 Released, 6 - Cancelled
									and pr.iscancelled=0
									and a.isdischarge=0
									)=0
								begin
									update admissions set isdischarge=1
										,dischargestatus='I' --Improved
										,datedischarged=GETDATE()
										,admissionstatus=2
									where admissionid=@admissionid
								end
								--if(select count(*) from admissions a
								--	inner join admissiondetails ad on a.admissionid=ad.admissionid
								--	inner join patientrequest pr on a.admissionid=pr.admissionid
								--	inner join patientrequestdetails prd on prd.patientrequestno=pr.patientrequestno
								--	where a.admissionid=@admissionid 
								--	and a.admissiontype='OPD' 
								--	and ad.officecode='302' --Diagnostic
								--	and prd.[status] not in (5,6) -- 5 Released, 6 - Cancelled
								--	and pr.iscancelled=0
								--	and a.isdischarge=0
								--	)=0
								--begin
								--	--update admissions set isdischarge=1
								--	--	,dischargestatus='I' --Improved
								--	--	,datedischarged=GETDATE()
								--	--	,admissionstatus=2
								--	--where admissionid=@admissionid
								--end
							end
					End
END
GO
PRINT N'Altering [dbo].[spLaboratoryResult]...';


GO


-- =============================================
-- Author:		<Idris Rosales>
-- Create date: <August 20 2012>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spLaboratoryResult]
	 @operation int = 0
	,@sOperation int = 14
	,@Oldlaboratoryid bigint = 0
	,@laboratoryid bigint = 0
    ,@itemcode varchar(200) =''
    ,@admissionid bigint =0
	,@patientrequestno bigint=''
    ,@specimen varchar = ''
    ,@labno  bigint = 0
    ,@datesubmitted datetime = ''
    ,@dateencoded datetime = ''
    ,@encodedby bigint = 0
    ,@pathologist  bigint = 0
    ,@medicaltechnologist  bigint =0
	,@medtech bigint =0
	,@verifiedby bigint =0
	,@employeeno as varchar(50) = ''
    ,@releasedby bigint = 0
    ,@datereleased datetime = ''
	,@search as varchar(255) = '655'
	,@search1 as varchar(255) = '15' 
	,@remarks as varchar(500) = ''
	,@esigmedtech bit = 0
	,@esigverifiedby bit = 0
	,@esigpatho bit = 0
	
	,@NewPk varchar(15) = '' output
AS
BEGIN
SET NOCOUNT ON;
	if @operation = 0 
		Begin		
			if @soperation = 0 --- display Examination UpShots
			Begin
			      SELECT  pd.[isrendered] as [Is Rendered]
					     ,a.[admissionid] as [Admission No.]
					     ,a.ptno as [Patient No.]
					     ,i.[itemspecs] as Specification
					     ,p.[lastname]+' ,'+p.[firstname]+' '+p.[middlename] as [Name of Patient]
				  FROM [dbo].[patients] p
				  inner join [dbo].[admissions] a 
				  on  p.[patientid] = a.[patientid]
				  inner join [dbo].[admissiondetails] ad 
				  on a.[admissionid] = ad.[admissionid]
				  inner join [dbo].[patientrequest] pr 
				  on a.[admissionid] = pr.admissionid
				  inner join [dbo].[patientrequestdetails] pd 
				  on pr.[patientrequestno] = pd.[patientrequestno]
				  inner join [dbo].[items] i 
				  on pd.[itemcode] = i.[itemcode]
			End
			else if @soperation = 1
			Begin
			SELECT  e.[lastname]+' ,'+e.[firstname]+' '+e.[middlename] as [Name]
				   ,e.[employeeno]
			  FROM [dbo].[employees] e
			  inner join [dbo].[employeetypes] et
			  on e.[employeetypeid] = et.[employeetypeid]
			  where et.[employeetypeid] = @search
			End
			else if @soperation = 2
			Begin
			SELECT i.[itemcode]
				  ,i.[itemspecs]
			  FROM [dbo].[items] i
			  inner join [dbo].[itemcategories] ic
			  on i.[itemcatcode] = ic.[itemcatcode]
			  Where ic.[itemcatcode] = @search
			End
			else if @soperation = 3
			Begin
			  SELECT      a.[hospitalno] as [Case No.]
					     ,i.[itemspecs] as Examination
					     ,p.[lastname]+' ,'+p.[firstname]+' '+p.[middlename] as [Name of Patient]
						 ,p.[age]
						 ,p.[gender]
						 ,pr.[requisitionstatus] as  Status
						 ,pr.[patientrequestno] as [request no.]
						 ,e.[lastname]+' ,'+e.[firstname]+' '+e.[middlename] as [requested by]
				  FROM [dbo].[patient] p
				  inner join [dbo].[admissions] a 
				  on  p.[patientid] = a.[patientid]
				  inner join [dbo].[admissiondetails] ad 
				  on a.[admissionid] = ad.[admissionid]
				  inner join [dbo].[patientrequest] pr 
				  on a.[admissionid] = pr.[admissionid]
				  inner join [dbo].[patientrequestdetails] pd 
				  on pr.[patientrequestno] = pd.[patientrequestno]
				  inner join [dbo].[items] i 
				  on pd.[itemcode] = i.[itemcode]
				  inner join [dbo].[employees] e
				  on pr.[requestedbyid] = e.[employeeno]
			  Where a.[admissionid] = @search
			End
			else if @soperation = 4 -- Used in Viewing Patient Details Manage
			Begin
            Select @labno = referencevalue  from referencetable where referencekey = 'labno'
			SELECT	   ad.documentno,@labno as labexaminationno   
							  ,pr.patientrequestno patientrequestno
							  --,p.lastname +', '+ p.firstname +' '+ p.middlename patient
							  ,dbo.fngetpatientname(p.patientid) patient
							  ,p.gender 
							  ,p.age 
							  ,i.itemcode,i.itemspecs , 
							  case when i.itemcatcode='ANCILIARY' then
		 						 'ULTRASOUND REPORT'
		 					  else
		 						 'RADIOGRAPHIC REPORT'
		 					  end reportttitle  ,'' designation
							  ,getdate() dateencoded
							  ,e.lastname+', '+ e.firstname +' '+ e.middlename requestedby
							  ,daterequested  
							  ,-1 radiologistid
							  ,'' radiologistname 
							  ,normalresultdesc resultdescription
							  ,i1.itemdescription film
							  ,qtyfilm filmcount
							  ,0 filmspoil 
							  ,'' remarks
							 ,requisitionstatus,lrd.itemcodefilm,0 itemcodefilm 
							  ,a.[admissionid]
							  ,rm.[roomno]
							  ,a.hospitalno
							  ,prd.patientrequestdetailno
							  ,p.mobileno
							  ,e.employeeid
							  ,p.mothername
							  ,@labno labno
							  ,getdate() resultdateencoded
					FROM admissions a  left outer join admissiondetails ad on a.[admissionid]=ad.[admissionid]
						 inner join patients p on a.patientid=p.patientid 
						 inner   join patientrequest pr on a.[admissionid]=pr.[admissionid]
						 inner   join patientrequestdetails prd on pr.patientrequestno = prd.patientrequestno 
						 --inner   join employees e  on pr.requestedbyid=e.employeeid 
						 inner   join employees e  on a.attendingphysicianid=e.employeeid 
						 inner   join items i  on prd.itemcode=i.itemcode  
						 left outer join labradiologydefault lrd on prd.itemcode=lrd.itemcode
						 left outer   join items i1  on lrd.itemcodefilm=i1.itemcode 
						 inner join [dbo].[rooms] rm
						 on a.roomid  = rm.[roomid]
					WHERE    prd.patientrequestdetailno = @search
			End
			else if @soperation = 5 -- Used in Viewing Patient Details Release
			Begin	
			SELECT	   ad.documentno,lr.labno as  labexaminationno   
							  ,pr.patientrequestno patientrequestno
							  --,p.lastname +', '+ p.firstname +' '+ p.middlename patient
							  ,dbo.fngetpatientname(p.patientid) patient
							  ,p.gender 
							  ,p.age 
							  ,i.itemcode,i.itemspecs , 
							  case when i.itemcatcode='ANCILIARY' then
		 						 'ULTRASOUND REPORT'
		 					  else
		 						 'RADIOGRAPHIC REPORT'
		 					  end reportttitle  ,'' designation
							  ,getdate() dateencoded
							  ,dbo.fnFormatName(1,e.firstname,e.middlename,e.lastname,e.extensioname,e.notes) requestedby
							  ,daterequested  
							  ,-1 radiologistid
							  ,'' radiologistname 
							  ,normalresultdesc resultdescription
							  ,i1.itemdescription film
							  ,qtyfilm filmcount
							  ,0 filmspoil 
							  ,'' remarks
							  ,requisitionstatus,coalesce(lrd.itemcodefilm,0)itemcodefilm 
							  ,a.[admissionid]
							  ,rm.[roomno]
							  ,a.hospitalno
							  ,prd.patientrequestdetailno
							  ,p.mobileno
							  ,e1.lastname+', '+ e1.firstname +' '+ e1.middlename pathologist
							  ,p.mothername
							  ,lr.dateencoded resultdateencoded
					FROM admissions a  left outer join admissiondetails ad on a.[admissionid]=ad.[admissionid]
						 inner join patients p on a.patientid=p.patientid 
						 inner   join patientrequest pr on a.[admissionid]=pr.[admissionid]
						 inner   join patientrequestdetails prd on pr.patientrequestno = prd.patientrequestno  
						 --inner   join employees e  on pr.requestedbyid=e.employeeid 
						 inner   join employees e  on a.attendingphysicianid=e.employeeid 
						 left outer   join items i  on prd.itemcode=i.itemcode  
						 left outer join labradiologydefault lrd on prd.itemcode=lrd.itemcode
						 left outer   join items i1  on lrd.itemcodefilm=i1.itemcode 
						 inner join [dbo].[rooms] rm
						 on a.roomid  = rm.[roomid]
						left outer  join [dbo].[laboratoryresult] lr
						 on prd.patientrequestdetailno = lr.patientrequestdetailno
						 Left outer  join employees e1
						 on lr.pathologist = e1.employeeid
					WHERE    prd.patientrequestdetailno = @search
			End
			else if @soperation = 6
			Begin
			SELECT l.[laboratoryresultid]
			FROM [dbo].[laboratoryresult] l
			inner join [dbo].[patientrequestdetails] pd
			on l.patientrequestdetailno  = pd.[patientrequestdetailno]
			Where pd.[patientrequestdetailno] = @search and l.laboratoryid = @search1
			End
			else if @soperation = 7--CARDIOLOGIST JND 5/16/2012
			Begin
				SELECT [employeeid]
				,[firstname]+' '+[middlename]+'. '+[lastname] As cname
				FROM [employees]
				WHERE specialization like '%Cardio%'
			End
			else if @soperation = 8--PEDIA JND 5/18/2012
			Begin
				SELECT [employeeid]
				,[firstname]+' '+[middlename]+'. '+[lastname] As cname
				FROM [employees]
				WHERE specialization like '%Pedia%'
			End
			else if @soperation = 9
			Begin
				SELECT --p.lastname +', '+ p.firstname +' '+ p.middlename patient
				       dbo.fngetpatientname(p.patientid) patient
					  ,p.gender 
					  ,p.age 
				      ,prd.patientrequestdetailno
					  ,lr.[laboratoryresultid]
					  ,lr.[laboratoryid]
					  ,a.[admissionid]
					  ,prd.[patientrequestdetailno]
					  ,lr.[labno]
					  ,lr.[datesubmitted]
					  ,lr.[dateencoded]
					  ,lr.[encodedby]
					  ,lr.[pathologist]
					  ,lr.[medicaltechnologist]
					  ,lr.[medtech]
					  ,coalesce(lr.[employeeno],0) employeeno
					  ,lr.[releasedby]
					  ,lr.[datereleased]
					  ,rm.[roomno]
					  ,p.mobileno
					  ,p.mothername
					  ,e1.lastname+', '+ e1.firstname +' '+ e1.middlename pathologist
					  ,e2.lastname+', '+ e2.firstname +' '+ e2.middlename medtech
					  ,e3.lastname+', '+ e3.firstname +' '+ e3.middlename physician
				  FROM  admissions a  --inner join admissiondetails ad on ad.[admissionid]=a.[admissionid]
						 inner join patients p on a.patientid=p.patientid 
						 inner   join patientrequest pr on a.[admissionid]=pr.[admissionid]
						 inner   join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno   
						 inner join [dbo].[rooms] rm
						 on a.roomid  = rm.[roomid]
						 left outer join [dbo].[laboratoryresult] lr
						 on prd.[patientrequestdetailno] = lr.patientrequestdetailno
						 left   join employees e  on lr.employeeno=e.employeeid 
						 left outer join employees e1
						 on lr.pathologist = e1.employeeid
						 left outer join employees e2
						 on lr.medtech = e2.employeeid
						 left outer join employees e3
						 on lr.employeeno = e3.employeeid
					WHERE    a.[admissionid] = @search and prd.patientrequestdetailno=@search1
					--GROUP BY p.lastname,p.firstname,p.middlename
					--  ,p.gender 
					--  ,p.age 
				 --     ,prd.patientrequestdetailno
					--  ,lr.[laboratoryresultid]
					--  ,lr.[laboratoryid]
					--  ,lr.[admissionid]
					--  ,lr.[patientrequestdetailno]
					--  ,lr.[labno]
					--  ,lr.[datesubmitted]
					--  ,lr.[dateencoded]
					--  ,lr.[encodedby]
					--  ,lr.[pathologist]
					--  ,lr.[medicaltechnologist]
					--  ,lr.[medtech]
					--  ,lr.[employeeno]
					--  ,lr.[releasedby]
					--  ,lr.[datereleased]
					--  ,rm.[roomno]
					--  ,p.mobileno
					--  ,p.mothername
					--  ,e1.lastname,e1.firstname,e1.middlename
					--  ,e2.lastname,e2.firstname,e2.middlename 
					--  ,e3.lastname,e3.firstname,e3.middlename 
			End
			else if @soperation = 10
			Begin
				SELECT [laboratoryresultdetailsid]
					  ,[laboratoryresultid]
					  ,[laboratorydetailsid]
					  ,[result]
				  FROM [laboratoryresultdetails]
				WHERE [laboratoryresultid]=@search
			End
			else if @soperation = 11
			BEGIN
			SELECT distinct  e1.lastname+', '+ e1.firstname +' '+ e1.middlename medtechnologist 
				from patientrequest pr
				inner join patientrequestdetails pd
				on pr.patientrequestno = pd.patientrequestno 
				inner join laboratoryresult lr
				on pd.patientrequestdetailno = lr.patientrequestdetailno
				left outer join employees e1
				on lr.medicaltechnologist = e1.employeeid
				where pd.patientrequestdetailno=@search
			END
			else if @soperation = 12
			BEGIN
				Select top 1(laboratoryresultid) From laboratoryresult order by laboratoryresultid desc
			END
			else if @sOperation = 13
			begin
				SELECT lr.laboratoryresultid
					,l.laboratoryid
					,l.description
					,lr.datereleased FROM laboratory l
				inner join laboratoryresult lr on lr.laboratoryid=l.laboratoryid
				where lr.admissionid=@search
			end
			else if @soperation = 14 --LIS Royette 2021-08-04
			begin
				declare @lab_showmedtech_sig int
				declare @lab_showverifiedby_sig int
				declare @lab_showpatho_sig int
				
				Select @labno = referencevalue  from referencetable where referencekey = 'labno'
				Select @lab_showmedtech_sig = referencevalue  from referencetable where referencekey = 'lab_showmedtech_sig'
				Select @lab_showverifiedby_sig = referencevalue  from referencetable where referencekey = 'lab_showverifiedby_sig'
				Select @lab_showpatho_sig = referencevalue  from referencetable where referencekey = 'lab_showpatho_sig'
				SELECT	
					a.[admissionid]
					,coalesce(lr.laboratoryresultid,0) laboratoryresultid
					,coalesce(lr.labno,@labno) labexaminationno
					,pr.patientrequestno
					--,p.lastname +', '+ p.firstname +' '+ p.middlename +' '+ coalesce(p.suffixname,'') patient
					,dbo.fngetpatientname(p.patientid) patient
					,p.gender 
					--,p.age
					,dbo.fnGetAge(p.birthdate,a.dateadmitted) age
					,p.homeaddress
					,a.ptno
					,i.itemcode
					,i.itemspecs
					,coalesce(lr.dateencoded,getdate()) dateencoded
					,case when e.employeetypeid<>'555' then '' else dbo.fnFormatName(1,e.firstname,e.middlename,e.lastname,e.extensioname,e.notes) end requestedby
					,pr.daterequested  
					,prd.patientrequestdetailno
					,coalesce(lr.pathologist,0) pathologist
					,coalesce(lr.medicaltechnologist,0) medicaltechnologist
					,coalesce(lr.verifiedby,0) verifiedby
					,coalesce(lr.datesubmitted,getdate()) resultdatesubmitted
					,p.mothername
					,p.fathername
					,p.mobileno
					,p.birthplace [Birth Place]
					,p.birthdate [Birth Date]
					,coalesce(lr.remarks,'') remarks
					,coalesce(lr.esigmedtech,CAST(@lab_showmedtech_sig AS bit)) esigmedtech
					,coalesce(lr.esigvalidatedby,CAST(@lab_showverifiedby_sig AS bit)) esigverifiedby
					,coalesce(lr.esigpatho,CAST(@lab_showpatho_sig AS bit)) esigpatho
					FROM admissions a  
						inner join patients p on a.patientid=p.patientid 
						inner join patientrequest pr on a.[admissionid]=pr.[admissionid]
						inner join patientrequestdetails prd on pr.patientrequestno = prd.patientrequestno  
						--inner join employees e  on pr.requestedbyid=e.employeeid 
						inner join employees e  on a.attendingphysicianid=e.employeeid 
						left outer   join items i  on prd.itemcode=i.itemcode  
						left join [dbo].[laboratoryresult] lr on prd.patientrequestdetailno = lr.patientrequestdetailno
					WHERE    prd.patientrequestdetailno = @search
			end
			else if @soperation = 15
			BEGIN
				SELECT 'Birth Place' defaultval
				union all
				SELECT 'Birth Date'				
			END
			else if @sOperation = 16 --Search released results for merging; Used in LIS
			begin
				select @admissionid=pr.admissionid,@search1=coalesce(l.templateid,0)
				from patientrequest pr
				inner join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno
				inner join items i on i.itemcode=prd.itemcode
				left join laboratoryitems li on li.itemcode=i.itemcode
				left join laboratory l on l.laboratoryid=li.laboratoryid
				where prd.patientrequestdetailno=@search
				
				select cast(0 as bit)chk,prd.patientrequestdetailno,i.itemdescription,i.itemspecs,pr.daterequested
				from patientrequest pr
				inner join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno
				inner join items i on i.itemcode=prd.itemcode
				inner join laboratoryitems li on li.itemcode=i.itemcode
				inner join laboratory l on l.laboratoryid=li.laboratoryid
				left join laboratoryresult lr on lr.patientrequestdetailno=prd.patientrequestdetailno
				where pr.admissionid=@admissionid and prd.[status] not in(5,6) --prd.[status]=5 -- released
				and prd.patientrequestdetailno<>@search
				and coalesce(lr.mergetoresult,0)=0
				and coalesce(l.templateid,0)=@search1
			end
			else if @sOperation = 17 --get all result who use/merge this master result @search=[masterresultid]
			begin
				select prd.patientrequestdetailno,i.itemdescription,i.itemspecs
				from patientrequestdetails prd
				inner join items i on i.itemcode=prd.itemcode
				inner join laboratoryresult lr on lr.patientrequestdetailno=prd.patientrequestdetailno
				where lr.mergetoresult=@search
			end
		End
	else if @operation = 1
		Begin
        Select @labno = referencevalue  from referencetable where referencekey = 'labno'

			INSERT INTO [dbo].[laboratoryresult]
					   ([laboratoryid]
					   ,[itemcode]
					   ,[admissionid]
					   ,[patientrequestdetailno]
					   ,[specimen]
					   ,[labno]
					   ,[datesubmitted]
					   ,[dateencoded]
					   ,[encodedby]
					   ,[pathologist]
					   ,[medicaltechnologist]
					   ,[medtech]
					   ,[verifiedby]
					   ,[employeeno]
					   ,[releasedby]
					   ,[datereleased]
					   ,[remarks]
					   ,[esigmedtech]
					   ,[esigvalidatedby]
					   ,[esigpatho])
				 VALUES
					   (@laboratoryid
					   ,@itemcode
					   ,@admissionid
					   ,@patientrequestno
					   ,@specimen
					   ,@labno
					   ,@datesubmitted
					   ,@dateencoded
					   ,@encodedby
					   ,@pathologist
					   ,@medicaltechnologist
					   ,@medtech
					   ,@verifiedby
					   ,@employeeno
					   ,@releasedby
					   ,@datereleased
					   ,@remarks
					   ,@esigmedtech
					   ,@esigverifiedby 
					   ,@esigpatho)
            update referencetable Set referencevalue = referencevalue + 1
			Where referencekey = 'labno'
			set @NewPk=SCOPE_IDENTITY()
			return @NewPK
		End
	Else if @operation =2
		Begin
		if @soperation = 0
		Begin
		UPDATE [dbo].[laboratoryresult]
		SET [laboratoryid] = @laboratoryid
			  ,[itemcode] = @itemcode
			  ,[admissionid] = @admissionid
			  ,[patientrequestdetailno] = @patientrequestno
			  ,[specimen] = @specimen
			  ,[labno] = @labno
			  ,[datesubmitted] = @datesubmitted
			  ,[dateencoded] = @dateencoded
			  ,[encodedby] = @encodedby
			  ,[employeeno] = @employeeno
			  ,[pathologist] = @pathologist
			  ,[medicaltechnologist] = @medicaltechnologist
			  ,[medtech] = @medtech
			  ,[verifiedby] = @verifiedby
			  ,[releasedby] = @releasedby
			  ,[datereleased] = @datereleased
			  ,remarks = @remarks
			  ,esigmedtech = @esigmedtech
			  ,esigvalidatedby = @verifiedby
			  ,esigpatho = @esigpatho
		WHERE [laboratoryresultid] = @Oldlaboratoryid 
			set @NewPk=@Oldlaboratoryid
			return @NewPK
		End
		else if @soperation = 1
		Begin
		UPDATE [dbo].[patientrequestdetails]
		SET [status] = 5
		WHERE  [patientrequestdetailno] = @patientrequestno
		End
		else if @sOperation=2
		begin
			select @admissionid=pr.admissionid,@laboratoryid=lr.laboratoryid,@itemcode=i.itemcode
					,@Oldlaboratoryid=coalesce(lr.laboratoryresultid,0)
				from patientrequest pr
				inner join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno
				inner join items i on i.itemcode=prd.itemcode
				inner join laboratoryitems li on li.itemcode=i.itemcode
				left join laboratoryresult lr on lr.patientrequestdetailno=prd.patientrequestdetailno
				where prd.patientrequestdetailno=@search1
			if @Oldlaboratoryid=0
			begin
				INSERT INTO [dbo].[laboratoryresult](
				   [laboratoryid],[itemcode],[admissionid],[patientrequestdetailno],[specimen],[labno],[datesubmitted]
				   ,[dateencoded],[encodedby],[pathologist],[medicaltechnologist],[medtech],[employeeno],[releasedby]
				   ,[datereleased],[remarks],[mergetoresult])
				SELECT @laboratoryid,@itemcode,[admissionid],@search1,[specimen],[labno],[datesubmitted]
					,[dateencoded],[encodedby],[pathologist],[medicaltechnologist],[medtech],[employeeno],[releasedby]
					,[datereleased],[remarks],@search
				FROM [dbo].[laboratoryresult] where patientrequestdetailno=@search
			end
			else
			begin
				update [laboratoryresult] set mergetoresult=@search where laboratoryresultid=@Oldlaboratoryid
			end
			update patientrequestdetails set [status]=5 where patientrequestdetailno=@search1
			
			--[spLaboratoryResult]
		end
		else if @sOperation=3
		begin
			update [laboratoryresult] set mergetoresult=0 where patientrequestdetailno=@search
			update patientrequestdetails set [status]=3 where patientrequestdetailno=@search
		end
	End
END
GO
