namespace lazurite.pattern.basics {
    /// <summary>
    /// 
    /// </summary>
    public interface IComposite : Compositable {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adden_component"></param>
        /// <returns></returns>
        bool addComponent(Compositable adden_component);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="removed_component"></param>
        /// <returns></returns>
        bool removeComponent(Compositable removed_component);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Compositable[] getChild();
    }
}
