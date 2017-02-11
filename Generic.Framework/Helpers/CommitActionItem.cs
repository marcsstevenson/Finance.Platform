using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Helpers
{
    public class CommitActionItem
    {
        public CommitActionItem(IEntity entity, CommitAction commitAction)
        {
            this.Entity = entity;
            CommitAction = commitAction;
        }

        public IEntity Entity { get; set; }
        public CommitAction CommitAction { get; set; } 
    }
}
