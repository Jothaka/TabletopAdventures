using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ReflectionUtility
{
    public static List<FieldInfo> GetConstants(Type type)
    {
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
             BindingFlags.Static | BindingFlags.FlattenHierarchy);

        return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
    }

    public static Type[] GetAllSubTypes(Type baseClass)
    {
        var result = new List<Type>();
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(baseClass))
                    result.Add(type);
            }
        }
        return result.ToArray();
    }

    public static string[] GetFieldNames(List<FieldInfo> fields)
    {
        return (from field in fields select field.Name).ToArray();
    }

    public static string[] GetTypeNames(Type[] types)
    {
        return (from type in types select type.Name).ToArray();
    }

    public static List<T> GetFieldConstantValues<T>(List<FieldInfo> fields)
    {
        return (from field in fields select (T)field.GetRawConstantValue()).ToList();
    }

    public static T GetConstantValue<T>(FieldInfo constant)
    {
        return (T)constant.GetRawConstantValue();
    }

}
