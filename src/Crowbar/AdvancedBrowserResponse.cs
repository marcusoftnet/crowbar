using System.Web.Mvc;
using System.Web.SessionState;

namespace Crowbar
{
    /// <summary>
    /// Provides access to various states during an HTTP request cycle.
    /// </summary>
    public class AdvancedBrowserResponse
    {
        /// <summary>
        /// Gets the context for the OnActionExecuted method.
        /// </summary>
        public ActionExecutedContext ActionExecutedContext { get; internal set; }

        /// <summary>
        /// Gets the context for the OnActionExecuting method.
        /// </summary>
        public ActionExecutingContext ActionExecutingContext { get; internal set; }

        /// <summary>
        /// Gets the context for the OnResultExecuted method.
        /// </summary>
        public ResultExecutedContext ResultExecutedContext { get; internal set; }

        /// <summary>
        /// Gets the context for the OnResultExecuting method.
        /// </summary>
        public ResultExecutingContext ResultExecutingContext { get; internal set; }

        /// <summary>
        /// Gets the HTTP session state.
        /// </summary>
        public HttpSessionState HttpSessionState { get; internal set; }
    }
}