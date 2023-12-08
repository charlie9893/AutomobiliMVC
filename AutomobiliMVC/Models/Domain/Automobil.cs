﻿using System;

namespace AutomobiliMVC.Models.Domain
{
    public class Automobil
    {
        public Guid Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public int Zapremina { get; set; }
        public int Snaga { get; set; }
        public string Gorivo { get; set; }
        public string Karoserija { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public string Kontakt { get; set; }

    }
}
