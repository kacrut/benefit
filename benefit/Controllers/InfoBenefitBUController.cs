using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using benefit.Models;
using WebMatrix.WebData;
using WebMatrix.Data;
using OfficeOpenXml;
using System.Web.UI.WebControls;


namespace benefit.Controllers
{
    public class InfoBenefitBUController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /InfoBenefitBU/

        public ActionResult Index()
        {
            //var infobenefitbus = db.InfoBenefitBUs.Include(i => i.FreqCase).Include(i => i.FreqPeriode).Include(i => i.ManfaatInManfaatItem).Include(i => i.ManfaatPISA);
            //return View(infobenefitbus.ToList());
            //return View(db.vwInfoBenefits.OrderBy(a => a.KDKC).ToList());
            return RedirectToAction("Create");
        }

        //
        // GET: /InfoBenefitBU/Details/5

        public ActionResult Details(int id = 0)
        {
            vwInfoBenefit infobenefitbu = db.vwInfoBenefits.Where(a => a.infoBenefitBUID == id).SingleOrDefault();
            if (infobenefitbu == null)
            {
                return HttpNotFound();
            }
            return View(infobenefitbu);
        }

        //
        // GET: /InfoBenefitBU/Create

        public ActionResult Create()
        {
            
            using (var dbnas = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                //IQueryable<dynamic> bu = dbnas.Query("select pkskd,pkskd +'-' +nomor+'-' +pksnm as pksnm from datpks").AsQueryable();
                IQueryable<dynamic> cabang = dbnas.Query("select kdkc,nmkc from refkc").AsQueryable();
                //ViewBag.PKSKD = new SelectList(bu, "pkskd", "pksnm");
                ViewBag.KDKC = new SelectList(cabang, "kdkc", "nmkc");
                ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName");
                ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName");
                ViewBag.FreqCaseID = new SelectList(db.FreqCases, "FreqCaseID", "FreqCaseName");
                ViewBag.FreqPeriodeID = new SelectList(db.FreqPeriodes, "FreqPeriodeID", "FreqPeriodeName");
                var ManfaatInManfaatItem = (from x in db.ManfaatInManfaatItems
                                            select new
                                            {
                                                ManfaatInManfaatItemID = x.ManfaatInManfaatItemID,
                                                ManfaatItemName = x.Manfaat.NamaManfaat + "-" + x.ManfaatItem.ManfaatItemName
                                            }).OrderBy(a => a.ManfaatItemName);
                ViewBag.ManfaatInManfaatItemID = new SelectList(ManfaatInManfaatItem, "ManfaatInManfaatItemID", "ManfaatItemName");
                ViewBag.ManfaatPISAID = new SelectList(db.ManfaatPISAs, "ManfaatPISAID", "ManfaatPISAName");
            }
            return View();
        }

        //
        // POST: /InfoBenefitBU/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfoBenefitBU infobenefitbu)
        {
            if (ModelState.IsValid)
            {
                db.InfoBenefitBUs.Add(infobenefitbu);
                db.SaveChanges();
                return RedirectToAction("SuccessAddBenefitBU");
            }

            //ViewBag.FreqCaseID = new SelectList(db.FreqCases, "FreqCaseID", "FreqCaseName", infobenefitbu.FreqCaseID);
            //ViewBag.FreqPeriodeID = new SelectList(db.FreqPeriodes, "FreqPeriodeID", "FreqPeriodeName", infobenefitbu.FreqPeriodeID);
            //ViewBag.ManfaatInManfaatItemID = new SelectList(db.ManfaatInManfaatItems, "ManfaatInManfaatItemID", "ManfaatInManfaatItemID", infobenefitbu.ManfaatInManfaatItemID);
            //ViewBag.ManfaatPISAID = new SelectList(db.ManfaatPISAs, "ManfaatPISAID", "ManfaatPISAName", infobenefitbu.ManfaatPISAID);
            using (var dbnas = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                //IQueryable<dynamic> bu = dbnas.Query("select pkskd,pkskd +'-' +nomor+'-' +pksnm as pksnm from datpks").AsQueryable();
                IQueryable<dynamic> cabang = dbnas.Query("select kdkc,nmkc from refkc").AsQueryable();
                //ViewBag.PKSKD = new SelectList(bu, "pkskd", "pksnm");
                ViewBag.KDKC = new SelectList(cabang, "kdkc", "nmkc");
                ViewBag.CaraBayarID = new SelectList(db.CaraBayars, "CaraBayarID", "CaraBayarName");
                ViewBag.PolisPegawaiID = new SelectList(db.PolisPegawais, "PolisPegawaiID", "PolisPegawaiName");
                ViewBag.FreqCaseID = new SelectList(db.FreqCases, "FreqCaseID", "FreqCaseName");
                ViewBag.FreqPeriodeID = new SelectList(db.FreqPeriodes, "FreqPeriodeID", "FreqPeriodeName");
                var ManfaatInManfaatItem = (from x in db.ManfaatInManfaatItems
                                            select new
                                            {
                                                ManfaatInManfaatItemID = x.ManfaatInManfaatItemID,
                                                ManfaatItemName = x.Manfaat.NamaManfaat + "-" + x.ManfaatItem.ManfaatItemName
                                            }).OrderBy(a => a.ManfaatItemName);
                ViewBag.ManfaatInManfaatItemID = new SelectList(ManfaatInManfaatItem, "ManfaatInManfaatItemID", "ManfaatItemName");
                ViewBag.ManfaatPISAID = new SelectList(db.ManfaatPISAs, "ManfaatPISAID", "ManfaatPISAName");
            }
            return View(infobenefitbu);
        }

