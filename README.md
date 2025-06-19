#  Restaurant Ordering System

A full-stack web application for restaurant ordering, developed using **ASP.NET Core Web API (Onion Architecture)** and **Angular**. Users can browse restaurants, filter by city or name, view menus, select items, place orders, and receive a confirmation email. The system supports full authentication (JWT, Refresh Tokens) and "Forget Password" via email.

---

##  Technologies Used

###  Backend
- ASP.NET Core Web API 
- Onion Architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core (Code First)
- AutoMapper
- JWT (Access & Refresh Tokens)
- SMTP (Email Sending)
- SQL Server
- FluentValidation (optional)
- Repository & Unit of Work Pattern

###  Frontend
- Angular 19+
- Bootstrap 5
- Angular Forms
- HTTPClient
- Pagination, Search, Filtering

---

##  Features

###  Backend
- CRUD for Restaurants and Menus
- Search restaurants by name and city
- Filter restaurants by category
- Pagination for restaurant listing
- View menu items by restaurant
- Place order with selected items
- Send order confirmation to user via email
- AutoMapper used for DTO mapping
- Authentication using JWT + Refresh Token
- Forget password via secure email link
- Onion Architecture for clean, scalable code

###  Frontend
- List all restaurants with search & filters
- Filter by city and category
- Pagination support
- View menu for selected restaurant
- Select items and place order
- Enter customer data (name, email, phone, address)
- Receive confirmation email after order

---

##  Project Structure (Onion Architecture)

