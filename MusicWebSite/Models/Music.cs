using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicWebSite.Models
{
    [Table("Music")]
    public class Music
    {
        #region Constructor
        public Music()
        {

        }
        #endregion Constructor

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Music>
        {
            public Configuration()
            {
                HasRequired(current => current.Singer)
                    .WithMany(sin => sin.Musics)
                    .HasForeignKey(current => current.SingerId_Fk)
                    .WillCascadeOnDelete(false)
                    ;

                HasRequired(current => current.MusicCategory)
                   .WithMany(mus => mus.Musics)
                   .HasForeignKey(current => current.CategoryMusicId_Fk)
                   .WillCascadeOnDelete(false)
                   ;
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
        [MaxLength(250)]
        [StringLength(250)]
        [TypeConverter("Nvarchar(250)")]
        [DisplayName("نام فارسی")]
        public string FarsiName { get; set; }

        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        [TypeConverter("varchar(250)")]
        [DisplayName("نام انگلیسی")]
        public string EngName { get; set; }

        [Required]
        [StringLength(250)]
        [MaxLength(250)]
        [TypeConverter("Nvarchar(250)")]
        [DisplayName("عنوان آهنگ")]
        public string Title { get; set; }

        [MaxLength(2000)]
        [StringLength(2000)]
        [TypeConverter("Nvarchar(2000)")]
        [DisplayName("متن آهنگ")]
        public string Description { get; set; }


        [Required]
        public int CategoryMusicId_Fk { get; set; }


        [Required]
        public int SingerId_Fk { get; set; }

        [MaxLength(2000)]
        [StringLength(2000)]
        [TypeConverter("Nvarchar(2000)")]
        [DisplayName("متن آهنگ")]
        public string Lyrics { get; set; }

        [Required]
        [DisplayName("تاریخ ارسال")]
        public DateTime TimeAdded { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        [TypeConverter("varchar(250)")]
        [DisplayName("تصویر")]
        public string PictureName {get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        [TypeConverter("varchar(250)")]
        [DisplayName("آدرس فایل موسیقی")]
        public string FileName { get; set; }


        #endregion Properties


        #region Relations

        [ForeignKey("SingerId_Fk")]
        public virtual Models.Singer Singer { get; set; }
        [ForeignKey("CategoryMusicId_Fk")]
        public virtual Models.MusicCategory MusicCategory { get; set; }
        public virtual List<Models.Comment> Comments { get; set; }


        #endregion Relations

    }
}