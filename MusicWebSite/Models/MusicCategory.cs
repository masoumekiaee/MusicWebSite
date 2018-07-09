using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicWebSite.Models
{
    [Table("MusicCategory")]
    public class MusicCategory
    {
        #region Constructor
        public MusicCategory()
        {

        }
        #endregion Constructor

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MusicCategory>
        {
            public Configuration()
            {

            }
        }
        #endregion Configuration

        #region Properties
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("کد")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        [TypeConverter("Nvarchar(30)")]
        [DisplayName("نام فارسی")]
        public string FarsiName { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        [TypeConverter("varchar(30)")]
        [DisplayName("نام انگلیسی")]
        public string EngName { get; set; }


        [TypeConverter("Nvarchar(2000)")]
        [StringLength(2000, ErrorMessage = "حداکثر خلاصه توضیحات می تواند 2000 کارکتر باشد.")]
        [MaxLength(2000)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }


        [Required]
        [DisplayName("ترنیب")]
        public short DisplayOrder { get; set; }

        #endregion Properties

        #region Relations

        public virtual List<Models.Music> Musics { get; set; }

        #endregion Relations
    }
}