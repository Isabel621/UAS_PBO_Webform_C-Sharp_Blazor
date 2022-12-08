using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApp1.Services
{
    public class MtrService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public MtrService(ApplicationDbContext _db)
        {
            _dbcontext = _db;   
        }


        public List<MtrClass> GetAllMtr()
        {
            return _dbcontext.Set<MtrClass>().OrderBy(item => item.kontenid).ToList();
        }

        public bool InsertRec(MtrClass ecadd)
        {
            if(ecadd.authorid == 0)
            {
                return false;
            }
            _dbcontext.mtrtable.Add(ecadd);
            _dbcontext.SaveChanges();
            return true;
        }

        public MtrClass EditRec(int kontenid)
        {
            MtrClass mc = new MtrClass();
            return _dbcontext.mtrtable.FirstOrDefault(u => u.kontenid == kontenid);
        }

        public bool UpdateRec(MtrClass mcupdate)
        {
            var Mtrimcupdate = _dbcontext.mtrtable.FirstOrDefault(u => u.kontenid == mcupdate.kontenid);
            if (Mtrimcupdate != null)
            {
                Mtrimcupdate.kelas = mcupdate.kelas;
                Mtrimcupdate.materi = mcupdate.materi;
                Mtrimcupdate.penjelasan = mcupdate.penjelasan;
                _dbcontext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DelRec(MtrClass mtrdel)
        {
            var Mtrimcupdel = _dbcontext.mtrtable.FirstOrDefault(u => u.kontenid == mtrdel.kontenid);
            if (Mtrimcupdel != null)
            {
                _dbcontext.Remove(Mtrimcupdel); 
                _dbcontext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
