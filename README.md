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
- **Sample Response**:
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
