using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using WebApp.Models.Friend;
using WebApp.Services;
using CloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;

namespace WebApp.Controllers
{
    public class FriendController : Controller
    {
        private IFriendApi _friendApi;

        public FriendController(IFriendApi friendApi)
        {
            _friendApi = friendApi;
        }

        // GET: FriendController
        public async Task<ActionResult> Index()
        {
            var friends = await _friendApi.GetAsync();
            return View(friends);
        }

        // GET: FriendController/Details/5
        public ActionResult Details(Guid id)
        { 
            return View();
        }

        // GET: FriendController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFriend createFriend)
        {
            var urlPicture = UploadProfilePicture(createFriend.ProfilePicture);

            createFriend.UrlPicture = urlPicture;

            await _friendApi.PostAsync(createFriend);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

        // GET: FriendController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FriendController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FriendController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string UploadProfilePicture(IFormFile profilePicture)
        {
            var reader = profilePicture.OpenReadStream();
            var cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=atazure;AccountKey=KfLMRh/w+nHjvUmPdhnBQtgYamgn418nqxMqOrk0T4Kxt14PnUXBpJuH+dEgvIHWBoeXq4H+Fi6NKZK84yNUIw==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("fotoperfil");
            container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinyOfThePictureInTheCloud = blob.Uri.ToString();

            return destinyOfThePictureInTheCloud;
        }
    }
}
