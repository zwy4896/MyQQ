using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class Frm_Chat : Form
    {
        public int friendID = 0;   //号码
        public string nickName;    // 昵称
        public int headID;     //好友头像ID
        DataOperator dataOper = new DataOperator();   //创建数据操作类的对象
        public Frm_Chat()
        {
            InitializeComponent();
        }

        private void Frm_Chat_Load(object sender, EventArgs e)
        {

        }
    }
}
