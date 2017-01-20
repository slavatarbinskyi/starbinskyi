# IO.Swagger.Api.ClaimsApi

All URIs are relative to *http://localhost:8778*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ClaimsGetClaims**](ClaimsApi.md#claimsgetclaims) | **GET** /api/claims | 


<a name="claimsgetclaims"></a>
# **ClaimsGetClaims**
> Object ClaimsGetClaims ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ClaimsGetClaimsExample
    {
        public void main()
        {
            
            var apiInstance = new ClaimsApi();

            try
            {
                Object result = apiInstance.ClaimsGetClaims();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ClaimsApi.ClaimsGetClaims: " + e.Message );
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

