using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TSMayHan2.Models
{
    public class standard
    {
        [Key]
        public string machine_name { get; set; }
        public string? cycle_min { get; set; }
        public string? cycle_max { get; set; }
        public string? string_time_min { get; set; }
        public string? string_time_max { get; set; }
        public string? pk_pwr_min { get; set; }
        public string? pk_pwr_max { get; set; }
        public string? energy_min { get; set; }
        public string? energy_max { get; set; }
        public string? total_abs_min { get; set; }
        public string? total_abs_max { get; set; }
        public string? weld_col_min { get; set; }
        public string? weld_col_max { get; set; }
        public string? total_col_min { get; set; }
        public string? total_col_max { get; set; }
        public string? trigger_force_min { get; set; }
        public string? trigger_force_max { get; set; }
        public string? weld_force_min { get; set; }
        public string? weld_force_max { get; set; }
        public string? freq_chg_min { get; set; }
        public string? freq_chg_max { get; set; }
        public string? set_ampA_min { get; set; }
        public string? set_ampA_max { get; set; }
        public string? set_ampB_min { get; set; }
        public string? set_ampB_max { get; set; }
        public string? velocity_min { get; set; }
        public string? velocity_max { get; set; }
        public string? modify_by { get; set; }
        public DateTime? modify_at { get; set; }

        public List<parameter> Parameters { get; set; }
        public List<device_manage> device_manages { get; set; }
    }

    public class device_manage
    {
        [Key]
        public int id_device { get; set; }
        [ForeignKey("standard")]
        public string machine_name { get; set; }
        public string? status { get; set; }
        public standard standard { get; set; }
    }

    public class parameter
    {
        [Key]
        public int id_parameter { get; set; }
        [ForeignKey("standard")]
        public string machine_name { get; set; }
        public string? cycle { get; set; }
        public string? string_time { get; set; }
        public string? pk_pwr { get; set; }
        public string? energy { get; set; }
        public string? total_abs { get; set; }
        public string? weld_col { get; set; }
        public string? total_col { get; set; }
        public string? trigger_force { get; set; }
        public string? weld_force { get; set; }
        public string? freq_chg { get; set; }
        public string? set_ampA { get; set; }
        public string? set_ampB { get; set; }
        public string? velocity { get; set; }
        public string? device_id { get; set; }
        public string? port_name { get; set; }
        public DateTime? create_at { get; set; }
        public string? create_by { get; set; }
        public DateTime? last_modify_at { get; set; }
        public string? last_modify_by { get; set; }
        public standard standard { get; set; }
    }

    public class users
    {
        [Key]
        public int id_user { get; set; }
        public string username { get; set; }
        public string passcode { get; set; }
    }
}
