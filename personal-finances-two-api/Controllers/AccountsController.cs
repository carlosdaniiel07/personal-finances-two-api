using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class AccountsController : ApiController
    {
        private AccountService _service = new AccountService();

        // GET api/<controller>
        public IEnumerable<Account> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Account Get(int id)
        {
            return _service.Get(id);
        }
    }
}