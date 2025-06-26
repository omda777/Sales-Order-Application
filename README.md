# 🛒 Sales Order System

## 📖 Overview
The **Sales Order System** is a console-based C# application built for an Object-Oriented Programming (OOP) assignment. It simulates a retail sales workflow, allowing users to manage customers, stock, orders, and payments. It follows core OOP principles such as abstraction, encapsulation, inheritance, and polymorphism, and utilizes features like operator overloading and class hierarchies.

---

## 🚀 Features
- 👤 **Customer Management**  
  Add, update, and delete customers (ID, name, address, phone).

- 📦 **Product & Stock Management**  
  Add, update, and delete products (ID, number, name, price, quantity, type).

- 🧾 **Order Management**  
  Create and manage orders with status tracking (`New`, `Hold`, `Paid`, `Canceled`).

- ➕ **Order Item Operations**  
  Operator overloading for adjusting order quantities: `++`, `--`, `+=`, `-=`.

- 💰 **Payment Processing**  
  Supports **cash**, **credit**, and **check** payment types.

- 🔄 **Transaction Tracking**  
  Record transactions linking payments with orders.

- 🧾 **Reports**  
  Print reports: customer list, stock data, and transaction history.

---

##  Project Structure
Sales_Order_Application/
│
├── CustomerSystem/
│ ├── Person.cs # Base class: name, address, age
│ ├── Customer.cs # Extends Person with ID, phone
│ └── Customers.cs # Customer list and operations
│
├── Products/
│ ├── Product.cs # Product definition and methods
│ └── Stock.cs # List of products with stock control
│
├── OrderSystem/
│ ├── Order.cs # Order header: number, date, status, customer, items
│ └── OrderItem.cs # Line item details with quantity operations
│
├── PaymentSystem/
│ ├── Payment.cs # Abstract base for all payments
│ └── Transaction.cs # Links payments and orders
│
└── Program.cs # Main menu and user interaction
## UML Digram 
![System Diagram](Photo/UML)
