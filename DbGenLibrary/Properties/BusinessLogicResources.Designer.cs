﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbGenLibrary.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class BusinessLogicResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BusinessLogicResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DbGenLibrary.Properties.BusinessLogicResources", typeof(BusinessLogicResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;configuration&gt;
        ///  &lt;connectionStrings&gt;
        ///    &lt;add connectionString=&quot;@ConnectionString@&quot;
        ///         name=&quot;ConnectionString&quot;
        ///         providerName=&quot;System.Data.SqlClient&quot; /&gt;
        ///  &lt;/connectionStrings&gt;
        ///    &lt;startup&gt; 
        ///        &lt;supportedRuntime version=&quot;v4.0&quot; sku=&quot;.NETFramework,Version=v4.5.1&quot; /&gt;
        ///    &lt;/startup&gt;
        ///&lt;/configuration&gt;.
        /// </summary>
        internal static string App {
            get {
                return ResourceManager.GetString("App", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] BLToolkit_4 {
            get {
                object obj = ResourceManager.GetObject("BLToolkit_4", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Project ToolsVersion=&quot;12.0&quot; DefaultTargets=&quot;Build&quot; xmlns=&quot;http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;
        ///  &lt;Import Project=&quot;$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props&quot; Condition=&quot;Exists(&apos;$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props&apos;)&quot; /&gt;
        ///  &lt;PropertyGroup&gt;
        ///    &lt;Configuration Condition=&quot; &apos;$(Configuration)&apos; == &apos;&apos; &quot;&gt;Debug&lt;/Configuration&gt;
        ///    &lt;Platform Condition=&quot; &apos;$(Platform)&apos; == &apos;&apos; &quot;&gt;AnyCPU&lt;/Platform&gt;
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BusinessLogic {
            get {
                return ResourceManager.GetString("BusinessLogic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using System;
        ///using System.Collections.Generic;
        ///using System.Linq;
        ///using System.Linq.Expressions;
        ///using BLToolkit.Data;
        ///using BLToolkit.Data.Linq;
        ///
        ///namespace @NameSpace@.Repository
        ///{
        ///    public class DataProvider&lt;T&gt; : IProvider&lt;T&gt; where T : class
        ///    {
        ///        private readonly DbManager _dataContext = new DbManager();
        ///
        ///        public IEnumerable&lt;T&gt; GetAll()
        ///        {
        ///            return _dataContext.GetTable&lt;T&gt;();
        ///        }
        ///
        ///        public IEnumerable&lt;T&gt; Find(Func&lt;T, bool&gt; predicate)
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DataProvider {
            get {
                return ResourceManager.GetString("DataProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using System;
        ///using System.Collections.Generic;
        ///using System.Linq.Expressions;
        ///
        ///namespace @NameSpace@.Repository
        ///{
        ///    public interface IProvider&lt;T&gt; where T : class
        ///    {
        ///        IEnumerable&lt;T&gt; GetAll();
        ///        IEnumerable&lt;T&gt; Find(Func&lt;T, bool&gt; predicate);
        ///        int MassUpdate(Expression&lt;Func&lt;T, bool&gt;&gt; predicate, Expression&lt;Func&lt;T, T&gt;&gt; setter);
        ///        int MassDelete(Expression&lt;Func&lt;T, bool&gt;&gt; predicate);
        ///        int Insert(T entity);
        ///        int Update(T entity);
        ///        int Delete(T entity [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IProvider {
            get {
                return ResourceManager.GetString("IProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;packages&gt;
        ///  &lt;package id=&quot;BLToolkit&quot; version=&quot;4.1.21&quot; targetFramework=&quot;net451&quot; /&gt;
        ///&lt;/packages&gt;.
        /// </summary>
        internal static string packagesBLL {
            get {
                return ResourceManager.GetString("packagesBLL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using System;
        ///using System.Collections.Generic;
        ///using System.Linq.Expressions;
        ///using @NameSpace@.Mapping;
        ///using @NameSpace@.Repository;
        ///
        ///namespace @NameSpace@.Services
        ///{
        ///    public class @ClassName@Service : IProvider&lt;@ClassName@&gt;
        ///    {
        ///        public @ClassName@Service()
        ///        {
        ///            Provider = new DataProvider&lt;@ClassName@&gt;();
        ///        }
        ///
        ///        private IProvider&lt;@ClassName@&gt; Provider { get; set; }
        ///
        ///        public IEnumerable&lt;@ClassName@&gt; GetAll()
        ///        {
        ///            //validat [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ProxyPattern {
            get {
                return ResourceManager.GetString("ProxyPattern", resourceCulture);
            }
        }
    }
}
