using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ESDS_SYSTEM
{
    class datos
    {
        public string servidor, usuario, clave, db;//variables que seran los parametros de la coneccion
        public string cadena;//esta variable tendra toda la coneccion
        public void conec()//procedimiento para la coneccion
        {
            servidor = "LAPTOP-2GICQ9FS";//nombre del servidor para sql server
            db = "ESDS";//nombre de la base
            usuario = "sa";//usuario de sql server
            clave = "123456";//clave de sql server
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;//esta es la ruta de coneccion sql a c#
        }
    }
}
