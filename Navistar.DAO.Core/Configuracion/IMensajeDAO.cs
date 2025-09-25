using Navistar.Model.common.Enum;
using Navistar.Model.common.Configuracion;
using System.Threading.Tasks;

namespace Navistar.DAO.Core
{
    public interface IMensajeDAO
    {
        string Get(MsgEnum key);


        //Task<int> Add(MensajeAplicacion entity);
    }
}
