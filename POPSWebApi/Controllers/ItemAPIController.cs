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
    public class ItemAPIController : ApiController
    {
        // GET: api/ItemAPI 
        public List<ItemViewModel> Get()
        {
            List<ItemViewModel> l_ItemViewModels = new List<ItemViewModel>();

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                List<ITEM> l_item = new List<ITEM>();

                l_item = pOPSEntities.ITEMs.Select(x => x).ToList();

                if (l_item?.Count > 0)
                {
                    foreach (var item in l_item)
                    {
                        ItemViewModel itemViewModel = new ItemViewModel();
                        itemViewModel.ITCode = item.ITCODE;
                        itemViewModel.ITDesc = item.ITDESC;
                        itemViewModel.ITRate = Convert.ToDecimal(item.ITRATE);

                        l_ItemViewModels.Add(itemViewModel);
                    }
                }
            };

            return l_ItemViewModels;
        }

        // GET: api/ItemAPI/5 
        public string Get(int id)
        {
            return null;
        }

        // POST: api/ItemAPI 
        public string Post(ItemViewModel ItemViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {

                ITEM item = new ITEM();
                item.ITCODE = ItemViewModel.ITCode;
                item.ITDESC = ItemViewModel.ITDesc;
                item.ITRATE = ItemViewModel.ITRate;

                pOPSEntities.ITEMs.Add(item);
                pOPSEntities.SaveChanges();
            }

            success = "Item Details successfully saved";

            return success;
        }

        // PUT: api/ItemAPI/5 
        public string Put(ItemViewModel ItemViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                ITEM item = new ITEM();

                item = pOPSEntities.ITEMs.Where(t => t.ITCODE == ItemViewModel.ITCode).Select(x => x).FirstOrDefault();

                if (item != null)
                {
                    item.ITCODE = ItemViewModel.ITCode;
                    item.ITDESC = ItemViewModel.ITDesc;
                    item.ITRATE = ItemViewModel.ITRate;

                    pOPSEntities.Entry(item).State = EntityState.Modified;
                    pOPSEntities.SaveChanges();
                }
            };

            success = "Item Details successfully Updated";
            return success;
        }

        // DELETE: api/ItemAPI/5 
        public string Delete(ItemViewModel ItemViewModel)
        {
            string success = string.Empty;

            using (POPSEntities pOPSEntities = new POPSEntities())
            {
                ITEM item = new ITEM();

                item = pOPSEntities.ITEMs.Where(t => t.ITCODE == ItemViewModel.ITCode).Select(x => x).FirstOrDefault();

                if (item != null)
                {
                    pOPSEntities.Entry(item).State = EntityState.Deleted;
                    pOPSEntities.SaveChanges();
                }
            };

            return success;
        }

    }
}