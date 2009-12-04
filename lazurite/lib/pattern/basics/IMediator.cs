namespace lazurite.pattern.basics {


    /// <summary>
    /// Mediator のタグインターフェイスです。
    /// </summary>
    public interface tag_Mediator { }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Colleague"></typeparam>
    /// <typeparam name="_Messagee"></typeparam>
    public interface IMediator<_Colleague> : tag_Mediator {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleague"></param>
        void append(_Colleague __colleague);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        void appendAll(_Colleague[] __colleagues);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        void remove(_Colleague __removed_colleague);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        void removeAll(_Colleague[] __removed_colleague);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <returns></returns>
        bool send(_Colleague __message);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Colleague"></typeparam>
    /// <typeparam name="_Messagee"></typeparam>
    public interface IMediator<_Colleague, _Messagee> : tag_Mediator {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleague"></param>
        void append(_Colleague __colleague);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        void appendAll(_Colleague[] __colleagues);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        void remove(_Colleague __removed_colleague);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        void removeAll(_Colleague[] __removed_colleague);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <returns></returns>
        bool send(_Messagee __message);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Key"></typeparam>
    /// <typeparam name="_Colleague"></typeparam>
    /// <typeparam name="_Messagee"></typeparam>
    public interface IMediator<_Key, _Colleague, _Messagee> : tag_Mediator {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__key"></param>
        /// <param name="__colleague"></param>
        void append(_Key __key, _Colleague __colleague);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__eraced_key"></param>
        void remove(_Key __eraced_key);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <returns></returns>
        bool send(_Messagee __message);
    }
}
