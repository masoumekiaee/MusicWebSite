using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicWebSite.Models
{
    [Table("Comment")]
    public class Comment
    {


        #region Constructor
        public Comment()
        {

        }
        #endregion Constructor

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Comment>
        {
            public Configuration()
            {
                HasRequired(current => current.Music)
                    .WithMany(mus => mus.Comments)
                    .HasForeignKey(current => current.MusicId_Fk)
                    .WillCascadeOnDelete(true)
                    ;

                HasRequired(current => current.UserInfo)
                    .WithMany(user => user.Comments)
                    .HasForeignKey(current => current.UserInfoId_Fk)
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
        [MaxLength(2000)]
        [StringLength(2000)]
        [TypeConverter("Nvarchar(2000)")]
        [DisplayName("متن آهنگ")]
        public string Text { get; set; }

        [Required]
        public int MusicId_Fk { get; set; }


        [Required]
        public int UserInfoId_Fk { get; set; }

        [Required]
        [DisplayName("تاریخ ارسال")]
        public DateTime TimeAdded { get; set; }

        #endregion Properties


        #region Relations

        [ForeignKey("MusicId_Fk")]
        public virtual Models.Music Music { get; set; }

        [ForeignKey("UserInfoId_Fk")]
        public virtual Models.UserInfo UserInfo { get; set; }

        #endregion Relations
    }
}