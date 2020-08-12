using Microsoft.IdentityModel.Tokens;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services {
    public static class TokenService {
        public static string GenerateToken(User user) {
            var tokenHandler = new JwtSecurityTokenHandler();//Gerando um tokenHandler
            var key = Encoding.ASCII.GetBytes(Settings.Secret);//Encodando a secret
            var tokenDescriptor = new SecurityTokenDescriptor {//Gerando um tokenDescriptor
                //Subject para fornecer os dados ao controller
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),//Tempo de vida do token
                SigningCredentials  = 
                new SigningCredentials(
                    new SymmetricSecurityKey(key),//Chave para Encriptar 
                    SecurityAlgorithms.HmacSha256Signature)// Tipo de encriptaçao
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);// Armazenando token handler em uma variavel
            return tokenHandler.WriteToken(token);// retornando tokenHandler como string
        }
    }
}
