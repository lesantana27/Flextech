using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Flextech.Replicador.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Flextech.Replicador.Estatico.Repositorio.CaminhoCompletoDoArquivo = @"C:\aaa\aaa.replicador.xml";
            Flextech.Replicador.Estatico.Repositorio.NomeDoArquivo = "aaa.replicador.xml";

            Flextech.Replicador.Estatico.Repositorio.CarregarArquivo();

            Flextech.Replicador.Wpf.Estatico.NomeDaTelaPrincipal = Flextech.Replicador.Estatico.Repositorio.NomeDoArquivo;

            Flextech.Replicador.Wpf.Estatico.PrincipalWindow.Show();
        }
    }
}
