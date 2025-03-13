﻿using DBUtility;

namespace HRManagementSystemDDD.Common
{
    public class ApiResult
    {
        public class Result
        {
            public ErrorCode.ReturnCode ReturnCode { get; set; }
            public object? ReturnData { get; set; } = null;
        }
    }
}
