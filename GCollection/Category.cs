using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
    public class Category
    {
        private string catid="0";
        private string catname="";
        private string parentids="0";
        private string gcatid="0";
        private string gcatname="";

        /// <summary>
        /// 1688商品分类ID
        /// </summary>
        public string Catid
        {
            set { catid = value; }
            get { return catid; }
        }

        /// <summary>
        /// 1688商品分类名称
        /// </summary>
        public string Catname
        {
            set { catname = value; }
            get { return catname; }
        }

        /// <summary>
        /// 1688父分类ID
        /// </summary>
        public string Parentids
        {
            set { parentids = value; }
            get { return parentids; }
        }

        /// <summary>
        /// 大商创分类ID
        /// </summary>
        public string Gcatid
        {
            set { gcatid = value; }
            get { return gcatid; }
        }

        /// <summary>
        /// 大商创分类名称
        /// </summary>
        public string Gcatname
        {
            set { gcatname = value; }
            get { return gcatname; }
        }
    }
}
