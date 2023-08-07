# TASCUS REST API

An ASP.NET Core Web API with Entity Framework Core

## Setup Guide

Setting up the application is a straightforward process. One of the most essential steps is to update the connection string to ensure your application communicates with the database seamlessly.

### Prerequisites:

1. Install .NET Core SDK
2. Install SQL Server

### Step-by-Step Guide:

1. **Clone the Repository**
   
   Use git to clone the repository:
   ```bash
   git clone https://github.com/mujassir/tascus-api.git
   ```

2. **Navigate to the Project Directory**

   Change your current directory to the project:
   ```bash
   cd [Your Project Directory]
   ```

3. **Update the Connection String**

   The connection string is a crucial part that lets your application talk to the database. Follow these steps to update it:

   - Open the `appsettings.json` file located at the project's root.
   
   - Locate the following line:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
     }
     ```
   
   - Update the placeholders (`your_server`, `your_database`, `your_username`, `your_password`) with your actual SQL Server details.

4. **Build and Run the Application**

   Build the application either by Visual Studio or with the following command:
   ```bash
   dotnet build
   ```

   Run the application either by Visual Studio or with the following command:
   ```bash
   dotnet run
   ```

5. **Access the Application**

   Once running, you can access the application via:




## APIs

### Base URL

`https://localhost:7084`
### ProductResult

#### GET `/ProductResults`

- **Purpose**: Returns the production step results for a product.
- **Example Request**: `{{Tascus Base Url}}/ProductResults?Part_Number=G090L&Serial_Number=0021116&Operation_ID=1000`
- **Query Parameters**:
  - `Part_Number`: `G090L`
  - `Serial_Number`: `0021116`
  - `Operation_ID`: `1000`
  
- **Response**:
```json
[
    {
        "step_Name": "Work Instruction",
        "step_Measurement": "Pick Parts Tray",
        "step_Result": "Complete",
        "high_Limit": "",
        "low_Limit": "",
        "step_Status": "PASS",
        "unit": "",
        "step_Run": 1,
        "operation_Name": "Picking",
        "operation_ID": 1000,
        "date": "2023-05-11T06:40:48"
    }
]
```

#### POST `/ProductResults`
- **Purpose**: Adds production step results for a product.
Example Request Body:
- **Example Request Body**:
```json
{
  "step_Name": "Test Step Name",
  "step_Measurement": "Test Step Measurement",
  "step_Result": "PASS",
  "high_Limit": "Test High Limit",
  "low_Limit": "Test Low Limit",
  "step_Status": "EXECUTING",
  "unit": "Test Unit",
  "step_Run": 0,
  "operation_Name": "Test Operation Name",
  "operation_ID": 1000,
  "serial_Number": "0021116",
  "part_Number": "G090L",
  "date": "2023-08-04T13:32:27.472Z"
}
```
- **Response**:
```json
{
    "message": "Product Result Created Successfully."
}
```

### ProductStatus

#### GET `/ProductStatus`

- **Purpose**: Get the Status of a manufacturing operation for a product.
- **Example Request**: `{{Tascus Base Url}}/ProductStatus?Part_Number=G090L&Serial_Number=0021116&Operation_ID=1000`
- **Query Parameters**:
  - `Part_Number`: `G090L`
  - `Serial_Number`: `0021116`
  - `Operation_ID`: `1000`
  
- **Response**:
```json
[
    {
        "status": "EXECUTING",
        "result": "FAIL"
    }
]
```

#### PUT `/ProductStatus`

- **Purpose**: Updates the result and status string for a product.
  
- **Request URL**: `{{Tascus Base Url}}/ProductStatus`

- **Example Request Body**:
```json
{
  "model_Number": "G090L",
  "serial_Number": "0021116",
  "status": "EXECUTING",
  "result": "FAIL",
  "operation_ID": 1000
}
```
- **Response**:
```json
{
    "message": "Product Status updated successfully."
}

```
## Using the Postman Collection

[Postman](https://www.postman.com/) is a powerful tool for API development and testing. Our project provides a Postman collection to help you test the API endpoints efficiently. Here's a step-by-step guide on how to use the provided Postman collection:

### Prerequisites:

1. [Download and Install Postman](https://www.postman.com/downloads/)

### Steps:

1. **Open Postman**

   Launch the Postman application on your machine.

2. **Import the Collection**

   - In the top-left corner of the Postman app, you'll see an `Import` button. Click on it.
   
   - A dialog will appear. Choose the `Upload Files` option and select the provided `.json` Postman collection file.
   
   - After selecting the file, click the `Import` button in the dialog.

3. **View the Collection**

   Once imported, the collection will appear in the left sidebar under the `Collections` tab. You can click on it to view the list of API requests included in the collection.

4. **Run a Request**

   - Click on one of the requests under the collection to load it.
   
   - Once the request is loaded, adjust any necessary parameters, headers, or body data as needed.
   
   - Click the blue `Send` button to execute the request. You'll see the response appear in the pane below.

5. **Environment Variables (Optional)**

   If the collection utilizes environment variables (placeholders like `{{Tascus Base Url}}`), you might need to set up or adjust an environment in Postman:

   - Click on the gear icon (⚙️) in the top-right corner to manage environments.
   
   - Choose the desired environment or add a new one, and set the key-value pairs as required by the collection.

---

**Tip:** Postman collections often come with pre-configured requests, including necessary headers, parameters, and body data. Ensure you review and understand the requests before sending them, especially when working with production data.


### Note: 
The provided Postman collection uses a placeholder {{Tascus Base Url}} which has a value of https://localhost:7084. You may need to replace this with the actual base URL when making requests.
