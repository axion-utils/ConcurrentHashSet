//===========================================================
//
// https://referencesource.microsoft.com/#mscorlib/system/threading/SpinWait.cs,a7801aeb755e9d6f
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
//===========================================================

using System;
using System.Diagnostics;

namespace System
{
	/// <summary>
	/// A helper class to get the number of processors, it updates the numbers of processors every sampling interval.
	/// </summary>
	internal static class PlatformHelper
	{
		private const int PROCESSOR_COUNT_REFRESH_INTERVAL_MS = 30000; // How often to refresh the count, in milliseconds.
		private static volatile int s_processorCount; // The last count seen.
		private static volatile int s_lastProcessorCountRefreshTicks; // The last time we refreshed.

		/// <summary>
		/// The number of concurrent writes for which to optimize by default.
		/// </summary>
		public static int DefaultConcurrencyLevel => ProcessorCount;


		/// <summary>
		/// Gets the number of available processors
		/// </summary>
		private static int ProcessorCount {
			get {
				int now = Environment.TickCount;
				int procCount = s_processorCount;
				if (procCount == 0 || (now - s_lastProcessorCountRefreshTicks) >= PROCESSOR_COUNT_REFRESH_INTERVAL_MS) {
					s_processorCount = procCount = Environment.ProcessorCount;
					s_lastProcessorCountRefreshTicks = now;
				}

				Debug.Assert(procCount > 0 && procCount <= 64,
					"Processor count not within the expected range (1 - 64).");

				return procCount;
			}
		}
	}
}
