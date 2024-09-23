using EX3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EX3.Controllers
{
    public class HocVienController : Controller
    {
        // GET: HocVien
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult LuuHocVien(HocVien hocVien)
            {
                if (ModelState.IsValid)
                {
                    string filePath = Server.MapPath("~/App_Data/HocVienData.txt");

                    var data = new[]
                    {
                    hocVien.MaHocVien,
                    hocVien.HoTen,
                    hocVien.GioiTinh,
                    hocVien.NgaySinh.ToString("yyyy-MM-dd"),
                    hocVien.HocPhi.ToString(),
                    hocVien.HinhAnh,
                    hocVien.GhiChu,
                    "-----------------------------------------" 
                };

                    System.IO.File.AppendAllLines(filePath, data);
                    ViewBag.Message = "Lưu thông tin thành công!";
                }
                return View("Index", hocVien);
            }

            public ActionResult DocHocVien()
            {
                string filePath = Server.MapPath("~/App_Data/HocVienData.txt");

                if (System.IO.File.Exists(filePath))
                {
                    var lines = System.IO.File.ReadAllLines(filePath);

                    var hocVienList = new List<HocVien>();

                    for (int i = 0; i < lines.Length; i += 8) 
                    {
                        if (i + 7 < lines.Length) 
                        {
                            var hocVien = new HocVien
                            {
                                MaHocVien = lines[i],
                                HoTen = lines[i + 1],
                                GioiTinh = lines[i + 2],
                                NgaySinh = DateTime.Parse(lines[i + 3]),
                                HocPhi = decimal.Parse(lines[i + 4]),
                                HinhAnh = lines[i + 5],
                                GhiChu = lines[i + 6]
                            };
                            hocVienList.Add(hocVien);
                        }
                    }

                    return View("DanhSachHocVien", hocVienList); 
                }

                ViewBag.Message = "Không có dữ liệu học viên!";
                return View("Index");
            }
     }
 }
