using Dapper;
using IRepository;
using Model.TableModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
    /// <summary>
    /// 产品仓储
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public bool CreateEntity(Product entity, string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string insertSql = @"INSERT INTO [dbo].[Product]
                                           ([ProductName]
                                           ,[Brand]
                                           ,[ProductPrice]
                                           ,[CreateUserId]
                                           ,[CreateDate]
                                           ,[UpdateUserId]
                                           ,[UpdateDate]
                                           ,[IsDeleted])
                                     VALUES
                                           ( @ProductName
                                           ,@Brand
                                           ,@ProductPrice
                                           ,@CreateUserId
                                           ,@CreateDate
                                           ,@UpdateUserId
                                           ,@UpdateDate
                                           ,@IsDeleted)";
                return conn.Execute(insertSql, entity) > 0;
            }
        }

        /// <summary>
        /// 创建一个产品
        /// </summary>
        /// <param name="entity">产品</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntityList(IEnumerable<Product> entityList, string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string insertSql = @"INSERT INTO [dbo].[Product]
                                           ([ProductName]
                                           ,[Brand]
                                           ,[ProductPrice]
                                           ,[CreateUserId]
                                           ,[CreateDate]
                                           ,[UpdateUserId]
                                           ,[UpdateDate]
                                           ,[IsDeleted])
                                     VALUES
                                           (@ProductName
                                           ,@Brand
                                           ,@ProductPrice
                                           ,@CreateUserId
                                           ,@CreateDate
                                           ,@UpdateUserId
                                           ,@UpdateDate
                                           ,@IsDeleted)";
                return conn.Execute(insertSql, entityList) > 0;
            }
        }
        /// <summary>
        /// 根据主键Id删除一个产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool DeleteEntityById(int id, string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string deleteSql = @"DELETE FROM [dbo].[Product]
                                            WHERE [Id] = @Id";
                return conn.Execute(deleteSql, new { Id = id }) > 0;
            }
        }
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public IEnumerable<Product> RetriveAllEntity(string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string querySql = @"SELECT [Id]
                                            ,[ProductName]
                                           ,[Brand]
                                           ,[ProductPrice]
                                           ,[CreateUserId]
                                           ,[CreateDate]
                                           ,[UpdateUserId]
                                           ,[UpdateDate]
                                           ,[IsDeleted]
                                      FROM [dbo].[Product]";
                return conn.Query<Product>(querySql);
            }
        }

        /// <summary>
        /// 根据主键Id获取一个产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public Product RetriveOneEntityById(int id, string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string querySql = @"SELECT（[ProductName]
                                           ,[Brand]
                                           ,[ProductPrice]
                                           ,[CreateUserId]
                                           ,[CreateDate]
                                           ,[UpdateUserId]
                                           ,[UpdateDate]
                                           ,[IsDeleted])
                                      FROM [dbo].[Product]  WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Product>(querySql, new { Id = id });
            }
        }

        /// <summary>
        /// 修改一个产品
        /// </summary>
        /// <param name="entity">要修改的产品</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool UpdateEntity(Product entity, string connectionString = null)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(connectionString))
            {
                string updateSql = @"UPDATE [dbo].[Product]
                                       SET 
                                        [ProductName]=@ProductName
                                        ,[Brand]=@Brand
                                        ,[CreateUserId]=@CreateUserId
                                        ,[UpdateDate]=@UpdateDate
                                        ,[UpdateUserId]=@UpdateUserId
                                        ,[CreateDate]=@CreateDate
                                        ,[IsDeleted]=@IsDeleted  WHERE Id = @Id";
                return conn.Execute(updateSql, entity) > 0;
            }
        }
    }
}
