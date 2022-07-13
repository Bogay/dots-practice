using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.UI;
using Unity.Mathematics;

namespace Bogay.VampireSurvivorLike.Component
{
    [Serializable]
    public class HPBar : IComponentData
    {
        public Image bar;
        public float3 offset;
    }
}