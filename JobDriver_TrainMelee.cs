using Verse.Sound;

namespace Rebels;

public class JobDriver_TrainMelee : JobDriver_WatchBuilding
{
    private const int PunchSoundInterval = 400;

    public override void WatchTickAction()
    {
        if (pawn.IsHashIntervalTick(PunchSoundInterval + UnityEngine.Random.Range(0, 100) - (pawn.skills.GetSkill(SkillDefOf.Melee).Level) * 10))
        {
            SoundInfo soundInfo = new TargetInfo(pawn.Position, pawn.Map);
            if (UnityEngine.Random.Range(0, 100) / 3 == 1)
                SoundDefOf.Pawn_Melee_Punch_Miss.PlayOneShot(soundInfo);
            else
                SoundDefOf.Pawn_Melee_Punch_HitPawn.PlayOneShot(soundInfo);
        }
        base.WatchTickAction();
    }
}