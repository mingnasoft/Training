using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace codefirstfromdatabase
{
    class Program
    {
   
        static void Main(string[] args)
        {
         MyDBContext db = new MyDBContext();
          //直接调用视图
         var v = db.V_student_iPhone;
         foreach (var item in v)
         {
             Console.WriteLine(item.Name + " " + item.PhoneName);
                //
         }


         SqlParameter myParameter = new SqlParameter
         {
             ParameterName = "@Id",
             Value = 1,
             SqlDbType = SqlDbType.Int,
             Direction = ParameterDirection.Input//默认是 input
         };
         SqlParameter myParameter2 = new SqlParameter
         {
             ParameterName = "@outP1",
             Size=50,
             SqlDbType = SqlDbType.VarChar,
             Direction = ParameterDirection.Output
         };
         SqlParameter myParameter3 = new SqlParameter
         {
             ParameterName = "@outP2",
             Size = 50,
             SqlDbType = SqlDbType.VarChar,
             Direction = ParameterDirection.Output
         };
         //调用无参数且只有一个返回结果的存储过程实例
         var list1 = db.Database.SqlQuery<students>("exec P1", myParameter, myParameter2).ToList();
         //调用带传入参数且有一个返回结果的存储过程实例
         var list2 = db.Database.SqlQuery<students>("exec P2  @Id, @Id", myParameter, myParameter2, myParameter3).ToList();
       //调用带返回参数且只有一个返回结果的存储过程实例，用的是EF的自己的模式
       var list3 = db.Database.SqlQuery<students>("exec P3 @Id, @outP1 output", myParameter, myParameter2).ToList();
       //调用带返回参数且有多个返回结果的存储过程实例，这是自己写的扩展方法
       var list4 = db.Database.SqlQueryForStoredProcedure("P4", myParameter, myParameter2, myParameter3);


            
         Console.ReadLine();
        }
    }
}
