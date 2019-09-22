using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Client
{
    public static class SessionExtensions
    {
        public static T GetObject<T>(this ISession session,string Key)
        {
            var obj= session.GetString(Key);
            if(!String.IsNullOrEmpty(obj))
               return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(obj);

            return default(T);
        }
        public static void SetObject<T>(this ISession session, string Key,object content)
        {
             session.SetString(Key, Newtonsoft.Json.JsonConvert.SerializeObject(content));           
        }

        //public static string Getstring(this ISession session, string Key)
        //{
        //    return session.GetString(Key);
        //}
        //public static void Setstring(this ISession session, string Key, string content)
        //{
        //    try
        //    {
        //        session.SetString(Key, content);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
          
        //}
    }
}
