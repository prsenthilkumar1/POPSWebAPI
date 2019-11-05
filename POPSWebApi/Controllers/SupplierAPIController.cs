using POPSWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace POPSWebApi.Controllers
{
    public class SupplierAPIController : ApiController
    {
        // GET api/values 
        public List<SupplierViewModel> Get()
        {
            List<SupplierViewModel> l_supplierViewModels = new List<SupplierViewModel>();

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                List<SUPPLIER> l_supplier = new List<SUPPLIER>();
                l_supplier = pOPSEntities.SUPPLIERs.Select(x => x).ToList();

                if (l_supplier?.Count > 0)
                {
                    foreach (var item in l_supplier)
                    {
                        SupplierViewModel supplierViewModel = new SupplierViewModel();
                        supplierViewModel.SupplierNo = item.SUPLNO;
                        supplierViewModel.SupplierName = item.SUPLNAME;
                        supplierViewModel.SupplierAddress = item.SUPLADDR;
                        l_supplierViewModels.Add(supplierViewModel);
                    }
                }
            };

            return l_supplierViewModels;
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return null;
        }

        // POST api/values 
        public string Post(SupplierViewModel supplierViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                SUPPLIER supplier = new SUPPLIER();
                supplier.SUPLNO = supplierViewModel.SupplierNo;
                supplier.SUPLNAME = supplierViewModel.SupplierName;
                supplier.SUPLADDR = supplierViewModel.SupplierAddress;

                pOPSEntities.SUPPLIERs.Add(supplier);
                pOPSEntities.SaveChanges();
            };

            success = "Supplier Details successfully saved";
            return success;
        }

        // PUT api/values/5 
        //[ResponseType(typeof(SupplierViewModel))] 
        public string Put(SupplierViewModel supplierViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                SUPPLIER supplier = new SUPPLIER();

                supplier = pOPSEntities.SUPPLIERs.Where(t => t.SUPLNO == supplierViewModel.SupplierNo).Select(x => x).FirstOrDefault();

                if (supplier != null)
                {
                    supplier.SUPLNO = supplierViewModel.SupplierNo;
                    supplier.SUPLNAME = supplierViewModel.SupplierName;
                    supplier.SUPLADDR = supplierViewModel.SupplierAddress;

                    pOPSEntities.Entry(supplier).State = EntityState.Modified;
                    pOPSEntities.SaveChanges();
                }
            };

            success = "Supplier Details successfully Updated";
            return success;
        }

        // DELETE api/values/5 
        public string Delete(string SupplierNo)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                SUPPLIER supplier = new SUPPLIER();

                supplier = pOPSEntities.SUPPLIERs.Where(t => t.SUPLNO == SupplierNo).Select(x => x).FirstOrDefault();

                if (supplier != null)
                {
                    supplier.SUPLNO = SupplierNo;

                    pOPSEntities.Entry(supplier).State = EntityState.Deleted;
                    pOPSEntities.SaveChanges();
                }
            };

            success = "Supplier Details successfully Deleted";
            return success;
        }

    }
}