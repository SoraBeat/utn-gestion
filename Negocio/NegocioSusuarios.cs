using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Negocio
{
    public class NegocioSusuarios
    {

        DaoSusuarios dao_usu = new DaoSusuarios();
        public Susuarios verificarUseryPass(Susuarios user)
        {
            return dao_usu.verificarUseryPass(user);
        }

       public String obtenerIdUsuario(Susuarios usuario)
        {
            return dao_usu.obtenerIdUsuario(usuario);
        }

       
            public String EncriptarClave(string str)
            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
      

    }
}
