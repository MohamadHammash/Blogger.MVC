using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using Blogger.Core.Repositories;
using Blogger.Ui.Filters;
using Blogger.Ui.Models.ViewModels.VideosListsViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Controllers
{
    public class VideosListsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly IUoW uoW;

        public VideosListsController(IUoW uoW, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.uoW = uoW;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var videosLists = await uoW.VideosListsRepository.GetAllVideosListsAsync();

            var model = mapper.Map<IEnumerable<ListVideosListsViewModel>>(videosLists);
  

            return View(model);
        }

        [ModelNotNull]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var videosList = await uoW.VideosListsRepository.GetVideosListByIdAsync((Guid)id);
            if (videosList is null)
            {
                return NotFound();
            }
            var model = mapper.Map<DetailsVideosListViewModel>(videosList);
            return View(model);
        }

        public IActionResult Create()
        {
            var viewmodel = new CreateVideosListViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelNotNull, ModelValid]
        public async Task<IActionResult> Create(CreateVideosListViewModel viewmodel)
        {
            var videosList = mapper.Map<VideosList>(viewmodel);
            string uniqueFileName = null;

            if (viewmodel.Photo is not null)
            {
                string[] allowedextension = { ".jpg", ".jpeg", ".png", ".jfif" };
                var extension = Path.GetExtension(viewmodel.Photo.FileName);
                if (!allowedextension.Contains(extension))
                {
                    ModelState.AddModelError("Photo", "الملف المحمل ليس صورة , الرجاء تحميل صورة");
                }

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewmodel.Photo.FileName;


                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder

                // Fortunately FileStream implements IDisposable, so it's easy to wrap all the code inside a using statement
                // in order to ensure that the file won't be left open

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewmodel.Photo.CopyToAsync(stream);
                }
                // Here (outside the using statement) stream is not accessible and it has been closed (also if
                // an exception is thrown and stack unrolled
                videosList.ImagePath = uniqueFileName;
            }
            if (ModelState.IsValid)
            {

            await uoW.VideosListsRepository.AddAsync(videosList);

            if (await uoW.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
            }
            return View(viewmodel);
        }

        [ModelNotNull]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var videoslist = await uoW.VideosListsRepository.GetVideosListByIdAsync((Guid)id);

            if (videoslist == null)
            {
                return NotFound();
            }
            var model = mapper.Map<EditVideosListViewModel>(videoslist);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelNotNull, ModelValid]
        public async Task<IActionResult> Edit(Guid id, EditVideosListViewModel viewmodel)
        {
            var videolsList = await uoW.VideosListsRepository.GetVideosListByIdAsync(id);
            if (await TryUpdateModelAsync(viewmodel, "", vl => vl.ListName))
                mapper.Map(viewmodel, videolsList);

            if (ModelState.IsValid)
            {
                try
                {
                    await uoW.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideosListExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [ModelNotNull]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var videoslistToBeRemoved = await uoW.VideosListsRepository.GetVideosListByIdAsync((Guid)id);
            var model = mapper.Map<DeleteVideosListViewModel>(videoslistToBeRemoved);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ModelNotNull]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteVideosListViewModel viewModel)
        {
            var videosListToBeRemoved = await uoW.VideosListsRepository.GetVideosListByIdAsync(id);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", $"{videosListToBeRemoved.ImagePath}");

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            uoW.VideosListsRepository.Remove(videosListToBeRemoved);
            if (await uoW.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500);
            }
        }

        private bool VideosListExists(Guid id)
        {
            return uoW.VideosListsRepository.Any(id);
        }
    }
}