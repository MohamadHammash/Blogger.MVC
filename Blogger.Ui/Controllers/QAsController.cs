using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using Blogger.Core.Repositories;
using Blogger.Ui.Models.ViewModels.QAsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Controllers
{
    public class QAsController : Controller
    {
        private readonly IUoW uoW;
        private readonly IMapper mapper;

        public QAsController(IUoW uoW, IMapper mapper)
        {
            this.uoW = uoW;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var qAs = await uoW.QAsRepository.GetAllQAsAsync();
            var model = mapper.Map<IEnumerable<ListQAsViewModel>>(qAs);
           

            return View(model);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qA = await uoW.QAsRepository.GetQAByIdAsync((Guid)id);

            if (qA == null)
            {
                return NotFound();
            }
            var model = mapper.Map<DetailsQAViewModel>(qA);

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateQAViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQAViewModel qA)
        {
            var qa = mapper.Map<QA>(qA);
            qa.PublishingDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                await uoW.QAsRepository.AddAsync(qa);
            if (await uoW.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
                return View(qA);
            }
           
            return View(qA);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qA = await uoW.QAsRepository.GetQAByIdAsync((Guid)id);
            if (qA == null)
            {
                return NotFound();
            }
            var model = mapper.Map<EditQAViewModel>(qA);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditQAViewModel viewModel)
        {
            var qA = await uoW.QAsRepository.GetQAByIdAsync(id);
            if (await TryUpdateModelAsync(viewModel, "", q => q.FirstName,
                                                        q => q.LastName,
                                                        q => q.Question,
                                                        q => q.Answer,
                                                        q => q.Subject
                                                        ))
                mapper.Map(viewModel, qA);

            if (ModelState.IsValid)
            {
                try
                {
                    await uoW.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QAExists(id))
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

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var qaToBeDeleted = await uoW.QAsRepository.GetQAByIdAsync((Guid)id);
            if (qaToBeDeleted is null)
            {
                return NotFound();
            }
            var model = mapper.Map<DeleteQAViewModel>(qaToBeDeleted);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteQAViewModel viewModel)
        {
            var qaToBeRemoved = await uoW.QAsRepository.GetQAByIdAsync(id);
            uoW.QAsRepository.Remove(qaToBeRemoved);

            if (await uoW.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Answer(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qA = await uoW.QAsRepository.GetQAByIdAsync((Guid)id);
            if (qA == null)
            {
                return NotFound();
            }
            var model = mapper.Map<AnswerQAViewModel>(qA);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(Guid id, AnswerQAViewModel viewModel)

        {
            var qA = await uoW.QAsRepository.GetQAByIdAsync(id);
            if (await TryUpdateModelAsync(viewModel, "", q => q.Answer))

                mapper.Map(viewModel, qA);

            if (ModelState.IsValid)
            {
                try
                {
                    await uoW.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QAExists(id))
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

        private bool QAExists(Guid id)
        {
            return uoW.QAsRepository.Any(id);
        }
    }
}