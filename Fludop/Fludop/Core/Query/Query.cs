using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Common.Extensions;
using Fludop.Core.Common.Models;
using Fludop.Core.Query.Commands.Enums;
using Fludop.Core.Query.Commands.Extensions;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;
using Fludop.Core.Tables.Conventions;
using Fludop.Core.Tables.Extensions;

namespace Fludop.Core.Query
{
    internal abstract class Query<TEntity> : 
        IWhereCommand<TEntity>
    {
        protected readonly StringBuilder _stringBuilder;
        public CommandEnum MainCommand { get; set; }
        public List<ConditionExpressionModel> WhereList { get; set; }   

        protected Query()
        {
            _stringBuilder = new StringBuilder();
        }

        public IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property)
        {
            if (WhereList == null)
                WhereList = new List<ConditionExpressionModel>();
            
            //TODO: Get list of condition expression
            MockWhere();

            return this;
        }

        public virtual string Build()
        {
            _stringBuilder.Append(MainCommand.GetMainCommand());
            return string.Empty;
        }

        protected void BuildWhere()
        {
            if (WhereList == null ||!WhereList.Any())
                return;

            _stringBuilder.Append(SqlPunctuationConst.Space);
            _stringBuilder.Append(SqlGrammarConst.Where);

            foreach(var whereCommand in WhereList)
            {
                _stringBuilder.Append(SqlPunctuationConst.Space);
                _stringBuilder.Append(whereCommand.Column);
                _stringBuilder.Append(whereCommand.Expression);
                _stringBuilder.Append(whereCommand.Value);

                if (!string.IsNullOrEmpty(whereCommand.Operator))
                {
                    _stringBuilder.Append(SqlPunctuationConst.Space);
                    _stringBuilder.Append(whereCommand.Operator);
                }
            }
        }

        protected string GetTableName()
        {
            var tableConvenction = new TableConvention<TEntity>();
            return tableConvenction.GetTableName();
        }

        protected void BuildSemicolon()
        {
            _stringBuilder.Append(SqlPunctuationConst.Semicolon);
        }

        private void MockWhere()
        {
            WhereList.Add(new ConditionExpressionModel()
            {
                Column = "Id",
                Expression = ">",
                Operator = "AND",
                Value = "3"
            });

            WhereList.Add(new ConditionExpressionModel()
            {
                Column = "Author",
                Expression = "=",
                Operator = "OR",
                Value = "Wojtek"
            });

            WhereList.Add(new ConditionExpressionModel()
            {
                Column = "Title",
                Expression = "=",
                Operator = null,
                Value = "Wojtek"
            });
        }
    }
}
