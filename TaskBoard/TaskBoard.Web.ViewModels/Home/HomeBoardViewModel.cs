using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Web.ViewModels.Home
{
    public class HomeBoardViewModel
    {
        public string BoardName { get; set; } = null!;

        public int TaskCount { get; set; }
    }
}
