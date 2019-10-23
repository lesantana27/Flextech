﻿/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Extensoes\ByteExtensions.cs
Espaço de nome...: Flextech.Infra.Extensoes
Classe...........: ByteExtensions
Descrição........: Extensões do Byte
==================================================================================
Criação..........: 16/07/2019 - Lessandro Santana
Alteração........: 16/07/2019 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Extensoes
{
    public static class ByteExtensions
    {
        public static bool[] ToBoolArray(this byte b)
        {
            // prepare the return result
            bool[] result = new bool[8];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (int i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) == 0 ? false : true;

            // reverse the array
            Array.Reverse(result);

            return result;
        }
    }
}

//private static byte ConvertBoolArrayToByte(bool[] source)
//{
//    byte result = 0;
//    // This assumes the array never contains more than 8 elements!
//    int index = 8 - source.Length;

//    // Loop through the array
//    foreach (bool b in source)
//    {
//        // if the element is 'true' set the bit at that position
//        if (b)
//            result |= (byte)(1 << (7 - index));

//        index++;
//    }

//    return result;
//}