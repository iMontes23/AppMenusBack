namespace Navistar.Model.common.DTO.Security
{
    public class UserMenuOptionDTO
    {

        public string AppCode { get; set; }

        public string ModuleDesc { get; set; }

        public string Category { get; set; }

        public string URL { get; set; }

        public string URLTarget { get; set; }

        public int IndexPos { get; set; }

        public int IndexPosSubMenu { get; set; }

        public string Application { get; set; }

        // ICG: Atributo de la descripcion
        public string DescripcionOpcion { get; set; }
        public string Objetivo { get; set; }
         public string nombreMenu { get; set; }
          public string nombreModulo { get; set; }

    }
}
