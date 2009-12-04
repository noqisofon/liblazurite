using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.mediators {


    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractMediator<_Colleague> : basics.IMediator<_Colleague> {
        /// <summary>
        /// 
        /// </summary>
        private List<_Colleague> contents_;


        /// <summary>
        /// 
        /// </summary>
        public AbstractMediator() {
            this.contents_ = new List<_Colleague>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        public AbstractMediator(_Colleague[] __colleagues) {
            this.contents_ = new List<_Colleague>( __colleagues );
        }


        /// <summary>
        /// 
        /// </summary>
        protected _Colleague[] contents {
            get {
                return contents_.ToArray();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleague"></param>
        public virtual void append(_Colleague __colleague) {
            this.contents_.Add(__colleague);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        public void appendAll(_Colleague[] __colleagues) {
            foreach ( _Colleague colleague in __colleagues ) {
                append( colleague );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        public virtual void remove(_Colleague __removed_colleague) {
            if ( this.contents_.Contains( __removed_colleague ) ) {
                this.contents_.Remove( __removed_colleague );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        public void removeAll(_Colleague[] __removed_colleagues) {
            foreach ( _Colleague colleague in __removed_colleagues ) {
                remove( colleague );
            }
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <returns></returns>
        public abstract bool send(_Colleague __message);
    }


    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractMediator<_Colleague, _Messagee> : basics.IMediator<_Colleague, _Messagee> {
        /// <summary>
        /// 
        /// </summary>
        private List<_Colleague> contents_;


        /// <summary>
        /// 
        /// </summary>
        public AbstractMediator() {
            this.contents_ = new List<_Colleague>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        public AbstractMediator(_Colleague[] __colleagues) {
            this.contents_ = new List<_Colleague>( __colleagues );
        }


        /// <summary>
        /// 
        /// </summary>
        protected _Colleague[] contents {
            get {
                return contents_.ToArray();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleague"></param>
        public void append(_Colleague __colleague) {
            this.contents_.Add( __colleague );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__colleagues"></param>
        public void appendAll(_Colleague[] __colleagues) {
            foreach ( _Colleague colleague in __colleagues ) {
                append( colleague );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        public void remove(_Colleague __removed_colleague) {
            if ( this.contents_.Contains( __removed_colleague ) ) {
                this.contents_.Remove( __removed_colleague );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_colleague"></param>
        public void removeAll(_Colleague[] __removed_colleagues) {
            foreach ( _Colleague colleague in __removed_colleagues ) {
                remove( colleague );
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <returns></returns>
        public abstract bool send(_Messagee __message);
    }

    
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Colleage"></typeparam>
    /// <typeparam name="_Messagee"></typeparam>
    public abstract class AbstractMediator<_Key, _Colleage, _Messagee> : basics.IMediator<_Key, _Colleage, _Messagee> {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<_Key, _Colleage> sheet_parts_book_;
        /// <summary>
        /// 
        /// </summary>
        private FormattingStrategy strategy_;


        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<_Key, _Colleage> sheet_parts_book {
            get {
                return sheet_parts_book_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected FormattingStrategy strategy {
            get {
                return strategy_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public AbstractMediator() {
            this.sheet_parts_book_ = new Dictionary<_Key, _Colleage>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__strategy"></param>
        public AbstractMediator(FormattingStrategy __strategy) {
            this.sheet_parts_book_ = new Dictionary<_Key, _Colleage>();
            this.strategy_ = __strategy;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        public AbstractMediator(Dictionary<_Key, _Colleage> __book) {
            this.sheet_parts_book_ = __book;
            this.strategy_ = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public AbstractMediator(AbstractMediator<_Key, _Colleage, _Messagee> __other) {
            this.sheet_parts_book_ = __other.sheet_parts_book_;
            this.strategy_ = __other.strategy_;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wc"></param>
        public void append(_Key __key, _Colleage __control) {
            this.sheet_parts_book_.Add( __key, __control );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eraced_key"></param>
        public void remove(_Key __eraced_key) {
            this.sheet_parts_book_.Remove( __eraced_key );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool send(_Messagee __message);



        /// <summary>
        /// 
        /// </summary>
        public abstract class FormattingStrategy {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="column"></param>
            /// <returns></returns>
            public abstract _Key format(_Messagee __message, object __cell);
        }
    }
}
