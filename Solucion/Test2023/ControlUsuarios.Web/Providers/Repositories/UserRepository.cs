using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ControlUsuarios.Web.Models;
using ControlUsuarios.Web.Models.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ControlUsuarios.Web.Providers.Repositories
{
    public interface IUserRepository
    {
        bool Register(RegisterVm model, string Url);
        JWT Validate(LoginVm model, string Url);
        List<Rol> GetListaRoles(string Url);
        List<CookieUser> GetListaUsuarios(string Url,string jwt);
        bool ValidarSession(string Url, string jwt);
    }

    public class UserRepository : IUserRepository
    {
        
        public UserRepository()
        {
        }

        public JWT Validate(LoginVm model,string Url)
        {
            return GetJWT(Url, model.UserName, model.Password);
        }

        public bool Register(RegisterVm model, string Url)
        {
            try
            {
                var user = new CookieUser
                {
                    UserName = model.UserName,
                    Clave = model.Password,
                    Enabled = true,
                    EmailAddress = model.EmailAddress,
                    RolRefId = model.RolRefId
                };

                bool respuesta = true;
                string url = Url + "/api/User/Registrar";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                string log = JsonConvert.SerializeObject(user,Formatting.Indented);
                requestWriter.Write(log);
                requestWriter.Close();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    respuesta = response.StatusCode == HttpStatusCode.Created;
                }

                return respuesta;
            }
            catch(WebException e)
            {
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                   string respuesta = reader.ReadToEnd();
                }
                return false;
            }
            
        }

        public List<Rol> GetListaRoles(string Url)
        {
            List<Rol> listaRoles = new List<Rol>();
            string respuesta = string.Empty;
            string url = Url + $"/api/Rol/Get";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.ContentLength = 0;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                String estado = response.StatusDescription;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                }
                else
                {
                    var encoding = ASCIIEncoding.Default;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
                    {
                        respuesta = reader.ReadToEnd();
                    }
                    JsonConvert.PopulateObject(respuesta, listaRoles);
                }
            }
            return listaRoles;
        }

        internal JWT GetJWT(string urlApi,string user,string clave)
        {
            try
            {
                JWT respJWT = new JWT();
                string respuesta = string.Empty;
                string url = urlApi + $"/api/User/Autenticar?userName={user}&clave={clave}";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    String estado = response.StatusDescription;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }
                    else
                    {
                        var encoding = ASCIIEncoding.Default;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
                        {
                            respuesta = reader.ReadToEnd();
                        }
                        JsonConvert.PopulateObject(respuesta, respJWT);
                    }
                }
                return respJWT;
            }
            catch (WebException e)
            {
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string respuesta = reader.ReadToEnd();
                }
                return null;
            }
        }

        public List<CookieUser> GetListaUsuarios(string Url, string jwt)
        {
            try
            {
                List<CookieUser> listaUsuarios = new List<CookieUser>();
                string respuesta = string.Empty;
                string url = Url + $"/api/User/Get";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Headers.Add("Authorization", "Bearer " + jwt);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    String estado = response.StatusDescription;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }
                    else
                    {
                        var encoding = ASCIIEncoding.Default;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
                        {
                            respuesta = reader.ReadToEnd();
                        }
                        JsonConvert.PopulateObject(respuesta, listaUsuarios);
                    }
                }
                return listaUsuarios;
            }
            catch
            {
                return null;
            }
        }

        public bool ValidarSession(string Url, string jwt)
        {
            try
            {
                bool respuesta = false;
                string url = Url + $"/api/Session/ValidarSession?jwt={jwt}";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    String estado = response.StatusDescription;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                    else
                    {
                        var encoding = ASCIIEncoding.Default;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
                        {
                            respuesta = Convert.ToBoolean(reader.ReadToEnd());
                        }
                    }
                }
                return respuesta;
            }
            catch
            {
                return false;
            }
        }
    }
}