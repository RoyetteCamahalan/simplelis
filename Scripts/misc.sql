
--May 06, 2024
select * from referencetable

insert into referencetable values('lab_showverifiedby_sig',0,GETDATE(),null)
insert into referencetable values('lab_showverifiedby',0,GETDATE(),null)
insert into referencetable values('lab_verifiedby_esig_checked',0,GETDATE(),null)
insert into referencetable values('lab_medtech_esig_checked',0,GETDATE(),null)
insert into referencetable values('lab_patho_esig_checked',1,GETDATE(),null)




select * from referencetable
