using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Models
{
   public interface IChecked
    {
        int Index { get; }
        bool IsChecked { get; set; }
    }
}
