/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: SerializadorXml.cs
Espaço de nome...: Flextech.Infra.Utilitarios
Classe...........: SerializadorXml
Descrição........: Classe para serializar e desserializar 
==================================================================================
Criação..........: 18/01/2018 - Lessandro Santana
Alteração........: 18/01/2018 - Lessandro Santana
==================================================================================
*/

namespace Flextech.Infra.Utilitarios
{
    public class SerializadorXml
    {
        public bool SerializarParaTexto(object objeto, out string conteudoDoTexto, out string mensagemDeRetorno)
        {
            conteudoDoTexto = "";
            mensagemDeRetorno = "";

            try
            {
                System.IO.StringWriter escritorDeStrings = new System.IO.StringWriter();
                System.Xml.Serialization.XmlSerializer serializador = new System.Xml.Serialization.XmlSerializer(objeto.GetType());
                serializador.Serialize(escritorDeStrings, objeto);

                conteudoDoTexto = escritorDeStrings.ToString();

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }

        public bool SerializarParaArquivo(object objeto, string arquivoCaminhoCompleto, out string mensagemDeRetorno)
        {
            mensagemDeRetorno = "";

            try
            {
                Flextech.Infra.Utilitarios.Arquivo arquivoUtil = new Flextech.Infra.Utilitarios.Arquivo();
                string conteudoDoTexto = "";

                if (!SerializarParaTexto(objeto, out conteudoDoTexto, out mensagemDeRetorno))
                    return false;

                if (!arquivoUtil.EscreverTextoNoArquivo(arquivoCaminhoCompleto, conteudoDoTexto, out mensagemDeRetorno))
                    return false;

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }


        public bool DesserializarDoTexto<T>(string textoXml, out T objeto, out string mensagemDeRetorno)
        {
            objeto = default(T);
            mensagemDeRetorno = "";

            try
            {
                System.IO.StringReader leitorDeString = new System.IO.StringReader(textoXml);
                System.Xml.Serialization.XmlSerializer serializador = new System.Xml.Serialization.XmlSerializer(typeof(T));

                objeto = (T)serializador.Deserialize(leitorDeString);

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }

        public bool DesserializarDoArquivo<T>(string arquivoCaminhoCompleto, out T objeto, out string mensagemDeRetorno)
        {
            objeto = default(T);
            mensagemDeRetorno = "";

            try
            {
                Flextech.Infra.Utilitarios.Arquivo arquivoUtil = new Flextech.Infra.Utilitarios.Arquivo();
                string conteudoDoArquivo = "";

                if (!arquivoUtil.LerTextoDoArquivo(arquivoCaminhoCompleto, out conteudoDoArquivo, out mensagemDeRetorno))
                    return false;

                if (!DesserializarDoTexto<T>(conteudoDoArquivo, out objeto, out mensagemDeRetorno))
                    return false;

                return true;
            }
            catch (System.Exception ex)
            {
                mensagemDeRetorno = $"ERRO: {ex.Message}";

                return false;
            }
        }



    }
}
