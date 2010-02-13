using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// ログレベルが提供する制御以上にログ対象をきめ細かく制御する為に使用されます。
    /// </summary>
    public interface Filter {
        /// <summary>
        /// 指定されたログレコードが通知されるかどうかを調べます。
        /// </summary>
        bool isLoggable(LogRecord __record);
    }
}
