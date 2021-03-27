using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using System.Net;

namespace CROM.Tools.Comun.Extensions
{
    public static class ObjectExtensions
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            if (obj is ExpandoObject) return obj.GetPropertyValue(propertyName) != null;
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public static PropertyInfo GetPropertyInfo(this object obj, string name)
        {
            PropertyInfo info = null;
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                info = type.GetProperty(part);
            }
            return info;
        }

        public static PropertyInfo GetPropertyInfoInternal(this object o, string member)
        {
            try
            {


                if (o == null) throw new ArgumentNullException("o");
                if (member == null) throw new ArgumentNullException("member");
                Type scope = o.GetType();
                IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
                if (provider != null)
                {
                    var odictionary = (IDictionary<string, object>)o;
                    if (!odictionary.Any(x => x.Key.Equals(member, StringComparison.OrdinalIgnoreCase))) return null;
                    var odynamic = odictionary.FirstOrDefault(x => x.Key.Equals(member, StringComparison.OrdinalIgnoreCase));
                    member = odynamic.Key;
                    //if (!odynamic.ContainsKey(member)) return null;
                    //if (odynamic.Any(x => x.Key.ToLower() == member.ToLower())) return null;



                    ParameterExpression param = Expression.Parameter(typeof(object));
                    DynamicMetaObject mobj = provider.GetMetaObject(param);
                    GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new[] { CSharpArgumentInfo.Create(0, null) });
                    DynamicMetaObject ret = mobj.BindGetMember(binder);
                    BlockExpression final = Expression.Block(
                        Expression.Label(CallSiteBinder.UpdateLabel),
                        ret.Expression
                    );
                    LambdaExpression lambda = Expression.Lambda(final, param);
                    Delegate del = lambda.Compile();
                    return null;
                    //return del.DynamicInvoke(o);
                }
                else
                {
                    var oProperty = o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (oProperty != null)
                        //return oProperty.GetValue(o, null);
                        return oProperty;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static object GetPropertyValue(this object o, string member)
        {
            try
            {


                if (o == null) throw new ArgumentNullException("o");
                if (member == null) throw new ArgumentNullException("member");
                Type scope = o.GetType();
                IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
                if (provider != null)
                {
                    var odictionary = (IDictionary<string, object>)o;
                    if (!odictionary.Any(x => x.Key.Equals(member, StringComparison.OrdinalIgnoreCase))) return null;
                    var odynamic = odictionary.FirstOrDefault(x => x.Key.Equals(member, StringComparison.OrdinalIgnoreCase));
                    member = odynamic.Key;
                    //if (!odynamic.ContainsKey(member)) return null;
                    //if (odynamic.Any(x => x.Key.ToLower() == member.ToLower())) return null;



                    ParameterExpression param = Expression.Parameter(typeof(object));
                    DynamicMetaObject mobj = provider.GetMetaObject(param);
                    GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new[] { CSharpArgumentInfo.Create(0, null) });
                    DynamicMetaObject ret = mobj.BindGetMember(binder);
                    BlockExpression final = Expression.Block(
                        Expression.Label(CallSiteBinder.UpdateLabel),
                        ret.Expression
                    );
                    LambdaExpression lambda = Expression.Lambda(final, param);
                    Delegate del = lambda.Compile();
                    return del.DynamicInvoke(o);
                }
                else
                {
                    var oProperty = o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (oProperty != null)
                        return oProperty.GetValue(o, null);
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T GetProperty<T>(this Object obj, String name)
        {
            Object retval = GetPropertyValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static List<KeyValuePair<string, string>> ObtenerHeaderService(WebHeaderCollection headers)
        {
            List<KeyValuePair<string, string>> lstHeaders = new List<KeyValuePair<string, string>>();
            int numFila = 0;
            foreach (string name in headers)
            {
                string[] dato = headers.GetValues(numFila);
                KeyValuePair<string, string> datoPar = new KeyValuePair<string, string>(name, dato[0]);
                lstHeaders.Add(datoPar);
                ++numFila;
            }
            return lstHeaders;
        }

    }
}
