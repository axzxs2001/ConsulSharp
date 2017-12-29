using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.ACL
{
    /// <summary>
    /// Create ACL Token
    /// </summary>
    public class ACLTokenParmeter
    {
        /// <summary>
        /// Specifies the ID of the ACL. If not provided, a UUID is generated.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Specifies a human-friendly name for the ACL token.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the type of ACL token. Valid values are: client and management.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///Specifies rules for this ACL token. The format of the Rules property is documented in the ACL Guide.
        /// </summary>
        public string Rules { get; set; }
    }
}
