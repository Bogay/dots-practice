using System;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{

    [Serializable]
    public struct Follow : IComponentData
    {
        public bool lockX;
        public bool lockY;
        public bool lockZ;
        // FIXME: workaround, use a LocalToWorld makes more sense
        public Entity target;
    }
}