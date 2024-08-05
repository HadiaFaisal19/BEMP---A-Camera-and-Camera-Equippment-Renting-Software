CREATE TABLE Customer (
    CNIC INT PRIMARY KEY,
    CName VARCHAR(50),
    CContact VARCHAR(11) NOT NULL,
    CDOB Date NOT NULL,
	CRName Varchar(50),
	CRContact varchar(11)
);
-- PRODUCT TABLE
CREATE TABLE Product (
    PID INT IDENTITY(1,1) PRIMARY KEY,
    pName VARCHAR NOT NULL,
    PCategory VARCHAR(20),
    PBrand Varchar(15),
	PPrice Float,
	PDescription varchar,
	IsAvailable Bit
);

-- Create the Users table
CREATE TABLE AdminUser (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR (30) NOT NULL UNIQUE,
    Pass VARCHAR (20) NOT NULL
);

CREATE PROCEDURE Signup_User
    @Email VARCHAR(30),
    @Pass VARCHAR(20)
AS
BEGIN
    INSERT INTO AdminUser ( Email, Pass)
    VALUES (@Email, @Pass);
END;

-- Create the Login_User stored procedure
CREATE PROCEDURE Login_Admin
    @Email NVARCHAR(30),
    @Pass NVARCHAR(20)
AS
BEGIN
    SELECT Email
    FROM AdminUser
    WHERE Email = @Email AND Pass = @Pass;
END;

-----------------CUSTOMER PROCEDURES----------------------
-- Procedure to ADD CUSTOMER DETAILS
CREATE PROCEDURE AddCustomer
    @CNIC INT,
    @CName VARCHAR(50),
    @CContact VARCHAR(11),
    @CDOB Date,
	@CRName Varchar(50),
	@CRContact varchar(11)
AS
BEGIN
    INSERT INTO Customer (CNIC, CName, CContact, CDOB, CRName, CRContact)
    VALUES (@CNIC, @CName, @CContact, @CDOB, @CRName, @CRContact);
END

-- Procedure to UPADATE Customer
CREATE PROCEDURE UpdateCustomer
    @CNIC INT,
    @CName VARCHAR(50),
    @CContact VARCHAR(11),
    @CDOB DATE,
    @CRName VARCHAR(50),
    @CRContact VARCHAR(11)
AS
BEGIN
    UPDATE Customer
    SET 
        CName = @CName,
        CContact = @CContact,
        CDOB = @CDOB,
        CRName = @CRName,
        CRContact = @CRContact
    WHERE CNIC = @CNIC;
END;


--Procedure to Get All CUSTOMERS Details
CREATE PROCEDURE GetAllCustomers
AS
BEGIN
    SELECT *
    FROM Customer;
END

--Procedure to Search customer
CREATE PROCEDURE GetCustomerById
    @CNIC VARCHAR(15)
AS
BEGIN
    SELECT *
    FROM Customer
    WHERE CNIC = @CNIC;
END

---------------PRODUCT PROCEDURES--------------------

-- Procedure to ADD Products DETAILS
CREATE PROCEDURE AddProduct
    @PName VARCHAR(50),
    @PCategory VARCHAR(20),
    @PBrand Varchar(15),
	@PPrice Float,
	@PDescription varchar,
	@IsAvailable Bit
AS
BEGIN
    INSERT INTO Product (PName, PCategory, PBrand, PPrice, PDescription, IsAvailable)
    VALUES (@PName, @PCategory, @PBrand, @PPrice, @PDescription, @IsAvailable);
END

-- Procedure to Delete Product
CREATE PROCEDURE DeleteProduct
    @PID INT
AS
BEGIN
    DELETE FROM Product
    WHERE PID = @PID;
END


--Procedure to Get ProductS
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT *
    FROM Product;
END

--Procedure to Get ProductS BY ID
CREATE PROCEDURE GetProductById
    @PID VARCHAR
AS
BEGIN
    SELECT PID, PName, PPrice, IsAvailable
    FROM Product
    WHERE PID = @PID;
END

--Procedure to update Product
CREATE PROCEDURE Update_Product
    @PID INT,
    @pName VARCHAR(255),
    @PCategory VARCHAR(20),
    @PBrand VARCHAR(15),
    @PPrice FLOAT,
    @PDescription VARCHAR(255),
    @IsAvailable BIT
AS
BEGIN
    UPDATE Product
    SET 
        pName = @pName,
        PCategory = @PCategory,
        PBrand = @PBrand,
        PPrice = @PPrice,
        PDescription = @PDescription,
        IsAvailable = @IsAvailable
    WHERE PID = @PID;
END;


---------------ORDER TABLE---------

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    StartShift VARCHAR(20) NOT NULL,
    EndShift VARCHAR(20) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    SubTotal DECIMAL(18, 2) NOT NULL,
    Discount DECIMAL(18, 2) NOT NULL,
    Total DECIMAL(18, 2) NOT NULL,
    Remarks VARCHAR(255)
);

CREATE TABLE OrderProducts (
    OrderId INT,
    ProductId INT,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(PID),
    UNIQUE (OrderId, ProductId) -- Ensures a product can only be booked once per order
);

---------------ORDER PROCEDURES--------------------

-- Procedure to Get All Orders
CREATE PROCEDURE GetAllOrders
AS
BEGIN
    SELECT * FROM Orders;
END;

-- Procedure to Get Order By Id
CREATE PROCEDURE GetOrderById
    @Id INT
AS
BEGIN
    SELECT * FROM Orders WHERE Id = @Id;
    SELECT p.* FROM Product p
    INNER JOIN OrderProducts op ON p.PID = op.ProductId
    WHERE op.OrderId = @Id;
END;


-- Procedure to Delete Order
CREATE PROCEDURE DeleteOrder
    @Id INT
AS
BEGIN
    DELETE FROM OrderProducts WHERE OrderId = @Id;
    DELETE FROM Orders WHERE Id = @Id;
END;