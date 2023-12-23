using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Services.Implementation
{
    public class MiddlewareService : IMiddlewareService
    {
        IWriteFileService writeFileService = new WriteFileService();
        public void Middleware(string pageid,int templateid,int prop)
        {
            writeFileService.MiddlewareRewrite(pageid,templateid);
        }
        public string Pattern(string pageid, int templateid)
        {
            return $@"[]{pageid}_{templateid}[/]";
        }
    }
}