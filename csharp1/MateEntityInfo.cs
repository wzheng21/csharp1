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
        public MateEntityInfo(int idx, Mate2 mate) 
        {
            this.mate = mate;
            this.entity = mate.MateEntity(idx);
            this.component = entity.ReferenceComponent;

            // Additional properties
            this.type = (swMateEntity2ReferenceType_e)entity.ReferenceType2;
            this.mate_type = (swMateType_e)mate.Type;
            this.mate_name = ((Feature)mate).Name;
            this.component_name = component.Name2;
            this.name = String.Format("Component_{0}-Mate_{1}-Entity_{2}",
                                      component_name, mate_name, idx);
        }

        public MateEntity2 entity { get; }

        public Mate2 mate { get; }

        public Component2 component { get; }

        public swMateEntity2ReferenceType_e type { get; }

        public swMateType_e mate_type { get; }

        public string name { get; }

        public string mate_name { get; }

        public string component_name { get; }
    }
}
