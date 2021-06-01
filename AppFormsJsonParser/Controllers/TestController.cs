using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFormsJsonParser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppFormsJsonParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("/FormTree")]
        public List<TreeStructure> FormTree()
        {
            return GetFileStructure();
        }

        private List<TreeStructure> GetFileStructure()
        {
            Tree t = new Tree();
            List<TreeStructure> list = new List<TreeStructure>();

            list.Add(new TreeStructure() { Id = "1", Title = "Equipments", Key = "0" });
            list.Add(new TreeStructure() { Id = "2", Title = "630", Key = "1", Node = "first" });
            list.Add(new TreeStructure() { Id = "3", Title = "630.01", Key = "2", Node = "second" });
            list.Add(new TreeStructure() { Id = "4", Title = "630.01.01", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "5", Title = "630.01.02", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "5", Title = "630.01.03", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "6", Title = "630.01.01.01", Key = "4", Node = "fourth" });

            list.Add(new TreeStructure() { Id = "11", Title = "Equipments", Key = "0" });
            list.Add(new TreeStructure() { Id = "22", Title = "930", Key = "1", Node = "first" });
            list.Add(new TreeStructure() { Id = "33", Title = "930.01", Key = "2", Node = "second" });
            list.Add(new TreeStructure() { Id = "44", Title = "930.01.01", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "55", Title = "930.01.02", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "66", Title = "930.01.03", Key = "3", Node = "third" });
            list.Add(new TreeStructure() { Id = "77", Title = "930.01.01.01", Key = "4", Node = "tedt" });

            var list2 = list.OrderBy(a => a.Title).ToList();
            List<TreeStructure> treelist = new List<TreeStructure>();
            if (list2.Count > 0)
            {
                treelist = t.BuildTree(list2);
            }

            return treelist;


            // return new JsonResult { Data = new { treeList = treelist }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }

    public partial class TreeStructure
    {

        public string Node { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }

        public List<TreeStructure> Children { get; set; }
    }
}



