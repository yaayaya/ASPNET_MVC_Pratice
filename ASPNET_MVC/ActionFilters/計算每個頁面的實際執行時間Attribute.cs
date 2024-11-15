using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNET_MVC.ActionFilters
{
    public class 計算每個頁面的實際執行時間Attribute : ActionFilterAttribute
    {
        private readonly ILogger<計算每個頁面的實際執行時間Attribute> logger;

        public 計算每個頁面的實際執行時間Attribute(ILogger<計算每個頁面的實際執行時間Attribute> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 紀錄開始時間
            context.HttpContext.Items["StartTime"] = DateTime.Now;

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var startTime =  (DateTime)context.HttpContext.Items["StartTime"]!;

            var endTime = DateTime.Now;

            var duration = endTime - startTime;

            this.logger.LogInformation("執行時間：{duration}", duration);

            // 取得Controller 的 ViewBag
            var controller = context.Controller as Controller;
            controller!.ViewBag.Duration = duration;

            base.OnActionExecuted(context);
        }
    }
}
