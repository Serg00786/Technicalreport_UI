using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalReport.Models;
using TechnicalReport_BL.FE.Availability;
using TechnicalReport_BL.DTO;
using TechnicalReport_Data.FE.Availability;
using AutoMapper;
using TechnicalReport_Data.ProcDown;

namespace TechnicalReport.Controllers
{
    public class FeAvailabilityController : Controller
    {
        private readonly IMapper _Mapper;

        public FeAvailabilityController(IMapper Mapper)
        {
            _Mapper = Mapper;
        }

        private readonly FERepository repository = new FERepository();
        private readonly ProcDownRepository procdownRepository = new ProcDownRepository();
        public async Task<ActionResult> Index(Date dt)
        {
            MainFEAvailability processAvailability_BL = new MainFEAvailability(repository, procdownRepository);
            var dtDTO = _Mapper.Map<DateDTO>(dt);
            var FeList= await processAvailability_BL.GetFeAvailabilityReportData(dtDTO);

            return View();
        }

        // GET: FeAvailabilityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeAvailabilityController/Create
        public ActionResult Create()
        {
            TechnicalReport_Data.FE.Availability.FERepository getFEData = new TechnicalReport_Data.FE.Availability.FERepository();
            var vm = new Date();

            var EqList= getFEData.GetEquipmentList();
            ViewBag.ListOfEquipment = EqList;

            vm.From = DateTime.Today.AddDays(-1).AddHours(8);
            vm.To = DateTime.Today.AddHours(8);
            vm.DiscrList = new List<Discrepance>
            {
                new Discrepance { Id = 1, DiscrTime = "Час" },
                new Discrepance { Id = 2, DiscrTime = "Смена" },
                new Discrepance { Id = 3, DiscrTime = "День" },
                new Discrepance { Id = 4, DiscrTime = "Неделя" },
                new Discrepance { Id = 5, DiscrTime = "Месяц" },
                new Discrepance { Id = 6, DiscrTime = "Год" }
            };
            return View(vm);
        }

        // POST: FeAvailabilityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Date dt)
        {
            try
            {
                return RedirectToAction("Index", dt);
            }
            catch
            {
                return View();
            }
        }

        // GET: FeAvailabilityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeAvailabilityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeAvailabilityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeAvailabilityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
