namespace DMLang.Server.AST
{
	/// <summary>
	/// Represents a ++x-like <see cref="IExpression"/>
	/// </summary>
	interface IAdjustOperation : IExpression
	{
		/// <summary>
		/// The target <see cref="IUnsafeVar"/> being adjusted
		/// </summary>
		IUnsafeVar Target { get; }
		/// <summary>
		/// If this is a ++ or -- operation
		/// </summary>
		bool IsAddition { get; }
		/// <summary>
		/// If the operation comes before or after returning <see cref="Target"/>
		/// </summary>
		bool IsPre { get; }
	}
}