        //
        // GET: /InfoBenefitBU/Edit/5
        
        public ActionResult Edit(int id = 0)
        {
            InfoBenefitBU infobenefitbu = db.InfoBenefitBUs.Find(id);
            if (infobenefitbu == null)
            {
                return HttpNotFound();
            }
            ViewBag.FreqCaseID = new SelectList(db.FreqCases, "FreqCaseID", "FreqCaseName", infobenefitbu.FreqCaseID);
            ViewBag.FreqPeriodeID = new SelectList(db.FreqPeriodes, "FreqPeriodeID", "FreqPeriodeName", infobenefitbu.FreqPeriodeID);
            var ManfaatInManfaatItem = (from x in db.ManfaatInManfaatItems
                                        select new
                                        {
                                            ManfaatInManfaatItemID = x.ManfaatInManfaatItemID,
                                            ManfaatItemName = x.Manfaat.NamaManfaat + "-" + x.ManfaatItem.ManfaatItemName
                                        }).OrderBy(a => a.ManfaatItemName);
            ViewBag.ManfaatInManfaatItemID = new SelectList(ManfaatInManfaatItem, "ManfaatInManfaatItemID", "ManfaatItemName", infobenefitbu.ManfaatInManfaatItemID);
            //ViewBag.ManfaatInManfaatItemID = new SelectList(db.ManfaatInManfaatItems, "ManfaatInManfaatItemID", "ManfaatInManfaatItemID", infobenefitbu.ManfaatInManfaatItemID);
            ViewBag.ManfaatPISAID = new SelectList(db.ManfaatPISAs, "ManfaatPISAID", "ManfaatPISAName", infobenefitbu.ManfaatPISAID);
            return View(infobenefitbu);
        }

