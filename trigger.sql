use QuanLyGiaoHang
drop table TheUser
select * from TheUser
create TRIGGER setCreatedAtUser on TheUser AFTER INSERT AS
BEGIN
	UPDATE TheUser
	SET createdAt = GETDATE()
	from inserted
	where inserted.id=TheUser.id
END
--alter TRIGGER setUpdatedAtUser on TheUser AFTER INSERT,UPDATE AS
--BEGIN
--	UPDATE TheUser
--	SET updatedAt = GETDATE()
--	from inserted,deleted
--	where inserted.id=TheUser.id and inserted.=TheUser.id
--END
--create TRIGGER setDeletedAtUser on TheUser AFTER DELETE AS
--BEGIN
--	UPDATE TheUser
--	SET deletedAt = GETDATE()
--	from deleted 
--	where deleted.id=TheUser.id
--END
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('hieptt','123456789','Tran Hiep','01234567865','01665645580',null,N'Lâm Đồng',N'50 Cao Thắng, Đà Lạt','013655489744','BIDV',null,null,1,null)

UPDATE TheUser
SET userName = 'tthiep'
from TheUser
where id=2

alter view TheUser_View as 
select id,userName, name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,idRole
from TheUser
where idRole<>1

select *from TheUser

DBCC CHECKIDENT ('TheUser', RESEED, 1)

insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('admin','123456789','admin','01234567865','01665645580',null,N'Lâm Đồng',N'50 Cao Thắng, Đà Lạt','013655489744','BIDV',null,null,1,null)
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('hieptt','123456789','Tran Hiep','01234567865','01665645580',null,N'Lâm Đồng',N'50 Cao Thắng, Đà Lạt','013655489744','BIDV',null,null,2,null)
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('quocnt','123456789','Nguyen Quoc','01234567865','01665645580',null,N'Lâm Đồng',N'50 Cao Bá Quát, Đà Lạt','013655489744','BIDV',null,null,2,null)
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('tinhpt','123456789',N'Shop nước hoa','01234567865','01665645580',null,N'Lâm Đồng',N'50 Trần Khánh Dư, Đà Lạt','013655489744','BIDV',null,null,3,null)
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('Quynhtt','123456789',N'Shop trái cây','01234567865','01665645580',null,N'Lâm Đồng',N'50 Trần Phú, Đà Lạt','013655489744','BIDV',null,null,3,null)