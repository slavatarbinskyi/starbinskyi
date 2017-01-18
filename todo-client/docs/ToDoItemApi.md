# IO.Swagger.Api.ToDoItemApi

All URIs are relative to *http://localhost:8778*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ToDoItemGetAll**](ToDoItemApi.md#todoitemgetall) | **GET** /api/ToDoItem/GetAll | Get All Items.
[**ToDoItemGetAllNotCompleted**](ToDoItemApi.md#todoitemgetallnotcompleted) | **GET** /api/ToDoItem/GetAllNotCompleted | Get All Not Completed Items.
[**ToDoItemGetById**](ToDoItemApi.md#todoitemgetbyid) | **GET** /api/ToDoItem/GetById/{Id} | Get by id item
[**ToDoItemInsertItem**](ToDoItemApi.md#todoiteminsertitem) | **POST** /api/ToDoItem/InsertItem | Insert Item
[**ToDoItemMarkAsCompleted**](ToDoItemApi.md#todoitemmarkascompleted) | **PUT** /api/ToDoItem/MarkAsCompleted/{Id} | Mark item as completed in database
[**ToDoItemRemoveItem**](ToDoItemApi.md#todoitemremoveitem) | **DELETE** /api/ToDoItem/RemoveItem | Remove item from database
[**ToDoItemUpdateItem**](ToDoItemApi.md#todoitemupdateitem) | **PUT** /api/ToDoItem/UpdateItem | Update item in database


<a name="todoitemgetall"></a>
# **ToDoItemGetAll**
> Object ToDoItemGetAll ()

Get All Items.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();

            try
            {
                // Get All Items.
                Object result = apiInstance.ToDoItemGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemGetAll: " + e.Message );
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

<a name="todoitemgetallnotcompleted"></a>
# **ToDoItemGetAllNotCompleted**
> Object ToDoItemGetAllNotCompleted ()

Get All Not Completed Items.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemGetAllNotCompletedExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();

            try
            {
                // Get All Not Completed Items.
                Object result = apiInstance.ToDoItemGetAllNotCompleted();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemGetAllNotCompleted: " + e.Message );
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

<a name="todoitemgetbyid"></a>
# **ToDoItemGetById**
> Object ToDoItemGetById (int? id)

Get by id item

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var id = 56;  // int? | 

            try
            {
                // Get by id item
                Object result = apiInstance.ToDoItemGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemGetById: " + e.Message );
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

<a name="todoiteminsertitem"></a>
# **ToDoItemInsertItem**
> Object ToDoItemInsertItem (ToDoItem item)

Insert Item

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemInsertItemExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var item = new ToDoItem(); // ToDoItem | 

            try
            {
                // Insert Item
                Object result = apiInstance.ToDoItemInsertItem(item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemInsertItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **item** | [**ToDoItem**](ToDoItem.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemmarkascompleted"></a>
# **ToDoItemMarkAsCompleted**
> Object ToDoItemMarkAsCompleted (int? id)

Mark item as completed in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemMarkAsCompletedExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var id = 56;  // int? | 

            try
            {
                // Mark item as completed in database
                Object result = apiInstance.ToDoItemMarkAsCompleted(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemMarkAsCompleted: " + e.Message );
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

<a name="todoitemremoveitem"></a>
# **ToDoItemRemoveItem**
> Object ToDoItemRemoveItem (ToDoItem item)

Remove item from database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemRemoveItemExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var item = new ToDoItem(); // ToDoItem | 

            try
            {
                // Remove item from database
                Object result = apiInstance.ToDoItemRemoveItem(item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemRemoveItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **item** | [**ToDoItem**](ToDoItem.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemupdateitem"></a>
# **ToDoItemUpdateItem**
> Object ToDoItemUpdateItem (ToDoItem item)

Update item in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemUpdateItemExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var item = new ToDoItem(); // ToDoItem | 

            try
            {
                // Update item in database
                Object result = apiInstance.ToDoItemUpdateItem(item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemUpdateItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **item** | [**ToDoItem**](ToDoItem.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

