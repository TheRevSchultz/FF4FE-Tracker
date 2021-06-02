using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FF4FE_Tracker_and_Timer
{
    public partial class EnterFlags : Form
    {
        public EnterFlags()
        {
            InitializeComponent();
        }
        public static Dictionary<string, string> PresetFlags = new Dictionary<string, string>();
        public static List<string> presetFlagNames = new List<string>();
        public static string hiddenFlags = "Orandom:{0},quest,boss,char/req:{1}/win:{2}{3}";
        public static string hiddenFlagPart1 = "part1";
        public static string hiddenFlagPart2 = "part2";
        public static string hiddenFlagPart3 = "part3";
        public static string hiddenFlagPart4 = "/hidden";
        public static string feFlagSetup = string.Empty;


        private void EnterFlags_Load(object sender, EventArgs e)
        {
            #region Preset Flags
            if (PresetFlags.Count.ToString() == "0")
            {
                PresetFlags.Add("Hidden", "hidden");
                PresetFlags.Add("Push B To Jump 2021 Ladder Season 2", "O1:quest_forge/2:quest_tradepink/random:1,quest,char/req:all/win:crystal Kmain/summon/moon Pkey Cstandard/j:abilities Twildish Sstandard Bstandard/alt:gauntlet Nchars Etoggle Glife/sylph -kit:basic -kit2:trap -spoon -supersmith -pushbtojump");
                PresetFlags.Add("ZZ1 Evolved 2021 Ladder Season 2", "Orandom:5,boss,char/req:4/win:crystal Kmain/summon/moon Pkey Cstandard/distinct:5/nodupes/bye Tstandard/junk Sstandard Bstandard Nchars/key Etoggle/no:jdrops Glife/sylph -kit:cata -supersmith -vanilla:hobs");
                PresetFlags.Add("Supermarket Sweep 2021 Ladder Season 2", "Orandom:3/req:all/win:crystal Kmain Pshop Crelaxed/j:abilities Twild Swild/free/no:apples Bstandard/whyburn Nnone Etoggle Glife/sylph -spoon");
                PresetFlags.Add("CHero 2021 Ladder Season 2", "O1:quest_forge/2:quest_toroiatreasury/random:2/req:all/win:crystal Kmain/summon/moon Pkey Crelaxed/no:fusoya/j:abilities/nekkie/hero Tpro Sstandard Bstandard/alt:gauntlet/whichburn Nchars/key Etoggle Glife/sylph -kit:freedom -kit2:random -noadamants");
                PresetFlags.Add("Giant % 2021 Ladder Season 2", " Omode:classicgiant/win:game Kmain Pnone Crelaxed Twild/no:j Scabins/free Bstandard/whichburn Nnone Etoggle/no:jdrops Gdupe/mp/warp/life/sylph -kit:basic -noadamants -spoon -supersmith");
                PresetFlags.Add("Push B To Jump 2021 Ladder Season 1", "O1:quest_forge/2:quest_tradepink/random:1,quest,char/req:all/win:crystal Kmain/summon/moon Pkey Cstandard/j:abilities Twildish Sstandard Bstandard/alt:gauntlet Nchars Etoggle Glife/sylph -kit:basic -kit2:trap -spoon -supersmith -pushbtojump");
                PresetFlags.Add("Lali-Ho Bracket 2021 Ladder Season 1", "Omode:classicforge/1:quest_tradepink/2:quest_magnes/random:2,boss,char/req:4/win:crystal Kmain/summon/moon Pkey Cstandard/distinct:10/j:abilities/nekkie/nodupes/bye Tpro/maxtier:6 Sstandard/sell:0 Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:freedom -kit2:grabbag -kit3:money -noadamants -exp:noboost -vanilla:giant");
                PresetFlags.Add("Supermarket Sweep 2021 Ladder Season 1", "Orandom:3/req:all/win:crystal Kmain Pshop Crelaxed/j:abilities Twild Swild/free/no:apples Bstandard/whyburn Nnone Etoggle Glife/sylph -kit:loaded -kit2:random -spoon");
                PresetFlags.Add("CHero 2021 Ladder Season 1", "O1:quest_forge/2:quest_toroiatreasury/random:2/req:all/win:crystal Kmain/summon/moon Pkey Crelaxed/no:fusoya/j:abilities/nekkie/hero Tpro Sstandard Bstandard/alt:gauntlet/whichburn Nchars/key Etoggle Glife/sylph -kit:freedom -kit2:random -noadamants");
                PresetFlags.Add("Casual", "Onone Kmain Pshop Crelaxed Twild Swild Bstandard/whyburn Nnone Etoggle Gdupe/mp/warp/life/sylph/64 -spoon -vanilla:fusoya");
                PresetFlags.Add("Intermediate", "Onone Kmain Pshop Cstandard/j:abilities Twild Sstandard Bstandard/whyburn Nnone Etoggle Gdupe/mp/warp/life/sylph -spoon");
                PresetFlags.Add("Advanced", "Onone Kmain/summon/moon Pkey Cstandard/maybe/j:abilities Tstandard Sstandard Bstandard Nchars/key Etoggle Glife/sylph -vanilla:agility");
                PresetFlags.Add("2021 Lali-Ho Swiss", "O1:quest_forge/2:quest_tradepink/3:quest_magnes/random:2,boss,char/req:4/win:crystal Kmain/summon/moon Pkey Cstandard/distinct:10/j:abilities/nekkie/bye Twildish/maxtier:6 Sstandard/sell:quarter Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:basic -kit2:dwarf -noadamants -spoon -exp:noboost -vanilla:giant");
                PresetFlags.Add("2021 Lali-Ho Bracket", "Omode:classicforge/1:quest_tradepink/2:quest_magnes/random:2,boss,char/req:4/win:crystal Kmain/summon/moon Pkey Cstandard/distinct:10/j:abilities/nekkie/nodupes/bye Tpro/maxtier:6 Sstandard/sell:0 Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:freedom -kit2:grabbag -kit3:money -noadamants -exp:noboost -vanilla:giant");
                PresetFlags.Add("2020 HTT3Z League - Group", "O1:quest_forge/random:3,quest/req:3/win:crystal Kmain/summon/moon Pkey Crelaxed/maybe/no:fusoya/j:abilities/bye Twildish/sparse:60 Sstandard Bstandard/alt:gauntlet Nkey Etoggle/cantrun Gwarp/life/sylph -kit:basic -noadamants -spoon -vanilla:agility");
                PresetFlags.Add("2020 HTT3Z League - Table/Bracket", "O1:quest_forge/random:3,quest/req:3/win:crystal Kmain/summon/moon Pkey Cstandard/maybe/no:fusoya/j:abilities/permajoin Tpro/sparse:60 Spro Bstandard/alt:gauntlet Nkey Etoggle/cantrun/no:sirens Glife/sylph -kit:basic -noadamants -vanilla:agility");
                PresetFlags.Add("2020 Fabul Gauntlet Swiss", "Orandom:5/win:crystal Kmain/summon/moon Pkey Cstandard/j:abilities Tstandard Sstandard Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:basic -noadamants");
                PresetFlags.Add("2020 Fabul Gauntlet Bracket", "Orandom:5/win:crystal Kmain/summon/moon Pkey Cstandard/distinct:7/j:abilities/nodupes/bye Tpro Spro/sell:quarter Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:basic -noadamants");
                PresetFlags.Add("Underground Racing Club Season 2", "O1:quest_forge/2:quest_tradepink/3:quest_mistcave/4:quest_waterfall/5:quest_antlionnest/6:quest_fabul/random:2,quest/req:7/win:crystal Kmain/summon/moon Pkey Cstandard/maybe/j:abilities/bye Tstandard/sparse:80 Spro/quarter Bstandard/alt:gauntlet Nchars/key Etoggle/no:sirens Glife/sylph -kit:basic -spoon -vanilla:agility");
                PresetFlags.Add("Mysidian Jumping Club Season 2", "O1:quest_magma/2:quest_tradepink/random:2,quest,char/req:all/win:crystal Kmain/summon/moon/unsafe Pkey Cstandard/j:abilities/nodupes Twildish Sstandard/quarter Bstandard/unsafe/alt:gauntlet Nchars Etoggle Glife/sylph -kit:basic -spoon -pushbtojump");
                PresetFlags.Add("Lunar Racing Club Season 2", "O1:quest_ribbonaltar/2:quest_masamunealtar/random:2/win:crystal Kmain/summon/moon/unsafe Pkey Cstandard/distinct:7/j:abilities/nodupes Tpro/junk Scabins/free Bstandard/alt:gauntlet Nchars/key Etoggle Glife/sylph -kit:loaded -noadamants");

                presetFlagNames.AddRange(PresetFlags.Keys);
            }

            string[] tempPresets = new string[] { };
            tempPresets = presetFlagNames.ToArray();

            cbPresetFlags.Items.AddRange(tempPresets);

            #endregion
            txtFlags.Text = string.Empty;
        }

        private void cbPresetFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem.ToString() == "Hidden")
            {
                gbHidden.Enabled = true;
            }
            else
            {
                gbHidden.Enabled = false;
                txtFlags.Text = PresetFlags[cb.SelectedItem.ToString()];
            }
        }

        private void UpdateHiddenFlags()
        {
            if (hiddenFlags.Contains(@"{"))
            {
                if (hiddenFlagPart1 != "part1" && hiddenFlagPart2 != "part2" && hiddenFlagPart3 != "part3")
                {
                    hiddenFlags = String.Format(hiddenFlags, hiddenFlagPart1, hiddenFlagPart2, hiddenFlagPart3, hiddenFlagPart4);
                    txtFlags.Text = hiddenFlags;
                }
                else 
                { 
                    txtFlags.Text = "(hidden)"; 
                }
            }
            else
            {
                txtFlags.Text = hiddenFlags;
            }
        }

        private void cbObjCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            hiddenFlagPart1 = cb.SelectedItem.ToString();

            UpdateHiddenFlags();
        }

        private void cbReqCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            hiddenFlagPart2 = cb.SelectedItem.ToString();

            UpdateHiddenFlags();
        }

        private void cbWin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            hiddenFlagPart3 = cb.SelectedItem.ToString();

            UpdateHiddenFlags();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbPresetFlags.SelectedItem != null)
            {
                if (cbPresetFlags.SelectedItem.ToString() == "Hidden")
                {
                    UpdateHiddenFlags();
                    Tracker.flags = txtFlags.Text;
                }
                else
                {
                    Tracker.flags = txtFlags.Text;
                }
            }
            else
            {
                Tracker.flags = txtFlags.Text;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
