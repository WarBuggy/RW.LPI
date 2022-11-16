using UnityEngine;
using Verse;

namespace LetterGenesRegrowFinish
{
    public class LGRFMod : Mod
    {
        private readonly LGRFSetting LGRFSetting;

        public LGRFMod(ModContentPack content)
            : base(content)
        {
            LGRFSetting = base.GetSettings<LGRFSetting>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("LGRF_Option".Translate());
            listingStandard.CheckboxLabeled("LGRF_Option_Message".Translate(), ref LGRFSetting.showOriginalMessage);
            listingStandard.CheckboxLabeled("LGRF_Option_Letter".Translate(), ref LGRFSetting.sendLetter);
            listingStandard.CheckboxLabeled("LGRF_Option_Pause".Translate(), ref LGRFSetting.pause);
            listingStandard.CheckboxLabeled("LGRF_Option_Debug".Translate(), ref LGRFSetting.debug);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "LGRF_Option_Mod_Name".Translate();
        }
    }
}