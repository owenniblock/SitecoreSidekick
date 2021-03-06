﻿using System;
using System.Linq.Expressions;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace SitecoreSidekick.Commands
{
	public class OpenScs : Command
	{
		public override void Execute(CommandContext context)
		{
			Assert.ArgumentNotNull((object)context, "context");
			try
			{
				typeof(Sitecore.Shell.Framework.Windows).GetMethod("RunUri", new [] {typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) }).Invoke(null, new object[]
				{
					$"//{HttpContext.Current.Request.Url.Host}/scs/scs.scs?desktop=true", "office/32x32/sword.png",
					"Sitecore Sidekick", "1000px", "600px"
				});
			}
			catch (Exception e)
			{
					SheerResponse.Eval(
						"var scs = window.top.document.getElementById(\"scs\");scs.innerHTML = \" <iframe id = 'scs-iframe' style = 'width:100%;height:100%;background-color: transparent;' src = '/scs/scs.scs' /> \";scs.style.display = \"block\";scs.style.position = \"absolute\";");
			}
		}
	}
}
