namespace CROM.Data.SqlServer
{
    using System;
    using System.Linq;


    public enum ObjectType
    {
        EscalarFunction = 1,
        View = 2,
        UserTable = 3,
        StoredProcedure = 4
    }
}