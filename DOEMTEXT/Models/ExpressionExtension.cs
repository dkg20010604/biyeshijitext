//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore.Internal;
//using System.Linq.Expressions;
//using System.Reflection;

//namespace DOEMTEXT.Models
//{
//    public class ExpressionExtension<T>
//    {
//        /// <summary>
//        /// 创建Expression
//        /// </summary>
//        /// <param name="left">字段名</param>
//        /// <param name="value">值</param>
//        /// <param name="entityOperator">比较符</param>
//        public static Expression CreateExpression(Expression left, Expression value, string entityOperator)
//        {
//            if (!Enum.TryParse(entityOperator, true, out OperatorEnum operatorEnum))
//            {
//                throw new ArgumentException("字段不存在，或类型错误");
//            }
//            return operatorEnum switch
//            {
//                OperatorEnum.Equals => Expression.Equal(left, Expression.Convert(value, left.Type)),
//                OperatorEnum.NotEqual => Expression.NotEqual(left, Expression.Convert(value, left.Type)),
//                OperatorEnum.Contains => Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), value),
//                OperatorEnum.StartsWith => Expression.Call(left, typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) }), value),
//                OperatorEnum.EndsWith => Expression.Call(left, typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) }), value),
//                OperatorEnum.Greater => Expression.GreaterThan(left, Expression.Convert(value, left.Type)),
//                OperatorEnum.GreaterEqual => Expression.GreaterThanOrEqual(left, Expression.Convert(value, left.Type)),
//                OperatorEnum.Less => Expression.LessThan(left, Expression.Convert(value, left.Type)),
//                OperatorEnum.LessEqual => Expression.LessThanOrEqual(left, Expression.Convert(value, left.Type)),
//                _ => Expression.Equal(left, Expression.Convert(value, left.Type)),
//            };
//        }
//        /// <summary>
//        /// 创建Expression<TDelegate>
//        /// </summary>
//        /// <param name="entity">查询实体</param>
//        /// <returns></returns>
//        public static Expression<Func<T, bool>> CreatExpressionDelegate(QueryEntity entity)
//        {
//            ParameterExpression Models = Expression.Parameter(typeof(T), "p");
//            Expression value = Models;
//            var entityvalue = entity.ColumnValue.Trim();
//            var TableName = entityvalue.Split('.');
//            foreach (var a in TableName)
//            {
//                value = Expression.Property(value, a.ToString());
//            }
//            Expression expression = Expression.Constant(ParseType(entity));
//            Expression body = CreateExpression(value, expression, entity.Operator);
//            var lambda = Expression.Lambda<Func<T, bool>>(body, Models);
//            return lambda;
//        }
//        /// <summary>
//        /// 转换类型
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        private static object ParseType(QueryEntity entity)
//        {
//            PropertyInfo property;

//            if (entity.ColumnValue.Contains('.'))
//            {
//                var TableName = entity.ColumnValue.Split('.');
//                property = typeof(T).GetProperty(TableName[0], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
//                foreach (var item in TableName.Skip(1))
//                {
//                    property = property.PropertyType.GetProperty(item, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
//                }
//            }
//            else
//            {
//                property = typeof(T).GetProperty(entity.ColumnValue, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
//            }
//            return Convert.ChangeType(entity.ColumnValue, property.PropertyType);
//        }



//        public Expression<Func<T, bool>> ExpressionMethod(List<QueryEntity> queryEntities)
//        {
//            if (queryEntities == null || queryEntities.Count < 1)
//            {
//                return p => true;
//            }
//            var expression_head = CreatExpressionDelegate(queryEntities[0]);
//            foreach (var item in queryEntities.Skip(1))
//            {
//                var expression = CreatExpressionDelegate(item);
//                InvocationExpression invocation = Expression.Invoke(expression_head, expression.Parameters.Cast<Expression>());
//                BinaryExpression binary;
//                //判断 and 还是 or
//                if (item.LogicalOperator.ToUpper().Equals("OR"))
//                {
//                    binary = Expression.Or(expression.Body, invocation);
//                }
//                else
//                {
//                    binary = Expression.And(expression.Body, invocation);
//                }
//                expression_head = Expression.Lambda<Func<T, bool>>(binary, expression.Parameters);
//            }
//            return expression_head;
//        }

//        /// <summary>
//        /// 查询实体
//        /// </summary>
//        public class QueryEntity
//        {
//            /// <summary>
//            /// 字段名称
//            /// </summary>
//            public string ColumnName { get; set; }

//            /// <summary>
//            /// 值
//            /// </summary>
//            public string ColumnValue { get; set; }

//            /// <summary>
//            /// 操作方法，对应OperatorEnum枚举类
//            /// </summary>
//            public string Operator { get; set; }

//            /// <summary>
//            /// 逻辑运算符，只支持AND、OR
//            /// </summary>
//            public string LogicalOperator { get; set; }
//        }
//        /// <summary>
//        /// 操作方法枚举
//        /// </summary>
//        public enum OperatorEnum
//        {
//            /// <summary>
//            /// 等于
//            /// </summary>
//            Equals,

//            /// <summary>
//            /// 不等于
//            /// </summary>
//            NotEqual,

//            /// <summary>
//            /// 包含
//            /// </summary>
//            Contains,

//            /// <summary>
//            /// 由什么开始
//            /// </summary>
//            StartsWith,

//            /// <summary>
//            /// 由什么结束
//            /// </summary>
//            EndsWith,

//            /// <summary>
//            /// 大于
//            /// </summary>
//            Greater,

//            /// <summary>
//            /// 大于等于
//            /// </summary>
//            GreaterEqual,

//            /// <summary>
//            /// 小于
//            /// </summary>
//            Less,

//            /// <summary>
//            /// 小于等于
//            /// </summary>
//            LessEqual,
//        }
//    }
//}
