using System;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace TeklaGetBeams
{
    class Program
    {
        private static Model _model;

        static void Main(string[] args)
        {
            _model = new Model();

            var beams = GetBeams();

            foreach (var beam in beams)
            {
                Console.WriteLine(GetData(beam));
            }

            Console.ReadKey();
        }

        private static dynamic GetData(Beam beam)
        {
            return new
            {
                Id = beam.Identifier.ID,
                Guid = beam.Identifier.GUID,
                Name = beam.Name
            };
        }

        private static IEnumerable<Beam> GetBeams()
        {
            var enumerator = _model.GetModelObjectSelector()
                .GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM);

            var list = new List<Beam>();

            while (enumerator.MoveNext())
            {
                var beam = enumerator.Current as Beam;

                if (beam == null)
                    continue;
                
                list.Add(beam);
            }

            return list;
        }
    }
}
