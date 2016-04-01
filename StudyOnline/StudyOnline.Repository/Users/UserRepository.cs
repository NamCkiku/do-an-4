using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;
using StudyOnline.Common;

namespace StudyOnline.Repository.Users
{

    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Danh sách người dùng
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.User> ListAllUser()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.User.ToList();
            }
        }
        //public List<StudyOnline.Entities.Models.User> ListUserName()
        //{
        //    using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
        //    {
        //        return _db.User.Where(x=>x.UserName.Equals(.ToList();
        //    }
        //}

        /// <summary>
        /// Xem chi tiết người dùng
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>User</returns>
        public StudyOnline.Entities.Models.User ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.User.Find(id);
            }
        }
        public StudyOnline.Entities.Models.User GetById(string userName)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.User.SingleOrDefault(x => x.UserName == userName);
            }
        }
        /// <summary>
        /// Tạo người dùng
        /// </summary>
        /// <param name="tq">User</param>
        /// <returns>long</returns>
        public long CreateUser(StudyOnline.Entities.Models.User tq)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    //User data = new User();
                    //data.UserName = tq.UserName;
                    //data.Name = tq.Name;
                    //data.Address = tq.Address;
                    //data.Email = tq.Email;
                    //data.Phone = tq.Phone;
                    //data.Avatar = tq.Avatar;
                    //data.Password = Encryptor.MD5Hash(tq.Password);
                    //data.Status = false;
                    _db.User.Add(tq);
                    _db.SaveChanges();
                    return tq.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Cập nhật người dùng
        /// </summary>
        /// <param name="us">User</param>
        /// <returns>bool</returns>
        public bool UpdateUser(StudyOnline.Entities.Models.User us)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.User.Find(us.ID);
                    c.UserName = us.UserName;
                    c.Password = us.Password;
                    c.Name = us.Name;
                    c.Address = us.Address;
                    c.Email = us.Email;
                    c.Phone = us.Phone;
                    c.Avatar = us.Avatar;
                    c.Status = us.Status;
                    c.CreatedDate = us.CreatedDate;
                    c.CreatedBy = us.CreatedBy;
                    c.ModifiedDate = us.ModifiedDate;
                    c.ModifiedBy = us.ModifiedBy;
                    //c.GroupID = us.GroupID;
                    //c.PayID = us.PayID;
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteUser(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var result = _db.User.Find(id);
                    _db.User.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public int Login(string userName, string password)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                var result = _db.User.SingleOrDefault(x => x.UserName == userName && x.Password == password);//lấy giá trị của User Name
                if (result == null)//Nếu bằng null
                {
                    return 0;//Nhập Tài Khoản Và Mật Khẩu
                }
                else    //Khác Null
                {
                    if (result.Status == false)//Trạng Thaí = False
                    {
                        return -1;  //Tài Khoản Đang Bị Khóa
                    }
                    else  //Trạng Thái == true
                    {
                        if (result.Password == password)  //Nếu Password đúng
                            return 1; //Đăng Nhập Thành Công
                        else
                            return -2; //Sai tài khoản và mật khẩu
                    }
                }
            }
        }
        public bool Signup(User user)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                if (user != null)
                {
                    var User = _db.User.Add(user);
                    _db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
        public void Active(int id, bool status)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                var data = _db.User.SingleOrDefault(x => x.ID == id);
                data.Status = true;
                _db.SaveChanges();
            }
        }
        public bool CheckUserName(string userName)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.User.Count(x => x.UserName == userName) > 0;
            }
        }
        public bool CheckEmail(string email)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.User.Count(x => x.Email == email) > 0;
            }
        }
        //public int GetPassword(User model)
        //{
        //    using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
        //    {
        //        var data = _db.User.Where(x => x.UserName == model.UserName && x.Email == model.Email).ToList();
        //        if (data.Count > 0)
        //        {
        //            var newpass = SendMail.RandomString(6);
        //            var id = Convert.ToInt32(data[0].ID);
        //            var dataUpdate = _db.User.SingleOrDefault(x => x.ID == id);
        //            dataUpdate.Password = newpass;
        //            _db.SaveChanges();
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}
    }
}
