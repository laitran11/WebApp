
--DROP DATABASE  Estore;
CREATE DATABASE Estore;
GO 
USE Estore;
GO
--DROP TABLE Category;
GO
CREATE TABLE Category(
CategoryId TINYINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
CategoryName NVARCHAR(64) NOT NULL,
ParentId TINYINT REFERENCES Category(CategoryId)
);
 --TRUNCATE TABLE Category;
 SELECT * FROM Category;
 GO
 SET IDENTITY_INSERT Category ON;
 INSERT INTO Category(CategoryId, CategoryName) VALUES
 (1,N' Thời trang nữ'),
 (2,N' Phụ kiện');
 GO
 SET IDENTITY_INSERT Category OFF;
 GO
-- DROP TABLE Product;
CREATE TABLE Product(
	ProductId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CategoryId TINYINT NOT NULL,
	ProductCode VARCHAR(18) NOT NULL,
	ProductName NVARCHAR(128) NOT NULL,
	Price INT NOT NULL,
	Color NVARCHAR(128) NOT NULL);
GO
-- DROP TABLE ProductImage;
SELECT * FROM Product;
GO
CREATE TABLE ProductImage(
	ProductId INT NOT NULL,
	ImageUrl NVARCHAR(64) NOT NULL,
);
GO
-- DROP TABLE ProductSize;
SELECT * FROM ProductImage;
GO
CREATE TABLE ProductSize(
	ProductId INT NOT NULL,
	Size VARCHAR(4) NOT NULL,
	IsSoldOut BIT NOT NULL DEFAULT 0
);
SELECT * FROM ProductSize;
SELECT * FROM ProductImage;
SELECT * FROM Product;
GO
CREATE PROC ClearEStore
AS
BEGIN
	TRUNCATE TABLE Category;
	SET IDENTITY_INSERT Category ON;
	INSERT INTO Category(CategoryId,CategoryName) VALUES
	(1,N'Thời trang nữ'),
	(2,N'Phụ kiện');
	SET IDENTITY_INSERT Category OFF;
	TRUNCATE TABLE ProductImage;
	TRUNCATE TABLE Product;
	TRUNCATE TABLE ProductSize;
END

CREATE TABLE Member(
	MemberId BIGINT NOT NULL PRIMARY KEY,
	Username VARCHAR(32) NOT NULL UNIQUE,
	Password BINARY(64) NOT NULL,
	PasswordStr VARCHAR(256) NOT NULL,
	Email VARCHAR(128) NOT NULL,
	Gender BIT NOT NULL

);

SELECT * FROM Member;
GO
--DROP PROC LoginMember;
GO
CREATE PROC LoginMember(
	@Usr VARCHAR(128),
	@Pwd BINARY(64)
	)
AS
	SELECT * FROM Member WHERE (Username = @Usr OR Email = @Usr) AND Password = @Pwd;
GO
--TRUNCATE TABLE Address;
SELECT * FROM Address;



CREATE TABLE Cart(
	CartId CHAR(16) NOT NULL,
	ProductId INT NOT NULL REFERENCES Product(ProductId),
	Size VARCHAR(8) NOT NULL,
	Quantity SMALLINT NOT NULL,
	PRIMARY KEY(CartId, ProductId,Size)
);
GO
CREATE PROC AddCart(
	@Id CHAR(16) ,
	@ProductId INT ,
	@Size VARCHAR(8) ,
	@Quantity SMALLINT
)
AS
BEGIN
	IF EXISTS (SELECT * FROM Cart WHERE CartId = @Id AND ProductId = @ProductId AND Size = @Size)
	UPDATE Cart SET Quantity += @Quantity WHERE CartId = @Id  AND ProductId = @ProductId AND Size = @Size;
	ELSE
	INSERT INTO Cart(CartId,ProductId, Size, Quantity) VALUES (@Id,@ProductId, @Size, @Quantity)
END
SELECT * FROM Cart;

--DROP PROC GetCategoriesWithParent;
CREATE PROC GetCategoriesWithParent
AS
SELECT Child.CategoryId, Child.CategoryName, Child.ParentId, parent.CategoryName AS ParentName
FROM Category AS Child LEFT JOIN Category AS Parent ON Child.ParentId = Parent.CategoryId;

ALTER TABLE ProductImage DROP COLUMN IsDefault;

SELECT * FROM ProductImage;
ALTER TABLE ProductImage ADD IsDefault BIT NOT NULL DEFAULT 0;


