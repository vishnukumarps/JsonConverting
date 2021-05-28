using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverting
{
    public class Tree
    {

        public void GetTreeview(List<MyFileStructure> list, MyFileStructure current, ref List<MyFileStructure> returnList)
        {
            //get child of current item
            var childs = list.Where(a => a.Key == current.Id).ToList();
            current.Children = new List<MyFileStructure>();
            current.Children.AddRange(childs);
            foreach (var i in childs)
            {
                GetTreeview(list, i, ref returnList);
            }
        }

        public List<MyFileStructure> BuildTree(List<MyFileStructure> list)
        {
            List<MyFileStructure> returnList = new List<MyFileStructure>();
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
