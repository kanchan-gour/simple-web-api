using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestwebApiapp.Models;

namespace TestwebApiapp.Controllers
{
    public class CusomerController : ApiController
    {
        [RoutePrefix("api/Customer")]
        public class CustomerController : ApiController
        {
            // GET: api/Customer?RowCount=5  
            [HttpGet]
            public IEnumerable<tblCustomer> GetCustomers(int pageSize)
            {
                try
                {
                    int pageNumber = 0;
                    int IsPaging = 0;
                    CrudDataService objCrd = new CrudDataService();
                    List<tblCustomer> modelCust = objCrd.GetCustomerList(pageNumber, pageSize, IsPaging);
                    return modelCust;
                }
                catch
                {
                    throw;
                }
            }

            // GET: api/Customer/InfinitScroll  
            [HttpGet]
            public IEnumerable<tblCustomer> GetCustomerScroll(int pageNumber, int pageSize)
            {
                try
                {
                    int IsPaging = 1;
                    CrudDataService objCrd = new CrudDataService();
                    List<tblCustomer> modelCust = objCrd.GetCustomerList(pageNumber, pageSize, IsPaging);
                    return modelCust;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            // GET: api/Customer/Create  
            [HttpPost]
            //[ResponseType(typeof(tblCustomer))]
            public string Create(tblCustomer objCust)
            {
                try
                {
                    CrudDataService objCrd = new CrudDataService();
                    Int32 message = 0;

                    if ((objCust.FirstName != null) && (objCust.Email != null)) message = objCrd.InsertCustomer(objCust);
                    else message = -1;
                    return message.ToString();
                }
                catch
                {
                    throw;
                }
            }

            // GET: api/Customer/Get  
            [HttpGet]
            public tblCustomer GetCustomer(string FName)

            {
                try
                {
                    CrudDataService objCrd = new CrudDataService();
                    tblCustomer modelCust = objCrd.GetCustomerDetails(FName);
                    return modelCust;
                }
                catch
                {
                    throw;
                }
            }


            // GET: api/Customer/Edit  
            [HttpPost]
            [ResponseType(typeof(tblCustomer))]
            public string Edit(tblCustomer objCust)
            {
                try
                {
                    CrudDataService objCrd = new CrudDataService();
                    Int32 message = 0;
                    message = objCrd.UpdateCustomer(objCust);
                    return message.ToString();

                }
                catch
                {
                    throw;
                }
            }

            // GET: api/Customer/Delete  
            [HttpDelete]
            public string Delete(string Fname)
            {
                try
                {
                    CrudDataService objCrd = new CrudDataService();
                    Int32 message = 0;
                    message = objCrd.DeleteCustomer(Fname);
                    return message.ToString();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
 