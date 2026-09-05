using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoList.Controllers;

public class TaskListController : Controller
{
    private readonly ApplicationDbContext _context;
    public TaskListController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // get saved tasks
        var TaskLists = _context.TaskLists.ToList();
        return View("Index", TaskLists);
    }

    //funzione per creare la rotta
    [HttpGet]
    public IActionResult Create()
    {
        return PartialView();
    }
    //funzione per action creazione
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Title,Description,Important")] TaskList taskList)
    {
        //check if data is valid
        if (ModelState.IsValid)
        {
            var now = DateTime.UtcNow;

            taskList.CreatedAt = now;
            taskList.UpdatedAt = now;
            taskList.Title = taskList.Title.Trim();
            taskList.Description = taskList.Description?.Trim();
            //add data to the context
            _context.Add(taskList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Index");
    }

    //funzione rotta
    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var taskList = await _context.TaskLists.FirstOrDefaultAsync(task => task.Id == Id);
        return PartialView("_Edit", taskList);
    }
    //funzione modifica
    [HttpPost]
    public async Task<IActionResult> Edit(int Id, [Bind("Id,Title,Description,Important,Completed")] TaskList taskList)
    {
        // validazione dati
        if (ModelState.IsValid)
        {
            //cerco il record
            var taskToEdit = await _context.TaskLists.FirstOrDefaultAsync(task => task.Id == Id);
            if (taskToEdit != null)
            {
                //se record esiste modifico il context
                var now = DateTime.UtcNow;
                taskToEdit.Title = taskList.Title.Trim();
                taskToEdit.Description = taskList.Description?.Trim();
                taskToEdit.UpdatedAt = now;
                taskToEdit.Important = taskList.Important;
                taskToEdit.Completed = taskList.Completed;
                //salvo le modifiche nel db
                await _context.SaveChangesAsync();
            }
        }
        return RedirectToAction("Index");
    }

    //funzione rotta elimina
    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        var taskList = await _context.TaskLists.FirstOrDefaultAsync(task => task.Id == Id);
        return PartialView(taskList);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> ConfirmeDelete(int Id)
    {
        //controllo se il record esiste
        var taskList = await _context.TaskLists.FindAsync(Id);
        if(taskList != null)
        {
            //se record esiste lo rimuovo dal contesto
            _context.TaskLists.Remove(taskList);
            //operazione al db per salvare le modifiche
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
    // public async IActionResult Complete(int Id)
    // {
    //     //search the task
    //     var task = _context.
    //     //pass the task to next method
    // }
    // [HttpPost]
    // public IActionResult Complete(TaskList task)
    // {
    //     //check task completed

    //     //redirect to Index
    // }
}
