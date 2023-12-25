using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DevPortal.Services.Implementation.DataBlocksService;

namespace DevPortal.Services.Implementation
{
    public class MiddlewareService : IMiddlewareService
    {
        IWriteFileService writeFileService = new WriteFileService();
        IDataBlocksService dataBlocksService = new DataBlocksService();
        public void Middleware(string pageid,int templateid,int prop)
        {
            PageData pageData =  dataBlocksService.GetDataBlocks($@"Page{pageid}");
        }
        public string Pattern(string pageid, int templateid)
        {
            return $@"[]{pageid}_{templateid}[/]";
        }
    }
}