using Microsoft.EntityFrameworkCore;
using Transporter.Core.Data;
using Transporter.Transport.Domain.Interfaces;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Data
{
    public class TransportRecordRepository : BaseRepository<TransportRecord>, ITransportRecordRepository
    {
        private readonly DbSet<TransportRecord> _dbSet;

        public TransportRecordRepository(TransportContext context) : base(context)
        {
            _dbSet = context.Set<TransportRecord>();
        }
    }
}
