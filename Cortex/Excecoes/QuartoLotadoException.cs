﻿using FeriasCo.Cortex.Interfaces;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoLotadoException : FeriasCoException
    {
        public QuartoLotadoException(int id) : base($"O quarto {id} está acima da capacidade permitida")
        {
        }
    }
}
