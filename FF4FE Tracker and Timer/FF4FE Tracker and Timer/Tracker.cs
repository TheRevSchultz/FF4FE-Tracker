﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace FF4FE_Tracker_and_Timer
{
    public partial class Tracker : Form
    {
        #region Global Variables
        public Dictionary<string, string> Objectives = new Dictionary<string, string>();
        public Dictionary<string, string> Flags = new Dictionary<string, string>();
        public int ObjectiveCount;
        public static string feFlagString;
        public static string randoObjective;
        public static string[] randoObjectives = new string[] { };
        public static List<string> randoObjectiveList = new List<string>();
        public static string tempFlag = string.Empty;
        public Stopwatch runClock = new Stopwatch();
        public bool requireAll = false;
        public string winCondition = string.Empty;
        public bool BeatZ = false;
        public static string flags = string.Empty;
        public static int ObjectiveNumber = -1;
        public static string ObjectiveName = string.Empty;
        public static List<String> tempflags = new List<String>();
        public static string flagSeries = string.Empty;
        public static List<string> gatedObjectives = new List<string>();
        public static List<string> questObjectives = new List<string>();
        public static List<string> bossObjectives = new List<string>();
        public static List<string> charObjectives = new List<string>();
        public static List<String> tempobjectives = new List<String>();
        public static int randoObjectiveCount;
        public static string flagvalue = string.Empty;
        #endregion
        public Tracker()
        {
            InitializeComponent();

        }
        #region Flag Parsing
        public string[] ParseFlags(string flags)
        {
            string[] feFlags = new string[] { };
            string delimitedflags = flags.Replace(" ", "/");
            feFlags = delimitedflags.Split('/') ;
            return feFlags;
        }

        public void ProcessFlags()
        {
            string[] feFlags = ParseFlags(feFlagString);
            string[] feObjectives = new string[] { };
            string[] feFlagsParsed = new string[] { };

            randoObjectiveList.Clear();

            foreach (string flag in feFlags)
            {
                string tempflag = string.Empty;

                if (flag.Substring(0, 1).Where(char.IsUpper).Any())
                {
                    flagSeries = flag.Substring(0, 1);
                }

                if (flag.Contains("hidden"))
                {
                    ProcessForHidden(flag);
                }
                else
                {
                    if( flagSeries == "K")
                    {
                        ProcessForUnsafe(flag);
                        if (flag == "nofree")
                        {
                            string kFlag = "Knofree";
                            ProcessOtherFlags(kFlag);
                        }
                        else
                        {
                            ProcessOtherFlags(flag);
                        }
                    }
                    else if (flagSeries == "B")
                    {
                        if (flag == "nofree")
                        {
                            string bFlag = "Bnofree";
                            ProcessOtherFlags(bFlag);
                        }
                        else
                        {
                            ProcessOtherFlags(flag);
                        }
                    }
                    else if (flagSeries == "O")
                    {
                        ProcessForObjectives(flag);
                    }
                    else if (flagSeries == "C")
                    {
                        if (flag.Length >= 5 && flag.Substring(0, 5) == "only:")
                        {
                            ProcessForOnly(flag);
                        }
                        else if (flag.Length >= 5 && flag.Substring(0, 3) == "no:")
                        {
                            ProcessForRemovedCharacters(flag);
                        }
                        else if (flag.Length >= 5 && flag.Substring(0, 3) == "restrict:")
                        {
                            ProcessForRestricted(flag);
                        }
                        else
                        {
                            ProcessOtherFlags(flag);
                        }
                    }
                    else
                    {
                        ProcessOtherFlags(flag);
                    }
                }
            }

            feObjectives = tempobjectives.ToArray();
            feFlagsParsed = tempflags.ToArray();

            clbObjectives.Items.AddRange(feObjectives);
            lbFlags.Items.AddRange(feFlagsParsed);
        }

        private void ProcessForHidden(string flag)
        {
            if (feFlagString == "(hidden)")
            {
                tempflags.Add(Flags[flag]);
                lblObjectives.Text = "Hidden Objectives";
            }
            else
            {
                tempflags.Add(Flags[flag]);
            }
        }

        private void ProcessForUnsafe(string flag)
        {
            if (flagSeries == "B" && flag == "unsafe")
            {
                tempflags.Add("Unsafe Bosses");
            }
            if (flagSeries == "K" && flag == "unsafe")
            {
                tempflags.Add("Unsafe Key Item Placement");
            }
        }

        private void ProcessForObjectives(string flag)
        {
            if (flag == "Onone")
            {
                tempobjectives.Add("No Objectives In Seed");
            }
            else if (flag.Contains("Omode"))
            {
                tempFlag = flag.Substring(flag.IndexOf(@":") + 1);

                if (tempFlag.Contains(","))
                {
                    List<string> classicmodes = new List<string>();

                    classicmodes = tempFlag.Split(',').ToList();
                    foreach (string mode in classicmodes)
                    {
                        tempobjectives.Add(Objectives[mode]);
                    }
                }
                else if (tempFlag.Contains("fiends"))
                {
                    tempobjectives.Add(Objectives["boss_milon"]);
                    tempobjectives.Add(Objectives["boss_milonz"]);
                    tempobjectives.Add(Objectives["boss_kainazzo"]);
                    tempobjectives.Add(Objectives["boss_valvalis"]);
                    tempobjectives.Add(Objectives["boss_rubicant"]);
                    tempobjectives.Add(Objectives["boss_elements"]);
                }
                else
                {
                    tempobjectives.Add(Objectives[tempFlag]);
                }
            }
            else if ((flag.Length >= 6 && flag.Substring(0, 6) == "random") || ((flag.Length >= 7 && flag.Substring(0, 7) == "Orandom")))
            {
                int count = 1;
                if (flag.Substring(0, 1) == "O")
                {
                    randoObjectiveCount = Int32.Parse(flag.Substring(8, 1));
                }
                else
                {
                    randoObjectiveCount = Int32.Parse(flag.Substring(7, 1));
                }
                while (count <= randoObjectiveCount)
                {
                    tempobjectives.Add("Random Objective " + count.ToString());
                    count++;
                }

                List<string> objectiveFlags = new List<string>();

                objectiveFlags = flag.Split(',').ToList();
                questObjectives = Objectives.Where(d => d.Key.Contains("quest") && !d.Key.Contains("gated")).ToDictionary(d => d.Key, d => d.Value).Values.ToList();
                charObjectives = Objectives.Where(d => d.Key.Contains("char")).ToDictionary(d => d.Key, d => d.Value).Values.ToList();
                bossObjectives = Objectives.Where(d => d.Key.Contains("boss")).ToDictionary(d => d.Key, d => d.Value).Values.ToList();
                gatedObjectives = Objectives.Where(d => d.Key.Contains("gated")).ToDictionary(d => d.Key, d => d.Value).Values.ToList();

                foreach (string objective in objectiveFlags)
                {
                    if (objective.Contains("quest") && !objective.Contains("gated") && !objective.Contains("tough"))
                    {
                        foreach (string quest in questObjectives)
                        {
                            if (!randoObjectiveList.Contains(quest))
                            {
                                randoObjectiveList.Add(quest);
                            }
                        }
                    }
                    else if (objective.Contains("char"))
                    {
                        foreach (string character in charObjectives)
                        {
                            if (!randoObjectiveList.Contains(character))
                            {
                                randoObjectiveList.Add(character);
                            }
                        }
                    }
                    else if (objective.Contains("boss"))
                    {
                        foreach (string boss in bossObjectives)
                        {
                            if (!randoObjectiveList.Contains(boss))
                            {
                                randoObjectiveList.Add(boss);
                            }
                        }
                    }
                    else if (objective.Contains("gated_quest") || objective.Contains("tough_quest"))
                    {
                        foreach (string gated in gatedObjectives)
                        {
                            if (!randoObjectiveList.Contains(gated))
                            {
                                randoObjectiveList.Add(gated);
                            }
                        }
                    }
                    else if (objectiveFlags.Count == 1)
                    {
                        foreach (string quest in questObjectives)
                        {
                            if (!randoObjectiveList.Contains(quest))
                            {
                                randoObjectiveList.Add(quest);
                            }
                        }
                        foreach (string character in charObjectives)
                        {
                            if (!randoObjectiveList.Contains(character))
                            {
                                randoObjectiveList.Add(character);
                            }
                        }
                        foreach (string boss in bossObjectives)
                        {
                            if (!randoObjectiveList.Contains(boss))
                            {
                                randoObjectiveList.Add(boss);
                            }
                        }
                    }
                }
            }
            else if (flag.Substring(0, 2) == "O1" || flag.Substring(0, 1).All(char.IsDigit))
            {
                if (flag.Substring(0, 2) != "64")
                {
                    flagvalue = flag.Substring(flag.IndexOf(@":") + 1);
                    tempobjectives.Add(Objectives[flagvalue]);
                }
            }
            else if (flag.Length >= 3 && flag.Substring(0, 3) == "req")
            {
                if (flag.Substring(flag.IndexOf(@":") + 1) == "all")
                {
                    ObjectiveCount = tempobjectives.Count;
                    requireAll = true;
                }
                else
                {
                    ObjectiveCount = Int32.Parse(flag.Substring(flag.IndexOf(@":") + 1));
                }
            }
            else if (flag == "win:crystal")
            {
                tempobjectives.Add("Defeat Zeromus");
                winCondition = "Zeromus";

                if (!feFlagString.Contains("req") || requireAll)
                {
                    lblObjectives.Text = string.Format("Objectives: Require All to get the Crystal and defeat Zeromus.");
                }
                else
                {
                    lblObjectives.Text = string.Format("Objectives: Require {0} to get the Crystal and defeat Zeromus.", ObjectiveCount.ToString());
                }
            }
            else if (flag == "win:game")
            {
                winCondition = "Game";

                if (!feFlagString.Contains("req") || requireAll)
                {
                    lblObjectives.Text = string.Format("Objectives: Require All to Win the Game");
                }
                else
                {
                    lblObjectives.Text = string.Format("Objectives: Require {0} to Win the Game", ObjectiveCount.ToString());
                }
            }
            
        }

        private void ProcessForOnly(string flag)
        {
            List<string> tempConly = new List<string>();
            List<string> parsedConly = new List<string>();
            tempConly = flag.Split(',').ToList();
            int startPool = 0;

            foreach (string only in tempConly)
            {
                if (only.Length >= 5 && only.Substring(0, 5) == "only:")
                {
                    parsedConly.Add(Flags[only]);
                }
                else if (only.Length >= 5 && only.Contains("start:") && !only.Contains("not"))
                {
                    startPool = 1;
                    int flagIndex = only.IndexOf(":");
                    string tempCharFlag = "start:" + only.Substring(flagIndex + 1);
                    parsedConly.Add(Flags[tempCharFlag]);
                }
                else
                {
                    if (startPool == 1 && !only.Contains("not"))
                    {
                        int flagIndex = only.IndexOf(":");
                        string tempCharFlag = "start:" + only.Substring(flagIndex + 1);
                        parsedConly.Add(Flags[tempCharFlag]);
                    }
                    else
                    {
                        if (!only.Contains("not"))
                        {
                            parsedConly.Add(Flags["only:" + only]);
                        }
                        
                    }
                    
                }
            }
            startPool = 0;
            tempflags.AddRange(parsedConly);
        }

        private void ProcessForRestricted(string flag)
        {
            List<string> tempRestricted = new List<string>();
            List<string> parsedConly = new List<string>();
            tempRestricted = flag.Split(',').ToList();
            int startPool = 0;

            foreach (string only in tempRestricted)
            {
                if (only.Length >= 5 && only.Substring(0, 9) == "restrict:")
                {
                    parsedConly.Add(Flags[only]);
                }
                else if (only.Length >= 5 && only.Contains("restrict:"))
                {
                    startPool = 1;
                    int flagIndex = only.IndexOf(":");
                    string tempCharFlag = "restrict:" + only.Substring(flagIndex + 1);
                    parsedConly.Add(Flags[tempCharFlag]);
                }
            }
            startPool = 0;
            tempflags.AddRange(parsedConly);
        }
        private void ProcessForRemovedCharacters(string flag)
        {
            List<string> tempCno = new List<string>();
            List<string> parsedCno = new List<string>();
            tempCno = flag.Split(',').ToList();
            int startExclude = 0;
            string tempCharFlag = string.Empty;

            foreach (string no in tempCno)
            {
                tempCharFlag = string.Empty;
                if (no.Length > 5 && no.Substring(0,6) == "start:")
                {
                    startExclude = 1;
                }

                if (no.Length >= 5 && no.Substring(0, 3) == "no:")
                {
                    tempCharFlag = no;
                }
                else if (no.Length >= 6 && (no.Substring(0,6) == "start:" && no.Contains("not")))
                {
                    int flagIndex = no.IndexOf(":");
                    tempCharFlag = "start:" + no.Substring(flagIndex + 1);
                }
                else if (no.Length >= 5 && no.Substring(0, 3) == "not")
                {
                    int flagIndex = no.IndexOf(":");
                    tempCharFlag = "start:" + no.Substring(flagIndex + 1);
                }
                else
                {
                    if (startExclude == 0 && !no.Contains("start:") && no.Substring(0, 3) != "not")
                    {
                        tempCharFlag = "no:" + no;
                    }
                }
                if (tempCharFlag != string.Empty)
                {
                    parsedCno.Add(Flags[tempCharFlag]);
                }
            }
            startExclude = 0;
            tempflags.AddRange(parsedCno);
        }

        private void ProcessOtherFlags(string flag)
    {
        if (flag.Contains("-vanilla:"))
        {
            List<String> tempvanillaflags = new List<String>();
            tempvanillaflags = flag.Split(',').ToList<String>();

            foreach (string vanilla in tempvanillaflags)
            {
                tempflags.Add(Flags[vanilla]);
            }
        }
        else if (flag.Contains("start:"))
            {
                ProcessForOnly(flag);
                ProcessForRemovedCharacters(flag);
            }
        else
        {
            if (flag != "unsafe")
            {
                tempflags.Add(Flags[flag]);
            }
        }
    }
        #endregion
        
        private void Tracker_Load(object sender, EventArgs e)
        {
            #region Add Character Objectives
            Objectives.Add("char_cecil", "Get Cecil");
            Objectives.Add("char_cid", "Get Cid");
            Objectives.Add("char_edge", "Get Edge");
            Objectives.Add("char_edward", "Get Edward");
            Objectives.Add("char_fusoya", "Get FuSoYa");
            Objectives.Add("char_kain", "Get Kain");
            Objectives.Add("char_palom", "Get Palom");
            Objectives.Add("char_porom", "Get Porom");
            Objectives.Add("char_rosa", "Get Rosa");
            Objectives.Add("char_rydia", "Get Rydia");
            Objectives.Add("char_tellah", "Get Tellah");
            Objectives.Add("char_yang", "Get Yang");
            #endregion

            #region Add Boss Hunt Objectives
            Objectives.Add("boss_antlion", "Defeat Antlion");
            Objectives.Add("boss_asura", "Defeat Asura");
            Objectives.Add("boss_bahamut", "Defeat Bahamut");
            Objectives.Add("boss_baigan", "Defeat Baigan");
            Objectives.Add("boss_calbrena", "Defeat Calbrena");
            Objectives.Add("boss_cpu", "Defeat CPU");
            Objectives.Add("boss_dknight", "Defeat Dark Knight Cecil");
            Objectives.Add("boss_mirrorcecil", "Defeat Dark Knight Cecil");
            Objectives.Add("boss_dmist", "Defeat Mist Dragon");
            Objectives.Add("boss_lugae", "Defeat Dr. Lugae");
            Objectives.Add("boss_elements", "Defeat Elements");
            Objectives.Add("boss_evilwall", "Defeat EvilWall");
            Objectives.Add("boss_golbez", "Defeat Golbez");
            Objectives.Add("boss_kingqueen", "Defeat K.Eblan and Q.Eblan");
            Objectives.Add("boss_kainazzo", "Defeat Kainazzo");
            Objectives.Add("boss_karate", "Defeat Karate");
            Objectives.Add("boss, leviatan", "Defeat Leviathan");
            Objectives.Add("boss_milon", "Defeat Milon");
            Objectives.Add("boss_milonz", "Defeat Milon Z.");
            Objectives.Add("boss_mombomb", "Defeat MomBomb");
            Objectives.Add("boss_octomamm", "Defeat Octomamm");
            Objectives.Add("boss_odin", "Defeat Odin");
            Objectives.Add("boss_officer", "Defeat Officer");
            Objectives.Add("boss_ogopogo", "Defeat Ogopogo");
            Objectives.Add("boss_paledim", "Defeat Pale Dim");
            Objectives.Add("boss_plague", "Defeat Plague");
            Objectives.Add("boss_rubicant", "Defeat Rubicant");
            Objectives.Add("boss_dlunar", "Defeat the Lunar Dragons");
            Objectives.Add("boss_darkelf", "Defeat the Dark Elf (dragon form)");
            Objectives.Add("boss_darkimp", "Defeat the Dark Imps (boss)");
            Objectives.Add("boss_fabulgauntlet", "Defeat the Fabul Gauntlet");
            Objectives.Add("boss_guard", "Defeat the Guards (boss)");
            Objectives.Add("boss_magus", "Defeat the Magus Sisters");
            Objectives.Add("boss_valvalis", "Defeat Valvalis");
            Objectives.Add("boss_waterhag", "Defeat Waterhag (boss version)");
            Objectives.Add("boss_wyvern", "Defeat Wyvern");
            #endregion

            #region Add Quest Objectives
            Objectives.Add("quest_music", "Break the Dark Elfs Spell with the TwinHarp");
            Objectives.Add("quest_burnmist", "Burn village Mist with the Package");
            Objectives.Add("quest_cavebahamut", "Complete Cave Bahamut");
            Objectives.Add("quest_magnes", "Complete Cave Magnes");
            Objectives.Add("quest_ordeals", "Complete Mt. Ordeals");
            Objectives.Add("quest_antlionnest", "Complete the Antlion Nest");
            Objectives.Add("quest_giant", "Complete the Giant of Bab-il");
            Objectives.Add("quest_sealedcave", "Complete the Sealed Cave");
            Objectives.Add("quest_zot", "Complete the Tower of Zot");
            Objectives.Add("quest_crystalaltar", "Conquer the vanilla Crystal Sword altar");
            Objectives.Add("quest_masamunealtar", "Conquer the vanilla Masamune altar");
            Objectives.Add("quest_murasamealtar", "Conquer the vanilla Murasame altar");
            Objectives.Add("quest_ribbonaltar", "Conquer the vanilla Ribbon room");
            Objectives.Add("quest_whitealtar", "Conquer the vanilla White Spear altar");
            Objectives.Add("quest_curefever", "Cure the fever with the SandRuby");
            Objectives.Add("quest_baronbasement", "Defeat the Baron Castle Basement Throne");
            Objectives.Add("quest_lowerbabil", "Defeat the boss of Lower Bab-il");
            Objectives.Add("quest_mistcave", "Defeat the boss of the Mist Cave");
            Objectives.Add("quest_waterfall", "Defeat the boss of the Waterfall");
            Objectives.Add("quest_baroninn", "Defeat the bosses of Baron Inn");
            Objectives.Add("quest_dwarfcastle", "Defeat the bosses of Dwarf Castle");
            Objectives.Add("quest_monsterking", "Defeat the King at the Town of Monsters");
            Objectives.Add("quest_monsterqueen", "Defeat the Queen at the Town of Monsters");
            Objectives.Add("quest_fabul", "Defend Fabul");
            Objectives.Add("quest_supercannon", "Destroy the Super Cannon");
            Objectives.Add("quest_magma", "Drop the Magma Key into the Agart well");
            Objectives.Add("quest_forge", "Have Kokkol Forge Legend Sword");
            Objectives.Add("quest_launchfalcon", "Launch the Falcon");
            Objectives.Add("quest_falcon", "Launch the Falcon");
            Objectives.Add("quest_baroncastle", "Liberate Baron Castle");
            Objectives.Add("quest_toroiatreasury", "Open the Toroia Treasury with Earth Crystal");
            Objectives.Add("quest_bigwhale", "Raise the Big Whale");
            Objectives.Add("quest_hobs", "Rescue the hostage on Mt. Hobs");
            Objectives.Add("quest_tradepan", "Return the Pan to Yang's wife");
            Objectives.Add("quest_tradepink", "Trade away the Pink Tail");
            Objectives.Add("quest_traderat", "Trade away the Rat Tail");
            Objectives.Add("quest_pass", "Unlock the Pass door in Toroia");
            Objectives.Add("quest_unlocksealedcave", "Unlock the Sealed Cave");
            Objectives.Add("quest_unlocksewer", "Unlock the sewer with the Baron Key");
            Objectives.Add("quest_wakeyang", "Wake Yang with the Pan");
            Objectives.Add("classicforge", "Have Kokkol Forge Crystal");
            Objectives.Add("classicgiant", "Required Giant of Bab-Il (No Character Reward)");
            Objectives.Add("dkmatter", "Deliver 30 Dark Matters to Kory in Agart");


            #endregion

            #region Add Gated Objectives
            Objectives.Add("gated_music", "Break the Dark Elfs Spell with the TwinHarp");
            Objectives.Add("gated_burnmist", "Burn village Mist with the Package");
            Objectives.Add("gated_cavebahamut", "Complete Cave Bahamut");
            Objectives.Add("gated_magnes", "Complete Cave Magnes");
            Objectives.Add("gated_giant", "Complete the Giant of Bab-il");
            Objectives.Add("gated_sealedcave", "Complete the Sealed Cave");
            Objectives.Add("gated_zot", "Complete the Tower of Zot");
            Objectives.Add("gated_crystalaltar", "Conquer the vanilla Crystal Sword altar");
            Objectives.Add("gated_masamunealtar", "Conquer the vanilla Masamune altar");
            Objectives.Add("gated_murasamealtar", "Conquer the vanilla Murasame altar");
            Objectives.Add("gated_ribbonaltar", "Conquer the vanilla Ribbon room");
            Objectives.Add("gated_whitealtar", "Conquer the vanilla White Spear altar");
            Objectives.Add("gated_curefever", "Cure the fever with the SandRuby");
            Objectives.Add("gated_baronbasement", "Defeat the Baron Castle Basement Throne");
            Objectives.Add("gated_lowerbabil", "Defeat the boss of Lower Bab-il");
            Objectives.Add("gated_dwarfcastle", "Defeat the bosses of Dwarf Castle");
            Objectives.Add("gated_monsterking", "Defeat the King at the Town of Monsters");
            Objectives.Add("gated_monsterqueen", "Defeat the Queen at the Town of Monsters");
            Objectives.Add("gated_supercannon", "Destroy the Super Cannon");
            Objectives.Add("gated_magma", "Drop the Magma Key into the Agart well");
            Objectives.Add("gated_forge", "Have Kokkol Forge Legend Sword");
            Objectives.Add("gated_launchfalcon", "Launch the Falcon");
            Objectives.Add("gated_falcon", "Launch the Falcon");
            Objectives.Add("gated_baroncastle", "Liberate Baron Castle");
            Objectives.Add("gated_toroiatreasury", "Open the Toroia Treasury with Earth Crystal");
            Objectives.Add("gated_bigwhale", "Raise the Big Whale");
            Objectives.Add("gated_tradepan", "Return the Pan to Yang's wife");
            Objectives.Add("gated_tradepink", "Trade away the Pink Tail");
            Objectives.Add("gated_traderat", "Trade away the Rat Tail");
            Objectives.Add("gated_unlocksealedcave", "Unlock the Sealed Cave");
            Objectives.Add("gated_unlocksewer", "Unlock the sewer with the Baron Key");
            Objectives.Add("gated_wakeyang", "Wake Yang with the Pan");
            #endregion

            #region Add Flag Definitions
            Flags.Add("hidden", "Hidden Flags");
            Flags.Add("(hidden)", "Hidden Flags");

            #region Character Flags
            Flags.Add("Cvanilla", "No Character Randomization");
            Flags.Add("Cstandard", "Standard Character Randomization");
            Flags.Add("Crelaxed", "Relaxed Character Randomization");
            Flags.Add("Cnoearned", "No Characters At Non-Free Spots");
            Flags.Add("Cnofree", "No Free Characters");
            Flags.Add("noearned", "No Characters At Non-Free Spots");
            Flags.Add("maybe", "No Character Appearance Guarantee");
            Flags.Add("distinct:1", "Limit to 1 Distinct Character");
            Flags.Add("distinct:2", "Limit to 2 Distinct Characters");
            Flags.Add("distinct:3", "Limit to 3 Distinct Characters");
            Flags.Add("distinct:4", "Limit to 4 Distinct Characters");
            Flags.Add("distinct:5", "Limit to 5 Distinct Characters");
            Flags.Add("distinct:6", "Limit to 6 Distinct Characters");
            Flags.Add("distinct:7", "Limit to 7 Distinct Characters");
            Flags.Add("distinct:8", "Limit to 8 Distinct Characters");
            Flags.Add("distinct:9", "Limit to 9 Distinct Characters");
            Flags.Add("distinct:10", "Limit to 10 Distinct Characters");
            Flags.Add("distinct:11", "Limit to 11 Distinct Characters");
            Flags.Add("start:cecil", "Starting Character May Be: Cecil");
            Flags.Add("start:rosa", "Starting Character May Be: Rosa");
            Flags.Add("start:kain", "Starting Character May Be: Kain");
            Flags.Add("start:rydia", "Starting Character May Be: Rydia");
            Flags.Add("start:palom", "Starting Character May Be: Palom");
            Flags.Add("start:porom", "Starting Character May Be: Porom");
            Flags.Add("start:tellah", "Starting Character May Be: Tellah");
            Flags.Add("start:edward", "Starting Character May Be: Edward");
            Flags.Add("start:yang", "Starting Character May Be: Yang");
            Flags.Add("start:edge", "Starting Character May Be: Edge");
            Flags.Add("start:fusoya", "Starting Character May Be: FuSoYa");
            Flags.Add("start:cid", "Starting Character May Be: Cid");
            Flags.Add("start:any", "Starting Character May Be: Any");
            Flags.Add("start:not_cecil", "Starting Character Cannot Be: Cecil");
            Flags.Add("start:not_rosa", "Starting Character Cannot Be: Rosa");
            Flags.Add("start:not_kain", "Starting Character Cannot Be: Kain");
            Flags.Add("start:not_rydia", "Starting Character Cannot Be: Rydia");
            Flags.Add("start:not_palom", "Starting Character Cannot Be: Palom");
            Flags.Add("start:not_porom", "Starting Character Cannot Be: Porom");
            Flags.Add("start:not_tellah", "Starting Character Cannot Be: Tellah");
            Flags.Add("start:not_edward", "Starting Character Cannot Be: Edward");
            Flags.Add("start:not_yang", "Starting Character Cannot Be: Yang");
            Flags.Add("start:not_edge", "Starting Character Cannot Be: Edge");
            Flags.Add("start:not_fusoya", "Starting Character Cannot Be: FuSoYa");
            Flags.Add("start:not_cid", "Starting Character Cannot Be: Cid");
            Flags.Add("restrict:cecil", "Restricted Character: Cecil");
            Flags.Add("restrict:rosa", "Restricted Character: Rosa");
            Flags.Add("restrict:kain", "Restricted Character: Kain");
            Flags.Add("restrict:rydia", "Restricted Character: Rydia");
            Flags.Add("restrict:palom", "Restricted Character: Palom");
            Flags.Add("restrict:porom", "Restricted Character: Porom");
            Flags.Add("restrict:tellah", "Restricted Character: Tellah");
            Flags.Add("restrict:edward", "Restricted Character: Edward");
            Flags.Add("restrict:yang", "Restricted Character: Yang");
            Flags.Add("restrict:edge", "Restricted Character: Edge");
            Flags.Add("restrict:fusoya", "Restricted Character: FuSoYa");
            Flags.Add("restrict:cid", "Restricted Character: Cid");
            Flags.Add("bye", "Permanently Dismiss Characters");
            Flags.Add("nodupes", "Only Unique Characters");
            Flags.Add("permajoin", "Permanently Joined Characters");
            Flags.Add("permadeath", "Permanently Remove Characters When Dead After Battle");
            Flags.Add("permadeader", "Permanently Remove Characters When Dead After Battle or Cutscene");
            Flags.Add("hero", "Starting Character is the Hero(AGI Anchor, Solo Ordeals)");
            Flags.Add("party:1", "Party Size Restriction to 1 Character");
            Flags.Add("party:2", "Party Size Restriction to 2 Characters");
            Flags.Add("party:3", "Party Size Restriction to 3 Characters");
            Flags.Add("party:4", "Party Size Restriction to 4 Characters");
            Flags.Add("j:abilities", "Japan Edition Abilities");
            Flags.Add("j:spells, abilities", "Japan Edition Spells and Abilities");
            Flags.Add("j:spells", "Japan Edition Spells");
            Flags.Add("only:cecil", "Include Character: Cecil");
            Flags.Add("only:rosa", "Include Character: Rosa");
            Flags.Add("only:kain", "Include Character: Kain");
            Flags.Add("only:rydia", "Include Character: Rydia");
            Flags.Add("only:palom", "Include Character: Palom");
            Flags.Add("only:porom", "Include Character: Porom");
            Flags.Add("only:tellah", "Include Character: Tellah");
            Flags.Add("only:edward", "Include Character: Edward");
            Flags.Add("only:yang", "Include Character: Yang");
            Flags.Add("only:edge", "Include Character: Edge");
            Flags.Add("only:fusoya", "Include Character: FuSoYa");
            Flags.Add("only:cid", "Include Character: Cid");
            Flags.Add("no:cecil", "Exclude Character: Cecil");
            Flags.Add("no:rosa", "Exclude Character: Rosa");
            Flags.Add("no:kain", "Exclude Character: Kain");
            Flags.Add("no:rydia", "Exclude Character: Rydia");
            Flags.Add("no:palom", "Exclude Character: Palom");
            Flags.Add("no:porom", "Exclude Character: Porom");
            Flags.Add("no:tellah", "Exclude Character: Tellah");
            Flags.Add("no:edward", "Exclude Character: Edward");
            Flags.Add("no:yang", "Exclude Character: Yang");
            Flags.Add("no:edge", "Exclude Character: Edge");
            Flags.Add("no:fusoya", "Exclude Character: FuSoYa");
            Flags.Add("no:cid", "Exclude Character: Cid");
            Flags.Add("nekkie", "Random Low Level Weapon, No Armor (Nekkie!)");
            #endregion

            #region Key Item Flags
            Flags.Add("Kvanilla", "Vanilla Key Items");
            Flags.Add("Knofree", "No Free Key Item");
            Flags.Add("Kmain", "Key Item Randomization");
            Flags.Add("Kforce:magma", "Guaranteed Magma Route");
            Flags.Add("Kforce:hook", "Guaranteed Hook Route");
            Flags.Add("force:magma", "Guaranteed Magma Route");
            Flags.Add("force:hook", "Guaranteed Hook Route");
            Flags.Add("summon", "Mixed Summon Rewards With Key Items");
            Flags.Add("moon", "Mixed Moon Rewards With Key Items");
            Flags.Add("trap", "Mixed Trasp Chest Rewards With Key Items");
            #endregion

            #region Pass Flags
            Flags.Add("Pkey", "Pass is a Key Item");
            Flags.Add("Pchests", "Pass is in 3 random chests");
            Flags.Add("Pshop", "Pass is in a shop");
            Flags.Add("Pnone", "Pass is not in the seed");

            #endregion

            #region Treasure Flags
            Flags.Add("Tvanilla", "No Chest Randomization");
            Flags.Add("Tshuffle", "Shuffled Chest Randomization");
            Flags.Add("Tstandard", "Standard Chest Randomization");
            Flags.Add("Tpro", "Pro Chest Randomization");
            Flags.Add("Twild", "Wild Chest Randomization");
            Flags.Add("Twildish", "Wildish Chest Randomization");
            Flags.Add("Tempty", "Empty Chests");
            Flags.Add("sparse:10", "10% Full Chests");
            Flags.Add("sparse:20", "20% Full Chests");
            Flags.Add("sparse:30", "30% Full Chests");
            Flags.Add("sparse:40", "40% Full Chests");
            Flags.Add("sparse:50", "50% Full Chests");
            Flags.Add("sparse:60", "60% Full Chests");
            Flags.Add("sparse:70", "70% Full Chests");
            Flags.Add("sparse:80", "80% Full Chests");
            Flags.Add("sparse:90", "90% Full Chests");
            Flags.Add("no:j", "No J-Items in Chests");
            Flags.Add("junk", "Junk Items Kept in Chests");
            Flags.Add("money", "Chests Give Relative Money (No Items)");
            Flags.Add("maxtier:6", "Maximum Tier of Items is Tier 6");
            #endregion

            #region Shop Flags
            Flags.Add("Svanilla", "No Shop Randomization");
            Flags.Add("Sshuffle", "Shuffled Shop Randomization");
            Flags.Add("Sstandard", "Standard Shop Randomization");
            Flags.Add("Spro", "Pro Shop Randomization");
            Flags.Add("Scabins", "Shops Only Sell Cabins");
            Flags.Add("Swild", "Wild Shop Randomization");
            Flags.Add("Sempty", "Empty Shops");
            Flags.Add("free", "Shops Sell For Free");
            Flags.Add("sell:0", "Items Sell to Shops for 0");
            Flags.Add("sell:quarter", "Items Sell to Shops for 1/4");
            Flags.Add("quarter", "Items Sell to Shops for 1/4");
            Flags.Add("no:j,apples,sirens,life", "Np J-Items, Apples, Sirens, or Life Potions in Shops");
            Flags.Add("no:apples,sirens,life", "No Apples, Sirens, or Life Potions in Shops");
            Flags.Add("no:apples,sirens", "No Apples, or Sirens in Shops");
            Flags.Add("no:apples,life", "No Apples or Life potions in Shops");
            Flags.Add("no:apples", "No Apples in Shops");
            Flags.Add("no:j,sirens,life", "No J-Items, Sirens, or Life potions in Shops");
            Flags.Add("no:j,apples,life", "No J-Items, Apples, or Life potions in Shops");
            Flags.Add("no:j,apples,sirens", "No J-Items, Apples or Sirens in Shops");
            Flags.Add("no:j,sirens", "No J-Items, or Sirens in Shops");
            Flags.Add("no:j,apples", "No J-Items, or Apples in Shops");
            Flags.Add("no:j,life", "No J-Items or Life Potions in Shops");
            Flags.Add("no:sirens,life", "No Sirens, or Life potions in Shops");
            Flags.Add("no:sirens", "No Sirens in Shops");
            Flags.Add("no:life", "No Life Potions in Shops");
            #endregion

            #region Boss Flags
            Flags.Add("Bvanilla", "No Boss Randomization");
            Flags.Add("Bnofree", "No Free Bosses");
            Flags.Add("Bstandard", "Standard Boss Randomization");
            Flags.Add("alt:gauntlet", "Alternate 5-fight Gauntlet");
            Flags.Add("whyburn", "Disable Wyvern Opening Meganuke");
            Flags.Add("whichburn", "Random Attack for Wyvern Meganuke");
            #endregion

            #region Challenge Flags
            Flags.Add("Nchars", "No Free Characters");
            Flags.Add("Nkey", "No Free Key Item");
            Flags.Add("Nbosses", "No Free Boss Fights");
            Flags.Add("key", "No Free Key Item");
            Flags.Add("bosses", "No Free Boss Fights");
            Flags.Add("Nnone", "No Challenge Flags");
            #endregion

            #region Encounter Flags
            Flags.Add("Evanilla", "Vanilla Random Encounters");
            Flags.Add("Etoggle", "Toggle Random Encounters");
            Flags.Add("Ereduce", "50% Reduced Random Encounters");
            Flags.Add("Enoencounters", "No Encounters (Including Sirens)");
            Flags.Add("keep:doors", "Keep Trap Door Fights");
            Flags.Add("keep:doors,behemoths", "Keep Trap Door and Behemoth Fights");
            Flags.Add("keep:doors,behemoths,danger", "Keep Trap Door, Dangerous, and Behemoth Fights");
            Flags.Add("keep:behemoths", "Keep Behemoth Fights");
            Flags.Add("keep:behemoths,danger", "Keep Dangerous and Behemoth Fights");
            Flags.Add("keep:danger", "Keep Dangerous Fights");
            Flags.Add("no:jdrops", "J-Item Drops/Sneaks");
            Flags.Add("cantrun", "Can't Run From Encounters");
            Flags.Add("noexp", "No Experience From Encounters");
            #endregion

            #region Glitches Flags
            Flags.Add("Gdupe", "Allow Item Duplication");
            Flags.Add("Gmp", "Allow MP Underflow");
            Flags.Add("Gwarp", "Allow Dwarf Castle Warp");
            Flags.Add("Glife", "Allow Life Glitch");
            Flags.Add("Gsylph", "Allow Sylph MP Glitch");
            Flags.Add("G64", "Allow 64-floor Glitch");
            Flags.Add("Gnone", "No Glitches Allowed");
            Flags.Add("Gbackrow", "Allow Backrow Glitch");
            Flags.Add("mp", "Allow MP Underflow");
            Flags.Add("warp", "Allow Dwarf Castle Warp");
            Flags.Add("life", "Allow Life Glitch");
            Flags.Add("sylph", "Allow Sylph MP Glitch");
            Flags.Add("64", "Allow 64-floor Glitch");
            Flags.Add("backrow", "Allow Backrow Glitch");
            #endregion

            #region Other Flags
            Flags.Add("-kit:basic", "Basic Utility Potion Kit");
            Flags.Add("-kit:better", "Basic kit, Plus Some Combat Items");
            Flags.Add("-kit:loaded", "Wide Array of Potions and Items");
            Flags.Add("-kit:cata", "3 Life Potions and a StarVeil");
            Flags.Add("-kit:freedom", "10 Life, 3-5 StarVeils, 1-2 Sirens, and 10 ThorRages");
            Flags.Add("-kit:cid", "5 Cure2, 1 Bacchus, 1 Unihorn, and Tier 4-5 Axe");
            Flags.Add("-kit:yang", "2 CatClaws");
            Flags.Add("-kit:money", "20,000-80,000 Gold");
            Flags.Add("-kit:grabbag", "8 Random Tier 1-5 Items");
            Flags.Add("-kit:trap", "3 HrGlass2's, 3 MuteBells, and an Assassin Dagger");
            Flags.Add("-kit:archer", "Tier 4-6 Bow, and Tier 3-6 Arrow Type x20");
            Flags.Add("-kit:fabul", "Black Sword");
            Flags.Add("-kit:castlevania", "Tier 3-5 Whip and 3 Crosses");
            Flags.Add("-kit:summon", "Random Summon Orb");
            Flags.Add("-kit:notdeme", "3 Cure3's, 2 Elixirs, and 1 Illusion");
            Flags.Add("-kit:meme", "Ninja Shirt, Drain Spear");
            Flags.Add("-kit:defense", "Dragoon Armor and Diamond Helm");
            Flags.Add("-kit:mist", "10 Dancing Daggers, a Tiara, and a Change Rod");
            Flags.Add("-kit:mysidia", "70 of each: Cure2, Life, Heal, Ether1, 1 Gaea Hat, 1 paladin Shield, and 1 Silver Ring");
            Flags.Add("-kit:baron", "10 Karate Gi's, 10 Headbands, Thunder Claw, and Thunder Rod");
            Flags.Add("-kit:dwarf", "Wizard Hat, Wizarad Robe, 10 Rune Rings, Dwarf Axe, Elixir, and Strength Ring");
            Flags.Add("-kit:eblan", "Icebrand and Blizzard Spear");
            Flags.Add("-kit:99", "99 of a Random Item");
            Flags.Add("-kit:libra", "50 Bestiaries");
            Flags.Add("-kit:green", "4 Random FE Green Name Items");
            Flags.Add("-kit:random", "Randomized Starter Kit");
            Flags.Add("-kit2:basic", "Basic Utility Potion Kit");
            Flags.Add("-kit2:better", "Basic kit, Plus Some Combat Items");
            Flags.Add("-kit2:loaded", "Wide Array of Potions and Items");
            Flags.Add("-kit2:cata", "3 Life Potions and a StarVeil");
            Flags.Add("-kit2:freedom", "10 Life, 3-5 StarVeils, 1-2 Sirens, and 10 ThorRages");
            Flags.Add("-kit2:cid", "5 Cure2, 1 Bacchus, 1 Unihorn, and Tier 4-5 Axe");
            Flags.Add("-kit2:yang", "2 CatClaws");
            Flags.Add("-kit2:money", "20,000-80,000 Gold");
            Flags.Add("-kit2:grabbag", "8 Random Tier 1-5 Items");
            Flags.Add("-kit2:trap", "3 HrGlass2's, 3 MuteBells, and an Assassin Dagger");
            Flags.Add("-kit2:archer", "Tier 4-6 Bow, and Tier 3-6 Arrow Type x20");
            Flags.Add("-kit2:fabul", "Black Sword");
            Flags.Add("-kit2:castlevania", "Tier 3-5 Whip and 3 Crosses");
            Flags.Add("-kit2:summon", "Random Summon Orb");
            Flags.Add("-kit2:notdeme", "3 Cure3's, 2 Elixirs, and 1 Illusion");
            Flags.Add("-kit2:meme", "Ninja Shirt, Drain Spear");
            Flags.Add("-kit2:defense", "Dragoon Armor and Diamond Helm");
            Flags.Add("-kit2:mist", "10 Dancing Daggers, a Tiara, and a Change Rod");
            Flags.Add("-kit2:mysidia", "70 of each: Cure2, Life, Heal, Ether1, 1 Gaea Hat, 1 paladin Shield, and 1 Silver Ring");
            Flags.Add("-kit2:baron", "10 Karate Gi's, 10 Headbands, Thunder Claw, and Thunder Rod");
            Flags.Add("-kit2:dwarf", "Wizard Hat, Wizarad Robe, 10 Rune Rings, Dwarf Axe, Elixir, and Strength Ring");
            Flags.Add("-kit2:eblan", "Icebrand and Blizzard Spear");
            Flags.Add("-kit2:99", "99 of a Random Item");
            Flags.Add("-kit2:libra", "50 Bestiaries");
            Flags.Add("-kit2:green", "4 Random FE Green Name Items");
            Flags.Add("-kit2:random", "Randomized Starter Kit");
            Flags.Add("-kit3:basic", "Basic Utility Potion Kit");
            Flags.Add("-kit3:better", "Basic kit, Plus Some Combat Items");
            Flags.Add("-kit3:loaded", "Wide Array of Potions and Items");
            Flags.Add("-kit3:cata", "3 Life Potions and a StarVeil");
            Flags.Add("-kit3:freedom", "10 Life, 3-5 StarVeils, 1-2 Sirens, and 10 ThorRages");
            Flags.Add("-kit3:cid", "5 Cure2, 1 Bacchus, 1 Unihorn, and Tier 4-5 Axe");
            Flags.Add("-kit3:yang", "2 CatClaws");
            Flags.Add("-kit3:money", "20,000-80,000 Gold");
            Flags.Add("-kit3:grabbag", "8 Random Tier 1-5 Items");
            Flags.Add("-kit3:trap", "3 HrGlass2's, 3 MuteBells, and an Assassin Dagger");
            Flags.Add("-kit3:archer", "Tier 4-6 Bow, and Tier 3-6 Arrow Type x20");
            Flags.Add("-kit3:fabul", "Black Sword");
            Flags.Add("-kit3:castlevania", "Tier 3-5 Whip and 3 Crosses");
            Flags.Add("-kit3:summon", "Random Summon Orb");
            Flags.Add("-kit3:notdeme", "3 Cure3's, 2 Elixirs, and 1 Illusion");
            Flags.Add("-kit3:meme", "Ninja Shirt, Drain Spear");
            Flags.Add("-kit3:defense", "Dragoon Armor and Diamond Helm");
            Flags.Add("-kit3:mist", "10 Dancing Daggers, a Tiara, and a Change Rod");
            Flags.Add("-kit3:mysidia", "70 of each: Cure2, Life, Heal, Ether1, 1 Gaea Hat, 1 paladin Shield, and 1 Silver Ring");
            Flags.Add("-kit3:baron", "10 Karate Gi's, 10 Headbands, Thunder Claw, and Thunder Rod");
            Flags.Add("-kit3:dwarf", "Wizard Hat, Wizarad Robe, 10 Rune Rings, Dwarf Axe, Elixir, and Strength Ring");
            Flags.Add("-kit3:eblan", "Icebrand and Blizzard Spear");
            Flags.Add("-kit3:99", "99 of a Random Item");
            Flags.Add("-kit3:libra", "50 Bestiaries");
            Flags.Add("-kit3:green", "4 Random FE Green Name Items");
            Flags.Add("-kit3:random", "Randomized Starter Kit");
            Flags.Add("-noadamants", "No Adamant Armors");
            Flags.Add("-nocursed", "No Cursed Rings");
            Flags.Add("-spoon", "Spoon is Equipable by Edward (Spoonward!)");
            Flags.Add("-supersmith", "Kokol Forge Gives FF4 Advance Weapon");
            Flags.Add("-smith:super", "Kokol Forge Gives FF4 Advance Weapon");
            Flags.Add("-super:alt", "Kokol Forge Gives Tier 7/8 Weapon");
            Flags.Add("-exp:split", "Split EXP Distribution");
            Flags.Add("-exp:noboost", "No Low-Level EXP Boost");
            Flags.Add("-exp:nonokeybonus", "No EXP Bonus for 10+ Key Items");
            Flags.Add("-vanilla:fusoya", "Vanilla FuSoYa");
            Flags.Add("-vanilla:agility", "Vanilla Agility Anchoring");
            Flags.Add("-vanilla:hobs", "Mt. Hobs gives Rydia Fire1");
            Flags.Add("-vanilla:fashion", "Vanilla Character Sprites");
            Flags.Add("-vanilla:traps", "Vanilla Trap Chest Locations");
            Flags.Add("-vanilla:giant", "Vanilla Giant (No Exit, Must Complete)");
            Flags.Add("-vanilla:z", "Vanilla Zeromus Sprite");
            Flags.Add("-vanilla:growup", "Vanilla Summons at Rydia Grow Up");
            Flags.Add("agility", "Vanilla Agility Anchoring");
            Flags.Add("hobs", "Mt. Hobs gives Rydia Fire1");
            Flags.Add("fashion", "Vanilla Character Sprites");
            Flags.Add("traps", "Vanilla Trap Chest Locations");
            Flags.Add("giant", "Vanilla Giant (No Exit, Must Complete)");
            Flags.Add("z", "Vanilla Zeromus Sprite");
            Flags.Add("-vintage", "8-Bit Battlefield and Sprites");
            Flags.Add("-pushbtojump", "Push B to Jump");
            #endregion

            #region Wacky Flags
            Flags.Add("-wacky:random", "Random Wacky Challenge");
            Flags.Add("-wacky:Afflicted", "Wacky Challenge: Afflicted");
            Flags.Add("-wacky:battlescars", "Wacky Challenge: Battle Scars");
            Flags.Add("-wacky:bodyguard", "Wacky Challenge: The Bodyguard");
            Flags.Add("-wacky:enemyunknown", "Wacky Challenge: Enemy Unknown");
            Flags.Add("-wacky:musical", "Wacky Challenge: Final Fantasy IV: The Musical");
            Flags.Add("-wacky:fistfight", "Wacky Challenge: Fist Fight");
            Flags.Add("-wacky:floorislava", "Wacky Challenge: Floor is Made of Lava!");
            Flags.Add("-wacky:forwardisback", "Wacky Challenge: Forward is the New Back");
            Flags.Add("-wacky:friendlyfire", "Wacky Challenge: Friendly Fire");
            Flags.Add("-wacky:gottagofast", "Wacky Challenge: Gotta Go Fast");
            Flags.Add("-wacky:batman", "Wacky Challenge: Holy Onomatopoeias, Batman!");
            Flags.Add("-wacky:imaginarynumbers", "Wacky Challenge: Imaginary Numbers");
            Flags.Add("-wacky:isthisevenrandomized", "Wacky Challenge: Is This Even Randomized?!");
            Flags.Add("-wacky:kleptomania", "Wacky Challenge: Kleptomania");
            Flags.Add("-wacky:menarepigs", "Wacky Challenge: Men Are Pigs");
            Flags.Add("-wacky:misspelled", "Wacky Challenge: Misspelled");
            Flags.Add("-wacky:biggermagnet", "Wacky Challenge: A Much Bigger Magnet");
            Flags.Add("-wacky:mysteryjuice", "Wacky Challenge: Mystery Juice");
            Flags.Add("-wacky:neatfreak", "Wacky Challenge: Neat Freak");
            Flags.Add("-wacky:nightmode", "Wacky Challenge: Night Mode");
            Flags.Add("-wacky:omnidextrous", "Wacky Challenge: Omnidextrous");
            Flags.Add("-wacky:playablegolbez", "Wacky Challenge: Playable Golbez (HA HA HA)");
            Flags.Add("-wacky:saveusbigchocobo", "Wacky Challenge: Save Us, Big Chocobo!");
            Flags.Add("-wacky:sixleggedrace", "Wacky Challenge: Six-Legged Race");
            Flags.Add("-wacky:skywarriors", "Wacky Challenge: The Sky Warriors");
            Flags.Add("-wacky:worthfighting", "Wacky Challenge: Something Worth Fighting For");
            Flags.Add("-wacky:tellahmaneuver", "Wacky Challenge: The Tellah Maneuver");
            Flags.Add("-wacky:3point", "Wacky Challenge: The 3-Point System");
            Flags.Add("-wacky:timeismoney", "Wacky Challenge: Time is Money");
            Flags.Add("-wacky:darts", "Wacky Challenge: World Championship of Darts");
            Flags.Add("-wacky:unstackable", "Wacky Challenge: Unstackable");
            Flags.Add("-wacky:zombies", "Wacky Challenge: Zombies!!!");
            #endregion

            #region Spoiler Flags
            Flags.Add("-spoil:all", "Full Spoiler Log");
            Flags.Add("-spoil:sparse90", "90% Spoiler Log Visible");
            Flags.Add("-spoil:sparse80", "80% Spoiler Log Visible");
            Flags.Add("-spoil:sparse70", "70% Spoiler Log Visible");
            Flags.Add("-spoil:sparse60", "60% Spoiler Log Visible");
            Flags.Add("-spoil:sparse50", "50% Spoiler Log Visible");
            Flags.Add("-spoil:sparse40", "40% Spoiler Log Visible");
            Flags.Add("-spoil:sparse30", "30% Spoiler Log Visible");
            Flags.Add("-spoil:sparse20", "20% Spoiler Log Visible");
            Flags.Add("-spoil:sparse10", "10% Spoiler Log Visible");
            Flags.Add("-spoil:keyitems", "Spoil Key Item Locations");
            Flags.Add("-spoil:rewards", "Spoil Quest Rewards");
            Flags.Add("-spoil:chars", "Spoil Character Locations");
            Flags.Add("-spoil:shops", "Spoil Shop Inventory");
            Flags.Add("-spoil:bosses", "Spoil Boss Locations");
            Flags.Add("-spoil:misc", "Include Misc. Spoilers ");
            Flags.Add("-spoil:treasure", "Spoil All Treasure Chests");
            Flags.Add("-spoil:traps", "Spoil Trap Chests");
            #endregion

            #endregion

            EnterFlags();

            lblTimer.Text = "00:00:00";
            lblVersion.Text = "Tracker Version: " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
        }
        private void EnterFlags()
        {
            Form enterFlags = new EnterFlags();
            enterFlags.ShowDialog();

            if (flags != string.Empty)
            {
                feFlagString = flags.TrimStart(' ');
                feFlagString = feFlagString.TrimEnd(' ');
                ProcessFlags();
            }
            else
            {
                Application.Exit();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            runClock.Start();
            tParseStopwatch.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            runClock.Stop();
            tParseStopwatch.Stop();
        }

        private void clbObjectives_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbObjectives.Items[e.Index].ToString().Contains("Random Objective"))
            {
                Form randoObj = new RandoObjectiveSet();
                ObjectiveNumber = e.Index;

                randoObj.ShowDialog();

                e.NewValue = CheckState.Unchecked;
                if (ObjectiveNumber != -1 && ObjectiveName!= string.Empty)
                {
                    clbObjectives.Items[ObjectiveNumber] = ObjectiveName;
                }
            }
            else if (clbObjectives.Items[e.Index].ToString().Contains("Done:"))
            {
                int beginOfComplete = clbObjectives.Items[e.Index].ToString().IndexOf(@"Done:");
                string renameObjective = clbObjectives.Items[e.Index].ToString().Substring(0, beginOfComplete);
                clbObjectives.Items[e.Index] = renameObjective;
            }
            else if (clbObjectives.Items[e.Index].ToString().Contains("Defeat Zeromus"))
            {
                BeatZ = true;
                clbObjectives.Items[e.Index] = clbObjectives.Items[e.Index].ToString() + " Done: " + lblTimer.Text;
            }
            else
            {
                clbObjectives.Items[e.Index] = clbObjectives.Items[e.Index].ToString() + " Done: " + lblTimer.Text;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            runClock.Stop();
            runClock.Reset();
            tParseStopwatch.Stop();
            lblTimer.Text = "00:00:00";
            lblObjectives.Text = string.Empty;
            clbObjectives.Items.Clear();
            lbFlags.Items.Clear();
            BeatZ = false;
            wbSchala.Refresh();
            ResetGlobalFlags();
            ProcessFlags();
        }
       
        private void btnReenterFlags_Click(object sender, EventArgs e)
        {
            clbObjectives.Items.Clear();
            lbFlags.Items.Clear();
            BeatZ = false;
            lblObjectives.Text = string.Empty;
            ResetGlobalFlags();

            tParseStopwatch.Stop();
            runClock.Stop();
            runClock.Reset();
            lblTimer.Text = "00:00:00";

            wbSchala.Refresh();
            
            EnterFlags();
        }

        private void ResetGlobalFlags()
        {
            ObjectiveName = string.Empty;
            tempflags.Clear();
            flagSeries = string.Empty;
            questObjectives.Clear();
            bossObjectives.Clear();
            charObjectives.Clear();
            tempobjectives.Clear();
            randoObjectiveCount = 0;
            flagvalue = string.Empty;
    }

        private void lbFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbFlags.ClearSelected();
        }

        private void clbObjectives_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbObjectives.ClearSelected();
        }

        private void tParseStopwatch_Tick(object sender, EventArgs e)
        {
            var ts = runClock.Elapsed;
            string tsHours = string.Empty;
            string tsMinutes = string.Empty;
            string tsSeconds = string.Empty;

            if (ts.Hours < 10)
            {
                tsHours = "0" + ts.Hours.ToString();
            }
            else
            {
                tsHours = ts.Hours.ToString();
            }

            if (ts.Minutes < 10)
            {
                tsMinutes = "0" + ts.Minutes.ToString();
            }
            else
            {
                tsMinutes = ts.Minutes.ToString();
            }
            if (ts.Seconds < 10)
            {
                tsSeconds = "0" + ts.Seconds.ToString();
            }
            else
            {
                tsSeconds = ts.Seconds.ToString();
            }

            lblTimer.Text = String.Format("{0}:{1}:{2}", tsHours, tsMinutes, tsSeconds);

            if (clbObjectives.CheckedItems.Count == ObjectiveCount && winCondition == "Game")
            {
                runClock.Stop();
                tParseStopwatch.Stop();
            }
            else if (clbObjectives.CheckedItems.Count >= ObjectiveCount && winCondition == "Zeromus" && BeatZ)
            {
                runClock.Stop();
                tParseStopwatch.Stop();
            }
        }

        private void btnBosses_Click(object sender, EventArgs e)
        {
            Form BossScalingForm = new BossScaling();
            BossScalingForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://ff4fe.com");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("https://wiki.ff4fe.com/doku.php?id=changelog");
        }
    }
}
