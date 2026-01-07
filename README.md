# 🧮 Online Pricing Calculator – Backend API

This repository contains the **backend REST API** for the Online Pricing Calculator application.  
It is built using **.NET 8** and follows **Clean Architecture principles**, providing a scalable and maintainable pricing engine with configurable discount rules such as **Buy X Get Y Free** and **Percentage-based discounts**.

---

## ✨ Key Features

- RESTful Web API built with .NET 8
- Clean Architecture (Domain, Application, Infrastructure, API layers)
- PostgreSQL database with normalized schema
- EF Core 8 (Database-first approach)
- Strategy Pattern for discount calculation
- Supports multiple discount types:
  - Percentage-based (e.g., 10% Off)
  - Buy X Get Y Free (e.g., Buy 2 Get 1 Free)
- Item-wise pricing breakdown
- Frontend-agnostic API (React, Angular, etc.)

---

## 🧱 Technology Stack

| Layer | Technology |
|-----|-----------|
| Language | C# |
| Framework | .NET 8 Web API |
| ORM | Entity Framework Core 8 |
| Database | PostgreSQL |
| IDE | Visual Studio 2022 |
| API Docs | Swagger / OpenAPI |

---

## 🏗️ Architecture Overview

The solution follows **Clean Architecture**, separating concerns clearly:

```
online_pricing_calculator_api
│
├── Controllers          → API endpoints
├── Application          → Pricing & discount services
├── Domain               → Core business models & strategies
├── Infrastructure       → EF Core, PostgreSQL, repositories
├── Models               → API request/response DTOs
└── Program.cs           → App bootstrap & middleware
```

### Why Clean Architecture?

- Business rules are independent of frameworks
- Easy to test and extend
- Clear separation between API, business logic, and persistence

---

## 📐 Database Design (ERD)

### Tables Overview

#### 1️⃣ Items
Stores sellable products.

| Column | Description |
|-----|------------|
| itemid | Primary Key |
| name | Product name |
| unitprice | Price per unit |
| isactive | Soft delete flag |
| createdat | Created timestamp |

---

#### 2️⃣ DiscountTypes
Defines the type of discount.

| Column | Description |
|-----|------------|
| discounttypeid | Primary Key |
| code | PERCENTAGE / BUY_X_GET_Y |
| description | Human-readable description |

---

#### 3️⃣ Discounts
Stores discount configuration.

| Column | Description |
|-----|------------|
| discountid | Primary Key |
| discounttypeid | FK → DiscountTypes |
| percentagevalue | Used for percentage discounts |
| buyquantity | Buy X |
| freequantity | Get Y |
| isactive | Enable/disable discount |

---

#### 4️⃣ ItemDiscounts
Maps discounts to items.

| Column | Description |
|-----|------------|
| itemdiscountid | Primary Key |
| itemid | FK → Items |
| discountid | FK → Discounts |

---

### Relationship Summary

- One Item → Many ItemDiscounts
- One Discount → Many ItemDiscounts
- One DiscountType → Many Discounts

This design allows **fully configurable promotions without schema changes**.

---

## 🧠 Pricing & Discount Design

### Strategy Pattern

Each discount type is implemented as a separate strategy:

- `PercentageDiscountStrategy`
- `BuyXGetYDiscountStrategy`

A `DiscountEngine` selects the correct strategy at runtime based on discount type.

### Benefits

- Open/Closed Principle (easy to add new discounts)
- No conditional-heavy pricing logic
- Clean, testable business rules

---

## 🔁 API Endpoints

### Get Items
```
GET /api/items
```

Returns all active items.

---

### Calculate Pricing
```
POST /api/pricing/calculate
```

#### Sample Request

```json
{
  "items": [
    { "itemId": 1, "quantity": 3 }
  ]
}
```

#### Sample Response

```json
{
  "items": [
    {
      "itemId": 1,
      "itemName": "Apple",
      "quantity": 3,
      "rate": 50,
      "subTotal": 150,
      "discount": 50,
      "finalAmount": 100,
      "discountDescription": "Buy 2 Get 1 Free"
    }
  ],
  "subTotal": 150,
  "discount": 50,
  "total": 100
}
```

---

## 🔐 SOLID Principles Applied

- **S**ingle Responsibility – Each service has one responsibility
- **O**pen/Closed – New discounts added without modifying existing logic
- **L**iskov Substitution – Discount strategies are interchangeable
- **I**nterface Segregation – Focused interfaces for repositories
- **D**ependency Inversion – Business logic depends on abstractions

---

## 🚀 Running the Application

### Prerequisites

- .NET 8 SDK
- PostgreSQL
- Visual Studio 2022

---

### Steps

1. Clone the repository:
```bash
git clone https://github.com/Naren4297/online-pricing-backend.git
```

2. Update PostgreSQL connection string in `appsettings.json`

3. Run the application:
```bash
dotnet run
```

4. Open Swagger:
```
https://localhost:{port}/swagger
```

---

## 🔮 Future Enhancements

- Multiple discounts per item with priority
- Unit tests for pricing engine
- Authentication & authorization
- Docker & cloud deployment
- Caching for item master data

---

## 👤 Author

**Naren**  
GitHub: https://github.com/Naren4297

---

## 📜 License

This project is for learning and demonstration purposes.
