using System;


namespace lazurite.pattern.factories {


    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractFactory<_Target> {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract _Target create(string palam);
    }
}
