using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public partial class Repository : IRepository
    {
        #region Attach
        public void Attach(Artist entity) { CurrentContext.Artists.Attach(entity); }
        public void Attach(Frame entity) { CurrentContext.Frames.Attach(entity); }
        public void Attach(Size entity) { CurrentContext.Sizes.Attach(entity); }
        public void Attach(Tag entity) { CurrentContext.Tags.Attach(entity); }
        #endregion
    }
}
