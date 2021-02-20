using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Storages
{
    interface IStorage
    {
        int MaxCountCharacter { get;  } //максимальное количество символов на странице - зависит от формата листа

    }
}
