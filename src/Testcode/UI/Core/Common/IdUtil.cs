//-----------------------------------------------------------------------
// <copyright file="IdUtil.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  Helper functions to generate IDs for MP Objects, 
//  Managed Entities, etc
//
//  This library should be in sync with corresponding native library
//  check IdUtil.h
// </summary>
//-----------------------------------------------------------------------


using System;
using System.Globalization;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Microsoft.Win32;

//#if SDK_INTEGRATED_COMPILE	
//    namespace Microsoft.EnterpriseManagement.Mom.InternalSdkOnly
//#elif TESTCODE    
namespace Mom.Test.UI.Core.Common
//#else
//    namespace Microsoft.EnterpriseManagement.Mom.Internal
//#endif
{

#if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.MSInternal","CA903:InternalNamespaceShouldNotContainPublicTypes")]
#endif
    /// <summary>
	/// helper class that helps ID generation for MP objects/ Managed Entities
	/// </summary>
#if SDK_INTEGRATED_COMPILE	
    internal static class IdUtil
#else
    public static class IdUtil
#endif
	{
        /// <summary>
        /// Will we operate in legacy mode for this IDUtil
        /// </summary>
        private static bool legacyMode = true;
        
        /// <summary>
        /// Initializes the <see cref="IdUtil"/> class.
        /// </summary>
#if CODE_ANALYSIS
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
#endif
        static IdUtil()
        {
#if SILVERLIGHT 
#else
            RegistryKey key = null;
            try
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\System Center\2010\Common\Machine Settings");

                if (key != null)
                {
                    int temp = (int)key.GetValue("LegacyMode", 1);
                    IdUtil.legacyMode = (temp == 0 ? false : true);
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                try
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
                catch
                { }
            }
#endif
        }        
        
        /// <summary>
        /// creates a GUID that can be used as an id from a string
        /// </summary>
        /// <param name="keyString">string to create id of</param>
        public static Guid GetGuidFromString(string textToHash)
        {
            byte[] hashValue;

            SHA1 hash;

            // On a system with FIPS compliance set it isn't possible to create
            // an instance of SHA1Managed.  If this is the case we will use the
            // SHA1CryptoServiceProvider provider class instead.
            if (!IdUtil.isFipsEnforcementEnabled) 
            {
                try
                {
                    hash = new SHA1Managed();
                }
                catch (InvalidOperationException)
                {
                    // mark that FIPS enforcement is enabled.
                    IdUtil.isFipsEnforcementEnabled = true;

#if SILVERLIGHT                    
                    hash = new SHA1Managed();
#else
                    hash = new SHA1CryptoServiceProvider();
#endif

                }
            }
            else
            {
#if SILVERLIGHT
                hash = new SHA1Managed();
#else
                hash = new SHA1CryptoServiceProvider();
#endif
            }

            using (hash)
            {
                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] dataToHash;

                if (textToHash == null)
                {
                    dataToHash = encoding.GetBytes(TagNullString.ToString());
                }
                else
                {
                    dataToHash = encoding.GetBytes(textToHash.ToString());
                }
                hashValue = hash.ComputeHash(dataToHash);
            }

            // We can't use the byte[] constructor of guid expects a 16 byte
            // array.  Since SHA1 generates a 20 byte hash which we are
            // truncating we need to use a constructor which lets us pass in
            // only the part of the array we are using.
            return new Guid(
                (int)hashValue[3] << 24 | (int)hashValue[2] << 16 | (int)hashValue[1] << 8 | hashValue[0],
                (short)((int)hashValue[5] << 8 | hashValue[4]),
                (short)((int)hashValue[7] << 8 | hashValue[6]),
                hashValue[8],
                hashValue[9],
                hashValue[10],
                hashValue[11],
                hashValue[12],
                hashValue[13],
                hashValue[14],
                hashValue[15]);
        }

        /// <summary>
        /// Gets the deterministic field id.
        /// </summary>
        /// <param name="elementIdentity">The element identity.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldIndex">Index of the field.</param>
        /// <returns></returns>
        public static Guid GetDeterministicFieldId(String elementIdentity, String fieldName, String fieldIndex)
        {
            return GetGuidFromString(String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", elementIdentity, fieldName, fieldIndex));
        }

        /// <summary>
        /// creates a GUID which represents a management group
        /// </summary>
        /// <param name="keyString">Name of the management group</param>
        public static Guid GetGuidFromManagementGroupName( string managementGroupName )
        {
            string uppercaseManagementGroupName = managementGroupName.ToUpperInvariant();

            return GetGuidFromString(uppercaseManagementGroupName);
        }

        /// <summary>
        /// creates a version dependent Guid reference id to an MP
        /// </summary>
        /// <param name="MPName">MP Name</param>
        /// <param name="PublicKeyToken">MP Public Key Token, can be null</param>
        /// <param name="MPVersion">MP Version, can be null</param>
        public static Guid GetMPIdAsGuid(string MPName, 
                                         string PublicKeyToken, 
                                         string MPVersion)
        {
            return GetGuidFromString(GetMPIdAsString(MPName, PublicKeyToken, MPVersion));
        }

        ///
        /// creates a version dependent URL (string) reference id to an MP
        ///
        /// lpszMPName - MP Name (id)
        /// lpszPublicKeyToken - MP Public Key Token, can be NULL.
        /// lpszMPVersion - MP Version, can be NULL.
        /// pbstrMPObjectId - string id of the MP calculated
        ///
        /// returns S_OK if successful.
        ///
        /// L"MPName=<MPName>[,KeyToken=<KeyToken>][,Version=<MPVersion>]"
        ///
        public static string GetMPIdAsString(string MPName,
                                             string PublicKeyToken,
                                             string MPVersion)
        {
            if (MPName == null)
                throw new ArgumentNullException("MPName");

            // MPId is in the following format
            // "MPName=<MPName>[,KeyToken=<KeyToken>],[Version=<Version>]"

            // build this string
            StringBuilder builder = new StringBuilder();

            builder.Append(TagMPName);
            builder.Append(MPName);
            if (PublicKeyToken != null)
            {
                builder.Append(TagKeyToken);
                builder.Append(PublicKeyToken);
            }
            if (MPVersion != null)
            {
                builder.Append(TagMPVersion);
                builder.Append(MPVersion);
                if (IdUtil.legacyMode == false)
                {
                    builder.Append(TagSchemaVersion);
                }
            }

            return builder.ToString();
        }

 
        /// <summary>
        /// creates a MP version independent GUID reference id for an MP
        /// object such as a rule, monitor, module type, monitor type, task, etc
        /// <summary>
        /// <param name="MPName">MP Name</param>
        /// <param name="PublicKeyToken">MP Public Key Token, can be null</param>
        /// <param name="MPObjectId">MP Object Id relative to the MP</param>
        public static Guid GetMPObjectIdAsGuid(string MPName,
                                               string PublicKeyToken,
                                               string MPObjectId)
        {
            return GetGuidFromString(GetMPObjectIdAsString(MPName,PublicKeyToken,MPObjectId));
        }

        /// <summary>
        /// creates a MP version independent URL (string) reference id for an MP
        /// object such as a rule, monitor, module type, monitor type, task, class, etc
        /// </summary>
        /// <param name="MPName">MP Name</param>
        /// <param name="PublicKeyToken">MP Public Key Token, can be null</param>
        /// <param name="MPObjectId">MP Object Id relative to the MP</param>
        public static string GetMPObjectIdAsString(string MPName,
                                                   string PublicKeyToken,
                                                   string MPObjectId)
        {
            if (MPName == null)
            {
                throw new ArgumentNullException("MPName");
            }

            if (MPObjectId == null)
            {
                throw new ArgumentNullException("MPObjectId");
            }

            // MPObjectId is in the following format
            // "MPName=<MPName>,[KeyToken=<KeyToken>,]ObjectId=<ObjectId>"

            // build this string
            StringBuilder builder = new StringBuilder();

            builder.Append(TagMPName);
            builder.Append(MPName);
            if (PublicKeyToken != null)
            {
                builder.Append(TagKeyToken);
                builder.Append(PublicKeyToken);
            }
            builder.Append(TagObjectId);
            builder.Append(MPObjectId);

            return builder.ToString();
        }

        /// <summary>
        /// creates a MP version independent GUID reference id for an MP
        /// sub-object such as a property of a class, operational state of a monitor.
        /// </summary>
        /// <param name="MPName">MP Name</param>
        /// <param name="PublicKeyToken">MP Public Key Token, can be null</param>
        /// <param name="MPObjectId">MP Object Id relative to the MP</param>
        /// <param name="MPSubObjectId">MP Sub Object Id relative to the MP Object Id</param>
        public static Guid GetMPSubObjectIdAsGuid(string MPName,
                                                  string PublicKeyToken,
                                                  string MPObjectId,
                                                  string MPSubObjectId)
        {
            return GetGuidFromString(GetMPSubObjectIdAsString(MPName, PublicKeyToken, MPObjectId, MPSubObjectId));
        }

        /// <summary>
        /// creates a MP version independent GUID reference id for an MP
        /// sub-object such as a property of a class, operational state of a monitor.
        /// </summary>
        /// <param name="MPName">MP Name</param>
        /// <param name="PublicKeyToken">MP Public Key Token, can be null</param>
        /// <param name="MPObjectId">MP Object Id relative to the MP</param>
        /// <param name="MPSubObjectId">MP Sub Object Id relative to the MP Object Id</param>
        public static string GetMPSubObjectIdAsString(string MPName,
                                                      string PublicKeyToken,
                                                      string MPObjectId,
                                                      string MPSubObjectId)
        {
            if (MPName == null)
            {
                throw new ArgumentNullException("MPName");
            }

            if (MPObjectId == null)
            {
                throw new ArgumentNullException("MPObjectId");
            }

            if (MPSubObjectId == null)
            {
                throw new ArgumentNullException("MPSubObjectId");
            }

            // MPSubObjectId is in the following format
            // "MPName=<MPName>,[KeyToken=<KeyToken>,]ObjectId=<ObjectId>, SubObjectId=<SubObjectId>"

            // build this string
            StringBuilder builder = new StringBuilder();

            builder.Append(TagMPName);
            builder.Append(MPName);
            if (PublicKeyToken != null)
            {
                builder.Append(TagKeyToken);
                builder.Append(PublicKeyToken);
            }
            builder.Append(TagObjectId);
            builder.Append(MPObjectId);
            builder.Append(TagSubObjectId);
            builder.Append(MPSubObjectId);

            return builder.ToString();
        }


        /// <summary>
        /// creates a version independent Guid reference to a managed
        /// entity instance
        /// </summary>
        /// <param name="guidMEClassId">the ME class id of the instance</param>
        /// <param name="keyProperties">list of key properties for the instance. For singleton classes, this param can be null</param>

        /// L"Type=<TypeGuid>[,<KeyName>=<KeyValue>]*"

        //
        // this function is needed to keep in sync with its native code counterpart
        // Please review GetManagedEntityInstanceIdAsGuid (IdUtil.cpp) when changing
        //

        public static Guid GetManagedEntityInstanceIdAsGuid(Guid guidMEClassId,
                                                            ReadOnlyCollection<KeyProperty> keyProperties)
        {
            // ME Instance Id is generated based from the following string format
            // "TypeId=<TypeGuid>[,<KeyPropertyId>=<KeyValue>]*"

            // For singleton types we assume that the TypeId and the InstanceId are the same.
            // This way even in the DB sprocs we can create singleton instances without dealing
            // with MD5 hashing. Once we switch to Yukon we can get rid of this assumptions and
            // use this assembly from within the sproc.
            if ((keyProperties == null) || (keyProperties.Count == 0))
            {
                return guidMEClassId;
            }

            // build this string
            StringBuilder builder = new StringBuilder();

            builder.Append(TagClassId);
            builder.Append(guidMEClassId.ToString("B").ToUpperInvariant());

            if (keyProperties != null)
            {
                List<KeyProperty> sortedKeyProperties = new List<KeyProperty>(keyProperties);
                sortedKeyProperties.Sort();

                for (Int32 i = 0; i < sortedKeyProperties.Count; i++)
                {
                    KeyProperty property = sortedKeyProperties[i];
                    // dump ",<KeyName>=<KeyValue>" for each key property
                    builder.Append(TagSeperator);
                    builder.Append(property.PropertyId.ToString("B").ToUpperInvariant());
                    builder.Append(TagEqual);
                    if (property.IsCaseSensitive)
                    {
                        builder.Append(property.Value);
                    }
                    else
                    {
                        // because the property is not case sensitive
                        // we need to convert the property value to a canonical
                        // form such that no matter whether the value is lower case or
                        // upper case, we end up generating the same id.
                        // we will achieve this by converting the letters to Upper Case
                        // according language neutral rules.
                        builder.Append(property.Value.ToUpperInvariant());
                    }
                }
            }

            return GetGuidFromString(builder.ToString());
        }

        /// <summary>
        /// creates a version independent Guid reference to a relationship instance
        /// </summary>
        /// <param name="guidRelationshipTypeId">the type id of the relationship</param>
        /// <param name="guidSourceEntityId">the id of the source entity</param>
        /// <param name="guidTargetEntityId">the id of the source entity</param>
        /// L"Type=<TypeGuid>SourceId=<SourceId>TargetId=<TargetId>"
        public static Guid RelationshipInstanceIdAsGuid(Guid guidRelationshipTypeId,
                                                        Guid guidSourceEntityId,
                                                        Guid guidTargetEntityId)
        {
            // build this string
            StringBuilder builder = new StringBuilder();

            builder.Append(TagClassId);
            builder.Append(guidRelationshipTypeId.ToString("B").ToUpperInvariant());

            builder.Append(SourceId);
            builder.Append(guidSourceEntityId.ToString("B").ToUpperInvariant());

            builder.Append(TargetId);
            builder.Append(guidTargetEntityId.ToString("B").ToUpperInvariant());

            return GetGuidFromString(builder.ToString());
        }

        //
        // info for a key property of an ME instance
        //
        public struct KeyProperty : IComparable<KeyProperty>
        {
            public KeyProperty(Guid PropertyId, bool IsCaseSensitive, string Value)
            {
                if (Value==null)
                    throw new ArgumentNullException("Value");

                this.propertyId = PropertyId;
                this.isCaseSensitive = IsCaseSensitive;
                this.value = Value;
            }

            public Guid PropertyId
            {
                get
                {
                    return this.propertyId;
                }
            }

            public bool IsCaseSensitive
            {
                get
                {
                    return this.isCaseSensitive;
                }
            }

            public string Value
            {
                get
                {
                    return this.value;
                }
            }

            private Guid propertyId;
            private bool isCaseSensitive;
            private string value;

            public Int32 CompareTo(KeyProperty otherProperty)
            {
                return this.propertyId.CompareTo(otherProperty.PropertyId);
            }
        }

        public static bool TryGetLocalWindowsComputerIdAsGuid(out Guid localWindowsComputerId)
        {
            return NativeMethods.GetLocalWindowsComputerIdAsGuid(out localWindowsComputerId);
        }

        public static bool TryGetLocalHealthServiceIdAsGuid(out Guid localHealthServiceId)
        {
            return NativeMethods.GetLocalHealthServiceIdAsGuid(out localHealthServiceId);
        }

        /// <summary>
        /// Generates pool version hashing pool member dictionary
        /// </summary>
        /// <param name="isUsingDefaultObserver">True if pool uses default observer</param>
        /// <param name="poolMemberDictionary">Sorted dictionary of pool members. 
        /// Key is member guid, value is true for observer only, false for regular member</param>
        /// <returns>Pool version id</returns>
        public static long GetPoolVersion(bool isUsingDefaultObserver, IDictionary<Guid, bool> poolMemberDictionary)
        {
            if (poolMemberDictionary == null)
            {
                throw new ArgumentNullException("poolMemberDictionary");
            }

            if (poolMemberDictionary.Count <= 0)
            {
                return 0;
            }

            // Copy pool member guid to array to sort
            // Over allocate the array by one to account for the default observer id
            Guid[] poolMemberIds = new Guid[poolMemberDictionary.Count];

            poolMemberDictionary.Keys.CopyTo(poolMemberIds, 0);

            // sort guid list 
            Array.Sort(poolMemberIds);

            StringBuilder sb = new StringBuilder();

            if (isUsingDefaultObserver)
            {
                sb.Append("DefaultObserver,1,");
            }

            foreach (Guid poolMemberId in poolMemberIds)
            {
                // write member id
                sb.AppendFormat("{0},", poolMemberId.ToString());

                // write '1' if this is observer only member
                if (poolMemberDictionary[poolMemberId])
                {
                    sb.Append("1,");
                }
                else
                {
                    sb.Append("0,");
                }
            }

            return Math.Abs(BitConverter.ToInt64(GetGuidFromString(sb.ToString()).ToByteArray(), 0));
        }

        private static class NativeMethods
        {
            [DllImport("Microsoft.Mom.ServiceCommon.dll")]
            public static extern bool GetLocalWindowsComputerIdAsGuid(
                                         out Guid localWindowsComputerId
                                         );

            [DllImport("Microsoft.Mom.ServiceCommon.dll")]
            public static extern bool GetLocalHealthServiceIdAsGuid(
                                         out Guid localHealthServiceId
                                         );
        }

        /// <summary>
        /// We keep track of whether or not FIPS enforcement is enabled.
        /// Catching the exception every time from the SHA1Managed constructor
        /// is expensive
        /// </summary>
        private static bool isFipsEnforcementEnabled = false;


        //
        // private constants
        //
        private const string TagNullString = "<null>";
        private const string TagMPName = "MPName=";
        private const string TagKeyToken = ",KeyToken=";
        private const string TagObjectId = ",ObjectId=";
        private const string TagSubObjectId = ",SubObjectId=";
        private const string TagMPVersion = ",Version=";
        private const string TagSchemaVersion = ",Schema=2";
        private const string TagClassId = "TypeId=";
        private const string SourceId = "SourceId=";
        private const string TargetId = "TargetId=";
        private const string TagSeperator = ",";
        private const string TagEqual = "=";

    }
#if SILVERLIGHT
    public static class SilverlightExtensions
    {
        public static string ToUpperInvariant(this string input)
        {
            return input.ToUpper(CultureInfo.InvariantCulture);
        }
    }
#endif


}