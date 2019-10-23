/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: Base\RepositorioBase.cs
Espaço de nome...: Flextech.Replicador.Base
Classe...........: RepositorioBase
Descrição........: 
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Runtime.Serialization;

namespace Flextech.Replicador.Base
{
    [DataContract]
    public partial class RepositorioBase : Flextech.Infra.Base.ObjetoBase
    {
    }
}