using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using Blogger.Core.Repositories;
using Blogger.Ui.Filters;
using Blogger.Ui.Models.ViewModels.VideosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Controllers
{
    public class VideosController : Controller
    {
        private IMapper mapper;
        private readonly IUoW uoW;

        public VideosController(IMapper mapper, IUoW uoW)
        {
            this.mapper = mapper;
            this.uoW = uoW;
        }

        public async Task<IActionResult> Index()
        {
            var videos = await uoW.VideosRepository.GetAllVideosAsync();
            var models = mapper.Map<IEnumerable<ListVideosViewModel>>(videos);
            models.OrderByDescending(vl => vl.PublishingDate);

            return View(models);
        }

        [ModelNotNull]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var video = await uoW.VideosRepository.GetVideoByIdAsync((Guid)id);
            var model = mapper.Map<DetailsVideoViewModel>(video);
            return View(model);
        }

        public IActionResult Create(Guid? videosListId)
        {
            //if (videosListId is null)
            //{
            //    return BadRequest();
            //}

            var createVideo = new CreateVideoViewModel();
            if (videosListId is not null)
            {
            createVideo.VideosListId = (Guid)videosListId;
            }

            return View(createVideo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelNotNull, ModelValid]
        public async Task<IActionResult> Create(CreateVideoViewModel createVideo)
        {
            var video = mapper.Map<Video>(createVideo);
            video.PublishingDate = DateTime.Now;
            if (createVideo.VideosListId is null)
            {
                ModelState.AddModelError("VideosListId", "الرجاء اختيار قائمة التشغيل");
            }
            if (ModelState.IsValid)
            {
            await uoW.VideosRepository.AddAsync(video);
            if (await uoW.SaveAsync())
            {
                return RedirectToAction("Details", "VideosLists", new { Id = video.VideosListId });
            }

            }
            return View(createVideo);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await uoW.VideosRepository.GetVideoByIdAsync((Guid)id);
            if (video == null)
            {
                return NotFound();
            }

            var viewmodel = mapper.Map<EditVideoViewModel>(video);

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelNotNull, ModelValid]
        public async Task<IActionResult> Edit(Guid id, EditVideoViewModel viewmodel)
        {
            if (id != viewmodel.Id)
            {
                return NotFound();
            }

            var video = await uoW.VideosRepository.GetVideoByIdAsync(id);
            if (await TryUpdateModelAsync(viewmodel, "", v => v.Title,
                                                            v => v.VideosListId))
                mapper.Map(viewmodel, video);

            if (ModelState.IsValid)
            {
                try
                {
                    await uoW.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index", "VideosLists");
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await uoW.VideosRepository.GetVideoByIdAsync((Guid)id);
            if (video == null)
            {
                return NotFound();
            }

            var model = mapper.Map<DeleteVideoViewModel>(video);
            return View(model);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteVideoViewModel viewmodel)
        {
            TempData["VideosListId"] = viewmodel.VideosListId;
            var temp = TempData["VideosListId"];
            var video = await uoW.VideosRepository.GetVideoByIdAsync(id);
            uoW.VideosRepository.Remove(video);
            if (await uoW.SaveAsync())
            {
                return RedirectToAction("Details", "VideosLists", new { Id = (Guid)temp });
            }
            else
            {
                return StatusCode(500);
            }
        }

        private bool VideoExists(Guid id)
        {
            return uoW.VideosRepository.Any(id);
        }
    }
}