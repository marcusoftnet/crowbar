using System.Security.Principal;
using System.Web.Security;

namespace Crowbar
{
    /// <summary>
    /// Represents the context of a partial view that should be rendered for form submission.
    /// </summary>
    public class PartialViewContext
    {
        /// <summary>
        /// Creates a new instance of <see cref="PartialViewContext"/>.
        /// </summary>
        /// <param name="viewName">The name of the partial view that should be rendered.</param>
        public PartialViewContext(string viewName)
        {
            ViewName = viewName;
            ClientValidationEnabled = true;         // Read from Web.config?
            UnobtrusiveJavaScriptEnabled = true;    // Read from Web.config?
        }

        /// <summary>
        /// Gets or sets whether client-side validation should be enabled when rendering the partial view.
        /// </summary>
        public bool ClientValidationEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether unobtrusive JavaScript should be enabled when rendering the partial view.
        /// </summary>
        public bool UnobtrusiveJavaScriptEnabled { get; set; }

        /// <summary>
        /// Gets or sets the security principal in which the view should be rendered.
        /// </summary>
        public IPrincipal User { get; set; }

        /// <summary>
        /// Gets the name of the partial view that should be rendered.
        /// </summary>
        public string ViewName { get; private set; }

        /// <summary>
        /// Sets the security principal, using forms identity, in which the view should be rendered.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="timeout">The time, in minutes, for which the forms authentication cookie is valid.</param>
        public PartialViewContext SetFormsAuthPrincipal(string username, int timeout = 30)
        {
            var ticket = new FormsAuthenticationTicket(username, false, timeout);
            User = new GenericPrincipal(new FormsIdentity(ticket), new string[0]);

            return this;
        }

        /// <summary>
        /// Sets the security principal to an anonymous user (no username), using a generic identity.
        /// </summary>
        public PartialViewContext SetAnonymousPrincipal()
        {
            User = new GenericPrincipal(new GenericIdentity(""), new string[0]);

            return this;
        }

        /// <summary>
        /// Converts a string to a <see cref="PartialViewContext"/> object.
        /// </summary>
        /// <param name="viewName">The name of the partial view that should be rendered.</param>
        /// <returns></returns>
        public static implicit operator PartialViewContext(string viewName)
        {
            return new PartialViewContext(viewName);
        }
    }
}