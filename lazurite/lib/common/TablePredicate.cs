using System;
using System.Data;


namespace lazurite.common {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="__table"></param>
    public delegate void TableInvoker(DataTable __table);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="__row"></param>
    public delegate void EveryLiner(DataRow __row);
}
