using RimWorld;
using Verse;

namespace LetterGenesRegrowFinish
{
    public class LGRFSetting : ModSettings
    {
        public bool showOriginalMessage;

        public bool sendLetter;

        public bool pause;

        public bool debug;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref showOriginalMessage, "alertColonist", true, false);
            Scribe_Values.Look(ref sendLetter, "alertPrisoner", true, false);
            Scribe_Values.Look(ref pause, "alertPet", true, false);
            Scribe_Values.Look(ref debug, "debug", false, false);
            base.ExposeData();
        }
    }
}
