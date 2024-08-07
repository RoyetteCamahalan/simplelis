
-- =============================================
-- Author:		<Idris Rosales>
-- Create date: <August 20 2012>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spRadiology]
 @operation int=0 
,@soperation int=0
,@Oldlabradiologyid bigint =''
,@labexaminationno bigint =''
,@resultdescription text ='' ---varchar(200)
,@patientrequestdetailno bigint =''
,@admissionid bigint =''
,@itemcode varchar(200) =''
,@filmcount bigint =''
,@filmspoil int =''
,@remarks varchar(200) =''
,@itemcodefilm varchar(200) =''
,@search varchar(20)=''
,@labno  varchar(100) = ''

,@HospitalLogo image=''
AS
BEGIN
SET NOCOUNT ON;
	Declare @HospName as varchar(150)
	Declare @Address varchar(150)
	Declare @Telephone as varchar(150) 
	Declare @eclaimshospitalcode varchar(100)
	Declare @philhealthaccredno varchar(100)
	Declare @Logo as varchar(150) 
	Declare @Hospital as varchar (10)
   ----* Hospital Information Here pls. add this on every @soperation select statement
	SELECT	 @HospName  = [HospName]
			,@Address   = [NoStreet] + ' '+[Barangay]+', '+[MunCity]+ ', '+[Province]
			,@Telephone = [Telephone]
			,@HospitalLogo= hospitallogo
	FROM [dbo].[hospitalinformation]
	if @operation=0
		BEGIN
			if @soperation=0
				Begin			
					Select @labno = referencevalue  from referencetable where referencekey = 'labno'
					SELECT	   a.hospitalno as documentno,@labno as labexaminationno   
							  ,pr.patientrequestno patientrequestno
							  ,p.lastname +', '+ p.firstname +' '+ p.middlename patient
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
							  ,1 radiologistid
							  ,'' radiologistname 
							  ,normalresultdesc resultdescription
							  ,i1.itemdescription film
							  ,qtyfilm filmcount
							  ,0 filmspoil 
							  ,'' remarks
							  ,requisitionstatus
							  ,lrd.itemcodefilm itemcodefilm --coalesce(lrd.itemcodefilm,0)itemcodefilm 
							  ,a.[admissionid]
							  ,p.[patientid]
					FROM admissions a  left join admissiondetails ad on ad.[admissionid]=a.[admissionid]
						 inner join patients p on a.patientid = p.patientid 
						 inner   join patientrequest pr on a.[admissionid]=pr.[admissionid]
						 inner   join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno  
						 --inner   join employees e  on pr.requestedbyid=e.employeeid 
						 inner   join employees e  on a.attendingphysicianid=e.employeeid 
						 inner   join items i  on prd.itemcode=i.itemcode  
						 left outer join labradiologydefault lrd on prd.itemcode=lrd.itemcode
						 left outer   join items i1  on lrd.itemcodefilm=i1.itemcode 
					WHERE    prd.patientrequestdetailno =  @search
					End
			else if @soperation = 1 
				  
		 			SELECT     a.hospitalno as documentno, lr.labexaminationno, le.patientrequestdetailno as 'patientrequestno',  ---ptno
		 			           p.lastname + ', ' + p.firstname + ' ' + p.middlename AS patient, p.gender, p.age, 
		 			           i.itemcode, i.itemspecs,   case when i.itemcatcode='ANCILIARY' then
		 													 'ULTRASOUND REPORT'
		 												  else
		 													 'RADIOGRAPHIC REPORT'
		 												  end reportttitle , case when i.itemcatcode='ANCILIARY' then
		 													 'ULTRASONOLOGIST'
		 												  else
		 													 'RADIOLOGIST'
		 												  end designation 
							  ,le.dateencoded,  e3.lastname+', '+ e3.firstname +' '+ e3.middlename requestedby,
							  pr.daterequested, le.pathologist radiologistid,
							  e4.lastname + ', ' + e4.firstname + ' ' + e4.middlename AS radiologistname,   
							  lr.resultdescription, 
							  i1.itemdescription AS film, lr.filmcount, lr.filmspoil, lr.remarks, pr.requisitionstatus
							 ,i1.itemcode itemcodefilm
							 ,lr.[filmspoil]
							 ,a.[admissionid]
							 ,p.[patientid]
					FROM   patientrequestdetails AS prd 
					  INNER JOIN LabRadiology AS lr  
					  INNER JOIN [dbo].[laboratoryresult] AS le 
					  ON lr.labexaminationno = le.labno 
					  INNER JOIN employees AS e 
					  ON le.encodedby = e.employeeid 
					  left outer join employees AS e2 
					  ON le.releasedby = e2.employeeid 
					  ON prd.patientrequestdetailno = le.patientrequestdetailno
					  INNER JOIN  items AS i 
					  ON prd.itemcode = i.itemcode 
					  left outer join  items AS i1 
					  ON lr.itemcodefilm = i1.itemcode 
					  left outer join employees AS e3 
					  INNER JOIN admissions AS a 
					  left JOIN admissiondetails AS ad 
					  ON a.admissionid= ad.admissionid 
					  INNER JOIN patients AS p 
					  ON a.patientid = p.patientid 
					  INNER JOIN patientrequest AS pr 
					  ON a.admissionid = pr.[admissionid]
					  ON e3.employeeid = pr.requestedbyid 
					  ON le.admissionid = pr.[admissionid] AND 
                      prd.patientrequestno = pr.patientrequestno 
					  inner join employees e4 
					  on le.pathologist=e4.employeeid 
                  	WHERE     prd.patientrequestdetailno = @search
			else if @soperation=3
				SELECT employeeid
					   ,firstname + ' ' + middlename + ' ' + lastname + ltrim(coalesce(' ' + extensioname,'')) + coalesce(notes,'') AS radiologist
				--FROM employees WHERE employeetypeid = @search ORDER BY lastname
				FROM employees WHERE isactive=1 and ((@search='901' and employeetypeid in('900','903','904'))
                                --or (@search='999' and employeetypeid in('999','902'))
                                or employeetypeid=@search)
                                ORDER BY lastname
			else if @soperation = 4
			Begin
			 SELECT  i.[imageid]
					 ,i.[labradiologyid]
					 ,i.[image]
					 ,i.[description]
			FROM [dbo].[images] i
			inner join [dbo].[labradiology] l
		    on i.[labradiologyid] = l.[labradiologyid]
			inner join [dbo].[patientrequestdetails] pd
			on  l. patientrequestdetailno= pd.[patientrequestdetailno]
			Where pd.[patientrequestdetailno] = @search
			End
			else if @soperation = 5
			Begin
			SELECT l.[laboratoryresultid]
			FROM [dbo].[laboratoryresult] l
			inner join [dbo].[patientrequestdetails] pd
			on  l.patientrequestdetailno = pd.[patientrequestdetailno]
			Where pd.[patientrequestdetailno] = @search
			End
			else if @soperation = 6
			Begin
			SELECT l.[labradiologyid]
			FROM [dbo].[labradiology] l
			inner join [dbo].[patientrequestdetails] pd
			on  l.patientrequestdetailno = pd.[patientrequestdetailno]
			Where pd.[patientrequestdetailno] = @search
			End		
			else if @soperation = 7
			Begin
			SELECT [labradiologyid]
			FROM [dbo].[labradiology] 
			where [patientrequestdetailno] = @search
			End
			else if @soperation=8
				SELECT e.employeeid
					   --, lastname+', '+firstname+' '+middlename employeename
					   ,dbo.fnFormatName(1,e.firstname,e.middlename,e.lastname,e.extensioname,e.notes) employeename
					   , designation
					   , prcno
					   , licenceno
					   , u.usersign
				FROM employees e 
				left join users u on e.employeeid=u.employeeid WHERE e.employeeid = @search
			else if @soperation=9
			begin				
				declare @rad_showreader_sig int
				
				Select @labno = referencevalue  from referencetable where referencekey = 'labno'
				Select @rad_showreader_sig = referencevalue  from referencetable where referencekey = 'rad_showreader_sig'
	 			SELECT
	 				coalesce(lr.labexaminationno,@labno) labexaminationno
	 				,le.patientrequestdetailno as 'patientrequestno'
	 				,p.lastname + ', ' + p.firstname + ' ' + p.middlename + coalesce(' ' + p.suffixname,'') AS patient
	 				,p.gender
	 				,dbo.fnGetAge(p.birthdate,a.dateadmitted) age
					,i.itemcode
					,i.itemspecs
					,le.dateencoded
					,dbo.fnFormatName(1,e3.firstname,e3.middlename,e3.lastname,e3.extensioname,e3.notes) requestedby
					,pr.daterequested
					,le.medicaltechnologist radtechid
					,radtech.firstname + ' ' + radtech.middlename + ' ' + radtech.lastname + coalesce(' ' + radtech.extensioname,'') + coalesce(radtech.notes,'') AS radtechname
					,le.pathologist radiologistid
					,dbo.fnFormatName(1,e4.firstname,e4.middlename,e4.lastname,e4.extensioname,e4.notes) AS radiologistname
					,lr.resultdescription
					,i1.itemdescription AS film
					,lr.filmcount
					,lr.filmspoil
					,lr.remarks
					,pr.requisitionstatus
					,i1.itemcode itemcodefilm
					,lr.[filmspoil]
					,a.[admissionid]
					,a.chiefcomplaints
					,case when ereq.employeeid=0 then '' else 
						ereq.firstname + ' ' + ereq.middlename + ' ' + ereq.lastname + rtrim(coalesce(' ' + ereq.extensioname,'')) + coalesce(ereq.notes,'') end AS requestingphysician
					,p.[patientid]
					,coalesce(lr.labradiologyid,0) labradiologyid
					,coalesce(le.laboratoryresultid,0) laboratoryresultid
					,a.ptno
					,a.hospitalno
					,p.birthdate
					,p.homeaddress
					,p.mobileno
					,coalesce(n.Nationality,'') nationality
					,p.emailaddress
					,pv.[height]
					,pv.[weight]
					,'' result
					,e4.designation radiologistdesignation
					,le.dateencoded
					,case when le.esigpatho=1 then u4.usersign else null end radiologistsign
					,coalesce(le.esigpatho,@rad_showreader_sig) esigradiologist
					,e4.licenceno radiologistlicense
					,case when coalesce(ro.officedescription,'')<>'' then ro.officedescription
						when a.admissiontype='opd' then 'OPD'
						when a.admissiontype='er' then 'Emergency' else '' end ward
					,GETDATE() printdate
					,@HospName hospitalname
					,@Address hospitaladdress
					,@Telephone telephone
					,@HospitalLogo hospitallogo
				FROM admissions a 
				inner join patients p on a.patientid=p.patientid 
				inner join patientrequest pr on a.[admissionid]=pr.[admissionid]
				inner join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno
				inner join items i ON prd.itemcode = i.itemcode
				left join LabRadiology lr on prd.patientrequestdetailno=lr.patientrequestdetailno
				left JOIN [dbo].[laboratoryresult] le on prd.patientrequestdetailno=le.patientrequestdetailno
				left outer join items i1 ON lr.itemcodefilm = i1.itemcode 
				left join rooms r on r.roomid=a.roomid
				left join offices ro on r.officecode=ro.officecode
				left join nationality n on p.nationality=n.NationalityCode
				left join patientvitalsign pv on pv.admissionid=a.admissionid
				left outer join employees e3 ON e3.employeeid = le.employeeno 
				left outer join employees e4 ON e4.employeeid = le.pathologist 
				left outer join employees ereq ON ereq.employeeid = a.attendingphysicianid  
				left outer join employees radtech ON radtech.employeeid = le.medicaltechnologist 
				left outer join users u4 ON u4.employeeid = e4.employeeid 
              	WHERE prd.patientrequestdetailno = @search
			end
			else if @soperation=10
			begin
				select prd.patientrequestdetailno
				,i.itemdescription + '-' + convert(varchar,pr.dateposted,101) + ' (' + 'Dr. ' + e.lastname + ')' testdesc
				from admissions a
				inner join patientrequest pr on a.admissionid=pr.admissionid
				inner join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno
				inner join laboratoryresult lr on lr.patientrequestdetailno=prd.patientrequestdetailno
				inner join items i on i.itemcode=prd.itemcode
				left join employees e on e.employeeid=lr.pathologist
				where a.patientid=@search and prd.patientrequestdetailno<>@patientrequestdetailno 
				and i.itemcatcode in ('444','333') and prd.[status]=5
				order by pr.dateposted desc
			end
		END
	else if   @operation=1
		BEGIN
			IF @soperation=0 
				Select @labno = referencevalue  from referencetable where referencekey = 'labno'
				INSERT INTO [dbo].[labradiology]
						   ([labexaminationno]
						   ,[resultdescription]
						   ,[patientrequestdetailno]
						   ,[admissionid]
						   ,[itemcode]
						   ,[filmcount]
						   ,[filmspoil]
						   ,[remarks]
						   ,[itemcodefilm])
				 VALUES
						   (@labexaminationno
						   ,@resultdescription
						   ,@patientrequestdetailno
						   ,@admissionid
						   ,@itemcode
						   ,@filmcount
						   ,@filmspoil
						   ,@remarks
						   ,@itemcodefilm)	
				 UPDATE [dbo].[patientrequestdetails]
				 SET [status] = 4
			     WHERE  [patientrequestdetailno] = @patientrequestdetailno
		END
	else if @operation=2
			BEGIN
				if @soperation = 0
				Begin
				UPDATE [dbo].[labradiology]
				   SET [labexaminationno] = @labexaminationno
					  ,[resultdescription] = @resultdescription
					  ,[patientrequestdetailno] = @patientrequestdetailno
					  ,[admissionid] = @admissionid
					  ,[itemcode] = @itemcode
					  ,[filmcount] = @filmcount
					  ,[filmspoil] = @filmspoil
					  ,[remarks] = @remarks
					  ,[itemcodefilm] = @itemcodefilm
				WHERE [labradiologyid] = @Oldlabradiologyid
				End
			    else if @soperation = 1
				Begin
			    UPDATE [dbo].[patientrequestdetails]
				SET [status] = 5
			    WHERE  [patientrequestdetailno] = @patientrequestdetailno
				End
				else if @soperation = 2
				Begin
			    UPDATE [dbo].[patientrequestdetails]
				SET [status] = 6
			    WHERE  [patientrequestdetailno] = @patientrequestdetailno
				End
			END		
END