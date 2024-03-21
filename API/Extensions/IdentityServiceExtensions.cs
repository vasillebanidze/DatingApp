using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static WebApplicationBuilder AddIdentityServices(this WebApplicationBuilder builder)
        {


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                                            System.Text.Encoding.UTF8.GetBytes(
                                                                    builder.Configuration.GetValue<string>("TokenKey")!
                                                                    )
                                                                ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return builder;
        }
    }
}