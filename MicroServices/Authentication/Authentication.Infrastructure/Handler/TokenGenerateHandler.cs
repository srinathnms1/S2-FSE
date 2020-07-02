namespace Authentication.Infrastructure.Handler
{
    using Authentication.Domain.ViewModel;
    using Authentication.Infrastructure.Query;
    using AutoMapper;
    using MediatR;
    using Microservice.Core;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.JsonWebTokens;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class TokenGenerateHandler : IRequestHandler<TokenGenerateQuery, UserClaim>
    {
        private readonly IOptions<Audience> settings;
        private readonly IMapper mapper;

        public TokenGenerateHandler(IOptions<Audience> settings, IMapper mapper)
        {
            this.mapper = mapper;
            this.settings = settings;
        }
        public Task<UserClaim> Handle(TokenGenerateQuery request, CancellationToken cancellationToken)
        {
            UserClaim GenerateToken(UserViewModel userViewModel)
            {
                var now = DateTime.UtcNow;

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userViewModel.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
                };

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Value.Secret));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = settings.Value.Iss,
                    ValidateAudience = true,
                    ValidAudience = settings.Value.Aud,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,

                };

                var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                    issuer: settings.Value.Iss,
                    audience: settings.Value.Aud,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(24 * 60)),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(jwt);
                var userClaims = mapper.Map<UserClaim>(userViewModel);
                userClaims.Token = encodedJwt;
                userClaims.ExpiresIn = (int)TimeSpan.FromMinutes(2).TotalSeconds;

                return userClaims;
            }

            var userClaim = GenerateToken(request.UserViewModel);
            return Task.FromResult(userClaim);
        }
    }
}