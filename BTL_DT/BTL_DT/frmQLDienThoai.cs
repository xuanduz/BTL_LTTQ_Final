using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_DT
{
    public partial class frmQLDienThoai : Form
    {
        public frmQLDienThoai()
        {
            InitializeComponent();
        }

        private void frmQLDienThoai_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1000, 600);
        }
    }
}
