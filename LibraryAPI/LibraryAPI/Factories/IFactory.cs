﻿namespace LibraryAPI.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}
