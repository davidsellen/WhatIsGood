using System.Collections.Generic;
using System.Linq;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    public class FileInformationFormViewModel
    {
        public int FileInformationId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public uint Size { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }

        public static List<FileInformationFormViewModel> Create(List<FileInformation> fileInformationList)
        {
            if (fileInformationList == null) return null;
            return fileInformationList.Select(Create).ToList();
        }

        public static FileInformationFormViewModel Create(FileInformation fileInformation)
        {
            if (fileInformation == null) return null;
            var vm = new FileInformationFormViewModel
            {
                FileInformationId = fileInformation.Id,
                Name = fileInformation.Name,
                Url = fileInformation.Url,
                Size = fileInformation.Size,
                Description = fileInformation.Description,
                Extension = fileInformation.Extension
            };
            return vm;
        }

        public static List<FileInformation> Create(List<FileInformationFormViewModel> fileInformationListVm)
        {
            if (fileInformationListVm == null) return null;
            return fileInformationListVm.Select(Create).ToList();
        }

        public static FileInformation Create(FileInformationFormViewModel fileInformationVm)
        {
            if (fileInformationVm == null) return null;
            var vm = new FileInformation
            {
                Id = fileInformationVm.FileInformationId,
                Name = fileInformationVm.Name,
                Url = fileInformationVm.Url,
                Size = fileInformationVm.Size,
                Description = fileInformationVm.Description,
                Extension = fileInformationVm.Extension
            };
            return vm;
        }
    }
}