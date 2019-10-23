/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra.T4Scripts
Arquivo..........: Database\Column.cs
Espaço de nome...: Flextech.Infra.T4Scripts.Database
Classe...........: Column
Descrição........: Column class represents a column table for databases
==================================================================================
Criação..........: 30/11/2017 - Lessandro Santana
Alteração........: 13/01/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.Text;
using Flextech.Infra.Extensoes;

namespace Flextech.Infra.T4Scripts.Database
{
    public class Column
    {
        public string Name { get; set; } = "";
        public string NameTreated { get { return Name.ToUpper(); } }
        public string Position { get; set; } = "";
        public string Type { get; set; } = "";
        public string Size { get; set; } = "";
        public bool PrimaryKey { get; set; } = false;
        public bool ForeignKey { get; set; } = false;

        public string GetTypeCSharp()
        {
            switch (this.Type.ToLower())
            {
                case "bigint":
                    return "Int64";
                case "binary":
                case "image":
                case "varbinary":
                    return "byte[]";
                case "bit":
                    return "bool";
                case "char":
                    return "char";
                case "datetime":
                case "smalldatetime":
                    return "DateTime";
                case "decimal":
                case "money":
                case "numeric":
                    return "decimal";
                case "float":
                    return "double";
                case "int":
                    return "int";
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "string";
                case "real":
                    return "single";
                case "smallint":
                    return "Int16";
                case "tinyint":
                    return "byte";
                case "uniqueidentifier":
                    return "Guid";

                default:
                    return $"GetTypeCSharp(): {this.Type} not implemented";
            }
        }

        public string GetDefaultValueCSharp()
        {
            switch (this.Type.ToLower())
            {
                case "bigint":
                    return "0";
                case "binary":
                case "image":
                case "varbinary":
                    return "Não tem default";
                case "bit":
                    return "false";
                case "char":
                    return "''";
                case "datetime":
                case "smalldatetime":
                    return "new DateTime(2000, 1, 1)";
                case "decimal":
                case "money":
                case "numeric":
                    return "0";
                case "float":
                    return "0";
                case "int":
                    return "0";
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "\"\"";
                case "real":
                    return "0";
                case "smallint":
                    return "0";
                case "tinyint":
                    return "0";
                case "uniqueidentifier":
                    return $"Guid.NewGuid()";

                default:
                    return $"GetDefaultValueCSharp(): {this.Type} not implemented";
            }
        }

        public string GetFormatedValueCSharp(string value)
        {
            string toReturn = $"GetFormatedValueCSharp(): {this.Type} not implemented. ";

            switch (this.Type.ToLower())
            {
                case "bigint":
                    return $"{value}";
                case "binary":
                case "image":
                case "varbinary":
                case "bit":
                    return $"{value.ToLower()}";
                case "char":
                    return $"\"{value}\"";
                case "datetime":
                    string val = value.OnlyNumbers();
                    if (val.Length != 14) { break; }
                    return $"new DateTime({Convert.ToInt32(val.Substring(4, 4))}, {Convert.ToInt32(val.Substring(2, 2))}, {Convert.ToInt32(val.Substring(0, 2))}, {Convert.ToInt32(val.Substring(8, 2))}, {Convert.ToInt32(val.Substring(10, 2))}, {Convert.ToInt32(val.Substring(12, 2))})";
                case "smalldatetime":
                case "decimal":
                case "money":
                case "numeric":
                case "float":
                case "int":
                    return $"{value}";
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return $"@\"{value}\"";
                case "real":
                case "smallint":
                case "tinyint":
                    return $"{value}";
                case "uniqueidentifier":
                    return $"new Guid(\"{value}\")";


                default:
                    break;
            }

            return toReturn;
        }

