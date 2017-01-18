# IO.Swagger.Api.AccountApi

All URIs are relative to *http://localhost:8778*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AccountAddExternalLogin**](AccountApi.md#accountaddexternallogin) | **POST** /api/Account/AddExternalLogin | 
[**AccountChangePassword**](AccountApi.md#accountchangepassword) | **POST** /api/Account/ChangePassword | 
[**AccountGetExternalLogin**](AccountApi.md#accountgetexternallogin) | **GET** /api/Account/ExternalLogin | 
[**AccountGetExternalLogins**](AccountApi.md#accountgetexternallogins) | **GET** /api/Account/ExternalLogins | 
[**AccountGetManageInfo**](AccountApi.md#accountgetmanageinfo) | **GET** /api/Account/ManageInfo | 
[**AccountGetUserInfo**](AccountApi.md#accountgetuserinfo) | **GET** /api/Account/UserInfo | 
[**AccountLogout**](AccountApi.md#accountlogout) | **POST** /api/Account/Logout | 
[**AccountRegister**](AccountApi.md#accountregister) | **POST** /api/Account/Register | 
[**AccountRegisterExternal**](AccountApi.md#accountregisterexternal) | **POST** /api/Account/RegisterExternal | 
[**AccountRemoveLogin**](AccountApi.md#accountremovelogin) | **POST** /api/Account/RemoveLogin | 
[**AccountSetPassword**](AccountApi.md#accountsetpassword) | **POST** /api/Account/SetPassword | 


<a name="accountaddexternallogin"></a>
# **AccountAddExternalLogin**
> Object AccountAddExternalLogin (AddExternalLoginBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountAddExternalLoginExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new AddExternalLoginBindingModel(); // AddExternalLoginBindingModel | 

            try
            {
                Object result = apiInstance.AccountAddExternalLogin(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountAddExternalLogin: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**AddExternalLoginBindingModel**](AddExternalLoginBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountchangepassword"></a>
# **AccountChangePassword**
> Object AccountChangePassword (ChangePasswordBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountChangePasswordExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new ChangePasswordBindingModel(); // ChangePasswordBindingModel | 

            try
            {
                Object result = apiInstance.AccountChangePassword(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountChangePassword: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**ChangePasswordBindingModel**](ChangePasswordBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountgetexternallogin"></a>
# **AccountGetExternalLogin**
> Object AccountGetExternalLogin (string provider, string error = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountGetExternalLoginExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var provider = provider_example;  // string | 
            var error = error_example;  // string |  (optional) 

            try
            {
                Object result = apiInstance.AccountGetExternalLogin(provider, error);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountGetExternalLogin: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **provider** | **string**|  | 
 **error** | **string**|  | [optional] 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountgetexternallogins"></a>
# **AccountGetExternalLogins**
> List<ExternalLoginViewModel> AccountGetExternalLogins (string returnUrl, bool? generateState = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountGetExternalLoginsExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var returnUrl = returnUrl_example;  // string | 
            var generateState = true;  // bool? |  (optional) 

            try
            {
                List&lt;ExternalLoginViewModel&gt; result = apiInstance.AccountGetExternalLogins(returnUrl, generateState);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountGetExternalLogins: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **returnUrl** | **string**|  | 
 **generateState** | **bool?**|  | [optional] 

### Return type

[**List<ExternalLoginViewModel>**](ExternalLoginViewModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountgetmanageinfo"></a>
# **AccountGetManageInfo**
> ManageInfoViewModel AccountGetManageInfo (string returnUrl, bool? generateState = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountGetManageInfoExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var returnUrl = returnUrl_example;  // string | 
            var generateState = true;  // bool? |  (optional) 

            try
            {
                ManageInfoViewModel result = apiInstance.AccountGetManageInfo(returnUrl, generateState);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountGetManageInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **returnUrl** | **string**|  | 
 **generateState** | **bool?**|  | [optional] 

### Return type

[**ManageInfoViewModel**](ManageInfoViewModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountgetuserinfo"></a>
# **AccountGetUserInfo**
> UserInfoViewModel AccountGetUserInfo ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountGetUserInfoExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();

            try
            {
                UserInfoViewModel result = apiInstance.AccountGetUserInfo();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountGetUserInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UserInfoViewModel**](UserInfoViewModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountlogout"></a>
# **AccountLogout**
> Object AccountLogout ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountLogoutExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();

            try
            {
                Object result = apiInstance.AccountLogout();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountLogout: " + e.Message );
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

<a name="accountregister"></a>
# **AccountRegister**
> Object AccountRegister (RegisterBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountRegisterExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new RegisterBindingModel(); // RegisterBindingModel | 

            try
            {
                Object result = apiInstance.AccountRegister(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountRegister: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**RegisterBindingModel**](RegisterBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountregisterexternal"></a>
# **AccountRegisterExternal**
> Object AccountRegisterExternal (RegisterExternalBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountRegisterExternalExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new RegisterExternalBindingModel(); // RegisterExternalBindingModel | 

            try
            {
                Object result = apiInstance.AccountRegisterExternal(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountRegisterExternal: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**RegisterExternalBindingModel**](RegisterExternalBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountremovelogin"></a>
# **AccountRemoveLogin**
> Object AccountRemoveLogin (RemoveLoginBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountRemoveLoginExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new RemoveLoginBindingModel(); // RemoveLoginBindingModel | 

            try
            {
                Object result = apiInstance.AccountRemoveLogin(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountRemoveLogin: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**RemoveLoginBindingModel**](RemoveLoginBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="accountsetpassword"></a>
# **AccountSetPassword**
> Object AccountSetPassword (SetPasswordBindingModel model)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccountSetPasswordExample
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new SetPasswordBindingModel(); // SetPasswordBindingModel | 

            try
            {
                Object result = apiInstance.AccountSetPassword(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountSetPassword: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **model** | [**SetPasswordBindingModel**](SetPasswordBindingModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

