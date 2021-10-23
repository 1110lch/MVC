using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using PrjFinal.Models;

using System.Threading.Tasks;
namespace PrjFinal.Controllers
{
    public class HomeController : Controller
    {
        //constr連接字串指定連接資料庫
        string constr = @"Server=140.138.144.66\SQL1422;" +
                 "database=1092netdbB;" +
                 "uid=1092netdbB;" +
                 "pwd=yzuim1092netdbB";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            dbOrderEntities db = new dbOrderEntities();
            var result = from m in db.TableFinalExams1081703
                         orderby m.訂單號碼 descending
                         select m;
            return View(result);
        }
        //排序由最晚至最新之日期

        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowCity(string cityname)
        {
            dbOrderEntities db = new dbOrderEntities();
            var result = from m in db.TableFinalExams1081703
                         where m.送貨地址.Contains(cityname)
                         select m;
            return View(result);
        }
        //Linq查詢運算式寫法
        public ActionResult Index3(int EmpCode=1)
        {
            dbOrderEntities db = new dbOrderEntities();
            var reasult = db.TableFinalExams1081703
                   .Where(m => m.員工編號 == EmpCode).ToList();
            return View(reasult);
        }
        //執行Index3()動作會將所有所有員工編號跟選的EmpCode一樣的員工傳入index3.cshtml檢視頁面
        public ActionResult Edit(int OrderCodeEdit)
        {
            dbOrderEntities db = new dbOrderEntities();
            var reasult = (from m in db.TableFinalExams1081703
                           where m.訂單號碼 == OrderCodeEdit
                           select m).FirstOrDefault();
            return View(reasult);
        }
        //使用LINQ查詢運算式驗證URL傳入的OrderCodeEdit，再透過FirstOrDefault()方法取得符合的訂單號碼
        [HttpPost]
        public ActionResult Edit(TableFinalExams1081703 OrderCodeEdit2)
        {
            if (ModelState.IsValid)
            {
                dbOrderEntities db = new dbOrderEntities();
                var reasult = (from m in db.TableFinalExams1081703
                               where m.訂單號碼 == OrderCodeEdit2.訂單號碼
                               select m).FirstOrDefault();

                reasult.客戶編號 = OrderCodeEdit2.客戶編號;
                reasult.員工編號 = OrderCodeEdit2.員工編號;
                reasult.訂單日期 = OrderCodeEdit2.訂單日期;
                reasult.要貨日期 = OrderCodeEdit2.要貨日期;
                reasult.送貨日期 = OrderCodeEdit2.送貨日期;
                reasult.送貨方式 = OrderCodeEdit2.送貨方式;
                reasult.運費 = OrderCodeEdit2.運費;
                reasult.收貨人 = OrderCodeEdit2.收貨人;
                reasult.送貨地址 = OrderCodeEdit2.送貨地址;
                reasult.送貨城市 = OrderCodeEdit2.送貨城市;
                reasult.送貨行政區 = OrderCodeEdit2.送貨行政區;
                reasult.送貨郵遞區號 = OrderCodeEdit2.送貨郵遞區號;
                reasult.送貨國家地區 = OrderCodeEdit2.送貨國家地區;

                db.SaveChanges();

                return RedirectToAction("Index3");
            }
            return View(OrderCodeEdit2);
        }
        //由OrderCodeEdit參數數值找出欲修改的員工紀錄，接著將該員工紀錄顯示在Index3.cshtml檢視頁面上
        public ActionResult Delete(int OrderCode)
        {
            dbOrderEntities db = new dbOrderEntities();
            var reasult = (from m in db.TableFinalExams1081703
                          where m.訂單號碼 == OrderCode
                           select m).FirstOrDefault();
            db.TableFinalExams1081703.Remove(reasult);
            db.SaveChanges();
            return RedirectToAction("Index3");
        }
        //由OrderCode參數數值找出欲修改的員工紀錄並進行刪除，接著執行在Index3.cshtml檢視頁面
        public ActionResult index4()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QueryByID1(string OrderAddress)
        {
            dbOrderEntities db = new dbOrderEntities();
            var reasult = from m in db.TableFinalExams1081703
                   where m.送貨地址.Contains(OrderAddress)
                   select m;
            return View(reasult);
        }

        public ActionResult index5()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QueryByID(int OrderCode,string CusCode)
        {
            dbOrderEntities db = new dbOrderEntities();
            var reasult = (from m in db.TableFinalExams1081703
                           where m.訂單號碼 == OrderCode && m.客戶編號 == CusCode
                           select m).ToList();
            return View(reasult);
        }
    }
}