        public string GetWpfXamlEditField(string generalAttributes = "", string pathBinding = "")
        {
            string attributes = "";
            string binding = "{ Binding " + pathBinding + " }";

            string itemsSource = "";
            string displayMemberPath = "";
            string selectedValuePath = "";
            string selectedValue = "";

            if (this.ForeignKey)
            {
                switch (this.Name)
                {
                    // TYPE_FIELD_PRIMITIVE__ID
                    // TYPE_VISUAL_OBJECT__ID
                    // DATABASE__ID
                    // SCHEMA__ID
                    // TABLE__ID
                    // FIELD__ID
                    // SCHEMA__ID__FOREIGN_KEY
                    // TABLE__ID__FOREIGN_KEY


                    case "TYPE_FIELD_PRIMITIVE__ID":
                        itemsSource = "{Binding Path=ListTYPE_FIELD_PRIMITIVE}";
                        displayMemberPath = "TYPE_NAME";
                        selectedValuePath = "ID";
                        selectedValue = "{Binding Path=TYPE_FIELD_PRIMITIVE.ID}";
                        break;


                    case "ID_CLASS_TABLE_INHERITED": // CLASS_TABLEView.xaml
                        itemsSource = "{Binding Path=ListCLASS_TABLE_INHERITED}";
                        displayMemberPath = "CLASS_TABLE_NAME";
                        selectedValuePath = "ID";
                        selectedValue = "{Binding Path=CLASS_TABLE.ID_CLASS_TABLE_INHERITED}";
                        break;

                    default:
                        break;
                }
            }

            switch (this.Type.ToLower())
            {
                case "bigint":
                    return "Int64";
                case "binary":
                case "image":
                case "varbinary":
                    return "byte[]";
                case "bit":
                    attributes = " VerticalAlignment=\"Center\" HorizontalAlignment=\"Left\" Content=\"Yes\" Width=\"100\" ";
                    return $"<CheckBox {generalAttributes}{attributes} IsChecked=\"{binding}\" />";
                case "char":
                    return "char";
                case "datetime":
                case "smalldatetime":
                    return "DateTime";
                case "decimal":
                case "money":
                case "numeric":
                    return "decimal";
                case "float":
                    return "double";
                case "int":
                    attributes = $" Margin=\"0,6,10,6\" Width=\"100\" HorizontalAlignment=\"Left\" ";
                    if (this.PrimaryKey) attributes += "IsReadOnly=\"True\" ";
                    //return $" <xctk:IntegerUpDown {generalAttributes}{attributes} Value=\"{binding}\"></xctk:IntegerUpDown> ";
                    return $"<TextBox {generalAttributes}{attributes} Text=\"{binding}\" />";
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    attributes = $" Margin=\"0,6\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Center\" ";
                    attributes = $" Margin=\"0,6,10,6\" VerticalAlignment=\"Center\" MaxLength=\"{this.Size}\" ";

                    if (Convert.ToInt32(this.Size) <= 50)
                    {
                        attributes += $" HorizontalAlignment=\"Left\"  Width=\"200\" ";
                    }
                    else if (Convert.ToInt32(this.Size) <= 200)
                    {
                        attributes += $" HorizontalAlignment=\"Left\"  Width=\"500\" ";
                    }
                    else
                    {

                    }

                    return $"<TextBox {generalAttributes}{attributes} Text=\"{binding}\" />";
                case "real":
                    return "single";
                case "smallint":
                    return "Int16";
                case "tinyint":
                    return "byte";
                case "uniqueidentifier":
                    attributes = " VerticalAlignment=\"Center\" HorizontalAlignment=\"Left\" Width=\"300\" ";
                    if (this.PrimaryKey)
                    {
                        attributes += $" Margin=\"0,6,10,6\" IsReadOnly=\"True\" CharacterCasing=\"Upper\" ";
                        return $"<TextBox {generalAttributes}{attributes} Text=\"{binding}\" />";
                    }

                    return $"<ComboBox {generalAttributes}{attributes} ItemsSource=\"{itemsSource}\" DisplayMemberPath=\"{displayMemberPath}\" SelectedValuePath=\"{selectedValuePath}\" SelectedValue=\"{selectedValue}\" />";
                default:
                    return $"<TextBox {generalAttributes} Background=\"Red\" Text=\"ERROR: GetWpfXamlEditField -> {this.Name.ToLower()} not found\" />";
            }
        }


