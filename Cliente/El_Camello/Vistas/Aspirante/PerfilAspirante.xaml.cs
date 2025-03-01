﻿using El_Camello.Assets.utilerias;
using El_Camello.Modelo.dao;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace El_Camello.Aspirante
{
    /// <summary>
    /// Interaction logic for PerfilAspirante.xaml
    /// </summary>
    public partial class PerfilAspirante : Window
    {
        private int idUsuarioAspirante;
        private string token;
        private Modelo.clases.Aspirante aspiranteConsultado;
        private Modelo.clases.Usuario usuario;

        public PerfilAspirante(int idUsuarioAspirante, string token)
        {
            this.idUsuarioAspirante = idUsuarioAspirante;
            this.token = token;

            InitializeComponent();

            cargarAspirante();
        }

        private void cargarAspirante()
        {
            obtenerAspirante();


        }

        private async void obtenerAspirante()
        {
            usuario = await UsuarioDAO.getUsuario(idUsuarioAspirante, token);
            aspiranteConsultado = await AspiranteDAO.GetAspirante(idUsuarioAspirante, token);
            //aspiranteConsultado.Video = await AspiranteDAO.GetVideo(idUsuarioAspirante, token);

            tbAspirante.Text = aspiranteConsultado.NombreAspirante;
            tbAspirante.IsEnabled = false;
            tbCorreo.Text = usuario.CorreoElectronico;
            tbCorreo.IsEnabled = false;
            tbDireccion.Text = aspiranteConsultado.Direccion;
            tbDireccion.IsEnabled = false;
            tbTelefono.Text = aspiranteConsultado.Telefono;
            tbTelefono.IsEnabled = false;
            cargarImagen(usuario.Fotografia);
            dgOficios.ItemsSource = aspiranteConsultado.Oficios;

            /*
            aspiranteConsultado.RutaVideo = "";
            do
            {
                aspiranteConsultado.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
            } while (System.IO.File.Exists(aspiranteConsultado.RutaVideo));

            MemoryStream_toFile.MemoryStreamToFile(aspiranteConsultado.Video, aspiranteConsultado.RutaVideo);
            meVideoAspirante.Source = new Uri(aspiranteConsultado.RutaVideo);
            */

        }

        private void cargarImagen(byte[] fotografia)
        {
            try
            {
                byte[] fotoPerfil = fotografia;
                if (fotoPerfil == null)
                {
                    fotoPerfil = null;
                }
                else if (fotoPerfil.Length > 0)
                {
                    using (var memoryStream = new System.IO.MemoryStream(fotoPerfil))
                    {
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = memoryStream;
                        imagen.EndInit();
                        this.imgAspirante.Source = imagen;
                    }
                }
            }
            catch (Exception)
            {
                imgAspirante.Source = null;
            }
        }

        private void cerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
