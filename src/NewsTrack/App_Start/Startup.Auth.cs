using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using NewsTrack.Providers;
using NewsTrack.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Facebook;

namespace NewsTrack
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, long>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ApplicationCookie),
                        getUserIdCallback: (id) => (id.GetUserId<long>()))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "1922694004623014",
            //   appSecret: "3a6916ba2525d38efc8125ee68a8fdd3");
            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1922694004623014",
                AppSecret = "3a6916ba2525d38efc8125ee68a8fdd3",
                BackchannelHttpHandler = new NewsTrack.Handlers.FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location"
            };
            app.UseFacebookAuthentication(facebookOptions);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "116431716054-0f0jumr0i300bnrbghkj24jn5e3llb2i.apps.googleusercontent.com",
                ClientSecret = "QWdkcInQjTCeyhek58IJzSYH",
                Provider = new GoogleOAuth2AuthenticationProvider
                {
                    OnAuthenticated = async context =>
                    {
                        // Retrieve the OAuth access token to store for subsequent API calls
                        string accessToken = context.AccessToken;

                        // Retrieve the username
                        string userName = context.Name;

                        // You can even retrieve the full JSON-serialized user
                        var serializedUser = context.GivenName;
                    }
                }
            });
        }
    }
}
