﻿using El_Camello.Modelo.clases;
using System.Windows.Controls;

namespace El_Camello.Vistas.Aspirante.controles
{
    /// <summary>
    /// Lógica de interacción para ConversacionControl.xaml
    /// </summary>
    public partial class ConversacionControl : UserControl
    {
        public Conversacion conversacion;

        public Conversacion Conversacion
        {
            get
            {
                return conversacion;
            }
            set
            {
                conversacion = value;
                if (conversacion != null)
                {
                    lblNombre.Content = "Título: " + conversacion.Titulo;
                    lblFechaContratacion.Content = "Fecha contratación: " + conversacion.FechaContratacion.ToShortDateString();
                }
            }
        }

        public ConversacionControl()
        {
            InitializeComponent();
            conversacion = new Conversacion();
        }
    }
}
