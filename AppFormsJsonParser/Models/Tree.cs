using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFormsJsonParser.Controllers;

namespace AppFormsJsonParser.Models
{
    public class Tree
    {

        public void GetTreeview(List<TreeStructure> list, TreeStructure current, ref List<TreeStructure> returnList)
        {
            //get child of current item
            var childs = list.Where(a => a.Key == current.Id).ToList();
            current.Children = new List<TreeStructure>();
            current.Children.AddRange(childs);
            foreach (var i in childs)
            {
                GetTreeview(list, i, ref returnList);
            }
        }

        public List<TreeStructure> BuildTree(List<TreeStructure> list)
        {
            List<TreeStructure> returnList = new List<TreeStructure>();
            //find top levels items
            var topLevels = list.Where(a => a.Key == list.OrderBy(b => b.Key).FirstOrDefault().Key).ToList();


            returnList.AddRange(topLevels);
            foreach (var i in topLevels)
            {
                GetTreeview(list, i, ref returnList);
            }
            return returnList;
        }
    }
}
