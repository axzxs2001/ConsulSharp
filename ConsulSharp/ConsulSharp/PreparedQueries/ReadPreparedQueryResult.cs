using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Read Prepared Query Result
    /// </summary>
    public class ReadPreparedQueryResult: CreatePreparedQueryParmeter
    {
        /// <summary>
        /// RaftIndex
        /// </summary>
        public RaftIndex RaftIndex { get; set; }
    }
}
