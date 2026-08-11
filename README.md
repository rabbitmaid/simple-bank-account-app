# Simple Bank Account App

A simple **Bank Account Management application** built with **C#, .NET, and Windows Forms**. The project demonstrates fundamental **Object-Oriented Programming (OOP)** concepts through a basic banking system.

## Features

* Create a bank account with:

  * Owner name
	
* Create either:

  * **Regular Account**
  * **Savings Account**
* Deposit money into an account
* Withdraw money from an account
* Display account information and balance
* Apply different account behaviors using inheritance and polymorphism

## Account Types

The application supports two types of bank accounts:

### Regular Account

A regular account is created when the **interest percentage is 0**.

### Savings Account

A savings account is created when the **interest percentage is greater than 0**.

This allows the application to determine the appropriate account type based on the provided interest percentage.

## OOP Concepts Demonstrated

This project was designed to practice and demonstrate several important Object-Oriented Programming concepts.

### Encapsulation

Account data such as the owner name, balance, and account ID is controlled through the account class. Access to the data is managed through appropriate properties and methods.

### Inheritance

Different account types inherit common functionality from a base bank account class.

For example:

* `BankAccount`
* `SavingsAccount`

This allows common banking functionality to be shared while still allowing specialized account behavior.

### Polymorphism

The application uses polymorphism to allow different account types to implement or override behavior differently.

For example, withdrawal or interest-related behavior can vary depending on whether the account is a regular or savings account.

### Abstraction

Common account functionality can be defined in a base account class, while specific implementation details are handled by the derived account classes.

## Technologies Used

* **C#**
* **.NET 8.0**
* **Windows Forms**
* **Object-Oriented Programming (OOP)**

## Example Account Information

An account can contain information such as:

```text
Owner: John Doe
Account ID: 8f2c1d4a-7b23-4a8c-91e2-123456789abc
Balance: $1,000.00
```

## Basic Operations

### Create Account

The user provides the account owner name, initial balance, and interest percentage.

* Interest percentage = `0` → Regular Account
* Interest percentage > `0` → Savings Account

### Deposit

The deposit operation increases the account balance by the specified amount.

### Withdraw

The withdrawal operation decreases the account balance when the requested amount can be withdrawn according to the account's rules.

