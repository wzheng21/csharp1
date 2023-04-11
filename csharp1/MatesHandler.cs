using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace csharp1
{
    internal class MatesHandler
    {
        public MatesHandler(SldWorks app, string filename)
        {
            int errors = 0;
            int warnings = 0;
            model = (ModelDoc2)app.OpenDoc6(filename, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            entities = new Dictionary<string, MateEntityInfo>();
        }
        private ModelDoc2 model;
        private Feature mate_feature;
        private Dictionary<string, MateEntityInfo> entities;

        public void Run()
        {
            FindMateFeature();
            IterateOverMates();
        }

        // SolidWorks store mate related info as one of the features. This function goes through
        // features and find the mate feature
        private void FindMateFeature()
        {
            Console.WriteLine("Finding mate feature");
            Feature feature = (Feature)model.FirstFeature();
            while (feature != null) {
                if ("MateGroup" == feature.GetTypeName()) {
                    mate_feature = feature;
                    Console.WriteLine(String.Format("mate feature: {0}", mate_feature.Name));
                    break;
                }
                Console.WriteLine(String.Format("feature: {0}", feature.Name));
                feature = feature.GetNextFeature();
            }
            Console.WriteLine("Found mate feature\n\n");
        }

        // Iterate over all mates and entities and collect them in dictionary
        private void IterateOverMates() {
            Feature feature = mate_feature.GetFirstSubFeature();
            while (feature != null)
            {
                Mate2 mate = feature.GetSpecificFeature2();
                if (mate == null) continue;
                Console.WriteLine(String.Format("Feature name: {0}", feature.Name));
                int n_ent = mate.GetMateEntityCount();
                var mate_type = (swMateType_e)mate.Type;
                Feature mf = (Feature)mate;
                Console.WriteLine(String.Format("-- Mate name: {0}", mf.Name));
                Console.WriteLine(String.Format("-- Mate type str: {0}", mate_type.ToString()));
                Console.WriteLine(String.Format("-- MateEntityCount: {0}\n", n_ent));
                for (int i = 0; i < n_ent; i++)
                {
                    MateEntity2 ent = mate.MateEntity(i);
                    var info = new MateEntityInfo(i, mate);
                    entities[info.name] = info;
                    Console.WriteLine(String.Format("---- Entity {0}, name: {1}", i, entities[info.name].name));
                    Console.WriteLine(String.Format("---- Component name: {0}", entities[info.name].component_name));
                    Console.WriteLine(String.Format("---- Entity type str: {0}\n", entities[info.name].type.ToString()));
                }
                feature = feature.GetNextSubFeature();
            }
        }
    }
}
