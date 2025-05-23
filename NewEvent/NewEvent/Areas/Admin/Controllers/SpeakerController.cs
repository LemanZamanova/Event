using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using NewEvent.DAL;
using NewEvent.Models;
using NewEvent.Utilities.Extensions;
using NewEvent.ViewModels;
using System.Collections.Generic;

namespace NewEvent.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles="Admin,Moderator")]
public class SpeakerController : Controller
{




    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;


    public SpeakerController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {

        List<GetSpeakerVM> speakerVM = await _context.Speakers.Select(s => new GetSpeakerVM

        {
            Name = s.Name,
            Surname = s.Surname,
            Image = s.Image,
            Id = s.Id,



        }
            ).ToListAsync();

        return View(speakerVM);
    }
    public async Task<IActionResult> Create()
    {


        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Create(int? id, CreateSpeakerVM createSpeakerVM)
    {
        if (id is null && id <= 0) return BadRequest();

        if (!ModelState.IsValid) return View();

        Speaker speaker = new Speaker
        {
            Name = createSpeakerVM.Name,
            Surname = createSpeakerVM.Surname,
            PositionId = createSpeakerVM.PositionId,
            Image = await createSpeakerVM.Photo.CreateFile(_env.WebRootPath, "assets", "images")
        };


        if (!createSpeakerVM.Photo.ValidateType("image/"))
        {
            ModelState.AddModelError("Photo", "File type is incorrect");
            return View(createSpeakerVM);
        }

        if (!createSpeakerVM.Photo.ValidateSize(Utilities.FileSize.MB, 1))
        {
            ModelState.AddModelError("Photo", "File size is incorrect");
            return View(createSpeakerVM);
        }


        await _context.AddAsync(createSpeakerVM);
        await _context.SaveChangesAsync();
        return RedirectToAction();


    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null && id <= 0) return BadRequest();

        if (!ModelState.IsValid) return View();
        Speaker? speaker = await _context.Speakers.FirstOrDefaultAsync(s => s.Id == id);


        _context.Remove(speaker);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id is null && id <= 0) return BadRequest();

        if (!ModelState.IsValid) return View();
        Speaker? existed = await _context.Speakers.FirstOrDefaultAsync(s => s.Id == id);



    }
}