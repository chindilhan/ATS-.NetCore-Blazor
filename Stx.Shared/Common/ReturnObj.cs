using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Common
{
    public class ReturnObj
    {
        public ReturnObj()
        {

        }

        public ReturnObj(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public ReturnObj(bool isSuccess, string msgCode, string errMsg)
        {
            IsSuccess = isSuccess;
            ErrMsg = errMsg;
            MsgCode = msgCode;
        }

        public ReturnObj(bool isSuccess, string errMsg)
        {
            IsSuccess = isSuccess;
            MsgCode = "";
            ErrMsg = errMsg;
        }

        public ReturnObj(bool isSuccess, string msgCode, string errMsg, object retResult)
        {
            IsSuccess = isSuccess;
            ErrMsg = errMsg;
            MsgCode = msgCode;
            RetResult = retResult;
        }

        public bool IsSuccess { get; set;}
        public string MsgCode { get; set; } = "";
        public string ErrMsg { get; set; }
        public object RetResult { get; set; }
    }
}
