/* 
 * 
 * (c) Copyright Ascensio System Limited 2010-2014
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * http://www.gnu.org/licenses/agpl.html 
 * 
 */

using System;
using System.Text;
using System.Web;
using ASC.Web.Studio.Controls.FileUploader;

namespace ASC.Web.CRM.Controls.Common
{
    public partial class FileUploader : BaseUserControl
    {
        public static string Location
        {
            get { return PathProvider.GetFileStaticRelativePath("Common/FileUploader.ascx"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _uploadSwitchHolder.Controls.Add(new FileUploaderModeSwitcher());

            RegisterScript();
        }

        private void RegisterScript()
        {
            var sb = new StringBuilder();

            sb.AppendFormat(" var fileSizeLimit = \"{0}\"; ",
                    ASC.Web.Studio.Core.SetupInfo.MaxUploadSize);

            Page.RegisterInlineScript(sb.ToString(), onReady: false);
        }
    }
}