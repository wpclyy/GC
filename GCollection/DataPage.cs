using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCollection
{
    public partial class DataPage : UserControl
    {
        public delegate void EventPagingHandler(EventArgs e);
        public event EventPagingHandler EventPaging;

        public DataPage()
        {
            InitializeComponent();
        }

        #region
        private int _pageSize = 20;
        /// <summary>
        /// 每页显示记录数(默认20)
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value > 0)
                {
                    _pageSize = value;
                }
                else
                {
                    _pageSize = 20;
                }
                this.cmbpagesize.Text = _pageSize.ToString();
            }
        }

        private int _currentPage = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (value > 0)
                {
                    _currentPage = value;
                    this.txtcurrentpage.Text =value + "";
                }
                else
                {
                    _currentPage = 1;
                    this.txtcurrentpage.Text = value + "";
                }
            }
        }

        private int _totalCount = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }
            set
            {
                if (value >= 0)
                {
                    _totalCount = value;
                }
                else
                {
                    _totalCount = 0;
                }
                this.lbltotalcount.Text = "总计 " + this._totalCount.ToString() + " 条";
                CalculatePageCount();
                SetbtnStatus();
            }
        }

        private int _pageCount = 0;
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                if (value >= 0)
                {
                    _pageCount = value;
                }
                else
                {
                    _pageCount = 0;
                }
                this.lblpagecount.Text = "共 " + _pageCount + " 页";
            }
        }
        #endregion

        /// <summary>
        /// 计算页数
        /// </summary>
        private void CalculatePageCount()
        {
            if (this.TotalCount > 0)
            {
                this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.TotalCount) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this.PageCount = 0;
            }
        }

        private void SetbtnStatus()
        {
            if (this.TotalCount == 0)
            {
                this.btnfirstpage.Enabled = false;
                this.btnprevpage.Enabled = false;
                this.btnnextpage.Enabled = false;
                this.btnlastpage.Enabled = false;
            }
            else
            {
                this.btnfirstpage.Enabled = true;
                this.btnprevpage.Enabled = true;
                this.btnnextpage.Enabled = true;
                this.btnlastpage.Enabled = true;
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void Bind()
        {
            if (this.CurrentPage > this.PageCount)
            {
                this.CurrentPage = this.PageCount;
            }
            this.EventPaging?.Invoke(new EventArgs());
            this.txtcurrentpage.Text = this.CurrentPage+"";
            this.lbltotalcount.Text = "总计 " + this.TotalCount + " 条";
            this.lblpagecount.Text = "共 " + this.PageCount + " 页";
            if (this.CurrentPage == 1)
            {
                this.btnfirstpage.Enabled = false;
                this.btnprevpage.Enabled = false;
            }
            else
            {
                this.btnfirstpage.Enabled = true;
                this.btnprevpage.Enabled = true;
            }
            if (this.CurrentPage == this.PageCount)
            {
                this.btnnextpage.Enabled = false;
                this.btnlastpage.Enabled = false;
            }
            else
            {
                this.btnnextpage.Enabled = true;
                this.btnlastpage.Enabled = true;
            }
            if (this.TotalCount == 0)
            {
                this.btnfirstpage.Enabled = false;
                this.btnprevpage.Enabled = false;
                this.btnnextpage.Enabled = false;
                this.btnlastpage.Enabled = false;
            }
            else {
                this.btnfirstpage.Enabled = true;
                this.btnprevpage.Enabled = true;
                this.btnnextpage.Enabled = true;
                this.btnlastpage.Enabled = true;
            }
        }

        private void btnfirstpage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
              this.Bind();
        }

        private void btnprevpage_Click(object sender, EventArgs e)
        {
            this.CurrentPage -= 1;
            this.Bind();
        }

        private void btnnextpage_Click(object sender, EventArgs e)
        {
            this.CurrentPage += 1;
            this.Bind();
        }

        private void btnlastpage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.PageCount;
            this.Bind();
        }

        private void cmbpagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PageSize = Convert.ToInt32(cmbpagesize.Text);
            this.CurrentPage = 1;
            this.Bind();
        }

        private void txtcurrentpage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
