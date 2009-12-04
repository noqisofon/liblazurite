namespace lazurite.pattern.basics {


    /// <summary>
    /// 
    /// </summary>
    public interface IVisitor {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__article"></param>
        /// <returns></returns>
        bool visit(Visitable __article);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public interface IVisitor<_Target> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__target"></param>
        bool visit(_Target __target);
    }
}