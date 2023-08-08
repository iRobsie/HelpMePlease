namespace CelestialRotations.Magical
{
	internal class BLU_Celestial : BLU_Base
	{

		public override string GameVersion => "6.45";
		public override string RotationName => "BLU_Celestial";
		public override string Description => "My soon to be custom rotations.";
		protected override bool CanHealAreaSpell => this.CanHealAreaSpell;
		protected override bool CanHealSingleSpell => this.CanHealSingleSpell;

		#region GCD actions
		protected override bool GeneralGCD(out IAction act)
		{
			if (Electrogenesis.CanUse(out act, CanUseOption.MustUse)) return true;
			act = null;
			return false;
		} 
		//For some gcds very important, even more than healing, defense, interrupt, etc.
		//protected override bool EmergencyGCD(out IAction act)
		//{
		//	return base.EmergencyGCD(out act);
		//}

		//For some gcds that moving forward.
		otationDesc("Optional description for Moving Forward GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool MoveForwardGCD(out IAction act)
		{
		    return base.MoveForwardGCD(out act);
		}

		[RotationDesc("Optional description for Defense Area GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool DefenseAreaGCD(out IAction act)
		{
			return base.DefenseAreaGCD(out act);
		}

		[RotationDesc("Optional description for Defense Single GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool DefenseSingleGCD(out IAction act)
		{
			return base.DefenseSingleGCD(out act);
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

		#region 0GCD actions
		protected override bool AttackAbility(out IAction act)
		{
            act = null;
            throw new NotImplementedException();
		}

		//For some 0gcds very important, even more than healing, defense, interrupt, etc.
		protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
		{
			return base.EmergencyAbility(nextGCD, out act);
		}

		//Some 0gcds that don't need to a hostile target in attack range.
		protected override bool GeneralAbility(out IAction act)
		{
			return base.GeneralAbility(out act);
		}

		//Some 0gcds that moving forward. In general, it doesn't need to be override.
		[RotationDesc("Optional description for Moving Forward 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool MoveForwardAbility(out IAction act)
		{
			return base.MoveForwardAbility(out act);
		}

		//Some 0gcds that moving back. In general, it doesn't need to be override.
		[RotationDesc("Optional description for Moving Back 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool MoveBackAbility(out IAction act)
		{
			return base.MoveBackAbility(out act);
		}

		//Some 0gcds that defense area.
		[RotationDesc("Optional description for Defense Area 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool DefenseAreaAbility(out IAction act)
		{
			return base.DefenseAreaAbility(out act);
		}

		//Some 0gcds that defense single.
		[RotationDesc("Optional description for Defense Single 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool DefenseSingleAbility(out IAction act)
		{
			return base.DefenseSingleAbility(out act);
		}

		//Some 0gcds that healing area.
		[RotationDesc("Optional description for Healing Area 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool HealAreaAbility(out IAction act)
		{
			return base.HealAreaAbility(out act);
		}

		//Some 0gcds that healing single.
		[RotationDesc("Optional description for Healing Single 0GCD")]
		[RotationDesc(ActionID.None)]
		protected override bool HealSingleAbility(out IAction act)
		{
			return base.HealSingleAbility(out act);
		}
		#endregion

		#region Extra
		//For counting down action when pary counting down is active.
		protected override IAction CountDownAction(float remainTime)
		{
			return base.CountDownAction(remainTime);
		}

		//This is the method to update all field you wrote, it is used first during one frame.
		protected override void UpdateInfo()
		{
			base.UpdateInfo();
		}

		//This method is used when player change the terriroty, such as go into one duty, you can use it to set the field.
		public override void OnTerritoryChanged()
		{
			base.OnTerritoryChanged();
		}

		//This method is used to debug. If you want to show some information in Debug panel, show something here.
		public override void DisplayStatus()
		{
			base.DisplayStatus();
		}
		#endregion
	}
}