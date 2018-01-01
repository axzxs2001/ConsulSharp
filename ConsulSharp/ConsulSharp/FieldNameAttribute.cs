using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Change Field Name
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class FieldNameAttribute:Attribute
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="changedFieldName">Field Name</param>
        public FieldNameAttribute(string changeFieldName)
        {
            ChangeFieldName = changeFieldName;

        }
        /// <summary>
        /// Changed Field
        /// </summary>
        public string ChangeFieldName { get;private set; }
    }
}
