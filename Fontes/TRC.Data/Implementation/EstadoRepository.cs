using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TRC.Core.Modelo;
using TRC.Data.Interfaces;

namespace TRC.Data.Implementation
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly TrcContext _context;

        public EstadoRepository(TrcContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estado>> GetEstadosAsync()
        {
            return await _context.Estados.ToListAsync();
        }
    }
}
