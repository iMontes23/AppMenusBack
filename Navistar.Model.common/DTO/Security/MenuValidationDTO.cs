namespace Navistar.Model.common.DTO.Security
{
    public class MenuValidationDTO
    {
        // BD
        public string AppCode { get; set; }

        public string Category { get; set; }

        // RESPONSE
        public string UserID{ get; set; }

        public string UserName { get; set; }

        public int NumberOfAppsInSP { get; set; }

        public int NumberOfAppsInNewMenu { get; set; }

        public string AppsOnlyInSP  { get; set; }

        public string AppsOnlyInInNewMenu { get; set; }

        public int NumberOfOptionsInSP { get; set; }

        public int NumberOfOptionsInNewMenu { get; set; }

        public string OptionsOnlyInSP { get; set; }

        public string OptionsOnlyInInNewMenu { get; set; }

        public string Status { get; set; }

    }
}
