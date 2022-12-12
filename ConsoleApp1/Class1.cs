//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using Microsoft.OpenApi.Any;
//using Microsoft.OpenApi.Models;
//using SnelStart.Diva.Enums;
//using Swashbuckle.AspNetCore.SwaggerGen;
//namespace SnelStart.Diva.Swagger;

//public class EnumerationToEnumSchemaFilter : ISchemaFilter
//{
//    private static IEnumerable<FieldInfo> GetFieldInfoRecursive(Type type)
//    {
//        var fields = new List<FieldInfo>();
//        if (type.BaseType != typeof(Enumeration) && type.BaseType != null)
//        {
//            fields.AddRange(GetFieldInfoRecursive(type.BaseType));
//        }
//        fields.AddRange(type.GetFields(BindingFlags.Static | BindingFlags.Public));
//        return fields;
//    }
//    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
//    {
//        if (!context.Type.IsSubclassOf(typeof(Enumeration)))
//        {
//            return;
//        }
//        var fields = GetFieldInfoRecursive(context.Type);
//        schema.Enum = fields.Select(field => new OpenApiString(field.Name)).Cast<IOpenApiAny>().ToList();
//        schema.Type = "string";
//        schema.Properties = null;
//        schema.AllOf = null;
//    }
//}

