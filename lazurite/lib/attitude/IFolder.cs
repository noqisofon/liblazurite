namespace lazurite.attitude {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Tree"></typeparam>
    public interface IFolder<_Tree> {
        /// <summary>
        /// 
        /// </summary>
        _Tree nextNode { get; }
        
        
        /// <summary>
        /// 
        /// </summary>
        _Tree prevNode { get; }

        
        /// <summary>
        /// 
        /// </summary>
        _Tree firstNode { get; }
        
        
        /// <summary>
        /// 
        /// </summary>
        _Tree lastNode { get; }
        
        
        /// <summary>
        /// 
        /// </summary>
        _Tree[] nodes { get; }
        
        
        /// <summary>
        /// 
        /// </summary>
        bool is_nodeEmpty { get; }
        
        
        /// <summary>
        /// 
        /// </summary>
        int entries { get; }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__child"></param>
        void append(_Tree __child);
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__childs"></param>
        void appendAll(_Tree[] __childs);

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__erased_child"></param>
        /// <returns></returns>
        int erase(_Tree __erased_child);
        
        
        /// <summary>
        /// 
        /// </summary>
        void clear();
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__other"></param>
        /// <returns></returns>
        int indexOf(_Tree __other);
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__other"></param>
        /// <returns></returns>
        int lastIndexOf(_Tree __other);
    }
}