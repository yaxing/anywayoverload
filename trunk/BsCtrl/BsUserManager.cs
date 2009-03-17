using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BsCtrl
{
    public class BsUserManager
    {
        /*功能：匹配登录用户信息，获取验证结果
          参数：strUserName 用户登录名
                strPassWord 用户登录密码*/
        public bool VerifyUserInfo(String strUserName, String strPassWord)
        {
            bool ret = true;

            return ret;
        }

        /* 功能：查询已注册用户信息。
           参数：strUserID	表示用户的ID号	
                strUserName	表示用户的姓名	
                strTEL	表示用户的联系电话	
                str Email	表示用户的Email*/
        public DataSet FindUser(String strUserID, String strUserName, String strTEL, String strEmail)
        {
            DataSet ret = null;

            return ret;
        }

        /*功能：删除用户信息
          参数：strDelID[]	存放待删除用户的ID号*/
        public bool DeleteUser(String[] strDelID)
        {
            bool ret = true;

            return ret;
        }
    }
}
