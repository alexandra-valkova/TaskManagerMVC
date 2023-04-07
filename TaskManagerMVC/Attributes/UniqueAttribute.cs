using DataAccess.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace TaskManagerMVC.Attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        public string Entity { get; set; }
        public string Repository { get; set; }

        public UniqueAttribute(string entity, string repository)
        {
            Entity = entity;
            Repository = repository;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get assembly and type of entity
            Assembly asm = Assembly.GetAssembly(typeof(BaseEntity));
            Type entityType = asm.GetType(Entity);

            // property of Entity
            PropertyInfo pi = entityType.GetProperty(validationContext.MemberName);

            // Expression: "entity"
            ParameterExpression parameter = Expression.Parameter(entityType, "entity");

            // Expression: "entity.PropertyName"
            MemberExpression lhs = Expression.MakeMemberAccess(parameter, pi);

            // Expression: "value"
            object convertedValue = Convert.ChangeType(value, pi.PropertyType);
            ConstantExpression rhs = Expression.Constant(convertedValue);

            // Expression: "entity.PropertyName == value"
            BinaryExpression equal = Expression.Equal(lhs, rhs);

            // ID

            // get type of model
            Type modelType = validationContext.ObjectInstance.GetType();

            // ID property of model
            PropertyInfo idModelProp = modelType.GetProperty("ID");
            object idValue = idModelProp.GetValue(validationContext.ObjectInstance);

            // ID property of entity
            PropertyInfo idEntity = entityType.GetProperty("ID");

            // Expression: "entity.ID"
            MemberExpression left = Expression.MakeMemberAccess(parameter, idEntity);

            // Expression: "<model.ID>"
            ConstantExpression right = Expression.Constant(idValue);

            // Expression: "entity.ID != <model.ID>"
            BinaryExpression notEqual = Expression.NotEqual(left, right);

            // Expression: "entity.PropertyName == value && entity.ID != <model.ID>"
            BinaryExpression expression = Expression.And(equal, notEqual);

            LambdaExpression lambda = Expression.Lambda(expression, parameter);

            Type repoType = asm.GetType(Repository);
            object repo = Activator.CreateInstance(repoType);

            object entity = repoType.GetMethod("GetFirst").Invoke(repo, new object[] { lambda });

            if (entity == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(string.Format("{0} already exists!", pi.Name), new string[] { pi.Name });
        }
    }
}