using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalReport.Models;
using TechnicalReport_Data.Models.FE;
using TechnicalReport_Data.ProcDown;

namespace TechnicalReport.Controllers
{
    public class ProcDownController : Controller
    {
        private readonly IMapper _Mapper;
        
        public ProcDownController(IMapper mapper)
        {
            _Mapper = mapper;
        }

        IProcDownRepository procDownRepository = new ProcDownRepository();
        // GET: ProcDownController
        public async Task<ActionResult> Index()
        {    
            var Result = await procDownRepository.GetProcDownList();
            return View(Result);
        }

        // GET: ProcDownController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Result = await procDownRepository.DetailProcDownList(id);
            return View(Result);
        }

        // GET: ProcDownController/Create
        public async Task <ActionResult> Create()
        {
            var EqList = await procDownRepository.CreateEquipList();
            ViewBag.ListOfEquipment = EqList;
            return View();
        }

        // POST: ProcDownController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcDowntimeViewModel model)
        {
            try
            {
                var ModelView = _Mapper.Map<ProcessDowntimes>(model);
                procDownRepository.CreateNewProcDownItem(ModelView);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcDownController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var EqList = await procDownRepository.CreateEquipList();
            ViewBag.ListOfEquipment = EqList;
            var Result = await procDownRepository.GetProcessDowntimeRecord(id);
            return View(Result);
        }

        // POST: ProcDownController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProcDowntimeViewModel model)
        {
            try
            {
                var ModelView = _Mapper.Map<ProcessDowntimes>(model);
                procDownRepository.EditExistingItem(ModelView);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcDownController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Result = await procDownRepository.GetProcessDowntimeRecord(id);
            return View(Result);
        }

        // POST: ProcDownController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {               
                procDownRepository.DeleteProcDownRecord(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
