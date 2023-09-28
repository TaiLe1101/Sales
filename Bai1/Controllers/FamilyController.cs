using Bai1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai1.Controllers
{
    public class FamilyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Myself()
        {

            ViewBag.HO_TEN = "Lê Trần Tấn Tài";
            ViewBag.TUOI = 20;
            ViewBag.SO_THICH = "Xem phim";
            return View();
        }
        public IActionResult Members()
        {
            var members = new List<PersonInfo>
            {
                new PersonInfo { HoTen = "Lê Tấn Thành", Tuoi=52, SoThich="Trồng cây", MoiQuanHe="Tía" },
                new PersonInfo { HoTen = "Lê Trần Thanh Tuyền", Tuoi=23, SoThich="Vẽ", MoiQuanHe="Chị" },
                new PersonInfo { HoTen = "Lê Trần Thanh Nguyên", Tuoi = 18, SoThich = "Mua sắm", MoiQuanHe = "Em" },
            };
            return View(members);
        }
    }
}
