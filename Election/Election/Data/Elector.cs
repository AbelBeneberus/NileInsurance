﻿namespace Election.Data;

public class Elector
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string? ElectedNominee { get; set; }
}