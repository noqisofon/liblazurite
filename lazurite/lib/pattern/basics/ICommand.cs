namespace lazurite.pattern.basics {


    /// <summary>
    /// 
    /// </summary>
    public interface tag_Command {
    }


    /// <summary>
    /// 
    /// </summary>
    public interface ICommand : tag_Command {
        /// <summary>
        /// 
        /// </summary>
        void execute();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_R"></typeparam>
    public interface ICommand<_R> : tag_Command {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        _R execute();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_R"></typeparam>
    /// <typeparam name="_Type1"></typeparam>
    public interface ICommand<_R, _Type1> : tag_Command {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_1"></param>
        /// <returns></returns>
        _R execute(_Type1 _1);
    }
}