namespace lazurite.common {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    /// <param name="__that"></param>
    /// <returns></returns>
    public delegate bool unary_predicate<_T>(_T __that);


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T1"></typeparam>
    /// <typeparam name="_T2"></typeparam>
    /// <param name="__left"></param>
    /// <param name="__right"></param>
    /// <returns></returns>
    public delegate bool binary_predicate<_T1, _T2>(_T1 __left, _T2 __right);
}
