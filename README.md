# TASCUS REST API

An ASP.NET Core Web API with Entity Framework Core

## Base URL

`https://localhost:7084`

## APIs

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

### Note: 
The provided Postman collection uses a placeholder {{Tascus Base Url}} which has a value of https://localhost:7084. You may need to replace this with the actual base URL when making requests.
