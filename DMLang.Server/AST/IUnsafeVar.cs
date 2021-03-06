﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IUnsafeVar
	{
		string Name { get; }

		/// <summary>
		/// The <see cref="IUnsafeVar"/> used to retrieve this <see cref="IUnsafeVar"/>. <see langword="null"/> if none
		/// </summary>
		IUnsafeVar Owner { get; }
	}
}
