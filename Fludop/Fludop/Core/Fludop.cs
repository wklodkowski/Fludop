using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Common.Extensions;
using Fludop.Core.Query.Commands;
using Fludop.Core.Query.Commands.Enums;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;
using Fludop.Core.Tables.Conventions;
using Fludop.Core.Tables.Extensions;
using Fludop.Core.Tables.Models;

namespace Fludop.Core
{
    public static class Fludop
    {
        public static ISelectCommand<TEntity> Select<TEntity>()
            where TEntity : class
        {
            return Select<TEntity>(x => new { });
        }

        public static ISelectCommand<TEntity> Select<TEntity>(Expression<Func<TEntity, object>> columnObject)
            where TEntity : class
        {
            var query = new SelectQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Select
            };
            var columns = columnObject.GetNames();



            return query;
        }

        //public static ISelectCommand<TEntity> Select<TEntity>(Expression<Func<TEntity, object>> columnObject)
        //    where TEntity : class
        //{
        //    var query = new SelectQueryCommand<TEntity>();
        //    query.Type = CommandEnum.Select;
        //    //query.SelectColumns = 

        //    var queryModel = new List<string>();
        //    var columns = columnObject.GetType().GetProperties();
        //    queryModel.Add(SqlPunctuationConst.Space);

        //    if (columns.Length > 0)
        //    {
        //        foreach (var column in columns)
        //        {
        //            queryModel.Add(column.Name);
        //            queryModel.Add(SqlPunctuationConst.Comma);
        //            queryModel.Add(SqlPunctuationConst.Space);
        //        }
        //        queryModel.RemoveAt(queryModel.Count - 2);
        //    }
        //    else
        //    {
        //        queryModel.Add(SqlPunctuationConst.Asterisk);
        //    }

        //    var tableModel = GetTable<TEntity>(CommandEnum.Select, queryModel);

        //    //return new FludopBuilder<TEntity>(tableModel);
        //    return query;
        //}

        public static IInsertCommand<TEntity> Insert<TEntity>()
            where TEntity : class
        {
            return Insert<TEntity>(x => new {});
        }

        public static IInsertCommand<TEntity> Insert<TEntity>(Func<TEntity, object> columnObject)
            where TEntity : class
        {
            var query = new InsertQueryCommand<TEntity>();

            
            
            return query;
        }

        public static IUpdateCommand<TEntity> Update<TEntity>()
            where TEntity : class
        {
            var query = new UpdateQueryCommand<TEntity>();



            return query;
        }

        public static IDeleteCommand<TEntity> Delete<TEntity>()
            where TEntity : class
        {
            var query = new DeleteQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Delete
            };
            return query;
        }

        //private class FludopBuilder<TEntity> : ISelectCommand<TEntity>,
        //    IInsertCommand<TEntity>,
        //    IUpdateCommand<TEntity>,
        //    IDeleteCommand<TEntity>,
        //    IFromCommand<TEntity>,
        //    IWhereCommand<TEntity>,
        //    IValuesCommand,
        //    ISetCommand<TEntity>
        //{
        //    private readonly StringBuilder _stringBuilder;
        //    private readonly TableModel _tableModel;

        //    public FludopBuilder(TableModel tableModel)
        //    {
        //        _tableModel = tableModel;
        //        _stringBuilder = new StringBuilder();
        //    }

        //    public IFromCommand<TEntity> From()
        //    {
        //        Initialize();
        //        _stringBuilder.Append($"{SqlPunctuationConst.Space}{SqlGrammarConst.From}{SqlPunctuationConst.Space}{_tableModel.TableName}");
        //        return this;
        //    }

        //    public ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value)
        //    {
        //        Initialize();
        //        string setQuery = $"{SqlPunctuationConst.Space}{SqlGrammarConst.Set}{SqlPunctuationConst.Space}{property.GetName()}='{value}'{SqlPunctuationConst.Space}";
        //        _stringBuilder.Append(setQuery);
        //        return this;
        //    }

        //    public IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value)
        //    {
        //        string whereQuery = $"{SqlPunctuationConst.Space}{SqlGrammarConst.Where}{SqlPunctuationConst.Space}{property.GetName()}='{value}'";
        //        _stringBuilder.Append(whereQuery);
        //        return this;
        //    }

        //    public IValuesCommand Values(params string[] values)
        //    {
        //        Initialize();
        //        string valueQuery = $"{SqlPunctuationConst.Space}{SqlGrammarConst.Values}{SqlPunctuationConst.Space}{SqlPunctuationConst.OpenBracket}";
        //        _stringBuilder.Append(valueQuery);
        //        foreach (var value in values)
        //        {
        //            _stringBuilder.Append($"{value}{SqlPunctuationConst.Comma}{SqlPunctuationConst.Space}");
        //        }

        //        _stringBuilder.Remove(_stringBuilder.Length - 2, 2);
        //        _stringBuilder.Append(SqlPunctuationConst.CloseBracket);

        //        return this;
        //    }

        //    public string Build()
        //    {
        //        if (_tableModel.CommandEnum == CommandEnum.Select)
        //        {

        //        }

        //        _stringBuilder.Append(SqlPunctuationConst.Semicolon);
        //        var query = _stringBuilder.ToString();
        //        _stringBuilder.Clear();
        //        return query;
        //    }

        //    private void Initialize()
        //    {
        //        if (_stringBuilder.Length > 0)
        //            return;

        //        //_stringBuilder.Append(_tableModel.GetMainCommand());
        //        _stringBuilder.Append(_tableModel.GetQueryCommands());
        //    }
        //}
    }
}
