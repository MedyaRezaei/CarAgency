
# Car Agency Login System

This is a C#, Windows Forms desktop application for user registration and login using SQL Server for a real car agency project.

## How to run
1. Open the application in Visual Studio.
2. Make sure SQL Server is running on your machine.
3. Create a database on your SQL Server and create the following table named Users:

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
	Phonenumber CHAR(11)NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);

3. Edit the `App.config` file to match your local SQL Server instance. (In the Data Source field, write the name of your SQL Server and in the Catalog field, enter the name of the database in which you created the table.)

4. Press **Start (F5)** to launch the login page

## Features:

- User registration (Register)
- User login with SQL authentication Server
- Forgotten password
- Role-based access (e.g., manager vs. driver)
- Form navigation (login ↔ register)
- SQL Server data storage
- Error handling and basic validation

# Login feature:

- Users enter their username and password to log in.
- The login information is checked against the SQL Server users table.

- If the login is successful:

- The user is redirected based on their role (e.g., manager, driver, admin, operator).
- If the login is unsuccessful:

- An error message is displayed.

## Login validation includes:

- Empty field check
- User existence check
- Password match validation

# Registration feature:

- New users can register by clicking the register button from the login page.

- The registration form collects the following:

- Username

- Password

- Confirm Password

- Email

- Role (dropdown menu)

- Address

- If the registration is successful:

- User data is stored in a SQL Server database.

## Registration validation includes:

- Required fields check

- Password matching and password confirmation

- Unique username and email

## Forgot Password Feature:

- Users can click "Forgot your password?" on the login form.

- They are redirected to the "Forgot your password?" form.

- The logic can be customized to reset the password via:

- Enter username

- Enter new password

=======
#Agency Login System

This is a C#, Windows Forms desktop application for user registration and login using SQL Server for a real car agency project.

## How to run
1. Open the application in Visual Studio.
2. Make sure SQL Server is running on your machine.
3. Create a database on your SQL Server and create the following table named Users:

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
	Phonenumber CHAR(11)NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);

3. Edit the `App.config` file to match your local SQL Server instance. (In the Data Source field, write the name of your SQL Server and in the Catalog field, enter the name of the database in which you created the table.)

4. Press **Start (F5)** to launch the login page

## Features:

- User registration (Register)
- User login with SQL authentication Server
- Forgotten password
- Role-based access (e.g., manager vs. driver)
- Form navigation (login ↔ register)
- SQL Server data storage
- Error handling and basic validation

# Login feature:

- Users enter their username and password to log in.
- The login information is checked against the SQL Server users table.

- If the login is successful:

- The user is redirected based on their role (e.g., manager, driver, admin, operator).
- If the login is unsuccessful:

- An error message is displayed.

## Login validation includes:

- Empty field check
- User existence check
- Password match validation

# Registration feature:

- New users can register by clicking the register button from the login page.

- The registration form collects the following:

- Username

- Password

- Confirm Password

- Email

- Role (dropdown menu)

- Address

- If the registration is successful:

- User data is stored in a SQL Server database.

## Registration validation includes:

- Required fields check

- Password matching and password confirmation

- Unique username and email

## Forgot Password Feature:

- Users can click "Forgot your password?" on the login form.

- They are redirected to the "Forgot your password?" form.

- The logic can be customized to reset the password via:

- Enter username

- Enter new password

- Repeat password
