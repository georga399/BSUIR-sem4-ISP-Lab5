namespace _253505_Azarov.Domain.Entities;

public class Song: Entity
{
    public string? Title{get;set;}
    public int Position{get;set;}
    public string? Description{get;set;}
    public string? Genre{get;set;}
    public int ArtistId{get;set;}
    public Artist? Artist{get;set;}
}