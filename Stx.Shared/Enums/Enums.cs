using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared
{

    /// <summary>
    /// The target specifies where to open the linked documents.
    /// </summary>
    public enum Target
    {
        /// <summary>
        /// No target. Same as <see cref="Target.Self"/>.
        /// </summary>
        None,

        /// <summary>
        /// Opens the linked document in same frame (default)
        /// </summary>
        Self,

        /// <summary>
        /// Opens the linked document in a new tab.
        /// </summary>
        Blank,

        /// <summary>
        /// Opens the linked document in the parent.
        /// </summary>
        Parent,

        /// <summary>
        /// Opens the linked document in new window.
        /// </summary>
        Top,
    }
}
