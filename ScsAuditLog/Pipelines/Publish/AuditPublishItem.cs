﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace ScsAuditLog.Pipelines.Publish
{
	public class AuditPublishItem : PublishItemProcessor
	{
		public override void Process(PublishItemContext context)
		{
			AuditLogger.Current.Log(context.VersionToPublish, "6",
				$"<table><th>Field</th><th>Source</th><th>Target</th><tr><td>Location</td><td>{context.PublishOptions.SourceDatabase.Name}</td><td>{context.PublishOptions.TargetDatabase.Name}</td></tr></table>");
		}
	}

}
