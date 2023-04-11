using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace csharp1
{
    internal class MateEntityInfo
    {
        public MateEntityInfo(MateEntity2 entity) 
        {
            this.entity = entity;
            this.mate = entity.Reference;
            this.component = entity.ReferenceComponent;

            // Additional properties
            this.type = (swMateEntity2ReferenceType_e)entity.ReferenceType2;
            this.mate_type = (swMateType_e)mate.Type;
            this.name = entity.ToString();
        }

        public MateEntity2 entity { get; }

        public Mate2 mate { get; }

        public Component2 component { get; }

        public swMateEntity2ReferenceType_e type { get; }

        public swMateType_e mate_type { get; }

        public string name { get; }
    }
}
