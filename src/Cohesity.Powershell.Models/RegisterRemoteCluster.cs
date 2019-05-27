// Copyright 2019 Cohesity Inc.

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cohesity.Model
{
    /// <summary>
    /// Specifies the settings required for registering a remote Cluster on this local Cluster.
    /// </summary>
    [DataContract]
    public partial class RegisterRemoteCluster :  IEquatable<RegisterRemoteCluster>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterRemoteCluster" /> class.
        /// </summary>
        /// <param name="allEndpointsReachable">Specifies whether any endpoint (such as a Node) on the remote Cluster is reachable from this local Cluster. If true, a service running on the local Cluster can communicate directly with any of its peers running on the remote Cluster, without using a proxy..</param>
        /// <param name="bandwidthLimit">bandwidthLimit.</param>
        /// <param name="clearInterfaces">clearInterfaces.</param>
        /// <param name="clearVlanId">Specifies whether to clear the vlanId field, and thus stop using only the IPs in the VLAN for communicating with the remote Cluster..</param>
        /// <param name="clusterId">Specifies the unique id of the remote Cluster..</param>
        /// <param name="compressionEnabled">Specifies whether to compress the outbound data when transferring the replication data over the network to the remote Cluster..</param>
        /// <param name="encryptionKey">Specifies the encryption key used for encrypting the replication data from a local Cluster to a remote Cluster. If a key is not specified, replication traffic encryption is disabled. When Snapshots are replicated from a local Cluster to a remote Cluster, the encryption key specified on the local Cluster must be the same as the key specified on the remote Cluster..</param>
        /// <param name="ifaceName">Specifies the interface name of the VLAN to use for communicating with the remote Cluster..</param>
        /// <param name="networkInterfaceGroup">Specifies the group name of the network interfaces to use for communicating with the remote Cluster..</param>
        /// <param name="networkInterfaceIds">Array of Network Interface Ids.  Specifies the ids of the network interfaces to use for communicating with the remote Cluster..</param>
        /// <param name="password">Specifies the password for Cohesity user to use when connecting to the remote Cluster..</param>
        /// <param name="purposeRemoteAccess">Whether the remote cluster will be used for remote access for SPOG..</param>
        /// <param name="purposeReplication">Whether the remote cluster will be used for replication..</param>
        /// <param name="remoteAccessCredentials">remoteAccessCredentials.</param>
        /// <param name="remoteIps">Array of Remote Node IP Addresses.  Specifies the IP addresses of the Nodes on the remote Cluster to connect with. These IP addresses can also be VIPS. Specifying hostnames is not supported..</param>
        /// <param name="remoteIrisPorts">Array of Ports.  Specifies the ports to use when connecting to the Nodes of the remote Cluster..</param>
        /// <param name="userName">Specifies the Cohesity user name used to connect to the remote Cluster..</param>
        /// <param name="validateOnly">Whether to only validate the credentials without saving the information..</param>
        /// <param name="viewBoxPairInfo">Array of Storage Domain (View Box) Pairs.  Specifies pairings between Storage Domains (View Boxes) on the local Cluster with Storage Domains (View Boxes) on a remote Cluster that are used in replication..</param>
        /// <param name="vlanId">Specifies the Id of the VLAN to use for communicating with the remote Cluster..</param>
        public RegisterRemoteCluster(bool? allEndpointsReachable = default(bool?), BandwidthLimit bandwidthLimit = default(BandwidthLimit), bool? clearInterfaces = default(bool?), bool? clearVlanId = default(bool?), long? clusterId = default(long?), bool? compressionEnabled = default(bool?), string encryptionKey = default(string), string ifaceName = default(string), string networkInterfaceGroup = default(string), List<long> networkInterfaceIds = default(List<long>), string password = default(string), bool? purposeRemoteAccess = default(bool?), bool? purposeReplication = default(bool?), AccessTokenCredential remoteAccessCredentials = default(AccessTokenCredential), List<string> remoteIps = default(List<string>), List<long> remoteIrisPorts = default(List<long>), string userName = default(string), bool? validateOnly = default(bool?), List<ViewBoxPairInfo> viewBoxPairInfo = default(List<ViewBoxPairInfo>), int? vlanId = default(int?))
        {
            this.AllEndpointsReachable = allEndpointsReachable;
            this.ClearInterfaces = clearInterfaces;
            this.ClearVlanId = clearVlanId;
            this.ClusterId = clusterId;
            this.CompressionEnabled = compressionEnabled;
            this.EncryptionKey = encryptionKey;
            this.IfaceName = ifaceName;
            this.NetworkInterfaceGroup = networkInterfaceGroup;
            this.NetworkInterfaceIds = networkInterfaceIds;
            this.Password = password;
            this.PurposeRemoteAccess = purposeRemoteAccess;
            this.PurposeReplication = purposeReplication;
            this.RemoteIps = remoteIps;
            this.RemoteIrisPorts = remoteIrisPorts;
            this.UserName = userName;
            this.ValidateOnly = validateOnly;
            this.ViewBoxPairInfo = viewBoxPairInfo;
            this.VlanId = vlanId;
            this.AllEndpointsReachable = allEndpointsReachable;
            this.BandwidthLimit = bandwidthLimit;
            this.ClearInterfaces = clearInterfaces;
            this.ClearVlanId = clearVlanId;
            this.ClusterId = clusterId;
            this.CompressionEnabled = compressionEnabled;
            this.EncryptionKey = encryptionKey;
            this.IfaceName = ifaceName;
            this.NetworkInterfaceGroup = networkInterfaceGroup;
            this.NetworkInterfaceIds = networkInterfaceIds;
            this.Password = password;
            this.PurposeRemoteAccess = purposeRemoteAccess;
            this.PurposeReplication = purposeReplication;
            this.RemoteAccessCredentials = remoteAccessCredentials;
            this.RemoteIps = remoteIps;
            this.RemoteIrisPorts = remoteIrisPorts;
            this.UserName = userName;
            this.ValidateOnly = validateOnly;
            this.ViewBoxPairInfo = viewBoxPairInfo;
            this.VlanId = vlanId;
        }
        
        /// <summary>
        /// Specifies whether any endpoint (such as a Node) on the remote Cluster is reachable from this local Cluster. If true, a service running on the local Cluster can communicate directly with any of its peers running on the remote Cluster, without using a proxy.
        /// </summary>
        /// <value>Specifies whether any endpoint (such as a Node) on the remote Cluster is reachable from this local Cluster. If true, a service running on the local Cluster can communicate directly with any of its peers running on the remote Cluster, without using a proxy.</value>
        [DataMember(Name="allEndpointsReachable", EmitDefaultValue=true)]
        public bool? AllEndpointsReachable { get; set; }

        /// <summary>
        /// Gets or Sets BandwidthLimit
        /// </summary>
        [DataMember(Name="bandwidthLimit", EmitDefaultValue=false)]
        public BandwidthLimit BandwidthLimit { get; set; }

        /// <summary>
        /// Gets or Sets ClearInterfaces
        /// </summary>
        [DataMember(Name="clearInterfaces", EmitDefaultValue=true)]
        public bool? ClearInterfaces { get; set; }

        /// <summary>
        /// Specifies whether to clear the vlanId field, and thus stop using only the IPs in the VLAN for communicating with the remote Cluster.
        /// </summary>
        /// <value>Specifies whether to clear the vlanId field, and thus stop using only the IPs in the VLAN for communicating with the remote Cluster.</value>
        [DataMember(Name="clearVlanId", EmitDefaultValue=true)]
        public bool? ClearVlanId { get; set; }

        /// <summary>
        /// Specifies the unique id of the remote Cluster.
        /// </summary>
        /// <value>Specifies the unique id of the remote Cluster.</value>
        [DataMember(Name="clusterId", EmitDefaultValue=true)]
        public long? ClusterId { get; set; }

        /// <summary>
        /// Specifies whether to compress the outbound data when transferring the replication data over the network to the remote Cluster.
        /// </summary>
        /// <value>Specifies whether to compress the outbound data when transferring the replication data over the network to the remote Cluster.</value>
        [DataMember(Name="compressionEnabled", EmitDefaultValue=true)]
        public bool? CompressionEnabled { get; set; }

        /// <summary>
        /// Specifies the encryption key used for encrypting the replication data from a local Cluster to a remote Cluster. If a key is not specified, replication traffic encryption is disabled. When Snapshots are replicated from a local Cluster to a remote Cluster, the encryption key specified on the local Cluster must be the same as the key specified on the remote Cluster.
        /// </summary>
        /// <value>Specifies the encryption key used for encrypting the replication data from a local Cluster to a remote Cluster. If a key is not specified, replication traffic encryption is disabled. When Snapshots are replicated from a local Cluster to a remote Cluster, the encryption key specified on the local Cluster must be the same as the key specified on the remote Cluster.</value>
        [DataMember(Name="encryptionKey", EmitDefaultValue=true)]
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Specifies the interface name of the VLAN to use for communicating with the remote Cluster.
        /// </summary>
        /// <value>Specifies the interface name of the VLAN to use for communicating with the remote Cluster.</value>
        [DataMember(Name="ifaceName", EmitDefaultValue=true)]
        public string IfaceName { get; set; }

        /// <summary>
        /// Specifies the group name of the network interfaces to use for communicating with the remote Cluster.
        /// </summary>
        /// <value>Specifies the group name of the network interfaces to use for communicating with the remote Cluster.</value>
        [DataMember(Name="networkInterfaceGroup", EmitDefaultValue=true)]
        public string NetworkInterfaceGroup { get; set; }

        /// <summary>
        /// Array of Network Interface Ids.  Specifies the ids of the network interfaces to use for communicating with the remote Cluster.
        /// </summary>
        /// <value>Array of Network Interface Ids.  Specifies the ids of the network interfaces to use for communicating with the remote Cluster.</value>
        [DataMember(Name="networkInterfaceIds", EmitDefaultValue=true)]
        public List<long> NetworkInterfaceIds { get; set; }

        /// <summary>
        /// Specifies the password for Cohesity user to use when connecting to the remote Cluster.
        /// </summary>
        /// <value>Specifies the password for Cohesity user to use when connecting to the remote Cluster.</value>
        [DataMember(Name="password", EmitDefaultValue=true)]
        public string Password { get; set; }

        /// <summary>
        /// Whether the remote cluster will be used for remote access for SPOG.
        /// </summary>
        /// <value>Whether the remote cluster will be used for remote access for SPOG.</value>
        [DataMember(Name="purposeRemoteAccess", EmitDefaultValue=true)]
        public bool? PurposeRemoteAccess { get; set; }

        /// <summary>
        /// Whether the remote cluster will be used for replication.
        /// </summary>
        /// <value>Whether the remote cluster will be used for replication.</value>
        [DataMember(Name="purposeReplication", EmitDefaultValue=true)]
        public bool? PurposeReplication { get; set; }

        /// <summary>
        /// Gets or Sets RemoteAccessCredentials
        /// </summary>
        [DataMember(Name="remoteAccessCredentials", EmitDefaultValue=false)]
        public AccessTokenCredential RemoteAccessCredentials { get; set; }

        /// <summary>
        /// Array of Remote Node IP Addresses.  Specifies the IP addresses of the Nodes on the remote Cluster to connect with. These IP addresses can also be VIPS. Specifying hostnames is not supported.
        /// </summary>
        /// <value>Array of Remote Node IP Addresses.  Specifies the IP addresses of the Nodes on the remote Cluster to connect with. These IP addresses can also be VIPS. Specifying hostnames is not supported.</value>
        [DataMember(Name="remoteIps", EmitDefaultValue=true)]
        public List<string> RemoteIps { get; set; }

        /// <summary>
        /// Array of Ports.  Specifies the ports to use when connecting to the Nodes of the remote Cluster.
        /// </summary>
        /// <value>Array of Ports.  Specifies the ports to use when connecting to the Nodes of the remote Cluster.</value>
        [DataMember(Name="remoteIrisPorts", EmitDefaultValue=true)]
        public List<long> RemoteIrisPorts { get; set; }

        /// <summary>
        /// Specifies the Cohesity user name used to connect to the remote Cluster.
        /// </summary>
        /// <value>Specifies the Cohesity user name used to connect to the remote Cluster.</value>
        [DataMember(Name="userName", EmitDefaultValue=true)]
        public string UserName { get; set; }

        /// <summary>
        /// Whether to only validate the credentials without saving the information.
        /// </summary>
        /// <value>Whether to only validate the credentials without saving the information.</value>
        [DataMember(Name="validateOnly", EmitDefaultValue=true)]
        public bool? ValidateOnly { get; set; }

        /// <summary>
        /// Array of Storage Domain (View Box) Pairs.  Specifies pairings between Storage Domains (View Boxes) on the local Cluster with Storage Domains (View Boxes) on a remote Cluster that are used in replication.
        /// </summary>
        /// <value>Array of Storage Domain (View Box) Pairs.  Specifies pairings between Storage Domains (View Boxes) on the local Cluster with Storage Domains (View Boxes) on a remote Cluster that are used in replication.</value>
        [DataMember(Name="viewBoxPairInfo", EmitDefaultValue=true)]
        public List<ViewBoxPairInfo> ViewBoxPairInfo { get; set; }

        /// <summary>
        /// Specifies the Id of the VLAN to use for communicating with the remote Cluster.
        /// </summary>
        /// <value>Specifies the Id of the VLAN to use for communicating with the remote Cluster.</value>
        [DataMember(Name="vlanId", EmitDefaultValue=true)]
        public int? VlanId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString() { return ToJson(); }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RegisterRemoteCluster);
        }

        /// <summary>
        /// Returns true if RegisterRemoteCluster instances are equal
        /// </summary>
        /// <param name="input">Instance of RegisterRemoteCluster to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegisterRemoteCluster input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AllEndpointsReachable == input.AllEndpointsReachable ||
                    (this.AllEndpointsReachable != null &&
                    this.AllEndpointsReachable.Equals(input.AllEndpointsReachable))
                ) && 
                (
                    this.BandwidthLimit == input.BandwidthLimit ||
                    (this.BandwidthLimit != null &&
                    this.BandwidthLimit.Equals(input.BandwidthLimit))
                ) && 
                (
                    this.ClearInterfaces == input.ClearInterfaces ||
                    (this.ClearInterfaces != null &&
                    this.ClearInterfaces.Equals(input.ClearInterfaces))
                ) && 
                (
                    this.ClearVlanId == input.ClearVlanId ||
                    (this.ClearVlanId != null &&
                    this.ClearVlanId.Equals(input.ClearVlanId))
                ) && 
                (
                    this.ClusterId == input.ClusterId ||
                    (this.ClusterId != null &&
                    this.ClusterId.Equals(input.ClusterId))
                ) && 
                (
                    this.CompressionEnabled == input.CompressionEnabled ||
                    (this.CompressionEnabled != null &&
                    this.CompressionEnabled.Equals(input.CompressionEnabled))
                ) && 
                (
                    this.EncryptionKey == input.EncryptionKey ||
                    (this.EncryptionKey != null &&
                    this.EncryptionKey.Equals(input.EncryptionKey))
                ) && 
                (
                    this.IfaceName == input.IfaceName ||
                    (this.IfaceName != null &&
                    this.IfaceName.Equals(input.IfaceName))
                ) && 
                (
                    this.NetworkInterfaceGroup == input.NetworkInterfaceGroup ||
                    (this.NetworkInterfaceGroup != null &&
                    this.NetworkInterfaceGroup.Equals(input.NetworkInterfaceGroup))
                ) && 
                (
                    this.NetworkInterfaceIds == input.NetworkInterfaceIds ||
                    this.NetworkInterfaceIds != null &&
                    input.NetworkInterfaceIds != null &&
                    this.NetworkInterfaceIds.SequenceEqual(input.NetworkInterfaceIds)
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.PurposeRemoteAccess == input.PurposeRemoteAccess ||
                    (this.PurposeRemoteAccess != null &&
                    this.PurposeRemoteAccess.Equals(input.PurposeRemoteAccess))
                ) && 
                (
                    this.PurposeReplication == input.PurposeReplication ||
                    (this.PurposeReplication != null &&
                    this.PurposeReplication.Equals(input.PurposeReplication))
                ) && 
                (
                    this.RemoteAccessCredentials == input.RemoteAccessCredentials ||
                    (this.RemoteAccessCredentials != null &&
                    this.RemoteAccessCredentials.Equals(input.RemoteAccessCredentials))
                ) && 
                (
                    this.RemoteIps == input.RemoteIps ||
                    this.RemoteIps != null &&
                    input.RemoteIps != null &&
                    this.RemoteIps.SequenceEqual(input.RemoteIps)
                ) && 
                (
                    this.RemoteIrisPorts == input.RemoteIrisPorts ||
                    this.RemoteIrisPorts != null &&
                    input.RemoteIrisPorts != null &&
                    this.RemoteIrisPorts.SequenceEqual(input.RemoteIrisPorts)
                ) && 
                (
                    this.UserName == input.UserName ||
                    (this.UserName != null &&
                    this.UserName.Equals(input.UserName))
                ) && 
                (
                    this.ValidateOnly == input.ValidateOnly ||
                    (this.ValidateOnly != null &&
                    this.ValidateOnly.Equals(input.ValidateOnly))
                ) && 
                (
                    this.ViewBoxPairInfo == input.ViewBoxPairInfo ||
                    this.ViewBoxPairInfo != null &&
                    input.ViewBoxPairInfo != null &&
                    this.ViewBoxPairInfo.SequenceEqual(input.ViewBoxPairInfo)
                ) && 
                (
                    this.VlanId == input.VlanId ||
                    (this.VlanId != null &&
                    this.VlanId.Equals(input.VlanId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AllEndpointsReachable != null)
                    hashCode = hashCode * 59 + this.AllEndpointsReachable.GetHashCode();
                if (this.BandwidthLimit != null)
                    hashCode = hashCode * 59 + this.BandwidthLimit.GetHashCode();
                if (this.ClearInterfaces != null)
                    hashCode = hashCode * 59 + this.ClearInterfaces.GetHashCode();
                if (this.ClearVlanId != null)
                    hashCode = hashCode * 59 + this.ClearVlanId.GetHashCode();
                if (this.ClusterId != null)
                    hashCode = hashCode * 59 + this.ClusterId.GetHashCode();
                if (this.CompressionEnabled != null)
                    hashCode = hashCode * 59 + this.CompressionEnabled.GetHashCode();
                if (this.EncryptionKey != null)
                    hashCode = hashCode * 59 + this.EncryptionKey.GetHashCode();
                if (this.IfaceName != null)
                    hashCode = hashCode * 59 + this.IfaceName.GetHashCode();
                if (this.NetworkInterfaceGroup != null)
                    hashCode = hashCode * 59 + this.NetworkInterfaceGroup.GetHashCode();
                if (this.NetworkInterfaceIds != null)
                    hashCode = hashCode * 59 + this.NetworkInterfaceIds.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                if (this.PurposeRemoteAccess != null)
                    hashCode = hashCode * 59 + this.PurposeRemoteAccess.GetHashCode();
                if (this.PurposeReplication != null)
                    hashCode = hashCode * 59 + this.PurposeReplication.GetHashCode();
                if (this.RemoteAccessCredentials != null)
                    hashCode = hashCode * 59 + this.RemoteAccessCredentials.GetHashCode();
                if (this.RemoteIps != null)
                    hashCode = hashCode * 59 + this.RemoteIps.GetHashCode();
                if (this.RemoteIrisPorts != null)
                    hashCode = hashCode * 59 + this.RemoteIrisPorts.GetHashCode();
                if (this.UserName != null)
                    hashCode = hashCode * 59 + this.UserName.GetHashCode();
                if (this.ValidateOnly != null)
                    hashCode = hashCode * 59 + this.ValidateOnly.GetHashCode();
                if (this.ViewBoxPairInfo != null)
                    hashCode = hashCode * 59 + this.ViewBoxPairInfo.GetHashCode();
                if (this.VlanId != null)
                    hashCode = hashCode * 59 + this.VlanId.GetHashCode();
                return hashCode;
            }
        }

    }

}

