# IO.Swagger.Api.ToDoListApi

All URIs are relative to *http://localhost:8778*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ToDoListGetAll**](ToDoListApi.md#todolistgetall) | **GET** /api/ToDoList/GetAll | Get All lists from database
[**ToDoListGetById**](ToDoListApi.md#todolistgetbyid) | **GET** /api/ToDoList/GetById/{id} | Get by id list
[**ToDoListInsertList**](ToDoListApi.md#todolistinsertlist) | **POST** /api/ToDoList/InsertList | Insert list in database
[**ToDoListRemoveList**](ToDoListApi.md#todolistremovelist) | **DELETE** /api/ToDoList/RemoveList | Remove list from database
[**ToDoListUpdateList**](ToDoListApi.md#todolistupdatelist) | **PUT** /api/ToDoList/UpdateList | Update list in database


<a name="todolistgetall"></a>
# **ToDoListGetAll**
> Object ToDoListGetAll ()

Get All lists from database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();

            try
            {
                // Get All lists from database
                Object result = apiInstance.ToDoListGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistgetbyid"></a>
# **ToDoListGetById**
> Object ToDoListGetById (int? id)

Get by id list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var id = 56;  // int? | 

            try
            {
                // Get by id list
                Object result = apiInstance.ToDoListGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListGetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistinsertlist"></a>
# **ToDoListInsertList**
> Object ToDoListInsertList (ToDoList list)

Insert list in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListInsertListExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var list = new ToDoList(); // ToDoList | 

            try
            {
                // Insert list in database
                Object result = apiInstance.ToDoListInsertList(list);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListInsertList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **list** | [**ToDoList**](ToDoList.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistremovelist"></a>
# **ToDoListRemoveList**
> Object ToDoListRemoveList (ToDoList list)

Remove list from database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListRemoveListExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var list = new ToDoList(); // ToDoList | 

            try
            {
                // Remove list from database
                Object result = apiInstance.ToDoListRemoveList(list);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListRemoveList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **list** | [**ToDoList**](ToDoList.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistupdatelist"></a>
# **ToDoListUpdateList**
> Object ToDoListUpdateList (ToDoList list)

Update list in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListUpdateListExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var list = new ToDoList(); // ToDoList | 

            try
            {
                // Update list in database
                Object result = apiInstance.ToDoListUpdateList(list);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListUpdateList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **list** | [**ToDoList**](ToDoList.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

