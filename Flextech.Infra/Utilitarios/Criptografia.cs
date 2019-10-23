/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Utilitarios\Criptografia.cs
Espaço de nome...: Flextech.Infra.Utilitarios
Classe...........: Criptografia
Descrição........: 
===============================================================================
Criação..........: 13/03/2018 - Lessandro Santana
Alteração........: 26/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Utilitarios
{
    public partial class Criptografia
    {
        #region ASCII

        //private string lista1 = "abcdefghijklmnopqrstuvxz";
        //private string lista2 = "";

        //public string CodificarASCII(string texto)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    char c;

        //    for (int i = 0; i < texto.Length; i++)
        //    {
        //        c = texto[i];
        //        for (int j = 0; j < lista1.Length; j++)
        //        {
        //            if (c == lista1[j])
        //            {
        //                c = lista2[j];
        //                j = lista1.Length;
        //            }
        //        }
        //        sb.Append(c.ToString());
        //    }

        //    return sb.ToString();
        //}

        public string CodificarASCIINumerico(string texto)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            string bytes = "";
            string aux = "";

            Byte[] encodedBytes = ascii.GetBytes(texto);

            foreach (Byte b in encodedBytes)
            {
                aux = "0" + b.ToString();

                if (aux.Length > 3)
                    aux = aux.Substring(1);

                bytes += aux;
            }

            return bytes;
        }

        public string DecodificarASCIINumerico(string texto)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            Byte[] encodedBytes;
            int tamanho = 0;

            tamanho = texto.Length / 3;

            encodedBytes = new Byte[tamanho];

            for (int i = 1; i < tamanho + 1; i++)
            {
                encodedBytes[i - 1] = Convert.ToByte(texto.Substring((i - 1) * 3, 3));
            }

            return ascii.GetString(encodedBytes);
        }

        #endregion ASCII

        #region DES

        private byte[] DESKey = { };
        private byte[] DESIV = { 0xFE, 0x34, 0x27, 0x78, 0xAA, 0xAB, 0x13, 0xEF };
        private string DESEncryptionKey = "Fl3xT3ch";

        public string CodificarDES(string texto)
        {
            try
            {
                DESKey = System.Text.Encoding.UTF8.GetBytes(DESEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(texto);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(DESKey, DESIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DecodificarDES(string texto)
        {
            Byte[] inputByteArray = new Byte[texto.Length];
            try
            {
                DESKey = System.Text.Encoding.UTF8.GetBytes(DESEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(texto);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(DESKey, DESIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;

                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion DES

        #region NUMÉRICO

        // codifica e decodifica apenas trocando numeros por letras.
        // Ex:  texto = "1;17054314000170;20141107130300";

        //private string numeroMatriz = "1234567890;";
        //private string numeroChave1 = "QJMUDYFTVEP";
        //private string numeroChave2 = "UZPDOGKHSBL";
        //private string numeroChave3 = "FALPSJKCZTM";

        //public string CodificarNumero(string texto)
        //{
        //    Numeric numeric = new Numeric();
        //    StringBuilder sb = new StringBuilder();

        //    string chave = numeroChave1;
        //    int controleChave = 1;

        //    texto = numeric.NumberOnly(texto);

        //    for (int i = 0; i < texto.Length; i++)
        //    {
        //        for (int j = 0; j < chave.Length; j++)
        //        {
        //            if (texto.Substring(i, 1) == numeroMatriz.Substring(j, 1))
        //            {
        //                sb.Append(chave.Substring(j, 1));
        //            }
        //        }
        //        if (texto.Substring(i, 1) == ";") controleChave++;
        //        if (controleChave == 2) chave = numeroChave2;
        //        if (controleChave == 3) chave = numeroChave3;
        //    }
        //    return sb.ToString();
        //}

        //public string DecodificarNumero(string texto)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    string chave = numeroChave1;
        //    int controleChave = 1;

        //    for (int i = 0; i < texto.Length; i++)
        //    {
        //        for (int j = 0; j < chave.Length; j++)
        //        {
        //            if (texto.Substring(i, 1) == chave.Substring(j, 1))
        //            {
        //                sb.Append(numeroMatriz.Substring(j, 1));
        //            }
        //        }
        //        if (texto.Substring(i, 1) == "P" && controleChave == 1) controleChave++;
        //        if (texto.Substring(i, 1) == "L" && controleChave == 2) controleChave++;
        //        if (controleChave == 2) chave = numeroChave2;
        //        if (controleChave == 3) chave = numeroChave3;
        //    }
        //    return sb.ToString();
        //}

        #endregion NUMÉRICO
    }
}
