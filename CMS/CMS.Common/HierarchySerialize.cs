using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    /// <summary>
    /// 层级序列化
    /// </summary>
    public static class HierarchySerialize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <param name="ParentKey">父级</param>
        /// <param name="ChildKey">子级</param>
        /// <param name="TopKeyValue">顶级值</param>
        public static IEnumerable<T> Go<T>(IEnumerable<T> List, string ParentKey, string ChildKey, string TopKeyValue)
        {
            List<T> List_Result = new List<T>();
            GetChild<T>(TopKeyValue, List, ParentKey, ChildKey, ref List_Result);
            return List_Result;
        }

        //获取子级
        private static void GetChild<T>(string ParentValue, IEnumerable<T> List_All, string ParentKey, string ChildKey, ref List<T> List_Result)
        {
            //查询子级
            var List_Child = List_All.Where(o => (typeof(T).GetProperty(ParentKey).GetValue(o) == null ? "" : typeof(T).GetProperty(ParentKey).GetValue(o).ToString()) == ParentValue);
            if (List_Child.LongCount() > 0)
            {
                //循环所有子级再查询
                foreach (var item in List_Child)
                {
                    List_Result.Add(item);
                    GetChild<T>(typeof(T).GetProperty(ChildKey).GetValue(item).ToString(), List_All, ParentKey, ChildKey, ref List_Result);
                }
            }
        }
    }
}
