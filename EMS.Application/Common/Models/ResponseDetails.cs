using EMS.Application.Common.Models.Enum;
using System.Collections;

namespace EMS.Application.Common.Models
{
    public class ResponseDetail
    {
        #region Public Constructors

        public ResponseDetail()
        {
            MessageType = MessageType.None;
            DateTime = DateTime.Now;
            Success = false;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public MessageType MessageType { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        #endregion Public Properties
    }

    public class ResponseDetail<T> : ResponseDetail
    {
        #region Public Constructors

        public ResponseDetail()
        {
            MessageType = MessageType.None;
            DateTime = DateTime.Now;
            Success = false;
            Data = default(T)!;
        }

        public ResponseDetail(ResponseDetail r)
        {
            Count = r.Count;
            Exception = r.Exception;
            Success = r.Success;
            MessageType = r.MessageType;
            Data = default(T)!;
        }

        public ResponseDetail(ResponseDetail r, T data) : this(r)
        {
            Data = data;
        }

        #endregion Public Constructors

        #region Public Properties

        public T Data { get; set; }

        #endregion Public Properties

        #region Private Methods

        private int GetCount(T data)
        {
            var count = 1;
            var list = data as IList;
            if (list != null)
            {
                count = list.Count;
            }
            return count;
        }

        #endregion Private Methods

        #region Public Methods

        public ResponseDetail<TU> To<TU>()
        {
            var result = new ResponseDetail<TU>
            {
                Data = (TU)Convert.ChangeType(Data, typeof(TU))
            };

            return result;
        }

        /// <summary>
        /// Takes one param <see cref="string"/> <paramref name="message"/>
        ///  and returns error message with <see cref="MessageType.Invalid"/>
        /// </summary>
        /// <param name="message">error message</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Invalid"/> </returns>
        public ResponseDetail<T> InvalidResponse(string message)
        {
            Count = 0;
            Message = message;
            Exception = null!;
            Success = false;
            MessageType = MessageType.Invalid;
            return this;
        }

        /// <summary>
        /// Takes one param <see cref="Exception"/> <paramref name="exception"/>
        ///  and returns error message with <see cref="MessageType.Invalid"/>
        /// </summary>
        /// <param name="exception">exception</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Invalid"/> </returns>
        public ResponseDetail<T> InvalidResponse(Exception exception)
        {
            Count = 0;
            Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            Exception = exception;
            Success = false;
            MessageType = MessageType.Invalid;
            return this;
        }

        /// <summary>
        /// Takes two params <see cref="string"/> <paramref name="message"/> and <see cref="Exception"/> <paramref name="exception"/>
        /// and returns error message with <see cref="MessageType.Invalid"/>
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="exception">exception</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Invalid"/> </returns>
        public ResponseDetail<T> InvalidResponse(string message, Exception exception)
        {
            Count = 0;
            Message = message + " -- " + exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            Exception = exception;
            Success = false;
            MessageType = MessageType.Invalid;
            return this;
        }

        /// <summary>
        /// Takes one param <see cref="string"/> <paramref name="message"/>
        ///  and returns error message with <see cref="MessageType.Error"/>
        /// </summary>
        /// <param name="message">error message</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Error"/> </returns>
        public ResponseDetail<T> ErrorResponse(string message)
        {
            Count = 0;
            Message = message;
            Exception = null!;
            Success = false;
            MessageType = MessageType.Error;
            return this;
        }

        /// <summary>
        /// Takes one param <see cref="Exception"/> <paramref name="exception"/>
        ///  and returns error message with <see cref="MessageType.Error"/>
        /// </summary>
        /// <param name="exception">exception</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Error"/> </returns>
        public ResponseDetail<T> ErrorResponse(Exception exception)
        {
            Count = 0;
            Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            Exception = exception;
            Success = false;
            MessageType = MessageType.Error;
            return this;
        }

        /// <summary>
        /// Takes two params <see cref="string"/> <paramref name="message"/> and <see cref="Exception"/> <paramref name="exception"/>
        /// and returns error message with <see cref="MessageType.Error"/>
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="exception">exception</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Error"/> </returns>
        public ResponseDetail<T> ErrorResponse(string message, Exception exception)
        {
            Count = 0;
            Message = message + " -- " + exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            Exception = exception;
            Success = false;
            MessageType = MessageType.Error;
            return this;
        }

        /// <summary>
        /// Takes <see cref="T"/> <paramref name="data"/> process with <see cref="MessageType.Success"/> code and <see cref="Data"/>
        /// </summary>
        /// <param name="data">Data to return</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Success"/> and data <see cref="T"/> </returns>
        public ResponseDetail<T> SuccessResponse(T data)
        {
            Data = data;
            Count = GetCount(data);
            Message = "Data Found Successfully!";
            Exception = null!;
            Success = true;
            MessageType = MessageType.Success;
            return this;
        }

        /// <summary>
        /// Takes <see cref="T"/> <paramref name="data"/> process with <see cref="MessageType.Success"/> code , <see cref="Data"/> and Provided <see cref="string"/> <paramref name="data"/>
        /// </summary>
        /// <param name="data">Data to return</param>
        /// <param name="message">Message to return</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Success"/> and data <see cref="T"/> </returns>
        public ResponseDetail<T> SuccessResponse(T data, string message)
        {
            Data = data;
            Count = GetCount(data);
            Message = message;
            Exception = null!;
            Success = true;
            MessageType = MessageType.Success;
            return this;
        }

        /// <summary>
        /// Takes <see cref="T"/> <paramref name="data"/> process with <see cref="MessageType.Success"/> code , <see cref="Data"/> and Provided <see cref="int"/> <paramref name="count"/>
        /// </summary>
        /// <param name="data">Data to return</param>
        /// <param name="count">Count to return</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Success"/> and data <see cref="T"/> </returns>
        public ResponseDetail<T> SuccessResponse(T data, int count)
        {
            Data = data;
            Count = count;
            Message = "Data Found Successfully!";
            Exception = null!;
            Success = true;
            MessageType = MessageType.Success;
            return this;
        }

        /// <summary>
        /// Takes <see cref="T"/> <paramref name="data"/> process with <see cref="MessageType.Success"/> code , <see cref="Data"/> , Provided <see cref="int"/> <paramref name="count"/> and provided <see cref="string"/> <paramref name="message"/>
        /// </summary>
        /// <param name="data">Data to return</param>
        /// <param name="count">Count to return</param>
        /// <param name="message">Message to return</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Success"/> and data <see cref="T"/> </returns>
        public ResponseDetail<T> SuccessResponse(T data, int count, string message)
        {
            Data = data;
            Count = count;
            Message = message;
            Exception = null!;
            Success = true;
            MessageType = MessageType.Success;
            return this;
        }

        /// <summary>
        /// Takes <see cref="T"/> <paramref name="data"/> process with <see cref="MessageType.Info"/> code , <see cref="Data"/> , Provided <see cref="int"/> <paramref name="count"/> , provided <see cref="string"/> <paramref name="message"/> and  provided <see cref="bool"/> <paramref name="success"/>
        /// </summary>
        /// <param name="data">Data to return</param>
        /// <param name="count">Count to return</param>
        /// <param name="message">Message to return</param>
        /// <param name="success">Message to return</param>
        /// <returns>Instance of existing response with <see cref="MessageType.Info"/> and data <see cref="T"/> </returns>
        public ResponseDetail<T> InfoResponse(T data, int count, string message, bool success)
        {
            Data = data;
            Count = count;
            Message = message;
            Exception = null!;
            Success = success;
            MessageType = MessageType.Info;
            return this;
        }


        #endregion Public Methods

    }
}
