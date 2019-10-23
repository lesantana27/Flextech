/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Extensoes\Enums.cs
Espaço de nome...: Flextech.Infra.Extensoes
Classe...........: Vários enumeradores
Descrição........: Enumeradores auxiliares para as extensões
==================================================================================
Criação..........: 11/01/2018 - Lessandro Santana
Alteração........: 19/01/2018 - Lessandro Santana
==================================================================================
*/


namespace Flextech.Infra.Extensoes
{
    public enum FormatoDataHora
    {
        Nenhum,

        ddMMyyyyHHmmss,

        yyyyMMdd,
        yyyyMMddHHmmss
    }

    public enum CaracterSeparador
    {
        Nenhum,

        Comma,                      // ,
        Colon,                      // :
        Semicolon,                  // ;
        Hashtag,                    // #
                                    // 
        LessThanSign,               // <
        GreaterThanSign,            // >
                                    // 
        Point,                      // .
                                    // 
        DollarSign,                 // $
        PercentSign,                // %
                                    // 
        Asterisk,                   // *
        PlusSign,                   // +
        Hyphen,                     // -
        EqualSign,                  // =
                                    // 
        SingleQuotation,            // '
        DoubleQuotation,            // "
                                    // 
        Slash,                      // /
        Backslash,                  // \
                                    // 
        AtSign,                     // @
        QuestionMark,               // ?
        ExclamationMark,            // !
                                    // 
        VerticalBar,                // |
        LowLine,                    // _
                                    // 
        Tab,                        // \t

    }
}
