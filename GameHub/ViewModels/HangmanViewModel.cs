using System;
using GameHub.Models;

namespace GameHub.ViewModels
{
	public class HangmanViewModel
	{
		HangmanModel model;
		MainPage mp;
		public HangmanViewModel(HangmanModel model, MainPage mainPage)
		{
			this.model = model;
			this.mp = mainPage;
		}
	}
}

