namespace CelestialRotations.Magical
{
    [RotationDesc("This is a burst info", ActionID.Divination)]
    internal class BLU_Celestial : BLU_Base
    {

        public override string GameVersion => "6.48";
        public override string RotationName => "BLU_Celestial";
        public override string Description => "My soon to be custom rotations.";
        protected override bool CanHealAreaSpell => this.CanHealAreaSpell;
        protected override bool CanHealSingleSpell => this.CanHealSingleSpell;

        protected override IRotationConfigSet CreateConfiguration()
        {
            return base.CreateConfiguration()
                .SetBool("MoonFluteBreak", false, "Use Moon Flute on cooldown?")
                .SetBool("SingleAOE", true, "Apply AOE Skills to your Single Target Rotation?")
                .SetBool("GamblerKill", false, "Risk chanced abilities, that don't have 100% success rate.")
                .SetBool("UseFinalSting", false, "Use Final Sting, die nerd.")
                .SetFloat("FinalStingHP", 0, "Health Threshold for Final Sting");
        }

        private bool MoonFluteBreak => Configs.GetBool("MoonFluteBreak");
        private static bool QuickLevel => false;
        private bool GamblerKill => Configs.GetBool("GamblerKill");
        private bool SingleAOE => Configs.GetBool("SingleAOE");
        private new bool InBurst { get; set; }
        #region GCD actions
        protected override bool GeneralGCD(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;
            //high injury
            if (PrimalSpell(out act)) return true;
            //colony
            if (AreaGCD(out act)) return true;
            // unitary filling
            if (SingleGCD(out act)) return true;
            return false;
        }

        private bool SingleGCD(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            //Sliding tongue + stun 0-70 for leveling
            if (QuickLevel && StickyTongue.CanUse(out act)) return true;

            //Song of Depression
            if (AllOnSlot(Bristle, SongOfTorment) && SongOfTorment.CanUse(out _))
            {
                //bristle
                if (Bristle.CanUse(out act)) return true;
                if (SongOfTorment.CanUse(out act)) return true;
            }
            if (SongOfTorment.CanUse(out act)) return true;

            // Vengeance Shock
            if (RevengeBlast.CanUse(out act)) return true;
            //gambler behavior
            if (GamblerKill)
            {
                //missile
                if (Missile.CanUse(out act)) return true;
                // spiral tail
                if (TailScrew.CanUse(out act)) return true;
                //death declaration
                if (Doom.CanUse(out act)) return true;
            }

            //Sharp kitchen knife, melee, stun and damage increase
            if (SharpenedKnife.CanUse(out act)) return true;

            //blood sucking back to blue
            if (CurrentMp < 1000 && BloodDrain.CanUse(out act)) return true;
            // sonic boom
            if (SonicBoom.CanUse(out act)) return true;
            if (DrillCannons.CanUse(out act, CanUseOption.MustUse)) return true;
            // Eternal ray cannot + stun 1s
            if (PerpetualRay.CanUse(out act)) return true;
            //The abyss runs through nothing + paralysis
            if (AbyssalTransfixion.CanUse(out act)) return true;
            //Countercurrent Thunder method + aggravation
            if (Reflux.CanUse(out act)) return true;
            //Water cannons
            if (WaterCannon.CanUse(out act)) return true;

            // small detection
            if (CondensedLibra.CanUse(out act)) return true;

            // tongue slip + vertigo
            if (StickyTongue.CanUse(out act)) return true;

            // Throw sardines (interrupt)
            if (FlyingSardine.CanUse(out act)) return true;

            return false;
        }

