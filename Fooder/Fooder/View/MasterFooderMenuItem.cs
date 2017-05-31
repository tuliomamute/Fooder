using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.View.Views
{

    public class MasterFooderMenuItem
    {
        public MasterFooderMenuItem()
        {
            TargetType = typeof(MasterFooderDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
