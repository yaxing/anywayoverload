using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DbConnect;
using System.Data.SqlClient;

namespace BsCtrl
{
    public class modeIndex
    {
        //mode_index.master母版页使用功能类
        private String Server;
        private String uName;
        private String pWord;
        private DataSet ds;
        private DbConnector conn;
        private String strDbConn;

        //public void initial(String s, String u, String p)
        //{
        //    //初始化数据库连接信息

        //    this.Server = s;
        //    this.uName = u;
        //    this.pWord = p;
        //    conn = new DbConnector();
        //    ds = null;
        //    conn.connDB(Server, uName, pWord);
            
        //}

        public void initial(String s)
        {
            //初始化数据库连接信息

            this.strDbConn = s;
            conn = new DbConnector();
            conn.connDB(strDbConn);

        }

        public DataSet VerifyUserInfo(String strUserName, String strPassWord)
        {
            //连接数据库并查询是否有与登录用户信息匹配项，返回dataset
            
            ds = conn.executeQuery("select * from users where username = '" + strUserName + "' and password = '" + strPassWord + "'");
            return ds;
        }

        public DataSet GetBbs() 
        {
            //获取公告内容
            ds = conn.executeQuery("select top 1 * from bbs order by postTime desc");
            return ds; 
        }

        public DataSet GetAvailablePoll() 
        {  //获取可用投票
            ds = conn.executeQuery("select * from poll, pollDetail where poll.available = '1' and pollDetail.pollID = poll.ID");
            return ds; 
        }

        public void ModifyPoll(int id) 
        {
            //获取投票结果
            ds = conn.executeQuery("select counts from pollDetail where ID = '"+id+"'");
            conn.executeUpdate("update pollDetail set counts = "+ds.Tables[0].Columns[0]+"+1 where ID = '"+id+"'");
            return;
        } 
    }
}
