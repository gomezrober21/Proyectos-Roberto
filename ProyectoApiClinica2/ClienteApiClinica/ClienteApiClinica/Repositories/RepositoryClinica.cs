using ClienteApiClinica.Helpers;
using ClienteApiClinica.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClienteApiClinica.Repositories
{
    public class RepositoryClinica
    {
        public String url;
        public MediaTypeWithQualityHeaderValue header;
        public RepositoryClinica()
        {

            this.url = "https://proyectoapiclinica2.azurewebsites.net/";
            //this.url = "https://localhost:44389/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        #region USUARIO

        public async Task<List<Usuario>> GetUsuarios()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/usuarios";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                /// MediaTypeWithQualityHeaderValue header = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    List<Usuario> usuario = await response.Content.ReadAsAsync<List<Usuario>>();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Usuario> BuscarUsuario(String username)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/usuarios/" + username;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Usuario usuario = await response.Content.ReadAsAsync<Usuario>();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task RegistrarUsuario(String nombreusu, String contrasena, String nombre, String apellido, int edad, int telefono, String email)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/usuarios";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Usuario usuario = new Usuario();
                usuario.NombreUsuario = nombreusu;
                usuario.Contrasena = contrasena;
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Edad = edad;
                usuario.Telefono = telefono;
                usuario.Email = email;
                String json = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task EliminarUsuario(String username)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/usuarios/" + username;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }

        public async Task<List<Usuario>> GetAdministradoresConectados()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/usuarios/administradoresconnectados";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    List<Usuario> usuario = await response.Content.ReadAsAsync<List<Usuario>>();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Usuario> PerfilEmpleado(string token)
        {
            Usuario empleado = await
            this.CallApi<Usuario>("api/Usuarios/PerfilEmpleado", token);
            return empleado;
        }

        public async Task ModificarPerfilUsuario(String nombreusu, String contrasena, String nombre, String apellido, int edad, int telefono, String email)
        {

            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Usuarios";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Usuario usuario = new Usuario();
                usuario.NombreUsuario = nombreusu;
                usuario.Contrasena = contrasena;
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Edad = edad;
                usuario.Telefono = telefono;
                usuario.Email = email;
                String json = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        #endregion

        #region PACIENTE FISIO

        public async Task<List<ConsultaFisio>> GetConsultas()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/ConsultaFisio";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<ConsultaFisio> fisio = await response.Content.ReadAsAsync<List<ConsultaFisio>>();
                    return fisio;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ConsultaFisio> BuscarConsulta(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/ConsultaFisio/" + id;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    ConsultaFisio fisio = await response.Content.ReadAsAsync<ConsultaFisio>();
                    return fisio;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task CogerCitaFisio(int id, String nombre, String apellido, String fecha,/* DateTime hora,*/ int edad, String direccion, int telefono)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/ConsultaFisio";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                ConsultaFisio consulta = new ConsultaFisio();
                consulta.Id = id;
                consulta.Nombre = nombre;
                consulta.Apellido = apellido;
                consulta.Fecha = fecha;
                //consulta.Hora = hora;   
                consulta.Edad = edad;
                consulta.Direccion = direccion;
                consulta.Telefono = telefono;
                String json = JsonConvert.SerializeObject(consulta);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task ModificarCitaFisio(int id, String nombre, String apellido, String fecha, int edad, String direccion, int telefono)
        {

            using (HttpClient client = new HttpClient())
            {
                String request = "/api/ConsultaFisio";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                ConsultaFisio consulta = new ConsultaFisio();
                consulta.Id = id;
                consulta.Nombre = nombre;
                consulta.Apellido = apellido;
                consulta.Fecha = fecha;
                consulta.Edad = edad;
                consulta.Direccion = direccion;
                consulta.Telefono = telefono;
                String json = JsonConvert.SerializeObject(consulta);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }


        public async Task EliminarCitaFisio(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/ConsultaFisio/" + id;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }

        #endregion

        #region ENTRENAMIENTO PERSONAL

        public async Task<List<ConsultaEntrenamiento>> GetConsultasEntrenamiento()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/ConsultaEntrenamiento";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<ConsultaEntrenamiento> entrenamientos = await response.Content.ReadAsAsync<List<ConsultaEntrenamiento>>();
                    return entrenamientos;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ConsultaEntrenamiento> BuscarCitaEntrPersonal(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/ConsultaEntrenamiento/" + id;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    ConsultaEntrenamiento cons = await response.Content.ReadAsAsync<ConsultaEntrenamiento>();
                    return cons;
                }
                else
                {
                    return null;
                }
            }
        }


        public async Task CogerCitaEntrenamiento(int id, String nombre, String apellido, String fecha, /*DateTime hora*/ int edad, int telefono)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/ConsultaEntrenamiento";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                ConsultaEntrenamiento consulta = new ConsultaEntrenamiento();
                consulta.Id = id;
                consulta.Nombre = nombre;
                consulta.Apellido = apellido;
                consulta.Fecha = fecha;
                // consulta.Hora = hora;
                consulta.Edad = edad;
                consulta.Telefono = telefono;
                String json = JsonConvert.SerializeObject(consulta);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task ModificarConsultaEntrPersonal(int id, String nombre, String apellido, String fecha, int edad, int telefono)
        {

            using (HttpClient client = new HttpClient())
            {
                String request = "/api/ConsultaEntrenamiento";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                ConsultaEntrenamiento cons = new ConsultaEntrenamiento();
                cons.Id = id;
                cons.Nombre = nombre;
                cons.Apellido = apellido;
                cons.Fecha = fecha;
                cons.Edad = edad;
                cons.Telefono = telefono;
                String json = JsonConvert.SerializeObject(cons);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        public async Task EliminarConsultaEntrPersonal(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "/api/ConsultaEntrenamiento/" + id;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }
        #endregion

        #region LOGIN

        public async Task<String> GetToken(String usuario, String password) { 

            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);

                LogInModel login = new LogInModel();
                login.NombreUsuario = usuario;
                login.Contrasena = password;
                String json = JsonConvert.SerializeObject(login);

                StringContent content =
                    new StringContent(json
                    , System.Text.Encoding.UTF8, "application/json");
                String peticion = "api/Auth/Login";
                HttpResponseMessage response =
                    await client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido =
                        await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(contenido);
                    var TokenExpiracion = jObject.Value<DateTime>(".expires");
                    Settings.ObtenerExpirarToken = TokenExpiracion;
                    
                    return jObject.GetValue("response").ToString();

                    
                }
                else
                {
                    return null;
                }
            }
        }

        private async Task<T> CallApi<T>(String peticion, String token) { 
        
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.url);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(header);
                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer "
                        + token);
                }
                HttpResponseMessage response =
                    await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    T datos =
                        await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }

        #endregion

        #region COMENTARIOS

        public async Task Comentarios(String comentario, String nombreusuario)
        {

            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Usuarios/Comentarios?comentario=" + comentario+  "&id=" + nombreusuario;
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                var comment = new
                {
                    nombreusuario = nombreusuario,
                    comentario = comentario
                };

                String json = JsonConvert.SerializeObject(comment);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        

        #endregion
    }
}
