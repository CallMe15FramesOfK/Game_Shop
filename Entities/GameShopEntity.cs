using System.ComponentModel.DataAnnotations;

namespace Game_Shop.Entities
{
    public class GameShopEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Platform { get; set; }

        public string? Genre { get; set; }

    }
}
