# 🪴 Virtual Smart Garden

**Smart. Modular. Scalable.**  
Simulation and remote management of a smart garden with real sensors, dashboards, and dynamic extensibility.

---

## 📌 What is it?

**VirtualSmartGarden** is a multi-layered, extensible system that collects, displays, and processes sensor data (moisture, light, pH, CO₂, etc.) for intelligent garden monitoring and management.

With full support for **real hardware sensors (via serial or API)**, **modern dashboards**, and **remote control capabilities**, it provides a solid foundation for any serious **AgriTech** solution.

---

## 🧠 Architecture

Built following **Clean Architecture** principles to separate concerns clearly:

| Layer             | Description |
|-------------------|-------------|
| `Core`            | Domain model: entities, enums, exceptions, and contracts (interfaces). |
| `Application`     | Business logic: services, use cases, DTOs, mappings. |
| `Infrastructure`  | Infrastructure: EF Core, persistence, repositories, DB communication. |
| `API`             | ASP.NET Core Web API: entry point, dependency injection, controllers. |
| `Shared`          | Shared DTOs, enums, constants for reuse between API & UI. |
| `BlazorUI`        | Web-based UI using Blazor: dashboards, visualization, and interaction. |

---

## ⚙️ Features

- ✅ **Sensor data collection** (real hardware or mock data for testing)  
- ✅ **Real-time dashboards** via Blazor UI  
- ✅ **Scalable and testable** thanks to Clean Architecture  
- ✅ **Extensible with new sensors or rules** without core changes  
- ✅ **Unit & integration tests** at every layer (`/tests` folder)  

---
## 🧪 Demo / Preview
![Screenshot 2025-05-25 220941](https://github.com/user-attachments/assets/fe5f221b-6365-40d9-80fd-c56062988346)


![Screenshot 2025-05-25 212935](https://github.com/user-attachments/assets/056d3495-99d5-4afa-b18a-f584b463a53c)


📈 Usage Examples

📊 Dashboard with temperature/humidity per sensor

🚨 Notification when pH goes out of range

⏱ Scheduled watering when humidity < 30%

📡 Remote control from mobile

## 🔩 Extensibility

Designed to allow:

- Adding new sensors simply by creating new Entities and Repositories in the `Core`.  
- Swapping the database engine (EF Core → Mongo, PostgreSQL, etc.) without touching domain code.  
- Easy integration of ML rule engines for smarter irrigation decisions.  
- Connection to cloud platforms (e.g., Azure IoT Hub or AWS Greengrass) for massive deployments.  

---

## 📁 Project Structure

```bash
/src
├── VirtualSmartGarden.API           # ASP.NET Core API
├── VirtualSmartGarden.Application   # Services, DTOs, Mappings
├── VirtualSmartGarden.Core          # Domain Entities & Contracts
├── VirtualSmartGarden.Infrastructure# EF Core + DB layer
├── VirtualSmartGarden.Shared        # Common objects for UI/API
├── VirtualSmartGarden.BlazorUI     # Web UI
/tests                               # Unit & integration tests


