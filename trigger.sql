use QuanLyGiaoHang
select * from TheUser
create TRIGGER setCreatedAtUser on TheUser AFTER INSERT AS
BEGIN
	UPDATE TheUser
	SET createdAt = GETDATE()
	from inserted
	where inserted.id=TheUser.id
END
create TRIGGER setUpdatedAtUser on TheUser AFTER INSERT,UPDATE AS
BEGIN
	UPDATE TheUser
	SET updatedAt = GETDATE()
	from inserted
	where inserted.id=TheUser.id
END
create TRIGGER setDeletedAtUser on TheUser AFTER DELETE AS
BEGIN
	UPDATE TheUser
	SET deletedAt = GETDATE()
	from deleted 
	where deleted.id=TheUser.id
END
insert into TheUser (userName,pwd,name,idNumber,phoneNumber,dateOfIssueIdNumber,placeOfIssueIdNumber,theAddress,bankAccountNumber,bankName,createdAt,updatedAt,idRole,deletedAt)
values ('hieptt','123456789','Tran Hiep','01234567865','01665645580',null,N'Lâm Đồng',N'50 Cao Thắng, Đà Lạt','013655489744','BIDV',null,null,1,null)

UPDATE TheUser
SET userName = 'tthiep'
from TheUser
where id=2

DELETE FROM TheUser WHERE id=2