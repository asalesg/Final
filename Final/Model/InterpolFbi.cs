using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final.Model
{
    [Table("FBI_INTERPOL_WANTED_CRIMINALS")]
    public class InterpolFbi
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string? Name { get; set; }

        [Column("FORENAME")]
        public string? ForeName { get; set; }

        [Column("LANGUAGES")]
        public string? Languages { get; set; }

        [Column("SEX")]
        public string? Sex { get; set; }

        [Column("CHARGES")]
        public string? Description { get; set; }

        [Column("NATIONALITY")]
        public string? Nationality { get; set; }

        public InterpolFbi()
        {
        }

        public InterpolFbi(int id, string? name, string? foreName, string? languages, string? sex, string? description, string? nationality)
        {
            Id = id;
            Name = name;
            ForeName = foreName;
            Languages = languages;
            Sex = sex;
            Description = description;
            Nationality = nationality;
        }

    }
}
