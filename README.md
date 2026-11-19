# Simple Bank Account App

A simple **Bank Account Management application** built with **C#, .NET 8.0, Windows Forms, ADO.NET, and SQLite**. The project demonstrates fundamental **Object-Oriented Programming (OOP)** concepts through a basic banking system, alongside database connectivity and data persistence using ADO.NET.

## Features

- Create a bank account with:
  - Owner name
  - Interest percentage
- Create either:
  - **Regular Account**
  - **Savings Account**
- Deposit money into an account
- Withdraw money from an account
- Display account information and balance
- Apply different account behaviors using inheritance and polymorphism
- Store account information in an SQLite database
- Retrieve saved accounts when the application starts
- Persist account balances and account details between application sessions

## Account Types

The application supports two types of bank accounts:

### Regular Account

A regular account is created when the **interest percentage is 0**.

### Savings Account

A savings account is created when the **interest percentage is greater than 0**.

This allows the application to determine the appropriate account type based on the provided interest percentage.

## Database Integration

The application uses **ADO.NET** with the **Microsoft.Data.Sqlite** provider to connect to and interact with an SQLite database.

Database operations include:

- Creating the database and the Accounts table if they do not already exist.
- Inserting newly created bank accounts into the database.
- Retrieving existing accounts from the database when the application starts.
- Persisting account information, including account number, owner, account type, interest rate, and balance.

The database is stored locally in the Windows **Local Application Data** directory, keeping it separate from the application source code.

### Database Technologies

- **ADO.NET:** Provides the data access functionality for communicating with the database.
- **Microsoft.Data.Sqlite:** The .NET data provider used to connect to SQLite.
- **SQLite:** A lightweight, file-based relational database used to store account information.

## Technologies Used

- **C#**
- **.NET 8.0**
- **Windows Forms**
- **Object-Oriented Programming (OOP)**
  - Encapsulation
  - Inheritance
  - Polymorphism
- **ADO.NET**
- **SQLite**
- **Microsoft.Data.Sqlite (NuGet Package)**

## Example Account Information

An account can contain information such as:

```text
Owner: John Doe
Account ID: 8f2c1d4a-7b23-4a8c-91e2-123456789abc
Balance: $1,000.00
```

## Basic Operations

### Create Account

The user provides the account owner name and interest percentage.

- Interest percentage = `0` → Regular Account
- Interest percentage > `0` → Savings Account

The newly created account is saved to the SQLite database.

### Deposit

The deposit operation increases the account balance by the specified amount.

### Withdraw

The withdrawal operation decreases the account balance when the requested amount can be withdrawn according to the account's rules.

### Database Persistence

Account information is saved in the SQLite database, allowing previously created accounts and their balances to be loaded again when the application is reopened.