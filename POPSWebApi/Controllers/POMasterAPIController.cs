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
    public class POMasterAPIController : ApiController
    {
        // GET: api/POMasterAPI 
        public List<POMasterViewModel> Get()
        {
            List<POMasterViewModel> l_POMasterViewModels = new List<POMasterViewModel>();

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                List<POMASTER> l_pomaster = new List<POMASTER>();

                l_pomaster = pOPSEntities.POMASTERs.Select(x => x).ToList();

                if (l_pomaster?.Count > 0)
                {
                    foreach (var item in l_pomaster)
                    {
                        POMasterViewModel poMasterViewModels = new POMasterViewModel();
                        poMasterViewModels.PONumber = item.PONO;
                        poMasterViewModels.PODate = Convert.ToDateTime(item.PODATE);
                        poMasterViewModels.SupplierNumber = item.SUPLNO;

                        l_POMasterViewModels.Add(poMasterViewModels);
                    }
                }
            };

            return l_POMasterViewModels;
        }

        // GET: api/POMasterAPI/5 
        public string Get(int id)
        {
            return null;
        }

        // POST: api/POMasterAPI 
        public string Post(POMasterViewModel poMasterViewModels)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                POMASTER pomaster = new POMASTER();
                pomaster.PONO = poMasterViewModels.PONumber;
                pomaster.PODATE = poMasterViewModels.PODate;
                pomaster.SUPLNO = poMasterViewModels.SupplierNumber;

                pOPSEntities.POMASTERs.Add(pomaster);
                pOPSEntities.SaveChanges();
            }

            success = "POMaster Details successfully saved";

            return success;
        }

        // PUT: api/POMasterAPI/5 
        public string Put(POMasterViewModel poMasterViewModels)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                POMASTER pomaster = new POMASTER();

                pomaster = pOPSEntities.POMASTERs.Where(t => t.PONO == poMasterViewModels.PONumber).Select(x => x).FirstOrDefault();

                if (pomaster != null)
                {
                    pomaster.PONO = poMasterViewModels.PONumber;
                    pomaster.PODATE = poMasterViewModels.PODate;
                    pomaster.SUPLNO = poMasterViewModels.SupplierNumber;

                    pOPSEntities.Entry(pomaster).State = EntityState.Modified;
                    pOPSEntities.SaveChanges();
                }
            };

            success = "POMaster Details successfully Updated";
            return success;
        }

        // DELETE: api/POMasterAPI/5 
        public string Delete(POMasterViewModel poMasterViewModels)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                POMASTER pomaster = new POMASTER();

                pomaster = pOPSEntities.POMASTERs.Where(t => t.PONO == poMasterViewModels.PONumber).Select(x => x).FirstOrDefault();

                if (pomaster != null)
                {
                    pOPSEntities.Entry(pomaster).State = EntityState.Deleted;
                    pOPSEntities.SaveChanges();
                }
            };

            return success;
        }

    }
}