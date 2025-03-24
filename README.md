# FolderMonitor - Automatic File Uploader for MOVEit Transfer

This project monitors a local folder and uploads new files to MOVEit Transfer Home Folder automatically.

## Instalation

### Prerequisites

Ensure you have the following installed:
* .NET SDK(8.0) - Framework Used.
* Visual Studio 2022  or any C# IDE
* Valid MOVEit Transfer API credentials (username, password)

## Installation & Setup

### Clone the Repository (or simply download the code directly)
Run the following command in your terminal:
```bash
git clone https://github.com/your-repo/FolderMonitor.git
cd FolderMonitor
```
## Running the Application
 Open the Project in Visual Studio  
- Navigate to the **FolderMonitor** directory.  
- Open **`FolderMonitor.sln`** in **Visual Studio**.  
- Restore dependencies using:  
  ```bash
  dotnet restore
- Click Run or press **F5** to start.
## Configuration
This app does not require configuration files. 
Instead, you'll enter your monitoring folder path and MOVEit Transfer credentials directly in the console.

## How It Works
* Authenticates with MOVEit Transfer using Bearer Token
* Retrieves your Home Folder ID
* Monitors the specified local folder
* Uploads new files when detected
