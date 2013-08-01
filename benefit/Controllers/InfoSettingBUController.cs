using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using benefit.Models;
using OfficeOpenXml;
using System.Web.UI.WebControls;

namespace benefit.Controllers
{
    public class InfoSettingBUController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /InfoSettingBU/

        public ActionResult Index()
        {
            //var infosettingbus = db.InfoSettingBUs.Include(i => i.CaraBayar).Include(i => i.PolisPegawai);
            //return View(infosettingbus.ToList());
            return RedirectToAction("Create");
        }

        //
        // GET: /InfoSettingBU/Details/5

        public ActionResult Details(int id = 0)
        {
            InfoSettingBU infosettingbu = db.InfoSettingBUs.Find(id);
            if (infosettingbu == null)
            {
                return HttpNotFound();
            }
            return View(infosettingbu);
        }

        //
        // GET: /InfoSettingBU/Create

        public ActionResult Create()
        {
            ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName");
            ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName");
            using (var dbnas = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IQueryable<dynamic> cabang = dbnas.Query("select kdkc,nmkc from REFKC").AsQueryable();
                ViewBag.KDKC = new SelectList(cabang, "kdkc", "nmkc");
            }
            return View();
        }

        //
        // POST: /InfoSettingBU/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfoSettingBU infosettingbu)
        {
            if (ModelState.IsValid)
            {
                db.InfoSettingBUs.Add(infosettingbu);
                db.SaveChanges();
                return RedirectToAction("SuccessAddSettingBU");
            }
            ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName", infosettingbu.CaraBayarID);
            ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName", infosettingbu.PolisPegawaiID);
            return View(infosettingbu);
        }

        //
        // GET: /InfoSettingBU/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InfoSettingBU infosettingbu = db.InfoSettingBUs.Find(id);
            if (infosettingbu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName", infosettingbu.CaraBayarID);
            ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName", infosettingbu.PolisPegawaiID);
            return View(infosettingbu);
        }

        //
        // POST: /InfoSettingBU/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InfoSettingBU infosettingbu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infosettingbu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SuccessEditSettingBU");
            }
            ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName", infosettingbu.CaraBayarID);
            ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName", infosettingbu.PolisPegawaiID);
            return View(infosettingbu);
        }

        //
        // GET: /InfoSettingBU/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InfoSettingBU infosettingbu = db.InfoSettingBUs.Find(id);
            if (infosettingbu == null)
            {
                return HttpNotFound();
            }
            return View(infosettingbu);
        }

        //
        // POST: /InfoSettingBU/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoSettingBU infosettingbu = db.InfoSettingBUs.Find(id);
            db.InfoSettingBUs.Remove(infosettingbu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetBUInfoSettingBU(string kdkc)
        {
            var listProd = (from _prod in db.vwInfoSettingBUs
                            where _prod.KDKC == kdkc
                            select new
                            {
                                PKSKD = _prod.NOMOR,
                                PKSNM = _prod.PKSNM
                            }).Distinct();
            return Json(listProd, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            using (var dbnas = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                //IQueryable<dynamic> bu = dbnas.Query("select pkskd,pkskd +'-' +nomor+'-' +pksnm as pksnm from datpks").AsQueryable();
                IQueryable<dynamic> cabang = dbnas.Query("select kdkc,nmkc from refkc").AsQueryable();
                //ViewBag.PKSKD = new SelectList(bu, "pkskd", "pksnm");
                ViewBag.KDKC = new SelectList(cabang, "kdkc", "nmkc");
            }
            return View();
        }


        public PartialViewResult DetailSettingBU(string polis)
        {
            IEnumerable<vwInfoSettingBU> info = db.vwInfoSettingBUs.Where(a => a.NOMOR == polis);
            return PartialView(info);
        }

        public ViewResult SuccessAddSettingBU()
        {
            return View();
        }

        public ViewResult SuccessEditSettingBU()
        {
            return View();
        }

        public ViewResult ListAll()
        {
            using (var dbnas = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IQueryable<dynamic> cabang = dbnas.Query("select kdkc,nmkc from refkc").AsQueryable();
                ViewBag.KDKC = new SelectList(cabang, "kdkc", "nmkc");
            }
            return View();
        }

        [HttpPost]
        public JsonResult BuList(string KDKC, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int _buCount = buCount(KDKC);
                using (var db = new BENEFITContext())
                {
                    var bus = db.vwInfoSettingBUs.Where(a => a.KDKC == KDKC).OrderBy(a => a.PKSNM).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    return Json(new { Result = "OK", Records = bus, TotalRecordCount = _buCount });
                }
                //List<person> persons = _personRepository.GetPersons(jtStartIndex, jtPageSize, jtSorting);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult vwInfoSetting(string NOMOR)
        {
            //var _NOMOR = NOMOR.Replace("'", "");
            try
            {
                using (var db = new BENEFITContext())
                {
                    List<vwInfoSettingBU> bus = db.vwInfoSettingBUs.Where(a => a.NOMOR == NOMOR).ToList();
                    return Json(new { Result = "OK", Records = bus });
                }
                //List<person> persons = _personRepository.GetPersons(jtStartIndex, jtPageSize, jtSorting);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public int buCount(string KDKC)
        {
            using (var db = new BENEFITContext())
            {
                int _buCount = db.vwInfoSettingBUs.Where(a => a.KDKC == KDKC).Count();
                return _buCount;
            }
        }

        public bool Export()
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                using (var db = new BENEFITContext())
                {
                    var filename = "InfoSettingBU";
                    var contacts = db.vwInfoSettingBUs.Select(a => new
                    {
                        NMKC = a.NMKC,
                        NOMOR = a.NOMOR,
                        PKSKD = a.PKSKD,
                        PKSNM = a.PKSNM
                    }).Distinct();
                    if (contacts.Count() != 0)
                    {
                        var grid = new System.Web.UI.WebControls.GridView();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        grid.DataSource = contacts.ToList();
                        grid.DataBind();

                        if (grid.HeaderRow != null)
                        {

                            for (int i = 0; i < grid.HeaderRow.Cells.Count; i++)
                            {
                                dt.Columns.Add(grid.HeaderRow.Cells[i].Text);
                            }
                        }

                        //  add each of the data rows to the table
                        foreach (GridViewRow row in grid.Rows)
                        {
                            DataRow dr;
                            dr = dt.NewRow();

                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                dr[i] = row.Cells[i].Text;//.Replace(" ", "");
                            }
                            dt.Rows.Add(dr);
                        }

                        //Create the worksheet
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

                        //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                        ws.Cells["A1"].LoadFromDataTable(dt, true);

                        //Write it back to the client
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;  filename=" + filename);
                        Response.BinaryWrite(pck.GetAsByteArray());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}