-- =============================================
-- Author:		<Idris Rosales>
-- Create date: <August 20 2012>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spLaboratoryResultdetails]
	 @operation int = 0
	,@sOperation int = 1
	,@Oldlaboratoryresultid bigint = ''
    ,@laboratoryresultid bigint= ''
    ,@laboratorydetailsid bigint = ''
    ,@result varchar(255) = ''	
    ,@resultconversion varchar(255) = ''	
	,@search as varchar(255) = ''
	,@search1 as varchar(255) = ''
	,@search2 as varchar(255) = ''
	,@NewPk varchar(15) = '' output
AS
BEGIN
SET NOCOUNT ON;
	if @operation = 0 
		Begin		
			if @soperation = 0 
			Begin
		    SELECT [laboratoryresultdetailsid]
				  ,[laboratoryresultid]
				  ,[laboratorydetailsid]
				  ,[result]
			FROM [dbo].[laboratoryresultdetails]
			End
			else if @soperation = 1
			Begin
				Select
					  Distinct lrds.[laboratoryresultdetailsid]
					  ,lrds.[laboratoryresultid]
					  ,lrds.[laboratorydetailsid]
					  ,ld.[description]
					  ,lrds.[result]
					  ,ld.normalvalues
					  ,coalesce(ld.unit,'') unit
					  ,coalesce(ld.orderno,0) orderno
				FROM admissions a  left join admissiondetails ad on ad.[admissionid]=a.[admissionid]
					 inner join patients p on a.patientid=p.patientid 
					 inner   join patientrequest pr on a.[admissionid]=pr.[admissionid]
					 inner   join patientrequestdetails prd on pr.patientrequestno=prd.patientrequestno  
					 inner   join employees e  on pr.requestedbyid=e.employeeid 
					 inner   join items i  on prd.itemcode=i.itemcode  
					 left outer join labradiologydefault lrd on prd.itemcode=lrd.itemcode
					 left outer   join items i1  on lrd.itemcodefilm=i1.itemcode 
					 left join [dbo].[rooms] rm
					 on a.roomid  = rm.[roomid]
					 left outer join [dbo].[laboratoryresult] lr
					 on prd.[patientrequestdetailno] = lr.patientrequestdetailno
					 left outer join employees e1
					 on lr.pathologist = e1.employeeid
					 inner join [dbo].[laboratoryresultdetails] lrds
					 on lr.laboratoryresultid = lrds.laboratoryresultid
					 inner join [dbo].[laboratorydetails] ld
					 on lrds.laboratorydetailsid = ld.laboratorydetailsid
				WHERE    prd.patientrequestdetailno = @search And lrds.laboratoryresultid = @search1 AND lr.laboratoryid = @search2 
				order by coalesce(ld.orderno,0),lrds.[laboratoryresultdetailsid] asc
			End
			else if @soperation = 2 --LIS Royette 2021-08-04
			begin
				SELECT   ld.laboratorydetailsid
							 ,ld.description
							 ,ld.normalvalues
							 ,coalesce(ld.visible,'True') visible
							 ,coalesce(ld.unit,'') unit
							 ,coalesce(ld.orderno,0) orderno
							 ,coalesce(ld.x2,0) x2
							 ,coalesce(ld.y2,0) y2
							 ,coalesce(ld.height2,0) height2
							 ,coalesce(ld.width2,0) width2
							 ,coalesce(ld.optionvalues,'') optionvalues
							 ,coalesce(ld.controltype,0) controltype
							 ,coalesce(ld.defaultvalue,'') defaultvalue
							 ,coalesce(ld.labeldescription,'') labeldescription
							 ,coalesce(lrd.laboratoryresultdetailsid,0) laboratoryresultdetailsid
							 ,coalesce(lrd.result,coalesce(ld.defaultvalue,'')) result
							 ,coalesce(ld.normalvaluessi,'') normalvaluessi
							 ,coalesce(ld.unitsi,'') unitsi
							 ,coalesce(ld.siconversion,0) siconversion
							 ,coalesce(lrd.resultconversion,coalesce(ld.defaultvalue,'')) resultconversion
							 ,coalesce(ld.texthighlight,'') texthighlight
					FROM dbo.laboratory l
					INNER JOIN dbo.laboratorydetails ld ON l.laboratoryid = ld.laboratoryid
					left join [dbo].[laboratoryresult] lr on l.laboratoryid = lr.laboratoryid and lr.patientrequestdetailno=@search
					left join [dbo].laboratoryresultdetails lrd on lrd.laboratoryresultid = lr.laboratoryresultid and lrd.laboratorydetailsid = ld.laboratorydetailsid
					where l.laboratoryid=@search2
					order by coalesce(ld.orderno,0)
			end
		End
	else if @operation = 1
		Begin
			if @soperation=0
			begin
				if(@laboratoryresultid=0)
					SELECT top 1@laboratoryresultid = [laboratoryresultid] FROM [dbo].[laboratoryresult] order by  [laboratoryresultid] desc
				DELETE FROM [laboratoryresultdetails] WHERE [laboratorydetailsid]=@laboratorydetailsid AND [laboratoryresultid]=@laboratoryresultid
				INSERT INTO [dbo].[laboratoryresultdetails]
						   ([laboratoryresultid]
						   ,[laboratorydetailsid]
						   ,[result]
						   ,[resultconversion])
				VALUES
						   (@laboratoryresultid
						   ,@laboratorydetailsid
						   ,@result
						   ,coalesce(@resultconversion,''))
			end
			else if @soperation=1
			begin
				INSERT INTO [dbo].[laboratoryresultdetails]
				   ([laboratoryresultid]
				   ,[laboratorydetailsid]
				   ,[result]
				   ,[resultconversion])
				VALUES
				   (@laboratoryresultid
				   ,@laboratorydetailsid
				   ,@result
				   ,coalesce(@resultconversion,''))
			end
		End
	Else if @operation =2
		BEgin
		UPDATE [dbo].[laboratoryresultdetails]
		   SET [laboratoryresultid] = @laboratoryresultid
			  ,[laboratorydetailsid] = @laboratorydetailsid
			  ,[result] = @result
			  ,[resultconversion] = coalesce(@resultconversion,'')
		 WHERE [laboratoryresultdetailsid] = @Oldlaboratoryresultid
		End
END
