using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.DAL.Infra
{
    public interface IRepository:IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
