﻿using System;
using System.Diagnostics;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace Controller
{
	internal class MenuButtonModel : IButtonModel
	{
		public MenuButtonModel(string title, EventHandler<CommandArgs> commandHandler)
		{
			Debug.Assert(commandHandler != null, "CommandHandler cannot be null");
			Debug.Assert(title != null, "Title cannot be null");
			Title = title;
			CommandHandler = commandHandler;
		}

		public string Title { get; }
		public EventHandler<CommandArgs> CommandHandler { get; }

		public override string ToString()
		{
			return $"MenuButtonModel: {Title}";
		}
	}
}