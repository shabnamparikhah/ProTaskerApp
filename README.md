# ProTasker

ProTasker is a **Kanban-style task management web application** built with **ASP.NET MVC**, **Entity Framework Core**, **Bootstrap**, and **jQuery**, featuring a **RESTful API** for external integrations.

It allows users to:

- ✅ Create and manage tasks per project  
- ✅ Organize tasks on a **visual Kanban board**  
- ✅ Drag & drop tasks between **To Do, In Progress, and Done**  
- ✅ Update and track task progress **in real-time** with AJAX  
- ✅ **Secure Authentication & Authorization** using ASP.NET Identity  
- ✅ **RESTful API** for programmatic task management

---

## 🛠 Technologies Used

- **Backend:** ASP.NET MVC 6, Entity Framework Core, ASP.NET Web API  
- **Frontend:** Bootstrap 5, jQuery, jQuery UI (for Drag & Drop)  
- **Database:** SQL Server / LocalDB  
- **Authentication:** ASP.NET Core Identity  
- **Version Control:** GitHub  

---

## 🌐 RESTful API Endpoints

ProTasker also provides an **API** for programmatic access to tasks:

| Method | Endpoint                     | Description                       |
|--------|------------------------------|-----------------------------------|
| GET    | `/api/tasks`                  | Get all tasks                     |
| GET    | `/api/tasks/{id}`             | Get task by ID                    |
| POST   | `/api/tasks`                  | Create a new task                 |
| PUT    | `/api/tasks/{id}`             | Update task status or title       |
| DELETE | `/api/tasks/{id}`             | Delete a task                     |

> API responses are returned in **JSON** format and require **Authentication** for write operations.

---

## 🚀 How to Run the Project

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YOUR_USERNAME/ProTasker.git
   cd ProTasker
