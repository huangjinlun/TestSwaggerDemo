﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.TableModel;

namespace TestSwaggerDemo.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBusiness iUserBusiness;
        /// <summary>
        /// 用户构造函数注入服务
        /// </summary>
        /// <param name="userBusiness"></param>
        public UserController(IUserBusiness userBusiness)
        {
            iUserBusiness = userBusiness;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("AllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return iUserBusiness.RetriveAllEntity().OrderBy(m => m.Id);
        }

        /// <summary>
        /// 根据主键Id获取一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User GetOneUser(int id)
        {
            return iUserBusiness.RetriveOneEntityById(id);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public bool CreateUser([FromBody]User user)
        {
            //List<User> userList = new List<User>();
            //for (int i = 0; i < 5000; i++)
            //{
            //    userList.Add(new User
            //    {
            //        Birthday = DateTime.Now,
            //        CreateDate = DateTime.Now,
            //        CreateUserId = 1000,
            //        Gender = false,
            //        IsDeleted = false,
            //        Password = i.ToString(),
            //        UpdateDate = DateTime.Now,
            //        UpdateUserId = 1000,
            //        UserName = i.ToString()
            //    });
            //}

            //iUserBusiness.CreateEntityList(userList);

            return iUserBusiness.CreateEntity(user);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool UpdateUser(int id, [FromBody]User user)
        {
            user.Id = id;
            return iUserBusiness.UpdateEntity(user);
        }

        /// <summary>
        /// 根据主键Id删除一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return iUserBusiness.DeleteEntityById(id);
        }
    }
}