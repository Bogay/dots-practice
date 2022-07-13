using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class UpdateHPBar : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((
                Component.HPBar hpBar,
                ref Translation translation,
                in Component.HP hp
            ) =>
            {
                hpBar.bar.transform.position = translation.Value + hpBar.offset;
                var ratio = (float)hp.Current / hp.Max;
                hpBar.bar.fillAmount = ratio;
            }).WithoutBurst().Run();
        }
    }
}
