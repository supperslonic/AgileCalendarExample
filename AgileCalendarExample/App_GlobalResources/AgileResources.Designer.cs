﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgileCalendarExample.App_GlobalResources {
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
    public class AgileResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AgileResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AgileCalendarExample.App_GlobalResources.AgileResources", typeof(AgileResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to en-US.
        /// </summary>
        public static string CultureInfo {
            get {
                return ResourceManager.GetString("CultureInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to dd MMM yy.
        /// </summary>
        public static string DateFormatForTitle {
            get {
                return ResourceManager.GetString("DateFormatForTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected xml element {0}.
        /// </summary>
        public static string E_UnexpectedXmlElementWithParam {
            get {
                return ResourceManager.GetString("E_UnexpectedXmlElementWithParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vacation date {0} must be inside sprint or planning.
        /// </summary>
        public static string E_VacationMustBeInsideSprintOrPlanningWithParam {
            get {
                return ResourceManager.GetString("E_VacationMustBeInsideSprintOrPlanningWithParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}
        ///from {1} to {2}.
        /// </summary>
        public static string TitleFormat {
            get {
                return ResourceManager.GetString("TitleFormat", resourceCulture);
            }
        }
    }
}
