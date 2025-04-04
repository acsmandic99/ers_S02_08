﻿using Domain.Enums;
using Domain.Models;

namespace Helpers.RegulatorHelpers
{
    public static class RegulatorPromenaRezima
    {
        public static void PromenaRezimaNoviThread(Regulator r)
        {
            Thread promenaRezimaThread = new Thread(() => PromeniRezim(r));
            promenaRezimaThread.Start();
        }
        public static void PromeniRezim(Regulator r)
        {
            while (true)
            {
                DateTime trenutnoVreme = DateTime.Now;
                TimeSpan interval;
                if (trenutnoVreme >= r.PocetakDnevnogRezima && trenutnoVreme < r.KrajDnevnogRezima)
                {
                    interval = r.KrajDnevnogRezima - trenutnoVreme;
                    r.Rezim = RegulatorRezimRada.Dnevni;
                    Thread.Sleep(Math.Abs((int)interval.TotalMilliseconds));
                }
                else
                {
                    interval = trenutnoVreme - r.PocetakDnevnogRezima;
                    r.Rezim = RegulatorRezimRada.Nocni;
                    Thread.Sleep(Math.Abs((int)interval.TotalMilliseconds));
                }

            }
        }
    }
}
