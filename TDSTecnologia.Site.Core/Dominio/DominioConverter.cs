using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace TDSTecnologia.Site.Core.Dominio
{
    public class DominioConverter
    {
        public static ValueConverter<DomTurno, string> ConverterDomTurno()
        {
            ValueConverter<DomTurno, string> converter = new ValueConverter<DomTurno, string>(
            v => v.ToString(),
            v => (DomTurno)Enum.Parse(typeof(DomTurno), v));
            return converter;
        }

        public static ValueConverter<DomNivel, string> ConverterDomNivel()
        {
            ValueConverter<DomNivel, string> converter = new ValueConverter<DomNivel, string>(
            v => v.ToString(),
            v => (DomNivel)Enum.Parse(typeof(DomNivel), v));
            return converter;
        }

        public static ValueConverter<DomModalidade, string> ConverterDomModalidade()
        {
            ValueConverter<DomModalidade, string> converter = new ValueConverter<DomModalidade, string>(
            v => v.ToString(),
            v => (DomModalidade)Enum.Parse(typeof(DomModalidade), v));
            return converter;
        }
    }
}
