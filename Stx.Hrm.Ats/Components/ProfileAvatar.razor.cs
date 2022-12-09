using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stx.HRM.Components
{
	public class ProfileAvatarBase: ComponentBase
    {
		private string _PreviewImageDataUri;
		private int _ImageKey;
        IBrowserFile? selectedFile;

        [Inject] ICorporateSettingsDataService CorporateSettingsDataService{ get; set; }
		[Inject] IApiHelperDataService ApiDataService { get; set; }
		[Parameter] public AvatarType AvatarType { get; set; }
		[Parameter] public string CssClass { get; set; }
		[Parameter] public string HeaderText { get; set; }
		[Parameter] public string SubText { get; set; }
		[Parameter] public string AltText { get; set; }
		[Parameter] public string ImageName { get; set; }
		[Parameter] public int ModuleID { get; set; }
		[Parameter]
		public int ImageKey
		{
			get { return this._ImageKey; }
			set
			{
				this._ImageKey = value;
			}
		}
		[Parameter]
		public string PreviewImageDataUri
		{
			get { return this._PreviewImageDataUri; }
			set
			{
				this._PreviewImageDataUri = value;
			}
		}

        public string AvatarStyle { get; set; }
        public string AvatarDummyImage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await PrepateAvatarStyle();
        }

        private async Task PrepateAvatarStyle()
        {
            if (AvatarType == AvatarType.Profile)
            {
                AvatarStyle = "avatar-profile";
                AvatarDummyImage = "profile-avatar2.svg";
            }
            else if (AvatarType == AvatarType.Profile_Small)
            {
                AvatarStyle = "avatar-profile-sm";
                AvatarDummyImage = "profile-avatar2.svg";
            }
            else if (AvatarType == AvatarType.Logo)
            {
                AvatarStyle = "avatar-logo";
                AvatarDummyImage = "logo-avatar.svg";
            }
            else if (AvatarType == AvatarType.Logo_Small)
            {
                AvatarStyle = "avatar-logo-sm";
                AvatarDummyImage = "logo-avatar.svg";
            }

            StateHasChanged();
        }
               

        public async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            int MaxFileSize = 1024 * 1024 * 5 /*<=MaxFileSizeInMB*/; // 5MB
            List<string> acceptedFileTypes = new List<string>() { "image/png", "image/jpeg", "image/gif" };

            if (e != null && e.File != null)
            {

                bool error = false;
                if (e.File.Size > MaxFileSize)
                {
                    error = true;
                    //ReportPageError("The max file size is {MaxFileSizeMB} MB.");
                }

                if (!acceptedFileTypes.Contains(e.File.ContentType))
                {
                    error = true;
                    //ReportPageError("Only image files are accepted");
                }

                //keep the good files
                var imageFile = e.File;
                if (!error && imageFile != null)
                {
                    string name = $"{ImageKey}{System.IO.Path.GetExtension(imageFile.Name)}";
                    var resizedFile = await imageFile.RequestImageFileAsync("image/jpeg", 300, 300);

                    selectedFile = e.GetMultipleFiles().FirstOrDefault();


                    using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)), "image", name);
                        

                        //var response = await ApiDataService.UploadFile($"CorporateSettings/Profile/Upload/{ImageKey}", content, "");
                        var response = await CorporateSettingsDataService.UpdateProfileImage(selectedFile, ImageKey);
                        {
                            if (response)
                            {
                                await GetLocalImageData(resizedFile);                                
                            }
                            else 
                            {
                                //Report Error("TODO");
                                //var postContent = await response.Content.ReadAsStringAsync();
                                //throw new ApplicationException(postContent);
                            }
                        }
                        //await OnChange.InvokeAsync(PreviewImageDataUri);
                    }
                }

            }
        }

        async Task GetLocalImageData(IBrowserFile file)
        {
            if (file != null)
            {
                //Load as an image file in memory
                var format = "image";
                var resizedImageFile = await file.RequestImageFileAsync(format, 300, 300);
                var buffer = new byte[resizedImageFile.Size];
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);
                PreviewImageDataUri = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                StateHasChanged();
            }
        }
    }

}
