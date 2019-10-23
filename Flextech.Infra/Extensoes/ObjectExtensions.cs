/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Extensoes\ObjectExtension.cs
Espaço de nome...: Flextech.Infra.Extensoes
Classe...........: ObjectExtension
Descrição........: Extensões do Object
==================================================================================
Criação..........: 02/01/2018 - Lessandro Santana
Alteração........: 19/01/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Flextech.Infra.Extensoes
{
    public static class ObjectExtensions
    {
        private static readonly MethodInfo CloneMethod = typeof(System.Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);


        public static Dictionary<string, object> ToDictionary<T>(this object obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                dic.Add(propertyInfo.Name, propertyInfo.GetValue(obj));
            }

            return dic;
        }

        public static T DeepCopyTo<T>(this object obj) where T : new()
        {
            var convertPropriedades = TypeDescriptor.GetProperties(typeof(T)).Cast<PropertyDescriptor>();
            var entityPropriedades = TypeDescriptor.GetProperties(obj).Cast<PropertyDescriptor>();

            var convert = new T();

            foreach (var entityProperty in entityPropriedades)
            {
                var property = entityProperty;
                var convertProperty = convertPropriedades.FirstOrDefault(prop => prop.Name == property.Name);
                if (convertProperty != null)
                {
                    convertProperty.SetValue(convert, Convert.ChangeType(entityProperty.GetValue(obj), convertProperty.PropertyType));
                }
            }

            return convert;
        }


        public static T CloneData<T>(this object source)
        {
            var target = (T)Activator.CreateInstance(typeof(T));

            Type objTypeSource = source.GetType();
            Type objTypeTarget = target.GetType();

            PropertyInfo propertyInfoTarget = null;
            var propertyInfoSourceArray = objTypeSource.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfoSource in propertyInfoSourceArray)
            {
                try
                {
                    propertyInfoTarget = objTypeTarget.GetProperty(propertyInfoSource.Name, BindingFlags.Instance | BindingFlags.Public);
                    if (propertyInfoTarget != null)
                    {
                        propertyInfoTarget.SetValue(target, propertyInfoSource.GetValue(source));
                    }
                }
                catch (ArgumentException aex) { if (!string.IsNullOrEmpty(aex.Message)) continue; }
                catch (Exception ex) { if (!string.IsNullOrEmpty(ex.Message)) return default(T); }
            }

            return target;
        }



        public static bool IsPrimitive(this Type type)
        {
            if (type == typeof(System.String)) return true;
            return (type.IsValueType & type.IsPrimitive);
        }

        public static T Copy<T>(this T original)
        {
            return (T)Copy((System.Object)original);
        }

        public static Object Copy(this System.Object originalObject)
        {
            return InternalCopy(originalObject, new Dictionary<System.Object, System.Object>(new ReferenceEqualityComparer()));
        }

        private static Object InternalCopy(System.Object originalObject, IDictionary<System.Object, System.Object> visited)
        {
            if (originalObject == null) return null;
            var typeToReflect = originalObject.GetType();
            if (IsPrimitive(typeToReflect)) return originalObject;
            if (visited.ContainsKey(originalObject)) return visited[originalObject];
            if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (IsPrimitive(arrayType) == false)
                {
                    Array clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                }

            }
            visited.Add(originalObject, cloneObject);
            CopyFields(originalObject, visited, cloneObject, typeToReflect);
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
            return cloneObject;
        }

        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType != null)
            {
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        }

        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false) continue;
                if (IsPrimitive(fieldInfo.FieldType)) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        }
    }

    public class ReferenceEqualityComparer : EqualityComparer<System.Object>
    {
        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }
        public override int GetHashCode(object obj)
        {
            if (obj == null) return 0;
            return obj.GetHashCode();
        }
    }


    public static class ArrayExtensions
    {
        public static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0) return;
            ArrayTraverse walker = new ArrayTraverse(array);
            do action(array, walker.Position);
            while (walker.Step());
        }
    }

    internal class ArrayTraverse
    {
        public int[] Position;
        private int[] maxLengths;

        public ArrayTraverse(Array array)
        {
            maxLengths = new int[array.Rank];
            for (int i = 0; i < array.Rank; ++i)
            {
                maxLengths[i] = array.GetLength(i) - 1;
            }
            Position = new int[array.Rank];
        }

        public bool Step()
        {
            for (int i = 0; i < Position.Length; ++i)
            {
                if (Position[i] < maxLengths[i])
                {
                    Position[i]++;
                    for (int j = 0; j < i; j++)
                    {
                        Position[j] = 0;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
