/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: Models\ArquivoDeDados.cs
Espaço de nome...: Flextech.Replicador.Wpf.Models
Classe...........: ArquivoDeDados
Descrição........: Classe para controlar a abertura e salvamento do arquivo de dados XML
===============================================================================
Criação..........: 11/01/2019 - Lessandro Santana
Alteração........: 11/01/2019 - Lessandro Santana
===============================================================================
*/


namespace Flextech.Replicador.Wpf.Models
{
    public partial class ArquivoDeDados
    {
        public static bool NovoArquivo()
        {
            if (Flextech.Replicador.Estatico.Repositorio.SalvarPendente == false)
            {
                Flextech.Replicador.Estatico.Repositorio.NovoArquivo();
                return true;
            }

            if (SalvarArquivo())
            {
                Flextech.Replicador.Estatico.Repositorio.NovoArquivo();
                return true;
            }

            return false;
        }

        public static bool AbrirArquivo()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (Flextech.Replicador.Estatico.Repositorio.SalvarPendente == true)
            {
                if (System.Windows.MessageBox.Show("O arquivo de dados do Replicador foi alterado e ainda não foi salvo. \n\nDeseja salvar o arquivo?", "Arquivo não salvo", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Exclamation) == System.Windows.MessageBoxResult.Yes)
                {
                    if (SalvarArquivo() == false)
                        return false;
                }
            }

            openFileDialog.Filter = Flextech.Replicador.Estatico.FiltroDoDialogoDeArquivo;
            openFileDialog.Title = Flextech.Replicador.Estatico.TituloDoDialogoDeArquivoAbrir;
            openFileDialog.DefaultExt = Flextech.Replicador.Estatico.ExtensaoPadraoDeArquivo;

            if (openFileDialog.ShowDialog() == true)
            {
                return AbrirArquivo(openFileDialog.FileName);
            }

            return false;
        }

        public static bool AbrirArquivo(string caminhoCompletoDoArquivo)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(caminhoCompletoDoArquivo);

            Flextech.Replicador.Estatico.Repositorio.CaminhoCompletoDoArquivo = fileInfo.FullName;
            Flextech.Replicador.Estatico.Repositorio.NomeDoArquivo = fileInfo.Name;

            Flextech.Replicador.Estatico.Repositorio.CarregarArquivo();

            return ValidarOperacaoExecutada();
        }

        public static bool SalvarArquivo()
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            if (string.IsNullOrEmpty(Flextech.Replicador.Estatico.Repositorio.NomeDoArquivo))
            {
                saveFileDialog.Filter = Flextech.Replicador.Estatico.FiltroDoDialogoDeArquivo;
                saveFileDialog.Title = Flextech.Replicador.Estatico.TituloDoDialogoDeArquivoSalvar;
                saveFileDialog.DefaultExt = Flextech.Replicador.Estatico.ExtensaoPadraoDeArquivo;
                saveFileDialog.FileName += $"{Flextech.Replicador.Estatico.Repositorio.BancoDeDados.NomeDoBancoDeDados}{Flextech.Replicador.Estatico.ExtensaoPadraoDeArquivo}";

                if (saveFileDialog.ShowDialog() == true)
                {
                    return SalvarArquivo(saveFileDialog.FileName);
                }
                else
                {
                    return false;
                }
            }

            return SalvarArquivo(caminhoCompletoDoArquivo: Flextech.Replicador.Estatico.Repositorio.CaminhoCompletoDoArquivo);
        }

        public static bool SalvarArquivo(string caminhoCompletoDoArquivo)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(caminhoCompletoDoArquivo);

            Flextech.Replicador.Estatico.Repositorio.CaminhoCompletoDoArquivo = fileInfo.FullName;
            Flextech.Replicador.Estatico.Repositorio.NomeDoArquivo = fileInfo.Name;

            Flextech.Replicador.Estatico.Repositorio.SalvarArquivo();

            return ValidarOperacaoExecutada();
        }

        public static bool ValidarOperacaoExecutada()
        {
            if (Flextech.Replicador.Estatico.Repositorio.ExisteErro)
            {
                System.Windows.Forms.MessageBox.Show(Flextech.Replicador.Estatico.Repositorio.TextoDaMensagemDeErro, "ERRO", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}