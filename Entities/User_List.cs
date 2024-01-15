using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Shop.Entities
{
    public class User_List
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("GameShopEntity")]

        public int? GameShopEntityId { get; set; }

        public string GameName { get; set; }

        public string? GamePlatform { get; set; }

        public string? GameGenre { get; set; }
    }
}
