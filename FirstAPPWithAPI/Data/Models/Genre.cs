namespace FirstAPPWithAPI.Data.Models
{
    
    //by default all properties is Requierd
    [Table("Genres",Schema ="Gen")]
    public class Genre //Movie Type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
