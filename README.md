# Blazor Server Data Management Application

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
  - [1. Clone the Repository](#1-clone-the-repository)
  - [2. Navigate to the Project Directory](#2-navigate-to-the-project-directory)
  - [3. Restore Dependencies](#3-restore-dependencies)
  - [4. Build the Project](#4-build-the-project)
  - [5. Run the Application](#5-run-the-application)
- [Configuration](#configuration)
- [Usage](#usage)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Overview

The **Blazor Server Data Management Application** is a web-based tool designed to manage data items efficiently. It offers functionalities such as creating, reading, updating, and deleting (CRUD) data items seamlessly. Enhanced with intuitive search functionality, comparison features, and a user-friendly interface, this application ensures a smooth and productive user experience.

## Features

- **CRUD Operations**: Easily create, read, update, and delete data items.
- **Enhanced Search**: Perform searches by pressing the **Enter** key for a more intuitive experience.
- **Item Comparison**: Select up to two items to compare their details side-by-side.
- **Fixed Compare Button**: A fixed **Compare** button positioned at the bottom-right corner ensures easy access regardless of scroll position.
- **Responsive Design**: Optimized for various devices and screen sizes.
- **Accessibility Enhancements**: ARIA labels, keyboard navigation support, and more to ensure an inclusive user experience.
- **Visual Feedback**: Loading indicators, highlighted search terms, and success/error messages provide clear feedback to users.
- **Bootstrap Integration**: Utilizes Bootstrap for consistent styling and responsive layouts.
- **Tooltips**: Informative tooltips on action buttons enhance usability.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **.NET SDK**: [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later installed on your machine.
- **Git**: [Git](https://git-scm.com/downloads) installed for cloning the repository.
- **Code Editor/IDE**: [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with the C# extension.
- **Web Browser**: A modern web browser like Chrome, Firefox, Edge, or Safari.

## Installation

Follow these steps to set up the project locally.

### 1. Clone the Repository

Start by cloning the repository to your local machine using Git.

```bash
git clone https://github.com/andrewhamilton375/OCCU-Project.git
```

### 2. Navigate to the Project Directory

Move into the project directory you just cloned.

```bash
cd OCCU-Project
```

### 3. Restore Dependencies

Restore the necessary NuGet packages required for the project.

```bash
dotnet restore
```

### 4. Build the Project

Compile the project to ensure all dependencies are correctly set up.

```bash
dotnet build
```

### 5. Run the Application

Start the Blazor Server application.

```bash
dotnet run
```

After running the above command, you should see output similar to:

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /path/to/your-repo-name
```

Open your web browser and navigate to [https://localhost:5001](https://localhost:5001) to access the application.

## Configuration

This application uses a JSON file for data storage instead of a traditional database. Follow these steps to configure and manage the JSON data:

1. **Locate the Data JSON File**

   The data is stored in a JSON file named `data.json` located in the `wwwroot/data/` directory. The full path is typically:

   ```
   wwwroot/data/data.json
   ```

2. **Initial Setup**

   - Upon the first run, if `data.json` does not exist, the application will create it automatically with an empty array.
   - Ensure that the `wwwroot/data/` directory has the necessary read and write permissions.

3. **Editing the JSON File**

   - To manually add or modify data items, open `data.json` in a text editor.
   - The structure of each data item should align with the `DataItem` model. Example:

     ```json
     [
       {
         "Name": "Item1",
         "Field1": "Value1",
         "Field2": "Value2",
         "Field3": "Value3",
         "UpdateTimestamp": "2023-10-01T12:34:56"
       },
       {
         "Name": "Item2",
         "Field1": "ValueA",
         "Field2": "ValueB",
         "Field3": "ValueC",
         "UpdateTimestamp": "2023-10-02T08:22:33"
       }
     ]
     ```

4. **Data Integrity**

   - Ensure that each `Name` is unique to prevent conflicts during CRUD operations.
   - Avoid manual edits that could corrupt the JSON structure. Use the application's interface for managing data when possible.

## Usage

Once the application is running, you can perform the following actions:

1. **Search Data Items**

   - Enter a search term in the search box.
   - Press the **Enter** key or click the **Search** button to filter results.
   - Click the **Reset** button to clear the search and view all items.

2. **Select Items for Comparison**

   - Select up to two items using the checkboxes or by clicking on the table rows.
   - The **Compare** button at the bottom-right becomes enabled when exactly two items are selected.
   - Click the **Compare** button to view a side-by-side comparison of the selected items.

3. **CRUD Operations**

   - **Create**: Fill out the form under "Create New Item" and click **Create** to add a new data item.
   - **Edit**: Click the **Edit** icon next to an item to modify its details.
   - **Delete**: Click the **Delete** icon next to an item to remove it. A confirmation modal will appear before deletion.
   - **Copy**: Click the **Copy** icon to create a duplicate of an existing item.

4. **Fixed Compare Button**

   - The **Compare** button remains fixed at the bottom-right corner, allowing quick access without needing to scroll.

## Troubleshooting

If you encounter issues while setting up or running the application, consider the following solutions:

- **.NET SDK Not Found**

  Ensure that the [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later is installed. You can verify by running:

  ```bash
  dotnet --version
  ```

- **Port Already in Use**

  If you receive an error indicating that a port is already in use, you can specify a different port when running the application:

  ```bash
  dotnet run --urls "https://localhost:5002;http://localhost:5003"
  ```

- **Missing Dependencies**

  Ensure all dependencies are restored properly:

  ```bash
  dotnet restore
  ```

- **File Permission Issues**

  Verify that the `wwwroot/data/` directory and `data.json` file have the necessary read and write permissions.

- **Corrupted JSON File**

  If `data.json` becomes corrupted, restore it from a backup or delete it to allow the application to recreate it. **Note:** Deleting `data.json` will erase all stored data.

- **Application Crashes on Startup**

  Check the console output for error messages. Common issues may include malformed JSON or missing files.

## Contributing

Contributions are welcome! Follow these steps to contribute to the project:

1. **Fork the Repository**

   Click the **Fork** button at the top-right corner of the repository page to create your own copy.

2. **Clone Your Fork**

   ```bash
   git clone https://github.com/andrewhamilton375/OCCU-Project.git
   cd OCCU-Project
   ```

3. **Create a New Branch**

   ```bash
   git checkout -b feature/YourFeatureName
   ```

4. **Make Your Changes**

   Implement your feature or fix bugs in the codebase.

5. **Commit Your Changes**

   ```bash
   git add .
   git commit -m "Add feature: YourFeatureName"
   ```

6. **Push to Your Fork**

   ```bash
   git push origin feature/YourFeatureName
   ```

7. **Create a Pull Request**

   Navigate to your fork on GitHub and click the **Compare & pull request** button to submit your changes for review.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

- **Project Lead**: [Your Name](https://github.com/andrewhamilton375)
- **Email**: andrewhamilton375@gmail.com
