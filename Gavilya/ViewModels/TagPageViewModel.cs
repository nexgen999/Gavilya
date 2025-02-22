﻿/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/

using Gavilya.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gavilya.ViewModels;

public class TagPageViewModel : ViewModelBase
{
	private readonly MainViewModel _mainViewModel;
	private readonly List<GameList> _sortedGames;
	private readonly List<Tag> _tags;

	public List<GameGroupViewModel> GameGroupViewModels => _sortedGames.Where(list => list.Count > 0).Select(list => new GameGroupViewModel(list.Title ?? "", list, _tags, _mainViewModel)).ToList();

	public TagPageViewModel(GameList games, List<Tag> tags, MainViewModel mainViewModel)
	{
		_sortedGames = games.GetSortedGameByTag();
		_tags = tags;
		_mainViewModel = mainViewModel;
	}
}
