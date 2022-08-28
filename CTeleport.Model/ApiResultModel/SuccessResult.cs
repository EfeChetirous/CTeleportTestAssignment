using CTeleport.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.Model.ApiResultModel
{
    public class SuccessResult : Result
    {
        public SuccessResult(object Root, string Message) : base(true, Root, Message, ResultCodeEnum.Success)
        {
        }
    }
}
