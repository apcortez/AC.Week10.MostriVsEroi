using System;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.Core
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IUtenteRepository utenteRepo;
        private readonly IEroeRepository eroeRepo;
        private readonly IMostroRepository mostroRepo;

        public BusinessLayer(IUtenteRepository utenti, IEroeRepository eroi, IMostroRepository mostri)
        {
            utenteRepo = utenti;
            eroeRepo = eroi;
            mostroRepo = mostri;
        }
    }
}
