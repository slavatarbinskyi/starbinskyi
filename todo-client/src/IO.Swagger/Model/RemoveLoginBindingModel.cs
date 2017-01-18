/* 
 * WebApp
 *
 * No descripton provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IO.Swagger.Model
{
    /// <summary>
    /// RemoveLoginBindingModel
    /// </summary>
    [DataContract]
    public partial class RemoveLoginBindingModel :  IEquatable<RemoveLoginBindingModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveLoginBindingModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RemoveLoginBindingModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveLoginBindingModel" /> class.
        /// </summary>
        /// <param name="LoginProvider">LoginProvider (required).</param>
        /// <param name="ProviderKey">ProviderKey (required).</param>
        public RemoveLoginBindingModel(string LoginProvider = null, string ProviderKey = null)
        {
            // to ensure "LoginProvider" is required (not null)
            if (LoginProvider == null)
            {
                throw new InvalidDataException("LoginProvider is a required property for RemoveLoginBindingModel and cannot be null");
            }
            else
            {
                this.LoginProvider = LoginProvider;
            }
            // to ensure "ProviderKey" is required (not null)
            if (ProviderKey == null)
            {
                throw new InvalidDataException("ProviderKey is a required property for RemoveLoginBindingModel and cannot be null");
            }
            else
            {
                this.ProviderKey = ProviderKey;
            }
        }
        
        /// <summary>
        /// Gets or Sets LoginProvider
        /// </summary>
        [DataMember(Name="LoginProvider", EmitDefaultValue=false)]
        public string LoginProvider { get; set; }
        /// <summary>
        /// Gets or Sets ProviderKey
        /// </summary>
        [DataMember(Name="ProviderKey", EmitDefaultValue=false)]
        public string ProviderKey { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RemoveLoginBindingModel {\n");
            sb.Append("  LoginProvider: ").Append(LoginProvider).Append("\n");
            sb.Append("  ProviderKey: ").Append(ProviderKey).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as RemoveLoginBindingModel);
        }

        /// <summary>
        /// Returns true if RemoveLoginBindingModel instances are equal
        /// </summary>
        /// <param name="other">Instance of RemoveLoginBindingModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RemoveLoginBindingModel other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.LoginProvider == other.LoginProvider ||
                    this.LoginProvider != null &&
                    this.LoginProvider.Equals(other.LoginProvider)
                ) && 
                (
                    this.ProviderKey == other.ProviderKey ||
                    this.ProviderKey != null &&
                    this.ProviderKey.Equals(other.ProviderKey)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.LoginProvider != null)
                    hash = hash * 59 + this.LoginProvider.GetHashCode();
                if (this.ProviderKey != null)
                    hash = hash * 59 + this.ProviderKey.GetHashCode();
                return hash;
            }
        }
    }

}
