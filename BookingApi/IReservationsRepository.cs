using System;
using System.Threading.Tasks;

namespace Ploeh.Samples.BookingApi
{
    public class IntBox
    {
        public IntBox(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public interface IReservationsRepository
    {
        Task<Reservation[]> ReadReservations(DateTimeOffset date);

        Task<IntBox> Create(Reservation reservation);
    }
}