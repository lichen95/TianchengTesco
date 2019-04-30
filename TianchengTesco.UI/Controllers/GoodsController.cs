using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TianchengTesco.UI.Controllers
{
    public class GoodsController : Controller
    {
        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Load()
        {
            HttpPostedFileBase img = Request.Files["file"];
            if (img!=null)
            {
                var getPath = Server.MapPath("~"+Path.DirectorySeparatorChar+ "img" + Path.DirectorySeparatorChar + "");
                if (!Directory.Exists(getPath))
                    Directory.CreateDirectory(getPath);
                var fileName =DateTime.Now.ToString("yyyyMMddHHmmss")+ img.FileName;
                var newPath = Path.Combine(getPath,fileName);
                img.SaveAs(newPath);
                return "上传成功#"+ Path.DirectorySeparatorChar + "img" + Path.DirectorySeparatorChar + fileName;
            }
            return "请选择要上传的图片";
        }
    }
}
