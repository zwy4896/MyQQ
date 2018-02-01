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
using System.Media;

namespace MyQQ
{
    public partial class Frm_main : Form
    {

        int fromUserID;  // 消息发送者
        int friendHeadID;  //  发消息好友的头像ID
        int messageImageIndex = 0;  //工具栏中信息图标索引
        public static string nickName = "";  //自己的昵称
        public static string strFlag = "[离线]";  //当前状态
        Frm_Chat frmChat;   //聊天窗体对象
        DataOperator dataOper = new DataOperator();  //创建数据操作类的对象
        public Frm_main()
        {
            InitializeComponent();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            tsbtnMessageReading.Image = imglistMessage.Images[0];
            ShowInfo();
            ShowFriendList();
        }

        //显示个人头像、昵称、账号等信息
        public void ShowInfo()
        {
            int headID = 0;
            string sql = "select NickName, HeadID, sign from tb_User where ID=" + PublicClass.loginID + "";
            SqlDataReader dataReader = dataOper.GetDataReader(sql);
            if (dataReader.Read())
            {
                if (!(dataReader["NickName"] is DBNull))  //  若昵称不为空
                {
                    nickName = dataReader["NickName"].ToString();
                }
                headID = Convert.ToInt32(dataReader["HeadID"]);  // 记录头像ID
                txtSign.Text = dataReader["Sign"].ToString();
            }
            dataReader.Close();  //  关闭读取器
            DataOperator.connection.Close();  //关闭数据库连接
            this.Text = PublicClass.loginID.ToString();  // 将当前用户账号显示在窗体标题
            pboxHead.Image = imglistHead.Images[headID];    //  显示用户头像
            lblName.Text = nickName + "(" + PublicClass.loginID + ")";   //显示昵称及账号
        }

        //ShowFrienfList方法，显示当前登录用户好友列表信息
        public void ShowFriendList()
        {
            lvFriend.Items.Clear();  //清空原来的列表
            string sql = "select FriendID, NickName, HeadID, Flag from tb_User, tb_Friend where tb_Friend.HostID=" +
                PublicClass.loginID + "and tb_User.ID = tb_Friend.FriendID";
            SqlDataReader dataReader = dataOper.GetDataReader(sql);
            int i = lvFriend.Items.Count;
            while (dataReader.Read())
            {
                if (dataReader["Flag"].ToString() == "0")
                    strFlag = "[离线]";
                else
                    strFlag = "[在线]";
                string strTemp = dataReader["NickName"].ToString();   // 记录好友昵称
                string strFriendName = strTemp;
                if (strTemp.Length < 9)
                    strFriendName = strTemp.PadLeft(9, ' ');
                else
                    strFriendName = (strTemp.Substring(0, 2) + "...").PadLeft(9, ' ');
                lvFriend.Items.Add(dataReader["FriendID"].ToString(), strFriendName + strFlag, (int)dataReader["HeadID"]);
                lvFriend.Items[i].Group = lvFriend.Groups[0];
                i++;
            }
            dataReader.Close();  //关闭读取器
            DataOperator.connection.Close();   //关闭与数据库的连接
        }

        private void tsbtnInfo_Click(object sender, EventArgs e)
        {
            Frm_EditInfo frmInfo = new Frm_EditInfo();  //创建个人信息窗体对象
            frmInfo.Show();  //  素质二连，创建对象，显示窗体
        }

        private void tsbtnSearchFriend_Click(object sender, EventArgs e)
        {
            Frm_AddFriend frmAdd = new Frm_AddFriend();
            frmAdd.Show();
        }

        private void tsbtnUpdateFriendList_Click(object sender, EventArgs e)
        {
            ShowFriendList();  //  显示好友列表
        }

        private void tsbtnMessageReading_Click(object sender, EventArgs e)
        {
            tmAddFriend.Stop();   //  停止消息提醒定时器
            messageImageIndex = 0;    //  头像回复正常
            tsbtnMessageReading.Image = imglistMessage.Images[messageImageIndex];  //显示正常的系统消息提示图标
            Frm_Remind frmRemind = new Frm_Remind();
            frmRemind.Show();
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "确认信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void lvFriend_DoubleClick(object sender, EventArgs e)
        {
            if(lvFriend.SelectedItems.Count > 0)
            {
                if(frmChat == null)
                {
                    frmChat = new Frm_Chat();  //  创建窗体对象
                    frmChat.friendID = Convert.ToInt32(lvFriend.SelectedItems[0].Name);
                    frmChat.nickName = dataOper.GetDataSet("select NickName from tb_User where ID=" +
                        frmChat.friendID).Tables[0].Rows[0][0].ToString();
                    frmChat.headID = Convert.ToInt32(dataOper.GetDataSet("select HeadID from tb_User where ID=" + frmChat.friendID).Tables[0].Rows[0][0]) + 1;
                    frmChat.ShowDialog();    //以对话框显示聊天窗体的对象
                    frmChat = null;  //  聊天窗体对象设置为空
                }
                if (tmChat.Enabled == true)
                {
                    tmChat.Stop();
                    lvFriend.SelectedItems[0].ImageIndex = friendHeadID;
                }
            }
        }
    }
}
