using Data.Model;
using Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class BaseController<T> : ApiController where T : Entity
    {
        private readonly IRepository<T> _repository;

        public BaseController()
        {
            _repository = new BaseRepository<T>();
        }
        public IEnumerable<T> Get()
        {
            return _repository.GetAll();
        }

        public T Get(int id)
        {
            return _repository.GetSingle(id);
        }

        public void Post([FromBody]T value)
        {
            _repository.Insert(value);
        }

        public void Put(int id, [FromBody]T value)
        {
            _repository.Edit(value);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
