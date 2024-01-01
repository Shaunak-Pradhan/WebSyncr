using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IMiddlewareService
    {
        string Pattern(string pageid, int templateid);
        void Middleware(string pageid, int templateid, int prop);
    }
}
