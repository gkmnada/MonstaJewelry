﻿namespace DtoLayer.IdentityDto.RegisterDto
{
    public class CreateRegisterDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
