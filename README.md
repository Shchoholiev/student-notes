# Student Notes

A web application designed to facilitate collaborative note-taking among students, enabling them to share and enhance their study materials within a group setting.

## Table of Contents

- [Features](#features)
- [Stack](#stack)
- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [Setup Instructions](#setup-instructions)
- [Configuration](#configuration)
- [Examples](#examples)

## Features

- **Collaborative Note-Taking**: Students can create, edit, and share notes with peers.
- **User Authentication**: Secure login and registration system.
- **Note Organization**: Categorize notes by subjects or topics for easy retrieval.
- **Search Functionality**: Quickly find notes using keywords.
- **File Attachments**: Upload and attach files to notes.
- **Commenting System**: Engage in discussions by commenting on notes.
- **Version Control**: Track changes and revert to previous versions of notes.

## Stack

- **Frontend**: Angular
- **Backend**: ASP.NET Core
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Cloud Storage**: Azure Blob Storage
- **Language**: C# (Backend), TypeScript (Frontend)
- **Framework**: .NET 6

## Installation

### Prerequisites

- **Node.js**: Required for Angular development.
- **Angular CLI**: To manage Angular projects.
- **.NET 6 SDK**: For building and running the ASP.NET Core backend.
- **SQL Server**: Database management system.
- **Azure Account**: For Blob Storage (optional for local development).

### Setup Instructions

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/Shchoholiev/student-notes.git
   cd student-notes
   ```

2. **Backend Setup**:

   - Navigate to the backend project directory:

     ```bash
     cd StudentNotes
     ```

   - Restore dependencies:

     ```bash
     dotnet restore
     ```

   - Apply database migrations:

     ```bash
     dotnet ef database update
     ```

   - Run the backend server:

     ```bash
     dotnet run
     ```

3. **Frontend Setup**:

   - Navigate to the frontend project directory:

     ```bash
     cd StudentNotes.App
     ```

   - Install Angular dependencies:

     ```bash
     npm install
     ```

   - Start the Angular development server:

     ```bash
     ng serve
     ```

   The application should now be accessible at `http://localhost:4200`.

## Configuration

- **Database Connection**: Configure the connection string in `appsettings.json` located in the backend project directory.

- **Azure Blob Storage**: Set up Azure Blob Storage credentials in the backend project's configuration files. For local development without Azure, consider using local storage options.

## Examples

- **Creating a Note**: After logging in, navigate to the "Create Note" section, enter the note details, and save.

- **Sharing a Note**: Once a note is created, use the "Share" option to generate a link or invite peers via email.

- **Commenting on a Note**: Open a note and use the comment section at the bottom to add your input or ask questions.

- **Uploading Attachments**: While creating or editing a note, use the "Attach File" option to upload relevant documents or images.
