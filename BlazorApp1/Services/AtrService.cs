using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore.Metadata;


namespace BlazorApp1.Services
{
    public class AtrService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public AtrService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<AtrClass> GetAllMtr()
        {
            return _dbcontext.Set<AtrClass>().OrderBy(item => item.authorid).ToList();
        }

        public bool TambahRec(AtrClass eccadd)
        {
            _dbcontext.author.Add(eccadd);
            _dbcontext.SaveChanges();
            return true;
        }

        public AtrClass UbahRec(int authorid)
        {
            AtrClass ar = new AtrClass();
            return _dbcontext.author.FirstOrDefault(u => u.authorid == authorid);
        }

        public bool UpdateeRec(AtrClass arupdate)
        {
            var Athrarupdate = _dbcontext.author.FirstOrDefault(u => u.authorid == arupdate.authorid);
            if (Athrarupdate != null)
            {
                Athrarupdate.nama = arupdate.nama;
                Athrarupdate.email = arupdate.email;
                _dbcontext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool HapusRec(AtrClass atrdel)
        {
            var Athrarupdel = _dbcontext.author.FirstOrDefault(u => u.authorid == atrdel.authorid);
            if (Athrarupdel != null)
            {
                _dbcontext.Remove(Athrarupdel);
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
