using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace Kuwona.Models;

public class Idea
{
    [Key]
    public int IdeaId { get; set; }
    
    public string Title { get; set; }
    
    public string Category { get; set; }

    public string Description { get; set; }
    
    public int LikesCount { get; set; } = 0;

    public int DislikesCount { get; set; } = 0;

    public string? ImageUrl { get; set; }
    
}