using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace lab_12
{
    public static class Reflector
    {
        public static string Analize(Type type, string path = "")
        {
            if (path == "")
            {
                path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{type.Name}_ReflectorLog.txt";
            }

            var fullInfo = "";
            fullInfo += Writer("Assembly Information", GetAssembly(type));
            fullInfo += Writer("Interfaces", GetInterfaces(type));
            fullInfo += Writer("Fields", GetFields(type));
            fullInfo += Writer("Properties", GetProperties(type));
            fullInfo += Writer("Constructors", GetConstructors(type));
            fullInfo += Writer("Methods", GetMethods(type));
            
            using (var sw = new StreamWriter(path))
            {
                sw.Write(fullInfo);
            }
            
            return fullInfo;
        }

        public static string GetAssembly(Type type)
        {
            var assemblyInfo = $"Name: {type.Module.Name}\n";
            assemblyInfo += $"Full name: {type.Module.Assembly.FullName}";
            assemblyInfo += $"Location: {type.Module.Assembly.Location}\n";
            return assemblyInfo;
        }
        
        public static string GetFields(Type type)
        {
            var fields = "";

            foreach (var a in typeof(string).GetFields())
            {
                if (a.IsPublic)
                {
                    fields += "Public ";
                }
                else
                {
                    fields += "Private ";
                }

                fields += $"{a.FieldType.Name} {a.Name};\n";
            }

            return fields;
        }
        
        public static string GetProperties(Type type)
        {
            var properties = "";

            foreach (var a in typeof(string).GetProperties())
            {
                properties += $"{a.PropertyType.Name} {a.Name};\n";
            }

            return properties;
        }
        
        public static string GetConstructors(Type type)
        {
            string ctors = "";
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                if (ctor.IsPublic)
                    ctors += "Public ";
                else
                    ctors += "Private ";
                
                ctors += $"{type.Name} (";
                
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    ctors += $"{parameters[i].ParameterType.Name} {parameters[i].Name}";
                    if (i + 1 < parameters.Length) ctors += ", ";
                }

                ctors += ")\n";
            }

            return ctors;
        }
        
        public static string GetMethods(Type type)
        {
            string methods = "";
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)
                    methods += "Public ";
                else
                    methods += "Private ";
                
                methods += $"{method.Name} (";

                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    methods += $"{parameters[i].ParameterType.Name} {parameters[i].Name}";
                    if (i + 1 < parameters.Length) methods += ", ";
                }

                methods += ");\n";
            }

            return methods;
        }
        
        public static string GetInterfaces(Type type)
        {
            var interfaces = type.GetInterfaces();
            var interfacesInfo = "";

            foreach (var @interface in interfaces)
            {
                interfacesInfo += $"{@interface.Name}\n";
            }

            return interfacesInfo;
        }

        private static string Writer(string title, string text)
        {
            var fullText = "";
            
            var border = "";
            for (int i = 0; i < title.Length + 30; i++)
                border += "-";

            fullText += $"{border}\n{title}\n{border}\n\n";
            fullText += $"{text}\n";

            return fullText;
        }

        public static List<string> TrashFunc(Type type, string parameterType)
        {
            var methods = new List<string>();
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                foreach (var parameter in parameters)
                {
                    if (parameter.ParameterType.Name == parameterType)
                    {
                        methods.Add(method.Name);
                        break;
                    }
                }
            }

            return methods;
        }

        public static object Invoke(Type type, string methodName, object[] parameters)
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            object classObject = constructor?.Invoke(new object[]{});

            MethodInfo method = type.GetMethod(methodName);
            if (method?.ReturnType.Name != "Void")
            {
                object value = method?.Invoke(classObject, parameters);
                return value;
                /*Console.WriteLine("MethodInfo.Invoke() Example\n");
                Console.WriteLine($"MagicClass.ItsMagic() returned: {value}");*/
            }
            return new object();
        }

        public static object Invoke(Type type, string methodName, string path)
        {
            List<object> parameters = new List<object>();
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    parameters.Add(JsonConvert.DeserializeObject<object>(sr.ReadLine()!));
                }
            }
            // ReSharper disable once CoVariantArrayConversion
            return Invoke(type, methodName, parameters.ToArray());
        }

        public static object Create(Type type, Type[] parametersType)
        {
            var constructor = type.GetConstructor(parametersType);
            object classObject = constructor?.Invoke(new object[]{});

            return classObject;
        }
    }
}