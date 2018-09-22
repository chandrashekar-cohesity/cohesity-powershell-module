﻿/* 
 * Cohesity REST API
 *
 * This API provides operations for interfacing with the Cohesity Cluster. NOTE: To view the documentation on the responses, click 'Model' next to 'Example Value' and keep clicking to expand the hierarchy.
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cohesity.Models
{
    /// <summary>
    /// Specifies the environment type (such as kVMware or kSQL) that contains the source to backup. Supported environment types include &#39;kView&#39;, &#39;kSQL&#39;, &#39;kVMware&#39;, &#39;kPuppeteer&#39;, &#39;kPhysical&#39;, &#39;kPure&#39;, &#39;kNetapp, &#39;kGenericNas, &#39;kHyperV&#39;, &#39;kAcropolis&#39;, &#39;kAzure&#39;. NOTE: &#39;kPuppeteer&#39; refers to Cohesity&#39;s Remote Adapter.
    /// </summary>
    /// <value>Specifies the environment type (such as kVMware or kSQL) that contains the source to backup. Supported environment types include &#39;kView&#39;, &#39;kSQL&#39;, &#39;kVMware&#39;, &#39;kPuppeteer&#39;, &#39;kPhysical&#39;, &#39;kPure&#39;, &#39;kNetapp, &#39;kGenericNas, &#39;kHyperV&#39;, &#39;kAcropolis&#39;, &#39;kAzure&#39;. NOTE: &#39;kPuppeteer&#39; refers to Cohesity&#39;s Remote Adapter.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnvironmentEnum
    {

        /// <summary>
        /// Enum KVMware for value: kVMware
        /// </summary>
        [EnumMember(Value = "kVMware")]
        kVMware = 1, 

        /// <summary>
        /// Enum KSQL for value: kSQL
        /// </summary>
        [EnumMember(Value = "kSQL")]
        kSQL = 2,

        /// <summary>
        /// Enum KView for value: kView
        /// </summary>
        [EnumMember(Value = "kView")]
        kView = 3,

        /// <summary>
        /// Enum KPuppeteer for value: kPuppeteer
        /// </summary>
        [EnumMember(Value = "kPuppeteer")]
        kPuppeteer = 4,

        /// <summary>
        /// Enum KPhysical for value: kPhysical
        /// </summary>
        [EnumMember(Value = "kPhysical")]
        kPhysical = 5,

        /// <summary>
        /// Enum KPure for value: kPure
        /// </summary>
        [EnumMember(Value = "kPure")]
        kPure = 6,

        /// <summary>
        /// Enum KNetapp for value: kNetapp
        /// </summary>
        [EnumMember(Value = "kNetapp")]
        kNetapp = 7,

        /// <summary>
        /// Enum KGenericNas for value: kGenericNas
        /// </summary>
        [EnumMember(Value = "kGenericNas")]
        kGenericNas = 8,

        /// <summary>
        /// Enum KHyperV for value: kHyperV
        /// </summary>
        [EnumMember(Value = "kHyperV")]
        kHyperV = 9,

        /// <summary>
        /// Enum KAcropolis for value: kAcropolis
        /// </summary>
        [EnumMember(Value = "kAcropolis")]
        kAcropolis = 10,

        /// <summary>
        /// Enum KAzure for value: kAzure
        /// </summary>
        [EnumMember(Value = "kAzure")]
        kAzure = 11,

        /// <summary>
        /// Enum KPhysical for value: kPhysical
        /// </summary>
        [EnumMember(Value = "kPhysicalFiles")]
        kPhysicalFiles = 12,

        [EnumMember(Value = "kAgent")]
        kAgent = 13,

        [EnumMember(Value = "kIsilon")]
        kIsilon = 14,

        [EnumMember(Value = "kKVM")]
        kKVM = 15,

        [EnumMember(Value = "kOracle")]
        kOracle = 16,

        [EnumMember(Value = "kAWS")]
        kAWS = 17,

        [EnumMember(Value = "kAWSNative")]
        kAWSNative = 18,

        /// <summary>
        /// Enum KHyperVVSS for value: kHyperVVSS
        /// </summary>
        [EnumMember(Value = "kHyperVVSS")]
        kHyperVVSS = 19,

    }
}
