/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Extensoes\DataTableExtensions.cs
Espaço de nome...: Flextech.Infra.Extensoes
Classe...........: DataTableExtensions
Descrição........: Extensões do DataTable
==================================================================================
Criação..........: 11/01/2018 - Lessandro Santana
Alteração........: 19/01/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Flextech.Infra.Extensoes
{
    public static class DataTableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this DataTable dt)
        {
            List<string> columns = new List<string>();
            var fields = typeof(T).GetFields();
            var Propriedades = typeof(T).GetProperties();

            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (DataColumn dc in dt.Columns)
            {
                columns.Add(dc.ColumnName);
            }

            foreach (DataRow dr in dt.Rows)
            {
                var object_T = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    if (columns.Contains(fieldInfo.Name))
                    {
                        fieldInfo.SetValue(object_T, dr[fieldInfo.Name]);
                    }
                }

                foreach (var propertyInfo in Propriedades)
                {
                    if (columns.Contains(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(object_T, dr[propertyInfo.Name]);
                    }
                }

                collection.Add(object_T);
            }

            return collection;
        }
    }
}