        public string GetSqlServerVariable(bool withEqualNull = false)
        {
            string equalNull = withEqualNull ? " = NULL" : "";
            string withSize = this.Type.ToLower().Contains("char") ? $"({this.Size})" : "";
            return $"@{this.Name} {this.Type.ToUpper()} {withSize}{equalNull}";
        }



        public StringBuilder GerarAtributosReplicador()
        {
            StringBuilder sb = new StringBuilder();
            string displayOrder = this.Position.Length == 2 ? this.Position : $"0{this.Position}";
            string displayName = this.Name;
            string displayShortName = this.Name;
            string displayGroupName = "Outros";
            string displayDescription = "";

            if (this.PrimaryKey) { sb.AppendLine($"        [Key]"); }

            if (this.Name == "ID")
            {
                //sb.AppendLine($"[Category(\"Identificador\")]");
                displayGroupName = "Identificador";
                sb.AppendLine($"        [ReadOnly(true)]");
            }

            if (this.Name.StartsWith("ROTULO_")) { displayGroupName = "Rótulos"; }
            if (this.Name.Contains("NOME")) { displayGroupName = "Nome"; }
            if (this.Name.Contains("MOSTRAR")) { displayGroupName = "Mostrar - Display field"; }
            if (this.Name.Contains("EDITAR")) { displayGroupName = "Editar - Edit field"; }
            if (this.Name.Contains("CHAVE_PRIMARIA")) { displayGroupName = "Chave Primaria"; }
            if (this.Name.Contains("CHAVE_ESTRANGEIRA")) { displayGroupName = "Chave Estrangeira"; }
            if (this.Name.Contains("VISIVEL_")) { displayGroupName = "Visibilidade"; }
            if (this.Name.Contains("FORMATO_")) { displayGroupName = ""; }
            if (this.Name.Contains("TAMANHO_")) { displayGroupName = "Tamanho do Campo"; }
            if (this.Name.Contains("VALOR_PADRAO")) { displayGroupName = "Valores Padrão"; }

            if (this.Name.Contains("CALCULADO_PELO_SISTEMA")) { displayGroupName = "Sistema"; }
            if (this.Name.Contains("PERMITIR_NULO")) { displayGroupName = "Sistema"; }
            if (this.Name.Contains("ORDEM_SEQUENCIAL_NA_TABELA")) { displayGroupName = "Sistema"; }

            if (this.Name.Contains("BANCO_DE_DADOS")) { displayGroupName = "Banco de Dados"; }
            if (this.Name.Contains("ESQUEMA")) { displayGroupName = "Esquema"; }
            if (this.Name.Contains("TABELA")) { displayGroupName = "Tabela"; }
            if (this.Name.Contains("CAMPO")) { displayGroupName = "Campo"; }
            if (this.Name.Contains("TIPO_OBJETO_VISUAL")) { displayGroupName = "Objeto Visual"; }
            if (this.Name.Contains("TIPO_PRIMITIVO_CAMPO")) { displayGroupName = "Tipo Primitivo"; }

            if (this.Name == "DICA_DE_CONTEXTO") { displayGroupName = "Dica de Contexto - Tooltip"; }
            if (this.Name.StartsWith("DESENVOLVEDOR_")) { displayGroupName = "Desenvolvedor"; }
            if (this.Name.StartsWith("USUARIO_")) { displayGroupName = "Usuário"; }

            sb.AppendLine("        [DataMember]");
            sb.Append($"        [Display(Order = {displayOrder}, Name = \"{displayName}\", ShortName = \"{displayShortName}\", GroupName = \"{displayGroupName}\", Description = \"{displayDescription}\")]");
            return sb;
        }
    }
}

