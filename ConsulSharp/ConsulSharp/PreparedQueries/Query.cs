using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Query
    /// </summary>
    public class Query
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Session
        /// </summary>
        public string Session { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Template
        /// </summary>
        public Template Template { get; set; }
        /// <summary>
        /// Explain Prepared Query
        /// </summary>
        public ExplainPreparedQuery.Service Service { get; set; }
    }
}
