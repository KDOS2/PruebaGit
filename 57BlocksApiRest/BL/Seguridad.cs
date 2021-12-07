namespace _57BlocksApiRest.BL
{
    using _57BlocksApiRest.DBAcces;
    using _57BlocksApiRest.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Seguridad
    {
        public static bool _Autenticacion(LoginRequest user)
        {
            EntitySql param = new EntitySql();
            param.query = "select  count(1) from Users where email = '" + user.email + "';";
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            if (Convert.ToInt32(tabla.Rows[0][0].ToString()).Equals(0))
                return false;
            else
                return true;
        }
    }
}
