# IO.Swagger.Api.UserApi

All URIs are relative to *http://localhost:8778*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UserGetAll**](UserApi.md#usergetall) | **GET** /api/User/GetAll | Get All users from database
[**UserGetByEmail**](UserApi.md#usergetbyemail) | **GET** /api/User/GetByEmail | Get user by email
[**UserInsertUser**](UserApi.md#userinsertuser) | **POST** /api/User/InsertUser | Insert user in database
[**UserRemoveUser**](UserApi.md#userremoveuser) | **DELETE** /api/User/RemoveUser | Remove user from database
[**UserUpdateUser**](UserApi.md#userupdateuser) | **PUT** /api/User/UpdateUser | Update user in database


<a name="usergetall"></a>
# **UserGetAll**
> List<User> UserGetAll ()

Get All users from database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();

            try
            {
                // Get All users from database
                List&lt;User&gt; result = apiInstance.UserGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<User>**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="usergetbyemail"></a>
# **UserGetByEmail**
> User UserGetByEmail (string email)

Get user by email

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserGetByEmailExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var email = email_example;  // string | 

            try
            {
                // Get user by email
                User result = apiInstance.UserGetByEmail(email);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserGetByEmail: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **email** | **string**|  | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userinsertuser"></a>
# **UserInsertUser**
> Object UserInsertUser (User user)

Insert user in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserInsertUserExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var user = new User(); // User | 

            try
            {
                // Insert user in database
                Object result = apiInstance.UserInsertUser(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserInsertUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userremoveuser"></a>
# **UserRemoveUser**
> Object UserRemoveUser (User user)

Remove user from database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserRemoveUserExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var user = new User(); // User | 

            try
            {
                // Remove user from database
                Object result = apiInstance.UserRemoveUser(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserRemoveUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userupdateuser"></a>
# **UserUpdateUser**
> Object UserUpdateUser (User user)

Update user in database

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserUpdateUserExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var user = new User(); // User | 

            try
            {
                // Update user in database
                Object result = apiInstance.UserUpdateUser(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserUpdateUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

