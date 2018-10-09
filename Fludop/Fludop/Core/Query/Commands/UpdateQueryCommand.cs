using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands
{
    internal class UpdateQueryCommand<TEntity> : Query<TEntity>,
        IUpdateCommand<TEntity>,
        ISetCommand<TEntity>
    {
        public Dictionary<string, string> SetList { get; set; }

        public ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property)
        {
            if (SetList == null || !SetList.Any())
                SetList = new Dictionary<string, string>();
            
            //TODO: Get set values
            MockSet();

            return this;
        }

        public override string Build()
        {
            base.Build();
            BuildSet();
            BuildWhere();
            BuildSemicolon();

            return _stringBuilder.ToString();
        }

        private void BuildSet()
        {
            if(!SetList.Any())
                return;

            foreach (var set in SetList)
            {
                _stringBuilder.Append(SqlPunctuationConst.Space);
                _stringBuilder.Append($"{set.Key}");
                _stringBuilder.Append(SqlPunctuationConst.Space);
                _stringBuilder.Append(SqlPunctuationConst.Equal);
                _stringBuilder.Append(SqlPunctuationConst.Space);
                _stringBuilder.Append($"{set.Value}");
                _stringBuilder.Append(SqlPunctuationConst.Comma);
            }

            _stringBuilder.Remove(_stringBuilder.Length - 1, 1);
        }

        private void MockSet()
        {
            SetList.Add("Author", "Wojtek");
            SetList.Add("Title", "Tytan");
        }
    }     
}