WITH CTE AS(
SELECT ProductId,ImageUrl, ROW_NUMBER() OVER(PARTITION BY ProductId ORDER BY ImageUrl) AS SrNO
FROM ProductImage
)UPDATE ProductImage SET IsDefault = 1 FROM 
ProductImage JOIN CTE ON ProductImage.ProductId = CTE.ProductId
AND ProductImage.ImageUrl = CTE.ImageUrl AND SrNO = 1;

CREATE PROC GetProductsWithImageByCategory(@Id TINYINT)
AS
	SELECT Product.*,ImageUrl FROM Product JOIN ProductImage ON Product.ProductId = ProductImage.ProductId AND IsDefault = 1 
	AND CategoryId = @Id;
GO
SELECT * FROM Cart;
GO
CREATE PROC GetCarts(
	@Id CHAR(16)
)
AS
	SELECT Cart.*, ProductName, ImageUrl, Price
	FROM Cart JOIN Product ON Cart.ProductId = Product.ProductId AND CartId = @Id
	JOIN ProductImage ON Product.ProductId = ProductImage.ProductId AND IsDefault = 1;
GO

EXEC GetCarts @Id ="6p1wggyk9n7qmiy1";

-- DROP TABLE InvoiceDetail;
GO
CREATE TABLE Address(
	AddressId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId BIGINT NOT NULL REFERENCES Member(MemberId),
	WardId INT NOT NULL REFERENCES Ward(WardId),
	AddressName NVARCHAR(128) NOT NULL,
	Phone VARCHAR(16) NOT NULL,
	IsDefault BIT DEFAULT 0 NOT NULL
);
GO
SELECT * FROM Member;
SELECT * FROM Address;

-- DROP TABLE Status;

--DELETE FROM Address;
CREATE TABLE Status(
	StatusId TINYINT NOT NULL PRIMARY KEY,
	StatusName NVARCHAR(32) NOT NULL
);
INSERT INTO Status (StatusId, StatusName) VALUES
	(1, 'Waiting'),
	(2, 'Accept'),
	(3, 'Shipping'),
	(4, 'Cancel'),
	(5, 'Ordered');
GO

CREATE TABLE Invoice(
	InvoiceId CHAR(32) NOT NULL PRIMARY KEY,
	AddressId INT NOT NULL REFERENCES Address(AddressId),
	InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),
	StatusId TINYINT NOT NULL REFERENCES Status(StatusId)
);
GO
CREATE TABLE InvoiceDetail(
	InvoiceId CHAR(32) NOT NULL REFERENCES Invoice(InvoiceId),
	ProductId INT NOT NULL REFERENCES Product(ProductId),
	Quantity SMALLINT NOT NULL,
	Price INT NOT NULL,
	Size VARCHAR(8) NOT NULL
);
GO
CREATE PROC AddInvoice(
	@InvoiceId CHAR(32),
	@CartId CHAR(16),
	@AddressId INT
)
AS
BEGIN
--TRANSACTION
	INSERT INTO Invoice(InvoiceId, AddressId, StatusId) VALUES (@InvoiceId, @AddressId, 1);
	INSERT INTO InvoiceDetail (InvoiceId, ProductId, Quantity, Price, Size) 
		SELECT @InvoiceId, Cart.ProductId, Cart.Quantity, Product.Price, Cart.Size FROM Cart 
		JOIN Product ON Cart.ProductId = Product.ProductId AND CartId = @CartId;
	DELETE Cart WHERE CartId = @CartId;
END

SELECT * FROM Invoice;
-- DROP PROC GetInvoiceById; 
GO
CREATE PROC GetInvoiceById(@Id VARCHAR(32))
AS
SELECT Invoice.*, AddressName,Phone,WardName,DistrictName,ProvinceName,StatusName
	FROM Invoice
	JOIN Status on Invoice.StatusId = Status.StatusId AND Invoice.InvoiceId = @Id
	JOIN Address on Invoice.AddressId = Address.AddressId
	JOIN Ward ON Address.WardId = Ward.WardId
	JOIN District ON Ward.DistrictId = District.DistrictId
	JOIN Province ON District.ProvinceId = Province.ProvinceId
GO
	EXEC GetInvoiceById @Id = '921e0417dff940d5a7536902ae493971'

GO
CREATE PROC GetInvoiceDetailById(@Id VARCHAR(32))
AS
	SELECT InvoiceDetail.*, ProductName, ImageUrl
	FROM InvoiceDetail JOIN Product ON InvoiceId = @Id AND InvoiceDetail.ProductId = Product.ProductId
	JOIN ProductImage ON Product.ProductId = ProductImage.ProductId AND IsDefault = 1
GO
EXEC GetInvoiceDetailById @Id = '921e0417dff940d5a7536902ae493971'






