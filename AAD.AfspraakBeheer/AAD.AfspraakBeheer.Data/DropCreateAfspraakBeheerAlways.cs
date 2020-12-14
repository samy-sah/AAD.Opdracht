using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
   public class DropCreateAfspraakBeheerAlways : DropCreateDatabaseAlways<AfspraakBeheerContext>
    {
        protected override void Seed(AfspraakBeheerContext context)
        {
            base.Seed(context);
            AfspraakBeheerSeed.Seed(context);
        }
    }
}
