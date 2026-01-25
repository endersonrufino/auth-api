namespace AuthApi.Application.DTOs;

public record RegisterRequest(string Email, string Password, string Name, Guid Profile);
