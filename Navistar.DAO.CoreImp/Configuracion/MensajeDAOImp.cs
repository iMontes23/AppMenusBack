using Navistar.DAO.Core;
using Navistar.DataContext;
using Navistar.Model.common;
using Navistar.Model.common.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar.DAO.CoreImp.Configuracion
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class MensajeDAOImp : IMensajeDAO
    {
        private readonly DBDataMartEntityFmwImp context;
        public MensajeDAOImp(DBDataMartEntityFmwImp context)
        {
            this.context = context;
        }

        public async Task<int> Add(MensajeAplicacion entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public string Get(MsgEnum valor)
        {
            return (from m in context.TCTRA_MensajeApp
                    where m.Key == valor
                    select m.Mensaje).FirstOrDefault();
        }


    
    }
}
