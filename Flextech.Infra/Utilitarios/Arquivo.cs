/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Arquivo.cs
Espaço de nome...: Flextech.Infra.Utilitarios
Classe...........: Arquivo
Descrição........: Classe para ler e gravar no sistema arquivos do sistema operacional
==================================================================================
Criação..........: 18/01/2018 - Lessandro Santana
Alteração........: 24/01/2018 - Lessandro Santana
==================================================================================
*/

using System.Text;

namespace Flextech.Infra.Utilitarios
{
    public class Arquivo
    {
        public bool LerTextoDoArquivo(string arquivoCaminhoCompleto, out StringBuilder conteudoDoArquivo, out string mensagemDeRetorno)
        {
            mensagemDeRetorno = "";
            conteudoDoArquivo = new StringBuilder();
            string texto = "";

            if (LerTextoDoArquivo(arquivoCaminhoCompleto: arquivoCaminhoCompleto, conteudoDoArquivo: out texto, mensagemDeRetorno: out mensagemDeRetorno))
            {
                conteudoDoArquivo.Append(texto);
                return true;
            }

            return false;
        }

        public bool LerTextoDoArquivo(string arquivoCaminhoCompleto, out string conteudoDoArquivo, out string mensagemDeRetorno)
        {
            conteudoDoArquivo = "";
            mensagemDeRetorno = "";

            try
            {
                if (!System.IO.File.Exists(arquivoCaminhoCompleto))
                {
                    mensagemDeRetorno = $"ERRO: Arquivo não encontrado -> {arquivoCaminhoCompleto}";

                    return false;
                }

                conteudoDoArquivo = System.IO.File.ReadAllText(arquivoCaminhoCompleto);
                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }

        public bool EscreverTextoNoArquivo(string arquivoCaminhoCompleto, string conteudoDoArquivo, out string mensagemDeRetorno)
        {
            mensagemDeRetorno = "";
            try
            {
                System.IO.File.WriteAllText(arquivoCaminhoCompleto, conteudoDoArquivo);

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }

        public bool EscreverTextoNoArquivo(string diretorio, string nomeDoArquivo, string conteudoDoArquivo, out string mensagemDeRetorno)
        {
            mensagemDeRetorno = "";
            try
            {
                if (!System.IO.Directory.Exists(diretorio))
                    System.IO.Directory.CreateDirectory(diretorio);

                System.IO.File.WriteAllText(diretorio + nomeDoArquivo, conteudoDoArquivo);

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }

        //public bool CreateFileIfNotExist(string arquivo, string fileName, out string mensagemDeRetorno)
        //{
        //    mensagemDeRetorno = "";

        //    try
        //    {
        //        if (!System.IO.Directory.Exists(arquivo))
        //            System.IO.Directory.CreateDirectory(arquivo);

        //        if (!System.IO.File.Exists(arquivo + fileName))
        //        {
        //            System.IO.File.Create(arquivo + fileName);
        //        }
        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        mensagemDeRetorno = $"ERRO: {ex.Message}";

        //        return false;
        //    }
        //}


        //public void DescompactarArquivo(string arquivoFonte, string diretorioDestino)
        //{
        //    ZipInputStream zipIn = new ZipInputStream(File.OpenRead(arquivoFonte));
        //    ZipEntry entry;
        //    while ((entry = zipIn.GetNextEntry()) != null)
        //    {
        //        FileStream streamWriter = File.Create(diretorioDestino + entry.Name);
        //        long size = entry.Size;
        //        byte[] data = new byte[size];
        //        while (true)
        //        {
        //            size = zipIn.Read(data, 0, data.Length);
        //            if (size > 0) streamWriter.Write(data, 0, (int)size);
        //            else break;
        //        }
        //        streamWriter.Close();
        //    }
        //}

        //public void DescompactarArquivoFastZip(string arquivoFonte, string arquivoDestino)
        //{
        //    FastZip fZip = new FastZip();
        //    fZip.ExtractZip(arquivoFonte, arquivoDestino, "");
        //}

        //public void DescompactarArquivoGZipStream(string arquivoFonte, string arquivoDestino)
        //{
        //    // Get the stream of the source file.
        //    FileInfo fi = new FileInfo(arquivoFonte);
        //    using (FileStream inFile = fi.OpenRead())
        //    {
        //        //Create the decompressed file.
        //        using (FileStream outFile = File.Create(arquivoDestino))
        //        {
        //            using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
        //            {
        //                Decompress.CopyTo(outFile);
        //            }
        //        }
        //    }
        //}

        //private void CompactarArquivo(string diretorioFonte, string arquivoDestino)
        //{
        //    ZipOutputStream zipOut = new ZipOutputStream(File.Create(arquivoDestino));
        //    foreach (string fName in Directory.GetFiles(diretorioFonte))
        //    {
        //        FileInfo fi = new FileInfo(fName);
        //        ZipEntry entry = new ZipEntry(fi.Name);
        //        FileStream sReader = File.OpenRead(fName);
        //        byte[] buff = new byte[Convert.ToInt32(sReader.Length)];
        //        sReader.Read(buff, 0, (int)sReader.Length);
        //        entry.DateTime = fi.LastWriteTime;
        //        entry.Size = sReader.Length;
        //        sReader.Close();
        //        zipOut.PutNextEntry(entry);
        //        zipOut.Write(buff, 0, buff.Length);
        //    }
        //    zipOut.Finish();
        //    zipOut.Close();
        //}

        //private void CompactarArquivoFastZip(string diretorioFonte, string arquivoDestino, bool incluirSubdiretorio)
        //{
        //    FastZip fZip = new FastZip();
        //    fZip.CreateZip(arquivoDestino, diretorioFonte, incluirSubdiretorio, "");
        //}

        //public void CompactarArquivoGZipStream(string arquivoFonte, string arquivoDestino)
        //{
        //    // Get bytes from input stream
        //    FileStream inFileStream = new FileStream(Path.Combine(Environment.CurrentDirectory, arquivoFonte), FileMode.Open);
        //    byte[] buffer = new byte[inFileStream.Length];
        //    inFileStream.Read(buffer, 0, buffer.Length);
        //    inFileStream.Close();

        //    // Create GZip file stream and compress input bytes
        //    FileStream outFileStream = new FileStream(Path.Combine(Environment.CurrentDirectory, arquivoDestino), FileMode.Create);
        //    GZipStream compressedStream = new GZipStream(outFileStream, CompressionMode.Compress);
        //    compressedStream.Write(buffer, 0, buffer.Length);
        //    compressedStream.Close();
        //    outFileStream.Close();
        //}


























        //private void CompactarArquivo(string arquivoFonte, string arquivoDestino)
        //{
        //    // http://msdn.microsoft.com/pt-br/library/system.io.compression.gzipstream.aspx
        //    FileInfo fi = new FileInfo(arquivoFonte);
        //    using (FileStream inFile = fi.OpenRead())
        //    {
        //        using (FileStream outFile = File.Create(arquivoDestino))
        //        {
        //            using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
        //            {
        //                inFile.CopyTo(Compress);
        //            }
        //        }
        //    }
        //}

        //private void DescompactarArquivo(string arquivoFonte, string arquivoDestino)
        //{
        //    // http://msdn.microsoft.com/pt-br/library/system.io.compression.gzipstream.aspx
        //    FileInfo fi = new FileInfo(arquivoFonte);
        //    using (FileStream inFile = fi.OpenRead())
        //    {
        //        string curFile = fi.FullName;
        //        string origName = curFile.Remove(curFile.Length - fi.Extension.Length);

        //        using (FileStream outFile = File.Create(arquivoDestino))
        //        {
        //            using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
        //            {
        //                Decompress.CopyTo(outFile);
        //            }
        //        }
        //    }
        //}
    }
}
