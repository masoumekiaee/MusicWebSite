using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Areas.Administrator.Models.ViewModels
{
    public class MusicUploadViewModels
    {
        [DisplayName("کد")]
        public int? Id { get; set; }

        [StringLength(250)]
        [DisplayName("خواننده")]
        public string SingerFarsiName { get; set; }

        [StringLength(250)]
        [DisplayName("نام فارسی")]
        public string FarsiName { get; set; }

        [StringLength(250)]
        [DisplayName("نام انگلیسی")]
        public string EngName { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("عنوان آهنگ")]
        public string Title { get; set; }

        [StringLength(2000)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [StringLength(2000)]
        [DisplayName("متن آهنگ")]
        public string Lyrics { get; set; }

        [DisplayName("تاریخ ارسال")]
        public DateTime? TimeAdded { get; set; }

        [StringLength(30)]
        [DisplayName("تصویر")]
        public string PictureName { get; set; }

        [StringLength(250)]
        [DisplayName("آدرس فایل موسیقی")]
        public string FileName { get; set; }

        [Display(Name = "خواننده")]
        public int SelectSinger { get; set; }

        public IEnumerable<SelectListItem> SingerList { get; set; }

        [Display(Name = "دسته‌بندی")]
        public int SelectMusicCategory { get; set; }

        public IEnumerable<SelectListItem> MusicCategoryList { get; set; }
        public HttpPostedFileBase UpMusicFile { get; set; }
        public HttpPostedFileBase UpMusicPictureFile { get; set; }
    }

    public class MusicIndexViewModels
    {
        [DisplayName("کد")]
        public int Id { get; set; }

        [DisplayName("خواننده")]
        public string SingerFarsiName { get; set; }

        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("نام فارسی")]
        public string FarsiName { get; set; }
    }
}