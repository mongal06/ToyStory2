﻿using Domain.Interfaces;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
    }
}