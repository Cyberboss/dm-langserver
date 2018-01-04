namespace DMLang.Server.AST
{
    /// <summary>
    /// Qualifiers for a <see cref="IVar"/>
    /// </summary>
	enum VarQualifier
	{
        /// <summary>
        /// No qualifiers
        /// </summary>
		Unqualified,
        /// <summary>
        /// The <see cref="IVar"/> is static or global
        /// </summary>
		Static,
        /// <summary>
        /// The <see cref="IVar"/> is const
        /// </summary>
		Const
	}
}
