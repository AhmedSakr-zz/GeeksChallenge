using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.ServiceProvider;
using GeeksChallenge.CloudLibrary.ServiceProvider.EventArgs;
using GeeksChallenge.Domain.Enums;
using Microsoft.AspNetCore.Hosting;

namespace GeeksChallenge.CloudLibrary.Services.CloudProvider
{
    public class IGSCloudServices : ServiceProvider.CloudServices
    {
        public override void OnCreateService(object source, CreateInfraEventArgs s)
        {
            if (s.InfrastructureForPostDto.CloudProviderId != (int)AppEnums.CloudProvider.IGS)
                return;

            //Implementation of create infrastructure on IGS provider
            //Goes here
            //..
            //..
            //..
            //..
            //-------------

            #region create directory for infrastructure
            var path = Path.Combine(Environment.CurrentDirectory, s.InfrastructureForPostDto.CloudProviderName);

            //create a sub-directory for cloud provider 
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //create a sub-directory for infrastructure
            path = Path.Combine(path, s.InfrastructureForPostDto.Name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //create a sub-directory foreach resource
            foreach (var resource in s.InfrastructureForPostDto.InfrastructureResources)
            {
                var resourceFolderName = resource.ServiceName;
                var resourcePath = Path.Combine(path, resourceFolderName);
                if (!Directory.Exists(resourcePath))
                    Directory.CreateDirectory(resourcePath);
                else
                {
                    resourceFolderName += "_" + DateTime.Now.Ticks;
                    resourcePath = Path.Combine(path, resourceFolderName);
                    Directory.CreateDirectory(resourcePath);
                }
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("content: ");
                stringBuilder.Append("{");

                //create attributes file
                foreach (var resourceOption in resource.InfrastructureResourceOption)
                {
                    stringBuilder.AppendFormat(resourceOption.ServiceOptionName);
                    stringBuilder.AppendFormat(" : ");
                    stringBuilder.AppendFormat(resourceOption.Value);
                    stringBuilder.AppendFormat(",");
                }

                var content = stringBuilder.ToString();
                content = content.Substring(0, content.Length - 1);

                content += "}";

                var filePath = Path.Combine(resourcePath, s.InfrastructureForPostDto.Name + "_" + resource.ServiceName + ".json");
                File.WriteAllText(filePath, content);

            }
            #endregion  create directory for infrastructure

            s.Created = true;
        }


        public override void OnDeleteService(object source, DeleteInfraEventArgs e)
        {
            if (e.Infrastructure.CloudProviderId != (int)AppEnums.CloudProvider.IGS)
                return;

            //Implementation of delete infrastructure on IGS provider
            //Goes here
            //..
            //..
            //..
            //..
            //-------------

            #region delete infrastructure
            var infraPath = Path.Combine(Environment.CurrentDirectory, e.Infrastructure.CloudProvider.Name);
            infraPath = Path.Combine(infraPath, e.Infrastructure.Name);

            var allInfraResources = Directory.GetDirectories(infraPath);

            //delete resources directories
            foreach (var resource in allInfraResources)
            {
                //delete all files in resource
                var resourceFiles = Directory.GetFiles(Path.Combine(infraPath, resource));
                foreach (var resourceFile in resourceFiles)
                {
                    File.Delete(resourceFile);
                }

                //delete resource directory
                Directory.Delete(Path.Combine(infraPath, resource));
            }

            //delete infrastructure directory
            Directory.Delete(infraPath);



            #endregion delete infrastructure

            e.Deleted = true;
        }
    }
}
