using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using Blogger.Core.Repositories;
using Blogger.Ui.Models.ViewModels.PostingCardsViewModels;
using Blogger.Ui.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blogger.Ui.Controllers
{
    public class PostingCardsController : Controller
    {
        private readonly IMapper mapper;
        private IUoW uoW;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostingCardsController(IMapper mapper, IUoW uoW, IWebHostEnvironment webHostEnvironment)
        {
            this.mapper = mapper;
            this.uoW = uoW;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int page =1)
        {

            var postingCards = await uoW.PostingCardsRepository.GetAllPostingCardsAsync();
            var model = mapper.Map<IEnumerable<ListPostingCardsViewModel>>(postingCards);

            var paginationResult = model.AsQueryable().GetPagination(page, 9);



            return View(paginationResult);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postingCard = await uoW.PostingCardsRepository.GetPostingCardByIdAsync((Guid)id);

            if (postingCard == null)
            {
                return NotFound();
            }
            var model = mapper.Map<DetailsPostingCardViewModel>(postingCard);

            return View(model);
        }

        public IActionResult Create()
        {
            var viewmodel = new CreatePostingCardViewModel();

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostingCardViewModel viewmodel)
        {
            var postingcard = mapper.Map<PostingCard>(viewmodel);
            postingcard.PublishingDate = DateTime.Now;

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

                // Fortunately FileStream implements IDisposable, so it's easy to wrap all the code inside a using statement
                // in order to ensure that the file won't be left open
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewmodel.Photo.CopyToAsync(stream);
                }

                // Here (outside the using statement) stream is not accessible and it has been closed (also if
                // an exception is thrown and stack unrolled
                postingcard.ImagePath = uniqueFileName;
            }

            if (ModelState.IsValid)
            {
                await uoW.PostingCardsRepository.AddAsync(postingcard);

                if (await uoW.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(viewmodel);
            }
            return View(viewmodel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postingCard = await uoW.PostingCardsRepository.GetPostingCardByIdAsync((Guid)id);
            if (postingCard == null)
            {
                return NotFound();
            }
            var model = mapper.Map<EditPostingCardViewModel>(postingCard);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditPostingCardViewModel viewmodel)
        {
            var postingCard = await uoW.PostingCardsRepository.GetPostingCardByIdAsync(id);
            if (await TryUpdateModelAsync(viewmodel, "", pc => pc.Header,
                                                                            pc => pc.Content))
                mapper.Map(viewmodel, postingCard);

            if (id != postingCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await uoW.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostingCardExists(id))
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

        // GET: PostingCards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postingCardToBeRemoved = await uoW.PostingCardsRepository.GetPostingCardByIdAsync((Guid)id);
            if (postingCardToBeRemoved == null)
            {
                return NotFound();
            }
            var model = mapper.Map<DeletePostingCardViewModel>(postingCardToBeRemoved);

            return View(model);
        }

        // POST: PostingCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postingCardToBeRemoved = await uoW.PostingCardsRepository.GetPostingCardByIdAsync(id);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", $"{postingCardToBeRemoved.ImagePath}");

            const int NumberOfRetries = 3;
            const int DelayOnRetry = 1000;

            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                   
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    break; // When done we can break loop
                }
                catch (IOException) when (i <= NumberOfRetries)
                {
                    // You may check error code to filter some exceptions, not every error
                    // can be recovered.
                    Thread.Sleep(DelayOnRetry);
                }
            }

            uoW.PostingCardsRepository.Remove(postingCardToBeRemoved);
            if (await uoW.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500);
            }
        }

        private bool PostingCardExists(Guid id)
        {
            return uoW.PostingCardsRepository.Any(id);
        }
    }
}