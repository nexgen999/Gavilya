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

namespace Gavilya.Models.Rawg;

public static partial class ApiKeys
{
	/// <summary>
	/// The RAWG.io API key. DO NOT SET A VALUE DIRECTLY IN A FILE THAT MIGHT BE PUBLISHED TO GITHUB. 
	/// It is highyly recommanded that you don't store you API Key as plaintext, but as an encrypted string.
	/// For security reasons, the encryption system used by official Léo Corporation releases isn't available.
	/// We recommand that you use AES algorithm.
	/// <para>YOUR API KEY IS SECRET!</para>
	/// <para>Define your API keys in a copy of <see cref="ApiKeys"/> called <c>ApiKeysLocal.cs</c></para>
	/// </summary>
	public static readonly string RawgApiKey = "";
}
