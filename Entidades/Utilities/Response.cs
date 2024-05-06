using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilities
{
    public abstract class Response<T> where T : Models
    {
        public string msg { get; set; } = "";

        public bool success { get; set; } = false;

        public T data { get; set; } = default;


    }

    public class ResponseBuilder<T> : Response<T> where T : Models
    {
        public ResponseBuilder() { }

        public ResponseBuilder(string msg, bool success, T data)
        {
            this.msg = msg;
            this.success = success;
            this.data = data;
        }

        public ResponseBuilder<T> withMsg(string msg)
        {
            this.msg = msg;
            return this;
        }

        public ResponseBuilder<T> withData(T data)
        {
            this.data = data;
            return this;
        }

        public ResponseBuilder<T> withSuccess(bool success)
        {
            this.success = success;
            return this;
        }

        public static Response<T> Success()
        {
            return new ResponseBuilder<T>().withSuccess(true);
        }
        public static Response<T> Success(string msg)
        {
            return new ResponseBuilder<T>()
                .withSuccess(true)
                .withMsg(msg);
        }
        public static Response<T> Fail(string msg)
        {
            return new ResponseBuilder<T>()
                .withSuccess(false)
                .withMsg(msg);
        }
        public static Response<T> Error(Exception exception)
        {
            return new ResponseBuilder<T>()
                .withSuccess(false)
                .withMsg(exception.Message);
        }
    }
}
