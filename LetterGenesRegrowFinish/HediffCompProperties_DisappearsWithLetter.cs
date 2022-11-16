using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LetterGenesRegrowFinish
{
    public class HediffCompProperties_DisappearsWithLetter : HediffCompProperties_Disappears
    {
        public HediffCompProperties_DisappearsWithLetter()
        {
            compClass = typeof(HediffComp_DisappearsWithLetter);
        }
    }

    public class HediffComp_DisappearsWithLetter : HediffComp_Disappears
    {
        public override void CompPostPostRemoved()
        {
            bool showOriginalMessage = ((Mod)LoadedModManager.GetMod<LGRFMod>()).GetSettings<LGRFSetting>().showOriginalMessage;
            bool sendLetter = ((Mod)LoadedModManager.GetMod<LGRFMod>()).GetSettings<LGRFSetting>().sendLetter;
            bool pause = ((Mod)LoadedModManager.GetMod<LGRFMod>()).GetSettings<LGRFSetting>().pause;
            bool debug = ((Mod)LoadedModManager.GetMod<LGRFMod>()).GetSettings<LGRFSetting>().debug;

            if (!Props.messageOnDisappear.NullOrEmpty() && PawnUtility.ShouldSendNotificationAbout(base.Pawn))
            {
                if (base.Def == HediffDefOf.XenogermReplicating)
                {
                    if (showOriginalMessage)
                    {
                        ShowMessage();
                    }
                    string labelShort = base.Pawn.LabelShort;
                    if (sendLetter)
                    {
                        TaggedString val2 = "LGRF_Letter_Label".Translate();
                        TaggedString val3 = "LGRF_Letter_Text".Translate(labelShort);
                        LookTargets val4 = new LookTargets(base.Pawn);
                        ChoiceLetter val5 = LetterMaker.MakeLetter(val2, val3, LetterDefOf.NeutralEvent, val4, (Faction)null, (Quest)null, (List<ThingDef>)null);
                        Find.LetterStack.ReceiveLetter((Letter)(object)val5, (string)null);
                    }
                    if (pause)
                    {
                        Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
                    }
                    if (debug)
                    {
                        Log.Message($"LetterGenesRegrowFinish: Pawn: {base.Pawn.LabelShort}, HediffDef. {base.Def.defName}");
                    }
                    return;
                }
                ShowMessage();
            }
        }

        private void ShowMessage()
        {
            Messages.Message(Props.messageOnDisappear.Formatted(base.Pawn.Named("PAWN")), base.Pawn, MessageTypeDefOf.PositiveEvent);
        }

    }
}