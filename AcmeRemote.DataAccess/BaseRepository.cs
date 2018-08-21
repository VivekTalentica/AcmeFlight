using AcmeRemote.BusinessEntity;
using AcmeRemote.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeRemote.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected List<T> _entities;
        protected string _fileName;
        public BaseRepository(string fileName)
        {
            _fileName = fileName;
            FillEntities();
            //Read the file and fill _entities
        }

        protected void FillEntities()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\bin\"+ _fileName))
            {
                _entities = Utility.Read<List<T>>(_fileName);
            }
        }
        public List<T> Get()
        {
            if(_entities == null)
            {
                FillEntities();
            }
            return _entities;
        }

        public T GetById(int id)
        {
            if (_entities == null)
            {
                FillEntities();
            }
            var entity = _entities.Where(e => e.Id == id).FirstOrDefault();
            return entity;
        }
    }
}
