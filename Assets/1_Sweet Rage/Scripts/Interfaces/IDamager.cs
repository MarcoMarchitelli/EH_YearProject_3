namespace Deirin.EB {
	public interface IDamager {
		float Damage { get; }

		void DealDamage ();

		void DealDamage ( float value );

		void SetDamage ( float value );

		void ResetDamage ();
	} 
}