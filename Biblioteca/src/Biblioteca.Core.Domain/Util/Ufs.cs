﻿using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Domain.Util
{
    public enum Ufs
    {
        [Display(Name = "Acre")]
        AC,
        [Display(Name = "Alagoas")]
        AL,
        [Display(Name = "Amapá")]
        AP,
        [Display(Name = "Amazonas")]
        AM,
        [Display(Name = "Bahia")]
        BA,
        [Display(Name = "Ceará")]
        CE,
        [Display(Name = "Distrito Federal")]
        DF,
        [Display(Name = "Espírito Santo")]
        ES,
        [Display(Name = "Goiás")]
        GO,
        [Display(Name = "Maranhão")]
        MA,
        [Display(Name = "Mato Grosso")]
        MT,
        [Display(Name = "Mato Grosso do Sul")]
        MS,
        [Display(Name = "Minas Gerais")]
        MG,
        [Display(Name = "Paraná")]
        PR,
        [Display(Name = "Paraíba")]
        PB,
        [Display(Name = "Pará")]
        PA,
        [Display(Name = "Pernambuco")]
        PE,
        [Display(Name = "Piauí")]
        PI,
        [Display(Name = "Rio de Janeiro")]
        RJ,
        [Display(Name = "Rio Grande do Norte")]
        RN,
        [Display(Name = "Rio Grande do Sul")]
        RS,
        [Display(Name = "Rondônia")]
        RO,
        [Display(Name = "Roraima")]
        RR,
        [Display(Name = "Santa Catarina")]
        SC,
        [Display(Name = "Sergipe")]
        SE,
        [Display(Name = "São Paulo")]
        SP,
        [Display(Name = "Tocantins")]
        TO

    }

    public class Estado
    {

        public string Nome { get; set; }
        public Ufs Uf { get; set; }

       

    }
}
