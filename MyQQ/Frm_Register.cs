using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyQQ
{
    public partial class Frm_Register : Form
    {
        DataOperator dataOper = new DataOperator();
        public Frm_Register()
        {
            InitializeComponent();
        }

        private void Frm_Register_Load(object sender, EventArgs e)
        {
            cboxStar.SelectedIndex = cboxBloodType.SelectedIndex = 0;  //设置星座和血型选项的默认值为0
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtNickName.Text.Trim() == "" || txtNickName.Text.Trim().Length > 20)  //验证昵称
            {
                MessageBox.Show("昵称输入有误！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtNickName.Focus();  //获取昵称的鼠标焦点
                return;
            }
            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtAge.Focus();
                return;
            }
            if (!rbtnMale.Checked && !rbtnFemale.Checked)
            {
                MessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lblSex.Focus();
                return;
            }
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwd.Focus();
                return;
            }
            if (txtPwdAgain.Text.Trim() == "")
            {
                MessageBox.Show("请确认密码", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwdAgain.Focus();
                return;
            }
            if (txtPwd.Text.Trim() != txtPwdAgain.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一样!", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwdAgain.Focus();
                return;
            }
            int myQQNum = 0;  //号码
            string message;  //弹出的消息
            string sex = rbtnMale.Checked ? rbtnMale.Text : rbtnFemale.Text;  //获得选中的性别信息
            string sql = string.Format("insert into tb_User (Pwd, NickName, Sex, Age, Name, Star, BloodType) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');select @@Identity from tb_User", txtPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()),
                txtName.Text.Trim(), cboxStar.Text, cboxBloodType.Text);  //真他妈的长！！！
            SqlCommand command = new SqlCommand(sql, DataOperator.connection);
            DataOperator.connection.Open();  //打开数据库连接
            int result = command.ExecuteNonQuery();  //所以，这句到底是干嘛的？
            if (result == 1)
            {
                sql = "select @@Identity from tb_User";   //查询新增加的记录的标识号
                command = new SqlCommand(sql, DataOperator.connection);  //  执行查询
                myQQNum = Convert.ToInt32(command.ExecuteScalar());   //获取最新增加的账号
                message = string.Format("注册成功！你的Lily Chat号码是" + myQQNum);
            }
            else
            {
                message = "注册失败，请重试！";
            }
            DataOperator.connection.Close();  //关闭数据库连接
            MessageBox.Show(message, "注册结果", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();  //关闭当前窗体
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
