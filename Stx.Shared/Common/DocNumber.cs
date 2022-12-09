using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Common
{
    /// <summary>
    /// Used to get and keep the information of a corresponding Pos Order
    /// Format: RecId, DocId, DocTransNum, DocStatus, IsExported, PageUId, TerminalID
    /// </summary>
    public class DocNumber
    {
        int _recId;
        string _docNum;
        int _runningNum;
        int _docStatus;
        bool _isExported;
        short? _pageUid;
        string _terminalID;

        public DocNumber()
        {
            this._recId = 0;
            this._docNum = "0";
            this._runningNum = 0;
            this._docStatus = 0;
            this._isExported = false;
            this._pageUid = null;
            this._terminalID = null;
        }

        public DocNumber(int recId, string docId, int docRunningNum, int docStatus)
        {
            this._recId = recId;
            this._docNum = docId;
            this._runningNum = docRunningNum;
            this._docStatus = docStatus;
            this._isExported = false;
            this._pageUid = null;
            this._terminalID = null;
        }

        public DocNumber(int recId, string docId, int docRunningNum, int docStatus, bool isExported, short pageUid, string terminalID)
        {
            this._recId = recId;
            this._docNum = docId;
            this._runningNum = docRunningNum;
            this._docStatus = docStatus;
            this._isExported = isExported;
            this._pageUid = pageUid;
            this._terminalID = terminalID;
        }

        public int RecID { get { return _recId; } }
        public string DocNum { get { return _docNum; } }
        public int RunningNum { get { return _runningNum; } }
        public int DocStatus { get { return _docStatus; } }
        public bool IsExported { get { return _isExported; } }
        public short? PageUId { get { return _pageUid; } }
        public string TerminalID { get { return _terminalID; } }
    };
}