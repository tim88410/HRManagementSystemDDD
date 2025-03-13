using DBUtility;
using HRManagementSystemDDD.Application.Commands.Leaves;
using HRManagementSystemDDD.Application.Queries.Leaves;
using HRManagementSystemDDD.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystemDDD.Controllers
{
    [ApiResult]
    [APIError]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly IMediator mediator;
        public LeavesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// 依據Filter對Leave進行查詢，取得List資料
        /// </summary>
        /// <remarks>
        /// <code>
        /// <br/>
        /// 透過 ReturnCode 判斷狀態:<br/>
        /// ParamError(2) 查詢參數錯誤<br/>
        /// DBConnectError(3) 查詢入DB時連線失敗<br/>
        /// OperationSuccessful(5) 查詢成功<br/>
        /// DataNotFound(6) API呼叫成功，但沒有任何資料回傳<br/>
        /// </code>
        /// </remarks>
        
        [ApiResult]
        [APIError]
        [HttpGet]
        [Route("v1/Leaves")]
        public async Task<IActionResult> Get([FromQuery] LeavesRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new APIError.ParamError();
            }
            var result = await mediator.Send(request);

            if (result == null)
            {
                throw new APIError.DBConnectError();
            }
            else if (result.Total == 0)
            {
                throw new APIError.DataNotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// 傳入Leave 主Key [Id]進行查詢，取得單一資料，通常用於單一筆資料編輯時，Load的情況
        /// </summary>
        /// <remarks>
        /// <code>
        /// <br/>
        /// 透過 ReturnCode 判斷狀態:<br/>
        /// ParamError(2) 查詢參數錯誤<br/>
        /// DBConnectError(3) 查詢入DB時連線失敗<br/>
        /// OperationSuccessful(5) 查詢成功<br/>
        /// DataNotFound(6) API呼叫成功，但沒有任何資料回傳<br/>
        /// </code>
        /// </remarks>
        [ApiResult]
        [APIError]
        [HttpGet]
        [Route("v1/Leaves/{Id}")]
        public async Task<IActionResult> GetOne(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new APIError.ParamError();
            }
            var result = await mediator.Send(new LeavesGetOneRequest { Id = Id });

            if (result == null)
            {
                throw new APIError.DBConnectError();
            }
            else if (!result.Any())
            {
                throw new APIError.DataNotFound();
            }
            return Ok(result.FirstOrDefault());
        }


    }
}
