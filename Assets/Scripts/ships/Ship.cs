using System;

namespace Ships
{
    public interface Ship
    {
        string Id { get; }

        void OnDamageRecived(bool isDeath);
    }
}

