using PersonMatterManager.DAL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.BLL
{
    
    public class UserInfoBLL
    {
        UserInfoDAL userInfoDAL = new UserInfoDAL();
        public UserInfo checkLogin(string name, string pwd)
        {
            return userInfoDAL.checkLogin(name, pwd);
        }

        public bool ModifyInfo(string id,string name, string sex, string age, string tel, string remark, string address,string useriphone, out UserInfo s)
        {
            int ids = Convert.ToInt32(id);
            UserInfo us = userInfoDAL.LoadEntities(u => u.UserID == ids).FirstOrDefault();
            s = us;
            us.UserName = name;
            us.UserSex = Tool.GetSexIdbySex(sex);
            us.UserAge = Convert.ToInt32(age);
            us.UserTel = tel;
            us.UserRemarks = remark;
            us.UserAddress = address;
            us.UserIphone = useriphone;
            bool modify = userInfoDAL.ModifyEntity(us);
            if (modify == true)
                s = us;
            return modify;
        }

        public IQueryable<UserInfo> GetFriendInfo(int DepartmentId,int UserId,int pageIndex,int pageSize,out int total)
        {
            //连续使用加ToList()，报错  LINQ to Entities 不识别方法“System.Linq.IQueryable`1[PersonMatterManager.Entity.UserInfo] Skip
            var list = userInfoDAL.GetPageInfo(pageIndex, pageSize, out total, u => u.UserID, u => u.DepartmentID == DepartmentId && u.UserID != UserId).AsQueryable();
            return list;
            //return userInfoDAL.LoadEntities(u => u.DepartmentID == DepartmentId).ToList().SkipWhile(u => u.UserID == UserId).AsQueryable();
        }

        public string ModifyPwd(int id, string oldpwd, string newpwd)
        {
            UserInfo us = userInfoDAL.LoadEntities(u => u.UserID == id && u.LoginPwd == oldpwd).FirstOrDefault();
            if (us == null)
                return "NoFound";
            us.LoginPwd = newpwd;
            bool modify = userInfoDAL.ModifyEntity(us);
            if (modify == false)
                return "False";
            return "True";
        }

        public IQueryable<UserInfo> GetPerson()
        {
            var list = userInfoDAL.LoadEntities(u => true);
            foreach (var item in list)
            {
                string department = Tool.GetDeaprtmentById(Convert.ToInt32(item.DepartmentID));
                item.UserRemarks = department;
            }
            return list;
        }

        public bool  AddPerson(UserInfo us)
        {
            return userInfoDAL.AddEntity(us);
        }

        public UserInfo GetPersonInfo(string number, string name)
        {
            return userInfoDAL.LoadEntities(u => u.UserNumber == number && u.UserName == name).FirstOrDefault();
        }

        public UserInfo GetPersonInfobyID(int id)
        {
            return userInfoDAL.LoadEntities(u => u.UserID==id).FirstOrDefault();
        }

        public bool ModifyPerson(UserInfo us)
        {
            UserInfo model= userInfoDAL.LoadEntities(u => u.UserID==us.UserID).FirstOrDefault();
            model.UserName = us.UserName;
            model.UserAge = us.UserAge;
            model.DepartmentID = us.DepartmentID;
            model.RoleID = us.RoleID;
            model.UserNumber = us.UserNumber;
            model.UserSex = us.UserSex;
            model.UserAddress = us.UserAddress;
            model.UserTel = us.UserTel;
            model.BasePay = us.BasePay;
            return userInfoDAL.ModifyEntity(model);
        }

        public bool AddInfoimg(string UserName, string imgSrc)
        {
            UserInfo model = userInfoDAL.LoadEntities(u => u.UserName == UserName).FirstOrDefault();
            model.UserIphone = imgSrc;
            bool modify = userInfoDAL.ModifyEntity(model);
            return modify; 
        }

        public bool ModifyInfoimg(int UserID,string imgSrc,out UserInfo s)
        {
            UserInfo model = userInfoDAL.LoadEntities(u => u.UserID == UserID).FirstOrDefault();
            model.UserIphone = imgSrc;
            s = model;
            bool modify = userInfoDAL.ModifyEntity(model);
            if (modify == true)
                s = model;
            return modify;
        }

        public bool DelPerson(string[] number, string[] name)
        {
            int n = 0;
            for (int i = 0; i < number.Length; i++)
            {
                var num = number[i];
                var na = name[i];
                UserInfo us = userInfoDAL.LoadEntities(u => u.UserNumber == num && u.UserName == na).FirstOrDefault();
                bool del = userInfoDAL.DeleteEntity(us);
                if (del == false)
                    n++;
            }
            if (n > 0)
                return false;
            return true;
        }

        public IQueryable<UserInfo> GetPageInfo(int PageIndex, int PageSize, out int total)
        {
            var list = userInfoDAL.GetPageInfo(PageIndex, PageSize, out total, u => u.UserID);
            foreach (var item in list)
            {
                string department = Tool.GetDeaprtmentById(Convert.ToInt32(item.DepartmentID));
                item.UserRemarks = department;
            }
            return list;
        }
    }
}
