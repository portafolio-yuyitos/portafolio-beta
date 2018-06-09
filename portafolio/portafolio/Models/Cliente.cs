using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portafolio.Models
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string rut;
        private decimal autorizado_fiado;
        private decimal estado;

        public decimal Autorizado_fiado
        {
            get
            {
                return autorizado_fiado;
            }
            set
            {
                autorizado_fiado = value;
            }
        }

        public decimal Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string Rut
        {
            get
            {
                return rut;
            }
            set
            {
                rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

    }
}