using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Query.Commands.Enums;
using Fludop.Core.Query.Commands.Extensions;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Commands.Models;
using Fludop.Core.Query.Consts;
using Fludop.Core.Tables.Extensions;

namespace Fludop.Core.Query
{
    internal abstract class Query<TEntity> : 
        IWhereCommand<TEntity>
    {
        protected readonly StringBuilder _stringBuilder;
        public CommandEnum MainCommand { get; set; }
        public string TableName { get; set; }
        public List<WhereModel> WhereList { get; set; }   

        protected Query()
        {
            _stringBuilder = new StringBuilder();
        }

        public IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value)
        {
            if (!WhereList.Any())
                WhereList = new List<WhereModel>();

            WhereList.Add(new WhereModel {
                Column = new Columns.Models.ColumnModel
                {
                    ColumnName = property.GetName()
                },
                Expression = null,
                Value = value
            });

            return this;
        }

        public virtual string Build()
        {
            _stringBuilder.Append(MainCommand.GetMainCommand());
            return string.Empty;
        }

        protected void BuildWhere()
        {
            if (!WhereList.Any())
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
    }
}
