using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Fludop.Core.Query.Commands.Interfaces;

namespace Fludop.Core.Query.Commands
{
    internal class UpdateQueryCommand<TEntity> : Query<TEntity>,
        IUpdateCommand<TEntity>,
        ISetCommand<TEntity>
    {
        public List<Dictionary<string, string>> SetList { get; set; }

        public ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value)
        {
            if (!SetList.Any())
                SetList = new List<Dictionary<string, string>>();


            
            return this;
        }

        public override string Build()
        {
            return _stringBuilder.ToString();
        }
    }     
}
