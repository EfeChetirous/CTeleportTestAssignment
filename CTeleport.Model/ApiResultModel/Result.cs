using CTeleport.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.Model.ApiResultModel
{
    public abstract class Result
    {
        public bool Success { get; private set; }
        public object Root { get; private set; }
        public string Message { get; private set; }
        public ResultCodeEnum ResultCodeEnum { get; private set; }

        public Result()
        {
            Success = false;
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        protected Result(bool success, object root, string message, ResultCodeEnum resultCodeEnum)
        {
            this.Success = success;
            this.Root = root;
            this.Message = message;
            this.ResultCodeEnum = resultCodeEnum;
        }
    }
}