        //
        // POST: /InfoBenefitBU/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InfoBenefitBU infobenefitbu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infobenefitbu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SuccessEditBenefitBU");
            }
            //ViewBag.FreqCaseID = new SelectList(db.FreqCases, "FreqCaseID", "FreqCaseName", infobenefitbu.FreqCaseID);
            //ViewBag.FreqPeriodeID = new SelectList(db.FreqPeriodes, "FreqPeriodeID", "FreqPeriodeName", infobenefitbu.FreqPeriodeID);
            ViewBag.ManfaatInManfaatItemID = new SelectList(db.ManfaatInManfaatItems, "ManfaatInManfaatItemID", "ManfaatInManfaatItemID", infobenefitbu.ManfaatInManfaatItemID);
            //ViewBag.ManfaatPISAID = new SelectList(db.ManfaatPISAs, "ManfaatPISAID", "ManfaatPISAName", infobenefitbu.ManfaatPISAID);
            return View(infobenefitbu);
        }

        //
        // GET: /InfoBenefitBU/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InfoBenefitBU infobenefitbu = db.InfoBenefitBUs.Find(id);
            if (infobenefitbu == null)
            {
                return HttpNotFound();
            }
            return View(infobenefitbu);
        }

        //
        // POST: /InfoBenefitBU/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoBenefitBU infobenefitbu = db.InfoBenefitBUs.Find(id);
            db.InfoBenefitBUs.Remove(infobenefitbu);
            db.SaveChanges();
            return RedirectToAction("List", "InfoBenefitBU");
        }

        public JsonResult GetProduk(string pkskd, string polis)
        {
            using (var dbprod = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IEnumerable<dynamic> prod = dbprod.Query(string.Format("select b.KDPROD,b.NMPROD from PKSPROD a inner join REFPROD b on a.KDPROD=b.KDPROD inner join REFKLSPRWT c on c.KDKLSRWT=a.PPKDKLSRWT where a.PKSKD='{0}' and a.PKSNO='{1}'", pkskd, polis));
                var listProd = (from _prod in prod
                                select new
                                {
                                    KDPROD = _prod.KDPROD,
                                    NMPROD = _prod.NMPROD
                                }).Distinct();
                return Json(listProd, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetKelas(string pkskd, string polis, string produk)
        {
            using (var dbprod = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IEnumerable<dynamic> prod = dbprod.Query(string.Format("select c.KDKLSRWT,c.NMKLSRWT from PKSPROD a inner join REFPROD b on a.KDPROD=b.KDPROD inner join REFKLSPRWT c on c.KDKLSRWT=a.PPKDKLSRWT where a.PKSKD='{0}' and a.PKSNO='{1}' and b.KDPROD='{2}'", pkskd, polis, produk));
                var listProd = (from _prod in prod
                                select new
                                {
                                    KDKLSRWT = _prod.KDKLSRWT,
                                    NMKLSRWT = _prod.NMKLSRWT
                                }).Distinct();
                return Json(listProd, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetPolis(string pkskd)
        {
            using (var dbprod = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IEnumerable<dynamic> prod = dbprod.Query(string.Format("select NOMOR from  DATPKS where PKSKD='{0}'", pkskd));
                var listProd = (from _prod in prod
                                select _prod.NOMOR);
                return Json(listProd, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetBU(string kdkc)
        {
            using (var dbprod = WebMatrix.Data.Database.Open("DBNASContext"))
            {
                IEnumerable<dynamic> prod = dbprod.Query(string.Format("select pkskd,nomor +' - ' +pkskd+' - ' +pksnm as pksnm from datpks where kdkc='{0}' and CONVERT(varchar(6),PKSTGLML,112) between '201207' and '201306'", kdkc));
                var listProd = (from _prod in prod
                                select new
                                {
                                    PKSKD = _prod.pkskd,
                                    PKSNM = _prod.pksnm
                                });
                return Json(listProd, JsonRequestBehavior.AllowGet);
            }
                //var _GetBU = db.vwBuListEntriBenefits.Where(a => a.KDKC == kdkc).Select(a => new
                //{
                //    PKSKD = a.PKSKD,
                //    PKSNM = a.PKSNM
                //});
                //return Json(_GetBU, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBUInfoBenefitBU(string kdkc)
        {
            var listProd = (from _prod in db.vwInfoBenefits
                            where _prod.KDKC == kdkc
                            select new
                            {
                                PKSKD = _prod.POLIS,
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


        public PartialViewResult DetailBenefitBU(string polis)
        {
            IEnumerable<vwInfoBenefit> info = db.vwInfoBenefits.Where(a => a.POLIS == polis).OrderBy(a=>a.NMPROD).ThenBy(a=>a.NMKLSRWT).ThenBy(a=>a.MANFAAT);
            return PartialView(info);
        }


        public ViewResult SuccessAddBenefitBU()
        {
            return View();
        }

        public ViewResult SuccessEditBenefitBU()
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
        public JsonResult BuList(string KDKC,int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int _buCount = buCount(KDKC);
                using (var db = new BENEFITContext())
                {
                    var bus = db.vwInfoBenefits.Where(a => a.KDKC == KDKC).Select(a=> new
                        {
                            NOMOR= a.POLIS,
                            PKSKD = a.PKSKD,
                            PKSTGLML = a.PKSTGLML,
                            PKSTGLAKH = a.PKSTGLAKH,
                            PKSNM = a.PKSNM
                        }).Distinct().OrderBy(a => a.PKSNM).Skip(jtStartIndex).Take(jtPageSize).ToList();
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
        public JsonResult vwInfoBenefit(string NOMOR)
        {
            //var _NOMOR = NOMOR.Replace("'", "");
            try
            {
                using (var db = new BENEFITContext())
                {
                    List<vwInfoBenefit> bus = db.vwInfoBenefits.Where(a => a.POLIS == NOMOR).OrderBy(a => a.NMPROD).ThenBy(a => a.NMKLSRWT).ToList();
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
                int _buCount = db.vwBuListInfoBenefits.Where(a=>a.KDKC== KDKC).Count();
                return _buCount;
            }
        }

        public bool Export()
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                using (var db = new BENEFITContext())
                {
                    var filename = "InfoBenefitBU";
                    var contacts = db.vwInfoBenefits.Select(a => new
                        {
                            NMKC = a.NMKC,
                            NOMOR = a.POLIS,
                            PKSKD = a.PKSKD,
                            PKSTGLML = a.PKSTGLML,
                            PKSTGLAKH = a.PKSTGLAKH,
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