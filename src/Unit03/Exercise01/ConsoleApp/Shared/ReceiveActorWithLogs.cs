﻿extern alias akka;

using akka::Akka.Actor;
using System;

namespace ConsoleApp.Shared
{
	public abstract class ReceiveActorWithLogs : ReceiveActor
	{
		public static bool ShowLog = true;

		protected string ActorName
		{
			get { return $"[{GetType().Name} - {Context.Self.Path}]"; } // Context.Self.Path.ToStringWithUid()
		}

		protected ReceiveActorWithLogs()
		{
			if (ShowLog)
			{
				ColoredConsole.WriteLineMagenta($"{ActorName} Constructor");
			}
		}

		protected override void PreStart()
		{
			if (ShowLog)
			{
				ColoredConsole.WriteLineMagenta($"{ActorName} PreStart");
			}
			base.PreStart();
		}

		protected override void PostStop()
		{
			if (ShowLog)
			{
				ColoredConsole.WriteLineMagenta($"{ActorName} PostStop");
			}
			base.PostStop();
		}

		protected override void PreRestart(Exception reason, object message)
		{
			if (ShowLog)
			{
				ColoredConsole.WriteLineMagenta($"{ActorName} PreRestart, reason: {reason.Message}, message: {message}");
			}
			base.PreRestart(reason, message);
		}

		protected override void PostRestart(Exception reason)
		{
			if (ShowLog)
			{
				ColoredConsole.WriteLineMagenta($"{ActorName} PostRestart, reason: {reason.Message}");
			}
			base.PostRestart(reason);
		}
	}
}
