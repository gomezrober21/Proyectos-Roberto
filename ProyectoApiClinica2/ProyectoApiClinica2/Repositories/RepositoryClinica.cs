using ProyectoApiClinica2.Data;
using ProyectoApiClinica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApiClinica2.Repositories
{
    public class RepositoryClinica
    {
        ContextoClinica context;

        public RepositoryClinica(ContextoClinica context)
        {
            this.context = context;
        }

        #region USUARIO

        public Usuario ExisteUsuario(String username, String password)
        {
            return context.Usuarios.SingleOrDefault(z => z.NombreUsuario == username && z.Contrasena == password);
        }

        public List<Usuario> GetUsuarios()
        {
            var consulta = from datos in context.Usuarios select datos;
            return consulta.ToList();
        }
        public Usuario BuscarUsuario(String nombreusu)
        {
            var consulta = context.Usuarios.SingleOrDefault(z => z.NombreUsuario == nombreusu);
            return consulta;
        }

        public void Registrarse(String nombreusu, String nombre, String contrasena, String apellido, int edad, int telefono, String email)
        {
            Usuario usu = new Usuario();
            usu.NombreUsuario = nombreusu;
            usu.Contrasena = contrasena;
            usu.Nombre = nombre;
            usu.Apellido = apellido;
            usu.Edad = edad;
            usu.Telefono = telefono;
            usu.Email = email;
            usu.Rol = "cliente";
            this.context.Usuarios.Add(usu);
            this.context.SaveChanges();
        }

        public void EliminarUsuario(String nombreusu)
        {
            Usuario usu = this.BuscarUsuario(nombreusu);
            this.context.Usuarios.Remove(usu);
            this.context.SaveChanges();
        }

        public void ModificarUsuario(String nombreusu, String nombre, String contrasena, String apellido, int edad, int telefono, String email)
        {
            Usuario usu = this.BuscarUsuario(nombreusu);
            usu.NombreUsuario = nombreusu;
            usu.Contrasena = contrasena;
            usu.Nombre = nombre;
            usu.Apellido = apellido;
            usu.Edad = edad;
            usu.Telefono = telefono;
            usu.Email = email;
            this.context.SaveChanges();
        }



        #endregion

        #region CONSULTA FISIOTERAPIA

        public List<ConsultaFisio> GetConsultaFisio()
        {
            var consulta = from datos in context.ConsultaFisioterapia select datos;
            return consulta.ToList();
        }

        public ConsultaFisio BuscarConsultaFisio(int id)
        {
            var consulta = this.context.ConsultaFisioterapia.SingleOrDefault(z => z.Id == id);
            return consulta;
        }

        public void CogerCitaFisio(int id, String nombre, String apellido, String fecha /*DateTime hora*/, int edad, String direccion, int telefono)
        {
            ConsultaFisio consulta = new ConsultaFisio();
            consulta.Id = id;
            consulta.Nombre = nombre;
            consulta.Apellido = apellido;
            consulta.Fecha = fecha;
            //consulta.Hora = hora;
            consulta.Edad = edad;
            consulta.Direccion = direccion;
            consulta.telefono = telefono;

            context.ConsultaFisioterapia.Add(consulta);
            context.SaveChanges();
        }

        public void EliminarConsultaFisio(int id)
        {
            ConsultaFisio consulta = this.BuscarConsultaFisio(id);
            this.context.ConsultaFisioterapia.Remove(consulta);
            this.context.SaveChanges();
        }

        public void ModificarCitaFisio(int id, String nombre, String apellido, String fecha, int edad, String direccion, int telefono)
        {
            ConsultaFisio consulta = this.BuscarConsultaFisio(id);
            consulta.Id = id;
            consulta.Nombre = nombre;
            consulta.Apellido = apellido;
            consulta.Fecha = fecha;
            consulta.Edad = edad;
            consulta.Direccion = direccion;
            consulta.telefono = telefono;
            this.context.SaveChanges();
        }



        #endregion

        #region CLIENTE ENTR PERSONAL

        public List<ConsultaEntrenamiento> GetConsultaEntrenamientos()
        {
            var consulta = from datos in context.ConsultaEntrenamientos select datos;
            return consulta.ToList();
        }

        public ConsultaEntrenamiento BuscarConsultaEntrenamiento(int id)
        {
            return this.context.ConsultaEntrenamientos.SingleOrDefault(z => z.Id == id);
        }

        public void CogerCitaEntrenamiento(int id, String nombre, String apellido, String fecha, /*DateTime hora*/ int edad, int telefono)
        {
            ConsultaEntrenamiento consulta = new ConsultaEntrenamiento();
            consulta.Id = id;
            consulta.Nombre = nombre;
            consulta.Apellido = apellido;
            consulta.Fecha = fecha;
           // consulta.Hora = hora;
            consulta.Edad = edad;
            consulta.Telefono = telefono;
            context.ConsultaEntrenamientos.Add(consulta);
            context.SaveChanges();
        }
       
        public void EliminarConsultaEntrenamiento(int id)
        {
            ConsultaEntrenamiento consulta = this.BuscarConsultaEntrenamiento(id);
            this.context.ConsultaEntrenamientos.Remove(consulta);
            this.context.SaveChanges();

        }

        public void ModificarCitaEntrPersonal(int id, String nombre, String apellido, String fecha, int edad, int telefono)
        {
            ConsultaEntrenamiento consulta = this.BuscarConsultaEntrenamiento(id);
            consulta.Id = id;
            consulta.Nombre = nombre;
            consulta.Apellido = apellido;
            consulta.Fecha = fecha;
            consulta.Edad = edad;
            consulta.Telefono = telefono;
            this.context.SaveChanges();
        }

        #endregion

        #region COMENTARIOS

        public void Comentarios(String comentario, String nombreusuario)
        {
            Usuario usercomment = this.BuscarUsuario(nombreusuario);
            usercomment.Comentarios = comentario;
            this.context.SaveChanges();
        }

        #endregion
    }
}
