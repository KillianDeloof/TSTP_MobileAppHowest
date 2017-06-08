using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using System.IO;
using System.Linq;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

//this could also work
//https://blog.xamarin.com/getting-started-with-the-media-plugin-for-xamarin/


namespace MobileAppHowest.Repositories
{
    public class MediaPicker// : ICameraService
    {
        public static async Task<MediaFile> TakePhoto()
        {

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Receipts",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                MediaFile file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);




                //await Task.Delay(100);
                //MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                //{
                //    SaveToAlbum = true,
                //    DefaultCamera = CameraDevice.Rear,
                //    Directory = "OnePosInventory",
                //    Name = "Media.jpg"
                //});




                return file;
            }
            else
            {
                return null;
            }

        }

        public static async Task<MediaFile> PickPhoto()
        {
            // Select a photo. 
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                return photo;
            }
            else
            {
                return null;
            }
                

            // Select a video. 
            //if (CrossMedia.Current.IsPickVideoSupported)
            //    MediaFile video = await CrossMedia.Current.PickVideoAsync();
        }


        public static byte[] MediaFileToByteArr(MediaFile mediafile)
        {
            byte[] byteArr;
            using (var memoryStream = new MemoryStream())
            {
                mediafile.GetStream().CopyTo(memoryStream);
                mediafile.Dispose();
                byteArr = memoryStream.ToArray();
            }
            return byteArr;
        }


        //chomado style
        //public async Task<byte[]> TakePhotosAsync()
        //{
        //    await CrossMedia.Current.Initialize();

        //    var picture = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

        //    if (picture == null)
        //    {
        //        return null;
        //    }

        //    var ms = new MemoryStream();

        //    using (var s = picture.GetStream())
        //    {
        //        await s.CopyToAsync(destination: ms);
        //    }

        //    //ms.Seek(offset: 0, loc: SeekOrigin.Begin);

        //    return ms.ToArray();
        //}

        //use this methot to call camera from viewmodel
        //private async Task StartGameAsync()
        //{
        //    this.IsBusy = true;   (isbussy is a prop declared in the viewmodel)
        //    try
        //    {
        //        this.Picture = await this.CameraService.TakePhotosAsync();
        //        if (this.Picture == null)
        //        {
        //            await this.NavigationService.GoBackAsync();
        //            return;
        //        }

        //        var detectResults = await this.DetectPictureAsync();

        //        if (detectResults.Any())
        //        {
        //            this.DetectWinner(detectResults);
        //        }

        //        this.FaceDetectionResults = detectResults;
        //    }
        //    finally
        //    {
        //        this.IsBusy = false;
        //    }
        //}


    }
}
