using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UrbanCareBack.Models;

namespace UrbanCareBack.Custom{
    public class Utilidades{
        
        private readonly IConfiguration _configuration;

        public Utilidades(IConfiguration configuration){
            _configuration = configuration;
        }

        public string encriptarSHA256(string texto){
            using(SHA256 sha256Hash = SHA256.Create()){
                // Convertir el texto a bytes y calcular el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                
                //Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++){
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public string generarTokenJwt(object usuario)
        {
            Claim[] userClaims;
            string rol;

            if (usuario is Organizacion organizacion)
            {
                // Creando la info del usuario para token de organización
                userClaims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, organizacion.IdOrganizacion.ToString()),
                    new Claim(ClaimTypes.Email, organizacion.Username!),
                    new Claim("rol", "Organizacion"), // Claim adicional para tipo de usuario
                    new Claim("OrganizacionId", organizacion.IdOrganizacion.ToString()) // Añadir OrganizationId
                };
                rol = "Organizacion";
            }
            else if (usuario is Administrador administrador)
            {
                // Creando la info del usuario para token de administrador
                userClaims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, administrador.IdAdministrador.ToString()),
                    new Claim(ClaimTypes.Email, administrador.Username!),
                    new Claim("rol", "Administrador"), // Claim adicional para tipo de usuario
                };
                rol = "Administrador";
            }
            else
            {
                throw new ArgumentException("Tipo de usuario no válido.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10), // Tiempo de expiración (puedes parametrizarlo si es necesario)
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}

