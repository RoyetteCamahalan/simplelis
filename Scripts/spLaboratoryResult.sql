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
					,l.[description]
					,lr.datereleased FROM laboratory l
				inner join laboratoryresult lr on lr.laboratoryid=l.laboratoryid
				where lr.admissionid=@search
			end
			else if @soperation = 14 --LIS Royette 2021-08-04
			begin
				declare @lab_medtech_esig_checked int
				declare @lab_verifiedby_esig_checked int
				declare @lab_patho_esig_checked int
				
				Select @labno = referencevalue  from referencetable where referencekey = 'labno'
				Select @lab_medtech_esig_checked = referencevalue  from referencetable where referencekey = 'lab_medtech_esig_checked'
				Select @lab_verifiedby_esig_checked = referencevalue  from referencetable where referencekey = 'lab_verifiedby_esig_checked'
				Select @lab_patho_esig_checked = referencevalue  from referencetable where referencekey = 'lab_patho_esig_checked'
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
					,coalesce(lr.esigmedtech,CAST(@lab_medtech_esig_checked AS bit)) esigmedtech
					,coalesce(lr.esigvalidatedby,CAST(@lab_verifiedby_esig_checked AS bit)) esigverifiedby
					,coalesce(lr.esigpatho,CAST(@lab_patho_esig_checked AS bit)) esigpatho
					,case when coalesce(ro.officedescription,'')<>'' then ro.officedescription
						when a.admissiontype='opd' then 'OPD'
						when a.admissiontype='er' then 'Emergency' else '' end ward
					,coalesce(r.[description],'') room
					FROM admissions a  
						inner join patients p on a.patientid=p.patientid 
						inner join patientrequest pr on a.[admissionid]=pr.[admissionid]
						inner join patientrequestdetails prd on pr.patientrequestno = prd.patientrequestno  
						--inner join employees e  on pr.requestedbyid=e.employeeid 
						inner join employees e  on a.attendingphysicianid=e.employeeid 
						left join rooms r on r.roomid=a.roomid
						left join offices ro on r.officecode=ro.officecode
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
