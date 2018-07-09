using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicWebSite.Models
{

    [Table("UserInfo")]
    public class UserInfo
    {
        #region Constructor
        public UserInfo()
        {

        }
        #endregion Constructor

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserInfo>
        {
            public Configuration()
            {

            }
        }
        #endregion Configuration

        #region Properties

        [Key]
        [Required]
        [DisplayName("کد")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام خود را وارد نمائید.")]
        [MaxLength(60)]
        [StringLength(60, ErrorMessage = "نام باید حداکثر 60 کارکتر باشد.")]
        [TypeConverter("Nvarchar(60)")]
        [DisplayName("نام")]
        [Column("FullName")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "ایمیل خود را وارد نمائید.")]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "ایمیل باید حداکثر 50 کارکتر باشد.")]
        [TypeConverter("varchar(50)")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        [TypeConverter("Nvarchar(50)")]
        [DisplayName("تصویر پروفایل")]
        public string Avatar { get; set; }

        [Required]
        [DisplayName("تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }


        #endregion Properties

        #region Relations

        public virtual IList<Models.Comment> Comments { get; set; }
        #endregion Relations

        #region Calculator
        #endregion Calculator
    }
}