        private bool AreaGCD(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            //gambler behavior
            if (GamblerKill)
            {
                // rocket launcher
                if (Launcher.CanUse(out act, CanUseOption.MustUse)) return true;
                //Level 5 is dead
                if (Level5Death.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            if (HasCompanion && ChocoMeteor.CanUse(out act, CanUseOption.MustUse)) return true;

            if (HostileTargets.GetObjectInRadius(6).Count() < 3)
            {

                if (HydroPull.CanUse(out act)) return true;
            }


            if (TheRamVoice.CanUse(out act)) return true;


            if (!IsMoving && Target.HasStatus(false, StatusID.DeepFreeze) && TheRamVoice.CanUse(out act)) return true;


            if (TheDragonVoice.CanUse(out act)) return true;


            if (Blaze.CanUse(out act)) return true;
            if (FeculentFlood.CanUse(out act)) return true;

            if (FlameThrower.CanUse(out act)) return true;

            if (AquaBreath.CanUse(out act)) return true;

            if (HighVoltage.CanUse(out act)) return true;

            if (Glower.CanUse(out act)) return true;

            if (PlainCracker.CanUse(out act)) return true;

            if (TheLook.CanUse(out act)) return true;

            if (InkJet.CanUse(out act)) return true;
            if (FireAngon.CanUse(out act)) return true;
            if (MindBlast.CanUse(out act)) return true;
            if (AlpineDraft.CanUse(out act)) return true;
            if (ProteanWave.CanUse(out act)) return true;
            if (Northerlies.CanUse(out act)) return true;
            if (Electrogenesis.CanUse(out act)) return true;
            if (WhiteKnightsTour.CanUse(out act)) return true;
            if (BlackKnightsTour.CanUse(out act)) return true;
            if (Tatamigaeshi.CanUse(out act)) return true;

            if (MustardBomb.CanUse(out act)) return true;
            if (AetherialSpark.CanUse(out act)) return true;
            if (MaledictionOfWater.CanUse(out act)) return true;
            if (FlyingFrenzy.CanUse(out act)) return true;
            if (DrillCannons.CanUse(out act)) return true;
            if (Weight4Tonze.CanUse(out act)) return true;
            if (Needles1000.CanUse(out act)) return true;
            if (Kaltstrahl.CanUse(out act)) return true;
            if (PeripheralSynthesis.CanUse(out act)) return true;
            if (FlameThrower.CanUse(out act)) return true;
            if (FlameThrower.CanUse(out act)) return true;
            if (SaintlyBeam.CanUse(out act)) return true;

            return false;
        }

        private bool PrimalSpell(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            // ice fog
            if (WhiteDeath.CanUse(out act)) return true;
            //Xuantianwu Water Wall
            if (DivineCataract.CanUse(out act)) return true;

            //fighting bullet
            if (TheRoseOfDestruction.CanUse(out act)) return true;

            //Harpoon three sections
            if (InBurst && !MoonFluteBreak && TripleTrident.CanUse(out act)) return true;
            // Matra magic
            if (InBurst && !MoonFluteBreak && MatraMagic.CanUse(out act)) return true;

            //prey
            if (Devour.CanUse(out act)) return true;
            //magic hammer
            //if (MagicHammer.ShouldUse(out act)) return true;

            var option = SingleAOE ? CanUseOption.MustUse : CanUseOption.None;
            //flowers on the other side of the moon
            if (InBurst && !MoonFluteBreak && NightBloom.CanUse(out act, option)) return true;
            // wishful whirlwind
            if (InBurst && !MoonFluteBreak && BothEnds.CanUse(out act, option)) return true;

            //Armor piercing shotgun
            if (InBurst && !MoonFluteBreak && Surpanakha.CurrentCharges >= 3 && Surpanakha.CanUse(out act, option | CanUseOption.EmptyOrSkipCombo)) return true;

            // quasar
            if (Quasar.CanUse(out act, option)) return true;
            //just kick
            if (!IsMoving && JKick.CanUse(out act, option)) return true;

            // ground fire eruption
            if (Eruption.CanUse(out act, option)) return true;
            //flying rain
            if (FeatherRain.CanUse(out act, option)) return true;

            //Boom
            if (ShockStrike.CanUse(out act, option)) return true;
            //landslide
            if (MountainBuster.CanUse(out act, option)) return true;

            //Ice and Snow Flurry
            if (GlassDance.CanUse(out act, option)) return true;

            return false;
        }

        //For some gcds very important, even more than healing, defense, interrupt, etc.
        protected override bool EmergencyGCD(out IAction act)
        {
            return base.EmergencyGCD(out act);
        }

        protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
        {
            {
                if (!Player.IsCasting)
                {
                    InBurst = true;
                }
                else InBurst = false;
            }
            if (InBurst == true)
            {
               return this.GeneralGCD(out act);
            }
            act = null;
            return false;
        }

        [RotationDesc("Optional description for Healing Area GCD")]
        [RotationDesc(ActionID.None)]
        protected override bool HealAreaGCD(out IAction act)
        {
            return base.HealAreaGCD(out act);
        }

        [RotationDesc("Optional description for Healing Single GCD")]
        [RotationDesc(ActionID.None)]
        protected override bool HealSingleGCD(out IAction act)
        {
            return base.HealSingleGCD(out act);
        }
        #endregion
    }
}
