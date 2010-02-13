using System;
using System.Collections.Generic;
using System.Text;

namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class Level {
        /// <summary>
        /// 
        /// </summary>
        private string name_;
        /// <summary>
        /// 
        /// </summary>
        private int level_value_;


        /// <summary>
        /// 
        /// </summary>
        public string name {
            get {
                return name_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string localizedName {
            get {
                string result_level_text = string.Empty;
                switch ( this.level_value_ ) {
                    case (int)FiltteringLevel.FINE:
                        result_level_text = "è⁄ç◊èÓïÒ(è¨)";
                        break;

                    case (int)FiltteringLevel.FINER:
                        result_level_text = "è⁄ç◊èÓïÒ(íÜ)";
                        break;

                    case (int)FiltteringLevel.FINEST:
                        result_level_text = "è⁄ç◊èÓïÒ(ëÂ)";
                        break;

                    case (int)FiltteringLevel.INFO:
                        result_level_text = "èÓïÒ";
                        break;

                    case (int)FiltteringLevel.WARNING:
                        result_level_text = "åxçê";
                        break;

                    case (int)FiltteringLevel.SEVERE:
                        result_level_text = "ívñΩìI";
                        break;
                }
                return result_level_text;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static Level ALL = new Level( "ALL", (int)FiltteringLevel.ALL );
        /// <summary>
        /// 
        /// </summary>
        public static Level FINEST = new Level( "FINEST", (int)FiltteringLevel.FINEST );

        /// <summary>
        /// 
        /// </summary>
        public static Level FINER = new Level( "FINER", (int)FiltteringLevel.FINER );
        /// <summary>
        /// 
        /// </summary>
        public static Level FINE = new Level( "FINE", (int)FiltteringLevel.FINE );
        /// <summary>
        /// 
        /// </summary>
        public static Level CONFIG = new Level( "CONFIG", (int)FiltteringLevel.CONFIG );
        /// <summary>
        /// 
        /// </summary>
        public static Level INFO = new Level( "INFO", (int)FiltteringLevel.INFO );
        /// <summary>
        /// 
        /// </summary>
        public static Level WARNING = new Level( "WARNING", (int)FiltteringLevel.WARNING );
        /// <summary>
        /// 
        /// </summary>
        public static Level SEVERE = new Level( "SEVERE", (int)FiltteringLevel.SEVERE );
        /// <summary>
        /// 
        /// </summary>
        public static Level OFF = new Level( "OFF", (int)FiltteringLevel.OFF );


        /// <summary>
        /// 
        /// </summary>
        private Level(string __name, int __value) {
            this.name_ = __name;
            this.level_value_ = __value;
        }


        /// <summary>
        /// 
        /// </summary>
        public int intValue() {
            return level_value_;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__filltering_level"></param>
        /// <returns></returns>
        public static Level valueOf(FiltteringLevel __filltering_level) {
            Level result = null;

            switch ( __filltering_level ) {
                case FiltteringLevel.ALL:
                    result = ALL;
                    break;
                
                case FiltteringLevel.FINEST:
                    result = FINEST;
                    break;

                case FiltteringLevel.FINER:
                    result = FINER;
                    break;
                
                case FiltteringLevel.FINE:
                    result = FINE;
                    break;
                
                case FiltteringLevel.CONFIG:
                    result = CONFIG;
                    break;
                
                case FiltteringLevel.INFO:
                    result = INFO;
                    break;
                
                case FiltteringLevel.WARNING:
                    result = WARNING;
                    break;
                
                case FiltteringLevel.SEVERE:
                    result = SEVERE;
                    break;
                
                case FiltteringLevel.OFF:
                    result = OFF;
                    break;
            }
            return result;
        }
    }
}
