# Monsta Jewelry - E-Commerce Project

## 📚 Introduction
Welcome to Monsta Jewelry, an advanced e-commerce platform designed to offer a seamless and enriching shopping experience for jewelry enthusiasts. This project showcases a sophisticated microservice architecture, ensuring high performance, scalability, and maintainability.

## 🛠️ Technologies Used
### Frontend
- HTML: The backbone of web content, providing structure to the application.
- CSS: For styling and making the application visually appealing.
- Bootstrap: A framework for building responsive and modern web interfaces.
- JavaScript: Adds interactivity to the user experience.
- jQuery: Simplifies DOM manipulation and event handling.

### Backend
- C#: The primary programming language used for backend development.
- ASP.NET Core 8.0 API: For building RESTful services.
- ASP.NET Core 8.0 MVC: For creating the web application's user interface.
- Ocelot Gateway: Manages API Gateway functionalities and routes requests to microservices.
- SignalR: Enables real-time web functionality.
- SqlTableDependency: Monitors SQL Server table changes and processes them in real time.
- Docker: Containerizes applications for consistency across multiple environments.
- Rapid API: Integrates third-party APIs for real-time data such as currency exchange rates.

### Design Patterns
- Microservice Architecture: Decomposes the application into smaller, manageable services.
- Repository Design Pattern: Provides a way to centralize data logic or business logic.
- CQRS: Separates read and write operations to optimize performance and scalability.
- MediatR: Facilitates in-process messaging within the CQRS pattern.
- Onion Architecture: Ensures a clear separation of concerns, promoting maintainability.

### Databases
- Microsoft SQL Server: For structured data storage and transactions.
- MongoDB: A NoSQL database for flexible data modeling.
- PostgreSQL: An advanced, open-source relational database.
- Redis: An in-memory data structure store used for caching.

### ORM Tools
- Entity Framework (Code First): An ORM for interacting with databases using C# objects.
- Dapper: A lightweight ORM for efficient data access.
- Security Tools
- Identity Server 4: Manages authentication and authorization.
- JWT (Json Web Token): Ensures secure communication between client and server.

### Other (Testing Tools)
- HTTPie: A command-line HTTP client for testing APIs.
- Postman: An API development environment for building and testing APIs.
- Swagger: A tool for documenting and testing APIs.

## 🚀 Project Overview
Monsta Jewelry is built with a robust microservice architecture, featuring seven distinct services: cart, shipping, catalog, comments, discounts, messages, and orders. Each service is secured using Identity Server 4 and JWT, with the Ocelot Gateway managing service routing and distribution. The project utilizes SignalR and SqlTableDependency for real-time data updates, ensuring that users receive the most current information instantly. Rapid API integration provides real-time currency exchange rates.

## ✨ Key Features
- Flexible and Scalable Architecture: Designed to scale effortlessly with increasing user demands and data loads.
- Subscription System: Offers email and SMS notifications for promotions and new product launches.
- Detailed Admin Panel: Provides comprehensive tools for managing products, categories, orders, and user interactions.
- Real-time Data Visualization: Leveraging SignalR for immediate updates and notifications.
- Modern and User-Friendly Interface: Crafted for an optimal user experience with intuitive navigation and interactions.
- Diverse Database and Design Patterns: Incorporates multiple databases and design patterns to enhance flexibility and performance.
- Mobile-Responsive Design: Ensures a seamless experience across all devices, including smartphones and tablets.
- Multi-language Support: Accessible to a global audience with multiple language options.

## 📦 Microservices
- Cart Service: Manages user shopping cart operations efficiently.
- Shipping Service: Handles shipping logistics and tracking.
- Catalog Service: Manages product listings and categories.
- Comments Service: Allows users to leave reviews and ratings for products.
- Discounts Service: Manages promotional discounts and offers.
- Messages Service: Facilitates customer inquiries and support.
- Orders Service: Processes and tracks customer orders.

## 📡 Real-Time Functionality
SignalR and SqlTableDependency are used for real-time data processing, ensuring users always have the latest information. Rapid API integration allows real-time currency exchange rates, providing up-to-date financial information.

## 🛡️ Security
The project utilizes Identity Server 4 and JWT for robust security, ensuring that all user data and communications are protected.

## 📈 Admin Features
- Detailed statistics and analytics for informed decision-making.
- Dynamic management of products, categories, and orders.
- Real-time monitoring and updates using SignalR.

## 📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgements
Special thanks to the developers and contributors of the libraries and frameworks used in this project.

![1](https://github.com/gkmnada/MonstaJewelry/assets/102467855/27b3e094-c8f2-4154-b647-e02ec8a7e422)

![1-1](https://github.com/gkmnada/MonstaJewelry/assets/102467855/254b738f-5911-4f0b-ad62-366d0938dfff)

![1-2](https://github.com/gkmnada/MonstaJewelry/assets/102467855/e25ec613-17c3-42ef-b453-b71180a0051f)

![1-3](https://github.com/gkmnada/MonstaJewelry/assets/102467855/6873836e-bfe7-4dd2-8597-8041aa1a9bb6)

![1-4](https://github.com/gkmnada/MonstaJewelry/assets/102467855/9cbf3446-dd47-40f6-9442-91b98ac6473a)

![2](https://github.com/gkmnada/MonstaJewelry/assets/102467855/2eeb447a-34a6-4143-b387-bf49b56867e7)

![3](https://github.com/gkmnada/MonstaJewelry/assets/102467855/489b6d10-79b0-40b9-88e9-7456bc8ae7a1)

![4](https://github.com/gkmnada/MonstaJewelry/assets/102467855/8f581093-f765-4cc7-ab9a-1fa51a6dbb1a)

![4-1](https://github.com/gkmnada/MonstaJewelry/assets/102467855/5ccfa76d-ce07-40d4-a101-a950d02ba98b)

![5](https://github.com/gkmnada/MonstaJewelry/assets/102467855/bee37309-83ed-4c50-b429-eff98c19ec39)

![6](https://github.com/gkmnada/MonstaJewelry/assets/102467855/968a53c0-eb36-4fb9-863c-48773a793900)

![7](https://github.com/gkmnada/MonstaJewelry/assets/102467855/22146c95-2087-40a0-bc77-32da557351be)

![8](https://github.com/gkmnada/MonstaJewelry/assets/102467855/3ee81c46-b433-47b8-a123-1a1157cbbc4a)
