using POPSWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace POPSWebApi.Controllers
{
    public class PODetailAPIController : ApiController
    {
        // GET: api/PODetailAPI 
        public List<PODetailViewModel> Get()
        {
            List<PODetailViewModel> l_PODetailViewModels = new List<PODetailViewModel>();

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                List<PODETAIL> l_podetail = new List<PODETAIL>();

                l_podetail = pOPSEntities.PODETAILs.Select(x => x).ToList();

                if (l_podetail?.Count > 0)
                {
                    foreach (var item in l_podetail)
                    {
                        PODetailViewModel poDetailViewModels = new PODetailViewModel();
                        poDetailViewModels.PONumber = item.PONO;
                        poDetailViewModels.ItemCode = item.ITCODE;
                        poDetailViewModels.Quantity = Convert.ToInt32(item.QTY);
                        l_PODetailViewModels.Add(poDetailViewModels);
                    }
                }
            };

            return l_PODetailViewModels;
        }

        // GET: api/PODetailAPI/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PODetailAPI 
        public string Post(PODetailViewModel pODetailViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                PODETAIL podetail = new PODETAIL();
                podetail.PONO = pODetailViewModel.PONumber;
                podetail.ITCODE = pODetailViewModel.ItemCode;
                podetail.QTY = pODetailViewModel.Quantity;

                pOPSEntities.PODETAILs.Add(podetail);
                pOPSEntities.SaveChanges();
            }

            success = "PODetail successfully saved";

            return success;
        }

        // PUT: api/PODetailAPI/5 
        public string Put(PODetailViewModel pODetailViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                PODETAIL podetail = new PODETAIL();

                podetail = pOPSEntities.PODETAILs.Where(t => t.PONO == pODetailViewModel.PONumber && t.ITCODE == pODetailViewModel.ItemCode).Select(x => x).FirstOrDefault();

                if (podetail != null)
                {
                    podetail.PONO = pODetailViewModel.PONumber;
                    podetail.ITCODE = pODetailViewModel.ItemCode;
                    podetail.QTY = pODetailViewModel.Quantity;

                    pOPSEntities.Entry(podetail).State = EntityState.Modified;
                    pOPSEntities.SaveChanges();
                }
            };

            success = "PODetail successfully Updated";
            return success;
        }

        // DELETE: api/PODetailAPI/5 
        public string Delete(PODetailViewModel pODetailViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                PODETAIL podetail = new PODETAIL();

                podetail = pOPSEntities.PODETAILs.Where(t => t.PONO == pODetailViewModel.PONumber && t.ITCODE == pODetailViewModel.ItemCode).Select(x => x).FirstOrDefault();
                if (podetail != null)
                {
                    pOPSEntities.Entry(podetail).State = EntityState.Deleted;
                    pOPSEntities.SaveChanges();
                }
            };

            return success;
        }

    }
}