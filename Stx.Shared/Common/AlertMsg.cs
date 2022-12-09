using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Shared.Common
{
    public class AlertMsg
    {
        public AlertMsg()
        {

        }

        public AlertMsg(string alertText, MsgType msgType = MsgType.None, MsgRole dispMode = MsgRole.Alert)
        {
            IsActiveMsg = true;
            Message = alertText;
            MsgType = msgType;
            MsgRole = dispMode;
        }

        public void Reset ()
		{
            IsActiveMsg = false;
            Message = string.Empty;
            MsgType = MsgType.None;
            MsgRole = MsgRole.Alert;
        }

        public void SetMessage(string message, MsgType msgType = MsgType.Error, MsgRole msgRole = MsgRole.Alert)
        {
            IsActiveMsg = true;
            Message = message;
            MsgType = msgType;
            MsgRole = msgRole;
        }
        public void SetError(string message, MsgRole msgRole = MsgRole.Alert)
        {
            IsActiveMsg = true;
            Message = message;
            MsgType = MsgType.Error;
            MsgRole = msgRole;
        }
        public void SetSuccess(string message, MsgRole msgRole = MsgRole.Alert)
        {
            IsActiveMsg = true;
            Message = message;
            MsgType = MsgType.Success;
            MsgRole = msgRole;
        }


        public bool IsActiveMsg { get; set; } = false;
        public MsgType MsgType { get; set; } = 0;
        public MsgRole MsgRole { get; set; } = 0;
        public string Message { get; set; } = "";

        /*
         * MsgType:  
                0 = primary
                1 = secondary
                2 = success
                3 = danger
                4 = warning
                5 = info
                6 = light
                7 = dark

            MsgRole:
                none = 0,
                Alert = 1, //alert
                Toast = 2, //(10/20 sec) 
                FixedAlert = 3,
                AlertDialog = 4 //alertdialog
        */
    }

    public enum MsgType:byte
    {

        None = 0,
        Success = 1,
        Info = 2,
        Warning = 3,
        Error = 4, //danger

        //Light = 6,
        //Dark = 7
    }

    public enum MsgRole : byte
    {
        none = 0,
        Alert = 1, //alert
        Toast = 2, //(10/20 sec) 
        FixedAlert = 3,
        AlertDialog = 4 //alertdialog
    }
}
