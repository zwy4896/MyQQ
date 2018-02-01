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
    public partial class Frm_login : Form
    {
        DataOperator dataOper = new DataOperator();  //创建数据操作类的对象
        public Frm_login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
            //  根据号码查询其密码、记住密码和自动登录字段的值
            string sql = "select Pwd, Remember, AutoLogin from tb_User where ID=" +
                int.Parse(txtID.Text.Trim()) + "";
            DataSet ds = dataOper.GetDataSet(sql);  //  查询结果储存到数据集中
            if(ds.Tables[0].Rows.Count > 0)  // 判断是否存在该用户
            {
                if(Convert.ToInt32(ds.Tables[0].Rows[0][1]) == 1)  //判断是否记住密码
                {
                    cboxRemember.Checked = true;
                    txtPwd.Text = ds.Tables[0].Rows[0][0].ToString();  //自动输入密码
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][2]) == 1)
                    {
                        cboxAutoLogin.Checked = true;  //自动登录复选框选中
                        pboxLogin_Click(sender, e);  // 自动登录
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Register frmRegister = new Frm_Register();  // 创建申请账号对象
            frmRegister.Show();  // 显示申请账号窗体
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录账号", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtID.Focus();  //获得鼠标当前焦点
                return false;
            }
            else if(int.Parse(txtID.Text.Trim()) > 65535)
            {
                MessageBox.Show("请输入正确的登录账号", "登录提示", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                txtID.Focus();
                return false;
            }
            else if(txtID.Text.Length > 5 && txtPwd.Text.Trim() == "")  //密码
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwd.Focus();
                return false;
            }
            return true;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断输入是否为数字
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '\r') ||
                (e.KeyChar == '\b'))
            {
                e.Handled = false;  //显示该字符
            }
            else
                e.Handled = true;// 取消显示该字符
        }

        private void pboxLogin_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                string sql = "select count(*) from tb_User where ID=" + int.Parse(txtID.Text.Trim()) +
                    "and Pwd=" + txtPwd.Text.Trim() + "";  //定义查询SQL语句
                int num = dataOper.ExecSQL(sql);
                if (num == 1)  //验证通过
                {
                    PublicClass.loginID = int.Parse(txtID.Text.Trim());  //设置登录用户的号码
                    if (cboxRemember.Checked)  //点击记住密码
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=1 where ID=" +
                            int.Parse(txtID.Text.Trim()));  //记住密码
                        if (cboxAutoLogin.Checked)  //记住密码才能自动登录
                        {
                            dataOper.ExecSQLResult("update tb_User set AutoLogin=1 where ID=" +
                                int.Parse(txtID.Text.Trim()));
                        }
                    }
                    else
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=0 where ID=" +
                            int.Parse(txtID.Text.Trim()));
                        dataOper.ExecSQLResult("update tb_User set AutoLogin=0 where ID=" +
                            int.Parse(txtID.Text.Trim()));
                    }
                    dataOper.ExecSQLResult("update tb_User set Flag=1 where ID=" +
                        int.Parse(txtID.Text.Trim()));  //设置登录状态
                    Frm_main frmMain = new Frm_main();  //创建主界面对象,素质三连：创建我，杀掉你，我称霸
                    frmMain.Show();  //显示主界面
                    this.Visible = false;  //隐藏登录窗口
                }
                else
                {
                    MessageBox.Show("您输入的信息有误！", "登录提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                pboxLogin_Click(sender, e);  //登录按钮获得鼠标焦点
        }

        private void cboxRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (!cboxRemember.Checked)
                cboxAutoLogin.Checked = false;
        }

        private void pboxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  //窗体最小化
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();  //退出程序
        }
    }
}
