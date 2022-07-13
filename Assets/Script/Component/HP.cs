using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Bogay.VampireSurvivorLike.Component
{
    [Serializable]
    public struct HP : IComponentData
    {
        public int Max;
        public int Current;
    }
}
