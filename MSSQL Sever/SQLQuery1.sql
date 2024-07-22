CREATE DATABASE UserManagement;
GO

USE UserManagement;
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50),
    MiddleName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    DateOfJoining DATE,
    DateOfBirth DATE,
    Email VARBINARY(MAX) NOT NULL,
    Phone VARBINARY(MAX) NOT NULL,
    AlternatePhone NVARCHAR(20),
    Address1 NVARCHAR(100),
    City1 NVARCHAR(50),
    State1 NVARCHAR(50),
    Country1 NVARCHAR(50),
    ZipCode1 NVARCHAR(20),
    Address2 NVARCHAR(100),
    City2 NVARCHAR(50),
    State2 NVARCHAR(50),
    Country2 NVARCHAR(50),
    ZipCode2 NVARCHAR(20),
    Password NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1, 
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Corrected Stored Procedure for adding a new user

CREATE OR ALTER PROCEDURE AddUser
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @Gender NVARCHAR(10),
    @DateOfJoining DATE,
    @DateOfBirth DATE,

    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),

    @AlternatePhone NVARCHAR(20),

    @Address1 NVARCHAR(100),
    @City1 NVARCHAR(50),
    @State1 NVARCHAR(50),
    @Country1 NVARCHAR(50),
    @ZipCode1 NVARCHAR(20),

    @Address2 NVARCHAR(100),
    @City2 NVARCHAR(50),
    @State2 NVARCHAR(50),
    @Country2 NVARCHAR(50),
    @ZipCode2 NVARCHAR(20),

    @IsActive BIT,
    @Password NVARCHAR(100)
AS
BEGIN
    -- Insert the new user into the Users table
    INSERT INTO Users (
        FirstName, LastName, MiddleName, Gender, DateOfJoining, DateOfBirth, 
        Email, 
        Phone, 
        AlternatePhone, 
        Address1, City1, State1, Country1, ZipCode1, 
        Address2, City2, State2, Country2, ZipCode2, 
        IsActive, Password
    )
    VALUES (
        @FirstName, @LastName, @MiddleName, @Gender, @DateOfJoining, @DateOfBirth, 
        ENCRYPTBYPASSPHRASE('YourSecretKey', @Email), 
        ENCRYPTBYPASSPHRASE('YourSecretKey', @Phone), 
        @AlternatePhone, 
        @Address1, @City1, @State1, @Country1, @ZipCode1, 
        @Address2, @City2, @State2, @Country2, @ZipCode2, 
        @IsActive, @Password
    );
    
    -- Return the ID of the newly inserted user
    --SELECT SCOPE_IDENTITY() AS UserId;
END;
GO

EXEC AddUser
    @FirstName = 'John',
    @LastName = 'Doe',
    @MiddleName = 'A',
    @Gender = 'Male',
    @DateOfJoining = '2023-07-20',
    @DateOfBirth = '1990-01-01',

    @Email = 'john.doe@example.com',
    @Phone = '1234567890',

    @AlternatePhone = '0987654321',

    @Address1 = '123 Main St',
    @City1 = 'Anytown',
    @State1 = 'Anystate',
    @Country1 = 'AnyCountry',
    @ZipCode1 = '12345',

    @Address2 = '456 Elm St',
    @City2 = 'Othertown',
    @State2 = 'Otherstate',
    @Country2 = 'OtherCountry',
    @ZipCode2 = '67890',

    @IsActive = 1,
    @Password = 'securepassword';

	INSERT INTO Users (
    FirstName,LastName,MiddleName,Gender,DateOfJoining,DateOfBirth,
    Email,
    Phone,
    AlternatePhone,
    Address1,City1,State1,Country1,ZipCode1,
    Address2,City2,State2,Country2,ZipCode2,
    IsActive,Password
) VALUES (
    'Divyansh','Chauhan','A', 'Male', '2023-07-20', '2002-11-14', 
    ENCRYPTBYPASSPHRASE('YourSecretKey', 'dc@gmail'), 
    ENCRYPTBYPASSPHRASE('YourSecretKey', '7876500078'), 
    '0987654321',
    '123 Main St', 'Anytown', 'Anystate', 'AnyCountry','12345',
    '456 Elm St', 'Othertown', 'Otherstate', 'OtherCountry', '67890',
    1, 'securepassword'
);
