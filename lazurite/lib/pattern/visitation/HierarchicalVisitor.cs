namespace lazurite.pattern.visitation {
    
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class HierarchicalVisitor<_Target, _TargetComposite> : basics.IVisitor<_Target> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public abstract bool visitEnter(_TargetComposite composite);
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public abstract bool visit(_Target tree);
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public abstract bool visitLeave(_TargetComposite composite);
    }
}