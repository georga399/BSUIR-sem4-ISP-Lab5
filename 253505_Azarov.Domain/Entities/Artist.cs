namespace _253505_Azarov.Domain.Entities;

public class Artist: Entity
{
    public string? Name{get;set;}
    public string? Description{get;set;} 
    public bool isVerified{get;set;}
    public ICollection<Song>? Songs {get;set;}  
}