using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ESDS_SYSTEM
{
    class Conection
    {
        //esta funcion publica sera la encargada de conectar la base con c#
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=LAPTOP-2GICQ9FS;DATABASE=ESDS;Uid=sa;Pwd=123456");//gracias a SqlConnection tenemos conexion con la base, colocamos el servidor, el nombre de la base, usuario y clave
            cn.Open();//abrimos la conexion
            return cn;//nos regresara la conexion abierta
        }
    }
}
