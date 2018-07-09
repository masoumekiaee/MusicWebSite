using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebSite.Models
{
    public class MusicThumbnails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FarsiName { get; set; }
        public string EngName { get; set; }
        public string SingerFarsiName { get; set; }
        public string PictureName { get; set; }
        public DateTime TimeAdded { get; set; }
    }
    public class MusicShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FarsiName { get; set; }
        public string FileName { get; set; }
        public string EngName { get; set; }
        public string SingerFarsiName { get; set; }
        public string Description { get; set; }
        public string Lyrics { get; set; }
        public string PictureName { get; set; }
        public DateTime TimeAdded { get; set; }
        public List<Comment> Comments { get; set; }
    }


}