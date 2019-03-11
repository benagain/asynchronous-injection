﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Ploeh.Samples.BookingApi
{
    public class MaîtreD
    {
        public MaîtreD(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; }

        public Maybe<Reservation> TryAccept(
            Reservation[] reservations,
            Reservation reservation)
        {
            int reservedSeats = reservations.Sum(r => r.Quantity);

            if (Capacity < reservedSeats + reservation.Quantity)
                return new Maybe<Reservation>();

            return new Maybe<Reservation>(reservation.Accept());
        }

        public Reservation? TryAcceptNullable(
            Reservation[] reservations,
            Reservation reservation)
        {
            int reservedSeats = reservations.Sum(r => r.Quantity);

            if (Capacity < reservedSeats + reservation.Quantity)
                return null;

            return reservation.Accept();
        }
    }
}
