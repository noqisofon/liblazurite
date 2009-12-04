using System;
using System.Data;


namespace lazurite.common {


    /// <summary>
    /// 
    /// </summary>
    public interface ITableStorage {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__sql_query"></param>
        /// <returns></returns>
        DataTable fetch(string __table_name, string __sql_query);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        int indexOf(string __name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        bool contains(string __name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_name"></param>
        void remove(string __removed_name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__index"></param>
        /// <returns></returns>
        DataTable this[int __index] { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        DataTable this[string __name] { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <param name="__invoker"></param>
        void invoke_table(TableInvoker __invoker);
    }
}