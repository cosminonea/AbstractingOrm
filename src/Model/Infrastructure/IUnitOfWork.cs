﻿namespace Model.Infrastructure
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
