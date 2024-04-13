using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.DTO
{
    public enum SignStatus : byte
    {
        InProgress = 0,
        Completed = 1,
        Canceled = 2,
    }
}
