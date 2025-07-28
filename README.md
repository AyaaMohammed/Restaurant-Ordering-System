
# 🍽️ Restaurant Ordering System

A full-stack restaurant ordering web application built with **ASP.NET Core Web API** (using Onion Architecture) and **Angular**.  
Users can browse restaurants, filter by city or name, view menus, select items, place orders, and receive confirmation via email.

---

## 🚀 Technologies Used

### 🔧 Backend
- ASP.NET Core Web API (.NET 7 or 8)
- Onion Architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core (Code First)
- AutoMapper
- JWT Authentication (Access & Refresh Tokens)
- SMTP (Email sending for order and password recovery)
- SQL Server
- FluentValidation (optional)
- Repository & Unit of Work Pattern

### 💻 Frontend
- Angular 17+ (or latest)
- Bootstrap 5
- Angular Reactive Forms
- Angular HTTPClient
- Pagination, Search, Filtering

---

## ✅ Key Features

### 🔙 Backend
- CRUD operations for restaurants and menus
- Filter/search restaurants by name, city, or category
- Pagination support for listings
- Order placement with selected items
- Send confirmation email on successful order
- JWT authentication with refresh token strategy
- "Forget Password" functionality with secure email link
- Clean code architecture using Onion layering
- AutoMapper for mapping DTOs

### 🔜 Frontend
- View restaurants with search and filter
- Filter by city and category
- Paginate restaurant listings
- View menu items of selected restaurant
- Add items to cart and place an order
- Submit customer info (name, email, phone, address)
- Receive email confirmation after placing an order

---

## 📁 Project Structure (Onion Architecture)

```
Restaurant-Ordering-System/
│
├── Restaurant.Domain/           → Entities and Interfaces
├── Restaurant.Application/      → Services, DTOs, Business Logic
├── Restaurant.Infrastructure/   → EF Core, Repositories, Email
├── Restaurant.API/              → Controllers, JWT Auth, Startup
└── Angular/                     → Angular Frontend (restaurant UI)
```

---

## 🧪 How to Run the Project

### 🖥️ 1. Clone the Repository

```bash
git clone https://github.com/AyaaMohammed/Restaurant-Ordering-System.git
cd Restaurant-Ordering-System
```

---

### ⚙️ 2. Setup Backend (API)

- Open `Restaurant.API` in Visual Studio
- Update `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RestaurantDB;Trusted_Connection=True;"
}
```

- Apply EF Core migrations and update the database:

```bash
dotnet ef database update
```

- Run the API:

```bash
dotnet run
```

It will be available at `https://localhost:5001` or `http://localhost:5000`.

---

### 🌐 3. Setup Frontend (Angular)

```bash
cd Angular
npm install
ng serve
```

Angular will run at:  
👉 `http://localhost:4200/`

---

## 📬 Admin Login (Example)

```text
Email: admin@restaurant.com
Password: Admin@123
```

> You may seed or register an admin and manually update its role in the database.

---

## 📦 Download & Deployment

- Download as `.zip` or clone the repo.
- Deploy Web API (e.g., Azure, IIS) and Angular separately (e.g., Firebase, Netlify).
- Configure environment-specific settings in `appsettings.{Environment}.json` and `environment.ts`.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙋‍♀️ Author

**Aya Mohamed Nafed**  
[![LinkedIn](https://img.shields.io/badge/LinkedIn-blue?logo=linkedin&style=flat-square)](https://www.linkedin.com/in/aya-mohamed-nafed)

---

## ⭐ Feedback & Contributions

Pull requests, stars, and issues are always welcome!  
If you found this project useful, feel free to give it a ⭐ and share it 🙌
