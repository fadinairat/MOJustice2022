using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class Settings
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string HeaderBg { get; set; } = String.Empty;

        [StringLength(50)]
        public string FooterColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string MenuFontColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string MenuFontHoverColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string BodyColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string TitlesColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string SummaryColor { get; set; } = String.Empty;

        [StringLength(50)]
        public string LeftBoxColor { get; set; } = String.Empty;

        public int ControlDefaultLang { get; set; } = 1;

        public int WebDefaultLang { get; set; } = 0;

    }
}
