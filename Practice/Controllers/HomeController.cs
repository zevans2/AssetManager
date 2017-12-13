using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMData;


namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        
            ProposalItemViewModel vm = new ProposalItemViewModel();
            
            //Initialize proposal types list for use later. 
            vm.Proposals = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "Gym Floor Proposal"},
                new SelectListItem {Value = "2", Text = "Warewash Proposal"}
            };

            //Call our public function handler/manager.
            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ProposalItemViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }


    }
}