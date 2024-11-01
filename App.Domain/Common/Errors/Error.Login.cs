

using ErrorOr;

namespace App.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Login
        {
            public static Error LoginUnauthorized => Error.Unauthorized(code: "Login.Unauthorized",
                description: "Invalid username or password!");

            public static Error LoginEmailValidation => Error.Validation(code: "Login.EmailValidation",
           description: "We require email verification from you. Please check your email and follow the instructions to verify your account.");
        }
    }
}
