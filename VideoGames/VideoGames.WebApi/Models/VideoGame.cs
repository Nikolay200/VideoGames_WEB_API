using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VideoGames.WebApi.Models
{
    public class VideoGame
    {      
        public Guid Id { get; set; }        
        public string Name { get; set; }        
        public string Studio { get; set; }
        public Gerne Gerne { get; set; }

    }

    public enum Gerne
    {
        [Description("Action")]
        Action,
        [Description("RPG")]
        RPG,
        [Description("Adventure")]
        Adventure,
        [Description("Strategy")]
        Strategy,
        [Description("Shooter")]
        Shooter
    }
}
