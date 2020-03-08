using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CMS.Web
{
    public class BaseController: Controller
    {
        //重写控制器的Json方法
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new FormatJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
        }
    }

    /// <summary>
    /// 通过从 System.Web.Mvc.JsonResult 类继承的自定义类型，用于将 JSON 格式的内容发送到响应
    /// 格式化日期，默认格式："yyyy-MM-dd HH:mm:ss" 例如：2017-10-11 18：00：00
    /// </summary>
    public class FormatJsonResult : JsonResult
    {
        /// <summary>
        /// 时间格式说明
        /// </summary>
        public string DateTimeFormat { get; set; }

        public FormatJsonResult() { }

        public FormatJsonResult(string dateFormatString)
        {
            DateTimeFormat = dateFormatString;
        }

        /// <summary>
        /// 通过从 JsonResult 类继承的自定义类型，启用对操作方法结果的处理
        /// </summary>
        /// <param name="context">执行结果时所处的上下文</param>
        /// <exception cref="ArgumentNullException">context 参数为 null</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JsonRequest_GetNotAllowed");
            }
            HttpResponseBase response = context.HttpContext.Response;
            // 设置内容的类型
            if (!string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            // 设置内容编码
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            // 设置数据
            if (Data != null)
            {
                if (string.IsNullOrEmpty(DateTimeFormat))
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                }
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.DateFormatString = DateTimeFormat;
                // 根据设置序列化数据
                response.Write(JsonConvert.SerializeObject(Data, settings));
            }
        }
    }
}