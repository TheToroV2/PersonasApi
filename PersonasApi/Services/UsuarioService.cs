using PersonasApi.Models;
using PersonasApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PersonasApi.Services;

public class UsuarioService
{
    private readonly AppDbContext _context;
    private readonly byte[] _salt = System.Text.Encoding.UTF8.GetBytes("FixedSaltForDemo123");

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> Register(UsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Usuario1 = dto.Usuario,
            Pass = HashPassword(dto.Pass),
            FechaCreacion = DateTime.Now
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<(bool Success, string Message, string? Usuario)> Login(UsuarioDto dto)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Usuario1 == dto.Usuario);

        if (user == null || user.Pass != HashPassword(dto.Pass))
            return (false, "Invalid credentials", null);

        return (true, "Login successful", user.Usuario1);
    }

    private string HashPassword(string password)
    {
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: _salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        return hashed;
    }
}
