using System.Collections.Generic;
using System.Threading.Tasks;
using TRC.Core.Modelo;
using TRC.Manager.Interfaces;

namespace TRC.Manager.Implementation
{
    public class EstadoManager : IEstadoManager
    {
        private readonly IEstadoManager _estadoManager;

        public EstadoManager(IEstadoManager estadoManager)
        {
            _estadoManager = estadoManager;
        }
        public async Task<IEnumerable<Estado>> GetEstadosAsync()
        {
            return await _estadoManager.GetEstadosAsync();
        }
    }
}
