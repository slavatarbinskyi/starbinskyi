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
    /// User
    /// </summary>
    [DataContract]
    public partial class User :  IEquatable<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected User() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="UserName">UserName (required).</param>
        /// <param name="Password">Password.</param>
        /// <param name="Email">Email (required).</param>
        /// <param name="Created">Created.</param>
        /// <param name="Modified">Modified.</param>
        /// <param name="ToDoLists">ToDoLists.</param>
        public User(int? Id = null, string UserName = null, string Password = null, string Email = null, DateTime? Created = null, DateTime? Modified = null, List<ToDoList> ToDoLists = null)
        {
            // to ensure "UserName" is required (not null)
            if (UserName == null)
            {
                throw new InvalidDataException("UserName is a required property for User and cannot be null");
            }
            else
            {
                this.UserName = UserName;
            }
            // to ensure "Email" is required (not null)
            if (Email == null)
            {
                throw new InvalidDataException("Email is a required property for User and cannot be null");
            }
            else
            {
                this.Email = Email;
            }
            this.Id = Id;
            this.Password = Password;
            this.Created = Created;
            this.Modified = Modified;
            this.ToDoLists = ToDoLists;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public int? Id { get; set; }
        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        [DataMember(Name="UserName", EmitDefaultValue=false)]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name="Password", EmitDefaultValue=false)]
        public string Password { get; set; }
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="Email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [DataMember(Name="Created", EmitDefaultValue=false)]
        public DateTime? Created { get; set; }
        /// <summary>
        /// Gets or Sets Modified
        /// </summary>
        [DataMember(Name="Modified", EmitDefaultValue=false)]
        public DateTime? Modified { get; set; }
        /// <summary>
        /// Gets or Sets ToDoLists
        /// </summary>
        [DataMember(Name="ToDoLists", EmitDefaultValue=false)]
        public List<ToDoList> ToDoLists { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Modified: ").Append(Modified).Append("\n");
            sb.Append("  ToDoLists: ").Append(ToDoLists).Append("\n");
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
            return this.Equals(obj as User);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.UserName == other.UserName ||
                    this.UserName != null &&
                    this.UserName.Equals(other.UserName)
                ) && 
                (
                    this.Password == other.Password ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) && 
                (
                    this.Created == other.Created ||
                    this.Created != null &&
                    this.Created.Equals(other.Created)
                ) && 
                (
                    this.Modified == other.Modified ||
                    this.Modified != null &&
                    this.Modified.Equals(other.Modified)
                ) && 
                (
                    this.ToDoLists == other.ToDoLists ||
                    this.ToDoLists != null &&
                    this.ToDoLists.SequenceEqual(other.ToDoLists)
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
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.UserName != null)
                    hash = hash * 59 + this.UserName.GetHashCode();
                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                if (this.Created != null)
                    hash = hash * 59 + this.Created.GetHashCode();
                if (this.Modified != null)
                    hash = hash * 59 + this.Modified.GetHashCode();
                if (this.ToDoLists != null)
                    hash = hash * 59 + this.ToDoLists.GetHashCode();
                return hash;
            }
        }
    }

}
